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
    internal class ServerService : IServerService
    {
        private readonly IServerRepository _serverReporitory;
        public ServerService(IServerRepository serverReporitory)
        {
            _serverReporitory = serverReporitory;
        }
        public Task<IEnumerable<ServerDto>> GetAll()
        {
            return _serverReporitory.GetAll();
        }

        public Task<ServerDto> GetById(string id)
        {
            return _serverReporitory.GetById(id);
        }

        public Task<string> Insert(ServerDto server)
        {
            return _serverReporitory.Insert(server);
        }

        public Task Update(ServerDto server)
        {
            return _serverReporitory.Update(server);
        }

        public Task Delete(string id)
        {
            return _serverReporitory.Delete(id);
        }
    }
}
