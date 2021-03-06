﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GameLoop {
    [StructLayout( LayoutKind.Sequential )]
    public struct Vector {
        public static readonly Vector Zero = new Vector( 0, 0, 0 );

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector( double x, double y, double z ) : this() {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length() {
            return Math.Sqrt( LengthSquared() );
        }
        public double LengthSquared() {
            return ( X * X + Y * Y + Z * Z );
        }
        public Vector Add( Vector r ) {
            return new Vector( X + r.X, Y + r.Y, Z + r.Z );
        }
        public Vector Subtract( Vector r ) {
            return new Vector( X - r.X, Y - r.Y, Z - r.Z );
        }
        public bool Equals( Vector v ) {
            return ( X == v.X ) && ( Y == v.Y ) && ( Z == v.Z );
        }

        public override int GetHashCode() {
            return (int)X ^ (int)Y ^ (int)Z;
        }

        public static bool operator ==( Vector v1, Vector v2 ) {
            // If they're the same object or both null, return.
            if ( System.Object.ReferenceEquals( v1, v2 ) ) {
                return true;
            }

            // If one is null, but not both, return false.
            if ( v1 == null || v2 == null ) {
                return false;
            }

            return v1.Equals( v2 );
        }

        public static bool operator !=( Vector v1, Vector v2 ) {
            return !v1.Equals( v2 );
        }

        public override bool Equals( object obj ) {
            if ( obj is Vector ) {
                return Equals( (Vector)obj );
            }
            return base.Equals( obj );
        }

        public Vector Multiply( double v ) {
            return new Vector( X * v, Y * v, Z * v );
        }

        public static Vector operator *( Vector v, double s ) {
            return v.Multiply( s );
        }
        public static double operator *( Vector v1, Vector v2 ) {
            return v1.DotProduct( v2 );
        }

        public static Vector operator +( Vector v1, Vector v2 ) {
            return v1.Add( v2 );
        }
        public static Vector operator -( Vector v1, Vector v2 ) {
            return v1.Subtract( v2 );
        }

        public Vector CrossProduct( Vector v ) {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector( nx, ny, nz );
        }

        public double DotProduct( Vector v ) {
            return ( v.X * X ) + ( Y * v.Y ) + ( Z * v.Z );
        }

        public Vector Normalise( Vector v ) {
            double r = v.Length();
            if ( r != 0.0 )             // guard against divide by zero
            {
                return new Vector( v.X / r, v.Y / r, v.Z / r ); // normalise and return
            } else {
                return new Vector( 0, 0, 0 );
            }
        }

        public override string ToString() {
            return string.Format( "X:{0}, Y:{1}, Z:{2}", X, Y, Z );
        }
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct Point {
        public float X { get; set; }
        public float Y { get; set; }

        public Point( float x, float y ) : this() {
            X = x;
            Y = y;
        }
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct Color {
        public static readonly Color write = new Color( 1, 1, 1, 1 );
        public static readonly Color black = new Color( 0, 0, 0, 1 );
        public static readonly Color red = new Color( 1, 0, 0, 1 );
        public static readonly Color green = new Color( 0, 1, 0, 1 );
        public static readonly Color blue = new Color(0, 0, 1, 1 );

        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Alpha { get; set; }

        public Color( float r, float g, float b, float a ) : this() {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }
    }

    public class Struct {
        
    }
}
