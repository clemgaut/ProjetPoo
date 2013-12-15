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
        GameBuilder builder;
        Rectangle selectedVisual;
        ImageBrushFactory imageBrushFactory = new ImageBrushFactory();

        public MainWindow(EGameType mapType, ENation nation1, ENation nation2)
        {
            InitializeComponent();

            switch(mapType)
            {
                case EGameType.DEMO:
                    builder = new DemoGameBuilder(nation1, nation2);
                    break;

                case EGameType.SMALL:
                    builder = new SmallGameBuilder(nation1, nation2);
                    break;

                case EGameType.NORMAL:
                    builder = new NormalGameBuilder(nation1, nation2);
                    break;

                default:
                    MessageBox.Show(this, "Type de jeu non reconnu", "Erreur du jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    break;
            }
            MapLabel.Content = "Type de carte : " + mapType.ToString().ToLower();

            labelNation1.Content = nation1.ToString();
            labelNation2.Content = nation2.ToString();

            game = builder.getGame();

            game.start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            map = game.getMap();

            for (int c = 0; c < map.Width; c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }

            for (int l = 0; l < map.Height; l++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                for (int c = 0; c < map.Width; c++)
                {
                    var tile = map.getBox(l, c);
                    var rect = createRectangle(l, c, tile);
                    mapGrid.Children.Add(rect);
                }
            }
            updateUnitUI();
        }

        private Rectangle createRectangle(int c, int l, Box tile)
        {
            var rectangle = new Rectangle();
            if (tile is ForestBox) rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.FOREST);
            if (tile is SeaBox) rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.SEA);
            if (tile is MountainBox) rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.MOUTAIN);
            if (tile is LowlandBox) rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.LOWLAND);
            if (tile is DesertBox) rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.DESERT);

            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile;
            rectangle.Stroke = Brushes.Gray;
            rectangle.StrokeThickness = 1;

            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        /*
         * Change the color of rectangle where active player units are
         */
        private void updateUnitUI()
        {
            List<Unit> selectableUnits = game.getActivePlayer().getSelectableUnits();

            foreach(Unit u in selectableUnits)
            {
                Rectangle r = getRectangle(u.getLine(), u.getColumn());
                r.Stroke = Brushes.GreenYellow;
                r.StrokeThickness = 2;
            }
        }

        private Rectangle getRectangle(int line, int column)
        {
            return mapGrid.Children.OfType<Rectangle>().FirstOrDefault(child => Grid.GetRow(child) == line && Grid.GetColumn(child) == column);
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

            updateUnitUI();

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
