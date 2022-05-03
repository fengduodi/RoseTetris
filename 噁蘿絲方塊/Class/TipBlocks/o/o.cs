using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    class o : TipBlock
    {
        public o(Block block) : base(block)
        {
            blockImages = Image.FromFile("image\\3.png");
            blockImages = new Bitmap(blockImages, new Size(size, size));
        }

        public override void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawImage(blockImages, x, y);

            SolidBrush solidBrush = new SolidBrush(Color.Yellow);

            G.FillRectangle(solidBrush, x + size / 2 - 33, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 + 3, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 33, y + size / 2 + 3, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 + 3, y + size / 2 + 3, 30, 30);
        }
    }
}