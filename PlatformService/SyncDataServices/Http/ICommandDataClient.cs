using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlafatormService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platformReadDto);
    }
}