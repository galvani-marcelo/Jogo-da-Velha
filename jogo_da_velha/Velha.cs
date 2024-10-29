using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace jogo_da_velha
{
    public enum PLAYER : sbyte
    {
        NONE = 0,
        MAN_X,
        BOX_O
    };

    
    public class Velha
    {
        public const int MAX_MOVE = 9; 
        private PLAYER player = PLAYER.MAN_X;
        private PLAYER backup_player = PLAYER.NONE;
        private int moveCounter = 0;

        public PLAYER[] board = new PLAYER[MAX_MOVE]
        {
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE
        };



        public void SetPlayerBoard(string position)
        {
            int index = -1;
            if (int.TryParse(position, out index))
            {
                switch (player)
                {
                    case PLAYER.MAN_X:
                        board[index] = PLAYER.MAN_X;
                        player = PLAYER.BOX_O;
                        break;
                    case PLAYER.BOX_O:
                        board[index] = PLAYER.BOX_O;
                        player = PLAYER.MAN_X;
                        break;
                }
                backup_player = board[index];
            }
            moveCounter++;
        }

        public int GetMoveCounter()
        {
            return moveCounter;
        }
        public bool isPlayerOnBoard(string position)
        {
            int index = -1;
            if (int.TryParse(position, out index))
                return (board[index] == PLAYER.NONE);
            return false;
        }

        public string GetJogador(string position)
        {
            int index = -1;
            string result = string.Empty;
            if (int.TryParse(position, out index))
            {
                switch (this.board[index])
                {
                    case PLAYER.MAN_X:
                        result = "✖︎";
                        break;
                    case PLAYER.BOX_O:
                        result = "⚫";
                        break;
                }
            }
            return result;
        }

        public string GetJogador()
        {
            string result = string.Empty;

            switch (player)
            {
                case PLAYER.MAN_X:
                    result = "✖︎";
                    break;
                case PLAYER.BOX_O:
                    result = "⚫";
                    break;
            }

            return result;
        }

        private bool CheckHorizontal()
        {
            return (board[0] == backup_player && board[1] == backup_player && board[2] == backup_player ||
                    board[3] == backup_player && board[4] == backup_player && board[5] == backup_player ||
                    board[6] == backup_player && board[7] == backup_player && board[8] == backup_player);
        }

        private bool CheckVertical()
        {
            return (board[0] == backup_player && board[3] == backup_player && board[6] == backup_player ||
                    board[1] == backup_player && board[4] == backup_player && board[7] == backup_player ||
                    board[2] == backup_player && board[5] == backup_player && board[8] == backup_player);
        }

        private bool CheckDiagonal()
        {
            return (board[2] == backup_player && board[4] == backup_player && board[6] == backup_player ||
                    board[0] == backup_player && board[4] == backup_player && board[8] == backup_player);
        }


        public bool CheckWin()
        {
            return CheckHorizontal() || CheckVertical() || CheckDiagonal();
        }
    }


}
