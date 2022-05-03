namespace 噁蘿絲方塊.Class
{
    class J_3 : Block
    {
        public J_3() : base()
        {
            ReSetX();

            value = 6;

            tipBlock = new j_3(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y) && CheckDown(x + 1, y) && CheckDown(x + 2, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x + 2, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 2, y) && CheckRight(x + 2, y + 1);
        }

        public override void Rotate()
        {
            if (y > 0 &&
                board[x + 1, y - 1] <= 0 && board[x, y + 1] <= 0 && board[x + 1, y + 1] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new J_4();

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
            SetValue(x + 2, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 3;
        }
    }
}