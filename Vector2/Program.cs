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
        public Vector2 Subtraction(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X - vector2.X, vector1.Y - vector2.Y);
            return result;
        }
        public Vector2 ScalarMultiplication(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X * scale, vector.Y * scale);
            return result;
        }
        public Vector2 ScalarDivision(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X/scale,vector.Y/scale);
            return result;
        }
        public float Dot(Vector2 vector1, Vector2 vector2) {
            float xComponent = vector1.X * vector2.X;
            float yComponent = vector1.Y * vector2.Y;
            return xComponent + yComponent;
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
    }


    class Program {
        static void Main(string[] args) {
        }
    }
}
