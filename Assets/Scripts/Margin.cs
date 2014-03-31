namespace Assets.Scripts
{
    public class Margin
    {
        public float Top;
        public float Bottom;
        public float Left;
        public float Right;

        public Margin()
        {
            Left = 0;
            Top = 0;
            Right = 0;
            Bottom = 0;
        }

        public Margin(float left, float top, float right, float bottm)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottm;
        }
    }
}