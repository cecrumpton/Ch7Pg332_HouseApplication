using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7Pg332_HouseApplication
{
    abstract class Location
    {
        public Location(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public Location[] Exits { get; set; }
        public virtual string Description 
        {
            get
            {
                string description = "You're standing in the " + Name + ". You see exits to the following places:";
                for (int i = 0; i < Exits.Length;  i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ", ";
                }
                description += ".";
                return description;
            }
        }
    }
}
