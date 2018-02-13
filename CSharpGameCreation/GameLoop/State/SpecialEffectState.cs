using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class SpecialEffectState : IGameObject {
        Font _font;
        Text _text;
        Renderer _renderer = new Renderer();
        double _totalTime = 0;

        public SpecialEffectState( TextureManager manager ) {
            _font = new Font( manager.Get( "font" ), FontParser.Parse( "Image/font.fnt" ) );
            _text = new Text( "Fermath", _font );
        }

        public void Render() {
            Gl.glClearColor( 0, 0, 0, 1 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
            _renderer.DrawText( _text );
            _renderer.Render();
        }

        public void Update( double elapsedTime ) {
            double frequency = 5;
            float _wavyNumber = (float)Math.Sin( _totalTime * frequency );
            _wavyNumber = 0.5f + _wavyNumber * 0.5f;
            _text.SetColor( new Color( 1, 0, 0, 1 ) );
            _text.SetPosition( Math.Sin( _totalTime * frequency ) * 15, Math.Cos( _totalTime * frequency ) * 15 );

            int xAdvance = 0;
            foreach ( CharacterSprite cs in _text.CharacterSprites ) {
                Vector position = cs.Sprite.GetPosition();
                position.Y = 0 + Math.Sin( ( _totalTime + xAdvance ) * frequency ) * 25;
                cs.Sprite.SetPosition( position );
                xAdvance++;
            }

            _totalTime += elapsedTime;
        }
    }
}
