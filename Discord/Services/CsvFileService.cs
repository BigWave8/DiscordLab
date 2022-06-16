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
    public class CsvFileService : ICsvFileService
    {
        private const string Server = "Server";
        private const string User = "User";
        private const string Chat = "Chat";
        private const string Message = "Message";
        private const string FilePath = @"C:\Projects\Discord\csvFile.csv";
        private readonly ICsvFileRepository _csvFileRepository;
        private readonly IServerService _serverService;
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;
        public CsvFileService(
            ICsvFileRepository csvFileRepository,
            IServerService serverService,
            IUserService userService,
            IChatService chatService,
            IMessageService messageService)
        {
            _csvFileRepository = csvFileRepository;
            _serverService = serverService;
            _userService = userService;
            _chatService = chatService;
            _messageService = messageService;
        }
        public Task ReadFile()
        {
            var list = _csvFileRepository.ReadFile(FilePath);
            foreach (var line in list)
            {
                string[] values = line.Split(',');
                switch (values[0])
                {
                    case Server:
                        _serverService.Insert(StringArrayToServerDto(values));
                        break;
                    case User:
                        _userService.Insert(StringArrayToUserDto(values));
                        break;
                    case Chat:
                        _chatService.Insert(StringArrayToChatDto(values));
                        break;
                    case Message:
                        _messageService.Insert(StringArrayToMessageDto(values));
                        break;
                }
            }
            return Task.CompletedTask;
        }
        private static ServerDto StringArrayToServerDto(string[] array)
        {
            return new ServerDto { Id = array[1], Name = array[2] };
        }
        private static UserDto StringArrayToUserDto(string[] array)
        {
            return new UserDto { Id = array[1], Name = array[2], MicroOn = array[3] != "0", SoundOn = array[4] != "0", ChatId = array[5] };
        }
        private static ChatDto StringArrayToChatDto(string[] array)
        {
            return new ChatDto { Id = array[1], Name = array[2], ServerId = array[3] };
        }
        private static MessageDto StringArrayToMessageDto(string[] array)
        {
            return new MessageDto { Id = array[1], Text = array[2], Time = DateTime.Parse(array[3]), ChatId = array[4], UserId = array[5] };
        }
    }
}
