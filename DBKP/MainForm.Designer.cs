﻿
namespace DBKP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableGridView = new System.Windows.Forms.DataGridView();
            this.DisplayTableStorage = new System.Windows.Forms.Button();
            this.TableName = new System.Windows.Forms.Label();
            this.DisplayTableFactory = new System.Windows.Forms.Button();
            this.DisplayTableMaterial = new System.Windows.Forms.Button();
            this.DisplayTableConsist = new System.Windows.Forms.Button();
            this.MakeOrder = new System.Windows.Forms.Button();
            this.DisplayTableOrder = new System.Windows.Forms.Button();
            this.OrderMaterialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TableGridView
            // 
            this.TableGridView.AllowUserToAddRows = false;
            this.TableGridView.AllowUserToDeleteRows = false;
            this.TableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGridView.Location = new System.Drawing.Point(534, 31);
            this.TableGridView.Name = "TableGridView";
            this.TableGridView.RowHeadersVisible = false;
            this.TableGridView.RowHeadersWidth = 51;
            this.TableGridView.RowTemplate.Height = 24;
            this.TableGridView.Size = new System.Drawing.Size(579, 460);
            this.TableGridView.TabIndex = 0;
            // 
            // DisplayTableStorage
            // 
            this.DisplayTableStorage.Location = new System.Drawing.Point(73, 283);
            this.DisplayTableStorage.Name = "DisplayTableStorage";
            this.DisplayTableStorage.Size = new System.Drawing.Size(428, 33);
            this.DisplayTableStorage.TabIndex = 1;
            this.DisplayTableStorage.Text = "Просмотр таблицы \"Склады\"";
            this.DisplayTableStorage.UseVisualStyleBackColor = true;
            this.DisplayTableStorage.Click += new System.EventHandler(this.DisplayTableStorage_Click);
            // 
            // TableName
            // 
            this.TableName.AutoSize = true;
            this.TableName.Location = new System.Drawing.Point(809, 11);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(43, 17);
            this.TableName.TabIndex = 2;
            this.TableName.Text = "Label";
            // 
            // DisplayTableFactory
            // 
            this.DisplayTableFactory.Location = new System.Drawing.Point(73, 322);
            this.DisplayTableFactory.Name = "DisplayTableFactory";
            this.DisplayTableFactory.Size = new System.Drawing.Size(428, 33);
            this.DisplayTableFactory.TabIndex = 4;
            this.DisplayTableFactory.Text = "Просмотр таблицы \"РЦ\"";
            this.DisplayTableFactory.UseVisualStyleBackColor = true;
            this.DisplayTableFactory.Click += new System.EventHandler(this.DisplayTableFactory_Click);
            // 
            // DisplayTableMaterial
            // 
            this.DisplayTableMaterial.Location = new System.Drawing.Point(73, 361);
            this.DisplayTableMaterial.Name = "DisplayTableMaterial";
            this.DisplayTableMaterial.Size = new System.Drawing.Size(428, 33);
            this.DisplayTableMaterial.TabIndex = 5;
            this.DisplayTableMaterial.Text = "Просмотр таблицы \"Номенклатура\"";
            this.DisplayTableMaterial.UseVisualStyleBackColor = true;
            this.DisplayTableMaterial.Click += new System.EventHandler(this.DisplayTableMaterial_Click);
            // 
            // DisplayTableConsist
            // 
            this.DisplayTableConsist.Location = new System.Drawing.Point(73, 400);
            this.DisplayTableConsist.Name = "DisplayTableConsist";
            this.DisplayTableConsist.Size = new System.Drawing.Size(428, 33);
            this.DisplayTableConsist.TabIndex = 6;
            this.DisplayTableConsist.Text = "Просмотр таблицы \"Запасы\"";
            this.DisplayTableConsist.UseVisualStyleBackColor = true;
            this.DisplayTableConsist.Click += new System.EventHandler(this.DisplayTableConsist_Click);
            // 
            // MakeOrder
            // 
            this.MakeOrder.Location = new System.Drawing.Point(73, 40);
            this.MakeOrder.Name = "MakeOrder";
            this.MakeOrder.Size = new System.Drawing.Size(428, 33);
            this.MakeOrder.TabIndex = 7;
            this.MakeOrder.Text = "Оформить заказ";
            this.MakeOrder.UseVisualStyleBackColor = true;
            this.MakeOrder.Click += new System.EventHandler(this.MakeOrder_Click);
            // 
            // DisplayTableOrder
            // 
            this.DisplayTableOrder.Location = new System.Drawing.Point(73, 244);
            this.DisplayTableOrder.Name = "DisplayTableOrder";
            this.DisplayTableOrder.Size = new System.Drawing.Size(428, 33);
            this.DisplayTableOrder.TabIndex = 8;
            this.DisplayTableOrder.Text = "Просмотр таблицы \"Заказы\"";
            this.DisplayTableOrder.UseVisualStyleBackColor = true;
            this.DisplayTableOrder.Click += new System.EventHandler(this.DisplayTableOrder_Click);
            // 
            // OrderMaterialButton
            // 
            this.OrderMaterialButton.Location = new System.Drawing.Point(73, 79);
            this.OrderMaterialButton.Name = "OrderMaterialButton";
            this.OrderMaterialButton.Size = new System.Drawing.Size(428, 33);
            this.OrderMaterialButton.TabIndex = 9;
            this.OrderMaterialButton.Text = "Заказ закупок";
            this.OrderMaterialButton.UseVisualStyleBackColor = true;
            this.OrderMaterialButton.Click += new System.EventHandler(this.OrderMaterialButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 507);
            this.Controls.Add(this.OrderMaterialButton);
            this.Controls.Add(this.DisplayTableOrder);
            this.Controls.Add(this.MakeOrder);
            this.Controls.Add(this.DisplayTableConsist);
            this.Controls.Add(this.DisplayTableMaterial);
            this.Controls.Add(this.DisplayTableFactory);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.DisplayTableStorage);
            this.Controls.Add(this.TableGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "БД ";
            ((System.ComponentModel.ISupportInitialize)(this.TableGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TableGridView;
        private System.Windows.Forms.Button DisplayTableStorage;
        private System.Windows.Forms.Label TableName;
        private System.Windows.Forms.Button DisplayTableFactory;
        private System.Windows.Forms.Button DisplayTableMaterial;
        private System.Windows.Forms.Button DisplayTableConsist;
        private System.Windows.Forms.Button MakeOrder;
        private System.Windows.Forms.Button DisplayTableOrder;
        private System.Windows.Forms.Button OrderMaterialButton;
    }
}
