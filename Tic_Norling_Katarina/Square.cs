using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Norling_Katarina
{
    class Square
    {
        public Player.Piece VärdeRuta { get; set; }

        public Square(Player.Piece ruta)
        {
            VärdeRuta = ruta;
        }
    }
}
