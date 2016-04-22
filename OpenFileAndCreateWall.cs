using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TankSpace
{
  public  class OpenFileAndCreateWall
    {
      
        public void OpenFile() {
            FileStream fin;
            string s;
         
            try
            {
                fin = new FileStream("Test.txt", FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Console.SetCursorPosition(0,Karta.MaxTop);
                Console.WriteLine("you must put file Test.txt in folder" +
                                  " near with *.exe file please do it and restart program");
                Console.WriteLine("I create random Walls" );

            //  Wall w1 = new Wall(1, 1, 1, 2);
            //  Wall w2 = new Wall(15, 10, 16, 14);
                Karta.CreateRandomOneWall();
                Thread.Sleep(1);
                Karta.CreateRandomOneWall();

                return;
            }
             StreamReader fstrIn = new StreamReader(fin);
                // Считываем файл построчно.
             for (int i = 0; (i < Karta.MaxTop ); i++)
            {
                char[] arrayChar  = new char[Karta.MaxLeft];

                s = fstrIn.ReadLine();
                if (s!=null)
                {
                    arrayChar = s.ToCharArray();
                    for (int j = 0; (j < arrayChar.Length && j < Karta.MaxLeft); j++)
                    {
                          if (arrayChar[j] == '*'||arrayChar[j] == '1'||arrayChar[j] == '2'||
                              arrayChar[j] == '3'||arrayChar[j] == '4'||arrayChar[j] == '5'||
                              arrayChar[j] == '6'||arrayChar[j] == '7'||arrayChar[j] == '8'||
                              arrayChar[j] == '9'||arrayChar[j] == '*')
                     
                        {
                            Wall w = new Wall(j, i, j, i);
                        }
                       Karta.DrawWall();
                    }   
                }
                
            }
              
            fstrIn.Close();
            }

    }
}
