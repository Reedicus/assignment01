using System.Drawing;

namespace assignment02
{
    public class EnactSprite : Sprite
    {
        int a;
        private Bitmap image;
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        public override void act()
        {
            base.act();
            if (a % 100 > 50)
            {
                this.X++;
                this.Y++;
            }

            else
            {
                this.X--;
                this.Y--;
            }
            a++;

            //THIS IS WHERE YOU MAKE IT DO THINGS
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(image, 0, 0);
        }
    }
}