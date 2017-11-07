using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
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

                return InternalServerError();
            }

        }
    }
}
