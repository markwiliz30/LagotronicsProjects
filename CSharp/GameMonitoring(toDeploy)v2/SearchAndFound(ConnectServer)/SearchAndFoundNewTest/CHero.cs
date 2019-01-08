using SearchAndFoundNewTest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndFoundNewTest
{
    class CHero : CImageBase
    {
        public CHero(Bitmap _bitmap) : base(_bitmap)
        {
            Left = 12;
            Top = 280;
        }
    }
}
