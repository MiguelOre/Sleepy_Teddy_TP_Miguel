using System;
using System.Collections.Generic;
using System.Text;

namespace SleepyTeddy.Models
{
    public class Patients
    {
        public string Pacient_ID{ get; set; }
        public string Names { get; set; }
        public string Last_Names { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public string Administrator_ID { get; set; }
        public string Therapist_ID { get; set; }
    }
}
