public interface ICasting<T>
{
    //position ranges from 0 to N-1
    public float WidthBetweenPixels {get;}
    public float HeightBetweenPixels {get;}
    public IScreen<T> _attachedScreen {get;}
    public T EvaluatePixelAtPosition(int column, int row);

}