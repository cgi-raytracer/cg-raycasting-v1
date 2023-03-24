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


    private float CalculateAbsoluteValue() => 
    (float)Math.Sqrt(X * X + Y * Y + Z * Z);


    public Vector3D Normalize() =>
    new Vector3D(X/AbsoluteValue, Y/AbsoluteValue, Z/AbsoluteValue);
    public bool IsNormalized() => 
    AbsoluteValue == 1 ? true : false;


    public static Vector3D operator +(Vector3D vector1, Vector3D vector2) =>
    new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
    public static Vector3D operator -(Vector3D vector1, Vector3D vector2) =>
    new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
    public static Vector3D operator -(Vector3D vector) => 
    new Vector3D(-vector.X, -vector.Y, -vector.Z);


    public Vector3D CrossProductWith(Vector3D other)
    {
        float x = this.Y * other.Z - this.Z * other.Y;
        float y = this.Z * other.X - this.X * other.Z;
        float z = this.X * other.Y - this.Y * other.X;

        return new Vector3D(x, y, z);
    }
    public float DotProductWith(Vector3D other) => 
    this.X * other.X + this.Y * other.Y + this.Z * other.Z;

    public float CosineWith(Vector3D other) => 
    DotProductWith(other) / (this.AbsoluteValue * other.AbsoluteValue);

    //in radians
    public float AngleWith(Vector3D other) =>
    (float)Math.Acos(CosineWith(other));

    public Vector3D Scale (int scaleBy) => 
    new Vector3D(this.X*scaleBy, this.Y*scaleBy, this.Z*scaleBy);
}