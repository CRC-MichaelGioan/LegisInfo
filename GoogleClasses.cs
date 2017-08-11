using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleClasses
{
    /////////////////////////////////  Google Places API classes  /////////////////////////////////

    
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class GooglePlace
    {
        public List<object> html_attributions { get; set; }
        public string next_page_token { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }

        public GooglePlace()
        {
            html_attributions = null;
            next_page_token = "";
            results = null;
            status = "";
        }
    }

    //------------------------------ Google Results (place details) ------------------------------
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }

        public AddressComponent()
        {
            long_name = "";
            short_name = "";
            types = null;
        }
    }

    public class Geometry
    {
        public Location location { get; set; }

        public Geometry()
        {
            location = null;
        }
    }

    public class Open
    {
        public int day { get; set; }
        public string time { get; set; }

        public Open()
        {
            day = 0;
            time = "";
        }
    }

    public class Close
    {
        public int day { get; set; }
        public string time { get; set; }

        public Close()
        {
            day = 0;
            time = "";
        }
    }

    public class Period
    {
        public Close close { get; set; }
        public Open open { get; set; }

        public Period()
        {
            close = null;
            open = null;
        }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public List<Period> periods { get; set; }
        public List<string> weekday_text { get; set; }

        public OpeningHours()
        {
            open_now = false;
            periods = null;
            weekday_text = null;
        }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public string place_id { get; set; }
        public int price_level { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }

        public Result()
        {
            address_components = null;
            adr_address = "";
            formatted_address = "";
            formatted_phone_number = "";
            geometry = null;
            icon = "";
            id = "";
            international_phone_number = "";
            name = "";
            opening_hours = null;
            place_id = "";
            price_level = 0;
            rating = 0.0;
            reference = "";
            types = null;
            url = "";
            utc_offset = 0;
            vicinity = "";
            website = "";
        }
    }

    public class GooglePlaceDetail
    {
        public List<object> html_attributions { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string vicinity { get; set; }
        public int price_level { get; set; }
        public double rating { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }
}
