using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankSpace
{
    internal static class Karta
    {
       
        //якого бена в одних циклах йде від 1 а в інших від 0 ????
        //переробити щоб воно керектно хавало ліву і верхню границю
     

       public static char GunView = '/';
       public static char FirstFonInKartaView = '.';
       public static char WallView = 'w';

       public static int MinTop = 1;                  public static int MaxLeft = 50;
        
       public static int MinLeft = 0;                 public static int MaxTop = 20;
       
       public static int XForWall = MaxTop+3;

       public static char[,] GlobalCoordinate = new char[MaxLeft, MaxTop]; //!!!!!!!!!!!!!!!

        static Karta()
        {
            for (int i = 0; i < MaxTop; i++)
                for (int j = 0; j < MaxLeft; j++)
                
                {
                    GlobalCoordinate[j, i] = FirstFonInKartaView;
                }
            
        }

     

        public static void CreateRandomOneWall()
        {
            Random ran = new Random();

            int lef1=ran.Next(MinLeft,MaxLeft);
            int top1=ran.Next(MinTop,MaxTop);

            int lef2 = ran.Next(lef1, MaxLeft);
            int top2 = ran.Next(top1, MaxTop);


            Wall w = new Wall(lef1,top1,lef2,top2);
            //Wall W = new Wall(49, 2, 49, 15);
            
            Console.SetCursorPosition(0, XForWall++);
            Console.WriteLine("{0} {1} {2} {3} ",lef1,top1,lef2,top2);
     

        }


        public static void ClearKartaFromTank()
        {


            for (int i = 0; i < MaxTop; i++)
                for (int j = 0; j < MaxLeft; j++)
                {
                    if (GlobalCoordinate[j, i] == '*' | GlobalCoordinate[j, i] == '0' |
                        GlobalCoordinate[j, i] == '-' | GlobalCoordinate[j, i] == '#' )
                    {
                        GlobalCoordinate[j, i] = ' ';
                        Console.SetCursorPosition(j, i);
                        Console.Write(GlobalCoordinate[j, i]);


                    }

                }

        }

        
        public static void ClearKartaFromGun()
      {

          for (int i = 0; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  if (GlobalCoordinate[j, i] == Karta.GunView)
                  {

                      GlobalCoordinate[j, i] = ' ';
                      Console.SetCursorPosition(j, i);
                      Console.Write(GlobalCoordinate[j, i]);
                  }

              }
            
      }

      public static bool KartaHaveWall()
      {
          int k = 0;

          for (int i = 1; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  if (GlobalCoordinate[j, i] == WallView)
                      k++;
              }

          return k>0;
         
      }

      public  static void SetAndDrawDotInKarta() //Draw all karta
      {
         Console.Clear();
        
          Console.SetCursorPosition(10, 0);
          Console.Write("I AM A TANK  W-up  D-righ S-down A-left Q-exit Z-fire Shot== {0}",Gun.CountShot);

          for (int i = 1; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  GlobalCoordinate[j, i] = FirstFonInKartaView;
                  Console.SetCursorPosition(j, i);
                  Console.Write(GlobalCoordinate[j,i]);

              }
      }

        public static void DrawFirstEScreen(string x1,string y, string z)
        {
            Console.Clear();
          

            Console.SetCursorPosition(0, 5);
            Console.Write("**************************************************");
            Console.SetCursorPosition(0, 6);
            Console.Write("**************************************************");
            Console.SetCursorPosition(0, 11);
            Console.Write("**************************************************");
            Console.SetCursorPosition(0, 12);
            Console.Write("**************************************************");
            
            Console.SetCursorPosition(0, 7);
            Console.Write("**                                              **");
            Console.SetCursorPosition(0, 8);
            Console.Write("**                                              **");
            Console.SetCursorPosition(0, 9);
            Console.Write("**                                              **");
            Console.SetCursorPosition(0, 10);
            Console.Write("**                                              **");


            string x = x1;

            Console.SetCursorPosition(2, 7);

            foreach (char t in x)
            {
                Thread.Sleep(10);
                Console.Write(t);
            }

     
            x = y;
       
            Console.SetCursorPosition(2, 8);
            
            foreach (char t in x)
            {
                Thread.Sleep(10);
                Console.Write(t);
            }
            
            Console.SetCursorPosition(2, 9);
           
             x = z;
            
            foreach (char t in x)
            {
                Thread.Sleep(10);
                Console.Write(t);
            }
            
        }
        
      public static void DrawTank() //Draw only Tank
      {
          // Console.Clear();

          Console.SetCursorPosition(10, 0);
          Console.Write("I AM A TANK  W-up  D-righ S-down A-left Q-exit Z-fire Shot== {0}", Gun.CountShot);

          for (int i = 1; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  if (GlobalCoordinate[j, i] == '*' | GlobalCoordinate[j, i] == '0' | GlobalCoordinate[j, i] == '-' | GlobalCoordinate[j, i] == '#')
                  {
                      Console.SetCursorPosition(j, i);
                      Console.Write(GlobalCoordinate[j, i]);    
                  }

              }
      }
      public static void DrawGun() //Draw only Gun
      {
          // Console.Clear();

          Console.SetCursorPosition(10, 0);
          Console.Write("I AM A TANK  W-up  D-righ S-down A-left Q-exit Z-fire Shot== {0}  ", Gun.CountShot);

          for (int i = 1; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  if (GlobalCoordinate[j, i] == Karta.GunView)
                  {
                      Console.SetCursorPosition(j, i);
                      Console.Write(GlobalCoordinate[j, i]);
                      Thread.Sleep(20);
                  }

              }
      }
      public static void DrawWall() //Draw only Wall
      {
          // Console.Clear();

          Console.SetCursorPosition(10, 0);
          Console.Write("I AM A TANK  W-up  D-righ S-down A-left Q-exit Z-fire Shot== {0}", Gun.CountShot);

          for (int i = 1; i < MaxTop; i++)
              for (int j = 0; j < MaxLeft; j++)
              {
                  if (GlobalCoordinate[j, i] == WallView)
                  {
                      Console.SetCursorPosition(j, i);
                      Console.Write(GlobalCoordinate[j, i]);
                      
                  }
                 // Thread.Sleep(10);
              }
      }
    }
}
