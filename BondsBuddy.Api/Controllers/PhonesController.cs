using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BondsBuddy.Api.Models;
using BondsBuddy.Api.Models.Dtos;
using BondsBuddy.Api.Models.Responses;

namespace BondsBuddy.Api.Controllers
{
    [RoutePrefix("api/v1/phones")]
    public class PhonesController : ApiController
    {
        [HttpGet, Route("", Name = "GetAllPhones")]
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
    }
}
