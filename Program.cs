using System;
using TankSpace;
using System.Threading;



namespace _111
{
    class TankMainClass
    {
      public  static bool FlagWeInProgram = true;

        private static void Main()
        {
            bool bodyTank = true;

            while (bodyTank)
            {

                Karta.DrawFirstEScreen("Tank v0.1","   you must kill all walls","  please press Enter to start");
                Console.ReadLine();
                Karta.SetAndDrawDotInKarta();
                var a = new Tank();
                
              a.Draw();

               // Wall w1 = new Wall(1, 10, 3, 10);

                // Wall w2 = new Wall(15, 10, 16, 14);
                OpenFileAndCreateWall fff = new OpenFileAndCreateWall();
                fff.OpenFile();

                //Console.Clear();
               // Karta.CleanKarta();
            

                while (FlagWeInProgram)
                {
                    Console.SetCursorPosition(0, 0);
                    //char x = char.Parse(Console.ReadLine());

                    //  char x = Convert.ToChar(Console.ReadKey());
                    var key = Console.ReadKey();
                    var x = key.KeyChar;

                    if (x == 'q') break;
                    if (x == 'й') break;

                    if (x == 'w') a.UpDate(DirectionEnum.Up);
                    if (x == 'd') a.UpDate(DirectionEnum.Right);
                    if (x == 's') a.UpDate(DirectionEnum.Down);
                    if (x == 'a') a.UpDate(DirectionEnum.Left);

                    if (x == 'ц') a.UpDate(DirectionEnum.Up);
                    if (x == 'в') a.UpDate(DirectionEnum.Right);
                    if (x == 'ы') a.UpDate(DirectionEnum.Down);
                    if (x == 'ф') a.UpDate(DirectionEnum.Left);

                    if (x == 'і') a.UpDate(DirectionEnum.Down);

                    if (x == 'z') a.Fire();
                    if (x == 'я') a.Fire();
                    
                    if (x == 'p') a.AutoPilot();
                    if (x == 'з') a.AutoPilot();



                    //    Karta.DrawKarta();

                    // System.Threading.Thread.Sleep(1000);

                }

                //Karta.DrawKarta();

                //    Console.SetCursorPosition(10, 0);
                //  Console.Write("I AM A TANK  W-up  D-righ S-down A-left Q-exit Z-fire Shot== {0} Game Over!!!!",Gun.CountShot);
                
                
                //Console.Clear();
                //Console.SetCursorPosition(10, 5);

                if (Karta.KartaHaveWall())
                    Karta.DrawFirstEScreen("               ", "!!!! LOSER     !!!!", "Want restart? pres Y");
                else
                    Karta.DrawFirstEScreen("                ", "!!!! WINER     !!!!", "Want restart? pres Y");
                
                //Console.ReadLine();
                
                var key1 = Console.ReadKey();
                var x1 = key1.KeyChar;

                if (x1=='y')
                {
                    bodyTank = true;
                    Karta.XForWall = Karta.MaxTop + 3;
                }
                else
                    bodyTank = false;
                 

                FlagWeInProgram = true;
                Gun.CountShot = Gun.MaxShot;

            }
            Karta.DrawFirstEScreen("    Tank v0.1", "     goodbye    ", "here can be your advertising");

            const int time = 2;
            for (int i = time; i > 0; i--)
            {
                Console.SetCursorPosition(2, 10);
                Console.Write("I Close this window over {0} second",i);
                Thread.Sleep(1000);
            }
            
            
            

        }
    }
}
