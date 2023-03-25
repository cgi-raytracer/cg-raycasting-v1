public interface ITracable
{
    public bool IsIntersectingWith(Ray3D ray);
    public Point3D? GetIntersectionWith(Ray3D ray);

    public Ray3D? GetNormalAtPointWith(Ray3D ray);
}