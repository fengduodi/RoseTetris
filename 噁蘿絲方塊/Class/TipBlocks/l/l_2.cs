using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    class l_2 : TipBlock
    {
        public l_2(Block block) : base(block)
        {
            blockImages = Image.FromFile("image\\2.png");
            blockImages = new Bitmap(blockImages, new Size(size, size));
        }

        public override void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawImage(blockImages, x, y);

            SolidBrush solidBrush = new SolidBrush(Color.Orange);

            G.FillRectangle(solidBrush, x + size / 2 - 33, y + size / 2 - 15, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 33, y + size / 2 - 51, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 33, y + size / 2 + 21, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 + 3, y + size / 2 + 21, 30, 30);
        }
    }
}