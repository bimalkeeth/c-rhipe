using rhipecode.common.Interfaces.Engine;

namespace rhipecode.businessrules.Engine
{
    public class TriangularFactory:ITriangularFactory
    {
        protected readonly ITriangleHelper _triangleHelper;

        public TriangularFactory(ITriangleHelper triangleHelper)
        {
            _triangleHelper = triangleHelper;
        }
        public ITriangular GetTriangularProcessor<T>()
        {
            ITriangular triangular = null;

            if (typeof(T) == typeof(IIsosceles))
            {
              triangular=new IsoscelesEngine(_triangleHelper);   
            }
            else if (typeof(T) == typeof(IEquilateral))
            {
                triangular=new EquilateralEngine(_triangleHelper);
            }
            else if (typeof(T) == typeof(IScalene))
            {
                triangular=new ScaleneEngine(_triangleHelper);
            }
            return triangular;
        }
    }
}