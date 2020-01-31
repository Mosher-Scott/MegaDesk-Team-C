using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace MegaDesk_Mosher
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {

            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();

            // Now close this window
            Close();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            //TODO: Finish this.
            // Now to read the JSON file back into the system
            // Method 1
            JObject o1 = JObject.Parse(File.ReadAllText("savedQuotes.txt"));

            MessageBox.Show(o1.ToString());

            //// Method 2: read JSON directly from a file
            //using (StreamReader file = File.OpenText(@"C:\testdownload\testjson3.txt"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}
        }
    }
}
