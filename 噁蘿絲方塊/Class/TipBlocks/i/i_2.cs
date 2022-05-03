using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    class i_2 : TipBlock
    {
        public i_2(Block block) : base(block)
        {
            blockImages = Image.FromFile("image\\5.png");
            blockImages = new Bitmap(blockImages, new Size(size, size));
        }

        public override void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawImage(blockImages, x, y);

            SolidBrush solidBrush = new SolidBrush(Color.Cyan);

            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 - 69, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 + 3, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 + 39, 30, 30);
        }
    }
}