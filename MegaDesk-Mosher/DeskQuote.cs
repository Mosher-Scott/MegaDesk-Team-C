using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Mosher
{
    class DeskQuote
    {
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
