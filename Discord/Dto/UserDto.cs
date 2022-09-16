using System;
using System.Collections.Generic;

namespace Discord.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool MicroOn { get; set; }
        public bool SoundOn { get; set; }
        public string ChatId { get; set; }
    }
}
