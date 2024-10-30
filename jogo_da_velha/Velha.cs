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
    /// <summary>
    /// Representa os diferentes tipos de jogadores no jogo.
    /// </summary>
    public enum PLAYER : sbyte
    {
        /// <summary>
        /// Representa a ausência de um jogador.
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Representa o jogador que utiliza o símbolo "X".
        /// </summary>
        MAN_X,

        /// <summary>
        /// Representa o jogador que utiliza o símbolo "O".
        /// </summary>
        BOX_O
    }

    public class Velha
    {
        public const int MAX_MOVE = 9;

        private int position = 0;
        private int moveCount = 0;

        private string playerTxt = string.Empty;
        private string nextPlayerTxt = string.Empty;

        private PLAYER player = PLAYER.MAN_X;
        private PLAYER backup_player = PLAYER.MAN_X;

        private PLAYER[] board =
        [
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE,
            PLAYER.NONE
        ];

        #region funções privada 
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
        #endregion

        /// <summary>
        /// Obtém o jogador que fez a última jogada.
        /// </summary>
        public string Player { get { return playerTxt; } }

        /// <summary>
        /// Obtém o próximo jogador que deve jogar.
        /// </summary>
        public string NextPlayer { get { return nextPlayerTxt; } }

        /// <summary>
        /// Grava o jogador no índice especificado do tabuleiro.
        /// </summary>
        /// <param name="index">O índice onde o jogador deve ser gravado no tabuleiro.</param>
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
            moveCount++;
        }

        /// <summary>
        /// Verifica se a partida terminou em empate (velha).
        /// </summary>
        /// <returns>
        /// Retorna <c>true</c> se a partida terminou em empate; caso contrário, retorna <c>false</c>.
        /// </returns>
        public bool OldWoman()
        {
            return moveCount == Velha.MAX_MOVE && !this.isVictory();
        }

        /// <summary>
        /// Verifica se o índice especificado do tabuleiro está vazio.
        /// </summary>
        /// <param name="index">O índice do tabuleiro a ser verificado.</param>
        /// <returns>
        /// Retorna <c>true</c> se o índice estiver vazio; caso contrário, retorna <c>false</c>.
        /// </returns>
        public bool isItemBoardEmpty(int index)
        {
            return (board[index] == PLAYER.NONE);
        }

        /// <summary>
        /// Verifica se houve um vencedor na partida.
        /// </summary>
        /// <returns>
        /// Retorna <c>true</c> se houver um vencedor; caso contrário, retorna <c>false</c>.
        /// </returns>
        public bool isVictory()
        {
            return CheckHorizontal() || CheckVertical() || CheckDiagonal() && moveCount < MAX_MOVE;
        }

    }


}
