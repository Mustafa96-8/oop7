using System;
using System.Drawing;


namespace OOP7
{
    public class Base
    {
        protected Pen mainpen;
        protected Pen redpen;
        protected Pen goldpen;
        public int x, y;
        protected bool Selected = false;
        protected Brush br = Brushes.White;
        protected string color = "White";
        public virtual void initcomp()
        {
            mainpen = new Pen(Color.Black);
            mainpen.Width = 1;
            redpen = new Pen(Color.Red);
            redpen.Width = 1;
        }

        public virtual void init(Base copy)
        {
            x = copy.x;
            y = copy.y;
            br = copy.br;
            Selected = copy.Selected;
            color = copy.color;
        }

        public virtual void setmainpen(string pen)
        {
            mainpen = new Pen(Color.FromName(pen));
        }
		public virtual char getCode()
        {
            return 'B';
        }
        public virtual bool isClick(int x, int y, bool isCtrl, Mylist mylist) 
        {
            return true;
        }
        public virtual void setBrush(string color)///Blue/Brown/Yellow/Green/Purple/Red/White
        {
            br = new SolidBrush(Color.FromName(color));
            this.color = color;
        }
        public virtual void setSelect(bool value)
        {
            Selected = value;
        }
        public virtual bool getSelect()
        {
            return Selected;
        }
        public virtual void print(Graphics gr)
        {

        }

        public virtual bool canMove(int x_, int y_, int width, int height, Mylist mylist)
        {
            return false;
        }
        public virtual void move(int x_, int y_,  int width, int height,Mylist mylist)
        {
        }

        public virtual bool canScaled(int size, int width, int height, Mylist mylist)
        {
            return false;
        }
        public virtual void changesize(int size, int width, int height, Mylist mylist)
        {
        }
        public virtual void refreshSelected(Mylist mylist)
        {
            for (int j = 0; j < mylist.getSize(); j++)
            {
                mylist.getObj(j).Selected = false;
            }
        }
        public virtual void toSelect(bool isCTRL, Mylist mylist)
        {
            if (!isCTRL)
            {
                mylist.refreshSelected(mylist);
            }
            setSelect(true);
        }
        public virtual void deleteSelected(Mylist list)
        {
            if (Selected) list.deleteObj(this);
        }
        public virtual void save(string path)
        {

        }
        public virtual void load(string path, string[] tmp)
        {

        }
    }
    class MyBaseFactory
	{
        public MyBaseFactory() { }
		public Base createBase(Base p)
		{
			Base _base = null;
			switch (p.getCode())
			{
                case 'C':
					_base = new Circle((Circle)p);
					break;
                case 'R':
                    _base = new Rectangle((Rectangle)p);
                    break;
                case 'S':
                    _base = new Square((Square)p);
                    break;
                case 'T':
                    _base = new Triangle((Triangle)p);
                    break;
                case 'L':
                    _base = new Mylist((Mylist)p);
                    break;
                default:
                    break;
			}
			return _base;
		}
        public Base createBase(char code)
        {
            Base _base = null;
            switch (code)
            {
                case 'C':
                    _base = new Circle();
                    break;
                case 'R':
                    _base = new Rectangle();
                    break;
                case 'S':
                    _base = new Square();
                    break;
                case 'T':
                    _base = new Triangle();
                    break;
                case 'L':
                    _base = new Mylist();
                    break;
                default:
                    break;
            }
            return _base;
        }
    }

};
