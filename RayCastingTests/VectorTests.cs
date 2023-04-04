using FluentAssertions;
using System.Numerics;
using Xunit;

namespace RayCastingTests
{
    public class VectorTests
    {
        [Fact]
        public void CrossProduct()
        {
            var vector1 = new Vector3D(1, 3, 5);
            var vector2 = new Vector3D(2, 4, 6);

            var result = vector1.CrossProductWith(vector2);
            var exepcted = new Vector3D(-2, 4, -2);

            result.Should().BeEquivalentTo(exepcted);
        }
        [Fact]
        public void DotProduct()
        {
            var vector1 = new Vector3D(7, 5, 3);
            var vector2 = new Vector3D(6, 4, 2);

            var result = vector1.DotProductWith(vector2);

            Assert.Equal(68, result);
        }
        [Fact]
        public void CosineWith() 
        {
            var vector1 = new Vector3D(12, 10, 8);
            var vector2 = new Vector3D(9, 11, 13);

            var result = vector1.CosineWith(vector2);

            if ((Math.Abs(result - 0.9525626715469696) > 10e-6))
            {
                throw new Exception();
            }
        }
    }
}