﻿using System;
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
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window {
        
        public EndWindow() {
            InitializeComponent();

        }

        public EndWindow(Player winner, int pt1, int pt2) {
            InitializeComponent();
            lblWin.Content = (winner != null) ? "Le vainqueur est " + winner.getName() + " !" : "Match nul !";
  
            lblPt1.Content = pt1;
            lblPt2.Content = pt2;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
