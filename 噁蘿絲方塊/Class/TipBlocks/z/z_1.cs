using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    class z_1 : TipBlock
    {
        public z_1(Block block) : base(block)
        {
            blockImages = Image.FromFile("image\\1.png");
            blockImages = new Bitmap(blockImages, new Size(size, size));
        }

        public override void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawImage(blockImages, x, y);

            SolidBrush solidBrush = new SolidBrush(Color.Red);

            G.FillRectangle(solidBrush, x + size / 2 - 51, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 + 3, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 + 21, y + size / 2 + 3, 30, 30);
        }
    }
}