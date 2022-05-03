namespace 噁蘿絲方塊.Class
{
    class L_4 : Block
    {
        public L_4() : base()
        {
            ReSetX();

            value = 2;

            tipBlock = new l_4(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y) && CheckDown(x + 1, y + 2);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x + 1, y + 1) && CheckLeft(x + 1, y + 2);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 1, y) && CheckRight(x + 1, y + 1) && CheckRight(x + 1, y + 2);
        }

        public override void Rotate()
        {
            if (x < board.GetLength(0) - 2 &&
                board[x + 2, y] <= 0 && board[x, y + 1] <= 0 && board[x + 2, y + 1] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new L_1();

                Block block = Form1.fallingBlock;

                block.x = x + 2;
                block.y = y;
                block.SetBoard(block.value);
            }
        }

        public override void SetBoard(int value)
        {
            base.SetBoard(value);

            SetValue(x, y, value);
            SetValue(x + 1, y, value);
            SetValue(x + 1, y + 1, value);
            SetValue(x + 1, y + 2, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}