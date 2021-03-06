﻿using System;
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

        private ImageBrush _point;
        private ImageBrush _life;
        private ImageBrush _sword;
        private ImageBrush _helmet;
        private ImageBrush _boots;

        private static String baseUri = "../../../IHM/textures/terrains/";

        public ImageBrushFactory() {
            BitmapImage _desertImage = new BitmapImage(new Uri(@baseUri + "desert.png", UriKind.Relative));
            _desertBrush = new ImageBrush();
            _desertBrush.ImageSource = _desertImage;

            BitmapImage _forestImage = new BitmapImage(new Uri(@baseUri + "forest.png", UriKind.Relative));
            _forestBrush = new ImageBrush();
            _forestBrush.ImageSource = _forestImage;

            BitmapImage _lowlandImage = new BitmapImage(new Uri(@baseUri + "lowland.png", UriKind.Relative));
            _lowlandBrush = new ImageBrush();
            _lowlandBrush.ImageSource = _lowlandImage;

            BitmapImage _mountainImage = new BitmapImage(new Uri(@baseUri + "mountain.png", UriKind.Relative));
            _mountainBrush = new ImageBrush();
            _mountainBrush.ImageSource = _mountainImage;

            BitmapImage _seaImage = new BitmapImage(new Uri(@baseUri + "sea.png", UriKind.Relative));
            _seaBrush = new ImageBrush();
            _seaBrush.ImageSource = _seaImage;

            BitmapImage _pointImage = new BitmapImage(new Uri(@baseUri + "../ressources/point.png", UriKind.Relative));
            _point = new ImageBrush();
            _point.ImageSource = _pointImage;

            BitmapImage _lifeImage = new BitmapImage(new Uri(@baseUri + "../ressources/life.png", UriKind.Relative));
            _life = new ImageBrush();
            _life.ImageSource = _lifeImage;

            BitmapImage _swordImage = new BitmapImage(new Uri(@baseUri + "../ressources/sword.png", UriKind.Relative));
            _sword = new ImageBrush();
            _sword.ImageSource = _swordImage;

            BitmapImage _helmetImage = new BitmapImage(new Uri(@baseUri + "../ressources/helmet.png", UriKind.Relative));
            _helmet = new ImageBrush();
            _helmet.ImageSource = _helmetImage;

            BitmapImage _bootsImage = new BitmapImage(new Uri(@baseUri + "../ressources/boots.png", UriKind.Relative));
            _boots = new ImageBrush();
            _boots.ImageSource = _bootsImage;
        }

        public ImageBrush getPointImage() {
            return _point;
        }

        public ImageBrush getLifeImage() {
            return _life;
        }
        public ImageBrush getSwordImage() {
            return _sword;
        }
        public ImageBrush getHelmetImage() {
            return _helmet;
        }
        public ImageBrush getBootsImage() {
            return _boots;
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
                case EBoxType.MOUNTAIN:
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
