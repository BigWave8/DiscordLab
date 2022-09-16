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
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public Task<IEnumerable<MessageDto>> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public Task<MessageDto> GetById(string id)
        {
            return _messageRepository.GetById(id);
        }

        public Task<string> Insert(MessageDto message)
        {
            return _messageRepository.Insert(message);
        }

        public Task Update(MessageDto message)
        {
            return _messageRepository.Update(message);
        }

        public Task Delete(string id)
        {
            return _messageRepository.Delete(id);
        }
    }
}
