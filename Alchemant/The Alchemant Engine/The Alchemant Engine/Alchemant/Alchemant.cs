using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Alchemant_Engine
{
    class Alchemant
    {
        public void Logo()
        {
            Console.WriteLine(@" _____________");
            Console.WriteLine(@"/\            \");
            Console.WriteLine(@"\_|         o  |");
            Console.WriteLine(@"  |       888  |");
            Console.WriteLine(@"  |     8  88  |");
            Console.WriteLine(@"  |   8oooo88  |");
            Console.WriteLine(@"  | 88o  o888o |");
            Console.WriteLine(@"  | ___________|_");
            Console.WriteLine(@"  \/____________/");
            Console.WriteLine("");
        }

        public void Copywrite()
        {
            Console.WriteLine("The Alchemant Engine " + "(Vers 0.0.0.2b)");
            Console.WriteLine("Copyright © - 2019. All rights reserved.");
            Console.WriteLine("");
        }


        public void Input(string input)
        {
            switch (input.Split(' ').Length) // total command inputs
            {
                case 1: // 0 inputs
                    input0(input.Split(' ')[0]);
                    break;

                case 2: //1 inputs
                    input1(input.Split(' ')[0], input.Split(' ')[1]);
                    break;

                case 3: // 2 inputs
                    input2(input.Split(' ')[0], input.Split(' ')[1], input.Split(' ')[2]);
                    break;

                default: // error
                    GenErr();
                    break;
            }
        }

        public void input0(string input)
        {
            Folder folder = new Folder();

            switch (input) //finds correct method
            {

                case "help": // help
                    Help();
                    break;

                case "logo": // logo
                    Logo();
                    break;

                case "copyright": // logo
                    Copywrite();
                    break;

                case "show": // help
                    folder.Show();
                    break;

                default: // error
                    GenErr();
                    break;
            } // end of switch
        }

        public void input1(string input, string in1)
        {
            Folder folder = new Folder();

            switch (input) //finds correct method
            {
                case "load": // load
                    folder.Load(in1);
                    break;

                case "remove": // load
                    folder.Remove(in1);
                    break;

                default: // error
                    GenErr();
                    break;
            } // end of switch
        }

        public void input2(string input, string in1, string in2)
        {
            Folder folder = new Folder();

            switch (input) //finds correct method
            {
                case "attach": // attach
                    folder.Attach(in1, in2);
                    break;

                case "change": // attach
                    folder.Change(in1, in2);
                    break;

                case "rename": // attach
                    folder.Rename(in1, in2);
                    break;

                default: // error
                    GenErr();
                    break;
            } // end of switch
        }

        public void GenErr()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid command (type help for command list)");
            Console.ResetColor();
            Console.WriteLine("");
        }

        public void Help()
        {
            Console.WriteLine("Help:                         Shows all possible commands"); //template
            Console.WriteLine("Logo:                         Prints Alchemant's logo"); //template
            Console.WriteLine("Copyright:                    Prints the copyright info"); //template
            Console.WriteLine("Load: name                    Loads attached game"); //load info
            Console.WriteLine("Remove: name                  Remove the attached game link"); //load info
            Console.WriteLine("Attach: name, directory       Attaches a game to the script"); // attach info
            Console.WriteLine("Change: name, directory       Change the directory of the game"); //template
            Console.WriteLine("Rename: name, newName         Renames the game attachement"); //template
            Console.WriteLine("Show:                         Shows all attached games"); //load info
            Console.WriteLine("");
            //TODO HELP FULL
        }
    }
}