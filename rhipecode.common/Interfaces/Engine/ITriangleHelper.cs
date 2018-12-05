using rhipecode.common.BusinessContract;

namespace rhipecode.common.Interfaces.Engine
{
    public interface ITriangleHelper
    {
        bool IsTrianglePossible(double sideA, double sideB, double sideC);
    }
}