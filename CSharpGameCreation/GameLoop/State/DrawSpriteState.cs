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

        float topUV = 0;
        float bottomUV = 1;
        float leftUV = 0;
        float rightUV = 1;

        TextureManager _textureManager;

        public DrawSpriteState(TextureManager textureManager) {
            halfHeight = height / 2;
            halfWidth = width / 2;
            _textureManager = textureManager;
        }
        public void Render() {
            Gl.glClearColor( 0, 0, 0, 1.0f );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );

            Texture texture = _textureManager.Get( "face_alpha" );
            Gl.glEnable( Gl.GL_TEXTURE_2D );
            Gl.glBindTexture( Gl.GL_TEXTURE_2D, texture.Id );
            Gl.glEnable( Gl.GL_BLEND );
            Gl.glBlendFunc( Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA );

            Gl.glBegin( Gl.GL_TRIANGLES );
            {
                Gl.glColor4f( 0, 1, 0, 1 );
                Gl.glTexCoord2d( leftUV, topUV );
                Gl.glVertex3d( x - halfWidth, y + halfHeight, z );
                Gl.glTexCoord2d( rightUV, topUV );
                Gl.glVertex3d( x + halfWidth, y + halfHeight, z );
                Gl.glTexCoord2d( leftUV, bottomUV );
                Gl.glVertex3d( x - halfWidth, y - halfHeight, z );

                Gl.glTexCoord2d( rightUV, topUV );
                Gl.glVertex3d( x + halfWidth, y + halfHeight, z );
                Gl.glTexCoord2d( rightUV, bottomUV );
                Gl.glVertex3d( x + halfWidth, y - halfHeight, z );
                Gl.glTexCoord2d( leftUV, bottomUV );
                Gl.glVertex3d( x - halfWidth, y - halfHeight, z );
            }
            Gl.glEnd();
        }

        public void Update( double elapsedTime ) {
            x += elapsedTime*10;
        }
    }
}
