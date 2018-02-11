using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class DrawSpriteState : IGameObject {
        double x = 0;
        double y = 0;
        double z = 0;
        double height = 200;
        double width = 200;
        double halfHeight;
        double halfWidth;

        public DrawSpriteState() {
            halfHeight = height / 2;
            halfWidth = width / 2;
        }
        public void Render() {
            Gl.glClearColor( 0, 0, 0, 1.0f );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
            Gl.glBegin( Gl.GL_TRIANGLES );
            {
                Gl.glVertex3d( x - halfWidth, y + halfHeight, z );
                Gl.glVertex3d( x + halfWidth, y + halfHeight, z );
                Gl.glVertex3d( x - halfWidth, y - halfHeight, z );

                Gl.glVertex3d( x + halfWidth, y + halfHeight, z );
                Gl.glVertex3d( x + halfWidth, y - halfHeight, z );
                Gl.glVertex3d( x - halfWidth, y - halfHeight, z );
            }
            Gl.glEnd();
        }

        public void Update( double elapsedTime ) {

        }
    }
}
