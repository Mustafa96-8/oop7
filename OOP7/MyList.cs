using System;
using System.Drawing;

namespace OOP7
{
    public class Mylist : Base
    {
        public Mylist() { }
        public class Node
        {
            public Base base_ = null;
            public Node next = null; //указатель на следующую ячейку списка

            public Node(Base _base)
            {
                MyBaseFactory factory = new MyBaseFactory();
                base_ = factory.createBase(_base);
            }

            public bool isEOL() { return Convert.ToBoolean(this == null ? 1 : 0); }
        };

        public void delete_first()
        {
            if (isEmpty()) return;

            Node temp = first;
            first = temp.next;
        }
        public void delete_last()
        {
            if (isEmpty()) return;
            if (last == first)
            {
                delete_first();
                return;
            }

            Node temp = first;
            while (temp.next != last)
            {
                temp = temp.next;
            }
            temp.next = null;
            last = temp;
        }

        public Node first = null;

        public Node last = null;

        public void add(Base _base)
        {
            Node another = new Node(_base);
            //("\tЭлемент добавлен в хранилище\n");

            if (isEmpty())
            {
                first = another;
                last = another;
                return;
            }
            last.next = another;
            last = another;
        }
        public bool isEmpty()
        {
            return first == null;
        }
        public void deleteObj(Base _base)
        {
            if (isEmpty())
            {
                
                return;
            }
            if (last.base_ == _base)
            {
                delete_last();
               
                return;
            }
            if (first.base_ == _base)
            {
                delete_first();
                
                return;
            }

            Node current = first;
            while (current.next != null && current.next.base_ != _base)
            {
                current = current.next;
            }
            if (current.next == null)
            {
                
                return;
            }
            Node tmp_next = current.next;
            current.next =
                current.next.next;

            
        }
        public int getSize()
        {
            if (first == null) return 0;
            Node node = first;
            int i = 1;

            while (node.next != null)
            {
                i++;
                node = node.next;
            }
            return i;
        }

        public Base getObj(int i)
        {
            if (isEmpty())
            {
               
                return null;//исправить на исключение
            }
            int j = 0;
            Node current = first;
            
            while (j < i && !(first.isEOL()))
            {
                current = current.next;
                j++;
            }
            
            return (current.base_);
        }
        public Base getObjAndDelete(int i)
        {
            if (isEmpty())
            {
                
                return null;//исправить на исключение
            }
            Base ret = getObj(i);
            Base tmp;
            MyBaseFactory factory = new MyBaseFactory();
            tmp = factory.createBase(ret);
            deleteObj(ret);
            
            return tmp;
        }

        //Реализация Визуальной части----------------------------------------------------------------------------
        //всё что выше надеюсь не тронем-------------------------------------------------------------------------
        private bool Selectonein;
        private int size;
        private int id;

        public override char getCode()
        {
            return 'L';
        }

        public override void initcomp()
        {
            Selectonein = false;
            Selected = false;
            redpen = new Pen(Color.Gold);
            redpen.Width = 1;
            size = getSize();
        }

        public void setId(int id)
        {
            this.id = id; 
        }

        public int getId()
        {
            return id;
        }

        public Mylist(Mylist list, int id)
        {
            Mylist mylist;
            mylist = IsLastList(list);
            this.id = id;
            initcomp();
            mylist.add(this);
            Mylist IsLastList(Mylist lists)
            {
                for (int i = lists.getSize()-1; i >=0;i--)
                {   
                    if (lists.getObj(i).getCode() == 'L' && ((Mylist)lists.getObj(i)).Selectonein)
                    {
                        lists = IsLastList(((Mylist)lists.getObj(i)));
                        return lists;
                    }
                    else if (lists.getObj(i).getSelect())
                    {
                        Base b = lists.getObjAndDelete(i);
                        b.setmainpen("Yellow");
                        add(b);
                    }
                }
                return lists;
            }
        }

