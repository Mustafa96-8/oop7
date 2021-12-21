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

        //Реализация Визуальной херни
        //всё что выше надеюсь не тронем
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
            list = IsLastList(list);
            for (int i = list.getSize() - 1; i >= 0; i--)
            {
                if (list.getObj(i).getSelect())
                {
                    Base b = list.getObjAndDelete(i);
                    b.setmainpen("Yellow");
                    add(b);
                }
            }
            this.id = id;
            initcomp();
            list.add(this);

            Mylist IsLastList(Mylist lists)
            {
                int i;
                for ( i = list.getSize() - 1; i >= 0; )
                {   
                    if (list.getSize() != 0)
                    {
                    if (list.getObj(i).getCode() == 'L' && ((Mylist)list.getObj(i)).Selectonein)
                    {
                        list = (Mylist)list.getObj(i);
                        i = list.getSize()-1;
                    }
                    else i--;
                    }
                }
                return list;
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
            if (Selected)
            {
                
            }
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
                    getObj(i).toSelect(isCtrl,this);
                    Selectonein = true;
                    flag = true;
                }
            }
            return flag;
        }

        public override void refreshSelected(Mylist mylist)//ВСЁ ЗАНУЛЯЕМ
        {
            for (int i = mylist.getSize() - 1; i >=0;i--)
            {   
                if (mylist.getObj(i).getCode() == 'L') 
                {
                    refreshSelected((Mylist)mylist.getObj(i));
                }
                else
                {
                    mylist.getObj(i).setSelect(false);
                }
            }
        }

        public override void move(int x_, int y_, int width, int height,Mylist mylist)
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    mylist.getObj(i).move(x_, y_, width, height, this);
                }
                else
                if (mylist.getObj(i).getSelect())
                {
                    mylist.getObj(i).move(x_, y_, width, height,this);
                }
            }
        }

        public override void changesize(int size,  int width, int height,Mylist mylist)
        {
            for (int i = 0; i < mylist.getSize(); i++)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    mylist.getObj(i).changesize(size, width, height, this);
                }
                else
                if (mylist.getObj(i).getSelect())
                {
                    mylist.getObj(i).changesize(size, width, height, this);
                }
            }
        }

        public override void setBrush(string color)
        {
            for (int i = 0; i < size; i++)
            {
                getObj(i).setBrush(color);
            }
        }

        public void getOut(Mylist lists)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                lists.add(getObjAndDelete(i));
            }
        }


        public override void toSelect(bool isCTRL, Mylist mylist)
        {
            for (int i = mylist.getSize() - 1; i >= 0; i--)
            {
                if (mylist.getObj(i).getCode() == 'L')
                {
                    toSelect(isCTRL,(Mylist)mylist.getObj(i));
                }
                else
                {
                    mylist.getObj(i).toSelect(isCTRL, mylist);
                }
            }
            
        }

    }
}
