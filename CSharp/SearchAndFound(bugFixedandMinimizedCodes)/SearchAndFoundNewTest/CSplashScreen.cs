using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndFoundNewTest
{
    class CSplashScreen : CImageBase
    {
        public CSplashScreen(Bitmap _bitmap) : base(_bitmap)
        {
            Left = 250;
            Top = 140;
        }
    }
}
