using System;

namespace Math_Implementation {
    class Quaternion {
        public float X = 0.0f;
        public float Y = 0.0f;
        public float Z = 0.0f;
        public float W = 0.0f;
        public Quaternion(float x,float y,float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = W;
        }
        public Quaternion() {
            X = Y = Z = W = 0.0f;
        }
        public static float Length(Quaternion q) {
            return (float)Math.Sqrt(q.X * q.X + q.Y * q.Y + q.Z * q.Z + q.W * q.W);
        }
        public static float LengthSquared(Quaternion q) {
            return (q.X * q.X + q.Y * q.Y + q.Z * q.Z + q.W * q.W);
        }
        public static Quaternion Normalize(Quaternion q) {
            Quaternion result = new Quaternion();
            float qLength = Length(q);
            result.X /= qLength;
            result.Y /= qLength;
            result.Z /= qLength;
            result.W /= qLength;
            return result;
        }
        public static Quaternion FromAngleAxis(Vector3 axis, float angle) {
            angle = angle * (float)(Math.PI / 180);
            Quaternion result = new Quaternion();
            float sin = (float)Math.Sin(angle);
            axis = Vector3.Normalize(axis);
            result.W = (float)Math.Cos(angle);
            result.X = axis.X * sin;
            result.Y = axis.Y * sin;
            result.Z = axis.Z * sin;
            return result;
        }
        public static Matrix3 ToMatrix(Quaternion q) {
            Matrix3 result = new Matrix3();
            float xSq = q.X * q.X;
            float ySq = q.Y * q.Y;
            float zSq = q.Z * q.Z;
            float wSq = q.W * q.W;
            float twoX = 2.0f * q.X;
            float twoY = 2.0f * q.Y;
            float twoW = 2.0f * q.W;
            float xy = twoX * q.Y;
            float xz = twoX * q.Z;
            float yz = twoY * q.Z;
            float wx = twoW * q.X;
            float wy = twoW * q.Y;
            float wz = twoW * q.Z;
            result[0, 0] = wSq + xSq - ySq - zSq;
            result[0, 1] = xy - wz;
            result[0, 2] = xz + wy;
            result[1, 0] = xy + wz;
            result[1, 1] = wSq - xSq + ySq - zSq;
            result[1, 2] = yz - wx;
            result[2, 0] = xz - wy;
            result[2, 1] = yz + wx;
            result[2, 2] = wSq - xSq - ySq + zSq;
            return result;
        }
        public static Quaternion Conjugate(Quaternion q) {
            Quaternion result = new Quaternion();
            result.X = -q.X;
            result.Y = -q.Y;
            result.Z = -q.Z;
            return result;
        }
        public static Quaternion operator *(Quaternion A, Quaternion B) {
            Quaternion result = new Quaternion();
            result.X = A.W * B.X + A.X * B.W + A.Y * B.Z - A.Z * B.Y;
            result.Y = A.W * B.Y - A.X * B.Z + A.Y * B.W + A.Z * B.X;
            result.Z = A.W * B.Z + A.X * B.Y - A.Y * B.X + A.Z * B.W;
            result.W = A.W * B.W - A.X * B.X - A.Y * B.Y - A.Z * B.Z;
            return result;
        }
        public static Quaternion Multiply(Quaternion A, Quaternion B) {
            Quaternion result = new Quaternion();
            result.X = A.W * B.X + A.X * B.W + A.Y * B.Z - A.Z * B.Y;
            result.Y = A.W * B.Y - A.X * B.Z + A.Y * B.W + A.Z * B.X;
            result.Z = A.W * B.Z + A.X * B.Y - A.Y * B.X + A.Z * B.W;
            result.W = A.W * B.W - A.X * B.X - A.Y * B.Y - A.Z * B.Z;
            return result;
        }
    }
}
