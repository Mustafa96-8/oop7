using System;
using System.Drawing;


namespace OOP7
{
    interface IObserver
    {
        bool collision(Base p, Mylist mylist);
    }
    public class Observer
    {
        public bool collision(Base p, Mylist mylist)
        {
            if (p.getCode() == 'L') 
            {
                return false;
            }
            Point leftup = new Point(p.x - p.sizecollision / 2, p.y - p.sizecollision / 2);
            Point rightup = new Point(p.x + p.sizecollision / 2, p.y - p.sizecollision / 2);
            Point leftdn = new Point(p.x - p.sizecollision / 2, p.y + p.sizecollision / 2);
            Point rightdn = new Point(p.x + p.sizecollision / 2, p.y + p.sizecollision / 2);

            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i) != p)
                {
                    float size = mylist.getObj(i).sizecollision / 2;
                    if (((mylist.getObj(i).x + size) >= leftup.X) && ((mylist.getObj(i).y + size) >= leftup.Y) && 
                        ((mylist.getObj(i).x - size) <= rightup.X)&& ((mylist.getObj(i).y + size) >= rightup.Y) &&
                        ((mylist.getObj(i).x + size) >= leftdn.X)&& ((mylist.getObj(i).y - size) <= leftdn.Y) &&
                        ((mylist.getObj(i).x - size) <= rightdn.X)&& ((mylist.getObj(i).y - size) <= rightdn.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
