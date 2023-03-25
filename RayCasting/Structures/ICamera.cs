public interface ICamera
{
    public Point3D Position {get;}
    public Vector3D Direction {get;} //always normalized through constructor
    public int FieldOfView {get;} //from 0 to 180, vFOV=hFOV
    public float DistanceToScreen {get;}

    public double GetScreenWidth();
    public double GetScreenHeight();
}