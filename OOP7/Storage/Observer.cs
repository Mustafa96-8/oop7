using System;
using System.Drawing;
using System.Windows.Forms;


namespace OOP7
{
    interface IObserver
    {
        bool collision(Base p, Mylist mylist);
        void toSlime(bool value);

        void move(int x_, int y_, int width, int height, Mylist mylist);
    }
    public class Observer
    {
        Mylist glbList;

        public void toSlime(bool value, Mylist mylist)
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                Base p = mylist.getObj(i);
                if (p.getCode() == 'L')
                {
                    toSlime(value, (Mylist)p);
                }
                else if (p.getSelect())
                {
                    p.setSlime(value);
                }
            }
        }

        public void setMyList(Mylist list)
        {
            glbList = list;
        }

        public void moveisslime(Base p, int x_, int y_, int width, int height, Mylist mylist)//Lollolo
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() != 'L')
                {
                    if (collision(p, mylist.getObj(i)))
                    {
                        if (!canMoveNearSlime(mylist.getObj(i), x_, y_, width, height, mylist))
                        {
                            p.x -= x_;
                            p.y -= y_;
                            return;
                        }
                    }
                }
            }
            for (int i = 0; i < mylist.getSize(); i++)
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

        public bool canMoveNearSlime(Base p, int x_, int y_, int width, int height, Mylist mylist)
        {
            //p - слайм
            bool flag = true;
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    flag = canMoveNearSlime(p, x_, y_, width, height, ((Mylist)mylist.getObj(i)));
                    if (!flag) break;
                }
                else if (!(mylist.getObj(i).getSlime()))
                {
                    if (!((p.x + p.sizecollision / 2 < width) && (p.y + p.sizecollision < height) && (p.x - p.sizecollision / 2 > 0) && (p.y - p.sizecollision / 2 > 0)))
                    {
                        flag = false;
                        break;
                    }
                    p.x += x_;
                    p.y += y_;
                    flag = !collision(p, mylist.getObj(i));
                    p.x -= x_;
                    p.y -= y_;
                    if (!flag) break;
                }
            }
            return flag;//Почти сделали попробуй запустить
        }


        public bool collision(Base p1, Base p2)// Проверяет на коллизию объект 
        {
            float size1 = p1.sizecollision / 2 +2;
            PointF leftup = new PointF(p1.x - size1, p1.y - size1);
            PointF rightup = new PointF(p1.x + size1, p1.y - size1);
            PointF leftdn = new PointF(p1.x - size1, p1.y + size1);
            PointF rightdn = new PointF(p1.x + size1, p1.y + size1);

            //p2 это объект из листа по индексу
            if (p2 != p1)
            {
                float size = p2.sizecollision / 2 +2;
                if (((p2.x + size) >= leftup.X) && ((p2.y + size) >= leftup.Y) &&
                    ((p2.x - size) <= rightup.X) && ((p2.y + size) >= rightup.Y) &&
                    ((p2.x + size) >= leftdn.X) && ((p2.y - size) <= leftdn.Y) &&
                    ((p2.x - size) <= rightdn.X) && ((p2.y - size) <= rightdn.Y))
                {
                    return true;
                }
            }

            return false;
        }
    }
}