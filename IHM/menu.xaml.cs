using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM {
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Page {

        private StartUpWindow parent; 
        public menu() {
            InitializeComponent();
        }

        private void newGame_Click(object sender, RoutedEventArgs e) {
            parent.Content = new newGame();
        }

        private void load_Click(object sender, RoutedEventArgs e) {
            parent.Content = new load();
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            parent.Content = new save();
        }

        private void close_Click(object sender, RoutedEventArgs e) {
            if(parent.inGame)
                parent.gameWindow.Close();
            parent.Close();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            parent = (StartUpWindow)this.Parent;
            saveButton.IsEnabled = parent.inGame;
            gameButton.Visibility = (parent.inGame) ? Visibility.Visible : Visibility.Hidden;
        }

        private void gameButton_Click(object sender, RoutedEventArgs e) {
            parent.Hide();
            parent.gameWindow.blurEffect(false);
        }

    }
}
