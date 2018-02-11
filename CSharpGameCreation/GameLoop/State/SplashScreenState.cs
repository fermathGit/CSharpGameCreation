using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class SplashScreenState : IGameObject {
        StateSystem _system;
        public SplashScreenState( StateSystem system ) {
            _system = system;
        }
        public void Render() {
            Gl.glClearColor( 1.0f, 1.0f, 1.0f, 1.0f );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );

            //Gl.glRotated( 10 * elapsedTime, 0, 1, 0 );
            Gl.glBegin( Gl.GL_TRIANGLE_STRIP );
            {
                Gl.glColor4d( 1.0f, 0, 0, 1.0f );
                Gl.glVertex3d( -50, 0, 0 );
                Gl.glColor4d( 0, 1.0f, 0, 1.0f );
                Gl.glVertex3d( 50, 0, 0 );
                Gl.glColor4d( 0, 0, 1.0f, 1.0f );
                Gl.glVertex3d( 0, 50, 0 );
            }
            Gl.glEnd();
            Gl.glFinish();
        }

        public void Update( double elapsedTime ) {
            System.Console.WriteLine( "updating splash" );
        }
    }
}
