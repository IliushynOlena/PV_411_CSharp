namespace _04_IntroToOOP
{
    partial class Point
    {
        public void setX(int newX)
        {
            if (newX >= 0)
                this.xCoord = newX;
            else
                this.xCoord = 0;
        }
        public void setY(int newY)
        {
            if (newY >= 0)
                this.yCoord = newY;
            else
                this.yCoord = 0;
        }
        public int getX() { return xCoord; }
        public int getY() { return yCoord; }
    }
}

namespace _04_IntroToOOP
{
    partial class Point
    {
        public void MovePoint(int x, int y)
        {
            XCoord += x;
            YCoord += y;
        }
    }
}
