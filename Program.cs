/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2023/2/8
 * Time: 14:50
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace ApiSixManagementTool
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
