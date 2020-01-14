using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Common
{
    public struct Move

        
    {
        


        public Move(Position from, Position to) 
            : this() //когато е структура
        {
            From = from;
            To = to;
        }
        public Position From { get; private set; }

        public Position To { get; private set; }
    }
}
