namespace rhipecode.common.Interfaces.Engine
{
    public interface ITriangularFactory
    {
        ITriangular GetTriangularProcessor<T>();
    }
}