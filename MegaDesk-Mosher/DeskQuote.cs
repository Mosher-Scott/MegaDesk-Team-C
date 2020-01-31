using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MegaDesk_Mosher
{
    class DeskQuote
    {
        //Get Rush Order
        //TODO: figure out file
        public int[,] GetRushOrder()
        {
            try
            {
            string path = @"c:..\..\rushOrderPrices.txt";
            string[] orderPrices = File.ReadAllLines(path);
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
