
namespace DBKP
{
    partial class RemoveMaterial
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
            this.RemovingMaterialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialIDUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MaterialIDUpDown
            // 
            this.MaterialIDUpDown.Location = new System.Drawing.Point(44, 49);
            this.MaterialIDUpDown.Name = "MaterialIDUpDown";
            this.MaterialIDUpDown.Size = new System.Drawing.Size(254, 22);
            this.MaterialIDUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Номенклатуры";
            // 
            // QuantityUpDown
            // 
            this.QuantityUpDown.Location = new System.Drawing.Point(44, 102);
            this.QuantityUpDown.Name = "QuantityUpDown";
            this.QuantityUpDown.Size = new System.Drawing.Size(254, 22);
            this.QuantityUpDown.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество";
            // 
            // RemovingMaterialButton
            // 
            this.RemovingMaterialButton.Location = new System.Drawing.Point(44, 147);
            this.RemovingMaterialButton.Name = "RemovingMaterialButton";
            this.RemovingMaterialButton.Size = new System.Drawing.Size(254, 44);
            this.RemovingMaterialButton.TabIndex = 4;
            this.RemovingMaterialButton.Text = "Списать";
            this.RemovingMaterialButton.UseVisualStyleBackColor = true;
            this.RemovingMaterialButton.Click += new System.EventHandler(this.RemovingMaterialButton_Click);
            // 
            // RemoveMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 208);
            this.Controls.Add(this.RemovingMaterialButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuantityUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaterialIDUpDown);
            this.Name = "RemoveMaterial";
            this.Text = "RemoveMaterial";
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
        private System.Windows.Forms.Button RemovingMaterialButton;
    }
}