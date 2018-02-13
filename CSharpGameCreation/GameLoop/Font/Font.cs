using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop {
  public   class Font {
        Texture _texture;
        Dictionary<char, CharacterData> _characterData;
        public Font( Texture texture, Dictionary<char, CharacterData> characterData ) {
            _texture = texture;
            _characterData = characterData;
        }

        public CharacterSprite CreateSprite( char c ) {
            CharacterData charData = _characterData[c];
            Sprite sprite = new Sprite();
            sprite.Texture = _texture;

            Point topleft = new Point( (float)charData.X / (float)_texture.Width,
                (float)charData.Y / (float)_texture.Height );

            Point bottomRight = new Point( (float)charData.Width / (float)_texture.Width + topleft.X, 
                (float)charData.Height / (float)_texture.Height + topleft.Y );
            sprite.SetUVs( topleft, bottomRight );
            sprite.SetWidth( charData.Width );
            sprite.SetHeight( charData.Height );
            sprite.SetColor( new Color( 1, 1, 1, 1 ) );
            return new CharacterSprite( sprite, charData );
        }
    }
}
