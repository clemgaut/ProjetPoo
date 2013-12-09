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

namespace IHM
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        public StartUpWindow()
        {
            InitializeComponent();
            this.DemoItem.Tag = EGameType.DEMO;
            this.SmallItem.Tag = EGameType.SMALL;
            this.NormalItem.Tag = EGameType.NORMAL;
        }

        private void StartUpButton_Click(object sender, RoutedEventArgs e)
        {
            // We retrieve game type with the tag
            ComboBoxItem item = (ComboBoxItem)GameTypeComboBox.SelectedItem;
            MainWindow win = new MainWindow((EGameType)item.Tag);
            win.Show();
            this.Close();
        }
    }
}
