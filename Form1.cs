
using System.Reflection.Metadata;

namespace BreakoutGameLab001
{
    public partial class Form1 : Form
    {
        // �C�����O���
        CustomizedPanel gamePanel;
        //
        public Form1()
        {
            InitializeComponent();

            // TODO : �i��C����l��
            InitializeGame();
        }

        private void InitializeGame()
        {
            // ���� ���ե� panel2 ���
            Controls.Remove( panel2 );
            //
            gamePanel = new CustomizedPanel( panel2.Width, panel2.Height);
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new Point(0, 61);
            gamePanel.Name = "BrickoutGamePanel";
            gamePanel.Size = new Size(panel2.Width, panel2.Height);
            gamePanel.TabIndex = 1;
            //
            gamePanel.Initialize();
            //
            Controls.Add(gamePanel);
            //
        }
    }
}
