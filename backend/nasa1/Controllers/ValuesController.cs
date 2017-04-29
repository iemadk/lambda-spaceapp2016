using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nasa1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            List<string> result = new List<string>();
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                DateTime x = new DateTime(2017, 1, 3, 11, (DateTime.Now.Second % 6)*10, 0);
                //sensorReading srs = dc.sensorReadings.OrderBy(a=>a.UV).First(a => a.readingDate == x && a.sensorError * a.UV >0);
                //uvIndex uvResult = new uvIndex();
                //uvResult.area = (long) srs.area;
                //uvResult.host = srs.host;
                //uvResult.readingDate = (DateTime)srs.readingDate;
                //uvResult.UV = (int)srs.UV;


                Random r = new Random();
                int uvi = r.Next(1, 11);
                result.Add("" + uvi);
                if (uvi >= 0 && uvi <= 2)
                {
                    result.Add("Low");
                    result.Add("0.2");
                }
                else if (uvi >= 3 && uvi <= 5)
                {
                    result.Add("Medium");
                    result.Add("0.4");
                }
                else if (uvi >=6 && uvi <= 7)
                {
                    result.Add("High");
                    result.Add("0.6");
                }
                else if (uvi >= 8 && uvi <= 10)
                {
                    result.Add("Very High");
                    result.Add("0.8");
                }
                else
                {
                    result.Add("Extreme");
                    result.Add("1.0");
                }

                

            }



            return result;
        }

        // GET api/values/5
        public IEnumerable<string> Get(int id, string name)
        {
            return new string[] { name, id+"" };
        }

        // POST api/values
        public void Post()
        {
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                //DateTime x = new DateTime(2017, 1, 3, 11, (DateTime.Now.Second % 6) * 10, 0);
                //sensorReading srs = dc.sensorReadings.OrderBy(a => a.UV).First(a => a.readingDate == x && a.sensorError * a.UV > 0);
                //uvIndex uvResult = new uvIndex();
                //uvResult.area = (long)srs.area;
                //uvResult.host = srs.host;
                //uvResult.readingDate = (DateTime)srs.readingDate;
                //uvResult.UV = (int)srs.UV;
                //Random r = new Random();
                //int uvi = r.Next(1, 11);
                //uvResult.UVI = uvi;

                
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
