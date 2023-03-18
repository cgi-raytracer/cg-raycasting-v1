public class Ray3D
{
    public Point3D Position {get; private set;}
    public Vector3D Direction {get; private set;} //always normalized through constructor
    
    public Ray3D(Point3D position, Vector3D direction) 
    {
        this.Position = position;
        this.Direction = direction.Normalize();
    }
}