using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageLabelFramework
{
    public partial class Zoom : Form
    {
        static private Pen pen = new Pen(Brushes.Red, 3);
        public MainForm mf;
        private String name;
        private int ptr = -1;
        private Point[] stack = new Point[100];
        private int dx, dy;
        private double ratio;
        private int idx;

        public Zoom(int index)
        {
            InitializeComponent();
            idx = index;
            CancelButton = confirmstring;
        }

        private void Zoom_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void confirmstring_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MainForm.orcname);
            name = enterstring.Text;
            confirmstring.Enabled = false;
            mf.updatename(name, idx);
            mf.UpdatePanel();
            this.Close();
        }

        public void setdata(double ra, int x, int y)
        {
            ratio = ra;
            dx = x;
            dy = y;
        }
        public void setstr(String st)
        {
            enterstring.Text = st;
        }
    }
}
