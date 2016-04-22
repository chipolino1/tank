using System.Threading;

using _111;

namespace TankSpace

{
    internal class Tank
    {
    
        private readonly int[] _coordinateLeft = new int[10];
        private readonly int[] _coordinateTop = new int[10];
        
        private readonly int[] _beforeCoordinateLeft = new int[10];
        private readonly int[] _beforeСoordinateTop = new int[10];

        public readonly int[] CoordinateLeft = {0, 6, 7, 8, 6, 7, 8, 6, 7, 8};
        public readonly int[] CoordinateTop =  {0,10,10,10,11,11,11,12,12,12};
       
        private DirectionEnum _direction = DirectionEnum.Up;
        private DirectionEnum  _beforeDirection = DirectionEnum.Up;

        private const int TimeTurn = 0;
        private const int TimeSleep = 50;

        public Tank()
        {
            
        }

   

        public void AutoPilot()
        {
            for (int i = 0; i < Karta.MaxLeft ; i++)
            {
                if (i==0 & _direction!=DirectionEnum.Up)
                    UpDate(DirectionEnum.Up);

           
            Fire();
                if (!TankMainClass.FlagWeInProgram)
                break;
                     
            Thread.Sleep(TimeSleep);
            UpDate(DirectionEnum.Down);
            Fire();
            if (!TankMainClass.FlagWeInProgram)
                break;
                
            Thread.Sleep(TimeSleep);
            UpDate(DirectionEnum.Right);
            Thread.Sleep(TimeSleep);
            UpDate(DirectionEnum.Right);

            UpDate(DirectionEnum.Up);
           
            }


        }


        public void Fire()
        {
       
            Gun g = new Gun(_direction, CoordinateLeft[2], CoordinateTop[2]);
            //G.MoveGun();
        }

        //function turn 1 
        private void Turn(int x)  // turn
        {
            for (var j = 0; j < x; j++)
            {
                for (var i = 1; i < 10; i++) // copy in rezerf Array
                {
                    _coordinateLeft[i] = CoordinateLeft[i];
                    _coordinateTop[i] = CoordinateTop[i];
                }
             //   CoordinateLeft[0] = _coordinateLeft[3];
              //  СoordinateTop[0] = _coordinateTop[3];

                CoordinateLeft[1] = _coordinateLeft[3];
                CoordinateTop[1] = _coordinateTop[3];

                CoordinateLeft[2] = _coordinateLeft[6];
                CoordinateTop[2] = _coordinateTop[6];

                CoordinateLeft[3] = _coordinateLeft[9];
                CoordinateTop[3] = _coordinateTop[9];

                CoordinateLeft[4] = _coordinateLeft[2];
                CoordinateTop[4] = _coordinateTop[2];

                CoordinateLeft[5] = _coordinateLeft[5];
                CoordinateTop[5] = _coordinateTop[5];

                CoordinateLeft[6] = _coordinateLeft[8];
                CoordinateTop[6] = _coordinateTop[8];

                CoordinateLeft[7] = _coordinateLeft[1];
                CoordinateTop[7] = _coordinateTop[1];

                CoordinateLeft[8] = _coordinateLeft[4];
                CoordinateTop[8] = _coordinateTop[4];

                CoordinateLeft[9] = _coordinateLeft[7];
                CoordinateTop[9] = _coordinateTop[7];
            }
        }