        public Mylist(Mylist copy)
        {
            for (int i = copy.getSize() - 1; i >= 0; i--)
            {
                Base b = copy.getObjAndDelete(i);
                b.setmainpen("Yellow");
                add(b);
            }
            id = copy.id;
            initcomp();
        }

        public override void deleteSelected(Mylist list)
        {
            if (Selected)
            {
                getOut(list);
                list.deleteObj(this);
            }
        }

        public override void print(Graphics gr)
        {
            for (int i = 0; i < getSize(); i++)
            {
                getObj(i).print(gr);
            }
        }

        public override bool isClick(int x, int y, bool isCtrl, Mylist mylist)
        {
            bool flag = false;
            for (int i = 0; i < getSize(); i++)
            {
                if (getObj(i).isClick(x, y, isCtrl, mylist))
                {
                    if (getObj(i).getCode() != 'L')
                    {
                        getObj(i).toSelect(isCtrl, this);
                    }
                    Selectonein = true;
                    flag = true;
                }
            }
            return flag;
        }

        public override void refreshSelected(Mylist mylist)//ВСЁ ЗАНУЛЯЕМ
        {
            for (int i = getSize() - 1; i >=0;i--)
            {   
                if (getObj(i).getCode() == 'L') 
                {
                    ((Mylist)getObj(i)).refreshSelected((Mylist)getObj(i));
                    getObj(i).setSelect(false);
                    ((Mylist)getObj(i)).Selectonein = false;
                }
                else
                {
                    getObj(i).setSelect(false);
                }
            }
        }

        public override bool canMove(int x_, int y_, int width, int height, Mylist mylist)
        {
            bool flag = true;
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    flag = ((Mylist)mylist.getObj(i)).canMove(x_, y_, width, height, (Mylist)mylist.getObj(i));
                    if (flag == false) return false;
                }
                else if (mylist.getObj(i).getSelect())
                {
                    flag = mylist.getObj(i).canMove(x_, y_, width, height, mylist);
                    if (flag == false) return false;
                }
            }
            return flag;
        }
        public override void move(int x_, int y_, int width, int height,Mylist mylist)
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    ((Mylist)mylist.getObj(i)).move(x_, y_, width, height, (Mylist)mylist.getObj(i));
                }
                else if (mylist.getObj(i).getSelect())
                {
                    mylist.getObj(i).move(x_, y_, width, height, mylist);
                }
            }
        }

        public override void changesize(int size_,  int width, int height,Mylist mylist)
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    ((Mylist)mylist.getObj(i)).changesize(size_, width, height, (Mylist)mylist.getObj(i));
                }
                else if (mylist.getObj(i).getSelect())
                {
                    mylist.getObj(i).changesize(size_, width, height, mylist);
                }
            }
        }

        public override void setBrush(string color)
        {
            for (int i = 0; i < getSize(); i++)
            {
                if (getObj(i).getCode() == 'L')
                {
                    ((Mylist)getObj(i)).setBrush(color);
                }
                else if(getObj(i).getSelect())
                {
                    getObj(i).setBrush(color);
                }
            }
        }

        public void getOut(Mylist lists)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                lists.add(getObjAndDelete(i));
            }
        }

        public override void toSelect(bool isCTRL, Mylist mylist)//Надо выделить всё что под ним
        {
            for (int i = getSize() - 1; i >= 0; i--)
            {
                if (getObj(i).getCode() == 'L')
                {
                    ((Mylist)getObj(i)).toSelect(true,(Mylist)getObj(i));
                    getObj(i).setSelect(true);
                }
                else
                {
                    getObj(i).setSelect(true);
                }
            }
            
        }
        public void toSelectInId(int ID_)
        {
            for (int i = 0; i < getSize(); i++)
            {
                if (getObj(i).getCode() == 'L')
                { 
                    if (((Mylist)getObj(i)).getId() == ID_)
                    {
                        ((Mylist)getObj(i)).toSelect(true, null);
                    }
                    else
                    {
                        ((Mylist)getObj(i)).toSelectInId(ID_);
                    }
                }
            }
        }
    }
}
