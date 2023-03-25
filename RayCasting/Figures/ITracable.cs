public interface ITracable
{
    public bool IsIntersectingWith(Ray3D ray);
    public Ray3D GetIntersectionWith(Ray3D ray);
}