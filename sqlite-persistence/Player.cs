using System;
using System.Collections.Generic;
using System.Text;

namespace sqlite_persistence
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Shield { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
