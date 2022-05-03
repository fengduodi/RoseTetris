namespace 噁蘿絲方塊.Class
{
    class T_4 : Block
    {
        public T_4() : base()
        {
            ReSetX();

            value = 7;

            tipBlock = new t_4(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x - 1, y + 1) && CheckDown(x, y + 2);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x - 1, y + 1) && CheckLeft(x, y + 2);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x, y + 1) && CheckRight(x, y + 2);
        }

        public override void Rotate()
        {
            if (x < board.GetLength(0) - 1 &&
                board[x + 1, y + 1] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new T_1();

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
            SetValue(x - 1, y + 1, value);
            SetValue(x, y + 1, value);
            SetValue(x, y + 2, value);
        }

        public override void ReSetX()
        {
            x = 5;
        }
    }
}