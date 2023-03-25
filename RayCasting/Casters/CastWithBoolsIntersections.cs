public class CastWithBoolsIntersections : ICasting<bool>
{
    public float WidthBetweenPixels {get; private set;}
    public float HeightBetweenPixels {get; private set;}
    public IScreen<bool> _attachedScreen {get; private set;}
    public ITracable[] _figures {get; private set;}
    public IScreen<Point3D> _screenToRead {get; private set;}

    public CastWithBoolsIntersections(IScreen<Point3D> screenToRead, IScreen<bool> screenToWrite, ITracable[] figures)
    {
        this._screenToRead = screenToRead;
        this._attachedScreen = screenToWrite;
        this.WidthBetweenPixels = _attachedScreen.Width / (_attachedScreen.NumberOfPixelsByWidth-1);
        this.HeightBetweenPixels = _attachedScreen.Height / (_attachedScreen.NumberOfPixelsByHeight-1);
        this._figures = figures;
    }

    public bool EvaluatePixelAtPosition(int column, int row)
    {
        Point3D position = _attachedScreen._attachedCamera.Position;
        Point3D pixel = _screenToRead.InformationPixels[column, row];
        foreach(var figure in _figures)
        {
            if(figure.IsIntersectingWith(new Ray3D(position, new Vector3D(pixel.X, pixel.Y, pixel.Z))))
            {
                return true;
            }
        }
        return false;
    }
}