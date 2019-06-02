using System;
using System.Collections.Generic;
using System.Text;

namespace UberHack.Core
{
    public class RideResponse
    {
        public string request_id { get; set; }
        public string product_id { get; set; }
        public string status { get; set; }
        public object vehicle { get; set; }
        public object driver { get; set; }
        public object location { get; set; }
        public int? eta { get; set; }
        public object surge_multiplier { get; set; }
    }
}

