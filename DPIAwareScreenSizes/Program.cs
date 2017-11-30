using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DPIAwareScreenSizes
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            int width, height, top, bottom, left, right;

            width = SystemInformation.VirtualScreen.Width;
            height = SystemInformation.VirtualScreen.Size.Height;

            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Height: {0}", height);

            top = SystemInformation.VirtualScreen.Top;
            bottom = SystemInformation.VirtualScreen.Bottom;
            left = SystemInformation.VirtualScreen.Left;
            right = SystemInformation.VirtualScreen.Right;

            Console.WriteLine("Left: {0}", left);
            Console.WriteLine("Top: {0}", top);
            Console.WriteLine("Right: {0}", right);
            Console.WriteLine("Bottom: {0}", bottom);

            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(left, top), new Point(0, 0), new Size(Math.Abs(left) + right, bottom + Math.Abs(top)));
                }
                bmp.Save("1.jpg");
            }

            Console.ReadLine();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
