public class Ray3D
{
    public Point3D Position {get; private set;}
    public Vector3D Direction {get; private set;} //always normalized through constructor
    
    public Ray3D(Point3D Position, Vector3D Direction) 
    {
        this.Position = Position;
        this.Direction = Direction.Normalize();
    }
}