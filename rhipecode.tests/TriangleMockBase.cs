using Moq;
using rhipecode.common.Interfaces.Engine;

namespace rhipecode.tests
{
    public class TriangleMockBase
    {
        public Mock<ITriangularFactory> engineTriangularFactoryMoq;
        public Mock<IEquilateral> engineEquilateralMoq;
        public Mock<IIsosceles> engineIIsoscelesMoq;
        public Mock<IScalene> engineIScaleneMoq;
        public Mock<ITriangleHelper> triangleHelperMoq;

        public TriangleMockBase()
        {
            engineTriangularFactoryMoq=new Mock<ITriangularFactory>();
            engineEquilateralMoq=new Mock<IEquilateral>();
            engineIIsoscelesMoq=new Mock<IIsosceles>();
            engineIScaleneMoq=new Mock<IScalene>();
            triangleHelperMoq=new Mock<ITriangleHelper>();
            
        }
    }
}