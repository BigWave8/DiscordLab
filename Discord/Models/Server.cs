using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Models
{
    internal class Server
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }
        public List<Chat>? Chats { get; set; }
    }
}
