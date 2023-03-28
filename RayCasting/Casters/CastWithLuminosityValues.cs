public class CastWithLuminosityValues : ICasting<float>
{
    public float WidthBetweenPixels {get; private set;}
    public float HeightBetweenPixels {get; private set;}
    public IScreen<float> _attachedScreen {get; private set;}
    public ITracable[] _figures {get; private set;}
    public IScreen<Point3D> _screenToRead {get; private set;}
    public Ray3D lightSource {get; private set;}

    public CastWithLuminosityValues(IScreen<Point3D> screenToRead, IScreen<float> screenToWrite, ITracable[] figures, Ray3D LightSource)
    {
        this._screenToRead = screenToRead;
        this._attachedScreen = screenToWrite;
        this.WidthBetweenPixels = _attachedScreen.Width / (_attachedScreen.NumberOfPixelsByWidth-1);
        this.HeightBetweenPixels = _attachedScreen.Height / (_attachedScreen.NumberOfPixelsByHeight-1);
        this._figures = figures;
        this.lightSource = LightSource;
    }

    public float EvaluatePixelAtPosition(int column, int row)
    {
        Point3D position = _attachedScreen._attachedCamera.Position;
        Point3D pixel = _screenToRead.InformationPixels[column, row];
        List<(Ray3D, float)> figureNormals = new List<(Ray3D, float)>();
        foreach(var figure in _figures)
        {
            Ray3D? normal = figure.GetNormalAtPointWith(new Ray3D(position, new Vector3D(pixel.X, pixel.Y, pixel.Z)));
            if(normal is not null)
            {
                figureNormals.Add((normal, normal.Position.GetDistance(pixel)));
            }
        }
        figureNormals.Sort((x, y) => y.Item2.CompareTo(x.Item2));
        if (figureNormals.Count > 0) {
            return figureNormals.First<(Ray3D, float)>().Item1.Direction.DotProductWith(lightSource.Direction);
        }
        return 0;
    }
}
