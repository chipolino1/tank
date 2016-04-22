using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankSpace;
using _111;

namespace TankSpace

{
    class Gun
    {
    
        
        public static int MaxShot = 100;
        
        public static int CountShot = MaxShot;
        

        private readonly DirectionEnum _directionGun;
        private readonly int [] _arrayGan = new int[2];
       
        public Gun(DirectionEnum directionGun, int left, int top)
        {
            
                this._directionGun = directionGun;
                _arrayGan[0] = left;
                _arrayGan[1] = top;
                CountShot--;
                
            MoveGun();///////////////////// in Move

            if (CountShot==0 | !Karta.KartaHaveWall())
            {
                TankMainClass.FlagWeInProgram = false;
            }
                
     
        }

        
        public void MoveGun()   //Move
        {
            switch (_directionGun)
            {
                case DirectionEnum.Up:
                    {
                        for (int i = _arrayGan[1]; i > Karta.MinTop; i--)
                        {
                            _arrayGan[1] -= 1;
                            Karta.ClearKartaFromGun();
                            Karta.GlobalCoordinate[_arrayGan[0], _arrayGan[1]] = Karta.GunView ;
                            Karta.DrawGun();
                        }
                        break;
                    }
                case DirectionEnum.Right:
                    {
                        for (int i = _arrayGan[0]; i < Karta.MaxLeft-1  ; i++)
                        {
                            _arrayGan[0] += 1;
                            Karta.ClearKartaFromGun();
                            Karta.GlobalCoordinate[_arrayGan[0], _arrayGan[1]] = Karta.GunView;
                            Karta.DrawGun();
                        }

                        break;
                    }
                case DirectionEnum.Down:
                    {
                        for (int i = _arrayGan[1]; i < Karta.MaxTop-1 ; i++)
                        {
                            _arrayGan[1] += 1;
                            Karta.ClearKartaFromGun();
                            Karta.GlobalCoordinate[_arrayGan[0], _arrayGan[1]] = Karta.GunView;
                            Karta.DrawGun();
                        }
                        break;
                    }
                case DirectionEnum.Left:
                    {
                        for (int i = _arrayGan[0]; i >  Karta.MinLeft ; i--)
                        {
                            _arrayGan[0] -= 1;
                            Karta.ClearKartaFromGun();
                            Karta.GlobalCoordinate[_arrayGan[0], _arrayGan[1]] = Karta.GunView;
                            Karta.DrawGun();
                        }
                        
                        break;
                    }
            }

            Karta.ClearKartaFromGun();
            Karta.DrawGun();


        }

    }
}
