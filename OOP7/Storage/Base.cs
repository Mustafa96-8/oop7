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

        public virtual void initcomp()
        {
            mainpen = new Pen(Color.Black);
            mainpen.Width = 1;
            redpen = new Pen(Color.Red);
            redpen.Width = 1;
            goldpen = new Pen(Color.Gold);
        }

        public virtual void setmainpen(string pen)
        {
            switch (pen)
            {
                case "Blue":
                    mainpen = Pens.Blue;
                    break;
                case "Brown":
                    mainpen = Pens.Brown;
                    break;
                case "Yellow":
                    mainpen = Pens.Yellow;
                    break;
                case "Green":
                    mainpen = Pens.Green;
                    break;
                case "Purple":
                    mainpen = Pens.Purple;
                    break;
                case "Red":
                    mainpen = Pens.Red;
                    break;
                case "White":
                    mainpen = Pens.White;
                    break;

                default:
                    break;
            }
        }

        protected bool Selected=false;
        protected Brush br = Brushes.White;
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
            switch (color)
            {
                case "Blue":
                    br = Brushes.Blue;
                    break;
                case "Brown":
                    br = Brushes.Brown;
                    break;
                case "Yellow":
                    br = Brushes.Yellow;
                    break;
                case "Green":
                    br = Brushes.Green;
                    break;
                case "Purple":
                    br = Brushes.Purple;
                    break;
                case "Red":
                    br = Brushes.Red;
                    break;
                case "White":
                    br = Brushes.White;
                    break;

                default:
                    break;
            }
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
					_base = new CCircle((CCircle)p);
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
	}

};
