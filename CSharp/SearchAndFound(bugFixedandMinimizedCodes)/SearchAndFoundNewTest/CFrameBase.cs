using System;
using System.Drawing;

namespace SearchAndFoundNewTest
{
    class CFrameBase : IDisposable
    {
        bool disposed = false;
        Pen bgPen = new Pen(Color.Black, 5);
        public CFrameBase()
        {
        }
        public void DrawImage(Graphics gfx)
        {
                PointF Box1_point1 = new PointF(200, 110);
                PointF Box1_point2 = new PointF(490, 110);
                PointF Box1_point3 = new PointF(1080, 765);
                PointF Box1_point4 = new PointF(690, 1072);
                PointF Box1_point5 = new PointF(200, 1072);

                PointF test = new PointF(1894, 110);
                PointF test2 = new PointF(1894, 1072);
                PointF[] linePoints = { test, test2 };

                PointF[] curvePoints1 = { Box1_point1, Box1_point2, Box1_point3, Box1_point4, Box1_point5 };

                gfx.DrawPolygon(bgPen, curvePoints1);
                gfx.DrawLines(bgPen, linePoints);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                bgPen.Dispose();
            }

            disposed = true;
        }
    }
}
