using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.Models
{
    public class Collaborator
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int Id { get; internal set; }
    }
}
