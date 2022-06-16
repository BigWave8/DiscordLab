using Discord.Dto;
using Discord.Interfaces.Repository;
using Discord.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Services
{
    internal class ChatService : IChatService
    {
        private readonly IChatRepository _chatReporitory;
        public ChatService(IChatRepository chatReporitory)
        {
            _chatReporitory = chatReporitory;
        }
        public Task<IEnumerable<ChatDto>> GetAll()
        {
            return _chatReporitory.GetAll();
        }

        public Task<ChatDto> GetById(string id)
        {
            return _chatReporitory.GetById(id);
        }

        public Task<string> Insert(ChatDto chat)
        {
            return _chatReporitory.Insert(chat);
        }

        public Task Update(ChatDto chat)
        {
            return _chatReporitory.Update(chat);
        }

        public Task Delete(string id)
        {
            return _chatReporitory.Delete(id);
        }
    }
}
