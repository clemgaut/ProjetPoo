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
using System.Windows.Media.Effects;
using SourceProject;

namespace IHM {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Map _map;
        Game _game;
        GameBuilder _builder;
        Rectangle _selectedVisual;
        ImageBrushFactory _imageBrushFactory = new ImageBrushFactory();
        StackPanel _selectedUnit;
        Wrapper.WrapperAlgo _wrap = new Wrapper.WrapperAlgo();

        StartUpWindow start;

        public MainWindow(StartUpWindow win, EGameType mapType, ENation nation1, ENation nation2, string nameP1, string nameP2) {
            InitializeComponent();

            start = win;
            start.inGame = true;

            switch(mapType) {
                case EGameType.DEMO:
                    _builder = new DemoGameBuilder(nation1, nation2);
                    break;

                case EGameType.SMALL:
                    _builder = new SmallGameBuilder(nation1, nation2);
                    break;

                case EGameType.NORMAL:
                    _builder = new NormalGameBuilder(nation1, nation2);
                    break;

                default:
                    MessageBox.Show(this, "Type de jeu non reconnu", "Erreur du jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    break;
            }
            MapLabel.Content = "Type de carte : " + mapType.ToString().ToLower();

            _game = _builder.getGame();

            _game.getPlayer1().setName(nameP1);
            _game.getPlayer2().setName(nameP2);

            Nation1Label.Content = nameP1 + " [" + nation1.ToString() + "]";
            Nation2Label.Content = nameP2 + " [" + nation2.ToString() + "]";

            _selectedUnit = null;

            _game.start();
        }

        public MainWindow(StartUpWindow win) {
            InitializeComponent();

            blurEffect(false);

            start = win;
            start.inGame = true;

            _game = Game.instance;

            MapLabel.Content = "Type de carte : " + _game.getMap().GetType().ToString().ToLower();

            Nation1Label.Content = _game.getPlayer1().getName() + " [" + _game.getPlayer1().getNation().nationType + "]";
            Nation2Label.Content = _game.getPlayer2().getName() + " [" + _game.getPlayer2().getNation().nationType + "]";

            _selectedUnit = null;

            _game.start();
        }

        /*
         * Click on end of turn button
         */
        private void EndOfTurnButton_Click(object sender, RoutedEventArgs e) {
            
            _selectedUnit = null;

            setDefaultOpacity();

            _game.nextStep();
            updateForStep();
            if (_game.checkEndfOfGame()) {
                
                EndWindow victoryWin = new EndWindow(_game.getWinner(), _game.getPlayer1().getPoints(), _game.getPlayer2().getPoints());

                victoryWin.ShowDialog();

                StartUpWindow startUpWindow = new StartUpWindow();
                startUpWindow.Show();
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            _map = _game.getMap();

            for(int i = 0; i < _map.Width; i++) {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
            }

            for(int l = 0; l < _map.Height; l++) {
                for(int c = 0; c < _map.Width; c++) {
                    var tile = _map.getBox(l, c);
                    var rect = createTile(l, c, tile);
                    mapGrid.Children.Add(rect);
                }
            }

            updateForStep();
        }

        /*
         * Create a tile
         */
        private Grid createTile(int l, int c, Box tile) {
            var rectangle = new Rectangle();
            if(tile is ForestBox)
                rectangle.Fill = _imageBrushFactory.getImageBrush(EBoxType.FOREST);
            if(tile is SeaBox)
                rectangle.Fill = _imageBrushFactory.getImageBrush(EBoxType.SEA);
            if(tile is MountainBox)
                rectangle.Fill = _imageBrushFactory.getImageBrush(EBoxType.MOUNTAIN);
            if(tile is LowlandBox)
                rectangle.Fill = _imageBrushFactory.getImageBrush(EBoxType.LOWLAND);
            if(tile is DesertBox)
                rectangle.Fill = _imageBrushFactory.getImageBrush(EBoxType.DESERT);

            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile;
            VisualBrush vb = new VisualBrush();
            vb.Opacity = 0;
            rectangle.Stroke = vb;
            rectangle.StrokeThickness = 1;
          
            Ellipse ell = new Ellipse();
            ell.Width = 25;
            ell.Height = 25;
            ell.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            ell.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            ell.Visibility = System.Windows.Visibility.Hidden;

            TextBlock text = new TextBlock();
            text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            text.TextAlignment = TextAlignment.Center;
            text.Visibility = System.Windows.Visibility.Hidden;

            Grid grid = new Grid();

            grid.Children.Add(rectangle);
            grid.Children.Add(ell);
            grid.Children.Add(text);

            Grid.SetColumn(grid, c);
            Grid.SetRow(grid, l);

            grid.MouseLeftButtonDown += new MouseButtonEventHandler(grid_MouseLeftButtonDown);

            return grid;
        }

        /*
         * Does every UI update needed when we finish a game step
         */
        private void updateForStep() {
            updateUnitUI();
            updateInfoPanel();
        }

        /*
         * Update informations about the general info panel( players and game info)
         */
        private void updateInfoPanel() {
            StepLabel.Content = "Tours restants : " + _game.getSteps();
            Units1Label.Content = "Unitées restantes : " + _game.getPlayer1().getNation().getUnitsNumber();
            Units2Label.Content = "Unitées restantes : " + _game.getPlayer2().getNation().getUnitsNumber();
            Points1Label.Content = "Points : " + _game.getPlayer1().getPoints();
            Points2Label.Content = "Points : " + _game.getPlayer2().getPoints();

            var activeLabel = (_game.isPlayer1Active()) ? Nation1Label : Nation2Label;
            var unactiveLabel = (_game.isPlayer1Active()) ? Nation2Label : Nation1Label;

            activeLabel.Foreground = Brushes.GreenYellow;
            activeLabel.FontWeight = FontWeights.Bold;
            unactiveLabel.Foreground = Brushes.Red;
            unactiveLabel.FontWeight = FontWeights.Normal;
        }

        /*
         * Change the color of rectangle where player units are and update the number of units
         */
        private void updateUnitUI() {
            if (_game.getActivePlayer().getNation().getUnits() != null) {
                List<Unit> selectableUnits1 = _game.getActivePlayer().getNation().getUnits().ToList();

                foreach (Unit u in selectableUnits1) {
                    Rectangle r = getRectangle(u.getLine(), u.getColumn());
                    r.Stroke = Brushes.GreenYellow;
                    if (r != _selectedVisual)
                        r.StrokeThickness = 2;

                    Ellipse ell = getEllipse(u.getLine(), u.getColumn());
                    ell.Fill = Brushes.GreenYellow;

                    TextBlock text = getText(u.getLine(), u.getColumn());
                    text.Text = "" + _game.getActivePlayer().getNation().getUnits(u.getLine(), u.getColumn()).Count;

                    ell.Visibility = System.Windows.Visibility.Visible;
                    text.Visibility = System.Windows.Visibility.Visible;
                }
            }

            if (_game.getUnactivePlayer().getNation().getUnits() != null) {
                List<Unit> selectableUnits2 = _game.getUnactivePlayer().getNation().getUnits().ToList();

                foreach (Unit u in selectableUnits2) {
                    Rectangle r = getRectangle(u.getLine(), u.getColumn());
                    r.Stroke = Brushes.Red;
                    if (r != _selectedVisual)
                        r.StrokeThickness = 2;

                    Ellipse ell = getEllipse(u.getLine(), u.getColumn());
                    ell.Fill = Brushes.Red;

                    TextBlock text = getText(u.getLine(), u.getColumn());
                    text.Text = "" + _game.getUnactivePlayer().getNation().getUnits(u.getLine(), u.getColumn()).Count;

                    ell.Visibility = System.Windows.Visibility.Visible;
                    text.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        /*
         * Return the rectangle on line,column
         */
        private Rectangle getRectangle(int line, int column) {
            return mapGrid.Children.OfType<Grid>().FirstOrDefault(child => Grid.GetRow(child) == line && Grid.GetColumn(child) == column).Children.OfType<Rectangle>().FirstOrDefault();
        }

        /*
         * Return the textblock on line,column
         */
        private TextBlock getText(int line, int column) {
            return mapGrid.Children.OfType<Grid>().FirstOrDefault(child => Grid.GetRow(child) == line && Grid.GetColumn(child) == column).Children.OfType<TextBlock>().FirstOrDefault();
        }

        /*
         * Return the ellipse on line,column
         */
        private Ellipse getEllipse(int line, int column) {
            return mapGrid.Children.OfType<Grid>().FirstOrDefault(child => Grid.GetRow(child) == line && Grid.GetColumn(child) == column).Children.OfType<Ellipse>().FirstOrDefault();
        }

        /*
         * Called whenever someone click on a map rectangle
         */
        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var grid = sender as Grid;
            Rectangle rectangle = grid.Children.OfType<Rectangle>().FirstOrDefault();
            var tile = rectangle.Tag as Box;
            int row = Grid.GetRow(rectangle);
            int column = Grid.GetColumn(rectangle);

            if(_selectedVisual != null) {
                if(hasUnits(Grid.GetRow(_selectedVisual), Grid.GetColumn(_selectedVisual)))
                    _selectedVisual.StrokeThickness = 2;
                else
                    _selectedVisual.StrokeThickness = 1;
            }
            _selectedVisual = rectangle;
            _selectedVisual.Tag = tile;
            rectangle.StrokeThickness = 3;
            InfoLabel.Content = String.Format("[{0:00} - {1:00}] {2}", row, column, tile);

            if(_selectedUnit != null) {
                make_action(row, column);
            }
            updateForStep();
            updateUnitInfo(row, column);
            setDefaultOpacity();

            e.Handled = true;
        }

        /*
         * Is called to determine either to move a player or attack on other one
         */
        private void make_action(int row, int column) {
            var unit = _selectedUnit.Tag as Unit;
            int old_row = unit.getLine();
            int old_column = unit.getColumn();

            if (unit.canMove(row, column, _map) && (old_row!=row || old_column!=column)) {
                //If the opponent has no units, we move
                if (_game.getUnactivePlayer().getNation().getUnits(row, column).Count == 0)
                    unit.move(row, column, _map);
                else {
                    Unit defUnit = null;
                    bool result = true;

                    // While there are defensive unit and we win battle we continue to fight
                    while (result && (defUnit = _game.getBestDefensiveUnit(row, column)) != null) {
                        result = unit.attack(defUnit);
                        _game.getUnactivePlayer().getNation().deleteDeadUnits();
                    }

                    // If we win battle
                    if (result)
                        unit.move(row, column, _map);
                    else
                        _game.getActivePlayer().getNation().deleteDeadUnits();

                }
            }

            if(!hasUnits(old_row, old_column)) {
                getRectangle(old_row, old_column).Stroke = Brushes.Gray;
                getRectangle(old_row, old_column).StrokeThickness = 1;

                getText(old_row, old_column).Visibility = System.Windows.Visibility.Hidden;
                getEllipse(old_row, old_column).Visibility = System.Windows.Visibility.Hidden;
            }

            _selectedUnit = null;
        }

        /*
         * Update information displayed about unit in the tile with line and column
         */
        private void updateUnitInfo(int line, int column) {
            List<Unit> unitsActivePlayer = _game.getActivePlayer().getNation().getUnits(line, column);
            List<Unit> unitsUnactivePlayer = _game.getUnactivePlayer().getNation().getUnits(line, column);
            List<Unit> nonEmptyList = new List<Unit>();
            StackPanel activePanel = new StackPanel();

            unitP1InfoPanel.Children.Clear();
            unitP2InfoPanel.Children.Clear();

            if(unitsActivePlayer.Count > 0) {
                if (_game.isPlayer1Active())
                    activePanel = unitP1InfoPanel;
                else
                    activePanel = unitP2InfoPanel;
                nonEmptyList = unitsActivePlayer;
            }

            if(unitsUnactivePlayer.Count > 0) {
                if (_game.isPlayer1Active())
                    activePanel = unitP2InfoPanel;
                else
                    activePanel = unitP1InfoPanel;
                nonEmptyList = unitsUnactivePlayer;
            }

            if(nonEmptyList.Count > 0) {

                foreach(Unit u in nonEmptyList) {
                    StackPanel stack = getUnitDescription(u);
                    Border border = new Border();
                    border.BorderThickness = new Thickness(2);
                    border.Child = stack;
                    border.Margin = new Thickness(5, 10, 5, 10);

                    activePanel.Children.Add(border);

                    //If it's an active player unit, we add events to select it
                    if(nonEmptyList == unitsActivePlayer && u.hasMoves())
                        stack.MouseDown += unitStackPanel_MouseDown;
                }
            } 
        }

        /**
         * Called when we click on one unit
         */
        private void unitStackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
            var stack = sender as StackPanel;

            selectUnit(stack);

            if (_selectedUnit != null) {
                ENation nation = _game.getActivePlayer().getNation().nationType;
                Unit u = (Unit) _selectedUnit.Tag;
                int pos = u.getLine() * _map.Width + u.getColumn();
                List<int> moves = _wrap.possibleMoves(_map.convertMapToIntList(), (int) nation, pos, _game.getOpponentUnitsPositions());

                for (int i = 0; i < moves.Count; ) {
                    int row = moves[i++];
                    int col = moves[i++];

                    Rectangle r = getRectangle(row, col);
                    //Peut mieux faire (param en plus à passer au cpp pour gérer le cas du 1/2 point de deplacement des gaulois)
                    if(u.canMove(row, col,_map))
                        r.Opacity = 1;
                }
            } else
                setDefaultOpacity();

            e.Handled = true;
        }

        /**
         * Select the unit according to the object selected
         */
        private void selectUnit(StackPanel selectedUnit) {
            if(_selectedUnit != null) {
                Border parent = (Border)_selectedUnit.Parent;
                parent.BorderThickness = new Thickness(2);
                foreach (Label lbl in _selectedUnit.Children.OfType<Label>())
                    lbl.FontWeight = FontWeights.Normal;
            }

            var unit = selectedUnit.Tag as Unit;

            /*
             * Evite la sélection d'une unité par le joueur adverse lors du changement de tour
             */
            if (_game.getActivePlayer().getNation().getUnits(unit.getLine(), unit.getColumn()).Count > 0) {
                if (selectedUnit != _selectedUnit) {
                    Border parent = (Border)selectedUnit.Parent;
                    parent.BorderThickness = new Thickness(3);
                    foreach(Label lbl in selectedUnit.Children.OfType<Label>())
                        lbl.FontWeight = FontWeights.Bold;
                   
                    _selectedUnit = selectedUnit;
                    setDefaultOpacity();
                } else
                    _selectedUnit = null;
            }
        }

        /*
         * Return a stack panel containing a graphical description of the unit
         */
        private StackPanel getUnitDescription(Unit u) {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            if(u.hasMoves())
                stack.Background = new SolidColorBrush(Colors.LightGray);
            else
                stack.Background = new SolidColorBrush(Colors.DarkGray);

            Label lbLife = new Label();
            lbLife.Content = "Vie : " + u.getLifePoints();
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            myVerticalGradient.StartPoint = new Point(0, 0.5);
            myVerticalGradient.EndPoint = new Point(1, 0.5);
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            if (u.getLifePoints() > 0)
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.2));
            else
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.White, 0.2));
            if (u.getLifePoints() > 1)
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.OrangeRed, 0.4));
            else
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.White, 0.4));
            if (u.getLifePoints() > 2)
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Orange, 0.6));
            else
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.White, 0.6));
            if (u.getLifePoints() > 3)
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.YellowGreen, 0.8));
            else
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.White, 0.8));
            if (u.getLifePoints() > 4)
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Green, 1.0));
            else
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.White, 1.0));
            
            Rectangle lifeBar = new Rectangle();
            lifeBar.Fill = myVerticalGradient;
            lifeBar.Width = 40;
            lifeBar.Height = 8;
            lifeBar.ToolTip = u.getLifePoints() + "/5";

            Rectangle iLife = new Rectangle();
            iLife.Width = iLife.Height = 24;
            iLife.Fill = _imageBrushFactory.getLifeImage();
            iLife.ToolTip = "Vie";

            Rectangle iPoint = new Rectangle();
            iPoint.Width = iPoint.Height = 24;
            iPoint.Fill = _imageBrushFactory.getPointImage();
            iPoint.ToolTip = "Point";

            Rectangle iSword = new Rectangle();
            iSword.Width = iSword.Height = 24;
            iSword.Fill = _imageBrushFactory.getSwordImage();
            iSword.ToolTip = "Attaque";

            Rectangle iHelmet = new Rectangle();
            iHelmet.Width = iHelmet.Height = 24;
            iHelmet.Fill = _imageBrushFactory.getHelmetImage();
            iHelmet.ToolTip = "Défense";

            Rectangle iBoots = new Rectangle();
            iBoots.Width = iBoots.Height = 24;
            iBoots.Fill = _imageBrushFactory.getBootsImage();
            iBoots.ToolTip = "Déplacement";

            Label lbPoint = new Label();
            lbPoint.Content = u.getPoint(_game.getMap());
            Label lbOff = new Label();
            lbOff.Content = u.getOffensive();
            Label lbDeff = new Label();
            lbDeff.Content = u.getDefensive();
            Label lbMoves = new Label();
            lbMoves.Content = u.getMoves();

            stack.Children.Add(iLife);
            stack.Children.Add(lifeBar);

            stack.Children.Add(iPoint);
            stack.Children.Add(lbPoint);

            stack.Children.Add(iSword);
            stack.Children.Add(lbOff);

            stack.Children.Add(iHelmet);
            stack.Children.Add(lbDeff);

            stack.Children.Add(iBoots);
            stack.Children.Add(lbMoves);
            //we add a reference to the unit in the stack
            stack.Tag = u;

            return stack;
        }

        /*
         * Check if there still is at least one unit in the game
         */
        private bool hasUnits(int line, int column) {
            return (_game.getActivePlayer().getNation().getUnits(line, column).Count > 0 ||
                _game.getUnactivePlayer().getNation().getUnits(line, column).Count > 0);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            InfoLabel.Content = "Pas d'info";
            if(_selectedVisual != null) {
                if(hasUnits(Grid.GetRow(_selectedVisual), Grid.GetColumn(_selectedVisual)))
                    _selectedVisual.StrokeThickness = 2;
                else
                    _selectedVisual.StrokeThickness = 1;
            }
            _selectedVisual = null;
            if (_selectedUnit != null) {
                foreach (Label lbl in _selectedUnit.Children.OfType<Label>())
                    lbl.FontWeight = FontWeights.Normal;
            }
            _selectedUnit = null;
            setDefaultOpacity();
            unitP1InfoPanel.Children.Clear();
            unitP2InfoPanel.Children.Clear();
        }

        private void setDefaultOpacity() {
            foreach (Grid g in mapGrid.Children) {
                if(_selectedUnit != null)
                    g.Children.OfType<Rectangle>().FirstOrDefault().Opacity = 0.6;
                else
                    g.Children.OfType<Rectangle>().FirstOrDefault().Opacity = 1;
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e) {
           
            if(!start.IsActive)
                start = new StartUpWindow();
            start.gameWindow = this;
            start.inGame = false;
            start.Show();
        }

        private void Menu_Click(object sender, RoutedEventArgs e) {
            if(!start.IsActive)
                start = new StartUpWindow();

            blurEffect(true);
            
            start.gameWindow = this;
            start.Content = new menu();
            start.inGame = true;
            start.Show();
        }

        public void blurEffect(bool on) {

            if(on) {
                this.IsEnabled = false;
                BlurEffect blur = new BlurEffect();
                blur.Radius = 5;
                Effect = blur;
                Opacity = 0.8;
            } else {
                this.IsEnabled = true;
                Effect = null;
                Opacity = 1;
            }
            
        }
    }
}
