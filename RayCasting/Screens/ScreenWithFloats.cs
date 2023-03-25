public class ScreenWithFloats : IScreen<float>
{
    public float Width {get; private set;}
    public float Height {get; private set;}
    public int NumberOfPixelsByWidth {get; private set;}
    public int NumberOfPixelsByHeight {get; private set;}
    public float[,] InformationPixels {get; private set;}
    public ICamera _attachedCamera {get; private set;}
    public (I3DSpaceplacable, I3DSpaceplacable, I3DSpaceplacable, I3DSpaceplacable) Corners {get; private set;}

    public ScreenWithFloats(int numberOfPixelsByWidth, int numberOfPixelsByHeight, ICamera attachedCamera)
    {
        this.NumberOfPixelsByWidth = numberOfPixelsByWidth;
        this.NumberOfPixelsByHeight = numberOfPixelsByHeight;

        this.InformationPixels = new float[numberOfPixelsByWidth, numberOfPixelsByHeight];

        this._attachedCamera = attachedCamera;

        this.Width = (float)_attachedCamera.GetScreenWidth();
        this.Height = (float)_attachedCamera.GetScreenHeight();

        this.Corners = _attachedCamera.GetScreenCorners();        
    }

    public void FillWithPixels(ICasting<float> caster)
    {
         for (int column = 0; column < InformationPixels.GetLength(0); column++) 
        {
            for (int row = 0; row < InformationPixels.GetLength(1); row++) 
            {
                float point = caster.EvaluatePixelAtPosition(column, row);

                InformationPixels[column,row] = point;
            }
        } 
    }
}