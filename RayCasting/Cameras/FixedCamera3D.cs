public class FixedCamera3D : ICamera
{
    public Point3D Position {get; private set;}
    public Vector3D Direction {get; private set;} //always normalized through constructor
    public int FieldOfView {get; private set;} //from 0 to 180, vFOV=hFOV
    public float DistanceToScreen {get; private set;}
  
  
    public FixedCamera3D(int fieldOfView, float distanceToScreen) 
    {
        this.Position = new Point3D(0, 0, 0);
        this.Direction = new Vector3D(1, 0, 0);
        this.FieldOfView = fieldOfView;
        this.DistanceToScreen = distanceToScreen;
    }
    
    // constructor with unfixed position and direction makes implementation much harder, so will not be used
    //
    // public FixedCamera3D(Point3D position, Vector3D direction, int fieldOfView, float distanceToScreen) 
    // {
    //     this.Position = position;
    //     this.Direction = direction.Normalize();
    //     this.FieldOfView = fieldOfView;
    //     this.DistanceToScreen = distanceToScreen;
    // }

    public double GetScreenWidth()
    {
        double hFOV = this.FieldOfView * Math.PI / 180; //coverting to radians
        return 2 * Math.Tan(hFOV/2) * DistanceToScreen;
    }

    //currently is the same as Width, because uses shared FieldOfView
    public double GetScreenHeight()
    {
        double vFOV = this.FieldOfView * Math.PI / 180; //coverting to radians
        return 2 * Math.Tan(vFOV/2) * DistanceToScreen;
    }

    //returns 4 points representing screen corners, starting upper left corner, clockwise
    public (Point3D, Point3D, Point3D, Point3D) GetScreenCorners()
    {
        float width = (float)this.GetScreenWidth();
        float height = (float)this.GetScreenHeight();

        Point3D upperLeft, upperRight, lowerRight, lowerLeft;
        Vector3D screenCenter = Direction.Scale(DistanceToScreen);

        upperLeft = new Point3D(screenCenter.X, screenCenter.Y-width/2, screenCenter.Z+height/2);
        upperRight = new Point3D(screenCenter.X, screenCenter.Y+width/2, screenCenter.Z+height/2);
        lowerRight = new Point3D(screenCenter.X, screenCenter.Y+width/2, screenCenter.Z-height/2);
        lowerLeft = new Point3D(screenCenter.X, screenCenter.Y-width/2, screenCenter.Z-height/2);


        return (upperLeft, upperRight, lowerRight, lowerLeft);
    }
    //TODO: find how to calculate screen width and hight based on fieldOfView and DistanceToScreen,
    // or find why it's not needed because width and hight will tell how dense pixels have to be together
    // based on distance to the Screen, so they are basically another set of parameters

    //TODO: Raytracer takes camera, screen with points and a figure, shoots rays through every screen pixel
    // and finds if a vector multiplication with figure is high enough. Then, one raytracer paints ScreenWithBools
    // in black and white, and the other raytracer will paint the screen according to light
}