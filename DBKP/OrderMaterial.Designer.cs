
namespace DBKP
{
    partial class OrderMaterial
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
            this.MaterialIDUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.QuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MakeOrderMaterialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialIDUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MaterialIDUpDown
            // 
            this.MaterialIDUpDown.Location = new System.Drawing.Point(36, 45);
            this.MaterialIDUpDown.Name = "MaterialIDUpDown";
            this.MaterialIDUpDown.Size = new System.Drawing.Size(227, 22);
            this.MaterialIDUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Номенклатуры";
            // 
            // QuantityUpDown
            // 
            this.QuantityUpDown.Location = new System.Drawing.Point(36, 111);
            this.QuantityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityUpDown.Name = "QuantityUpDown";
            this.QuantityUpDown.Size = new System.Drawing.Size(227, 22);
            this.QuantityUpDown.TabIndex = 2;
            this.QuantityUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество";
            // 
            // MakeOrderMaterialButton
            // 
            this.MakeOrderMaterialButton.Location = new System.Drawing.Point(36, 158);
            this.MakeOrderMaterialButton.Name = "MakeOrderMaterialButton";
            this.MakeOrderMaterialButton.Size = new System.Drawing.Size(227, 39);
            this.MakeOrderMaterialButton.TabIndex = 4;
            this.MakeOrderMaterialButton.Text = "Заказать";
            this.MakeOrderMaterialButton.UseVisualStyleBackColor = true;
            this.MakeOrderMaterialButton.Click += new System.EventHandler(this.MakeOrderMaterialButton_Click);
            // 
            // OrderMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 211);
            this.Controls.Add(this.MakeOrderMaterialButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuantityUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaterialIDUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OrderMaterial";
            this.Text = "Заказ закупок";
            ((System.ComponentModel.ISupportInitialize)(this.MaterialIDUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MaterialIDUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown QuantityUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MakeOrderMaterialButton;
    }
}