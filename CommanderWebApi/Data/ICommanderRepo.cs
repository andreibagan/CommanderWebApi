using CommanderWebApi.Models;
using System.Collections.Generic;

namespace CommanderWebApi.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void DeleteCommand(Command command);
    }
}
