using System;
namespace AmdOnlyRts.MathUtilities
{
    public class Vector2D{

        public float X;
        public float Y;
        public Vector2D(float pointX, float pointY){
            X = pointX;
            Y = pointY;
        }
        public Vector2D(){
            X = 0;
            Y = 0;
        }
        public float Length(){
            float result = 0;
            
            result = (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

            return result;
        }
        public float LengthSquared(){
            return (float)Math.Pow(Length(), 2);
        }
        public Vector2D Normalize(){
            Vector2D result = new Vector2D();
            
            result.X = X/Length();
            result.Y = Y/Length();

            return result;
        }
        public static float Dot(Vector2D vector1, Vector2D vector2){
            float result = 0;
            double theta = Vector2D.Angle(vector1, vector2);
            result = vector1.Length() * vector2.Length() * (float)Math.Cos( theta );
            return result;
        }
        public static Vector2D Sum(Vector2D vector1, Vector2D vector2){
            return new Vector2D(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
        public static float Product(Vector2D vector1, Vector2D vector2){
            return (vector1.X * vector2.X + vector1.Y * vector2.Y);
        }
        public static float Angle(Vector2D vector1, Vector2D vector2){
            float result = 0;
            float top = Product(vector1, vector2);
            float bottom = vector1.Length() * vector2.Length();
            if(bottom == 0) return 0;
            
            result = (float)Math.Acos(top / bottom);
            return result;
        }
        
    }
}