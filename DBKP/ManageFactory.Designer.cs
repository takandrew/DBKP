
namespace DBKP
{
    partial class ManageFactory
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
            this.FactoryIDUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FactoryTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmChangesButton = new System.Windows.Forms.Button();
            this.FactoryStatusTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryIDUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryTimeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FactoryIDUpDown
            // 
            this.FactoryIDUpDown.Location = new System.Drawing.Point(39, 36);
            this.FactoryIDUpDown.Name = "FactoryIDUpDown";
            this.FactoryIDUpDown.Size = new System.Drawing.Size(253, 22);
            this.FactoryIDUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID РЦ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Статус";
            // 
            // FactoryTimeUpDown
            // 
            this.FactoryTimeUpDown.Location = new System.Drawing.Point(39, 159);
            this.FactoryTimeUpDown.Name = "FactoryTimeUpDown";
            this.FactoryTimeUpDown.Size = new System.Drawing.Size(253, 22);
            this.FactoryTimeUpDown.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Время";
            // 
            // ConfirmChangesButton
            // 
            this.ConfirmChangesButton.Location = new System.Drawing.Point(39, 203);
            this.ConfirmChangesButton.Name = "ConfirmChangesButton";
            this.ConfirmChangesButton.Size = new System.Drawing.Size(253, 45);
            this.ConfirmChangesButton.TabIndex = 6;
            this.ConfirmChangesButton.Text = "Внести изменения";
            this.ConfirmChangesButton.UseVisualStyleBackColor = true;
            this.ConfirmChangesButton.Click += new System.EventHandler(this.ConfirmChangesButton_Click);
            // 
            // FactoryStatusTextBox
            // 
            this.FactoryStatusTextBox.Location = new System.Drawing.Point(39, 95);
            this.FactoryStatusTextBox.Name = "FactoryStatusTextBox";
            this.FactoryStatusTextBox.Size = new System.Drawing.Size(253, 22);
            this.FactoryStatusTextBox.TabIndex = 7;
            // 
            // ManageFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 266);
            this.Controls.Add(this.FactoryStatusTextBox);
            this.Controls.Add(this.ConfirmChangesButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FactoryTimeUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FactoryIDUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageFactory";
            this.Text = "Управление РЦ";
            ((System.ComponentModel.ISupportInitialize)(this.FactoryIDUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryTimeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FactoryIDUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown FactoryTimeUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConfirmChangesButton;
        private System.Windows.Forms.TextBox FactoryStatusTextBox;
    }
}