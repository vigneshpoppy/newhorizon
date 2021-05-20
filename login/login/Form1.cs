using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.UserName = textBox1.Text;
            l.Password = textBox2.Text;
            loginDAL dal = new loginDAL();
               bool res= dal.InsertData(l);
            if (res)
            {
                MessageBox.Show("id created");

            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        string  UserName = textBox1.Text;
           string Password = textBox2.Text;
            loginDAL dal = new loginDAL();
            bool res = dal.check(UserName, Password);

            if (dal.Statuscheck)
            {
                if (res)
                {
                    DashboardForm from1 = new DashboardForm();
                    dal.Statuscheck = false;
                    from1.Show();
                    dal.Statuscheck = false;
                    MessageBox.Show("logged in");
                   
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            else
            {
                MessageBox.Show("already logged in");
            }
        }
    }
}
