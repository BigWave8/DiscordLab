using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Models
{
    internal class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool MicroOn { get; set; }
        public bool VoiceOn { get; set; }
        public List<Server>? Servers { get; set; }
    }
}
