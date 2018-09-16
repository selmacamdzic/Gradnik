using Gradnik_Data;
using System.Linq;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        MojContext context = new MojContext();
        // GET api/values/5
        public IHttpActionResult Get()
        {
            var test = context.Investitori.ToList();
            return Ok(test);
        }
    }
}
