namespace 噁蘿絲方塊.Class
{
    class T_1 : Block
    {
        public T_1() : base()
        {
            ReSetX();

            value = 7;

            tipBlock = new t_1(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x - 1, y + 1) && CheckDown(x, y + 1) && CheckDown(x + 1, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x - 1, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x, y) && CheckRight(x + 1, y + 1);
        }

        public override void Rotate()
        {
            if (y < board.GetLength(1) - 2 &&
                board[x, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new T_2();

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
            SetValue(x + 1, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}