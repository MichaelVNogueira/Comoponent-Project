using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    class Card
    {
        string _rank;
        ushort _value;

        internal Card(string rank, ushort value)
        {
            _rank = rank;
            _value = value;
        }

        public override string ToString() => $"{_rank}({_value})";
    }
}
