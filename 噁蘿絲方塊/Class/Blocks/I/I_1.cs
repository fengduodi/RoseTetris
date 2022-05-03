namespace 噁蘿絲方塊.Class
{
    class I_1 : Block
    {
        public I_1() : base()
        {
            ReSetX();

            value = 5;

            tipBlock = new i_1(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y) && CheckDown(x + 1, y) && CheckDown(x + 2, y) && CheckDown(x + 3, y);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 3, y);
        }

        public override void Rotate()
        {
            if (y > 0 && y < board.GetLength(1) - 2 &&
                board[x + 1, y - 1] <= 0 && board[x + 1, y + 1] <= 0 && board[x + 1, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new I_2();

                Block block = Form1.fallingBlock;

                block.x = x + 1;
                block.y = y - 1;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x + 1, y, value);
            SetValue(x + 2, y, value);
            SetValue(x + 3, y, value);
        }

        public override void ReSetX()
        {
            x = 3;
        }
    }
}