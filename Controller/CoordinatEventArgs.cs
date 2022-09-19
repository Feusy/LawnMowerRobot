using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CoordinatesEventArgs : EventArgs
    {
        public int[] Coordinates { get; set; }
    }
}
