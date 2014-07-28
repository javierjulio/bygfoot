using System;
using Xwt;

namespace Bygfoot.Xwt
{
	public class App
	{
		public static void Run(ToolkitType type)
		{
			Application.Initialize(type);

			SplashWindow splash = new SplashWindow();
			splash.Show();

			Application.Run();

			splash.Dispose();
			Application.Dispose();
		}
	}
}

