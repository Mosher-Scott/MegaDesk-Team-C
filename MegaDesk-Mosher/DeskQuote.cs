using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;


namespace MegaDesk_Mosher
{
    class DeskQuote
    {
        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string submitDate { get; set; }
        public double quoteTotal { get; set; }
        // TODO:  Change this from a txt file to json file
        public const string SAVEDQUOTEFILE = "savedQuotes.json";  // Since this won't change

        // Create an empty desk object to be used
        public Desk userDesk;

        // Create an empty list to hold all of the DeskQuotes
        // TODO:  Add a method to read from the saved quote file and populate this list when program starts
        public static List<DeskQuote> listOfQuotes = new List <DeskQuote> ();

        // Default constructor
        public DeskQuote() { }

        // Constructor with values
        public DeskQuote(string quoteFirstName, string quoteLastName, string quoteDate, double deskQuoteTotal, Desk quoteDesk)
        {
            clientFirstName = quoteFirstName;
            clientLastName = quoteLastName;
            submitDate = quoteDate;
            quoteTotal = deskQuoteTotal;
            userDesk = quoteDesk;
        }

        // This will read values from the savedQuotes file into the list listOfQuotes
        public static void readSavedQuotesFiles() {

            if (File.Exists(SAVEDQUOTEFILE)) {
                 // Read the file.
                string json = File.ReadAllText(SAVEDQUOTEFILE);

                listOfQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(json);
            }
           
        }

        // This will convert the DeskQuote object into a string object, and write it out to a file. NOT USING THIS METHOD
         /* public void convertToJson()
        {

            // Read the current file first
            using (StreamReader r = new StreamReader("savedQuotes.txt"))
            {
                string quotesFromFile = r.ReadToEnd();
                List<DeskQuote> quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotesFromFile);
                quotes.Add(this);
            }
            

            

            // First serialize the object
            string deskObject = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Specify a text file to write the data to
            string quoteTextFile = "savedQuotes.txt";

            // TODO: Create this as its own method and call it 
            // Write the objects to a file.  This will append to the file
            using (StreamWriter textFile = new StreamWriter(quoteTextFile, true))
            {
                textFile.WriteLine(deskObject);
            }
        }  */

        // Converts the list listOfQuotes into a json file, and saves it to savedQuotes.txt
        public void convertListToJson()
        {
            // Convert the object to a json string, indented
            var output = JsonConvert.SerializeObject(listOfQuotes, Formatting.Indented);

            // Specify a text file to write the data to.  Uses the costant variable in MainMenu.cs
            string quoteTextFile = SAVEDQUOTEFILE;

            // Write the objects to a file.  Use true to append the file, false to overwrite it
            using (StreamWriter textFile = new StreamWriter(quoteTextFile, false))
            {
                textFile.WriteLine(output);
            }
        }

        //Get Rush Order
        //TODO: figure out file
        public int[,] GetRushOrder()
        {
            try
            {
            string[] orderPrices = File.ReadAllLines("rushOrderPrices.txt");
            int[,] rushOrderGrid = new int[3, 3];

                //outer loop for rows, inner for columns
                int x = 0;
                int i;
                int j = 0;
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        int output = int.Parse(orderPrices[x]);
                        rushOrderGrid[i, j] = output;
                        //MessageBox.Show("Test:" + i + ", " + j + " " + rushOrderGrid[i,j]);
                        x++;
                    }

                }
                return rushOrderGrid;
            }

            catch (FileNotFoundException)
            {

                MessageBox.Show("Error. File containing rush order prices not found.");
                throw;
            }

        }

    }



}