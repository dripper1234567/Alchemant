using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Alchemant_Engine
{
    public class Compiler
    {
        

        public void compile(string directory)
        {
            StreamReader file = new StreamReader(directory); // opens directory
            
            while (!file.EndOfStream)
            {
                
            } 
            file.Close();
        }
    }
}
