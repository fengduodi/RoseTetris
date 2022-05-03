namespace 噁蘿絲方塊.Class
{
    class L_2 : Block
    {
        public L_2() : base()
        {
            ReSetX();

            value = 2;

            tipBlock = new l_2(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y + 2) && CheckDown(x + 1, y + 2);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x, y + 1) && CheckLeft(x, y + 2);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x, y + 1) && CheckRight(x + 1, y + 2);
        }

        public override void Rotate()
        {
            if (x > 0 &&
                board[x - 1, y + 1] <= 0 && board[x + 1, y + 1] <= 0 && board[x - 1, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new L_3();

                Block block = Form1.fallingBlock;

                block.x = x - 1;
                block.y = y + 1;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x, y + 1, value);
            SetValue(x, y + 2, value);
            SetValue(x + 1, y + 2, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}