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

namespace IHM {
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class newGame : Page {
        public newGame() {
            InitializeComponent();

            initializeMapTags();

            initializeNationTags();
        }

        private void initializeMapTags() {
            this.DemoItem.Tag = EGameType.DEMO;
            this.SmallItem.Tag = EGameType.SMALL;
            this.NormalItem.Tag = EGameType.NORMAL;
        }

        private void initializeNationTags() {
            this.Nain1.Tag = ENation.NAIN;
            this.Nain2.Tag = ENation.NAIN;

            this.Gaul1.Tag = ENation.GAUL;
            this.Gaul2.Tag = ENation.GAUL;

            this.Viking1.Tag = ENation.VIKING;
            this.Viking2.Tag = ENation.VIKING;
        }

        private void StartUpButton_Click(object sender, RoutedEventArgs e) {
            //We start the game only if both nations are selected.
            if(ComboBoxNationPlayer1.SelectedIndex > -1 && ComboBoxNationPlayer2.SelectedIndex > -1) {
                // We retrieve game type with the tag
                ComboBoxItem itemGame = (ComboBoxItem)GameTypeComboBox.SelectedItem;
                ComboBoxItem itemNation1 = (ComboBoxItem)ComboBoxNationPlayer1.SelectedItem;
                ComboBoxItem itemNation2 = (ComboBoxItem)ComboBoxNationPlayer2.SelectedItem;

                MainWindow win = new MainWindow((EGameType)itemGame.Tag, (ENation)itemNation1.Tag, (ENation)itemNation2.Tag, labelPlayer1.Text, labelPlayer2.Text);
                win.Show();

                Window parent = (Window)this.Parent;
                parent.Close();
            }
        }

        private void ComboBoxNation_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            StartUpButton.IsEnabled = (ComboBoxNationPlayer1.SelectedIndex > -1 && ComboBoxNationPlayer2.SelectedIndex > -1);
        }

        private void labelPlayer2_Focus(object sender, RoutedEventArgs e) {
            if(labelPlayer2.IsFocused && labelPlayer2.Text == "Joueur 2")
                labelPlayer2.Text = "";

            if(!labelPlayer2.IsFocused && labelPlayer2.Text == "")
                labelPlayer2.Text = "Joueur 2";
        }

        private void labelPlayer1_Focus(object sender, RoutedEventArgs e) {
            if(labelPlayer1.IsFocused && labelPlayer1.Text == "Joueur 1")
                labelPlayer1.Text = "";

            if(!labelPlayer1.IsFocused && labelPlayer1.Text == "")
                labelPlayer1.Text = "Joueur 1";
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Content = new menu();
        }
    }
}
