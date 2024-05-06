using AvailabilityConfig.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "Delete a camera or configuration in the Database. ",
        documentation: "Prompt the user to delete a camera or configuration using it's id as parameter.\n" +
        "command: delete <PARAMETER> where the parameter is camera or config.\n")]
    public class Delete : ICommand
    {
        public Task ExecuteCommandAsync(string[] args)
        {
            DeleteElement(args);
            return Task.CompletedTask;
        }

        private static void DeleteElement(string[] args)
        {
            try
            {

            }
            catch (ConfigException ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
}
