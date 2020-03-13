using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Alchemant_Engine
{
    class Folder
    {
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string folder;
        public string files;

        public void SetLocation(string a, string b)
        {
            folder = a;
            files = b;
        }

        public bool Try()
        {
            if (!System.IO.File.Exists(path + folder + files)) // if it isn't there already
            {
                Directory.CreateDirectory(path + folder);  //make the dir

                try // did any of you happen to open a file on the way here?
                {
                    StreamWriter file = new StreamWriter(path + folder + files);
                    file.Close();
                }
                catch (Exception) // no?
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hmm, someone left a window open and a bug has flown in."); // then we still have a problem
                    Console.ResetColor();
                    return false; // and a knife
                }
            }
            return true;
        }

        public void Attach(string name, string directory)
        {
            if (File.Exists(directory)) //sees if file exists
            {
                StreamWriter file = new StreamWriter(path + folder + files);  // opens directory
                file.WriteLine(name + ";" + directory + ";"); // adds the data to thre directory
                file.Close(); //closes the directory
            }
            else // give error message
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Empty or broken directory");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }

        public void Change(string name, string directory)
        {
            StreamReader file = new StreamReader(path + folder + files); // opens directory
            List<string> data = new List<string>();

            while (!file.EndOfStream)
            {
                data.Add(file.ReadLine()); //add file data to list
            }
            file.Close();

            if (!data.Contains(directory)) //sees if file exists
            {
                if (!File.Exists(directory)) //sees if file exists
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Empty or broken directory");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
                else
                {
                    File.WriteAllText(path + folder + files, "");
                    StreamWriter file2 = new StreamWriter(path + folder + files);
                    for (int i = 0; i < data.Count;)
                    {
                        if (data[i].Split(';')[0] == name)
                        {
                            data[i] = data[i].Split(';')[0] + ";" + directory + ";";
                        }
                        file2.WriteLine(data[i]);
                        i++;
                    }
                    file2.Close();
                }
            }
            else // give error message
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory already in use");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }

        public void Rename(string name, string newName)
        {
            StreamReader file = new StreamReader(path + folder + files); // opens directory
            List<string> data = new List<string>();

            while (!file.EndOfStream)
            {
                data.Add(file.ReadLine()); //add file data to list
            }
            file.Close();

            if (!data.Contains(newName)) //sees if file exists
            {
                File.WriteAllText(path + folder + files, "");
                StreamWriter file2 = new StreamWriter(path + folder + files);
                for (int i = 0; i < data.Count;)
                {
                    if (data[i].Split(';')[0] == name)
                    {
                        data[i] = newName + ";" + data[i].Split(';')[1] + ";";
                    }
                    file2.WriteLine(data[i]);
                    i++;
                }
                file2.Close();
            }
            else // give error message
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name already in use");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }

        public void Remove(string name)
        {
            StreamReader file = new StreamReader(path + folder + files); // opens directory
            List<string> data = new List<string>();

            while (!file.EndOfStream)
            {
                data.Add(file.ReadLine()); //add file data to list
            }
            file.Close();

            bool Is = false;

            for(int i = 0; i < data.Count;)
            {
                if (data[i].Split(';')[0] == name)
                {
                    Is = true;
                    break;
                }
                i++;
            }

            if (Is) //sees if file exists
            {
                File.WriteAllText(path + folder + files, "");
                StreamWriter file2 = new StreamWriter(path + folder + files);
                for (int i = 0; i < data.Count;)
                {
                    if (data[i].Split(';')[0] == name)
                    {
                        data[i].Remove(i, data[i].Length);
                    }
                    else
                    {
                        file2.WriteLine(data[i]);
                    }
                    i++;
                }
                file2.Close();
            }
            else // give error message
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name not in use");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }

        public void Load(string name)
        {
            StreamReader file = new StreamReader(path + folder + files); // dir.txt reader

            if (file.ReadToEnd() != "" || file.ReadToEnd() != null) //if data is available
            {
                file.Close(); //close it wonce ti is done

                StreamReader file2 = new StreamReader(path + folder + files); // dir.txt reader
                List<string> data = new List<string>();

                while (!file2.EndOfStream)
                {
                    var line = file2.ReadLine();
                    var values = line.Split(';');
                    for (var i = 0; i < line.Split(';').Length; i++)
                        data.Add(values[i]); //example usage
                }
                file2.Close();

                if (data.Contains(name)) // if found execute the following
                {
                    Compiler compiler = new Compiler();
                    compiler.compile(data[data.IndexOf(name) + 1]);
                }
                else //if not found output error message
                {
                    //close it wonce ti is done
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid or missing name");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
            else // if there is nothing output error message
            {
                 //close it wonce ti is done
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory is empty");
                Console.ResetColor();
                Console.WriteLine("");
            }

            file.Close();
        }

        public void Show()
        {
            StreamReader file = new StreamReader(path + folder + files); // dir.txt reader
            if (file.ReadToEnd() != "" || file.ReadToEnd() != null) //if data is available
            {
                file.Close();

                StreamReader file2 = new StreamReader(path + folder + files); // dir.txt reader
                List<string> data = new List<string>();

                while (!file2.EndOfStream)
                {
                    data.Add(file2.ReadLine()); //add file data to list
                }
                file2.Close();

                for (int i = 0; i < data.Count;)
                {
                    Console.WriteLine(data[i].Split(';')[0] + " (" + data[i].Split(';')[1] + ")");
                    Console.WriteLine("");
                    i++;
                }
            }
            else // if there is nothing output error message
            {
                file.Close();
                //close it wonce ti is done
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory is empty");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }
    }
}
