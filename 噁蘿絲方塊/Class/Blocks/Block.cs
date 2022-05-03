namespace 噁蘿絲方塊.Class
{
    public class Block
    {
        public int x, y;

        public int value;

        protected int[,] board;

        public TipBlock tipBlock;

        public Block()
        {
            y = 0;

            board = Form1.board.blockBoard;
        }

        public void Falling()
        {
            if (CanGoDown())
            {
                SetBoard(0);

                y++;

                SetBoard(value);
            }
            else
            {
                Form1.board.Eliminate();

                Form1.SetNewBlock();

                Form1.canReplace = true;
            }
        }

        public void GoLeft()
        {
            if (CanGoLeft())
            {
                SetBoard(0);

                x--;

                SetBoard(value);
            }
        }

        public void GoRight()
        {
            if (CanGoRight())
            {
                SetBoard(0);

                x++;

                SetBoard(value);
            }
        }

        public virtual void Rotate() { }

        public void Setting()
        {
            SetBoard(0);

            while (CanGoDown())
                y++;

            SetBoard(value);

            Form1.board.Eliminate();

            Form1.SetNewBlock();

            Form1.canReplace = true;
        }

        protected virtual bool CanGoDown() { return true; }

        protected virtual bool CanGoLeft() { return true; }

        protected virtual bool CanGoRight() { return true; }

        protected bool CheckDown(int x, int y)
        {
            return y < board.GetLength(1) - 1 && board[x, y + 1] <= 0;
        }

        protected bool CheckLeft(int x, int y)
        {
            return x > 0 && board[x - 1, y] <= 0;
        }

        protected bool CheckRight(int x, int y)
        {
            return x < board.GetLength(0) - 1 && board[x + 1, y] <= 0;
        }

        public virtual void SetBoard(int value)
        {
            if (value > 0)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                    for (int j = 0; j < board.GetLength(1); j++)
                        if (board[i, j] < 0)
                            board[i, j] = 0;

                int temp = y;

                while (CanGoDown())
                    y++;

                SetBoard(-value);

                y = temp;
            }
        }

        protected void SetValue(int x, int y, int value)
        {
            if (board[x, y] > 0 && value != 0)
                Form1.gameOver = true;

            board[x, y] = value;
        }

        public virtual void ReSetX() { }
    }
}