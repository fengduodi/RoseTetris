using System;
using System.Drawing;
using System.Windows.Forms;
using 噁蘿絲方塊.Class;

namespace 噁蘿絲方塊
{
    public partial class Form1 : Form
    {
        int bias;
        public static int windowsWidth, windowsHeight;

        public static Board board;

        public static Block fallingBlock;

        static TipBoard nextBlock, holdBlock;

        public static bool canReplace;

        Timer fallingTimer;

        public static bool gameOver;

        public static int score;

        public Form1()
        {
            InitializeComponent();

            Size = new Size(700, 800);

            bias = 15;
            windowsWidth = Width - bias;
            windowsHeight = Height - SystemInformation.ToolWindowCaptionHeight - bias;

            board = new Board();

            nextBlock = new TipBoard(80, "NEXT");
            holdBlock = new TipBoard(350, "HOLD");

            Setting();

            fallingTimer = new Timer();
            fallingTimer.Interval = 500;
            fallingTimer.Tick += new EventHandler(Falling);
            fallingTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            board.Show(e);

            nextBlock.Show(e);
            holdBlock.Show(e);
        }

        void Falling(object sender, EventArgs e)
        {
            if (gameOver)
            {
                fallingTimer.Stop();

                DialogResult dialogResult = MessageBox.Show("總消除列數：" + score.ToString() + "\n\n再玩一次？",
                                                            "遊戲結束",
                                                            MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Setting();

                    fallingTimer.Start();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }

            fallingBlock.Falling();

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameOver)
            {
                if (e.KeyCode == Keys.Left)
                    fallingBlock.GoLeft();

                if (e.KeyCode == Keys.Right)
                    fallingBlock.GoRight();

                if (e.KeyCode == Keys.Down)
                    fallingBlock.Falling();

                if (e.KeyCode == Keys.Up)
                    fallingBlock.Rotate();

                if (e.KeyCode == Keys.Space)
                    fallingBlock.Setting();

                if (e.KeyCode == Keys.ControlKey && canReplace)
                {
                    canReplace = false;

                    TipBlock temp = fallingBlock.tipBlock;

                    fallingBlock.SetBoard(0);

                    if (holdBlock.tipBlock.block != null)
                    {
                        fallingBlock = holdBlock.tipBlock.block;

                        fallingBlock.ReSetX();
                        fallingBlock.y = 0;

                        fallingBlock.SetBoard(fallingBlock.value);
                    }
                    else
                        SetNewBlock();

                    holdBlock.SetTipBlock(temp);
                }

                Invalidate();
            }
        }

        public static Block GetNewBlock()
        {
            Block[] blocks = new Block[] { new I_1(), new I_2(),
                                           new J_1(), new J_2(), new J_3(), new J_4(),
                                           new L_1(), new L_2(), new L_3(), new L_4(),
                                           new O(),
                                           new S_1(), new S_2(),
                                           new T_1(), new T_2(), new T_3(), new T_4(),
                                           new Z_1(), new Z_2() };

            Random random = new Random();
            int i = random.Next(0, blocks.Length);

            return blocks[i];
        }

        public static void SetNewBlock()
        {
            fallingBlock = nextBlock.tipBlock.block;
            fallingBlock.SetBoard(fallingBlock.value);

            nextBlock.SetTipBlock(GetNewBlock().tipBlock);
        }

        void Setting()
        {
            board.Clear();

            fallingBlock = GetNewBlock();
            fallingBlock.SetBoard(fallingBlock.value);

            nextBlock.SetTipBlock(GetNewBlock().tipBlock);
            holdBlock.SetTipBlock(new TipBlock(null));

            canReplace = true;

            gameOver = false;

            score = 0;
        }
    }
}