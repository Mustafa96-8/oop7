﻿using System;
using System.Drawing;

namespace OOP7
{
    class PaintBox
    {
        Bitmap bitmap;
        Graphics graphics;
        int width;
        int height;
        public PaintBox(int width, int height)
        {
            this.width = width;
            this.height = height;
            bitmap = new Bitmap(this.width, this.height);
            graphics = Graphics.FromImage(bitmap);
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }
        public void Draw(Mylist list)
        {
            graphics.Clear(Color.White);
            if (list.getSize() == 0)
                return;
            for (int i = 0; i < list.getSize(); i++)
            {
                list.getObj(i).print(graphics);
            }
        }
        public void Create(int x, int y, Mylist mylist, string name)
        {
            switch (name)
            {
                case "Circle":
                    CCircle circle = new CCircle(x, y, mylist, width, height);
                    break;
                case "Rectangle":
                    Rectangle rectangle = new Rectangle(x, y, mylist, width, height);
                    break;
                case "Square":
                    Square square = new Square(x, y, mylist, width, height);
                    break;
                case "Triangle":
                    Triangle triangle = new Triangle(x, y, mylist, width, height);
                    break;
                default:
                    return;
            }
            Draw(mylist);
        }
    }
}
