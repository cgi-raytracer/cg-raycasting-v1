public class Disk : ITracable
{
    public Disk(Point3D center, float radius, Ray3D normal)
    {
        Center = center;
        Radius = radius;
        Normal = normal;
    }
    public Point3D Center { get; set; }
    public float Radius { get; set; }
    public Ray3D Normal { get; set; }
    public Point3D? GetIntersectionPointWith(Ray3D ray)
    {
        Plane3D plane = new(Normal);
        
        Point3D intesectPoint = plane.GetIntersectionPointWith(ray);

        if (intesectPoint == null)
            return null;

        float distanceFromCenter = Center.GetDistance(intesectPoint);
        if (distanceFromCenter > Radius)
            return null;

        return intesectPoint;
    }

    public Ray3D? GetNormalAtPointWith(Ray3D ray)
    {
        Point3D intersectPoint = GetIntersectionPointWith(ray);

        if (intersectPoint == null)
            return null;
        return new Ray3D(intersectPoint, ray.Direction);
    }

    public bool IsIntersectingWith(Ray3D ray)
    {
        if (this.GetIntersectionPointWith(ray) is not null)
        {
            return true;
        }
        return false;
    }
}