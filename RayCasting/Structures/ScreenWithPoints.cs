public class ScreenWithPoints : IScreen<Point3D>
{
    public int Width {get; private set;}
    public int Height {get; private set;}
    public Point3D[,] InformationPixels {get; private set;}

    public ScreenWithPoints(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.InformationPixels = new Point3D[Width,Height];
    }
}
