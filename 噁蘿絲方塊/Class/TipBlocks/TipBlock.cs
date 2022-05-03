using System.Drawing;
using System.Windows.Forms;

namespace 噁蘿絲方塊.Class
{
    public class TipBlock
    {
        public int x, y;

        protected int size;

        protected Image blockImages;

        public Block block;

        public TipBlock(Block block)
        {
            this.block = block;

            size = 200;
        }

        public virtual void Show(PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.FillRectangle(new SolidBrush(Color.Black), x, y, size, size);
        }
    }
}