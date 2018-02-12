using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop {
    public class WaveformGraphState : IGameObject {
        double _xPos = -100;
        double _yPos = -100;
        double _xLength = 200;
        double _yLength = 200;
        double _sampleSize = 100;
        double _frequency = 2;
        public delegate double WaveFunction( double value );

        public WaveformGraphState() {
            Gl.glLineWidth( 3 );
            Gl.glDisable( Gl.GL_TEXTURE_2D );
        }

        public void DrawAxis() {
            Gl.glColor3f( 1, 1, 1 );

            Gl.glBegin( Gl.GL_LINES );
            {
                Gl.glVertex2d( _xPos, _yPos );
                Gl.glVertex2d( _xPos + _xLength, _yPos );

                Gl.glVertex2d( _xPos, _yPos );
                Gl.glVertex2d( _xPos, _yPos + _yLength );
            }
            Gl.glEnd();
        }

        public void DrawGraph( WaveFunction waveFunction, Color color ) {
            double xIncrement = _xLength / _sampleSize;
            double previousX = _xPos;
            double previousY = _yPos + ( 0.5f * _yLength );
            Gl.glColor3f( color.Red, color.Green, color.Blue );
            Gl.glBegin( Gl.GL_LINES );
            {
                for ( int i = 0; i < _sampleSize; ++i ) {
                    double newX = previousX + xIncrement;
                    double percentDone = ( i / _sampleSize );
                    double percentRadians = percentDone * ( Math.PI * _frequency );

                    double newY = _yPos + waveFunction( percentRadians ) * ( _yLength / 2 );

                    if ( i > 1 ) {
                        Gl.glVertex2d( previousX, previousY );
                        Gl.glVertex2d( newX, newY );
                    }

                    previousX = newX;
                    previousY = newY;
                }
            }
            Gl.glEnd();
        }

        public void Render() {
            DrawAxis();

        }

        public void Update( double elapsedTime ) {
            
        }
    }
}
