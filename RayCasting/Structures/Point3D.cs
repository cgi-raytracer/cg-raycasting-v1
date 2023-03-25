public class Point3D:I3DSpaceplacable
{
    public float X {get; private set;}
    public float Y {get; private set;}
    public float Z {get; private set;}

    public Point3D(float X, float Y, float Z)
    {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
    }

    public float GetDistance(Point3D other)
    {
        float x = this.X - other.X;
        float y = this.Y - other.Y;
        float z = this.Z - other.Z;

        return (float)Math.Sqrt(x * x + y * y + z * z);
    }

    public static Point3D operator +(Point3D point, Vector3D vector)
    {
        return new Point3D(point.X+vector.X, point.Y+vector.Y, point.Z+vector.Z);
    }
    // public static Vector3D operator +(Vector3D vector, Point3D point)
    // {
    //     return new Vector3D(vector.X+point.X, vector.Y+point.Y, vector.Z+point.Z);
    // }
    public static Point3D operator -(Point3D point, Vector3D vector)
    {
        return new Point3D(point.X-vector.X, point.Y-vector.Y, point.Z-vector.Z);
    }
    // public static Vector3D operator -(Vector3D vector, Point3D point)
    // {
    //     return new Vector3D(vector.X-point.X, vector.Y-point.Y, vector.Z-point.Z);
    // }

    public override string ToString()
    {
        return $"{X}, {Y}, {Z}";
    }
}
