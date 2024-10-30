using System.Windows;
using System.Windows.Controls;


namespace jogo_da_velha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Velha velha { get; set; }
        public MainWindow()
        {
            velha = new Velha();
            InitializeComponent();
        }

        private void Item_Board_Click_Button(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? tag_index = button.Tag?.ToString(); 

            // Verifica se a tag está nula.
            if (tag_index is null)
                return;

            // Converte o tag_index para um tipo inteiro.
            int player_index = 0;
            int.TryParse(tag_index, out player_index);

            // Verifica se o índice do tabuleiro está vazio e se não houve vitória.
            bool isMoveValid = velha.isItemBoardEmpty(player_index) && !velha.isVictory();
            if (isMoveValid)
            {
                velha.SetPlayerBoard(player_index);
                button.Content = velha.Player;
                player_label.Content = velha.NextPlayer;

                // Verifica se há um vencedor na partida.
                bool isVictory = velha.isVictory();
                if (isVictory)
                {
                    player_border.Visibility = Visibility.Collapsed;
                    winner_border.Visibility = Visibility.Visible;
                    winner_label.Content = $"Player {velha.Player} won!";
                    return;
                }

                // Verifica se a partida terminou em velha.
                bool oldWoman = velha.OldWoman();
                if (oldWoman)
                {
                    player_border.Visibility = Visibility.Collapsed;
                    winner_border.Visibility = Visibility.Visible;
                    winner_label.Content = "It's a draw!";
                    return;
                }
            }
        }

        private void New_Game_Button(object sender, RoutedEventArgs e)
        {
            velha = new Velha();
            player_label.Content = "✖︎";
            winner_border.Visibility= Visibility.Collapsed;
            winner_label.Content = "";
            player_border.Visibility = Visibility.Visible;
            foreach (var item in board.Children.OfType<Button>())
            {
                item.Content = "🤖"; // Reinicia o conteúdo dos botões
            }
        }
    }
}
