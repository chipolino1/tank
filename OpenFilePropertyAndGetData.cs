using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TankSpace
{
    public class OpenFilePropertyAndGetData
    {

        public void OpenFile()
        {
            FileStream fin;
            string s;

            try
            {
                fin = new FileStream("Property.txt", FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Console.SetCursorPosition(0, Karta.MaxTop+2);
                Console.WriteLine("you must put file Property.txt in folder" +
                                  " near with *.exe file! Please do it and restart program");
                Console.WriteLine("I load default property");

                Console.WriteLine("This must be load property --->>>");
                Console.WriteLine("This must be load property --->>>");
                Console.WriteLine("This must be load property --->>>");
                Console.WriteLine("This must be load property --->>>");
                
                return;

            }
            StreamReader fstrIn = new StreamReader(fin);

            // Считываем файл построчно.

            for (int i = 0; (i < 10); i++) //10 is wrong
            {
                
                s = fstrIn.ReadLine();
                if (s != null)
                {
                    //s=s.
                    



                }

            }

            fstrIn.Close();
       
        }

            }

         }

    

