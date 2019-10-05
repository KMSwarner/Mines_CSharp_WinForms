using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class ScoresForm : Form
    {
        private NameValueCollection allSettings;
        private List<string> initSettingsList;

        /// <summary>
        /// Constructor initilizes form and loads data for display
        /// </summary>
        public ScoresForm()
        {
            allSettings = ConfigurationManager.AppSettings;
            InitializeComponent();
            LoadAndDisplayScores(out initSettingsList);
        }

        /// <summary>
        /// Loads scores from Highscores.Settings
        /// </summary>
        /// <param name="settingsList"></param>
        /// <returns></returns>
        private List<string> LoadAndDisplayScores(out List<string> settingsList)
        {
            //Pull defaults from SettingsAll relating to these fields
            string key = "";
            string value = "";
            settingsList = new List<string>();

            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Tag != null)
                {
                    key = c.Tag.ToString();

                    try
                    {
                        value = Properties.Highscores.Default[key].ToString();
                    }

                    catch
                    {
                        value = "";
                    }

                    c.Text = value;

                    settingsList.Add(key + "=`" + value + "`");
                }
            }

            return settingsList;
        }

        /// <summary>
        /// Displays a dialog warning the player that all scores are about to be reset
        /// </summary>
        /// <param name="strMesg"></param>
        /// <param name="warningItems"></param>
        private void DisplayWarningDialog(string strMesg)
        {
            //Display a warning doalog with the given message
            string strMessage = strMesg + "\n";
            MessageBoxButtons mbBtn = MessageBoxButtons.OKCancel;

            MessageBox.Show(strMessage, "Reset scores?", mbBtn);
        }

        /// <summary>
        /// Calls zeroScores() and refreshes the form to reflect new data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //DisplayWarningDialog("Are you sure?");
            zeroScores();
            LoadAndDisplayScores(out initSettingsList);
        }

        /// <summary>
        /// Resets logged best times to "00:00:00"
        /// </summary>
        public void zeroScores()
        {
            Properties.Highscores.Default["beginnerScore"] = "00:00:00";
            Properties.Highscores.Default["intermediateScore"] = "00:00:00";
            Properties.Highscores.Default["expertScore"] = "00:00:00";
            Properties.Highscores.Default["defaultScore"] = "00:00:00";

            Properties.Highscores.Default.Save();
        }
    }
}
