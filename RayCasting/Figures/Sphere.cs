public class Sphere : ITracable
{
    public Point3D Center { get; set; }
    public float Radius { get; set; }

    public Sphere(Point3D center, float radius)
    {
        this.Center = center;
        this.Radius = radius;
    }

    public bool IsIntersectingWith(Ray3D ray)
    {
        if (this.GetIntersectionPointWith(ray) is not null)
        {
            return true;
        }
        return false;
    }
    public Point3D? GetIntersectionPointWith(Ray3D ray)
    {
       float Ray3DDirSquared = ray.Direction.DotProductWith(ray.Direction);

        float RadiusSquared = Radius * Radius;

        float KSquared = new Vector3D(Center, ray.Position).DotProductWith(new Vector3D(Center, ray.Position));

        float a = Ray3DDirSquared;
        float b = 2 * ray.Direction.DotProductWith(new Vector3D(Center, ray.Position));
        float c = KSquared - RadiusSquared;

        //discriminant
        var D = b * b - 4 * a * c;
        if (D < 0)//no real roots
        {
            return null;
        }

        // x1 and x2
        double x1 = (-b - Math.Sqrt(D)) / (2 * a);
        double x2 = (-b + Math.Sqrt(D)) / (2 * a);
        float distanceToPoint; 
        if (x1 <= x2)// if equal then D = 0 and only 1 real root exits
        {
            distanceToPoint = (float)x1;
        }
        else distanceToPoint = (float)x2;

        return ray.Position + ray.Direction.Scale(distanceToPoint);
    }  

    public Ray3D? GetNormalAtPointWith(Ray3D ray)
    {
        Point3D? touchingPoint = this.GetIntersectionPointWith(ray);
        if(touchingPoint is not null)
            return new Ray3D(touchingPoint, new Vector3D(Center, touchingPoint));
        else return null;
    }
}