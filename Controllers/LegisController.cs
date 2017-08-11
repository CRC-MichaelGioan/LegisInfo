using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace CRCLegisInfoWS.Controllers
{
    [Produces("application/json")]
    [Route("api/Legis")]
    public class LegisController : Controller
    {
        //  Get settings.
        private readonly AppSettings appSettings;

        public LegisController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        //  GET: api/Legis
        //  Test API: http://localhost:50356/api/legisLocalReps/?address=90802
        [HttpGet]
        public string Get(string address)
        {
            List<AppRepresentative> repList = new List<AppRepresentative>();
            string ret = "", uri = "", data = "";

            //  Default ZIP code parameter.
            address = string.IsNullOrEmpty(address) ? "90802" : address;

            try
            {
                //  Get lat/lon parameters from address (address can be anything from landmark to ZIP code to completer address).
                uri = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", address, appSettings.GoogleAPIKey);
                data = getAPIData(uri);
                GoogleClasses.GooglePlace place = JsonConvert.DeserializeObject<GoogleClasses.GooglePlace>(data);

                //  Build URI to get State Senator & State Representative.
                uri = string.Format("https://openstates.org/api/v1/legislators/geo/?lat={0}&long={1}&apikey={2}", place.results[0].geometry.location.lat.ToString(), place.results[0].geometry.location.lng.ToString(), appSettings.OpenStatesAPIKey);
                data = getAPIData(uri);
                OpenStatesClasses.Legislator[] legis = JsonConvert.DeserializeObject<OpenStatesClasses.Legislator[]>(data);

                for (int i = 0; i < legis.GetLength(0); i++)
                {
                    AppRepresentative rep = new AppRepresentative();

                    rep.title = legis[i].chamber.ToLower() == "upper" ? "State Senator" : "State Representative";
                    rep.full_name = legis[i].full_name;
                    rep.party = legis[i].party;
                    rep.district = legis[i].district;
                    rep.office = legis[i].offices[0].name;
                    //  Some addresses contain CRLF character, translate.
                    rep.address = legis[i].offices[0].address.Replace('\n', '~').Replace("~", ", "); ;
                    rep.phone = legis[i].offices[0].phone;
                    rep.fax = legis[i].offices[0].fax;
                    rep.email = legis[i].offices[0].email;
                    rep.photo = legis[i].photo_url;
                    rep.active = legis[i].active;

                    repList.Add(rep);
                }

                //  Put State Senator fist, output JSON.
                repList.Reverse();
                ret = JsonConvert.SerializeObject(repList);
            }
            catch (Exception e)
            {
                string s = e.Message;
            }

            return ret;
        }

        //  Get data from remote web API resources.
        //  Data is returned as string (generally JSON). It is the resposibility of the caller to manipulate results.
        private static string getAPIData(string uri)
        {
            var data = "";

            //  Create HTTP client, send query and get results.
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(uri);
                    var response = client.GetAsync("").Result;
                    response.EnsureSuccessStatusCode(); // Throw exception if not successful.

                    data = response.Content.ReadAsStringAsync().Result;
                }
                catch (HttpRequestException e)
                {
                    //  Todo: log error.
                    string msg = e.Message;
                }

                client.Dispose();
            }

            return data;
        }

        // GET: api/Legis/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Legis
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Legis/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
