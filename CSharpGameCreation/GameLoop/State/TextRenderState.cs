using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class TextRenderState : IGameObject {
        TextureManager _textureManager;
        Font _font;
        Text _text;
        Renderer _renderer = new Renderer();
        FramesPerSecond _fps = new FramesPerSecond();
        public TextRenderState( TextureManager textureManager ) {
            _textureManager = textureManager;
            _font = new Font( textureManager.Get( "font" ), FontParser.Parse( "Image/font.fnt" ) );
        }
        public void Render() {
            Gl.glClearColor( 0, 0, 0, 1 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
            _text = new Text( "Fermath" + " FPS:" + _fps.CurrentFPS.ToString( "00.0000000" ), _font, 200 );
            _renderer.DrawText( _text );
            //for ( int i = 0; i < 1000; ++i ) {
            //    _renderer.DrawText( _text );
            //}
        }

        public void Update( double elapsedTime ) {
            _fps.Process( elapsedTime );
        }
    }
}
