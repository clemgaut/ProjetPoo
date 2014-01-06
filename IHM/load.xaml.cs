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
    /// Interaction logic for load.xaml
    /// </summary>
    public partial class load : Page {
       
        public load() {
            InitializeComponent();
            loadFilesList();
        }

        private void menu_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Content = new menu();
        }

        private void loadFilesList() {

            panel.Children.Clear();

            List<String> saves = new List<String>();
            saves = Files.getSaves();

            foreach(String file in saves) {
                Button bLoad = new Button();
                bLoad.Content = file;
                bLoad.Padding = new Thickness(5);
                bLoad.Margin = new Thickness(5);
                bLoad.Width = 150;
                bLoad.Height = 30;
                bLoad.Name = "button" + file;

                bLoad.Click += load_Click;

                panel.Children.Add(bLoad);
            }
        }

        private void load_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            string name = (String)button.Content;

            Files.saveHandle(name, true);
            StartUpWindow parent = (StartUpWindow)this.Parent;

            if(parent.inGame)
                parent.gameWindow.Close();
            
            parent.Hide();
            parent.gameWindow = new MainWindow(parent);
            parent.gameWindow.Show();
            parent.Hide();
        }

    }
}
