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
            game.nextStep();
            updateForStep();
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

        private Rectangle createRectangle(int l, int c, Box tile) {
            var rectangle = new Rectangle();
            if(tile is ForestBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.FOREST);
            if(tile is SeaBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.SEA);
            if(tile is MountainBox)
                rectangle.Fill = imageBrushFactory.getImageBrush(EBoxType.MOUTAIN);
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

        private void updateInfoPanel() {
            StepLabel.Content = "Tours restants : " + game.getSteps();
            Units1Label.Content = "Unitées restantes : " + game.getPlayer1().getNbUnits();
            Units2Label.Content = "Unitées restantes : " + game.getPlayer2().getNbUnits();
            Points1Label.Content = "Points : " + game.getPlayer1().getPoints(game.getMap());
            Points2Label.Content = "Points : " + game.getPlayer2().getPoints(game.getMap());

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
            List<Unit> selectableUnits1 = game.getActivePlayer().getSelectableUnits();

            foreach(Unit u in selectableUnits1) {
                Rectangle r = getRectangle(u.getLine(), u.getColumn());
                r.Stroke = Brushes.GreenYellow;
                if(r != selectedVisual)
                    r.StrokeThickness = 2;
            }

            List<Unit> selectableUnits2 = game.getUnactivePlayer().getSelectableUnits();

            foreach(Unit u in selectableUnits2) {
                Rectangle r = getRectangle(u.getLine(), u.getColumn());
                r.Stroke = Brushes.Red;
                if(r != selectedVisual)
                    r.StrokeThickness = 2;
            }
        }

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

            //If the opponent has no units, we move
            if(game.getUnactivePlayer().getUnits(row, column).Count == 0)
                unit.move(row, column);
            else {
                Unit defUnit = null;
                bool result = true;

                // While there are defensive unit and we win battle we continue to fight
                while(result && (defUnit = game.getBestDefensiveUnit(row, column)) != null) {
                    result = unit.attack(defUnit);
                    game.getUnactivePlayer().getNation().deleteDeadUnits();
                }

                // If we win battle
                if(result)
                    unit.move(row, column);
                else
                    game.getActivePlayer().getNation().deleteDeadUnits();

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
            List<Unit> unitsActivePlayer = game.getActivePlayer().getUnits(line, column);
            List<Unit> unitsUnactivePlayer = game.getUnactivePlayer().getUnits(line, column);
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
                    unitInfoPanel.Children.Add(stack);

                    //If it's an active player unit, we add events to select it
                    if(nonEmptyList == unitsActivePlayer)
                        stack.MouseDown += unitStackPanel_MouseDown;
                }
            } else {
                Label lbl = new Label();
                lbl.Content = "There are no units on this tile.";
                unitInfoPanel.Children.Add(lbl);
            }
        }

        private void unitStackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
            var stack = sender as StackPanel;

            selectUnit(stack);

            e.Handled = true;

        }

        private void selectUnit(StackPanel selectedUnit) {
            if(_selectedUnit != null) {
                Label lbl = _selectedUnit.Children.OfType<Label>().First();
                lbl.FontWeight = FontWeights.Normal;
            }

            var unit = selectedUnit.Tag as Unit;

            if(game.getActivePlayer().getUnits(unit.getLine(), unit.getColumn()).Count > 0) {
                Label newLbl = selectedUnit.Children.OfType<Label>().First();
                newLbl.FontWeight = FontWeights.Bold;

                _selectedUnit = selectedUnit;
            }
        }

        /*
         * Return a stack panel containing a graphical description of the unit
         */
        private StackPanel getUnitDescription(Unit u) {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Vertical;

            Label lbl = new Label();
            lbl.Content = "Life : " + u.getLifePoints();

            stack.Children.Add(lbl);

            //we add a reference to the unit in the stack
            stack.Tag = u;

            return stack;
        }

        private bool hasUnits(int line, int column) {
            return (game.getActivePlayer().getUnits(line, column).Count > 0 ||
                game.getUnactivePlayer().getUnits(line, column).Count > 0);
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
        }
    }
}
