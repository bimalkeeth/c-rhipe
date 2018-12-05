using System;
using System.ComponentModel.DataAnnotations;
using rhipecode.businessrules.Resource;
using rhipecode.common.BusinessContract;
using rhipecode.common.Interfaces.Engine;

namespace rhipecode.businessrules.Engine
{
    public class EquilateralEngine:IEquilateral
    {
        protected readonly ITriangleHelper _triangleHelper;
        public EquilateralEngine(ITriangleHelper triangleHelper)
        {
            _triangleHelper = triangleHelper;
        }
        public Points Process(TriangularContractBO data)
        {
            data.Height = Math.Sqrt(3.0) * (data.a / 2.0);
            if (!_triangleHelper.IsTrianglePossible(data.a, data.a, data.a))
            {
                throw new ValidationException(ValidationMessages.ExceptionInvalidEquilateralTriangle);
            }
            var pointsData = new Points();
            pointsData.PointA = new Point2D(0.0, 1.0);
            pointsData.PointB = new Point2D(pointsData.PointA.X + (data.a / 2.0), pointsData.PointA.Y + data.Height);
            pointsData.PointC = new Point2D(pointsData.PointA.X+data.a,pointsData.PointA.Y); 
            return pointsData;
        }
    }
}