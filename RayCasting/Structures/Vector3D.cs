public class Vector3D:I3DSpaceplacable
{
    public float X {get; private set;}
    public float Y {get; private set;}
    public float Z {get; private set;}

    public float AbsoluteValue {get; private set;}

    public Vector3D (float X, float Y, float Z)
    {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        AbsoluteValue = CalculateAbsoluteValue();
    }

    private float CalculateAbsoluteValue()
    {
        return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public Vector3D Normalize()
    {
        if (AbsoluteValue != 1)
        {
            X /= AbsoluteValue;
            Y /= AbsoluteValue;
            Z /= AbsoluteValue;
            AbsoluteValue = 1;
        }

        return this;
    }

    public bool IsNormalized()
    {
        return AbsoluteValue == 1 ? true : false;
    }


    public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
    {
        return new Vector3D(vector1.X+vector2.X, vector1.Y+vector2.Y, vector1.Z+vector2.Z);
    }
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
    {
        return new Vector3D(vector1.X-vector2.X, vector1.Y-vector2.Y, vector1.Z-vector2.Z);
    }
        public static Vector3D operator -(Vector3D vector)
    {
        return new Vector3D(-vector.X, -vector.Y, -vector.Z);
    }

    public Vector3D CrossProductWith(Vector3D other)
    {
        float x = this.Y * other.Z - this.Z * other.Y;
        float y = this.Z * other.X - this.X * other.Z;
        float z = this.X * other.Y - this.Y * other.X;

        return new Vector3D(x, y, z);
    }

    public float DotProductWith(Vector3D other)
    {
        return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
    }


}