        public void UpDate(DirectionEnum x)
        {
            for (int i = 1; i < 10; i++)  //make copy Array in  BeforeCoordinateLeft
            {
                _beforeCoordinateLeft[i] = CoordinateLeft[i];
                _beforeСoordinateTop[i] = CoordinateTop[i];

                _beforeDirection = _direction;
            }
            
            if (x == _direction) //move forward
            {
                
                switch (x)
                {
  
                    case DirectionEnum.Up:
                        for (var i = 1; i < 10; i++)
                        {
                            if (CoordinateTop[i] == Karta.MinTop)
                                CoordinateTop[i] = Karta.MaxTop-1 ;
                            else CoordinateTop[i]--;
                        }
                        break;

                    case DirectionEnum.Right:
                        for (var i = 1; i < 10; i++)
                        {
                            if (CoordinateLeft[i] == Karta.MaxLeft-1)
                                CoordinateLeft[i] = Karta.MinLeft ;

                            else CoordinateLeft[i]++;
                        }

                        break;


                    case DirectionEnum.Down:
                        for (var i = 1; i < 10; i++)
                        {
                            if (CoordinateTop[i] == Karta.MaxTop-1)
                                CoordinateTop[i] = Karta.MinTop ;

                            else CoordinateTop[i]++;
                        }

                        break;


                    case DirectionEnum.Left:

                        for (var i = 1; i < 10; i++)
                        {
                            if (CoordinateLeft[i] == Karta.MinLeft )
                                CoordinateLeft[i] = Karta.MaxLeft-1;

                            else CoordinateLeft[i]--;
                        }
                        break;
                }
            }
            else // turn
            {
                if ((int) x > (int) (_direction))
                {
                    var k = (int) x - (int) (_direction);
                    Turn(k);
                }
                //переписати це убожество
                if ((int) x == 1 && (int) (_direction) == 4) Turn(1);
                if ((int) x == 2 && (int) (_direction) == 4) Turn(2);
                if ((int) x == 3 && (int) (_direction) == 4) Turn(3);
                if ((int) x == 1 && (int) (_direction) == 3) Turn(2);
                if ((int) x == 2 && (int) (_direction) == 3) Turn(3);
                if ((int) x == 1 && (int) (_direction) == 2) Turn(3);


                _direction = x;
            }
            Draw();
         
        }

        public void Draw()
        {
            Karta.ClearKartaFromTank();
            
            int k = 0;
         //   Karta.ClearKarta();

            for (var i = 1; i < 10; i++)
                if (Karta.GlobalCoordinate[CoordinateLeft[i], CoordinateTop[i]] == Karta.WallView)
                    k++;

            if (k == 0)
            {
                Karta.GlobalCoordinate[CoordinateLeft[1], CoordinateTop[1]] = '-';
                Karta.GlobalCoordinate[CoordinateLeft[2], CoordinateTop[2]] = '*';
                Karta.GlobalCoordinate[CoordinateLeft[3], CoordinateTop[3]] = '-';
                Karta.GlobalCoordinate[CoordinateLeft[4], CoordinateTop[4]] = '0';
                Karta.GlobalCoordinate[CoordinateLeft[5], CoordinateTop[5]] = '*';
                Karta.GlobalCoordinate[CoordinateLeft[6], CoordinateTop[6]] = '0';
                Karta.GlobalCoordinate[CoordinateLeft[7], CoordinateTop[7]] = '#';
                Karta.GlobalCoordinate[CoordinateLeft[8], CoordinateTop[8]] = '#';
                Karta.GlobalCoordinate[CoordinateLeft[9], CoordinateTop[9]] = '#';
            }
            else
            {
                for (int i = 1; i < 10; i++)  //retyrn Array 
                {
                        CoordinateLeft[i]= _beforeCoordinateLeft[i];
                        CoordinateTop[i] = _beforeСoordinateTop[i];
                    _direction = _beforeDirection;

                }

                Karta.GlobalCoordinate[CoordinateLeft[1], CoordinateTop[1]] = '-';
                Karta.GlobalCoordinate[CoordinateLeft[2], CoordinateTop[2]] = '*';
                Karta.GlobalCoordinate[CoordinateLeft[3], CoordinateTop[3]] = '-';
                Karta.GlobalCoordinate[CoordinateLeft[4], CoordinateTop[4]] = '0';
                Karta.GlobalCoordinate[CoordinateLeft[5], CoordinateTop[5]] = '*';
                Karta.GlobalCoordinate[CoordinateLeft[6], CoordinateTop[6]] = '0';
                Karta.GlobalCoordinate[CoordinateLeft[7], CoordinateTop[7]] = '#';
                Karta.GlobalCoordinate[CoordinateLeft[8], CoordinateTop[8]] = '#';
                Karta.GlobalCoordinate[CoordinateLeft[9], CoordinateTop[9]] = '#';

            
            } 
                Karta.DrawTank();
        } 

       
    }
}
