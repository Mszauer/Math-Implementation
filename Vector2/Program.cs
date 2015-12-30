using System;

namespace Vector2 {
    public struct Vector2 {
        public float X {get; private set;}
        public float Y {get; private set; }
        public Vector2(float _x, float _y) {
            X = _x;
            Y = _y;
        }
        public Vector2 Addition(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X + vector2.X, vector1.Y + vector2.Y);
            return result;
        }
        public void Addition(Vector2 vector) {
            X += vector.X;
            Y += vector.Y;
        }
        public Vector2 Subtraction(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X - vector2.X, vector1.Y - vector2.Y);
            return result;
        }
        public void Subtraction(Vector2 vector) {
            X -= vector.X;
            Y -= vector.Y;
        }
        public Vector2 ScalarMultiplication(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X * scale, vector.Y * scale);
            return result;
        }
        public void ScalarMultiplication(float scale) {
            X *= scale;
            Y *= scale;
        }
        public Vector2 ScalarDivision(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X/scale,vector.Y/scale);
            return result;
        }
        public void ScalarDivision(float scale) {
            X /= scale;
            Y /= scale;
        }
        public float Dot(Vector2 vector1, Vector2 vector2) {
            float xComponent = vector1.X * vector2.X;
            float yComponent = vector1.Y * vector2.Y;
            return xComponent + yComponent;
        }
        public float Dot(float vector1,float vector2) {
            return vector1 * vector2;
        }
        public float Length(Vector2 vector) {
            double length = 0.0;
            length = (double)Dot(vector, vector);
            float result = (float)Math.Sqrt(length);
            return result;
        }
        public float Length() {
            double length = 0.0;
            length = (double)Dot(this,this);
            float result = (float)Math.Sqrt(length);
            return result;
        }
        public Vector2 Normalize(Vector2 vector) {
            vector.X /= Length();
            vector.Y /= Length();
            return new Vector2(vector.X, vector.Y);
        }
        public void Normalize() {
            X /= Length();
            Y /= Length();
        } 
        public float AngleBetween(Vector2 vector) {
            double angle = 0.0;
            double cosAngle = (double)(Dot(this, vector)) / (double)(Dot(Length(), vector.Length()));
            angle = Math.Acos(cosAngle);
            return (float)angle;
        }
        public float AngleBetween(Vector2 vector1, Vector2 vector2) {
            double angle = 0.0;
            double cosAngle = (double)(Dot(vector1, vector2)) / (double)(Dot(vector1.Length(),vector2.Length()));
            angle = Math.Acos(cosAngle);
            return (float)angle;
        }
        public float Cross(Vector2 vector1,Vector2 vector2) {
            float result = 0.0f;
            result = (vector1.X * vector2.Y) - (vector1.Y * vector2.X);
            return result;
        }
        public float Cross(Vector2 vector) {
            float result = 0.0f;
            result = (X * vector.Y) - (Y * vector.X);
            return result;
        }
    }


    class Program {
        static void Main(string[] args) {
        }
    }
}
