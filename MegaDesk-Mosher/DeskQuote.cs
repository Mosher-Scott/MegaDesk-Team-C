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

        // Create an empty desk object to be used
        public Desk userDesk;

        public DeskQuote() {
}

        public DeskQuote(string quoteFirstName, string quoteLastName, string quoteDate, double deskQuoteTotal, Desk quoteDesk)
        {
            clientFirstName = quoteFirstName;
            clientLastName = quoteLastName;
            submitDate = quoteDate;
            quoteTotal = deskQuoteTotal;
            userDesk = quoteDesk;
        }

        // This 
        public void convertToJson()
        {


            // TODO: Add logic so if the file exists, do this.  If it does not exist, create it and write the data
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

            // Write the objects to a file.  This will append to the file
            using (StreamWriter textFile = new StreamWriter(quoteTextFile, true))
            {
                textFile.WriteLine(deskObject);
            }
        }
        //Get Rush Order
        public int[,] GetRushOrder()
        {
            try
            {
            string[] orderPrices = File.ReadAllLines("..\\MegaDesk-Mosher\\Properties\\rushOrderPrices.txt");
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

            catch (Exception)
            {

                throw;
            }

        }

    }
    
    
    
}
