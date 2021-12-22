using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
                        flag = ((Circle)lists.getObj(i)).isClick(e.X, e.Y,isCTRL,lists);    
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
            int valuex = 1;
            int valuey = 1;
            bool Ismove = false;
            bool Isscale = false;
            if (e.Shift)
            {
                valuex = 10;
                valuey = 10;
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
                        valuex *= -1;
                        valuey = 0;
                        Ismove = true;
                        break;
                    case Keys.Right:
                        valuey = 0;
                        Ismove = true;
                        break;
                    case Keys.Up:
                        valuex = 0;
                        valuey *= -1;
                        Ismove = true;
                        break;
                    case Keys.Down:
                        valuex = 0;
                        Ismove = true;
                        break;
                    case Keys.OemMinus:
                        valuex *= -1;
                        Isscale = true;
                        break;
                    case Keys.Oemplus:
                        Isscale = true;
                        break;

                }
                if (Ismove&&lists.canMove(valuex, valuey, pictureBox1.Width, pictureBox1.Height, lists))
                {
                    lists.move(valuex, valuey, pictureBox1.Width, pictureBox1.Height, lists);
                }
                if (Isscale&&lists.canScaled(valuex, pictureBox1.Width, pictureBox1.Height, lists))
                {
                    lists.changesize(valuex, pictureBox1.Width, pictureBox1.Height, lists);
                }
                PaintAll();
            }
            
        }

        public void refreshGroup()
        {
            id = 0;
            listGroup.Items.Clear();
            listGroup.Items.Add("No one ");
            refr(lists);

            void refr(Mylist mylist)
            {
                for (int i = 0; i < mylist.getSize(); i++)
                {
                    if (mylist.getObj(i).getCode() == 'L')
                    {
                        id++;
                        ((Mylist)mylist.getObj(i)).setId(id);
                        listGroup.Items.Add("group " + id.ToString());
                        refr(((Mylist)mylist.getObj(i)));
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

        private void button_ApplyGroup_Click(object sender, EventArgs e)
        {
            lists.refreshSelected(lists);
            int ID = listGroup.SelectedIndex;
            if (ID != 0) 
            {
               lists.toSelectInId(ID);
            }
            PaintAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "savedata.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
                fileInfo.Delete();

            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(lists.getSize());
            writer.Close();
            for (int i = 0; i < lists.getSize(); i++)
            {
                lists.getObj(i).save(path);
            }
        }

        private void dontTouchKeyboard(object sender, KeyEventArgs e)
        {                
            e.SuppressKeyPress = true;
        }
    }
}
