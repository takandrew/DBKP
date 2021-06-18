
namespace DBKP
{
    partial class MakeOrder
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
            this.MaterialGridView = new System.Windows.Forms.DataGridView();
            this.MaterialUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.QuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MakeOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MaterialGridView
            // 
            this.MaterialGridView.AllowUserToAddRows = false;
            this.MaterialGridView.AllowUserToDeleteRows = false;
            this.MaterialGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaterialGridView.Location = new System.Drawing.Point(229, 24);
            this.MaterialGridView.Name = "MaterialGridView";
            this.MaterialGridView.RowHeadersVisible = false;
            this.MaterialGridView.RowHeadersWidth = 51;
            this.MaterialGridView.RowTemplate.Height = 24;
            this.MaterialGridView.Size = new System.Drawing.Size(331, 242);
            this.MaterialGridView.TabIndex = 0;
            // 
            // MaterialUpDown
            // 
            this.MaterialUpDown.Location = new System.Drawing.Point(49, 79);
            this.MaterialUpDown.Name = "MaterialUpDown";
            this.MaterialUpDown.Size = new System.Drawing.Size(143, 22);
            this.MaterialUpDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Номенклатуры";
            // 
            // QuantityUpDown
            // 
            this.QuantityUpDown.Location = new System.Drawing.Point(49, 137);
            this.QuantityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityUpDown.Name = "QuantityUpDown";
            this.QuantityUpDown.Size = new System.Drawing.Size(143, 22);
            this.QuantityUpDown.TabIndex = 3;
            this.QuantityUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество";
            // 
            // MakeOrderButton
            // 
            this.MakeOrderButton.Location = new System.Drawing.Point(37, 214);
            this.MakeOrderButton.Name = "MakeOrderButton";
            this.MakeOrderButton.Size = new System.Drawing.Size(167, 34);
            this.MakeOrderButton.TabIndex = 5;
            this.MakeOrderButton.Text = "Оформить заказ";
            this.MakeOrderButton.UseVisualStyleBackColor = true;
            this.MakeOrderButton.Click += new System.EventHandler(this.MakeOrderButton_Click);
            // 
            // MakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 296);
            this.Controls.Add(this.MakeOrderButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuantityUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaterialUpDown);
            this.Controls.Add(this.MaterialGridView);
            this.Name = "MakeOrder";
            this.Text = "Оформление заказа";
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MaterialGridView;
        private System.Windows.Forms.NumericUpDown MaterialUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown QuantityUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MakeOrderButton;
    }
}