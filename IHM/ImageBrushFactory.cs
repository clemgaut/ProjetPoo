using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IHM {
    class ImageBrushFactory {
        private ImageBrush _desertBrush;
        private ImageBrush _forestBrush;
        private ImageBrush _lowlandBrush;
        private ImageBrush _mountainBrush;
        private ImageBrush _seaBrush;

        public ImageBrushFactory() {
            BitmapImage _desertImage = new BitmapImage(new Uri(@"../../../IHM/textures/terrains/desert.png", UriKind.Relative));
            _desertBrush = new ImageBrush();
            _desertBrush.ImageSource = _desertImage;

            BitmapImage _forestImage = new BitmapImage(new Uri(@"../../../IHM/textures/terrains/forest.png", UriKind.Relative));
            _forestBrush = new ImageBrush();
            _forestBrush.ImageSource = _forestImage;

            BitmapImage _lowlandImage = new BitmapImage(new Uri(@"../../../IHM/textures/terrains/lowland.png", UriKind.Relative));
            _lowlandBrush = new ImageBrush();
            _lowlandBrush.ImageSource = _lowlandImage;

            BitmapImage _mountainImage = new BitmapImage(new Uri(@"../../../IHM/textures/terrains/mountain.png", UriKind.Relative));
            _mountainBrush = new ImageBrush();
            _mountainBrush.ImageSource = _mountainImage;

            BitmapImage _seaImage = new BitmapImage(new Uri(@"../../../IHM/textures/terrains/sea.png", UriKind.Relative));
            _seaBrush = new ImageBrush();
            _seaBrush.ImageSource = _seaImage;
        }

        public ImageBrush getImageBrush(EBoxType boxType) {
            ImageBrush image = null;
            switch(boxType) {
                case EBoxType.DESERT:
                    image = _desertBrush;
                    break;
                case EBoxType.FOREST:
                    image = _forestBrush;
                    break;
                case EBoxType.LOWLAND:
                    image = _lowlandBrush;
                    break;
                case EBoxType.MOUTAIN:
                    image = _mountainBrush;
                    break;
                case EBoxType.SEA:
                    image = _seaBrush;
                    break;
            }

            return image;
        }
    }
}
