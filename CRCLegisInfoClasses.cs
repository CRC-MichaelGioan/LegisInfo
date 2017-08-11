using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRCLegisInfoWS
{
    //  API keys used in various services.
    public class AppSettings
    {
        public string GoogleAPIKey { get; set; }
        public string OpenStatesAPIKey { get; set; }
    }

    public class AppCoordinates
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class AppRepresentative
    {
        public string title { get; set; }
        public string full_name { get; set; }
        public string party { get; set; }
        public string district { get; set; }
        public string office { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public object fax { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public bool active { get; set; }
    }
}
