using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Mosher
{
    class DeskQuote
    {
    }

    //Get Rush Order
      public int GetRushOrder(){
      string[] orderPrices = File.ReadAllLines("C:\\rushOrderPrices.txt");
      int[,] rushOrderGrid = new int[3,3];
        //outer loop for rows, inner for columns
            for ( int i = 0; i < 3; i++) {
                for ( int j = 0; j < 3; j++) {
              rushOrderGrid[i][j] = orderPrices;
           }
           statement(s);
        }
            
              try 
	        {	        
		
	        }
	        catch (Exception)
	        {

		        throw;
	        }
     
      }
      
     

    
}
