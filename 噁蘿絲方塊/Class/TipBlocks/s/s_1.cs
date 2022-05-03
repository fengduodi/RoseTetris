using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    class s_1 : TipBlock
    {
        public s_1(Block block) : base(block)
        {
            blockImages = Image.FromFile("image\\4.png");
            blockImages = new Bitmap(blockImages, new Size(size, size));
        }

        public override void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.DrawImage(blockImages, x, y);

            SolidBrush solidBrush = new SolidBrush(Color.Lime);

            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 + 21, y + size / 2 - 33, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 15, y + size / 2 + 3, 30, 30);
            G.FillRectangle(solidBrush, x + size / 2 - 51, y + size / 2 + 3, 30, 30);
        }
    }
}