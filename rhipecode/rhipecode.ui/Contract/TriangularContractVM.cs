using rhipecode.common.Enums;

namespace rhipecode.ui.Contract
{
    public class TriangularContractVM
    {
        public double Height { get; set; }
        public double Base { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public TriangleEnum Type { get; set; }
    }
}