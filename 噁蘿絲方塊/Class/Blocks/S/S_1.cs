namespace 噁蘿絲方塊.Class
{
    class S_1 : Block
    {
        public S_1() : base()
        {
            ReSetX();

            value = 4;

            tipBlock = new s_1(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x + 1, y) && CheckDown(x - 1, y + 1) && CheckDown(x, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x - 1, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 1, y) && CheckRight(x, y + 1);
        }

        public override void Rotate()
        {
            if (y < board.GetLength(1) - 2 &&
                board[x + 1, y + 1] <= 0 && board[x + 1, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new S_2();

                Block block = Form1.fallingBlock;

                block.x = x;
                block.y = y;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x + 1, y, value);
            SetValue(x - 1, y + 1, value);
            SetValue(x, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}