public class Camera3D
{
    public Point3D Position {get; private set;}
    public Vector3D Direction {get; private set;} //always normalized through constructor
    public int FieldOfView {get; private set;} //from 0 to 90

    public Camera3D(Point3D Position, Vector3D Direction, int FieldOfView) 
    {
        this.Position = Position;
        this.Direction = Direction.Normalize();
        this.FieldOfView = FieldOfView;
    }
}