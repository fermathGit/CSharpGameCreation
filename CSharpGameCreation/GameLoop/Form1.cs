using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.DevIl;

namespace GameLoop {
    public partial class Form1 : Form {
        FastLoop _fastLoop;
        bool _fullScreen = false;
        StateSystem _system = new StateSystem();
        TextureManager _textureManager = new TextureManager();

        public Form1() {
            InitializeComponent();
            _openGlControl.InitializeContexts();

            //Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer( Ilut.ILUT_OPENGL );

            //Load textures
            _textureManager.LoadTexture( "1", "Image/1.tif" );
            _textureManager.LoadTexture( "face", "Image/face.tif" );
            _textureManager.LoadTexture( "face_alpha", "Image/face_alpha.tif" );
            _textureManager.LoadTexture( "font", "Image/font.tga" );

            //states
            _system.AddState( "splash", new SplashScreenState( _system ) );
            _system.AddState( "title_menu", new TitleMenuState( _system ) );
            _system.AddState( "sprite_test", new DrawSpriteState( _textureManager ) );
            _system.AddState( "TestRender", new TestSpriteClassState( _textureManager ) );
            _system.AddState( "WaveformGraphState", new WaveformGraphState( ) );
            _system.AddState( "TextTest", new TextTestState( _textureManager ) ); 
            _system.AddState( "TextRender", new TextRenderState( _textureManager ) );
            _system.AddState( "SpecialEffect", new SpecialEffectState( _textureManager ) );

            _system.ChangeState( "SpecialEffect" );

            if ( _fullScreen ) {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            } else {
                ClientSize = new Size( 1280, 720 );
            }
            Setup2DGraphics( ClientSize.Width, ClientSize.Height );
            _fastLoop = new FastLoop( GameLoop );
            
        }

        private void GameLoop( double elapsedTime ) {
            _system.Update( elapsedTime );
            _system.Render();
            _openGlControl.Refresh();
        }

        protected override void OnClientSizeChanged( EventArgs e ) {
            base.OnClientSizeChanged( e );
            Gl.glViewport( 0, 0, this.ClientSize.Width, this.ClientSize.Height );
            Setup2DGraphics( ClientSize.Width, ClientSize.Height );
        }

        private void Setup2DGraphics( double width, double height ) {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode( Gl.GL_PROJECTION );
            Gl.glLoadIdentity();
            Gl.glOrtho( -halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100 );
            Gl.glMatrixMode( Gl.GL_MODELVIEW );
            Gl.glLoadIdentity();
        }
    }




}
