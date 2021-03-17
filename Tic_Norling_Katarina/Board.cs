using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Norling_Katarina
{
    class Board
    {
        List<Square> square;
        public int _radLängd{ get; private set; }
            
        public Board(int radlängd)
        {
            square = new List<Square>();
            _radLängd=radlängd;
            for (int i = 0; i < (_radLängd*_radLängd); i++)
                square.Add(new Square(Player.Piece.E));
        }
        public List<Square> GetCurrentGameState()
        {
            return square;
        }
        public bool IsPosistionAvailable(int pos)
        {
            if (square[pos].VärdeRuta == Player.Piece.E)
            {
                return true;
            }
            else
            {
                return false;                
            }
        }
    }
}
