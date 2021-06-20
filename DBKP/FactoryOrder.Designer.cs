
namespace DBKP
{
    partial class FactoryOrder
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
            this.OrderIDUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.StartFactoringButton = new System.Windows.Forms.Button();
            this.CloseOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrderIDUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderIDUpDown
            // 
            this.OrderIDUpDown.Location = new System.Drawing.Point(68, 79);
            this.OrderIDUpDown.Name = "OrderIDUpDown";
            this.OrderIDUpDown.Size = new System.Drawing.Size(265, 22);
            this.OrderIDUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Созданного заказа";
            // 
            // StartFactoringButton
            // 
            this.StartFactoringButton.Location = new System.Drawing.Point(68, 146);
            this.StartFactoringButton.Name = "StartFactoringButton";
            this.StartFactoringButton.Size = new System.Drawing.Size(265, 34);
            this.StartFactoringButton.TabIndex = 2;
            this.StartFactoringButton.Text = "Начать производство";
            this.StartFactoringButton.UseVisualStyleBackColor = true;
            this.StartFactoringButton.Click += new System.EventHandler(this.StartFactoringButton_Click);
            // 
            // CloseOrderButton
            // 
            this.CloseOrderButton.Location = new System.Drawing.Point(68, 200);
            this.CloseOrderButton.Name = "CloseOrderButton";
            this.CloseOrderButton.Size = new System.Drawing.Size(265, 34);
            this.CloseOrderButton.TabIndex = 3;
            this.CloseOrderButton.Text = "Закрыть заказ";
            this.CloseOrderButton.UseVisualStyleBackColor = true;
            this.CloseOrderButton.Click += new System.EventHandler(this.CloseOrderButton_Click);
            // 
            // FactoryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 277);
            this.Controls.Add(this.CloseOrderButton);
            this.Controls.Add(this.StartFactoringButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrderIDUpDown);
            this.Name = "FactoryOrder";
            this.Text = "Производственный заказ";
            ((System.ComponentModel.ISupportInitialize)(this.OrderIDUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown OrderIDUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartFactoringButton;
        private System.Windows.Forms.Button CloseOrderButton;
    }
}