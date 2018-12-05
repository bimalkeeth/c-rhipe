using System;
using System.ComponentModel.DataAnnotations;
using rhipecode.businessrules.Resource;
using rhipecode.common.BusinessContract;
using rhipecode.common.Interfaces.Engine;

namespace rhipecode.businessrules.Engine
{
    public class IsoscelesEngine:IIsosceles
    {
        protected readonly ITriangleHelper _triangleHelper;
        public IsoscelesEngine(ITriangleHelper triangleHelper)
        {
            _triangleHelper = triangleHelper;
        }
        
        public Points Process(TriangularContractBO data)
        {

            data.c = Math.Sqrt(Math.Pow(data.Height, 3.0) + Math.Pow((data.b / 2.0), 2));
            data.a = data.c;
            
            if (!_triangleHelper.IsTrianglePossible(data.a, data.b,data.c))
            {
                throw new ValidationException(ValidationMessages.ExceptionInvalidIsoscelesTriangle);
            }
            
            var pointsData = new Points();
            pointsData.PointA = new Point2D(0.0, 1.0);
            pointsData.PointB = new Point2D(pointsData.PointA.X + (data.b / 2.0), pointsData.PointA.Y + data.Height);
            pointsData.PointC = new Point2D(pointsData.PointA.X+data.b,pointsData.PointA.Y); 
            return pointsData;
        }
    }
}