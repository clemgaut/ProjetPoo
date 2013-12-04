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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SourceProject;

namespace IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Map map;
        Game game;
        Rectangle selectedVisual;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            map = game.getMap();

            for (int c = 0; c < map.Width; c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel) });
            }

            for (int l = 0; l < map.Height; l++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });
                for (int c = 0; c < map.Width; c++)
                {
                    var tile = map.getBox(c, l);
                    var rect = createRectangle(c, l, tile);
                    mapGrid.Children.Add(rect);
                }
            }
            //updateUnitUI();
        }

        private Rectangle createRectangle(int c, int l, Box tile)
        {
            var rectangle = new Rectangle();
            if (tile is ForestBox) rectangle.Fill = Brushes.Brown;
            if (tile is SeaBox) rectangle.Fill = Brushes.Blue;
            if (tile is MountainBox) rectangle.Fill = Brushes.Gray;
            if (tile is LowlandBox) rectangle.Fill = Brushes.Green;
            if (tile is DesertBox) rectangle.Fill = Brushes.Gold;

            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile;
            rectangle.Stroke = Brushes.Red;
            rectangle.StrokeThickness = 1;

            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        private void updateUnitUI()
        {
            var unit = game.getActivePlayer().getSelectableUnits();
        }

        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            var tile = rectangle.Tag as Box;
            int row = Grid.GetRow(rectangle);
            int column = Grid.GetColumn(rectangle);

            if (selectedVisual != null) selectedVisual.StrokeThickness = 1;
            selectedVisual = rectangle;
            selectedVisual.Tag = tile;
            rectangle.StrokeThickness = 3;
            InfoLabel.Content = String.Format("[{0:00} - {1:00}] {2}", column, row, tile);

            e.Handled = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InfoLabel.Content = "Pas d'info";
            if (selectedVisual != null) selectedVisual.StrokeThickness = 0;
            selectedVisual = null;
        }
    }
}