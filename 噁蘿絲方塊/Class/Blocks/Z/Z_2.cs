namespace 噁蘿絲方塊.Class
{
    class Z_2 : Block
    {
        public Z_2() : base()
        {
            ReSetX();

            value = 1;

            tipBlock = new z_2(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x - 1, y + 2) && CheckDown(x, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x - 1, y + 1) && CheckLeft(x - 1, y + 2);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x, y + 1) && CheckRight(x - 1, y + 2);
        }

        public override void Rotate()
        {
            if (x < board.GetLength(0) - 1 &&
                board[x - 1, y] <= 0 && board[x + 1, y + 1] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new Z_1();

                Block block = Form1.fallingBlock;

                block.x = x - 1;
                block.y = y;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x - 1, y + 1, value);
            SetValue(x, y + 1, value);
            SetValue(x - 1, y + 2, value);
        }

        public override void ReSetX()
        {
            x = 5;
        }
    }
}