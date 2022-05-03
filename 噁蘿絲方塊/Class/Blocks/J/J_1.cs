namespace 噁蘿絲方塊.Class
{
    class J_1 : Block
    {
        public J_1() : base()
        {
            ReSetX();

            value = 6;

            tipBlock = new j_1(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y + 1) && CheckDown(x + 1, y + 1) && CheckDown(x + 2, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x + 2, y + 1);
        }

        public override void Rotate()
        {
            if (y < board.GetLength(1) - 2 &&
                board[x + 1, y] <= 0 && board[x + 2, y] <= 0 && board[x + 1, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new J_2();

                Block block = Form1.fallingBlock;

                block.x = x + 1;
                block.y = y;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x, y + 1, value);
            SetValue(x + 1, y + 1, value);
            SetValue(x + 2, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}