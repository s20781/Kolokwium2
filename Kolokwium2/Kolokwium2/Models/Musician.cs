using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public virtual IEnumerable<Musican_Track> Musican_Tracks { get; set; }
    }
}
