using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace DoanLTWD
{
    public partial class Form1 : Form
    {
        public List<int> ans = new List<int>();
        public List<pointer> pointers = new List<pointer>();
        public List<pointer> run = new List<pointer>();
        public Form1()
        {
            InitializeComponent();
        }
        public void DrawNode(Graphics g, Brush bFillNode, Rectangle rect, Point pt, string name, int number)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillEllipse(bFillNode, rect);
            //g.DrawEllipse(pEllipse, rect);
            Font stringFont = new Font("Arial", 9);

            SizeF stringSize = g.MeasureString(name, stringFont);
            g.DrawString(name, stringFont, Brushes.Black,
                        pt.X + (number - stringSize.Width) / 2,
                        pt.Y + (number - stringSize.Height) / 2);
        }
        public void DrawNodemove(Graphics g, Brush bFillNode,Pen pEllipse, Rectangle rect, Point pt, string name, int number)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillEllipse(bFillNode, rect);
            g.DrawEllipse(pEllipse, rect);
            Font stringFont = new Font("Arial", 9);

            SizeF stringSize = g.MeasureString(name, stringFont);
            g.DrawString(name, stringFont, Brushes.Black,
                        pt.X + (number - stringSize.Width) / 2,
                        pt.Y + (number - stringSize.Height) / 2);
        }
        public void deletedraw(Graphics g, Brush bFillNode, Rectangle rect, Point pt)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillEllipse(bFillNode, rect);
            //g.DrawEllipse(pEllipse, rect);
        }
        public void DrawLine(Graphics g, Pen pLine,Point ptStart, Point ptEnd)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            pLine.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pLine, new Point(ptStart.X, ptStart.Y), new Point(ptEnd.X, ptEnd.Y));
          
        }
        
        public class pointer
        {
            public int x { get; set; }
            public int y { get; set; }
            public int ts { get; set; }
        }
        
        List<int> ls = new List<int>();
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại");
                return;
            }
            if (ls.Count==15)
            {
                MessageBox.Show ("Không thể nhập vì quá dung lượng");
                textBox1.Clear();
                return;
            }
            
            string a = textBox1.Text;
            textBox1.Clear();
            ls.Add(int.Parse(a));
        }
        public void swappointer(int i,int j)
        {
            pointer p = run[i];
            run[i] = run[j];
            run[j] = p;
        }
        public void swapnode(int i,int j)
        {
            int x = run[i].ts;
            run[i].ts = run[j].ts;
            run[j].ts = x;
        }
        public void adddata()
        {
            run.Clear();
            for (int i = 0; i < pointers.Count; i++)
                run.Add(pointers[i]);
        }
        public void move(pointer p1,pointer p2)
        {
            var g = panel1.CreateGraphics();
            Brush cbrushclear = new SolidBrush(Color.OldLace);
            Brush cBrushmove = new SolidBrush(Color.LightGreen);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            Point pt1 = new Point(p1.x, p1.y);
            Point pt2 = new Point(p2.x, p2.y);
            Rectangle rec1 = new Rectangle(pt1,sizeCircle);
            Rectangle rec2 = new Rectangle(pt2, sizeCircle);
            DrawNode(g, cBrushmove, rec1, pt1, p1.ts.ToString(), 50);
            DrawNode(g, cBrushmove, rec2, pt2, p2.ts.ToString(), 50);
            Thread.Sleep(100);
            rec1 = new Rectangle(pt1, sizeCircle1);
            rec2 = new Rectangle(pt2, sizeCircle1);
            deletedraw(g, cbrushclear, rec1, pt1);
            deletedraw(g, cbrushclear, rec2, pt2);
            int up = p1.y + 80;
            int down = p2.y - 80;
            while (p1.y<=up && p2.y>=down)
            {
                pt1 = new Point(p1.x, p1.y);
                pt2 = new Point(p2.x, p2.y);
                rec1 = new Rectangle(pt1, sizeCircle);
                rec2 = new Rectangle(pt2,sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt1, p1.ts.ToString(), 50);
                DrawNode(g, cBrushmove, rec2, pt2, p2.ts.ToString(), 50);
                Thread.Sleep(100);
                pt1.X-=5;
                pt1.Y -= 5;
                pt2.X-=5;
                pt2.Y -= 5;
                rec1 = new Rectangle(pt1, sizeCircle1);
                rec2 = new Rectangle(pt2, sizeCircle1);
                pt1.X+=5;
                pt2.X+=5;
                pt1.Y += 5;
                pt2.Y += 5;
                deletedraw(g, cbrushclear, rec1, pt1);
                deletedraw(g, cbrushclear, rec2, pt2);
                p1.y += 20;
                p2.y -= 20;
            }
            down = p1.x;
            up = p2.x;
            while (p1.x<up && p2.x>down)
            {
                if (p1.x > up)
                {
                    p1.x = up;
                    p2.x = down;
                    break;
                }
                pt1 = new Point(p1.x, p1.y);
                pt2 = new Point(p2.x, p2.y);
                rec1 = new Rectangle(pt1, sizeCircle);
                rec2 = new Rectangle(pt2, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt1, p1.ts.ToString(), 50);
                DrawNode(g, cBrushmove, rec2, pt2, p2.ts.ToString(), 50);
                Thread.Sleep(100);
                pt1.X -= 5;
                pt1.Y -= 5;
                pt2.X -= 5;
                pt2.Y -= 5;
                rec1 = new Rectangle(pt1, sizeCircle1);
                rec2 = new Rectangle(pt2, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt1);
                deletedraw(g, cbrushclear, rec2, pt2);
                pt1.X += 5;
                pt2.X += 5;
                pt1.Y += 5;
                pt2.Y += 5;
                p1.x += 20;
                p2.x -= 20;
            }
            down = p2.y + 80;
            up = p1.y - 80;
            while (p1.y>=up && p2.y<=down)
            {
                pt1 = new Point(p1.x, p1.y);
                pt2 = new Point(p2.x, p2.y);
                rec1 = new Rectangle(pt1, sizeCircle);
                rec2 = new Rectangle(pt2, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt1, p1.ts.ToString(), 50);
                DrawNode(g, cBrushmove, rec2, pt2, p2.ts.ToString(), 50);
                Thread.Sleep(100);
                pt1.X -= 5;
                pt1.Y -= 5;
                pt2.X -= 5;
                pt2.Y -= 5;
                rec1 = new Rectangle(pt1, sizeCircle1);
                rec2 = new Rectangle(pt2, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt1);
                deletedraw(g, cbrushclear, rec2, pt2);
                pt1.X += 5;
                pt2.X += 5;
                pt1.Y += 5;
                pt2.Y += 5;
                p1.y -= 20;
                p2.y += 20;
            }
        }
        /*   void movenode(Graphics g,Brush cbrush, pointer pt,Pen pen,int x,int name)
           {
               Size sizeCircle1 = new Size(30, 30);
               Point p;
               if (x == 10)
                   p = new Point(pt.x + 5, x + 5);
               else
                   p = new Point(pt.x - 5, x - 5);
                 Rectangle rec = new Rectangle(p, sizeCircle1);
               DrawNodemove(g, cbrush, pen, rec, new Point(pt.x, x),name.ToString(),30);
           }*/
        public void Nodesimpleup(pointer p)
        {
            var g = panel1.CreateGraphics();
            Brush cbrushclear = new SolidBrush(Color.OldLace);
            Brush cBrushmove = new SolidBrush(Color.Aqua);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            Point pt = new Point(p.x, p.y);
            Rectangle rec1 = new Rectangle(pt, sizeCircle);
            DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
            Thread.Sleep(100);
            pt.Y -= 10;
            pt.X -= 5;
            rec1 = new Rectangle(pt, sizeCircle1);
            deletedraw(g, cbrushclear, rec1, pt);
            int up = p.y - 80;
            while (p.y>=up)
            {
                p.y -= 20;
                pt = new Point(p.x, p.y);
                rec1 = new Rectangle(pt, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                Thread.Sleep(100);
                pt.X -= 5;
                pt.Y -= 5;
                if (p.y == up)
                    break;
                rec1 = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt);
                pt.X += 5;
                pt.Y += 5;
            }

        }
        public void Nodesimpleright(int x,int y,int ts,int right)
        {
            var g = panel1.CreateGraphics();
            Brush cbrushclear = new SolidBrush(Color.OldLace);
            Brush cBrushmove = new SolidBrush(Color.Aqua);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(80, 80);
            Point pt = new Point(x, y);
            Rectangle rec1 = new Rectangle(pt, sizeCircle);
            DrawNode(g, cBrushmove, rec1, pt, ts.ToString(), 50);
            Thread.Sleep(300);
            pt.X -= 10;
            pt.Y -= 2;
            rec1 = new Rectangle(pt, sizeCircle1);
            deletedraw(g, cbrushclear, rec1, pt);
            while (x <= right)
            {
                x += 20;
                pt = new Point(x,y);
                rec1 = new Rectangle(pt, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt, ts.ToString(), 50);
                Thread.Sleep(300);
                if (x == right)
                    break;
                pt.X -= 5;
                pt.Y -= 5;
                rec1 = new Rectangle(pt, sizeCircle1);
                pt.X += 5;
                pt.Y += 5;
                deletedraw(g, cbrushclear, rec1, pt);
            }
        }
        public void Nodesimpledown(pointer p)
        {
            var g = panel1.CreateGraphics();
            Brush cbrushclear = new SolidBrush(Color.OldLace);
            Brush cBrushmove = new SolidBrush(Color.Wheat);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(80, 80);
            Point pt = new Point(p.x, p.y);
            Rectangle rec1 = new Rectangle(pt, sizeCircle);
  
            DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
            Thread.Sleep(300);
            pt.X -= 10;
            pt.Y -= 5;
            
            rec1 = new Rectangle(pt, sizeCircle1);
            deletedraw(g, cbrushclear, rec1, pt);
            pt.X += 5;
            pt.Y += 10;
            int down = p.y + 80;
            while (p.y <= down)
            {
                p.y += 20;
                pt = new Point(p.x, p.y);
                rec1 = new Rectangle(pt, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                Thread.Sleep(300);
                if (p.y == down)
                    break;
                pt.X -= 5;
                pt.Y -= 5;
                rec1 = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt);
                pt.X += 5;
                pt.Y += 5;
            }
        }
        public void Nodesimpleleftdown(pointer p,int x,int y) // p là node di chuyển(tmp), p1 là node cần đúng vị trí
        {
            var g = panel1.CreateGraphics();
            Brush cbrushclear = new SolidBrush(Color.OldLace);
            Brush cBrushmove = new SolidBrush(Color.Aqua);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(80, 80);
            Point pt = new Point(x, y);
            Rectangle rec1 = new Rectangle(pt, sizeCircle);
            DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
            pt.X -= 10;
            pt.Y -= 10;
            rec1 = new Rectangle(pt, sizeCircle1);
            deletedraw(g, cbrushclear, rec1, pt);
            while (p.x<=x)
            {
                x -= 20;
                pt = new Point(x, y);
                rec1 = new Rectangle(pt, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                Thread.Sleep(100);
                pt.X -= 5;
                pt.Y -= 5;
                if (x == p.x)
                    break;
                rec1 = new Rectangle(pt, sizeCircle1);
                pt.X += 5;
                pt.Y += 5;
                deletedraw(g, cbrushclear, rec1, pt);
            }
            rec1 = new Rectangle(pt, sizeCircle1);
            pt.X += 5;
            pt.Y += 5;
            deletedraw(g, cbrushclear, rec1, pt);
            while (p.y >= y)
            {
                y += 20;
                pt = new Point(x, y);
                rec1 = new Rectangle(pt, sizeCircle);
                DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                Thread.Sleep(100);
                pt.X -= 5;
                pt.Y -= 5;
                if (y == p.y)
                    break;
               
                rec1 = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt);
                pt.X += 5;
                pt.Y += 5;
                /*pt.X -= 5;
                DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                Thread.Sleep(1000);
                pt.X += 5;
                rec1 = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushclear, rec1, pt);
                while (p.x>=p1.x)
                {
                    p.x += 20;
                    pt = new Point(p.x, p.y);
                    rec1 = new Rectangle(pt, sizeCircle);
                    DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                    Thread.Sleep(1000);
                    pt.X -= 5;
                    pt.Y -= 5;
                    rec1 = new Rectangle(pt, sizeCircle1);
                    pt.X += 5;
                    pt.Y += 5;
                    deletedraw(g, cbrushclear, rec1, pt);
                }

                while (p.y>=p1.y)
                {
                    p.y -= 20;
                    pt = new Point(p.x, p.y);
                    rec1 = new Rectangle(pt, sizeCircle);
                    DrawNode(g, cBrushmove, rec1, pt, p.ts.ToString(), 50);
                    Thread.Sleep(1000);
                    pt.X -= 5;
                    pt.Y -= 5;
                    rec1 = new Rectangle(pt, sizeCircle1);
                    pt.X += 5;
                    pt.Y += 5;
                    deletedraw(g, cbrushclear, rec1, pt);*/
            }
        }
        public void ssmin()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
        /*    Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.Gray);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray,3.0F);*/
            Size sizeCircle = new Size(50, 50);
            adddata();
            for (int i=0;i<ls.Count;i++)
            {
                int u = run[i].ts;
                Point pt1 = new Point(run[i].x, run[i].y);
                Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
               // movenode(g, cbrushnode, run[i], pennode, 10,i);
                for (int j = i + 1; j < ls.Count; j++)
                {
                   // movenode(g, cbrushnode, run[j], pennode, panel1.Height - 60,j);
                    Point pt2 = new Point(run[j].x, run[j].y);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                    Thread.Sleep(100);
                    int v = run[j].ts;
                    if (u > v)
                    {
                        move(run[i], run[j]);
                        swappointer(i, j);
                        pt1 = new Point(run[i].x, run[i].y);
                        rec1 = new Rectangle(pt1, sizeCircle);
                        DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
                        pt2 = new Point(run[j].x, run[j].y);
                        rec2 = new Rectangle(pt2, sizeCircle);
                        DrawNode(g, cbrush, rec2, pt2, run[j].ts.ToString(), 50);
                        Thread.Sleep(100);
                        u = run[i].ts;
                    }
                    else
                    {
                        pt2 = new Point(run[j].x, run[j].y);
                        rec2 = new Rectangle(pt2, sizeCircle);
                        DrawNode(g, cbrush, rec2, pt2, run[j].ts.ToString(), 50);
                        Thread.Sleep(100);
                    }
                  //  movenode(g, cbrushgray, run[i], penback, (panel1.Height - 60), j);
                }
                if (i==ls.Count-1)
                {
                    var pt2 = new Point(run[ls.Count - 1].x, run[ls.Count - 1].y);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushend, rec2, pt2, run[ls.Count - 1].ts.ToString(), 50);
                }
                else
                {
                    pt1 = new Point(run[i].x, run[i].y);
                    rec1 = new Rectangle(pt1, sizeCircle);
                    DrawNode(g, cbrushend, rec1, pt1, run[i].ts.ToString(), 50);
                    Thread.Sleep(100);
                }
              //  movenode(g, cbrushgray, run[i], penback, 10, i);
            }
        }
        public void ssmax()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            adddata();
            for (int i = 0; i < ls.Count; i++)
            {
                int u = run[i].ts;
                Point pt1 = new Point(run[i].x, run[i].y);
                Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
                // movenode(g, cbrushnode, run[i], pennode, 10,i);
                for (int j = i + 1; j < ls.Count; j++)
                {
                    // movenode(g, cbrushnode, run[j], pennode, panel1.Height - 60,j);
                    Point pt2 = new Point(run[j].x, run[j].y);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                    Thread.Sleep(100);
                    int v = run[j].ts;
                    if (u < v)
                    {
                        move(run[i], run[j]);
                        swappointer(i, j);
                        pt1 = new Point(run[i].x, run[i].y);
                        rec1 = new Rectangle(pt1, sizeCircle);
                        DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
                        pt2 = new Point(run[j].x, run[j].y);
                        rec2 = new Rectangle(pt2, sizeCircle);
                        DrawNode(g, cbrush, rec2, pt2, run[j].ts.ToString(), 50);
                        Thread.Sleep(100);
                        u = run[i].ts;
                    }
                    else
                    {
                        pt2 = new Point(run[j].x, run[j].y);
                        rec2 = new Rectangle(pt2, sizeCircle);
                        DrawNode(g, cbrush, rec2, pt2, run[j].ts.ToString(), 50);
                        Thread.Sleep(100);
                    }
                    //  movenode(g, cbrushgray, run[i], penback, (panel1.Height - 60), j);
                }
                if (i == ls.Count - 1)
                {
                    var pt2 = new Point(run[ls.Count - 1].x, run[ls.Count - 1].y);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushend, rec2, pt2, run[ls.Count - 1].ts.ToString(), 50);
                }
                else
                {
                    pt1 = new Point(run[i].x, run[i].y);
                    rec1 = new Rectangle(pt1, sizeCircle);
                    DrawNode(g, cbrushend, rec1, pt1, run[i].ts.ToString(), 50);
                    Thread.Sleep(100);
                }
                //  movenode(g, cbrushgray, run[i], penback, 10, i);
            }
        }
        public void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            this.Refresh();
            int x = 80;
            int y = panel1.Height/2;
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Pen pCircle = new Pen(Color.Wheat, 3.0F);
            Brush cbrushclean = new SolidBrush(Color.OldLace);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(30, 30);
            int dem = 0;
            pointers.Clear();
            foreach (var i in ls)
            {
                x += 50;
                dem++;
                Point pt1 = new Point(x, 10);
                Rectangle rec1 = new Rectangle(pt1, sizeCircle1);
                DrawNode(g, cbrushclean, rec1, pt1, dem.ToString(), 50);
                /*pt1 = new Point(x, panel1.Height - 60);
                rec1 = new Rectangle(pt1, sizeCircle1);
                DrawNode(g, cbrushclean, rec1, pt1, dem.ToString(), 50);*/
                Point pt = new Point(x, y);
                pointers.Add(new pointer
                {
                    x = x,
                    y = y,
                    ts = i
                });
                Rectangle rec = new Rectangle(pt, sizeCircle);
                x += 30;
                DrawNode(g, cbrush, rec, pt, i.ToString(), 50);
               // Thread.Sleep(3000);
            }
        }
        public void ismin()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            int x, y;
            adddata();
            for (int i = 1; i < ls.Count; i++)
            {
                int u = run[i].ts; // 0
                x = run[i].x;
                y = run[i].y - 80;
                //  MessageBox.Show(run[i].y.ToString());
                Point pt1 = new Point(pointers[i].x, pointers[i].y);
                Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
                Thread.Sleep(100);
                Nodesimpleup(run[i]);
                //  MessageBox.Show(run[i].y.ToString());
                run[i].y += 80;
                int j = i - 1;
                Point pt2 = new Point(run[j].x, run[j].y);
                Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                //DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                Thread.Sleep(300);
                while (run[j].ts > u)
                {
                    pt2 = new Point(run[j].x, run[j].y);
                    rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                    Thread.Sleep(100);
                    j--;
                    if (j == -1)
                        break;
                    Thread.Sleep(100);
                }
                if (j == i - 1)
                {
                    run[i].y -= 80;
                    Nodesimpledown(run[i]);
                    continue;
                }

                j++;
                for (int k = i - 1; k >= j; k--)
                {
                    int x1 = run[k].x;
                    int y1 = run[k].y;
                    int tmp = run[k].ts;
                    Nodesimpleright(x1, y1, tmp, run[k + 1].x);
                    swapnode(k, k + 1);
                }
                Nodesimpleleftdown(run[j], x, y);
                for (int k = j; k <= i; k++)
                {
                    pt1 = new Point(run[k].x, run[k].y);
                    rec1 = new Rectangle(pt1, sizeCircle);
                    DrawNode(g, cbrush, rec1, pt1, run[k].ts.ToString(), 50);
                    Thread.Sleep(100);
                }
            }
        }
        public void ismax()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            int x, y;
            adddata();
            for (int i = 1; i < ls.Count; i++)
            {
                int u = run[i].ts; // 0
                x = run[i].x;
                y = run[i].y - 80;
                //  MessageBox.Show(run[i].y.ToString());
                Point pt1 = new Point(pointers[i].x, pointers[i].y);
                Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                DrawNode(g, cbrushselect, rec1, pt1, run[i].ts.ToString(), 50);
                Thread.Sleep(100);
                Nodesimpleup(run[i]);
                //  MessageBox.Show(run[i].y.ToString());
                run[i].y += 80;
                int j = i - 1;
                Point pt2 = new Point(run[j].x, run[j].y);
                Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                //DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                Thread.Sleep(300);
                while (run[j].ts < u)
                {
                    pt2 = new Point(run[j].x, run[j].y);
                    rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j].ts.ToString(), 50);
                    Thread.Sleep(100);
                    j--;
                    if (j == -1)
                        break;
                    Thread.Sleep(100);
                }
                if (j == i - 1)
                {
                    run[i].y -= 80;
                    Nodesimpledown(run[i]);
                    continue;
                }

                j++;
                for (int k = i - 1; k >= j; k--)
                {
                    int x1 = run[k].x;
                    int y1 = run[k].y;
                    int tmp = run[k].ts;
                    Nodesimpleright(x1, y1, tmp, run[k + 1].x);
                    swapnode(k, k + 1);
                }
                Nodesimpleleftdown(run[j], x, y);
                for (int k = j; k <= i; k++)
                {
                    pt1 = new Point(run[k].x, run[k].y);
                    rec1 = new Rectangle(pt1, sizeCircle);
                    DrawNode(g, cbrush, rec1, pt1, run[k].ts.ToString(), 50);
                    Thread.Sleep(100);
                }
            }
        }
        public void bbmax()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            adddata();
            for (int i=0;i<ls.Count;i++)
            {
                for (int j=ls.Count-1;j>i;j--)
                {
                    Point pt1 = new Point(run[j].x, run[j].y);
                    Point pt2 = new Point(run[j - 1].x, run[j - 1].y);
                    Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec1, pt1, run[j].ts.ToString(), 50);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j - 1].ts.ToString(), 50);
                    Thread.Sleep(100);
                    if (run[j].ts>run[j-1].ts)
                    {
                        move(run[j-1], run[j]);
                        swappointer(j - 1, j);
                    }
                     pt1 = new Point(run[j].x, run[j].y);
                     pt2 = new Point(run[j - 1].x, run[j - 1].y);
                     rec1 = new Rectangle(pt1, sizeCircle);
                     rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrush, rec1, pt1, run[j].ts.ToString(), 50);
                    DrawNode(g, cbrush, rec2, pt2, run[j - 1].ts.ToString(), 50);
                }
                Point pt = new Point(run[i].x, run[i].y);
                Rectangle rec = new Rectangle(pt, sizeCircle);
                DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                Thread.Sleep(100);
            }
        }
        public void bbmin()
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushgray = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            adddata();
            for (int i = 0; i < ls.Count; i++)
            {
                for (int j = ls.Count - 1; j > i; j--)
                {
                    Point pt1 = new Point(run[j].x, run[j].y);
                    Point pt2 = new Point(run[j - 1].x, run[j - 1].y);
                    Rectangle rec1 = new Rectangle(pt1, sizeCircle);
                    Rectangle rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrushselect, rec1, pt1, run[j].ts.ToString(), 50);
                    DrawNode(g, cbrushselect, rec2, pt2, run[j - 1].ts.ToString(), 50);
                    Thread.Sleep(100);
                    if (run[j].ts < run[j - 1].ts)
                    {
                        move(run[j - 1], run[j]);
                        swappointer(j - 1, j);
                    }
                    pt1 = new Point(run[j].x, run[j].y);
                    pt2 = new Point(run[j - 1].x, run[j - 1].y);
                    rec1 = new Rectangle(pt1, sizeCircle);
                    rec2 = new Rectangle(pt2, sizeCircle);
                    DrawNode(g, cbrush, rec1, pt1, run[j].ts.ToString(), 50);
                    DrawNode(g, cbrush, rec2, pt2, run[j - 1].ts.ToString(), 50);
                }
                Point pt = new Point(run[i].x, run[i].y);
                Rectangle rec = new Rectangle(pt, sizeCircle);
                DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                Thread.Sleep(100);
            }
        }
        void nodeup(int k,pointer tmp)
        {
            int up = k - 60;
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.LightGreen);
            Brush cbrushback = new SolidBrush(Color.OldLace);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            Pen pennode = new Pen(Color.Black, 3.0F);
            while (k>=up)
            {
                k -= 20;
                Point pt = new Point(tmp.x, k);
                Rectangle rec = new Rectangle(pt, sizeCircle);
                DrawNode(g, cbrush, rec, pt, tmp.ts.ToString(), 50);
                Thread.Sleep(100);
                if (k == up)
                    break;
                pt.X -= 5;
                pt.Y -= 5;
                rec = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushback, rec, pt);
                pt.X += 5;
                pt.Y += 5;
            }
        }
        void nodedown(int k,pointer tmp)
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.LightGreen);
            Brush cbrushback = new SolidBrush(Color.OldLace);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Point pt = new Point(tmp.x - 5, k - 5);
            Rectangle rec = new Rectangle(pt, sizeCircle1);
            int up = k + 60;
            while (k <= up)
            {
                k += 20;
                pt = new Point(tmp.x, k);
                 rec = new Rectangle(pt, sizeCircle);
                DrawNode(g, cbrush, rec, pt, tmp.ts.ToString(), 50);
                Thread.Sleep(100);
                if (k == up)
                    break;
                pt.X += 7;
                pt.Y += 7;
                rec = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushback, rec, pt);
                pt.X -= 7;
                pt.Y -= 7;
            }
        }
        public void mgmax(int l,int r,int k)
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushback = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            int cnt;
            for (int i = l; i <= r; i++)
            {
                Thread.Sleep(100);
                Point pt = new Point(run[i].x, k);
                pt.X -= 5;
                pt.Y -= 5;
                Rectangle rec = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushback, rec, pt);
                nodeup(k, run[i]);
            }
            if (r-l<=1)
            {
                if (r-l==1)
                {
                    if (run[l].ts < run[r].ts)
                        swapnode(l, r);
                }
               /* for (int i = l; i <= r; i++)
                {
                    pointer tmp = run[i];
                    for (int j = i + 1; j <= r; j++)
                    {
                        if (run[i].ts < run[j].ts)
                            swapnode(i, j);
                    }
                }*/
                cnt = k - 60;   
                while (cnt <= k)
                {
                    for (int i = l; i <= r; i++)
                    {
                        Point pt = new Point(run[i].x, cnt);
                        Rectangle rec = new Rectangle(pt, sizeCircle);
                        DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                    }
                    Thread.Sleep(100);
                    if (cnt == k)
                        break;
                    for (int i = l; i <= r; i++)
                    {
                        Point pt = new Point(run[i].x, cnt);
                        pt.X -= 5;
                        pt.Y -= 5;
                        Rectangle rec = new Rectangle(pt, sizeCircle1);
                        deletedraw(g, cbrushback, rec, pt);
                    }
                    cnt += 20;
                }
                return;
            }
            int mid = (l + r) / 2;
            mgmax(l, mid, k - 60);
            mgmax(mid+1, r, k - 60);
            cnt = k - 60;
            int left = l;
            int right = mid+1;
            List<int> check = new List<int>();
            for (int i = l; i <= r; i++)
            {
                check.Add(run[i].ts);
            }
            List<int> kq = new List<int>();
            while (true)
            {
               
                if (left==mid+1)
                {
                    for (int i = right; i <= r; i++)
                        kq.Add(run[i].ts);
                    break;
                }
                if (right==r+1)
                {
                    for (int i = left; i <= mid; i++)
                        kq.Add(run[i].ts);
                    break;
                }
                if (run[left].ts<run[right].ts)
                {
                    kq.Add(run[right].ts);
                    right++;
                }
                else
                {
                    kq.Add(run[left].ts);
                    left++;
                }
            }
            int dem = 0;
            for (int i=l;i<=r;i++)
            {
                run[i].ts = kq[dem];
                dem++;
            }
            while (cnt<=k)
            {
                for (int i =l;i<=r;i++)
                {
                    Point pt = new Point(run[i].x, cnt);
                    Rectangle rec = new Rectangle(pt, sizeCircle);
                    DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                }
                Thread.Sleep(100);
                if (cnt == k)
                    break;
                for (int i=l;i<=r;i++)
                {
                    Point pt = new Point(run[i].x, cnt);
                    pt.X -= 5;
                    pt.Y -= 5;
                    Rectangle rec = new Rectangle(pt, sizeCircle1);
                    deletedraw(g, cbrushback, rec, pt);
                }
                cnt += 20;
            }
        }
        public void mgmin(int l,int r,int k)
        {
            var g = panel1.CreateGraphics();
            Brush cbrush = new SolidBrush(Color.Wheat);
            Brush cbrushselect = new SolidBrush(Color.LightGreen);
            Brush cbrushend = new SolidBrush(Color.Aqua);
            Brush cbrushnode = new SolidBrush(Color.Yellow);
            Brush cbrushback = new SolidBrush(Color.OldLace);
            Pen pennode = new Pen(Color.Black, 3.0F);
            Pen penback = new Pen(Color.Gray, 3.0F);
            Size sizeCircle = new Size(50, 50);
            Size sizeCircle1 = new Size(70, 70);
            int cnt;
            for (int i = l; i <= r; i++)
            {
                Thread.Sleep(100);
                Point pt = new Point(run[i].x, k);
                pt.X -= 5;
                pt.Y -= 5;
                Rectangle rec = new Rectangle(pt, sizeCircle1);
                deletedraw(g, cbrushback, rec, pt);
                nodeup(k, run[i]);
            }
            if (r - l <= 1)
            {
                /*for (int i = l; i <= r; i++)
                {
                    pointer tmp = run[i];
                    for (int j = i + 1; j <= r; j++)
                    {
                        if (run[i].ts > run[j].ts)
                            swapnode(i, j);
                    }
                }*/
                if (r - l == 1)
                {
                    if (run[l].ts > run[r].ts)
                        swapnode(l, r);
                }
                cnt = k - 60;
                while (cnt <= k)
                {
                    for (int i = l; i <= r; i++)
                    {
                        Point pt = new Point(run[i].x, cnt);
                        Rectangle rec = new Rectangle(pt, sizeCircle);
                        DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                    }
                    Thread.Sleep(100);
                    if (cnt == k)
                        break;
                    for (int i = l; i <= r; i++)
                    {
                        Point pt = new Point(run[i].x, cnt);
                        pt.X -= 5;
                        pt.Y -= 5;
                        Rectangle rec = new Rectangle(pt, sizeCircle1);
                        deletedraw(g, cbrushback, rec, pt);
                    }
                    cnt += 20;
                }
                return;
            }
            int mid = (l + r) / 2;
            mgmin(l, mid, k - 60);
            mgmin(mid + 1, r, k - 60);
            cnt = k - 60;
            int left = l;
            int right = mid + 1;
            List<int> check = new List<int>();
            for (int i = l; i <= r; i++)
            {
                check.Add(run[i].ts);
            }
            List<int> kq = new List<int>();
            while (true)
            {

                if (left == mid + 1)
                {
                    for (int i = right; i <= r; i++)
                        kq.Add(run[i].ts);
                    break;
                }
                if (right == r + 1)
                {
                    for (int i = left; i <= mid; i++)
                        kq.Add(run[i].ts);
                    break;
                }
                if (run[left].ts > run[right].ts)
                {
                    kq.Add(run[right].ts);
                    right++;
                }
                else
                {
                    kq.Add(run[left].ts);
                    left++;
                }
            }
            int dem = 0;
            for (int i = l; i <= r; i++)
            {
                run[i].ts = kq[dem];
                dem++;
            }
            /*for (int i = l; i <= r; i++)
            {
                pointer tmp = run[i];
                for (int j = i + 1; j <= r; j++)
                {
                    if (run[i].ts > run[j].ts)
                        swapnode(i, j);
                }
            }*/
            while (cnt <= k)
            {
                for (int i = l; i <= r; i++)
                {
                    Point pt = new Point(run[i].x, cnt);
                    Rectangle rec = new Rectangle(pt, sizeCircle);
                    DrawNode(g, cbrushend, rec, pt, run[i].ts.ToString(), 50);
                }
                Thread.Sleep(100);
                if (cnt == k)
                    break;
                for (int i = l; i <= r; i++)
                {
                    Point pt = new Point(run[i].x, cnt);
                    pt.X -= 5;
                    pt.Y -= 5;
                    Rectangle rec = new Rectangle(pt, sizeCircle1);
                    deletedraw(g, cbrushback, rec, pt);
                }
                cnt += 20;
            }
            for (int i = l; i <= r; i++)
            {
                pointer tmp = run[i];
                for (int j = i + 1; j <= r; j++)
                {
                    if (tmp.ts > run[j].ts)
                    {
                        swapnode(i, j);
                    }
                }
            }
            for (int i = l; i <= r; i++)
            {
                Point pt = new Point(run[i].x, run[i].y + k);
                Rectangle rec = new Rectangle(pt, sizeCircle);

            }
        }
        protected override void WndProc(ref Message m)
        {
            // Suppress the WM_UPDATEUISTATE message
            if (m.Msg == 0x128) return;
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
            if (ls.Count==0)
            {
                MessageBox.Show("Chưa có phần tử để thực hiện thuật toán");
                return;
            }
            if (checkBox1.Checked == true)
            {
                if (checkBox6.Checked == true)
                    ssmax();
                else if (checkBox5.Checked == true)
                    ssmin();
                else
                    MessageBox.Show("Vui lòng tích vào bảng điều khiển");
                return;
            }
            if (checkBox2.Checked == true)
            {
                if (checkBox6.Checked == true)
                    ismax();
                else if (checkBox5.Checked == true)
                    ismin();
                else
                    MessageBox.Show("Vui lòng tích vào bảng điều khiển");
                return;
            }
            if (checkBox3.Checked == true)
            {
                if (checkBox6.Checked == true)
                    bbmax();
                else if (checkBox5.Checked == true)
                    bbmin();
                else
                    MessageBox.Show("Vui lòng tích vào bảng điều khiển");
                return;
            }
            if (checkBox4.Checked == true)
            {
                adddata();
                if (checkBox6.Checked == true)
                    mgmax(0, ls.Count - 1, run[0].y);
                else if (checkBox5.Checked == true)
                    mgmin(0, ls.Count - 1, run[0].y);
                else
                    MessageBox.Show("Vui lòng tích vào bảng điều khiển");
                return;
            }
            MessageBox.Show("Vui lòng tích vào thuật toán");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("Vui lòng nhập lại");
                return;
            }
            if (ls.Count<=int.Parse(textBox2.Text)-1)
            {
                MessageBox.Show("Không tìm thấy phần tử");
                textBox2.Clear();
                return;
            }
            ls.RemoveAt(int.Parse(textBox2.Text)-1);
            button6_Click(sender,e);
            textBox2.Clear();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            checkBox6.Checked = false;
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
        }
    }
}
