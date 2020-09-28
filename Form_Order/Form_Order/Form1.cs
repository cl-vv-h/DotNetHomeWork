using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Order
{
    public partial class Form1 : Form
    {
        public static List<Order> orders;
        public Form1()
        {
            InitializeComponent();
            orders = Service.Import();
            init();
            Boxinit();
        }
        public void init()
        {
            QueryGrid.Rows.Clear();
            for (int i = 0; i < orders.Count; i++)
            {
                string str = orders[i].ToString();
                string[] strs = str.Split('\t');
                if(QueryGrid.RowCount<=orders.Count)
                    QueryGrid.Rows.Add();
                QueryGrid.Rows[i].Cells[0].Value = strs[0].Split('：')[1];
                QueryGrid.Rows[i].Cells[1].Value = strs[1].Split('：')[1];
                QueryGrid.Rows[i].Cells[2].Value = strs[2].Split('：')[1];
                QueryGrid.Rows[i].Cells[3].Value = orders[i].detail.ToString();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Order> Query = Service.Query(orders, txtSearch.Text);
            freshGird();
            for (int i = 0; i < Query.Count; i++)
            {
                string str = Query[i].ToString();
                string[] strs = str.Split('\t');
                QueryGrid.Rows.Add();
                QueryGrid.Rows[i].Cells[0].Value = strs[0].Split('：')[1];
                QueryGrid.Rows[i].Cells[1].Value = strs[1].Split('：')[1];
                QueryGrid.Rows[i].Cells[2].Value = strs[2].Split('：')[1];
                QueryGrid.Rows[i].Cells[3].Value = orders[i].detail.ToString();
            }
        }

        public void freshGird()
        {
            QueryGrid.Rows.Clear();
        }

        public void Boxinit()
        {
            boxlist.Items.Clear();
            for(int i =0;i<orders.Count;i++)
            {
                boxlist.Items.Add(orders[i].ID);
            }
        }

        private void QueryGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < orders.Count)
            {
                MessageBox.Show(QueryGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for(int i = orders.Count-1;i>=0;i--)
            {
                if (orders[i].ID == Int32.Parse(boxlist.Text))
                    orders.RemoveAt(i);
            }
            init();
            Boxinit();
            Service.Export(orders);
        }
    }
}
