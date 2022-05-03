using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    public class Board
    {
        int x, y, w, h;

        int blockSize;

        public int[,] blockBoard;

        Image[] blockImages;

        Color[] colors;

        public Board()
        {
            x = 30;
            w = 350;
            h = 700;
            y = Form1.windowsHeight / 2 - h / 2;

            blockSize = 35;

            blockBoard = new int[10, 20];

            Clear();

            blockImages = new Image[7];

            for (int i = 0; i < blockImages.Length; i++)
            {
                blockImages[i] = Image.FromFile("image\\" + (i + 1) + ".png");
                blockImages[i] = new Bitmap(blockImages[i], new Size(blockSize, blockSize));
            }

            colors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Lime, Color.Cyan, Color.Blue, Color.Magenta };
        }

        public void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.FillRectangle(new SolidBrush(Color.Black), x, y, w, h);

            for (int i = 0; i < blockBoard.GetLength(0); i++)
                for (int j = 0; j < blockBoard.GetLength(1); j++)
                    if (blockBoard[i, j] > 0)
                    {
                        G.DrawImage(blockImages[blockBoard[i, j] - 1], x + i * blockSize, y + j * blockSize);
                        G.DrawRectangle(new Pen(colors[blockBoard[i, j] - 1]), x + i * blockSize, y + j * blockSize, blockSize, blockSize);
                    }
                    else if (blockBoard[i, j] < 0)
                        G.DrawRectangle(new Pen(colors[blockBoard[i, j] * -1 - 1]), x + i * blockSize + 2, y + j * blockSize + 2, blockSize - 4, blockSize - 4);
        }

        public void Eliminate()
        {
            for (int i = 0; i < blockBoard.GetLength(1); i++)
            {
                int count = 0;
                
                for (int j = 0; j < blockBoard.GetLength(0); j++)
                    if (blockBoard[j, i] > 0)
                        count++;

                if (count == blockBoard.GetLength(0))
                {
                    Drop(i);

                    Form1.score++;
                }
            }
        }

        void Drop(int y)
        {
            for (int i = y; i > 0; i--)
                for (int j = 0; j < blockBoard.GetLength(0); j++)
                    blockBoard[j, i] = blockBoard[j, i - 1];

            for (int i = 0; i < blockBoard.GetLength(0); i++)
                blockBoard[i, 0] = 0;
        }

        public void Clear()
        {
            for (int i = 0; i < blockBoard.GetLength(0); i++)
                for (int j = 0; j < blockBoard.GetLength(1); j++)
                    blockBoard[i, j] = 0;
        }
    }
}