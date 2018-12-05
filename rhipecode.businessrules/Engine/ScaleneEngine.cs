using System;
using System.ComponentModel.DataAnnotations;
using rhipecode.businessrules.Resource;
using rhipecode.common.BusinessContract;
using rhipecode.common.Interfaces.Engine;

namespace rhipecode.businessrules.Engine
{
    public class ScaleneEngine:IScalene
    {
        
        protected readonly ITriangleHelper _triangleHelper;
        public ScaleneEngine(ITriangleHelper triangleHelper)
        {
            _triangleHelper = triangleHelper;
        }
        
        public Points Process(TriangularContractBO data)
        {
            var pointsData = new Points();

            
            if (data.b > 0 && data.Height > 0 && data.a > 0)
            {
                var l2 = Math.Sqrt(Math.Pow(data.a, 2) - Math.Pow(data.Height, 2));
                if (data.b < l2 )
                {
                    throw new ValidationException(ValidationMessages.ExceptionInvalidScaleneEngineTriangle);
                }
                var l1 = data.b - l2;
                data.c = Math.Sqrt(Math.Pow(l1, 2) + Math.Pow(data.Height, 2));
                
                if (data.Height > data.a || data.Height > data.c)
                {
                    throw new ValidationException(ValidationMessages.ExceptionInvalidScaleneEngineTriangle);
                }
                if (!_triangleHelper.IsTrianglePossible(data.a, data.b,data.c))
                {
                    throw new ValidationException(ValidationMessages.ExceptionInvalidScaleneEngineTriangle);
                }
                pointsData.PointA = new Point2D(0.0, 1.0);
                pointsData.PointB = new Point2D(pointsData.PointA.X + (l1), pointsData.PointA.Y + data.Height);
                pointsData.PointC = new Point2D(pointsData.PointA.X+data.b,pointsData.PointA.Y); 
            }
            else
            {
                throw new ValidationException(ValidationMessages.ExceptionInvalidScaleneEngineTriangle);
            }
            return pointsData;
            
          
        }
    }
}