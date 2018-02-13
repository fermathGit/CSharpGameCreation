using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop {
    public class Text {
        Font _font;
        List<CharacterSprite> _bitmapText = new List<CharacterSprite>();
        string _text;
        Color _color = new Color( 1, 1, 1, 1 );
        Vector _dimensions;
        double _maxWidth = -1;

        public double Width { get { return _dimensions.X; } }
        public double Height { get { return _dimensions.Y; } }

        public List<CharacterSprite> CharacterSprites {
            get { return _bitmapText; }
        }

        public Text( string text, Font font ) : this( text, font, -1 ) { }
        public Text( string text, Font font ,int maxWidth) {
            _text = text;
            _font = font;
            _maxWidth = maxWidth;
            CreateText( 0, 0 ,_maxWidth);
        }

        private void CreateText( double x, double y ) {
            CreateText( x, y ,_maxWidth);
        }

        private void CreateText( double x, double y, double maxWidth ) {
            _bitmapText.Clear();
            double curX = x;
            double curY = y;
            string[] words = _text.Split( ' ' );

            for ( int i = 0, imax = words.Length; i < imax; ++i ) {
                Vector nextWordLength = _font.MeasureFont( words[i] );
                if ( maxWidth != -1 && ( curX + nextWordLength.X ) > maxWidth ) {
                    curX = 0;
                    curY += nextWordLength.Y;
                }
                string wordWithSpace = words[i] + " ";
                var e = wordWithSpace.GetEnumerator();
                while ( e.MoveNext() ) {
                    CharacterSprite sprite = _font.CreateSprite( e.Current );
                    float xOffset = (float)sprite.Data.XOffset / 2;
                    float yOffset = (float)sprite.Data.YOffset + (float)sprite.Data.Height / 2;

                    sprite.Sprite.SetPosition( x + curX + xOffset, y - curY - yOffset );
                    curX += sprite.Data.XAdvance;
                    _bitmapText.Add( sprite );
                }
            }
            _dimensions = _font.MeasureFont( _text, _maxWidth );
            _dimensions.Y = curY;
            SetColor();
        }

        public void SetPosition( double x, double y ) {
            CreateText( x, y );
        }

        public void SetColor( Color color ) {
            _color = color;
            var e = _bitmapText.GetEnumerator();
            while ( e.MoveNext() ) {
                e.Current.Sprite.SetColor( color );
            }
        }

        public void SetColor() {
            var e = _bitmapText.GetEnumerator();
            while ( e.MoveNext() ) {
                e.Current.Sprite.SetColor( _color );
            }
        }
    }
}
