public class CastWithPoints : ICasting<Point3D>
{
    public float WidthBetweenPixels {get; private set;}
    public float HeightBetweenPixels {get; private set;}
    public IScreen<Point3D> _attachedScreen {get; private set;}

    public CastWithPoints(IScreen<Point3D> screen)
    {
        this._attachedScreen = screen;
        this.WidthBetweenPixels = _attachedScreen.Width / (_attachedScreen.NumberOfPixelsByWidth-1);
        this.HeightBetweenPixels = _attachedScreen.Height / (_attachedScreen.NumberOfPixelsByHeight-1);
    }

    public Point3D EvaluatePixelAtPosition(int column, int row)
    {
        I3DSpaceplacable StarterPoint = _attachedScreen.Corners.Item1;
        return new Point3D(StarterPoint.X, StarterPoint.Y+WidthBetweenPixels*row, StarterPoint.Z-HeightBetweenPixels*column);
    }
}