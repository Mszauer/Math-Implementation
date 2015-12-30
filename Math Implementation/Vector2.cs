using System;


namespace Math_Implementation {
    public class Vector2 {
        public float X = 0.0f;
        public float Y = 0.0f;
        public Vector2(float _x, float _y) {
            X = _x;
            Y = _y;
        }
        public Vector2() {
            X = 0;
            Y = 0;
        }
        public static Vector2 operator +(Vector2 vector1, Vector2 vector2) {
            return new Vector2(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
        public void Addition(Vector2 vector) {
            X += vector.X;
            Y += vector.Y;
        }
        public static Vector2 operator -(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X - vector2.X, vector1.Y - vector2.Y);
            return result;
        }
        public void Subtraction(Vector2 vector) {
            X -= vector.X;
            Y -= vector.Y;
        }
        public static Vector2 operator *(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X * scale, vector.Y * scale);
            return result;
        }
        public void ScalarMultiplication(float scale) {
            X *= scale;
            Y *= scale;
        }
        public static Vector2 operator *(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X * vector2.X, vector1.Y * vector2.Y);
            return result;
        }
        public void ScalarMultiplication(Vector2 scale) {
            X *= scale.X;
            Y *= scale.Y;
        }
        public static Vector2 operator /(Vector2 vector, float scale) {
            Vector2 result = new Vector2(vector.X / scale, vector.Y / scale);
            return result;
        }
        public static Vector2 operator /(Vector2 vector1, Vector2 vector2) {
            Vector2 result = new Vector2(vector1.X / vector2.X, vector1.Y / vector2.Y);
            return result;
        }
        public void ScalarDivision(float scale) {
            X /= scale;
            Y /= scale;
        }
        public void ScalarDivision(Vector2 scale) {
            X /= scale.X;
            Y /= scale.Y;
        }
        public float Dot(Vector2 vector1, Vector2 vector2) {
            float xComponent = vector1.X * vector2.X;
            float yComponent = vector1.Y * vector2.Y;
            return xComponent + yComponent;
        }
        public float Length(Vector2 vector) {
            double length = 0.0;
            length = (double)Dot(vector, vector);
            float result = (float)Math.Sqrt(length);
            return result;
        }
        public float Length() {
            return (float)Math.Sqrt((double)Dot(this, this));
        }
        public float LengthSquared() {
            return Dot(this, this);
        }
        public Vector2 Normalize(Vector2 vector) {
            float length = Length();
            vector.X /= length;
            vector.Y /= length;
            return new Vector2(vector.X, vector.Y);
        }
        public void Normalize() {
            X /= Length();
            Y /= Length();
        }
        public float AngleBetween(Vector2 vector) {
            return (float)Math.Acos((double)Dot(Normalize(this), Normalize(vector)));
        }
        public float AngleBetween(Vector2 vector1, Vector2 vector2) {
            return (float)Math.Acos((double)Dot(Normalize(vector1), Normalize(vector2)));
        }
        public static Vector2 operator -(Vector2 vector) {
            return new Vector2(vector.X * -1, vector.Y * -1);
        }
        public void Negate() {
            X *= -1;
            Y *= -1;
        }
        public static bool operator ==(Vector2 vector1,Vector2 vector2) {
            return (vector1.X == vector2.X) && (vector1.Y == vector2.Y )? true : false;
        }
        public static bool operator !=(Vector2 vector1, Vector2 vector2) {
            return (vector1.X != vector2.X) && (vector1.Y != vector2.Y) ? true : false;
        }
        public static bool operator >=(Vector2 vector1, Vector2 vector2) {
            return (vector1.X >= vector2.X) && (vector1.Y >= vector2.Y) ? true : false;
        }
        public static bool operator <=(Vector2 vector1, Vector2 vector2) {
            return (vector1.X <= vector2.X) && (vector1.Y <= vector2.Y) ? true : false;
        }
        public static bool operator <(Vector2 vector1, Vector2 vector2) {
            return (vector1.X < vector2.X) && (vector1.Y < vector2.Y) ? true : false;
        }
        public static bool operator >(Vector2 vector1, Vector2 vector2) {
            return (vector1.X > vector2.X) && (vector1.Y > vector2.Y) ? true : false;
        }
    }
}
