using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TestingWebProjectFramework.Controllers
{
    /// <summary>
    /// https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
    /// https://www.microsoft.com/en-us/download/details.aspx?id=58210
    /// </summary>
    public class AsyncClass
    {
        public AsyncClass()
        {
            //Get().Wait();            
        }

        public async Task GetGet()
        {
            await Get();
            //await Get().ConfigureAwait(false); 
        }

        public async Task Get()
        {           
            await Task.Delay(300);
            // await Task.Delay(300).ConfigureAwait(false);
            // var request = HttpContext.Current.Request.Url;
        }
    }

    public class ValuesController : ApiController
    {
        AsyncClass asyncClass = new AsyncClass();

        // GET api/values
        public IEnumerable<string> Get()
        {
            var request = HttpContext.Current.Request.Url;
            //asyncClass.Get().Wait();
            asyncClass.GetGet().Wait();
            return new string[] { "value1", "value2" };
        }

    }
}
