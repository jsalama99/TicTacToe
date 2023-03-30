using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Square
    {
        public Square(SquareValue value) => this.Value = value;

        public SquareValue Value { get; set; }

        public enum SquareValue
        {
            X,
            O,
            Blank
        }
    }
}
