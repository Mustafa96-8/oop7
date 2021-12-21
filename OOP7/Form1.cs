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
        bool isCTRL;
        Bitmap bitmap;
        Graphics gr ;
        int id;
        public Form1()
        {
            InitializeComponent();
            id = 0;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(bitmap);
            
            lists = new Mylist();
            isCTRL = false;
            pictureBox1.Image = GetBitmap();
        }

        public void createCCircle(int x, int y)
        {
            clearSheet();
            CCircle circle = new CCircle(x,y,lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createRectangle(int x,int y)
        {
            clearSheet();
            Rectangle rectangle = new Rectangle(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createSquare(int x, int y)
        {
            clearSheet();
            Square square = new Square(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createTriangle(int x,int y)
        {
            clearSheet();
            Triangle square = new Triangle(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }

        public void createGroup()
        {
            clearSheet();
            id++;
            Mylist group = new Mylist(lists,id);
            listGroup.Items.Add("group " + id.ToString());

            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void CreateObj(object sender, MouseEventArgs e)
        {
            bool flag=false;
            int i=0;
            char code;
            int size = lists.getSize();
            for(i = 0; i < size && (!flag); i++)
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
            isCTRL = false;
            if (!flag) {
                switch (listBox1.SelectedItem.ToString())
                {
                    case "Circle":
                        createCCircle(e.X, e.Y);
                        break;
                    case "Rectangle":
                        createRectangle(e.X, e.Y);
                        break;
                    case "Square":
                        createSquare(e.X, e.Y);
                        break;
                    case "Triangle":
                        createTriangle(e.X, e.Y);
                        break;
                    
                    default:
                        break;
                }
            }
            else
            {
                isCTRL = false;
                PaintAll(); 
            }
            
        }

        private void PaintAll()
        {
            clearSheet();
            PaintDraw();
            pictureBox1.Image = GetBitmap();
            
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void PaintDraw()//отрисовка всех объектов
        {
            if (lists.getSize() == 0)
                return;
            for (int i = 0; i < lists.getSize(); i++)
            {
                lists.getObj(i).print(gr);
            }
            
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }


        private void btnChangeColor(object sender, EventArgs e)
        {
            isCTRL = false;
            for (int i = 0; i < lists.getSize(); i++)
            {
                if (lists.getObj(i).getSelect())
                {
                    lists.getObj(i).setBrush(listColor.SelectedItem.ToString());
                }
            }
            PaintAll();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int value = 1;
            if (e.Shift)
            {
                value = 10;
                isCTRL = false;
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
                        for (int j = lists.getSize() - 1; j >= 0; j--)
                        {
                            char code = lists.getObj(j).getCode();
                            lists.getObj(j).deleteSelected(lists);
                            if (code == 'L')
                            {
                                refreshGroup();
                            }
                        }
                        if(lists.getSize()>0)lists.getObj(0).setSelect(true);
                        break;
                    case Keys.Left:
                        lists.move(-value, 0,  pictureBox1.Width, pictureBox1.Height,lists);
                        break;
                    case Keys.Right:
                        lists.move(+value, 0, pictureBox1.Width, pictureBox1.Height, lists);
                        break;
                    case Keys.Up:
                        lists.move( 0, -value, pictureBox1.Width, pictureBox1.Height, lists);
                        break;
                    case Keys.Down:
                        lists.move( 0,+value, pictureBox1.Width, pictureBox1.Height, lists);
                        break;
                    case Keys.OemMinus:
                        lists.changesize(-value, pictureBox1.Width, pictureBox1.Height, lists);
                        break;
                    case Keys.Oemplus:
                        lists.changesize(+value, pictureBox1.Width, pictureBox1.Height, lists);
                        break;
                    
                }
                PaintAll();
                isCTRL = false;
            }
            
        }
        public void refreshGroup()
        {
            id = 0;
            listGroup.Items.Clear();
            listGroup.Items.Add("Nothing ");
            for (int i = 0; i < lists.getSize(); i++)
            {
                if (lists.getObj(i).getCode() == 'L')
                {
                    id++;
                    ((Mylist)lists.getObj(i)).setId(id);
                    listGroup.Items.Add("group " + id.ToString());
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
            isCTRL = false;
            PaintAll();
        }

        private void listGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lists.refreshSelected(lists);
            if (listGroup.SelectedIndex == 0) 
            {
                PaintAll();
            }
                if (listGroup.SelectedIndex > 0)
            {
                
            }
        }
    }
}
