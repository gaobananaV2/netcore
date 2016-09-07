using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType().Equals(this.GetType()) == false) return false;
            Person tmp = null;
            tmp = (Person)obj;
            return this.Name.Equals(tmp.Name) && this.Age.Equals(tmp.Age);
        }

        public override int GetHashCode()
        {
            return this.Age.GetHashCode() + this.Name.GetHashCode();
        }
    }
}
