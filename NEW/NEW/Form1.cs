using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String TextFileDta = "ggg";
        string path = @"C:\Users\planet_WN\Desktop\TEST.kml";


        private void button1_Click(object sender, EventArgs e)
        {
            String pathOfFile = "C:\\Users\\planet_WN\\Desktop\\TEST.xlsx";
            System.Data.OleDb.OleDbConnection mCon;
            mCon = new System.Data.OleDb.OleDbConnection();
            mCon.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + pathOfFile + ";Extended Properties=\"Excel 12.0;HDR=YES\";");


            DataTable Contents = new DataTable();
            using (System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("Select * From [Sheet1$]", mCon))
            {
                adapter.Fill(Contents);
            }
            label1.Text = Contents.Rows[0][1].ToString();

            float lat = Convert.ToInt32(Contents.Rows[0][1]);
            float log = Convert.ToInt32(Contents.Rows[0][2]);
            int deg = Convert.ToInt32(Contents.Rows[0][4]);


            int n = 20;
            float x, s = 0.0f, t;
            x = (float)Math.PI * deg / 180f;
            s = x;
            t = x;
            for (int i = 1; i <= n; i++)
            {
                t = (-t * x * x) / ((2 * i) * (2 * i + 1));
                s = s + t;
            }
            label2.Text = "Value of Sin(" + deg + ") = " + s;


            float Xlat = lat + 1*s;

            label3.Text = "X = " + Xlat;

            TextFileDta = "helooo";


            mCon.Close();
        }















        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Close();
                }
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.Write(TextFileDta);
                }
            }
            else
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.Write(TextFileDta);
                }
            }
        }










        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        label4.Text = s.ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find the kmk file...!" + Environment.NewLine + "Create the kml file first.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }












    }
}
