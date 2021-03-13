using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase.DataInfo;
using DataBase.Models;

namespace DataBase
{
    public partial class Mainmenu : Form
    {
        public const int totalRecords = 25;
        public const int pageSize = 10;
        private int offset = 0;
        internal object labelstatus;

        public Mainmenu()
        {
            InitializeComponent();
            if (Datausers.IsCreateUser)
            {
                Datausers datas = new Datausers();
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Index" });
                Datausers.IsCreateUser = false;
            }
            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.DataSource = new PageOffsetList();
        }

        public void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

            var records = new List<user>();
            offset = (int)bindingSource1.Current;
            int offsetPlus = offset;
            for (int i = offset; i < offset + pageSize && i < Datausers.Users.Count; i++)
            {
                if (Datausers.Users.Last() == Datausers.Users.ElementAt(i))
                {
                    records.Add(Datausers.Users.ElementAt(i));
                    break;
                }
                records.Add(Datausers.Users.ElementAt(i));
                offsetPlus++;
            }
            offset = offsetPlus;
            dataGridView1.DataSource = records;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            INFO ninfo = new INFO(this);
            this.Hide();
            ninfo.Show();
        }
        private void Mainmenu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        class Record
        {
            public int Index { get; set; }
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }
        public void usersBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    }
}
