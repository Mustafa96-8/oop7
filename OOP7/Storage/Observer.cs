using System;
using System.Drawing;


namespace OOP7
{
    interface IObserver
    {
        bool collision(Base p, Mylist mylist);
        void toSlime(bool value,Mylist mylist);
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


        public bool collision(Base p, Mylist mylist)// Проверяет на коллизию объект 
        {
            if (p.getCode() == 'L') 
            {
                //return false;
            }
            Point leftup = new Point(p.x - p.sizecollision / 2, p.y - p.sizecollision / 2);
            Point rightup = new Point(p.x + p.sizecollision / 2, p.y - p.sizecollision / 2);
            Point leftdn = new Point(p.x - p.sizecollision / 2, p.y + p.sizecollision / 2);
            Point rightdn = new Point(p.x + p.sizecollision / 2, p.y + p.sizecollision / 2);

            for (int i = 0; i < mylist.getSize(); i++)
            {
                //p2 это объект из листа по индексу
                Base p2 = mylist.getObj(i);
                if (p2 != p)
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
            }
            return false;
        }

    }
}
