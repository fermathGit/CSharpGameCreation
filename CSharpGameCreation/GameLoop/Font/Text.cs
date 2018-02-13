﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop {
    public class Text {
        Font _font;
        List<CharacterSprite> _bitmapText = new List<CharacterSprite>();
        string _text;
        public List<CharacterSprite> CharacterSprites {
            get { return _bitmapText; }
        }

        public Text( string text, Font font ) {
            _text = text;
            _font = font;
            CreateText( 0, 0 );
        }

        private void CreateText(double x,double y ) {
            _bitmapText.Clear();
            double curX = x;
            double curY = y;
            var e = _text.GetEnumerator();
            while ( e.MoveNext() ) {
                CharacterSprite sprite = _font.CreateSprite( e.Current );
                float xOffset = (float)sprite.Data.XOffset / 2;
                float yOffset = (float)sprite.Data.YOffset / 2;

                sprite.Sprite.SetPosition( curX + xOffset, curY - yOffset );
                curX += sprite.Data.XAdvance;
                _bitmapText.Add( sprite );
            }
        }
    }
}
