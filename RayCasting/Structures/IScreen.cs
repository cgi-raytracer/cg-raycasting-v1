public interface IScreen<T>
{
    public float Width {get;}
    public float Height {get;}
    public int NumberOfPixelsByWidth {get;}
    public int NumberOfPixelsByHeight {get;}
    public T[,] InformationPixels {get;}
    public ICamera _attachedCamera {get;}

    public void FillWithPixels(ICasting<T> caster);
}