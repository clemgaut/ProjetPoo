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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        
        public Window1() {
            InitializeComponent();

        }

        public Window1(Player winner, int pt1, int pt2) {
            InitializeComponent();
            if (winner != null)
                lblWin.Content = "Le vainqueur est " + winner.getName() + " !";
            else
                lblWin.Content = "Match nul !";
            lblPt1.Content = pt1;
            lblPt2.Content = pt2;
        }
    }
}
