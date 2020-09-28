namespace Form_Order
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.cargoGrid = new System.Windows.Forms.DataGridView();
            this.btnAddcargo = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cargoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "顾客名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "备注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "商品";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "单价";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "数量";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(37, 58);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 21);
            this.txtID.TabIndex = 6;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(325, 58);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(100, 21);
            this.txtG.TabIndex = 7;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(37, 118);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(100, 21);
            this.txtC.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(202, 118);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 21);
            this.txtPrice.TabIndex = 9;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(349, 118);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 21);
            this.txtNum.TabIndex = 10;
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(37, 359);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(412, 21);
            this.txtR.TabIndex = 11;
            // 
            // cargoGrid
            // 
            this.cargoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cargoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CName,
            this.Price,
            this.Num});
            this.cargoGrid.Location = new System.Drawing.Point(37, 145);
            this.cargoGrid.Name = "cargoGrid";
            this.cargoGrid.RowTemplate.Height = 23;
            this.cargoGrid.Size = new System.Drawing.Size(412, 196);
            this.cargoGrid.TabIndex = 12;
            // 
            // btnAddcargo
            // 
            this.btnAddcargo.Location = new System.Drawing.Point(466, 116);
            this.btnAddcargo.Name = "btnAddcargo";
            this.btnAddcargo.Size = new System.Drawing.Size(75, 23);
            this.btnAddcargo.TabIndex = 13;
            this.btnAddcargo.Text = "添加商品";
            this.btnAddcargo.UseVisualStyleBackColor = true;
            this.btnAddcargo.Click += new System.EventHandler(this.btnAddcargo_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(629, 357);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrder.TabIndex = 14;
            this.btnAddOrder.Text = "添加订单";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // CName
            // 
            this.CName.HeaderText = "商品名";
            this.CName.Name = "CName";
            // 
            // Price
            // 
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            // 
            // Num
            // 
            this.Num.HeaderText = "数量";
            this.Num.Name = "Num";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnAddcargo);
            this.Controls.Add(this.cargoGrid);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.cargoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.DataGridView cargoGrid;
        private System.Windows.Forms.Button btnAddcargo;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
    }
}