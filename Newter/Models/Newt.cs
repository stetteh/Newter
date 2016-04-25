using System;

namespace Newter.Models
{
    public class Newt
    {
        public int Id { get; set; }
        public virtual NewterUser Author { get; set; }

        public string TextBody { get; set; }
        public DateTime DateCreated { get; set; }
    }
}