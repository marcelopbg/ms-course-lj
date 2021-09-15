using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);

        bool PlatformExists(int platformId);
        bool ExternalPlatformExist(int externalPlatformId);

        IEnumerable<Command> GetCommandsForPlatform(int platformId);

        Command GetCommand(int platformid, int CommandId);

        void CreateCommand(int platformId, Command command);

    }
}