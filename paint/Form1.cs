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
using MaterialSkin.Controls;

namespace paint
{
    public partial class Form1 : MaterialForm
    {
        public Point current = new Point();
        public Point old = new Point();
        public Pen p = new Pen(Color.Black, 5);
        public Pen gum = new Pen(Color.White, 40);
        public Bitmap bmp;
        public Bitmap bmt;
        //public ColorDialog clrdlg;
        public ColorDialog colorDialog2;
        int x;
        int y;
        //int xc;
        //int yc;
        int n = 0;
        ColorDialog clrdlg;
        

        public Form1()
        {         
            InitializeComponent();

            //clrdlg.Color = Color.White;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmt = new Bitmap(pictureBox2.Width, pictureBox2.Height);

           for (x = 0; x < bmp.Width; x++)
                {
                    for (y = 0; y < bmp.Height; y++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }


            for (x = 0; x < bmt.Width; x++)
            {
                for (y = 0; y < bmt.Height; y++)
                {
                    bmt.SetPixel(x, y, Color.Black);
                }
            }

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

            clrdlg = new ColorDialog();
            clrdlg.Color = Color.White;

           
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (n == 0)
                {
                    current = e.Location;
                    p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawLine(p, old, current);
                    old = current;

                    pictureBox1.Invalidate();
                }
                
            }

            if (e.Button == MouseButtons.Right)
            {
                current = e.Location;
                gum.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawLine(gum, old, current);
                old = current;
                if (clrdlg != null)
                    //gum = new Pen(clrdlg.Color, );
                    gum.Color = clrdlg.Color;
                else
                    //gum = new Pen(colorDialog2.Color, );
                    gum.Color = colorDialog2.Color;

                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            old = e.Location;
        }
        
        // czyszczenie tła zwykłe:

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
         
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, clrdlg.Color);
                }
            }
            
            /*pictureBox1.InitialImage = null;
            pictureBox1.Image = null;*/

            pictureBox1.Invalidate();
        }

        // colordialog dla pędzla:

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                p.Color = cd.Color;
            }

            for (x = 0; x < bmt.Width; x++)
            {
                for (y = 0; y < bmt.Height; y++)
                {
                    bmt.SetPixel(x, y, p.Color);
                }
            }

            pictureBox2.Invalidate();
        }
            // zapisywanie:

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
           
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog.FileName);
            }
        }

        // radiobuttony do grubości pędzla x5:

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 1);
                }
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 5);
                }
            }
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 10);
                }
            }
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 15);
                }
            }
        }

        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 20);
                }
            }
        }

        private void materialRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    p = new Pen(p.Color, 300);
                }
            }
        }
        // wczytywanie obrazów:

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            bmp.MakeTransparent();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)           
                return;

            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            pictureBox1.Invalidate();
        }

        // colordialog dla tło mocne:                                                                                                                                             

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {

            if (clrdlg.ShowDialog() == DialogResult.OK)
            {
                for (x = 0; x < bmp.Width; x++)
                {
                    for (y = 0; y < bmp.Height; y++)
                    {
                      
                        bmp.SetPixel(x, y, clrdlg.Color);
                      
                    }
                }
                
            }

            pictureBox1.Invalidate();
        }

        // czyszczenie tła mocne:

        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, Color.White);
                }
            }
            pictureBox1.Invalidate();
        }

        // colordialog dla tło zwykłe:

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog2 = new ColorDialog();
            colorDialog2.ShowDialog();

            bmp.MakeTransparent();

            /*for (x = 0; x < bmp.Width ; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, colorDialog2.Color);
                }
            }*/

            pictureBox1.BackColor = colorDialog2.Color;

            pictureBox1.Invalidate();

            
        }

        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            
        }

        private void materialFlatButton10_Click(object sender, EventArgs e)
        {
            Form3 frt = new Form3();
            if (frt.ShowDialog() == DialogResult.Cancel)
                return;

        }

        

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmt, 0, 0, bmt.Width, bmt.Height);
        }

        // radiobuttony dla grubości gumki x5:

        private void materialRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 5);
                }
            }
        }

        private void materialRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 10);
                }
            }
        }

        private void materialRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 15);
                }
            }
        }

        private void materialRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 20);
                }
            }
        }

        private void materialRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 25);
                }
            }
        }

        private void materialRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbg = sender as RadioButton;
            if (rbg != null)
            {
                if (rbg.Checked)
                {
                    gum = new Pen(gum.Color, 300);
                }
            }
        }

        //prostokąt:

        private void materialFlatButton11_Click(object sender, EventArgs e)
        {
            
        }
    }
}
