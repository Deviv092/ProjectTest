using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTest.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string customer { get; set; }
        public string product { get; set; }
        public string remarks { get; set; }
    }
}