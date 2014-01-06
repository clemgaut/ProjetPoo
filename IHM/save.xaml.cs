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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IHM {

    /// <summary>
    /// Interaction logic for save.xaml
    /// </summary>
    public partial class save : Page {
        public save() {
            InitializeComponent();
            loadFilesList();
        }

        private void menu_Click(object sender, RoutedEventArgs e) {
            Window parent = (Window)this.Parent;
            parent.Content = new menu();

        }

        private void loadFilesList() {

            panel.Children.Clear();

            Button bSave = new Button();
            bSave.Content = "Nouvelle sauvegarde";
            bSave.Padding = new Thickness(5);
            bSave.Margin = new Thickness(5);
            bSave.Name = "newSave";
            bSave.Width = 150;
            bSave.Height = 30;
            bSave.Click += newSave_Click;

            panel.Children.Add(bSave);

            List<String> saves = new List<String>();
            saves = Files.getSaves();

            foreach(String file in saves) {
                bSave = new Button();
                bSave.Content = file;
                bSave.Padding = new Thickness(5);
                bSave.Margin = new Thickness(5);
                bSave.Width = 150;
                bSave.Height = 30;
                bSave.Name = "button" + file;

                bSave.Click += save_Click;

                panel.Children.Add(bSave);
            }
        }

        private void newSave_Click(object sender, RoutedEventArgs e) {

            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            string defName = user + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

            Files.saveHandle(defName, false);
            loadFilesList();

            saveFile(defName);
        }


        private void save_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            string name = (String)button.Content;

            string msg = "Remplacer la sauvegarde " + name + " ?";

            MessageBoxResult result2 = MessageBox.Show(msg, "Confirmer la sauvegarde", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(result2 == MessageBoxResult.OK)
                saveFile(name);
        }

        private void saveFile(String name) {
            Files.saveHandle(name, false);
            StartUpWindow parent = (StartUpWindow)this.Parent;
            parent.gameWindow.Show();
            parent.Hide();
        }

    }
}
