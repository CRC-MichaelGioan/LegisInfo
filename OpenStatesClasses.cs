using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenStatesClasses
{
    public class Source
    {
        public string url { get; set; }
    }

    public class Role
    {
        public string term { get; set; }
        //public object end_date { get; set; }
        public string district { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string party { get; set; }
        public string type { get; set; }
        public object start_date { get; set; }
        public string committee_id { get; set; }
        //public object subcommittee { get; set; }
        public string committee { get; set; }
        public string position { get; set; }
    }

    public class Office
    {
        public object fax { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string email { get; set; }
    }

    public class Legislator
    {
        public string last_name { get; set; }
        public string updated_at { get; set; }
        public List<Source> sources { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string district { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string boundary_id { get; set; }
        public string email { get; set; }
        public List<string> all_ids { get; set; }
        public string leg_id { get; set; }
        public string party { get; set; }
        public bool active { get; set; }
        public string transparencydata_id { get; set; }
        public string photo_url { get; set; }
        public List<Role> roles { get; set; }
        public string url { get; set; }
        public string created_at { get; set; }
        public List<Office> offices { get; set; }
        public string suffixes { get; set; }
    }
}
