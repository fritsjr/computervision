using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rasterizer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            Matrix m = Matrix.identity();
            Matrix m1 = Matrix.identity();
            Vector3 v = new Vector3(2, 3, 4);
            Vector3 v1;
            Matrix m2;
            v1 = m * v;
            m2 = m * m1;




			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
