using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using DataBase.Models;
using DataBase.DataInfo;

namespace DataBase
{
    public partial class INFO : Form
    {
        Mainmenu mmenu;
        int i = 0;
        public INFO(Mainmenu mm)
        {
            InitializeComponent();
            this.mmenu = mm;
        }

        public void addinfo_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new user
                {
                    BirthDay = dateTimePicker1.Text,
                    Email = textBox6.Text,
                    FirstName = textBox2.Text,
                    LastName = textBox5.Text,
                    Login = textBox1.Text,
                    Password = textBox4.Text,
                    PhoneNumber = maskedTextBox1.Text,
                    Religion = textBox7.Text

                };

                // Datausers.Users.Add(new user { Index = i });
                Datausers.Users.Add(user);
                i++;
                Mainmenu listForm = new Mainmenu();
                listForm.Show();
                this.Hide();

            }
            catch (ArgumentOutOfRangeException)
            { Close(); }
        }
        private void INFO_Load(object sender, EventArgs e)
        {

        }
    }
}
