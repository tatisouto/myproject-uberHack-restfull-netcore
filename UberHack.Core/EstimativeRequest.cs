using System;

namespace UberHack.Core
{
    public class EstimativeRequest
    {
        public string product_id { get; set; }
        public string start_latitude { get; set; }
        public string start_longitude { get; set; }
        public string end_latitude { get; set; }
        public string end_longitude { get; set; }
        public string seat_count { get; set; }
    }
}
