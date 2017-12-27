using Bygfoot.Helpers;
using NLog;
using System;
using Xwt;
using Xwt.Drawing;

namespace Bygfoot.Xwt
{
	public partial class SplashWindow : Window
	{
        private VBox vbox2 = null;
		private Notebook notebook1 = null;
		private ImageView image1 = null;
		private ScrollView scrolledwindow2 = null;
		private TreeView treeview_splash_contributors = null;
        private HSeparator hseparator3 = null;
        private VBox vbox3 = null;
        private HBox hbox2 = null;
        private ImageView image2 = null;
        private Label label4 = null;
        private Label label_splash_hintcounter = null;
        private Label label_splash_hint = null;
        private HBox hbox10 = null;
        private Button button_splash_hint_back = null;
        private Button button_splash_hint_next = null;
        private HSeparator hseparator4 = null;
        private HBox hbox3 = null;
        private Button button_splash_new_game = null;
        private Button button_splash_load_game = null;
        private Button button_splash_resume_game = null;
        private Button button_splash_quit = null;
        private HBox hbox7 = null;
        private Label label_splash_progress = null;
        private ProgressBar progressbar_splash = null;

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
			var image1File = FileHelper.FindSupportFile("bygfoot_splash.png", false);
			image1.Image = Image.FromFile(image1File);

            notebook1.Add(image1, "");

            treeview_splash_contributors = new TreeView();
            treeview_splash_contributors.Visible = true;
            treeview_splash_contributors.CanGetFocus = true;

            scrolledwindow2 = new ScrollView();
            scrolledwindow2.Visible = true;
            scrolledwindow2.CanGetFocus = true;
            scrolledwindow2.Content = treeview_splash_contributors;

			notebook1.Add(scrolledwindow2, "Contributors");

            vbox2.PackStart(notebook1);

            hseparator3 = new HSeparator();
            hseparator3.WidthRequest = 1;
            hseparator3.HeightRequest = 10;
            hseparator3.Visible = true;

            vbox2.PackStart(hseparator3);

            vbox3 = new VBox();
            vbox3.Visible = true;

            hbox2 = new HBox();
            hbox2.Visible = true;
            hbox2.Spacing = 3;

            image2 = new ImageView();
            // TODO use correct image: gtk-dialog-info
            image2.Image = StockIcons.Information;
            image2.HeightRequest = 5;

            hbox2.PackStart(image2);

            label4 = new Label();
            label4.Visible = true;
            label4.Text = "Did you know?";
            label4.TooltipText = "Splash screen hint question.";
            //label4.Markup

            hbox2.PackStart(label4);

            label_splash_hintcounter = new Label();
            label_splash_hintcounter.Visible = true;

            hbox2.PackEnd(label_splash_hintcounter);

            vbox3.PackStart(hbox2);

            label_splash_hint = new Label();
            label_splash_hint.HeightRequest = 90;
            label_splash_hint.Visible = true;
            label_splash_hint.MarginLeft = 5;
            label_splash_hint.Wrap = WrapMode.Word;

            vbox3.PackStart(label_splash_hint);

            hbox10 = new HBox();
            hbox10.Visible = true;
            hbox10.Spacing = 3;

            button_splash_hint_back = new Button();
            button_splash_hint_back.Visible = true;
            button_splash_hint_back.CanGetFocus = true;
            //button_splash_hint_back.receives_default = false;
            button_splash_hint_back.Clicked += on_button_splash_hint_back_clicked;

            button_splash_hint_back.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-go-back
            button_splash_hint_back.Image = StockIcons.Add;
            button_splash_hint_back.Label = "Previous";

            hbox10.PackStart(button_splash_hint_back);

            button_splash_hint_next = new Button();
            button_splash_hint_next.Visible = true;
            button_splash_hint_next.CanGetFocus = true;
            //button_splash_hint_back.receives_default = false;
            button_splash_hint_next.Clicked += on_button_splash_hint_next_clicked;

