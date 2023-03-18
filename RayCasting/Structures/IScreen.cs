using System.Collections.Generic;

public interface IScreen<T>
{
    public int Width {get;}
    public int Height {get;}
    public T[,] InformationPixels {get;}
}