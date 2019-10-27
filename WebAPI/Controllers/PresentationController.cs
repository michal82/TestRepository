using DataBaseLayer.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/presentation")]
    public class PresentationController : ApiController
    {
        [HttpGet]
        [Route("search")]
        public async Task<IHttpActionResult> Search(string NationalId)
        {
            return Ok(false);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IHttpActionResult> Detail(string NationalId)
        {
            var individ = new IndividualInformation();
            return Ok(individ);
        }
    }
}