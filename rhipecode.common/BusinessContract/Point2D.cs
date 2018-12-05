namespace rhipecode.common.BusinessContract
{
    public class Point2D
    {
        public Point2D() : this(0, 0) { }
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; private set; }
        public double Y { get; private set; }
    }
}