            button_splash_hint_next.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-go-forward
            button_splash_hint_next.Image = StockIcons.Add;
            button_splash_hint_next.Label = "Next";

            hbox10.PackEnd(button_splash_hint_next);

            vbox3.PackStart(hbox10);

            vbox2.PackStart(vbox3);

            hseparator4 = new HSeparator();
            hseparator4.WidthRequest = 1;
            hseparator4.HeightRequest = 10;
            hseparator4.Visible = true;

            vbox2.PackStart(hseparator4);

            hbox3 = new HBox();
            hbox3.Visible = true;
            hbox3.Spacing = 3;

            button_splash_new_game = new Button();
            button_splash_new_game.Visible = true;
            button_splash_new_game.CanGetFocus = true;
            //button_splash_new_game.receives_default = false;
            button_splash_new_game.TooltipText = "Ctrl-N";
            //button_splash_new_game.AcceleratorKey = "n";
            button_splash_new_game.Clicked += on_button_splash_new_game_clicked;

            button_splash_new_game.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-new
            button_splash_new_game.Image = StockIcons.Add;
            button_splash_new_game.Label = "Start _new game";

            hbox3.PackStart(button_splash_new_game);

            button_splash_load_game = new Button();
            button_splash_load_game.Visible = true;
            button_splash_load_game.CanGetFocus = true;
            //button_splash_load_game.receives_default = false;
            button_splash_load_game.TooltipText = "Ctrl-O";
            //button_splash_load_game.AcceleratorKey = "o";
            button_splash_load_game.Clicked += on_button_splash_load_game_clicked;

            button_splash_load_game.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-open
            button_splash_load_game.Image = StockIcons.Add;
            button_splash_load_game.Label = "_Load game";

            hbox3.PackStart(button_splash_load_game);

            button_splash_resume_game = new Button();
            button_splash_resume_game.Visible = true;
            button_splash_resume_game.CanGetFocus = true;
            //button_splash_resume_game.receives_default = false;
            button_splash_resume_game.TooltipText = "Ctrl-R";
            //button_splash_resume_game.AcceleratorKey = "r";
            button_splash_resume_game.Clicked += on_button_splash_resume_game_clicked;

            button_splash_resume_game.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-revert-to-saved
            button_splash_resume_game.Image = StockIcons.Add;
            button_splash_resume_game.Label = "_Resume game";

            hbox3.PackStart(button_splash_resume_game);

            button_splash_quit = new Button();
            button_splash_quit.Visible = true;
            button_splash_quit.CanGetFocus = true;
            //button_splash_quit.receives_default = false;
            button_splash_quit.TooltipText = "Esc";
            //button_splash_quit.AcceleratorKey = "Escape";
            button_splash_quit.Clicked += on_button_splash_quit_clicked;

            button_splash_quit.ImagePosition = ContentPosition.Left;
            // TODO use correct image: gtk-quit
            button_splash_quit.Image = StockIcons.Remove;
            button_splash_quit.Label = "_Quit";

            hbox3.PackEnd(button_splash_quit);

            vbox2.PackStart(hbox3);

            hbox7 = new HBox();
            hbox7.Visible = true;
            hbox7.Spacing = 3;

            label_splash_progress = new Label();
            label_splash_progress.WidthRequest = 400;
            label_splash_progress.Visible = true;
            label_splash_progress.TextAlignment = Alignment.Start;
            label_splash_progress.Text = "Ready";

            hbox7.PackStart(label_splash_progress);

            progressbar_splash = new ProgressBar();
            progressbar_splash.HeightRequest = 10;
            progressbar_splash.Visible = true;
            progressbar_splash.Fraction = 0.10000000149;

            hbox7.PackEnd(progressbar_splash);

            vbox2.PackEnd(hbox7);

            Content = vbox2;
		}
    }
}

