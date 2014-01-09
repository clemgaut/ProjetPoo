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
using System.Windows.Shapes;
using SourceProject;

namespace IHM {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        
        public Window1() {
            InitializeComponent();

        }

        public Window1(Player winner, int pt1, int pt2) {
            InitializeComponent();
            lblWin.Content = "Le vainqueur est " + winner.getName() + " !";
            lblPt1.Content = pt1;
            lblPt2.Content = pt2;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
