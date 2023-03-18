public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.ReadLine();

        Point3D point = new Point3D (2, 2, 2);
        Vector3D vect = new Vector3D (1, 1, 1);

        Vector3D new_vect= vect+ vect;
        Point3D new_point = point + vect;
        // Point3D new_point2 = vect + point;
    }
}