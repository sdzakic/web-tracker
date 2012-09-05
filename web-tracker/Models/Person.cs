using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_tracker.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Ime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Person() { }
        public Person(string im, double Long, double Lat) 
        { 
            Ime = im; Longitude = Long; Latitude = Lat; 
        }
    }
}