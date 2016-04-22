
namespace TankSpace
{
    class Wall
    {
        public int CoorditaneLeft1, CoorditaneTop1;
        public int CoorditaneLeft2, CoorditaneTop2;
            public Wall(int x1, int y1, int x2, int y2)
        {
                // тут поставити обмеження щоб не можна було малювати нижче 16лінії
          CoorditaneLeft1 = x1;
          CoorditaneTop1 = y1;
          CoorditaneLeft2 = x2;
          CoorditaneTop2 = y2;
         ArrayBla();
        }

        
        
        public void ArrayBla() //чому я не можу це зробити в класі????
        {
           
            for (int i = CoorditaneTop1; i <= CoorditaneTop2; i++)
                for (int j = CoorditaneLeft1; j <= CoorditaneLeft2; j++)
                {
                    Karta.GlobalCoordinate[j, i] = Karta.WallView;
                  
                }
            Karta.DrawWall();

        }
    
       

    }

}

