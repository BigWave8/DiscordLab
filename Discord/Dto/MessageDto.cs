﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Dto
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string ChatId { get; set; }
        public string UserId { get; set; }
    }
}
