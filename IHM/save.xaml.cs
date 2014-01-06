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

            List<String> saves = new List<String>();
            saves = Files.getSaves();

            foreach(String file in saves) {
                Button bSave = new Button();
                bSave.Content = file;
                bSave.Height = 100;
                bSave.Name = "button" + file;

                // bSave.Click += fichierSauvegarde_Click;

                filesList.Items.Add(bSave);
            }
        }

        /*    private void newsave_Click(object sender, RoutedEventArgs e)
            {

                string nomSession = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                nomSession = nomSession.Split('\\')[1];
                string date = DateTime.Now.ToFileTime().ToString();

                string nom_defaut = nomSession + "_" + date;

                CustomInputBox dialog = new CustomInputBox("Entrez un nom pour la sauvegarde :", nom_defaut);
                dialog.ShowDialog();
                if (!dialog.Canceled)
                    doAction(dialog.InputText);


            }


            private void fichierSauvegarde_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                string nomSauvegarde = b.Content as String;

                string message;
                if (charger)
                {
                    message = "Charger la partie " + nomSauvegarde + " ?";
                }
                else
                {
                    message = "Remplacer la sauvegarde " + nomSauvegarde + " ?";
                }

                OKCancelDialog dialog = new OKCancelDialog(message);
                dialog.ShowDialog();
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    doAction(nomSauvegarde);


            }

            private void doAction(string n)
            {
                GestionFichiers.action(n, charger);

                if (charger)
                {
                    mainWindow.afficherJeu();
                }
                else
                {
                    mainWindow.afficherJeu();
                }
            }

            private void refreshListeFichiers()
            {
                listeFichiers.Items.Clear();
                loadFilesList();
            }
        }
        }*/
    }
}
