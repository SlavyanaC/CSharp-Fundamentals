using System.Collections.Generic;

public interface ICommandManager
{
    string ProcessCommand(string commandName, List<string> args);
}
