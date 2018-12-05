using rhipecode.common.BusinessContract;

namespace rhipecode.common.Interfaces.Engine
{
    public interface ITriangular
    {
        Points Process(TriangularContractBO data);
    }
}