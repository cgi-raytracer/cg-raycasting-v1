using System.Collections;

public class ScreenWithPoints : IScreen<Point3D>
{
    public float Width {get; private set;}
    public float Height {get; private set;}
    public int NumberOfPixelsByWidth {get; private set;}
    public int NumberOfPixelsByHeight {get; private set;}
    public Point3D[,] InformationPixels {get; private set;}
    public (I3DSpaceplacable, I3DSpaceplacable, I3DSpaceplacable, I3DSpaceplacable) Corners {get; private set;}
    public ICamera _attachedCamera {get; private set;}


    public ScreenWithPoints(int numberOfPixelsByWidth, int numberOfPixelsByHeight, ICamera attachedCamera)
    {
        this.NumberOfPixelsByWidth = numberOfPixelsByWidth;
        this.NumberOfPixelsByHeight = numberOfPixelsByHeight;

        this.InformationPixels = new Point3D[numberOfPixelsByWidth, numberOfPixelsByHeight];

        this._attachedCamera = attachedCamera;

        this.Width = (float)_attachedCamera.GetScreenWidth();
        this.Height = (float)_attachedCamera.GetScreenHeight();

        this.Corners = _attachedCamera.GetScreenCorners();
    }

    public void FillWithPixels(ICasting<Point3D> caster)
    {    
        for (int column = 0; column < InformationPixels.GetLength(0); column++) 
        {
            for (int row = 0; row < InformationPixels.GetLength(1); row++) 
            {
                Point3D point = caster.EvaluatePixelAtPosition(column, row);

                InformationPixels[column,row] = point;
            }
        } 
    }

    public Point3D EvaluatePixelValue(ICasting<Point3D> caster, int column, int row)
    {
        return caster.EvaluatePixelAtPosition(column, row);
    }
}
