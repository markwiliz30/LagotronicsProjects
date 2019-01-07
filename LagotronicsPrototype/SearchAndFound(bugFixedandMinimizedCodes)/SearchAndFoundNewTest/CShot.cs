using SearchAndFoundNewTest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndFoundNewTest
{
    class CShot : CImageBase
    {
        public CShot()
            : base(Resources.crossheirsmall)
        {
        }
        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
        }
    }
}
