public interface ICasting<T>
{
    //position ranges from 0 to N-1
    public T GetPixelAtPosition(int column, int row);
}