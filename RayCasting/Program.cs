public class Program
{
    private static void Main(string[] args)
    {
        int fieldOfView = 90;
        int numberOfPixels = 80;
        float distanceToScreen = 1;
        Ray3D light = new Ray3D(new Point3D(1, -2, 0), new Vector3D(-1, -2, 1));

        FixedCamera3D webcam = new FixedCamera3D(fieldOfView, distanceToScreen);

        ScreenWithPoints screen1 = new ScreenWithPoints(numberOfPixels, numberOfPixels, webcam);

        screen1.FillWithPixels(new CastWithPoints(screen1));

        ScreenWithBools screen2 = new ScreenWithBools(numberOfPixels, numberOfPixels, webcam);

        ITracable[] figures = new ITracable[1];
        figures[0] = new Sphere(new Point3D((float)1.7, 0, 0), (float)1);
        //figures[0] = new Sphere(new Point3D(3, -1, 0), (float)1);
        //figures[1] = new Sphere(new Point3D(3, 1, 0), (float)1);
       

        screen2.FillWithPixels(new CastWithBoolsIntersections(screen1, screen2, figures));

        ScreenWithFloats screen3 = new ScreenWithFloats(numberOfPixels, numberOfPixels, webcam);

        screen3.FillWithPixels(new CastWithLuminosityValues(screen1, screen3, figures, light));

        int counter = 0;
        foreach (var item in screen2.InformationPixels)
        {
            if(item)
            {
                Console.Write("#");
            }
            else Console.Write("_");

            counter+=1;
            if(counter == numberOfPixels)
            {
                Console.Write('\n');
                counter = 0;
            }
        }

        counter = 0;
        foreach (var item in screen3.InformationPixels)
        {
            if(item > 0.8)
                Console.Write("#");
            else if(item > 0.5)
                Console.Write("O");
            else if(item > 0.2)
                Console.Write("*");
            else if(item > 0)
                Console.Write(".");
            else Console.Write(" ");

            counter+=1;
            if(counter == numberOfPixels)
            {
                Console.Write('\n');
                counter = 0;
            }
        }

        Console.ReadLine();
    }
}