using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class CircleIntersectionState : IGameObject {
        Circle circle = new Circle( Vector.Zero, 200 );
        public CircleIntersectionState() {
            Gl.glLineWidth( 3 );
            Gl.glDisable( Gl.GL_TEXTURE_2D );
        }
        public void Render() {
            circle.Draw();
        }

        public void Update( double elapsedTime ) {
            
        }
    }
}
