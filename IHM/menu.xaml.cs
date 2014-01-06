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
        public menu() {
            InitializeComponent();
        }

        private void newGame_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Content = new newGame();
        }

        private void load_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Content = new save();
        }
        private void close_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Close();
        }

    }
}
