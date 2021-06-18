
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
            this.MakeOrderModifiedButton = new System.Windows.Forms.Button();
            this.ModifiedUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel1 = new System.Windows.Forms.Label();
            this.ModifiedUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel2 = new System.Windows.Forms.Label();
            this.ModifiedUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel3 = new System.Windows.Forms.Label();
            this.ModifiedUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel4 = new System.Windows.Forms.Label();
            this.ModifiedUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel5 = new System.Windows.Forms.Label();
            this.ModifiedUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.ModifiedLabel6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown6)).BeginInit();
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
            // MakeOrderModifiedButton
            // 
            this.MakeOrderModifiedButton.Location = new System.Drawing.Point(188, 525);
            this.MakeOrderModifiedButton.Name = "MakeOrderModifiedButton";
            this.MakeOrderModifiedButton.Size = new System.Drawing.Size(182, 42);
            this.MakeOrderModifiedButton.TabIndex = 6;
            this.MakeOrderModifiedButton.Text = "Оформить заказ на измененной спецификации";
            this.MakeOrderModifiedButton.UseVisualStyleBackColor = true;
            // 
            // ModifiedUpDown1
            // 
            this.ModifiedUpDown1.Location = new System.Drawing.Point(113, 376);
            this.ModifiedUpDown1.Name = "ModifiedUpDown1";
            this.ModifiedUpDown1.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown1.TabIndex = 7;
            // 
            // ModifiedLabel1
            // 
            this.ModifiedLabel1.AutoSize = true;
            this.ModifiedLabel1.Location = new System.Drawing.Point(113, 353);
            this.ModifiedLabel1.Name = "ModifiedLabel1";
            this.ModifiedLabel1.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel1.TabIndex = 8;
            this.ModifiedLabel1.Text = "label3";
            // 
            // ModifiedUpDown2
            // 
            this.ModifiedUpDown2.Location = new System.Drawing.Point(113, 432);
            this.ModifiedUpDown2.Name = "ModifiedUpDown2";
            this.ModifiedUpDown2.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown2.TabIndex = 9;
            // 
            // ModifiedLabel2
            // 
            this.ModifiedLabel2.AutoSize = true;
            this.ModifiedLabel2.Location = new System.Drawing.Point(113, 412);
            this.ModifiedLabel2.Name = "ModifiedLabel2";
            this.ModifiedLabel2.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel2.TabIndex = 10;
            this.ModifiedLabel2.Text = "label4";
            // 
            // ModifiedUpDown3
            // 
            this.ModifiedUpDown3.Location = new System.Drawing.Point(113, 483);
            this.ModifiedUpDown3.Name = "ModifiedUpDown3";
            this.ModifiedUpDown3.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown3.TabIndex = 11;
            // 
            // ModifiedLabel3
            // 
            this.ModifiedLabel3.AutoSize = true;
            this.ModifiedLabel3.Location = new System.Drawing.Point(113, 463);
            this.ModifiedLabel3.Name = "ModifiedLabel3";
            this.ModifiedLabel3.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel3.TabIndex = 12;
            this.ModifiedLabel3.Text = "label5";
            // 
            // ModifiedUpDown4
            // 
            this.ModifiedUpDown4.Location = new System.Drawing.Point(336, 376);
            this.ModifiedUpDown4.Name = "ModifiedUpDown4";
            this.ModifiedUpDown4.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown4.TabIndex = 13;
            // 
            // ModifiedLabel4
            // 
            this.ModifiedLabel4.AutoSize = true;
            this.ModifiedLabel4.Location = new System.Drawing.Point(336, 352);
            this.ModifiedLabel4.Name = "ModifiedLabel4";
            this.ModifiedLabel4.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel4.TabIndex = 14;
            this.ModifiedLabel4.Text = "label6";
            // 
            // ModifiedUpDown5
            // 
            this.ModifiedUpDown5.Location = new System.Drawing.Point(336, 432);
            this.ModifiedUpDown5.Name = "ModifiedUpDown5";
            this.ModifiedUpDown5.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown5.TabIndex = 15;
            // 
            // ModifiedLabel5
            // 
            this.ModifiedLabel5.AutoSize = true;
            this.ModifiedLabel5.Location = new System.Drawing.Point(336, 412);
            this.ModifiedLabel5.Name = "ModifiedLabel5";
            this.ModifiedLabel5.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel5.TabIndex = 16;
            this.ModifiedLabel5.Text = "label7";
            // 
            // ModifiedUpDown6
            // 
            this.ModifiedUpDown6.Location = new System.Drawing.Point(336, 482);
            this.ModifiedUpDown6.Name = "ModifiedUpDown6";
            this.ModifiedUpDown6.Size = new System.Drawing.Size(120, 22);
            this.ModifiedUpDown6.TabIndex = 17;
            // 
            // ModifiedLabel6
            // 
            this.ModifiedLabel6.AutoSize = true;
            this.ModifiedLabel6.Location = new System.Drawing.Point(336, 462);
            this.ModifiedLabel6.Name = "ModifiedLabel6";
            this.ModifiedLabel6.Size = new System.Drawing.Size(46, 17);
            this.ModifiedLabel6.TabIndex = 18;
            this.ModifiedLabel6.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(300, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Выберите нужное количество компонентов:";
            // 
            // MakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 596);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ModifiedLabel6);
            this.Controls.Add(this.ModifiedUpDown6);
            this.Controls.Add(this.ModifiedLabel5);
            this.Controls.Add(this.ModifiedUpDown5);
            this.Controls.Add(this.ModifiedLabel4);
            this.Controls.Add(this.ModifiedUpDown4);
            this.Controls.Add(this.ModifiedLabel3);
            this.Controls.Add(this.ModifiedUpDown3);
            this.Controls.Add(this.ModifiedLabel2);
            this.Controls.Add(this.ModifiedUpDown2);
            this.Controls.Add(this.ModifiedLabel1);
            this.Controls.Add(this.ModifiedUpDown1);
            this.Controls.Add(this.MakeOrderModifiedButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUpDown6)).EndInit();
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
        private System.Windows.Forms.Button MakeOrderModifiedButton;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown1;
        private System.Windows.Forms.Label ModifiedLabel1;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown2;
        private System.Windows.Forms.Label ModifiedLabel2;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown3;
        private System.Windows.Forms.Label ModifiedLabel3;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown4;
        private System.Windows.Forms.Label ModifiedLabel4;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown5;
        private System.Windows.Forms.Label ModifiedLabel5;
        private System.Windows.Forms.NumericUpDown ModifiedUpDown6;
        private System.Windows.Forms.Label ModifiedLabel6;
        private System.Windows.Forms.Label label9;
    }
}