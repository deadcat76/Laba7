using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class University
    {
        public string Name { get; set; }
        public University(string name)
        {
            Name = name;
        }
    }
}
