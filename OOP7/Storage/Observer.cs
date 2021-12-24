using System;
using System.Drawing;
using System.Windows.Forms;


namespace OOP7
{
    public class Observer
    {
        /*Mylist glbList;*/

        /*public void setMyList(Mylist list)
        {
            glbList = list;
        }*/

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

        public void moveisslime(Base p, int x_, int y_, int width, int height, Mylist mylist)//Lollolo
        {
            
            for (int i = 0; i < mylist.getSize(); i++)
            {
                Base p2 = mylist.getObj(i);
                if (p2.getCode() != 'L')
                {
                    if (collision(p, p2))
                    {
                        p2.setIsSticked(true);
                        if (!canMoveNearSlime(p2, x_, y_, width, height, mylist))
                        {
                            p.x -= x_;
                            p.y -= y_;
                            return;
                        }
                    }
                    else
                    {
                        p2.setIsSticked(false);
                    }
                }
            }
            
            for (int i = 0; i < mylist.getSize(); i++)
            {
                Base p2 = mylist.getObj(i);
                if (p2.getCode() != 'L')
                {
                    if (p2.getIsSticked())
                    {
                        p2.move(x_, y_, width, height, mylist);
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
                Base p2 = mylist.getObj(i);
                if (p2.getCode() == 'L')
                {
                    flag = canMoveNearSlime(p, x_, y_, width, height, ((Mylist)p2));
                    if (!flag) break;
                }
                else if (!p2.getSlime())
                {
                    p.x += x_;
                    p.y += y_;
                    if (!((p.x + p.sizecollision / 2 < width) && (p.y + p.sizecollision < height) && (p.x - p.sizecollision / 2 > 0) && (p.y - p.sizecollision / 2 > 0)))
                    {
                        flag = false;
                        p.x -= x_;
                        p.y -= y_;
                        break;
                    }
                    if (!p2.getIsSticked())
                    {
                        flag = !p2.collision(p);
                    }
                    p.x -= x_;
                    p.y -= y_;
                    if (!flag) break;
                    
                }
            }
            return flag;//Почти сделали попробуй запустить
        }

        public bool collision(Base p1, Base p2)// Проверяет на коллизию объект 
        {
            float size1 = p1.sizecollision / 2;
            PointF leftup = new PointF(p1.x - size1, p1.y - size1);
            PointF rightup = new PointF(p1.x + size1, p1.y - size1);
            PointF leftdn = new PointF(p1.x - size1, p1.y + size1);
            PointF rightdn = new PointF(p1.x + size1, p1.y + size1);

            //p2 это объект из листа по индексу
            if (p2 != p1)
            {
                float size = p2.sizecollision / 2;
                if (((p2.x + size) > leftup.X) && ((p2.y + size) > leftup.Y) &&
                    ((p2.x - size) < rightup.X) && ((p2.y + size) > rightup.Y) &&
                    ((p2.x + size) > leftdn.X) && ((p2.y - size) < leftdn.Y) &&
                    ((p2.x - size) < rightdn.X) && ((p2.y - size) < rightdn.Y))
                {
                    return true;
                }
            }

            return false;
        }
    }
}