using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newter.Models
{
    public class NewterUserVm
    {
        public string Handle { get; set; }
        public string Followers { get; set; }
        public string Following { get; set; }
    }

    public class NewterVM
    {
        public string Id { get; set; }
        public string Handle { get; set; }
        public string TextBody { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ProfileVM
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string TextBody { get; set; }
        public DateTime DateCreated { get; set; }
    }
}