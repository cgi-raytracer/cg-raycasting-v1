public class ScreenWithRays:IScreen<Ray3D>
{
    public int Width {get; private set;}
    public int Height {get; private set;}
    public Ray3D[,] InformationPixels {get; private set;} //width by height, (0,0) is top left corner

    public ScreenWithRays(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.InformationPixels = new Ray3D[Width,Height];
    } 

    // public ScreenWithVectors(int widthFromCenter, int Height, Camera3D camera)
    // {
    //     this.Width = widthFromCenter;
    //     this.Height = Height;
    // }

    public void AddVectorToScreen(Ray3D ray, int xOnScreen, int yOnScreen)
    {
        InformationPixels[xOnScreen, yOnScreen] = ray;
    }
}