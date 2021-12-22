using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP7
{
    public partial class Form1 : Form
    {
        Mylist lists;
        PaintBox paintBox;
        bool isCTRL;
        int id;
        public Form1()
        {
            InitializeComponent();
            id = 0;
            paintBox = new PaintBox(pictureBox1.Width, pictureBox1.Height);
            lists = new Mylist();
            isCTRL = false;
            PaintAll();
        }

        public void createGroup()
        {
            id++;
            Mylist group = new Mylist(lists,id);
            listGroup.Items.Add("group " + id.ToString());

            PaintAll();
        }
        public void CreateObj(object sender, MouseEventArgs e)
        {
            bool flag=false;
            char code;
            int size = lists.getSize();
            for(int i = 0; i < size && (!flag); i++)
            {
                code = lists.getObj(i).getCode();
                switch (code)
                {
                    case 'C':
                        flag = ((CCircle)lists.getObj(i)).isClick(e.X, e.Y,isCTRL,lists);    
                        break;
                    case 'R':
                        flag = ((Rectangle)lists.getObj(i)).isClick(e.X, e.Y,isCTRL, lists);
                        break;
                    case 'S':
                        flag = ((Square)lists.getObj(i)).isClick(e.X, e.Y, isCTRL, lists);
                        break;
                    case 'T':
                        flag = ((Triangle)lists.getObj(i)).isClick(e.X, e.Y, isCTRL, lists);
                        break;
                    case 'L':
                        flag = ((Mylist)lists.getObj(i)).isClick(e.X, e.Y, isCTRL, lists);
                        break;
                }
            }
            if (!flag) {
                paintBox.Create(e.X, e.Y, lists, listBox1.SelectedItem.ToString());
            }
            PaintAll();
        }

        private void PaintAll()
        {
            paintBox.Draw(lists);
            pictureBox1.Image = paintBox.GetBitmap();
        }

        private void btnChangeColor(object sender, EventArgs e)
        {

            lists.setBrush(listColor.SelectedItem.ToString());
            PaintAll();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control) isCTRL = false;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int value = 1;
            if (e.Shift)
            {
                value = 10;
            }
            if (e.KeyCode ==Keys.ControlKey)
            {
                isCTRL = true;
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        for (int i = lists.getSize() - 1; i >= 0; i--)
                        {
                            if (lists.getObj(i).getCode() == 'L')
                            {
                                lists.getObj(i).deleteSelected(lists);
                                refreshGroup();
                                lists.refreshSelected(lists);
                            }
                            else
                            {
                                lists.getObj(i).deleteSelected(lists);
                            }
                        }
                        if(lists.getSize()>0)lists.getObj(0).setSelect(true);
                        break;
                    case Keys.Left:
                        if(lists.canMove(-value, 0, pictureBox1.Width, pictureBox1.Height, lists))
                        {
                            lists.move(-value, 0, pictureBox1.Width, pictureBox1.Height, lists);
                        }
                        break;
                    case Keys.Right:
                        if (lists.canMove(+value, 0, pictureBox1.Width, pictureBox1.Height, lists))
                        {
                            lists.move(+value, 0, pictureBox1.Width, pictureBox1.Height, lists);
                        }
                        break;
                    case Keys.Up:
                        if (lists.canMove(0, -value, pictureBox1.Width, pictureBox1.Height, lists))
                        { 
                            lists.move(0, -value, pictureBox1.Width, pictureBox1.Height, lists); 
                        }
                        break;
                    case Keys.Down:
                        if (lists.canMove(0, +value, pictureBox1.Width, pictureBox1.Height, lists))
                        {
                            lists.move(0, +value, pictureBox1.Width, pictureBox1.Height, lists);
                        }
                        break;
                    case Keys.OemMinus:
                        if (lists.canScaled(-value, pictureBox1.Width, pictureBox1.Height, lists))
                        {
                            lists.changesize(-value, pictureBox1.Width, pictureBox1.Height, lists);
                        }
                        break;
                    case Keys.Oemplus:
                        if (lists.canScaled(+value, pictureBox1.Width, pictureBox1.Height, lists))
                        {
                            lists.changesize(+value, pictureBox1.Width, pictureBox1.Height, lists);
                        }
                        break;
                    
                }
                PaintAll();
            }
            
        }
        public void refreshGroup()
        {
            id = 0;
            listGroup.Items.Clear();
            listGroup.Items.Add("Nothing ");
            refr(id, lists);
            void refr(int id_,Mylist mylist)
            {
                for (int i = 0; i < mylist.getSize(); i++)
                {
                    if (mylist.getObj(i).getCode() == 'L')
                    {
                        id_++;
                        ((Mylist)mylist.getObj(i)).setId(id_);
                        listGroup.Items.Add("group " + id_.ToString());
                        refr(id_, ((Mylist)mylist.getObj(i)));
                    }
                }
            }
            
        }

        private void listColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrush.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            createGroup();
            PaintAll();
        }

        private void listGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lists.refreshSelected(lists);
            int ID = listGroup.SelectedIndex;
            if (ID == 0) 
            {
                PaintAll();
            }
            else
            {
                lists.toSelectInId(ID);
            }
        }
    }
}
