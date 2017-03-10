using NLog;
using System;
using Xwt;
using Xwt.Drawing;

namespace Bygfoot.Xwt
{
	public partial class SplashWindow : Window
	{
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private VBox vbox2 = null;
		private Notebook notebook1 = null;
		private ImageView image1 = null;
		private ScrollView scrolledwindow2 = null;
		private TreeView treeview_splash_contributors = null;

		private void InitializeComponent()
		{
			Width = 550;
			Height = 600;
			//Location = WindowLocation.CenterScreen;

			vbox2 = new VBox();
			vbox2.Visible = true;
			vbox2.Spacing = 3;

			notebook1 = new Notebook();
			notebook1.Visible = true;
			notebook1.CanGetFocus = true;

			image1 = new ImageView();
			string file = FileHelper.FindSupportFile("bygfoot_splash.png", false);
			image1.Image = Image.FromFile(file);

			treeview_splash_contributors = new TreeView();

			scrolledwindow2 = new ScrollView();
			scrolledwindow2.Content = treeview_splash_contributors;

            string helpFile = FileHelper.FindSupportFile("bygfoot_help", true);
            if (string.IsNullOrEmpty(helpFile))
            {
                logger.Warn("Didn't find file 'bygfoot_help'.");
                //GameGUI.ShowWarning(Mono.Unix.Catalog.GetString("Didn't find file 'bygfoot_help'."));
                return;
            }
            OptionsList helpList = null;
            FileHelper.LoadOptFile(helpFile, helpList, false);

            notebook1.Add(image1, "");
			notebook1.Add(scrolledwindow2, "");
			vbox2.PackStart(notebook1);	

			Content = vbox2;
		}
	}
}

