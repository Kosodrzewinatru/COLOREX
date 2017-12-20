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
using System.Data.SqlClient;
using System.Net;

namespace paint
{
    public partial class Form3 : MaterialForm
    {
        //private tekst;
        //public  Tekst      

        public Form3()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
          

            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Piotr Sienkiewicz\Desktop\C#\paint\paint\bin\Debug\config.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            SqlCommand command = new SqlCommand("select * from TableOptions", conn);
        
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            cs = textBox1.Text;



            /*
            while (reader.Read())
            {
                Class1 w = new Class1();
                w.Tekst = reader.GetString(1);
                Class1.Add(w);


                string cs2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Piotr Sienkiewicz\Desktop\C#\paint\paint\bin\Debug\config.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection conn2 = new SqlConnection(cs2);
                conn.Open();

                SqlCommand command2 = new SqlCommand($"insert into TableOptions(tekst) values({ w.Tekst })", conn);

                command.ExecuteNonQuery();
                conn.Close();
                
            }
            */

        }

    }
}
