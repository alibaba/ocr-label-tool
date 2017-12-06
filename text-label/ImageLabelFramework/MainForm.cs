using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageLabelFramework
{
    public partial class MainForm : Form
    {
        static private int maxLebel = 100;
        //static private double err = 1e-5;
        static private string[] rgSuffix = new string[] { "*.jpg", "*.bmp", "*.png", "*.gif", "*.jpeg" };
        static private Pen pen = new Pen(Brushes.Red, 2);
        static private Pen pen_sel = new Pen(Brushes.Green, 2);
        static private Pen pen2 = new Pen(Brushes.GreenYellow, 1);
        static private int extend = 20;

        private ImgMetaData[] rgIMD = null;
        private int cur = -1;
        private int ava = -1;
        //private Point[] stack = new Point[4];
        private int ptr = -1;
        private int ang = 0;
        private Point[] clkpoint = new Point[2];
        private Point[] newpoint = new Point[4];
        //public static String orcname;
        //private Point uppoint = Point.Empty;

        public static int maxH = 0;
        public static int maxW = 0;

        private Bitmap bmp = null;
        private Poly[] buffer = new Poly[maxLebel];
        private int index = 0;

        private int selected = -1;
        
        private void Initialize(string rootPath)
        {
            List<FileInfo> vList = new List<FileInfo>();
            foreach (string suf in rgSuffix)
            {
                vList.AddRange(new DirectoryInfo(rootPath).GetFiles(suf));
            }

            if (0 == vList.Count)
            {
                bottomToolStripStatusLabel.Text = "Invalid or empty directory.";
            }
            else
            {
                rgIMD = new ImgMetaData[vList.Count];
                for (int i = 0; i < vList.Count; ++i)
                {
                    //MessageBox.Show("002");
                    rgIMD[i] = new ImgMetaData(vList[i].FullName);
                }

                cur = ava = 0;
                LoadImg();
            }
            this.mainPictureBox.Focus();
        }

        private void FindAva()
        {
            int tar = -1;
            for (int i = ava + 1; i % rgIMD.Length != ava; ++i)
            {
                if (rgIMD[i % rgIMD.Length].IsEmpty())
                {
                    tar = i % rgIMD.Length;
                    break;
                }
            }
            ava = tar;
            availableButton.Enabled = ava >= 0;
        }

        private void updatecombobox()
        {
            avaitext.Items.Clear();
            avaitext.Text = "";
            for (int i = 0; i < index; i++)
            {
                avaitext.Items.Add(buffer[i].name);
            }
        }

        private void OperateClick()
        {
            mainPictureBox.Enabled = Click0Label.Enabled = Click1Label.Enabled = Click2Label.Enabled  = (bmp != null);
            Click0Label.Text = Click1Label.Text = Click2Label.Text = "";
            ptr = -1;
            redrawButton.Enabled = sealButton.Enabled = Confirm.Enabled = false;
            undoButton.Enabled = clearButton.Enabled = avaitext.Enabled = (index > 0);
            deletetext.Enabled = edittext.Enabled = (selected >= 0);
            if (rgIMD != null)
                avalabel.Text = (cur+1) + "/" + rgIMD.Length;
            updatecombobox();
            AcceptButton = nextButton;
        }
        
        private void DrawPanel(int sel)
        {
            if (bmp != null)
            {
                Graphics g = Graphics.FromImage(bmp);
                Point[] newpoint = new Point[4];
                double alp, beta, le;
                int mx, my;
                for (int i = 0; i < index; ++i)
                {
                    if (buffer[i].rgP[0].X < buffer[i].rgP[1].X)
                    {
                        newpoint[0] = new Point(buffer[i].rgP[0].X, buffer[i].rgP[0].Y);
                        newpoint[2] = new Point(buffer[i].rgP[1].X, buffer[i].rgP[1].Y);
                    }
                    else
                    {
                        newpoint[0] = new Point(buffer[i].rgP[1].X, buffer[i].rgP[1].Y);
                        newpoint[2] = new Point(buffer[i].rgP[0].X, buffer[i].rgP[0].Y);
                    }
                    if (buffer[i].angle == 0 || buffer[i].angle == 90 || buffer[i].angle == -90)
                    {
                        newpoint[1] = new Point(newpoint[0].X, newpoint[2].Y);
                        newpoint[3] = new Point(newpoint[2].X, newpoint[0].Y);
                    }
                    else
                    {
                        alp = buffer[i].angle / 180.0 * Math.PI;
                        beta = Math.Atan2((double)(newpoint[2].Y - newpoint[0].Y), (double)(newpoint[2].X - newpoint[0].X));
                        le = Math.Sqrt((newpoint[2].Y - newpoint[0].Y) * (newpoint[2].Y - newpoint[0].Y) + (newpoint[2].X - newpoint[0].X) * (newpoint[2].X - newpoint[0].X));
                        mx = (int)(le * Math.Cos(alp - beta) * Math.Cos(alp));
                        my = (int)(le * Math.Cos(alp - beta) * Math.Sin(alp));
                        newpoint[1] = new Point(newpoint[0].X + mx, newpoint[0].Y + my);
                        newpoint[3] = new Point(newpoint[2].X - mx, newpoint[2].Y - my);
                    }
                    if(i==sel)
                        g.DrawPolygon(pen_sel, newpoint);
                    else
                        g.DrawPolygon(pen, newpoint);
                }
            }
                
            mainPictureBox.Image = bmp;
            undoButton.Enabled = clearButton.Enabled = index > 0;
        }

        private void AddPoly()
        {
            Graphics g = Graphics.FromImage(bmp);
            Point[] newpoint = new Point[4];
            if (buffer[index - 1].rgP[0].X < buffer[index - 1].rgP[1].X)
            {
                newpoint[0] = new Point(buffer[index - 1].rgP[0].X, buffer[index - 1].rgP[0].Y);
                newpoint[2] = new Point(buffer[index - 1].rgP[1].X, buffer[index - 1].rgP[1].Y);
            }
            else
            {
                newpoint[0] = new Point(buffer[index - 1].rgP[1].X, buffer[index - 1].rgP[1].Y);
                newpoint[2] = new Point(buffer[index - 1].rgP[0].X, buffer[index - 1].rgP[0].Y);
            }
            if (buffer[index - 1].angle == 0 || buffer[index - 1].angle == 90 || buffer[index - 1].angle == -90)
            {
                newpoint[1] = new Point(newpoint[0].X, newpoint[2].Y);
                newpoint[3] = new Point(newpoint[2].X, newpoint[0].Y);
            }
            else
            {
                double alp = buffer[index - 1].angle / 180.0 * Math.PI;
                double beta = Math.Atan2((double)(newpoint[2].Y - newpoint[0].Y), (double)(newpoint[2].X - newpoint[0].X));
                double le = Math.Sqrt((newpoint[2].Y - newpoint[0].Y) * (newpoint[2].Y - newpoint[0].Y) + (newpoint[2].X - newpoint[0].X) * (newpoint[2].X - newpoint[0].X));
                int mx = (int)(le * Math.Cos(alp - beta) * Math.Cos(alp));
                int my = (int)(le * Math.Cos(alp - beta) * Math.Sin(alp));
                newpoint[1] = new Point(newpoint[0].X + mx, newpoint[0].Y + my);
                newpoint[3] = new Point(newpoint[2].X - mx, newpoint[2].Y - my);
            }
            g.DrawPolygon(pen, newpoint);

            mainPictureBox.Image = bmp;
            undoButton.Enabled = clearButton.Enabled = true;
        }

        private void LoadImg()
        {
            //MessageBox.Show(cur.ToString());
            Image img = rgIMD[cur].GetImg();
            if (null != img)
            {
                bmp = new Bitmap(img);
                Poly[] rgPoly = rgIMD[cur].GetPoly();
                if (rgPoly.Length > 0)
                {
                    index = rgPoly.Length;
                    Array.Copy(rgPoly, buffer, index);
                }

                bottomToolStripStatusLabel.Text = Path.GetFileName(rgIMD[cur].path);
            }
            else
            {
                bottomToolStripStatusLabel.Text = "Image corruption : " + Path.GetFileName(rgIMD[cur].path);
            }

            DrawPanel(-1);
            OperateClick();

            if (ava == cur)
            {
                FindAva();
            }

            nextButton.Enabled = (cur + 1) < rgIMD.Length;
            preButton.Enabled = cur > 0;
        }

        private void SaveImg()
        {
            if (rgIMD != null)
            {
                rgIMD[cur].SetRect(buffer, index);
                rgIMD[cur].SaveMetaDate();
            }

            bmp = null;
            index = 0;
        }

        private void Finish()
        {
            SaveImg();
            OperateClick();

            rgIMD = null;

            nextButton.Enabled = false;
            preButton.Enabled = false;

            mainPictureBox.Image = null;
            bottomToolStripStatusLabel.Text = null;
        }

        public MainForm()
        {
            InitializeComponent();

            maxH = mainPictureBox.Height;
            maxW = mainPictureBox.Width;
        }
        
        private void loadDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finish();

            if (dlgChooseDirectory.ShowDialog() == DialogResult.OK)
            {
                Initialize(dlgChooseDirectory.SelectedPath);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bottomToolStripStatusLabel.Text = "Welcome.";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            SaveImg();
            ++cur;
            if (ava < 0)
            {
                ava = cur;
            }
            LoadImg();
        }

        private void preButton_Click(object sender, EventArgs e)
        {
            SaveImg();
            --cur;
            if (ava < 0)
            {
                ava = cur;
            }
            LoadImg();
        }

        private void availableButton_Click(object sender, EventArgs e)
        {
            SaveImg();
            cur = ava;
            LoadImg();
        }

        private void mainPictureBox_Click(object sender, MouseEventArgs e)
        {
            if (e.X < rgIMD[cur].w+2*extend && e.Y < rgIMD[cur].h+2*extend)
            {
                ptr++;
                if (ptr < 2)
                    clkpoint[ptr] = new Point(e.X, e.Y);

                sealButton.Enabled = false;
                if (0 == ptr)
                {
                    undoButton.Enabled = false;
                    clearButton.Enabled = false;
                    redrawButton.Enabled = true;
                }
                else if (1 == ptr)
                {
                    sealButton.Enabled = true;
                }
                else if (2 == ptr)
                {
                    Bitmap dest = (Bitmap)bmp.Clone();
                    Graphics g = Graphics.FromImage(dest);
                    Pen p = new Pen(Color.Blue, 1);
                    if (clkpoint[1].X < clkpoint[0].X)
                    {
                        newpoint[0] = new Point(clkpoint[1].X, clkpoint[1].Y);
                        newpoint[2] = new Point(clkpoint[0].X, clkpoint[0].Y);
                    }
                    else
                    {
                        newpoint[0] = new Point(clkpoint[0].X, clkpoint[0].Y);
                        newpoint[2] = new Point(clkpoint[1].X, clkpoint[1].Y);
                    }
                    double pang = Math.Atan2((double)(e.Y - newpoint[0].Y), (double)(e.X - newpoint[0].X));
                    ang = (int)(pang / Math.PI * 180.0);
                    Click2Label.Text = "" + ang + "°";
                    if (ang == 0 || ang == 90 || ang == -90)
                    {
                        newpoint[1] = new Point(newpoint[0].X, newpoint[2].Y);
                        newpoint[3] = new Point(newpoint[2].X, newpoint[0].Y);
                    }
                    else
                    {
                        double alp = ang / 180.0 * Math.PI;
                        double beta = Math.Atan2((double)(newpoint[2].Y - newpoint[0].Y), (double)(newpoint[2].X - newpoint[0].X));
                        double le = Math.Sqrt((newpoint[2].Y - newpoint[0].Y) * (newpoint[2].Y - newpoint[0].Y) + (newpoint[2].X - newpoint[0].X) * (newpoint[2].X - newpoint[0].X));
                        int mx = (int)(le * Math.Cos(alp - beta) * Math.Cos(alp));
                        int my = (int)(le * Math.Cos(alp - beta) * Math.Sin(alp));
                        newpoint[1] = new Point(newpoint[0].X + mx, newpoint[0].Y + my);
                        newpoint[3] = new Point(newpoint[2].X - mx, newpoint[2].Y - my);
                    }
                    g.DrawPolygon(p, newpoint);
                    g.Dispose();
                    p.Dispose();
                    Graphics g1 = this.mainPictureBox.CreateGraphics();
                    g1.DrawImage(dest, new Point(0, 0));
                    g1.Dispose();
                    dest.Dispose();
                    sealButton.Enabled = false;
                    Confirm.Enabled = true;
                }
            }
        }

        private void mainPictureBox_Move(object sender, MouseEventArgs e)
        {
            if (e.X < rgIMD[cur].w + 2 * extend && e.Y < rgIMD[cur].h + 2 * extend)
            {
                this.Cursor = Cursors.Cross;
                Click0Label.Text = "" + e.X + "/" + (rgIMD[cur].w + 2 * extend) + ", " + e.Y + "/" + (rgIMD[cur].w + 2 * extend);

                if (ptr == -1)
                {
                    Bitmap dest = (Bitmap)bmp.Clone();
                    Graphics g = Graphics.FromImage(dest);
                    Pen p = new Pen(Color.Blue, 1);
                    g.DrawLine(p, new Point(e.X, e.Y - 20), new Point(e.X, e.Y + 20));
                    g.DrawLine(p, new Point(e.X - 20, e.Y), new Point(e.X + 20, e.Y));
                    g.Dispose();
                    p.Dispose();
                    Graphics g1 = this.mainPictureBox.CreateGraphics();
                    g1.DrawImage(dest, new Point(0, 0));
                    g1.Dispose();
                    dest.Dispose();
                }
                else if (ptr == 0) {
                    Bitmap dest = (Bitmap)bmp.Clone();
                    Graphics g = Graphics.FromImage(dest);
                    Pen p = new Pen(Color.Blue, 1);
                    newpoint[0] = clkpoint[0];
                    newpoint[2].X = e.X;
                    newpoint[2].Y = e.Y;
                    newpoint[1].X = clkpoint[0].X;
                    newpoint[1].Y = e.Y;
                    newpoint[3].X = e.X;
                    newpoint[3].Y = clkpoint[0].Y;
                    g.DrawPolygon(p, newpoint);
                    g.Dispose();
                    p.Dispose();
                    Graphics g1 = this.mainPictureBox.CreateGraphics();
                    g1.DrawImage(dest, new Point(0, 0));
                    g1.Dispose();
                    dest.Dispose();
                }
                else if (ptr == 1)
                {
                    Bitmap dest = (Bitmap)bmp.Clone();
                    Graphics g = Graphics.FromImage(dest);
                    Pen p = new Pen(Color.Blue, 1);
                    if (clkpoint[1].X < clkpoint[0].X)
                    {
                        newpoint[0] = new Point(clkpoint[1].X, clkpoint[1].Y);
                        newpoint[2] = new Point(clkpoint[0].X, clkpoint[0].Y);
                    }
                    else
                    {
                        newpoint[0] = new Point(clkpoint[0].X, clkpoint[0].Y);
                        newpoint[2] = new Point(clkpoint[1].X, clkpoint[1].Y);
                    }
                    double pang = Math.Atan2((double)(e.Y - newpoint[0].Y), (double)(e.X - newpoint[0].X));
                    ang = (int)(pang / Math.PI * 180.0);
                    Click2Label.Text = "" + ang + "°";
                    if (ang == 0 || ang == 90 || ang == -90)
                    {
                        newpoint[1] = new Point(newpoint[0].X, newpoint[2].Y);
                        newpoint[3] = new Point(newpoint[2].X, newpoint[0].Y);
                    }
                    else
                    {
                        double alp = ang / 180.0 * Math.PI;
                        double beta = Math.Atan2((double)(newpoint[2].Y - newpoint[0].Y), (double)(newpoint[2].X - newpoint[0].X));
                        double le = Math.Sqrt((newpoint[2].Y - newpoint[0].Y) * (newpoint[2].Y - newpoint[0].Y) + (newpoint[2].X - newpoint[0].X) * (newpoint[2].X - newpoint[0].X));
                        int mx = (int)(le * Math.Cos(alp - beta) * Math.Cos(alp));
                        int my = (int)(le * Math.Cos(alp - beta) * Math.Sin(alp));
                        newpoint[1] = new Point(newpoint[0].X + mx, newpoint[0].Y + my);
                        newpoint[3] = new Point(newpoint[2].X - mx, newpoint[2].Y - my);
                    }
                    g.DrawPolygon(p,newpoint);
                    g.Dispose();
                    p.Dispose();
                    Graphics g1 = this.mainPictureBox.CreateGraphics();
                    g1.DrawImage(dest, new Point(0, 0));
                    g1.Dispose();
                    dest.Dispose();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                Click0Label.Text = "" + e.X + "/" + (rgIMD[cur].w + 2 * extend) + ", " + e.Y + "/" + (rgIMD[cur].w + 2 * extend);
            }
        }

        private void buttonPanel_Move(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mainMenuStrip_Move(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finish();
            this.Dispose();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(rgIMD[cur].GetImg());
            --index;
            DrawPanel(-1);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(rgIMD[cur].GetImg());
            index = 0;
            DrawPanel(-1);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSuf = "";
            foreach (string suf in rgSuffix)
            {
                strSuf += suf + " ";
            }
            MessageBox.Show("Image Labeling Toolbox V1.25 (4 Points Polygon + 2 Points Rectangle). \n" 
                            + "Designed by Cao Yang. \n"
                            + "Max Label : " + maxLebel + "\n"
                            + "Suffix : " + strSuf);
        }

        private void redrawButton_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = bmp;
            OperateClick();
        }

        private void sealButton_Click(object sender, EventArgs e)
        {
            if (1 == ptr && clkpoint[0].X != clkpoint[1].X && clkpoint[0].Y != clkpoint[1].Y)
            {
                newpoint[0] = clkpoint[0];
                newpoint[2] = clkpoint[1];
                newpoint[1].X = clkpoint[0].X;
                newpoint[1].Y = clkpoint[1].Y;
                newpoint[3].X = clkpoint[1].X;
                newpoint[3].Y = clkpoint[0].Y;
                ang = 0;
                Bitmap dest = (Bitmap)bmp.Clone();
                Graphics g = Graphics.FromImage(dest);
                Pen p = new Pen(Color.Blue, 1);
                g.DrawPolygon(p, newpoint);
                g.Dispose();
                p.Dispose();
                Graphics g1 = this.mainPictureBox.CreateGraphics();
                g1.DrawImage(dest, new Point(0, 0));
                g1.Dispose();
                dest.Dispose();
                ptr = 2;
                sealButton.Enabled = false;
                Confirm.Enabled = true;
                Click2Label.Text = "" + ang + "°";
            }
            else
            {
                MessageBox.Show("Wrong Seal!");
            }
            //OperateClick();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            buffer[index] = new Poly(clkpoint, ang);
            ++index;
            Zoom f = new Zoom(index);       
            f.mf = this;
            Image img = new Bitmap(800,600);
            Image org = new Bitmap(rgIMD[cur].GetImg());
            Graphics g = Graphics.FromImage(img);
            int lx, rx, ly, ry;
            double ra, rax, ray;
            lx = Math.Min(newpoint[0].X, newpoint[1].X); lx = Math.Min(lx, newpoint[2].X); lx = Math.Min(lx, newpoint[3].X);
            rx = Math.Max(newpoint[0].X, newpoint[1].X); rx = Math.Max(rx, newpoint[2].X); rx = Math.Max(rx, newpoint[3].X);
            ly = Math.Min(newpoint[0].Y, newpoint[1].Y); ly = Math.Min(ly, newpoint[2].Y); ly = Math.Min(ly, newpoint[3].Y);
            ry = Math.Max(newpoint[0].Y, newpoint[1].Y); ry = Math.Max(ry, newpoint[2].Y); ry = Math.Max(ry, newpoint[3].Y);
            rax = 800.0 / (double)(rx - lx);
            ray = 600.0 / (double)(ry - ly);
            ra = Math.Min(rax, ray);
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(org, new Rectangle(0, 0, (int)(ra*(rx-lx)), (int)(ra*(ry-ly))), new Rectangle(lx,ly,rx-lx,ry-ly), GraphicsUnit.Pixel);
            f.setdata(ra,lx,ly);
            f.Zoompicbox.Image = img;
            f.Show();
            AddPoly();
            selected = -1;
            OperateClick();
        }

        public void updatename(String orcname, int textidx)
        {
            buffer[textidx - 1].name = orcname;
        }
        public int getang()
        {
            return buffer[index - 1].angle;
        }

        public void UpdatePanel()
        {
            OperateClick();
            bmp = new Bitmap(rgIMD[cur].GetImg());
            DrawPanel(-1);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finish();
            if (dlgChooseDirectory.ShowDialog() == DialogResult.OK)
            {
                Initialize(dlgChooseDirectory.SelectedPath);
            }
        }

        private void exitToolStripMenu_Click(object sender, EventArgs e)
        {
            Finish();
            this.Dispose();
        }

        private void avaitext_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = avaitext.SelectedIndex;
            deletetext.Enabled = true;
            edittext.Enabled = true;
            this.buttonPanel.Focus();
            DrawPanel(selected);
        }

        private void deletetext_Click(object sender, EventArgs e)
        {
            for (int i = selected; i < index - 1; i++)
            {
                buffer[i] = buffer[i + 1].Clone();
            }
            index--;
            selected = -1;
            OperateClick();
            bmp = new Bitmap(rgIMD[cur].GetImg());
            DrawPanel(-1);
        }

        private void edittext_Click(object sender, EventArgs e)
        {
            Zoom f = new Zoom(selected + 1);
            f.mf = this;
            Image img = new Bitmap(800, 600);
            Image org = new Bitmap(rgIMD[cur].GetImg());
            Graphics g = Graphics.FromImage(img);
            int lx, rx, ly, ry;
            double ra, rax, ray;
            Point[] newp = new Point[4];
            newp[0] = new Point(buffer[selected].rgP[0].X, buffer[selected].rgP[0].Y);
            newp[2] = new Point(buffer[selected].rgP[1].X, buffer[selected].rgP[1].Y);
            if (buffer[selected].angle == 0 || buffer[selected].angle == 90 || buffer[selected].angle == -90)
            {
                newp[1] = new Point(newp[0].X, newp[2].Y);
                newp[3] = new Point(newp[2].X, newp[0].Y);
            }
            else
            {
                double alp = buffer[selected].angle / 180.0 * Math.PI;
                double beta = Math.Atan2((double)(newp[2].Y - newp[0].Y), (double)(newp[2].X - newp[0].X));
                double le = Math.Sqrt((newp[2].Y - newp[0].Y) * (newp[2].Y - newp[0].Y) + (newp[2].X - newp[0].X) * (newp[2].X - newp[0].X));
                int mx = (int)(le * Math.Cos(alp - beta) * Math.Cos(alp));
                int my = (int)(le * Math.Cos(alp - beta) * Math.Sin(alp));
                newp[1] = new Point(newp[0].X + mx, newp[0].Y + my);
                newp[3] = new Point(newp[2].X - mx, newp[2].Y - my);
            }
            lx = Math.Min(newp[0].X, newp[1].X); lx = Math.Min(lx, newp[2].X); lx = Math.Min(lx, newp[3].X);
            rx = Math.Max(newp[0].X, newp[1].X); rx = Math.Max(rx, newp[2].X); rx = Math.Max(rx, newp[3].X);
            ly = Math.Min(newp[0].Y, newp[1].Y); ly = Math.Min(ly, newp[2].Y); ly = Math.Min(ly, newp[3].Y);
            ry = Math.Max(newp[0].Y, newp[1].Y); ry = Math.Max(ry, newp[2].Y); ry = Math.Max(ry, newp[3].Y);
            rax = 800.0 / (double)(rx - lx);
            ray = 600.0 / (double)(ry - ly);
            ra = Math.Min(rax, ray);
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(org, new Rectangle(0, 0, (int)(ra * (rx - lx)), (int)(ra * (ry - ly))), new Rectangle(lx, ly, rx - lx, ry - ly), GraphicsUnit.Pixel);
            f.setdata(ra, lx, ly);
            f.setstr(buffer[selected].name);
            f.Zoompicbox.Image = img;
            f.Show();
            selected = -1;
            OperateClick();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            rgIMD[cur].deldetimg();
            ++cur;
            if (ava < 0)
            {
                ava = cur;
            }
            LoadImg();
        }
    }
}

