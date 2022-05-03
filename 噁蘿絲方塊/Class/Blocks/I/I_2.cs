namespace 噁蘿絲方塊.Class
{
    class I_2 : Block
    {
        public I_2() : base()
        {
            ReSetX();

            value = 5;

            tipBlock = new i_2(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y + 3);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x, y + 1) && CheckLeft(x, y + 2) && CheckLeft(x, y + 3);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x, y + 1) && CheckRight(x, y + 2) && CheckRight(x, y + 3);
        }

        public override void Rotate()
        {
            if (x > 0 && x < board.GetLength(0) - 2 &&
                board[x - 1, y + 1] <= 0 && board[x + 1, y + 1] <= 0 && board[x + 2, y + 1] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new I_1();

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
            SetValue(x, y + 3, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}