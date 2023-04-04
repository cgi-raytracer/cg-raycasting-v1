public class Plane3D : ITracable
{
    public Ray3D Normal { get; set; }

    public Plane3D(Ray3D normal)
    {
        Normal = normal;
    }
    public Point3D? GetIntersectionPointWith(Ray3D ray)
    {
        float rayNormalDotProduct = ray.Direction.DotProductWith(Normal.Direction);
        if (rayNormalDotProduct < 10e-6)
        {
            return null;
        }

        //Vector3D rayRadiusVec = new Vector3D(ray.Position.X, ray.Position.Y, ray.Position.Z);
        Vector3D planePointRadiusVec = new Vector3D(Normal.Position.X, Normal.Position.Y, Normal.Position.Z);

        float t = (planePointRadiusVec - ray.Direction).DotProductWith(Normal.Direction) / (ray.Direction.DotProductWith(Normal.Direction));

        if (t < 0)
        {
            return null;
        }

        Point3D intersectPoint = ray.Position + ray.Direction.Scale(t);
        return intersectPoint;
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