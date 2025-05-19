using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace BreakoutGameLab001
{
    class CustomizedPanel : Panel
    {
        // 球的座標 x, y 
        private int x = 100;
        private int y = 100;
        // 球的移動速度
        private int speedX = 5;
        private int speedY = 5;

        // 定義 Timer 控制項
        private Timer timer = new Timer();

        public CustomizedPanel(int width, int height)
        { 
            // this.DoubleBuffered = true;
            this.BackColor = Color.Yellow; 
            this.Size = new Size(width, height);
            //
            Initialize();
            //
            this.DoubleBuffered = true;
        }
        //
        public void Initialize() { 
            // Timer : 每 20 毫秒觸發一次 Timer_Tick 事件 ==> 更新遊戲畫面
            // 也可以利用 Thread 類別來實現 類似的功能!!
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 更新遊戲狀態
            // 移動球的位置, 檢查碰撞事件 ...
            this.x = this.x + speedX;
            this.y += speedY;
            // 檢查邊界
            if (this.x < 0 || this.x > this.Width - 50)
            {
                speedX = -speedX;
            }
            if (this.y < 0 || this.y > this.Height - 50)
            {
                speedY = -speedY;
            }

            // 要求遊戲畫面重繪
            Invalidate(); // --> 觸發 OnPaint 事件
            //
        }

        // 處理畫面的重繪事件
        protected override void OnPaint(PaintEventArgs e)
        {
            // 呼叫基底類別的 OnPaint 方法 --> 這樣才能正確繪製 Panel 控制項
            base.OnPaint(e);

            // 取得 Graphics 物件
            Graphics gr = e.Graphics;

            // 繪製遊戲畫面
            gr.FillEllipse(new SolidBrush(Color.Red), x, y, 50, 50);
            
        }
    }
}
