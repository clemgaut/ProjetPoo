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
using SourceProject;

namespace IHM {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Map map;
        Game game;
        GameBuilder builder;
        Rectangle selectedVisual;
        ImageBrushFactory imageBrushFactory = new ImageBrushFactory();
        StackPanel _selectedUnit;
        Wrapper.WrapperAlgo wrap = new Wrapper.WrapperAlgo();

        public void Load() {

        }

        public void Save() {

        }


        public MainWindow(EGameType mapType, ENation nation1, ENation nation2, string nameP1, string nameP2) {
            InitializeComponent();

            switch(mapType) {
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

            game = builder.getGame();

            game.getPlayer1().setName(nameP1);
            game.getPlayer2().setName(nameP2);

            Nation1Label.Content = nameP1 + " [" + nation1.ToString() + "]";
            Nation2Label.Content = nameP2 + " [" + nation2.ToString() + "]";

            _selectedUnit = null;

            game.start();
        }

        /*
         * Click on end of turn button
         */
        private void EndOfTurnButton_Click(object sender, RoutedEventArgs e) {
            Player winner = null;
            _selectedUnit = null;

            setDefaultOpacity();

            game.nextStep();
            updateForStep();
            if (game.checkEndfOfGame()) {
                winner = game.getWinner();

                if (winner == null)
                    MessageBox.Show(this, "Match nul !", "Fin du jeu", MessageBoxButton.OK, MessageBoxImage.None);
                else
                    MessageBox.Show(this, winner.getName() + " vainqueur !", "Fin du jeu", MessageBoxButton.OK, MessageBoxImage.None);

                StartUpWindow startUpWindow = new StartUpWindow();
                startUpWindow.Show();
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            map = game.getMap();

            for(int i = 0; i < map.Width; i++) {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
            }

            for(int l = 0; l < map.Height; l++) {
                for(int c = 0; c < map.Width; c++) {
                    var tile = map.getBox(l, c);
                    var rect = createRectangle(l, c, tile);
                    mapGrid.Children.Add(rect);
                }
            }

            updateForStep();
        }

        /*
         * Create a tile rectangle
         */
        private Rectangle createRectangle(int l, int c, Box tile) {
            var rectangle = new Rectangle();
            if(tile is ForestBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.FOREST);
            if(tile is SeaBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.SEA);
            if(tile is MountainBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.MOUNTAIN);
            if(tile is LowlandBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.LOWLAND);
            if(tile is DesertBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.DESERT);

            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile;
            rectangle.Stroke = Brushes.Gray;
            rectangle.StrokeThickness = 1;

            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
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
            StepLabel.Content = "Tours restants : " + game.getSteps();
            Units1Label.Content = "Unitées restantes : " + game.getPlayer1().getNation().getUnitsNumber();
            Units2Label.Content = "Unitées restantes : " + game.getPlayer2().getNation().getUnitsNumber();
            Points1Label.Content = "Points : " + game.getPlayer1().getPoints();
            Points2Label.Content = "Points : " + game.getPlayer2().getPoints();

            var activeLabel = (game.isPlayer1Active()) ? Nation1Label : Nation2Label;
            var unactiveLabel = (game.isPlayer1Active()) ? Nation2Label : Nation1Label;

            activeLabel.Foreground = Brushes.GreenYellow;
            activeLabel.FontWeight = FontWeights.Bold;
            unactiveLabel.Foreground = Brushes.Red;
            unactiveLabel.FontWeight = FontWeights.Normal;
        }

        /*
         * Change the color of rectangle where player units are
         */
        private void updateUnitUI() {
            if (game.getActivePlayer().getNation().getUnits() != null) {
                List<Unit> selectableUnits1 = game.getActivePlayer().getNation().getUnits().ToList();

                foreach (Unit u in selectableUnits1) {
                    Rectangle r = getRectangle(u.getLine(), u.getColumn());
                    r.Stroke = Brushes.GreenYellow;
                    if (r != selectedVisual)
                        r.StrokeThickness = 2;
                }
            }

            if (game.getUnactivePlayer().getNation().getUnits() != null) {
                List<Unit> selectableUnits2 = game.getUnactivePlayer().getNation().getUnits().ToList();

                foreach (Unit u in selectableUnits2) {
                    Rectangle r = getRectangle(u.getLine(), u.getColumn());
                    r.Stroke = Brushes.Red;
                    if (r != selectedVisual)
                        r.StrokeThickness = 2;
                }
            }
        }

        /*
         * Return the rectangle on line,column
         */
        private Rectangle getRectangle(int line, int column) {
            return mapGrid.Children.OfType<Rectangle>().FirstOrDefault(child => Grid.GetRow(child) == line && Grid.GetColumn(child) == column);
        }

        /*
         * Called whenever someone click on a map rectangle
         */
        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var rectangle = sender as Rectangle;
            var tile = rectangle.Tag as Box;
            int row = Grid.GetRow(rectangle);
            int column = Grid.GetColumn(rectangle);

            setDefaultOpacity();

            if(selectedVisual != null) {
                if(hasUnits(Grid.GetRow(selectedVisual), Grid.GetColumn(selectedVisual)))
                    selectedVisual.StrokeThickness = 2;
                else
                    selectedVisual.StrokeThickness = 1;
            }
            selectedVisual = rectangle;
            selectedVisual.Tag = tile;
            rectangle.StrokeThickness = 3;
            InfoLabel.Content = String.Format("[{0:00} - {1:00}] {2}", row, column, tile);

            if(_selectedUnit != null) {
                make_action(row, column);
            }
            updateForStep();
            updateUnitInfo(row, column);

            e.Handled = true;
        }

        /*
         * Is called to determine either to move a player or attack on other one
         */
        private void make_action(int row, int column) {
            var unit = _selectedUnit.Tag as Unit;
            int old_row = unit.getLine();
            int old_column = unit.getColumn();

            if (unit.canMove(row, column, map) && (old_row!=row || old_column!=column)) {
                //If the opponent has no units, we move
                if (game.getUnactivePlayer().getNation().getUnits(row, column).Count == 0)
                    unit.move(row, column, map);
                else {
                    Unit defUnit = null;
                    bool result = true;

                    // While there are defensive unit and we win battle we continue to fight
                    while (result && (defUnit = game.getBestDefensiveUnit(row, column)) != null) {
                        result = unit.attack(defUnit);
                        game.getUnactivePlayer().getNation().deleteDeadUnits();
                    }

                    // If we win battle
                    if (result)
                        unit.move(row, column, map);
                    else
                        game.getActivePlayer().getNation().deleteDeadUnits();

                }
            }

            if(!hasUnits(old_row, old_column)) {
                getRectangle(old_row, old_column).Stroke = Brushes.Gray;
                getRectangle(old_row, old_column).StrokeThickness = 1;
            }

            _selectedUnit = null;
        }

        /*
         * Update information displayed about unit in the tile with line and column
         */
        private void updateUnitInfo(int line, int column) {
            List<Unit> unitsActivePlayer = game.getActivePlayer().getNation().getUnits(line, column);
            List<Unit> unitsUnactivePlayer = game.getUnactivePlayer().getNation().getUnits(line, column);
            List<Unit> nonEmptyList = new List<Unit>();

            unitInfoPanel.Children.Clear();

            if(unitsActivePlayer.Count > 0) {
                nonEmptyList = unitsActivePlayer;
            }

            if(unitsUnactivePlayer.Count > 0) {
                nonEmptyList = unitsUnactivePlayer;
            }

            if(nonEmptyList.Count > 0) {
                Label lbl = new Label();
                lbl.Content = "There are " + nonEmptyList.Count + " units on this tile : ";
                unitInfoPanel.Children.Add(lbl);

                foreach(Unit u in nonEmptyList) {
                    StackPanel stack = getUnitDescription(u);
                    Border border = new Border();
                    border.BorderThickness = new Thickness(2);
                    border.Child = stack;
                    border.Margin = new Thickness(10);
                    
                    unitInfoPanel.Children.Add(border);

                    //If it's an active player unit, we add events to select it
                    if(nonEmptyList == unitsActivePlayer && u.hasMoves())
                        stack.MouseDown += unitStackPanel_MouseDown;
                }
            } else {
                Label lbl = new Label();
                lbl.Content = "There are no units on this tile.";
                unitInfoPanel.Children.Add(lbl);
            }
        }

        /**
         * Called when we click on one unit
         */
        private void unitStackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
            var stack = sender as StackPanel;

            selectUnit(stack);

            if (_selectedUnit != null) {
                ENation nation = game.getActivePlayer().getNation().nationType;
                Unit u = (Unit) _selectedUnit.Tag;
                int pos = u.getLine() * map.Width + u.getColumn();
                List<int> moves = wrap.possibleMoves(map.convertMapToIntList(), (int) nation, pos, game.getOpponentUnitsPositions());

                for (int i = 0; i < moves.Count; ) {
                    int row = moves[i++];
                    int col = moves[i++];

                    Rectangle r = getRectangle(row, col);
                    //Peut mieux faire (param en plus à passer au cpp pour gérer le cas du 1/2 point de deplacement des gaulois)
                    if(u.canMove(row, col,map))
                        r.Opacity = 0.5;
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
                foreach(Label lbl in _selectedUnit.Children)
                    lbl.FontWeight = FontWeights.Normal;
            }

            var unit = selectedUnit.Tag as Unit;

            /*
             * Evite la sélection d'une unité par le joueur adverse lors du changement de tour
             */
            if (game.getActivePlayer().getNation().getUnits(unit.getLine(), unit.getColumn()).Count > 0) {
                if (selectedUnit != _selectedUnit) {
                    Border parent = (Border)selectedUnit.Parent;
                    parent.BorderThickness = new Thickness(3);
                    foreach(Label lbl in selectedUnit.Children)
                        lbl.FontWeight = FontWeights.Bold;
                   
                    _selectedUnit = selectedUnit;
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
            Label lbPoint = new Label();
            lbPoint.Content = "Point : " + u.getPoint(game.getMap());
            Label lbOff = new Label();
            lbOff.Content = "Attaque : " + u.getOffensive();
            Label lbDeff = new Label();
            lbDeff.Content = "Defense : " + u.getDefensive();

            stack.Children.Add(lbLife);
            stack.Children.Add(lbPoint);
            stack.Children.Add(lbOff);
            stack.Children.Add(lbDeff);
            //we add a reference to the unit in the stack
            stack.Tag = u;

            return stack;
        }

        /*
         * Check if there still is at least one unit in the game
         */
        private bool hasUnits(int line, int column) {
            return (game.getActivePlayer().getNation().getUnits(line, column).Count > 0 ||
                game.getUnactivePlayer().getNation().getUnits(line, column).Count > 0);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            InfoLabel.Content = "Pas d'info";
            if(selectedVisual != null) {
                if(hasUnits(Grid.GetRow(selectedVisual), Grid.GetColumn(selectedVisual)))
                    selectedVisual.StrokeThickness = 2;
                else
                    selectedVisual.StrokeThickness = 1;
            }
            selectedVisual = null;
            setDefaultOpacity();
        }

        private void setDefaultOpacity() {
            foreach (Rectangle r in mapGrid.Children)
                r.Opacity = 1;
        }
    }
}
