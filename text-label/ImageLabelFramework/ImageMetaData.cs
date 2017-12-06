using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageLabelFramework
{
    struct Poly
    {
        public int angle;
        public Point[] rgP;
        public String name;

        public Poly(int x0, int y0, int x1, int y1, int ang)
        {
            angle = ang;
            rgP = new Point[2];
            rgP[0] = new Point(x0, y0);
            rgP[1] = new Point(x1, y1);
            name = "BLANK";
        }

        public Poly(Point[] _rgP, int ang)
        {
            angle = ang;
            rgP = new Point[2];
            for (int i = 0; i < 2; ++i)
            {
                rgP[i] = new Point(_rgP[i].X, _rgP[i].Y);
            }
            name = "BLANK";
        }

        public Poly(int x0, int y0, int x1, int y1, int ang, String na)
        {
            angle = ang;
            rgP = new Point[2];
            rgP[0] = new Point(x0, y0);
            rgP[1] = new Point(x1, y1);
            name = na;
        }

        public Poly Clone()
        {
            Poly tmp = new Poly(rgP[0].X, rgP[0].Y, rgP[1].X, rgP[1].Y, angle, name);
            return tmp;
        }
    }

    class ImgMetaData
    {
        public string path = null;
        public string metaPath = null;
        public string raw_name = null;

        private Image img = null;
        //private List<Rect> vRect = null;
        private List<Poly> vPoly = null;

        public int height, width;
        public int h, w;
        public float ratio;

        public static int extend = 20;

        public ImgMetaData(string _path)
        {
            path = _path;
            metaPath = path.Replace(Path.GetExtension(path), ".txt");
            vPoly = new List<Poly>();

            if (File.Exists(metaPath))
            {
                try
                {
                    string[] rg_parts;
                    using (StreamReader sr = new StreamReader(metaPath))
                    {
                        raw_name = sr.ReadLine().Trim();

                        rg_parts = sr.ReadLine().Split('\t');
                        width = Convert.ToInt32(rg_parts[0]); 
                        height = Convert.ToInt32(rg_parts[1]);

                        int count = Convert.ToInt32(sr.ReadLine());
                        for (int i = 0; i < count; ++i)
                        {
                            int angle = Convert.ToInt32(sr.ReadLine());
                            rg_parts = sr.ReadLine().Split('\t');
                            String stname = Convert.ToString(sr.ReadLine());
                            vPoly.Add(new Poly(Convert.ToInt32(rg_parts[0]),
                                Convert.ToInt32(rg_parts[1]),
                                Convert.ToInt32(rg_parts[2]),
                                Convert.ToInt32(rg_parts[3]),
                                angle,stname));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Read Error!");
                    vPoly.Clear();
                }
            }
            else
            {
                raw_name = Path.GetFileNameWithoutExtension(path);
            }
        }

        public void SaveMetaDate()
        {
            using (StreamWriter sw = new StreamWriter(metaPath, false))
            {
                sw.WriteLine(raw_name);
                sw.WriteLine("" + width + "\t" + height);
                sw.WriteLine(vPoly.Count);
                foreach (Poly poly in vPoly)
                {
                    sw.WriteLine(poly.angle);
                    foreach (Point p in poly.rgP)
                    {
                        sw.Write("" + p.X + "\t" + p.Y + "\t");
                    }
                    sw.WriteLine();
                    sw.WriteLine(poly.name);
                }
            }
        }

        public bool IsEmpty()
        {
            return vPoly.Count == 0;
        }

        public void deldetimg()
        {
            img.Dispose();
            img = null;
            File.Delete(path);
            File.Delete(metaPath);
            path = null;
            metaPath = null;
        }

        public Image GetImg()
        {
            Image tmp_img = null;
            if (null == img)
            {
                try
                {
                    img = Image.FromFile(path);
                    ratio = 1.0f;
                    height = img.Height;
                    width = img.Width;
                    //MessageBox.Show(MainForm.maxH.ToString() + "," + MainForm.maxW.ToString());

                    if (1.0 * height / (MainForm.maxH-2*extend) > 1.0 * width / (MainForm.maxW-2*extend))
                    {
                        if (height > (MainForm.maxH-2*extend))
                        {
                            ratio = 1.0f * (MainForm.maxH-2*extend) / height;
                        }
                    }
                    else
                    {
                        if (width > (MainForm.maxW-2*extend))
                        {
                            ratio = 1.0f * (MainForm.maxW-2*extend) / width;
                        }
                    }
                    //tmp_img = (Bitmap)img.Clone();

                    if (ratio < 1.0f)
                    {
                        //MessageBox.Show("ERROR");
                        Image souImg = img;
                        h = Convert.ToInt32(ratio * height);
                        w = Convert.ToInt32(ratio * width);
                        tmp_img = new Bitmap(w+2*extend, h+2*extend);
                        //MessageBox.Show((h+extend).ToString() + "," + (w+extend).ToString());
                        Graphics g = Graphics.FromImage(tmp_img);
                        g.Clear(Color.White);
                        g.InterpolationMode = InterpolationMode.High;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(souImg, new Rectangle(extend, extend, w, h), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        Image souImg = img;
                        h = height;
                        w = width;
                        //MessageBox.Show(h.ToString()+","+w.ToString());
                        tmp_img = new Bitmap(w + 2 * extend, h + 2 * extend);
                        Graphics g = Graphics.FromImage(tmp_img);
                        g.Clear(Color.White);
                        g.DrawImage(souImg, new Rectangle(extend, extend, w, h), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                    }
                }
                catch
                {
                    img = null;
                }
            }
            img.Dispose();
            img = null;
            return tmp_img;
        }

        public int GetCount()
        {
            return vPoly.Count;
        }

        public Poly[] GetPoly()
        {
            Poly[] tmp = vPoly.ToArray();

            for (int i = 0; i < tmp.Length; ++i)
            {
                for (int j = 0; j < tmp[i].rgP.Length; ++j)
                {
                    tmp[i].rgP[j].X = (int)Math.Round(tmp[i].rgP[j].X * ratio + extend);
                    tmp[i].rgP[j].Y = (int)Math.Round(tmp[i].rgP[j].Y * ratio + extend);
                }
            }

            return tmp;
        }

        public void SetRect(Poly[] rgPoly, int len)
        {
            vPoly.Clear();
            for (int i = 0; i < len; ++i)
            {
                vPoly.Add(new Poly((int)Math.Round((rgPoly[i].rgP[0].X - extend) / ratio),
                    (int)Math.Round((rgPoly[i].rgP[0].Y - extend) / ratio),
                    (int)Math.Round((rgPoly[i].rgP[1].X - extend) / ratio),
                    (int)Math.Round((rgPoly[i].rgP[1].Y - extend) / ratio),
                    rgPoly[i].angle,
                    rgPoly[i].name));
            }
        }
    }
}
