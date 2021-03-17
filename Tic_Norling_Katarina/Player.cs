using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Norling_Katarina
{
    class Player
    {
        public enum Piece { E, X, O };
        public Piece PlayerPiece { get; private set; }

        public Player(Player.Piece piece)
        {
            PlayerPiece = piece;
        }
    }
}
