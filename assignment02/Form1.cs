
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace assignment02
{
    public partial class Form1 : Form
    {
        public static EnactSprite Sprite = new EnactSprite();
        public static Form form;
        public static Thread thread;
        public static Graphics norm;
        public static int fps = 30;
        public static double running_fps = 30.0;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            Sprite.Image = assignment02.Properties.Resources.BackGround;
            thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            thread.Abort();
        }

        public static void Update()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
                Console.WriteLine(running_fps);
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime - diff).Milliseconds);
                last = DateTime.Now;
                form.Invoke(new MethodInvoker(form.Refresh));
                Sprite.act();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Sprite.render(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}

