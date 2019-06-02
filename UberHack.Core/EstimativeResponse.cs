using System;
using System.Collections.Generic;
using System.Text;

namespace UberHack.Core
{
    public class EstimativeResponse
    {
        public Fare fare { get; set; }
        public Trip trip { get; set; }
        public int pickup_estimate { get; set; }


        public class Fare
        {
            public List<Breakdown> breakdown { get; set; }
            public double value { get; set; }
            public string fare_id { get; set; }
            public int expires_at { get; set; }
            public string display { get; set; }
            public string currency_code { get; set; }
        }

        public class Trip
        {
            public string distance_unit { get; set; }
            public int duration_estimate { get; set; }
            public double distance_estimate { get; set; }
        }

        public class Breakdown
        {
            public string type { get; set; }
            public string name { get; set; }
            public double value { get; set; }
        }




    }
}
