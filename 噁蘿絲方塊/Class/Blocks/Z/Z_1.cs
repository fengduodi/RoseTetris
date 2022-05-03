﻿namespace 噁蘿絲方塊.Class
{
    class Z_1 : Block
    {
        public Z_1() : base()
        {
            ReSetX();

            value = 1;

            tipBlock = new z_1(this);
        }

        protected override bool CanGoDown()
        {
            return CheckDown(x, y) && CheckDown(x + 1, y + 1) && CheckDown(x + 2, y + 1);
        }

        protected override bool CanGoLeft()
        {
            return CheckLeft(x, y) && CheckLeft(x + 1, y + 1);
        }

        protected override bool CanGoRight()
        {
            return CheckRight(x + 1, y) && CheckRight(x + 2, y + 1);
        }

        public override void Rotate()
        {
            if (y < board.GetLength(1) - 2 &&
                board[x, y + 1] <= 0 && board[x, y + 2] <= 0)
            {
                SetBoard(0);

                Form1.fallingBlock = new Z_2();

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
            SetValue(x + 1, y, value);
            SetValue(x + 1, y + 1, value);
            SetValue(x + 2, y + 1, value);
        }

        public override void ReSetX()
        {
            x = 4;
        }
    }
}