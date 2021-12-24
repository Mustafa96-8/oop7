using System;
using System.Drawing;
using System.IO;

namespace OOP7
{

    public class Circle : Base
    {
        private int R;

        public override char getCode()
        {
            return 'C';
        }
        public override void initcomp()
        {
            base.initcomp();
            R = 20;
            sizecollision = R;
        }
        public Circle()
        {
            initcomp();
        }
        public Circle(int x, int y, Mylist mylist, int width, int height)
        {

            initcomp();
            if (((x + R < width) && (y + R < height) && (x - R > 0) && (y - R > 0)))//Проверяем не уйдёт ли часть объекта за рамки если есть место для объекта создаём
            {
                this.x = x;
                this.y = y;
                mylist.refreshSelected(mylist);
                Selected = true;
                mylist.add(this);
            }
        }
        public Circle(Circle copy)
        {
            initcomp();
            init(copy);
            R = copy.R;
        }
        
        public override bool isClick(int x,int y, bool isCtrl, Mylist mylist)
        {
            double tmp = Math.Pow(this.x-x, 2) + Math.Pow(this.y - y, 2);
            if (tmp < (R * R))
            {
                toSelect(isCtrl, mylist);
                return true;
            }
            return false;
        }
        
        
        public void drawCircle(Graphics gr)//Вывод просто вершины(круга)
        {
            gr.FillEllipse(br, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(mainpen, (x - R), (y - R), 2 * R, 2 * R);
        }
        
        public void drawSelectedVert(Graphics gr)//Внутренний вывод выбранной
        {
            gr.DrawEllipse(redpen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public override void print(Graphics gr)//Вывод круга
        {
            drawCircle(gr);
            if (Selected)
            {
                drawSelectedVert(gr);
            }
        }

        public override bool canMove(int x_, int y_, int width, int height, Mylist mylist)
        {
            return ((x + x_ + R < width) && (y + y_ + R < height) && (x + x_ - R > 0) && (y + y_ - R > 0));//Проверяем не выйдем ли мы за границу Бокса
        }

        public override bool canScaled(int size, int width, int height, Mylist mylist)
        {
            return ((R + size > 5) && (x + R + size < width-5) && (y + size + R < height-5) && (x - size - R > 5) && (y - size - R > 5));
        }
        public override void changesize(int size, int width, int height)
        {
            R += size;
            sizecollision = R;
        }
        public override void save(string path)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("{0} {1} {2} {3} {4}", getCode(),x,y,color,R);
            writer.Close();
        }

        public override void load(string path, string[] tmp)
        {
            x = Int32.Parse(tmp[1]);
            y = Int32.Parse(tmp[2]);
            setBrush(tmp[3]);
            R = Int32.Parse(tmp[4]);
        }
    }
}
