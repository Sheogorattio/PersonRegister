using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister
{
    public class Person: IPerson
    {
        public string Name { get; set; }
        public int Age { get;set; }

        public Person(string name, int age )
        {
            Name = name;
            Age = age;
        }

        public Person() { }

        public void Save()
        {
            StreamWriter sw = new StreamWriter("Database.txt",true);
            sw.WriteLine(Name+"\n"+Age.ToString());
            sw.Close();
        }

        public string Load()
        {
            StringBuilder Result = new StringBuilder();
            StreamReader sr = new StreamReader("Database.txt", Encoding.UTF8);
            if (sr != null)
             while(!sr.EndOfStream)
                Result.Append(sr.ReadLine()+'\n');
            sr.Close();
            return Result.ToString();
        }
    }
}
