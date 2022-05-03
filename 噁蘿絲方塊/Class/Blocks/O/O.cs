namespace 噁蘿絲方塊.Class
{
    class O : Block
    {
        public O() : base()
        {
            ReSetX();

            value = 3;

            tipBlock = new o(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y + 1) && CheckDown(x + 1, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 1, y) && CheckRight(x + 1, y + 1);
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x + 1, y, value);
            SetValue(x, y + 1, value);
            SetValue(x + 1, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}