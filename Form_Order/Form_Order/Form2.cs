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
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
        List<OrderedCargo> cargos = new List<OrderedCargo>();
        private void btnAddcargo_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < cargoGrid.RowCount-1; i++)
                {
                    if (txtC.Text == cargoGrid.Rows[i].Cells[0].Value.ToString())
                    {
                        cargoGrid.Rows[i].Cells[2].Value = Int32.Parse(cargoGrid.Rows[i].Cells[2].Value.ToString()) + Int32.Parse(txtNum.Text);
                        return;
                    }
                }
            cargoGrid.Rows.Add();
            cargoGrid.Rows[cargoGrid.Rows.Count - 2].Cells[0].Value = txtC.Text;
            cargoGrid.Rows[cargoGrid.Rows.Count - 2].Cells[1].Value = txtPrice.Text;
            cargoGrid.Rows[cargoGrid.Rows.Count - 2].Cells[2].Value = txtNum.Text;
            OrderedCargo cargo = new OrderedCargo(txtC.Text, double.Parse(txtPrice.Text), Int32.Parse(txtNum.Text));
            cargos.Add(cargo);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Detail detail = new Detail(cargos, txtG.Text, txtR.Text);
            Order order = new Order(Int32.Parse(txtID.Text), detail);
            bool Badd=true;
            int i;
            for(i =0; i<Form1.orders.Count;i++)
            {
                Console.WriteLine(Form1.orders[i].ID);
                if (order.ID== Form1.orders[i].ID)
                {
                    Badd = false;
                    break;
                }
            }
            Console.WriteLine(Int32.Parse(txtID.Text));
            if (Badd)
            {
                Form1.orders.Add(order);
                Service.Export(Form1.orders);
                this.Close();
            }
            else
            {
                Form1.orders[i] = order;
                Service.Export(Form1.orders);
                MessageBox.Show("订单修改完成");
            }
            form1.Boxinit();
            form1.init();
        }
    }
}
