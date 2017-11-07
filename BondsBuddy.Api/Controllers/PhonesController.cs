using System.Linq;
using System.Net;
using System.Web.Http;
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

            var phonesToReturn = BondsBuddyDataStore.Current.Phones.ToList();

            return Ok(response);
        }
    }
}
