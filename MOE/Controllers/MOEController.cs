using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MOE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MOEController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "API is running." };
        }

        [HttpPost]
        public string Exec()
        {
            JObject json = JObject.Parse(Request.Form["values"]);
            var numbers = json["numbers"].ToArray();

            string result = "{\"result\": [";

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder;

                result += "\"number\": \"" + numbers[i] + "\",";

                Math.DivRem((int)numbers[i], 11, out remainder);

                if (remainder == 0)
                {
                    result += "\"isMultiple\": \"true\"}";
                }
                else
                {
                    result += "\"isMultiple\": \"false\"}";
                }

                if (i < numbers.Length - 1)
                {
                    result += ",";
                }
            }

            result += "]}";

            return result;
        }
    }
}
