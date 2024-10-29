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

        private string playerTxt = string.Empty;
        private string nextPlayerTxt = string.Empty;
        private PLAYER backup_player = PLAYER.MAN_X;
        private PLAYER player = PLAYER.MAN_X;
        private int moveCounter = 0;
        private int position = 0;
   


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


        public string Player { get {  return playerTxt; } }

        public string NextPlayer { get { return nextPlayerTxt; } }

        public void SetPlayerBoard(int index)
        {
            position = index;
            switch (player)
            {
                case PLAYER.MAN_X:
                    board[position] = PLAYER.MAN_X;
                    player = PLAYER.BOX_O;
                    nextPlayerTxt = "⚫";
                    playerTxt = "✖︎";
                    break;
                case PLAYER.BOX_O:
                    board[position] = PLAYER.BOX_O;
                    player = PLAYER.MAN_X;
                    nextPlayerTxt = "✖︎";
                    playerTxt = "⚫";
                    break;
            }
            
            backup_player = board[position];
            moveCounter++;
        }


        public bool OldWoman()
        {
            return moveCounter == Velha.MAX_MOVE; ;
        }
        public bool isItemBoardEmpty(int position)
        {
            return (board[position] == PLAYER.NONE);
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

        
        public bool isVictory()
        {
            return CheckHorizontal() || CheckVertical() || CheckDiagonal() && moveCounter < MAX_MOVE;
        }
    }


}
