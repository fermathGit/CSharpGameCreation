using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class Circle {
        Vector Position { get; set; }
        double Radius { get; set; }
        Color _color = Color.blue;
        public Color Color { get { return _color; }set { _color = value; } }
        public Circle() : this( Vector.Zero, 1 ) { }

        public Circle( Vector position, double radius ) {
            Position = position;
            Radius = radius;
        }

        public void Draw() {
            int vertexAmount = 50;
            double twoPI = 2.0f * Math.PI;

            Gl.glBegin( Gl.GL_LINE_LOOP );
            {
                for ( int i = 0; i < vertexAmount; ++i ) {
                    double xPos = Position.X + Radius * Math.Cos( i * twoPI / vertexAmount );
                    double yPos = Position.Y + Radius * Math.Sin( i * twoPI / vertexAmount );
                    Gl.glVertex2d( xPos, yPos );
                    Gl.glColor3f( _color.Red, _color.Green, _color.Blue );
                }
            }
            Gl.glEnd();
        }

        public bool Intersects( Point point ) {
            // Change point to a vector
            Vector vPoint = new Vector( point.X, point.Y, 0 );
            Vector vFromCircleToPoint = Position - vPoint;
            double distance = vFromCircleToPoint.Length();

            if ( distance > Radius ) {
                return false;
            }
            return true;

        }
    }
}
