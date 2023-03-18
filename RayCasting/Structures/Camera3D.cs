public class Camera3D
{
    public Point3D Position {get; private set;}
    public Vector3D Direction {get; private set;} //always normalized through constructor
    public int FieldOfView {get; private set;} //from 0 to 180
    public float DistanceToScreen {get; private set;}

    public Camera3D(Point3D position, Vector3D direction, int fieldOfView, float distanceToScreen) 
    {
        this.Position = position;
        this.Direction = direction.Normalize();
        this.FieldOfView = fieldOfView;
        this.DistanceToScreen = distanceToScreen;
    }
}