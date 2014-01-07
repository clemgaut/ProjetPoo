using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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
                bLoad.Margin = new Thickness(5);
                bLoad.Width = 150;
                bLoad.Height = 30;
               
                bLoad.Name = "button" +  file.Replace(" ", "_");
                bLoad.BorderBrush = Brushes.SlateGray;
                bLoad.Background = Brushes.SlateGray;
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
