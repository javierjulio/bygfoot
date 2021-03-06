﻿using NLog;
using System;
using Xwt;

namespace Bygfoot.Xwt
{
	public class App
	{
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Run(ToolkitType type)
		{
            _logger.Debug("App.Run");
			Application.Initialize(type);

			SplashWindow splash = new SplashWindow();
			splash.Show();

			Application.Run();

			splash.Dispose();
			Application.Dispose();
		}
	}
}

