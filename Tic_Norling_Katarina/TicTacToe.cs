using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Norling_Katarina
{
    // Katarina Norling & Amanda Hagnell, (samarbetat).
    // 13/12/18
    class TicTacToe
    {
        Board board;
        Player player1;
        Player player2;
        Player currentPlayer;
        Player AI;
        
        public void StartGame()
        {
            board = new Board(3);
            player1 = new Player(Player.Piece.X);
            player2 = new Player(Player.Piece.O);
            currentPlayer = player1;
            AI = player2;

            do
            {
                Print();

                if (currentPlayer == player1)
                {
                    string str_input = Console.ReadLine();
                    bool succses = Int32.TryParse(str_input, out int input);
                    if (succses)
                    {
                        if (input<=board._radLängd*board._radLängd && 0<input && board.IsPosistionAvailable(input - 1))
                        {
                            ReplaceSquare(input - 1);
                            if (CheckIfWin()==true)
                            {
                                break;
                            }
                            Current();
                        }
                        else
                        {
                            Console.WriteLine("Tagen plats! Klicka på enter och välj en ny plats.");                           
                        }
                    }
                }
                else
                {
                    MakeRandomAIMove();
                    if (CheckIfWin() == true)
                    {
                        break;
                    }
                    Current();
                }

                Console.Clear();
            } while (CheckIfDraw() != true && CheckIfWin() != true);

            Console.Clear();
            Print();
            if (CheckIfWin() == true)
            {
                Console.WriteLine("Win "+currentPlayer.PlayerPiece);
                Console.ReadLine();
            }
            else if (CheckIfDraw() == true) 
            {
                Console.WriteLine("Oavgjort");
            }       
        }        
    public void MakeRandomAIMove()
        {            
            Random rnd = new Random();
            int choice = rnd.Next(1, board._radLängd*board._radLängd);
            
            if(board.IsPosistionAvailable(choice)==true)
            {
                board.GetCurrentGameState()[choice].VärdeRuta = currentPlayer.PlayerPiece;                
            }
            else
            {
                Current();
            }
        }
        public bool CheckIfWin()
        {
            if (Diagona() == true)
            {
                return true;
            }
            else if (AntiDiagonal())
            {
                return true;
            }
            else if (Horisontell())
            {
                return true;
            }
            else if (Vertikal())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfDraw()
        {
            List<Square> v = board.GetCurrentGameState();
            int check = 0;
            for (int i = 0; i < v.Count; i++)
            {
                if (v[i].VärdeRuta != Player.Piece.E)
                {
                    check++;
                    if (check == v.Count)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Current()
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
        }        
        public bool Diagona()
        {
            int match=0;
            List<Square> CurrentBoard = board.GetCurrentGameState();
            for (int i = 0; i < board._radLängd * board._radLängd; i += board._radLängd+1)
            {
                if (CurrentBoard[i].VärdeRuta == currentPlayer.PlayerPiece)
                {
                    match++;
                }
                if (match==board._radLängd)
                {
                    return true;
                }
            }
            return false;
        }
        public bool AntiDiagonal()
        {
            int match=0;
            List<Square> CurrentBoard = board.GetCurrentGameState();
            for (int i = board._radLängd -1; i < board._radLängd * board._radLängd-1; i += board._radLängd-1)
            {
                if (CurrentBoard[i].VärdeRuta == currentPlayer.PlayerPiece && i != board._radLängd * board._radLängd - 1)
                {
                    match++;
                }
                if (match == board._radLängd)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Vertikal()
        {
            int match=0;
            List<Square> CurrentBoard = board.GetCurrentGameState();
            for (int i = 0; i < board._radLängd; i++)
            {
                for (int j = i; j < board._radLängd * board._radLängd; j += board._radLängd)
                {
                    if (CurrentBoard[j].VärdeRuta == currentPlayer.PlayerPiece)
                    {
                        match++;
                    }
                }
                if (match == board._radLängd)
                {
                    return true;
                }
                match = 0;
            }
            return false;
        }
            
        public bool Horisontell()
        {
            int match = 0;            
            List<Square> CurrentBoard = board.GetCurrentGameState();
            for (int i = 0; i < CurrentBoard.Count; i += board._radLängd)
            {
                for (int j = i; j < i + board._radLängd; j++)
                {
                    if (CurrentBoard[j].VärdeRuta == currentPlayer.PlayerPiece)
                    {
                        match++;
                    }                 
                }
                if (match == board._radLängd)
                {
                    return true;
                }
                match = 0;
            }
            return false;
        }            
        public bool ReplaceSquare(int index)
        {           
            if (board.IsPosistionAvailable(index) == true)
            {
                board.GetCurrentGameState()[index].VärdeRuta = currentPlayer.PlayerPiece;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Print()
        {
            List<Square> v = board.GetCurrentGameState();

            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", v[0].VärdeRuta, v[1].VärdeRuta, v[2].VärdeRuta);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", v[3].VärdeRuta, v[4].VärdeRuta, v[5].VärdeRuta);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", v[6].VärdeRuta, v[7].VärdeRuta, v[8].VärdeRuta);
            Console.WriteLine("     |     |      ");
        }     
    }
}
