using TraceOptimizer.Geometry;
using Xunit;

namespace TraceOptimizer.Tests
{
    public class OctoTreeTests
    {
        [Fact]
        public void ShouldAddOnePointCorrectly()
        {
            var tree = OctoTree.OctoTree<bool>.Create(2);

            var result = tree.AddNode(new Point3D(0, 0, 0), true);

            Assert.True(result);
        }

        [Fact]
        public void ShouldAddTwoPointsCorrectly()
        {
            var tree = OctoTree.OctoTree<bool>.Create(2);
            tree.AddNode(new Point3D(0, 0, 0), true);

            var result = tree.AddNode(new Point3D(0, 1, 0), true);

            Assert.True(result);
        }
    }
}