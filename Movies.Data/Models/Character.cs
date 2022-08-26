using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Character
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        public string CharacterName { get; set; }
    }
}
