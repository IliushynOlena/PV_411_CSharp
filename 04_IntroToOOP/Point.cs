namespace _04_IntroToOOP
{
    partial class Point
    {
        private int xCoord;
        public int XCoord//(int value)
        {
            get { return xCoord; }
            set
            {
                if (value >= 0)
                    this.xCoord = value;
                else
                    this.xCoord = 0;
            }
        }
        private int yCoord;
        public int YCoord
        {
            get { return yCoord; }
            set
            {
                if (value >= 0)
                    this.yCoord = value;
                else
                    this.yCoord = 0;
            }
        }
        //propfull + Tab ---> Full property
        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        //prop + Tab ---> autoProperty
        public string Name { get; set; }
        public string Color { get; private set; } = "White";

    }
}
