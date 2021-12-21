using System;
using System.Drawing;


namespace OOP7
{
    public class Square : Base
    {
        private int a;

        public override char getCode()
        {
            return 'S';
        }

        public override void initcomp()
        {
            base.initcomp();
            a = 25;
        }

        public Square(int x, int y, Mylist mylist, int width, int height)
        {

            initcomp();
            if ((x + a / 2 < width) && (y + a / 2 < height) && (x - a / 2 > 0) && (y - a / 2 > 0))//если есть место для объекта создаём
            {
                this.x = x;
                this.y = y;
                refreshSelected(mylist);
                Selected = true;
                mylist.add(this);
            }
        }

        public Square(Square copy)
        {
            initcomp();
            x = copy.x;
            y = copy.y;
            a = copy.a;
            Selected = copy.Selected;
        }

        public override bool isClick(int x, int y, bool isCtrl, Mylist mylist)
        {
            if ((x > (this.x - (a / 2))) && (x < (this.x + (a / 2))) && (y > (this.y - (a / 2))) && (y < (this.y + (a / 2))))
            {
                toSelect(isCtrl, mylist);
                return true;
            }
            return false;
        }

        public void drawRectangle(Graphics gr)
        {
            gr.FillRectangle(br, x - a / 2, y - a / 2, a, a);
            gr.DrawRectangle(mainpen, x - a / 2, y - a / 2, a, a);
        }
        public void drawSelectedRectangle(Graphics gr)
        {
            gr.DrawRectangle(redpen, x - a / 2, y - a / 2, a, a);
        }
        public override void print(Graphics gr)
        {
            drawRectangle(gr);
            if (Selected)
            {
                drawSelectedRectangle(gr);
            }
        }
        public override bool canMove(int x_, int y_, int width, int height, Mylist mylist)
        {
            return ((x + a / 2 + x_ < width - 5) && (y + a / 2 + y_ < height - 5) && (x - a / 2 + x_ > 5) && (y - a / 2 + y_  > 5));
        }
        public override void move(int x_, int y_, int width, int height, Mylist mylist)
        {
            x += x_;
            y += y_;
        }
        public override bool canScaled(int size, int width, int height, Mylist mylist)
        {
            return ((a + size > 6) && (x + a / 2 + size  < width-5) && (y + a / 2 + size  < height-5) && (x - a / 2 - size  > 5) && (y - a / 2 - size > 5));
        }
        public override void changesize(int size, int width, int height, Mylist mylist)
        {
            a += size * 2;
        }



    }
}
