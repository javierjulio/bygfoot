using Bygfoot.Helpers;
using NLog;
using System;
using System.IO;
using Xwt;

namespace Bygfoot.Xwt
{
	public partial class SplashWindow : Window
	{
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public SplashWindow()
		{
			InitializeComponent();

            //TreeViewHelper.ShowContributors(treeview_splash_contributors);

            Variables.hints = FileHelper.LoadHintsFile();

            LoadHintNumber();
            ShowHint();
        }

        protected override bool OnCloseRequested()
        {
            Application.Exit();
            return true;
        }

        /** Load the index of the hint to show in the splash screen. */
        private void LoadHintNumber()
        {
            _logger.Debug("SplashWindow.LoadHintNumber");

            string filename = Path.Combine(FileHelper.GetBygfootDir(), "hint_num");
            int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
            if (!File.Exists(filename))
            {
                Variables.Counters[counterIndex] = 0;
                return;
            }

            string sCounter = File.ReadAllText(filename);
            Variables.Counters[counterIndex] = 0;
            if (Int32.TryParse(sCounter, out Variables.Counters[counterIndex]))
            {
                if (Variables.Counters[counterIndex] < 0 ||
                    Variables.Counters[counterIndex] >= Variables.hints.Count)
                {
                    _logger.Debug("Hint counter out of bounds: {0} (bounds 0 and {1}).", Variables.Counters[counterIndex], Variables.hints.Count - 1);
                    Variables.Counters[counterIndex] = 0;
                }
            }
        }

        public void SaveHintNumber()
        {
            _logger.Debug("SplashWindow.SaveHintNumber");

            string filename = Path.Combine(FileHelper.GetBygfootDir(), "hint_num");
            int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
            File.WriteAllText(filename, Variables.Counters[counterIndex].ToString());
        }

        public void ShowHint()
        {
            _logger.Debug("SplashWindow.ShowHint");

            int index = Variables.Counters[(int)CounterType.COUNT_HINT_NUMBER];
            label_splash_hint.Text = Variables.hints[index].Value;
            label_splash_hintcounter.Text = string.Format("({0}/{1})", index + 1, Variables.hints.Count);
        }

        private void on_button_splash_hint_back_clicked(object sender, EventArgs e)
        {
            _logger.Debug("on_button_splash_hint_back_clicked");

            int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
            Variables.Counters[counterIndex] = Variables.Counters[counterIndex] == 0 ? Variables.hints.Count - 1 : Variables.Counters[counterIndex] - 1;
            ShowHint();
        }

        private void on_button_splash_hint_next_clicked(object sender, EventArgs e)
        {
            _logger.Debug("on_button_splash_hint_next_clicked");

            int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
            Variables.Counters[counterIndex] = (Variables.Counters[counterIndex] + 1) % Variables.hints.Count;
            ShowHint();
        }

        private void on_button_splash_new_game_clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void on_button_splash_load_game_clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void on_button_splash_resume_game_clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void on_button_splash_quit_clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

