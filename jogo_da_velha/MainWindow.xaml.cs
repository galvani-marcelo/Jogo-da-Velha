using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using jogo_da_velha;

namespace jogo_da_velha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Velha? velha { get; set; }
        public MainWindow()
        {
            velha = new Velha();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (velha is null)
                return;

            string? player_index = button.Tag.ToString();

            if (player_index is null)
                return ;

            if (velha.isPlayerOnBoard(player_index))
            {
                velha.SetPlayerBoard(player_index);
                string player = velha.GetJogador(player_index);
                button.Content = player;
                winner_label.Content = velha.GetJogador();
                if (velha.CheckWin() && velha.GetMoveCounter() < Velha.MAX_MOVE)
                    winner_label.Content = $"Jogador {player} venceu!";
                else if (velha.GetMoveCounter() == Velha.MAX_MOVE)
                    winner_label.Content = $"Deu Velha 👩🏽‍🦳";

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            velha = new Velha();
            winner_label.Content = "✖︎";
            foreach (var item in board.Children.OfType<Button>())
            {
                item.Content = "🤖";
            }
        }
    }
}