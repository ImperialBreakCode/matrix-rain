using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRain.Base.Models.Exceptions
{
    public class MatrixRainException : Exception
    {
        public MatrixRainException(string msg) : base(msg)
        {
        }
    }
}
