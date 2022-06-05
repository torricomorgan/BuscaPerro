namespace BuscaPerro.Domain.Mascota.DTO
{
    public class Rootobject
    {
        public string threegeonames { get; set; }
        public string geonumber { get; set; }
        public Nearest nearest { get; set; }
        public Osmtags osmtags { get; set; }
        public string geocode { get; set; }
        public Major major { get; set; }
        public Adminareas adminareas { get; set; }
    }

    public class Nearest
    {
        public string inlatt { get; set; }
        public string distance { get; set; }
        public string timezone { get; set; }
        public string elevation { get; set; }
        public Region region { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string latt { get; set; }
        public string longt { get; set; }
        public string city { get; set; }
        public string prov { get; set; }
        public string inlongt { get; set; }
        public string altgeocode { get; set; }
    }

    public class Region
    {
    }

    public class Osmtags
    {
        public string wikidata { get; set; }
        public string is_in_state { get; set; }
        public string name { get; set; }
        public string is_in_country { get; set; }
        public string state { get; set; }
        public string admin_level { get; set; }
        public string is_in_province { get; set; }
        public string boundary { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Major
    {
        public string inlatt { get; set; }
        public string distance { get; set; }
        public string timezone { get; set; }
        public string elevation { get; set; }
        public Region1 region { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string latt { get; set; }
        public string longt { get; set; }
        public string city { get; set; }
        public string prov { get; set; }
        public string inlongt { get; set; }
    }

    public class Region1
    {
    }

    public class Adminareas
    {
        public Admin6 admin6 { get; set; }
        public Admin8 admin8 { get; set; }
    }

    public class Admin6
    {
        public string wikipedia { get; set; }
        public string wikidata { get; set; }
        public string population { get; set; }
        public string is_in_state { get; set; }
        public string osmid { get; set; }
        public string name { get; set; }
        public string is_in_country { get; set; }
        public string admin_level { get; set; }
        public string level { get; set; }
        public string boundary { get; set; }
        public string type { get; set; }
    }

    public class Admin8
    {
        public string wikidata { get; set; }
        public string is_in_state { get; set; }
        public string osmid { get; set; }
        public string name { get; set; }
        public string is_in_country { get; set; }
        public string is_in_province { get; set; }
        public string admin_level { get; set; }
        public string level { get; set; }
        public string boundary { get; set; }
        public string type { get; set; }
    }
}

