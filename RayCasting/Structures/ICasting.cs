public interface ICasting<T>
{
    //position ranges from 0 to N-1
    public float WidthBetweenPixels {get;}
    public float HeightBetweenPixels {get;}
    public T GetPixelValueAtPosition(int column, int row);
}