using System;
using System.Collections.Generic;
using System.Text;

namespace UberHack.Core
{
    public class RideRequest
    {
        public string fare_id { get; set; }
        public double start_latitude { get; set; }
        public double start_longitude { get; set; }
        public double end_latitude { get; set; }
        public double end_longitude { get; set; }
    }
}
