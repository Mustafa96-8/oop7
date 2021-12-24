using System;
using System.Drawing;


namespace OOP7
{
    interface IObserver
    {
        bool collision(Base p, Mylist mylist);
        void toSlime(bool value,Mylist mylist);

        void move(int x_,int y_, int width, int height, Mylist mylist);
    }
    public class Observer
    {

        public void toSlime(bool value, Mylist mylist)
        {
            for(int i = 0; i < mylist.getSize(); i++)
            {
                Base p = mylist.getObj(i);
                if(p.getCode() == 'L')
                {
                    toSlime(value, (Mylist)p);
                }
                else if (p.getSelect())
                {
                    p.setSlime(value); 
                }
            }
        }

        public void moveisslime(Base p,int x_, int y_, int width, int height, Mylist mylist)
        {
            for(int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() != 'L')
                {
                    if (collision(p, mylist.getObj(i)))
                    {

                        mylist.getObj(i).move(x_, y_, width, height, mylist); 
                    }
                }
            }
        }


        public bool collision(Base p1, Base p2)// Проверяет на коллизию объект 
        {
            Point leftup = new Point(p1.x - p1.sizecollision / 2, p1.y - p1.sizecollision / 2);
            Point rightup = new Point(p1.x + p1.sizecollision / 2, p1.y - p1.sizecollision / 2);
            Point leftdn = new Point(p1.x - p1.sizecollision / 2, p1.y + p1.sizecollision / 2);
            Point rightdn = new Point(p1.x + p1.sizecollision / 2, p1.y + p1.sizecollision / 2);

            //p2 это объект из листа по индексу
            if (p2 != p1)
            {
                float size = p2.sizecollision / 2;
                if (((p2.x + size) >= leftup.X) && ((p2.y + size) >= leftup.Y) && 
                    ((p2.x - size) <= rightup.X)&& ((p2.y + size) >= rightup.Y) &&
                    ((p2.x + size) >= leftdn.X)&& ((p2.y - size) <= leftdn.Y) &&
                    ((p2.x - size) <= rightdn.X)&& ((p2.y - size) <= rightdn.Y))
                {
                    return true;
                }
            }
            
            return false;
        }

    }
}
