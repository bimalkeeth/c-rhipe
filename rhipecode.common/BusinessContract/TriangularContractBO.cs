using rhipecode.common.Enums;

namespace rhipecode.common.BusinessContract
{
    public class TriangularContractBO
    {
        
        // the following formulation, is obtain from point to point distance
        //    B
        //  c/ \a
        //  /   \
        //  A----C
        //    b
        //------------------------------------------------------------------
        
        public double Height { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double a { get; set; }
        
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        
        public TriangleEnum Type { get; set; }
    }
}