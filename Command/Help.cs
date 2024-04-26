using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "help",
        documentation: "Displays on the console help information. \n" +
        "help <COMMAND NAME> to access help about a specific command.\n")]
    internal class Help: ICommand
    {
        private Dictionary<string, DocCommand> Docs;

        public Help()
        {
            Docs = Assembly.GetExecutingAssembly().GetTypes()
             .Where(t => t.GetCustomAttributes<DocCommand>().Any())
             .Select(t => t.GetCustomAttribute<DocCommand>()!)
             .ToDictionary(d => d.Instruction);
        }

        public Task ExecuteCommandAsync(string[] args)
        {
            this.DisplayDocumentation(args); 
            return Task.CompletedTask;
        }

        private void DisplayDocumentation(string[] parameters)
        {
            // if has lenght 1, no parameters were sent
            if (parameters.Length == 1)
            {
                Console.WriteLine($"\nAvailabilityConfig (1.0) - Command line app (CLI).");
                Console.WriteLine($"Create, Modify, Update and Delete configurations for camera monotoring.");
                Console.WriteLine($"Possible Commands: \n");

                foreach (var doc in Docs.Values)
                {
                    Console.WriteLine(doc.Documentation);
                }
            }
            // Display help with specific paramter
            else if (parameters.Length == 2)
            {
                string commandToDisplay = parameters[1];
                if (Docs.ContainsKey(commandToDisplay))
                {
                    var command = Docs[commandToDisplay];
                    Console.WriteLine(command.Documentation);
                }

            }
        }
    }
}

