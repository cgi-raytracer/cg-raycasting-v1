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
        float Ray3DDirSquared = ray.Direction.DotProductWith(ray.Direction);

        float RadiusSquared = Radius * Radius;

        float KSquared = new Vector3D(Center, ray.Position).DotProductWith(new Vector3D(Center, ray.Position));

        float a = Ray3DDirSquared;
        float b = 2 * ray.Direction.DotProductWith(new Vector3D(Center, ray.Position));
        float c = KSquared - RadiusSquared;
        var D = b * b - 4 * a * c;

        if (D < 0)
        {
            return false;
        }

        return true;
    }
    public Ray3D GetIntersectionWith(Ray3D ray)
    {
        throw new NotImplementedException();
    }  
}