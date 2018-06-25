using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleAspMvcWcfApp.Models
{
    public class Employee
    {
        public int Empid { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Title { get; set; }
        public string Titleofcourtesy { get; set; }
        public System.DateTime Birthdate { get; set; }
        public System.DateTime Hiredate { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Mgrid { get; set; }
    }
}