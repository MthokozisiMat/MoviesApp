using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string ActorName { get; set; }
        [Column("Actor DOB")]
        public DateTime ActorDOB { get; set; }
    }
}
