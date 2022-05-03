using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    public class TipBoard
    {
        int x, y, size;

        string text;

        public TipBlock tipBlock;

        public TipBoard(int y, string text)
        {
            this.y = y;
            size = 200;
            x = Form1.windowsWidth - size - 50;

            this.text = text;
        }

        public void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawString(text, new Font("微軟正黑體", 20, FontStyle.Bold), new SolidBrush(Color.White), x - 10, y - 40);

            tipBlock.Show(e);
        }

        public void SetTipBlock(TipBlock tipBlock)
        {
            this.tipBlock = tipBlock;

            this.tipBlock.x = x;
            this.tipBlock.y = y;
        }
    }
}