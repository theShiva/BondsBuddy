﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BondsBuddy.Api.Models;
using BondsBuddy.Api.Models.Dtos;
using BondsBuddy.Api.Models.Responses;
using BondsBuddy.Core.Helpers;
using BondsBuddy.Core.Models;

namespace BondsBuddy.Api.Controllers
{
    /// <summary>
    /// Phones Resource
    /// </summary>
    [RoutePrefix("api/v1/phones")]
    public class PhonesController : ApiController
    {
        /// <summary>
        /// Get all Phones
        /// </summary>
        /// <remarks>Gets a list of all Phones</remarks>
        /// <returns></returns>
        [HttpGet, Route("", Name = "GetAllPhones")]
        [ResponseType(typeof(PhonesResponse))]
        public IHttpActionResult Get()
        {
            var response = new PhonesResponse();

            try
            {
                var phones = BondsBuddyDataStore.Current.Phones.ToList();

                var phonesToReturn = Mapper.Map<List<Phone>, List<PhoneDto>>(phones);

                response.Meta.HttpStatusCode = (int)HttpStatusCode.OK;
                response.Phones = phonesToReturn;

                return Ok(response);
            }
            catch (Exception exception)
            {
                    // TODO: Log Exception details
                Console.WriteLine(exception.Message);

                response.Meta.HttpStatusCode = (int) HttpStatusCode.InternalServerError;
                response.Meta.ErrorMessage =
                    "Oops! An unexpected error occurred. Our DevOps is investigating. Please try again later.";
                response.Meta.ErrorType = "ApiServerError";

                    // Reference: https://stackoverflow.com/a/34890211/325521
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        response));
            }

        }

        /// <summary>
        /// Gets a Phone by Id (not number)
        /// </summary>
        /// <param name="id">The Id of the Phone to get</param>
        /// <returns></returns>
        [HttpGet, Route("{id}", Name = "GetPhone")]
        [ResponseType(typeof(PhoneResponse))]
        public IHttpActionResult Get(int id)
        {
            var response = new PhoneResponse();

            var phone = BondsBuddyDataStore.Current.Phones.FirstOrDefault(a => a.Id == id);

            if (phone == null)
            {
                response.Meta.HttpStatusCode = (int)HttpStatusCode.NotFound;
                response.Meta.ErrorMessage =
                    $"Phone with Id = {id} not found!";
                response.Meta.ErrorType = "ApiServerError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.NotFound,
                        response)
                        );
            }

            var phonesToReturn = Mapper.Map<Phone, PhoneDto>(phone);

            response.Meta.HttpStatusCode = (int)HttpStatusCode.OK;
            response.Phone = phonesToReturn;

            return Ok(response);
        }

        /// <summary>
        /// Saves a new Phone
        /// </summary>
        /// <param name="newPhone">The Phone to save</param>
        /// <returns></returns>
        [HttpPost, Route("", Name = "SaveSinglePhone")]
        [ResponseType(typeof(PhoneResponse))]
        public IHttpActionResult SavePhone([FromBody] PhoneForCreationDto newPhone)
        {
            var response = new PhoneResponse();

            if (string.IsNullOrEmpty(newPhone?.PhoneNumber))
            {
                response.Meta.HttpStatusCode = (int)HttpStatusCode.BadRequest;
                response.Meta.ErrorMessage = "Phone Number is null!";
                response.Meta.ErrorType = "DataValidationError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        response)
                );
            }

            if (!ModelState.IsValid)
            {
                response.Meta.HttpStatusCode = (int)HttpStatusCode.BadRequest;
                response.Meta.ErrorMessage = "Phone object contains Invalid data";
                response.Meta.ErrorType = "DataValidationError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        response)
                );                
            }

                // parse the incoming string and see if it's a valid phone number
            var parsedPhone = PhoneHelper.Parse(newPhone.PhoneNumber);

            if (parsedPhone == null)
            {
                response.Meta.HttpStatusCode = (int)HttpStatusCode.BadRequest;
                response.Meta.ErrorMessage = $"Phone Number = {newPhone.PhoneNumber} is Invalid!";
                response.Meta.ErrorType = "InvalidDataError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        response));
            }

            try
            {
                if (BondsBuddyDataStore.Current.Phones.Exists(p => p.RawPhoneNumber == parsedPhone.RawPhoneNumber))
                {
                    response.Meta.HttpStatusCode = (int)HttpStatusCode.Conflict;
                    response.Meta.ErrorMessage = $"Phone object with Phone Number = {newPhone.PhoneNumber} already exists in database!";
                    response.Meta.ErrorType = "DataValidationError";

                    return ResponseMessage(
                        Request.CreateResponse(
                            HttpStatusCode.Conflict,
                            response));
                }

                int maxPhoneId = BondsBuddyDataStore.Current.Phones.Any() ? BondsBuddyDataStore.Current.Phones.Max(a => a.Id) : 0 ;

                var phoneToCreate = Mapper.Map<CanonicalPhoneNumber, Phone>(parsedPhone);

                phoneToCreate.Id = ++maxPhoneId;
                phoneToCreate.PhoneName = newPhone.PhoneName;

                BondsBuddyDataStore.Current.Phones.Add(phoneToCreate);

                var newlyCreatedPhone = BondsBuddyDataStore.Current.Phones.First(a => a.Id == phoneToCreate.Id);

                response.Meta.HttpStatusCode = (int)HttpStatusCode.OK;

                var newlyCreatedPhoneDto = Mapper.Map<Phone, PhoneDto>(newlyCreatedPhone);
                response.Phone = newlyCreatedPhoneDto;

                return CreatedAtRoute("GetPhone", new { id = phoneToCreate.Id }, response);
            }
            catch (Exception exception)
            {
                // TODO: Log Exception details
                Console.WriteLine(exception.Message);

                response.Meta.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.Meta.ErrorMessage =
                    "Oops! An unexpected error occurred. Our DevOps is investigating. Please try again later.";
                response.Meta.ErrorType = "ApiServerError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        response));
            }            
        }

        /// <summary>
        /// Deletes a Phone
        /// </summary>
        /// <param name="id">Id of the Phone to delete from the database.</param>
        /// <returns></returns>
        [HttpDelete, Route("{id}", Name = "DeletePhone")]
        [ResponseType(typeof(PhoneResponse))]
        public IHttpActionResult DeletePhone(int id)
        {
            var response = new PhoneResponse();

            try
            {
                var phoneToDelete = BondsBuddyDataStore.Current.Phones.FirstOrDefault(p => p.Id == id);

                if (phoneToDelete == null)
                {
                    response.Meta.HttpStatusCode = (int)HttpStatusCode.NotFound;
                    response.Meta.ErrorMessage =
                        $"Phone with Id = {id} not found!";
                    response.Meta.ErrorType = "NotFoundError";

                    return ResponseMessage(
                        Request.CreateResponse(
                            HttpStatusCode.NotFound,
                            response));
                }

                BondsBuddyDataStore.Current.Phones.Remove(phoneToDelete);

                response.Meta.HttpStatusCode = (int)HttpStatusCode.NoContent;

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.NoContent,
                        response));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                response.Meta.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.Meta.ErrorMessage =
                    "Oops! An unexpected error occurred. Our DevOps is investigating. Please try again later.";
                response.Meta.ErrorType = "ApiServerError";

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        response));
            }

        }
    }
}
