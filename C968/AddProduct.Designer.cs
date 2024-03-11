namespace C968
{
    partial class AddProduct
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
            this.allPartSearchBox = new System.Windows.Forms.TextBox();
            this.AllPartSearchButton = new System.Windows.Forms.Button();
            this.AllPartDataGridView = new System.Windows.Forms.DataGridView();
            this.addPartButton = new System.Windows.Forms.Button();
            this.AllAssociatedPartListView = new System.Windows.Forms.DataGridView();
            this.deleteAssociatedPartButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.inventoryTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AllPartDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllAssociatedPartListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Product";
            // 
            // allPartSearchBox
            // 
            this.allPartSearchBox.Location = new System.Drawing.Point(940, 18);
            this.allPartSearchBox.Name = "allPartSearchBox";
            this.allPartSearchBox.Size = new System.Drawing.Size(100, 20);
            this.allPartSearchBox.TabIndex = 3;
            // 
            // AllPartSearchButton
            // 
            this.AllPartSearchButton.Location = new System.Drawing.Point(859, 16);
            this.AllPartSearchButton.Name = "AllPartSearchButton";
            this.AllPartSearchButton.Size = new System.Drawing.Size(75, 23);
            this.AllPartSearchButton.TabIndex = 2;
            this.AllPartSearchButton.Text = "Search";
            this.AllPartSearchButton.UseVisualStyleBackColor = true;
            // 
            // AllPartDataGridView
            // 
            this.AllPartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllPartDataGridView.Location = new System.Drawing.Point(406, 55);
            this.AllPartDataGridView.Name = "AllPartDataGridView";
            this.AllPartDataGridView.Size = new System.Drawing.Size(634, 244);
            this.AllPartDataGridView.TabIndex = 7;
            // 
            // addPartButton
            // 
            this.addPartButton.Location = new System.Drawing.Point(940, 316);
            this.addPartButton.Name = "addPartButton";
            this.addPartButton.Size = new System.Drawing.Size(75, 23);
            this.addPartButton.TabIndex = 8;
            this.addPartButton.Text = "Add";
            this.addPartButton.UseVisualStyleBackColor = true;
            this.addPartButton.Click += new System.EventHandler(this.addPartButton_click);
            // 
            // AllAssociatedPartListView
            // 
            this.AllAssociatedPartListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllAssociatedPartListView.Location = new System.Drawing.Point(406, 370);
            this.AllAssociatedPartListView.Name = "AllAssociatedPartListView";
            this.AllAssociatedPartListView.Size = new System.Drawing.Size(634, 244);
            this.AllAssociatedPartListView.TabIndex = 9;
            // 
            // deleteAssociatedPartButton
            // 
            this.deleteAssociatedPartButton.Location = new System.Drawing.Point(940, 629);
            this.deleteAssociatedPartButton.Name = "deleteAssociatedPartButton";
            this.deleteAssociatedPartButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAssociatedPartButton.TabIndex = 10;
            this.deleteAssociatedPartButton.Text = "Delete";
            this.deleteAssociatedPartButton.UseVisualStyleBackColor = true;
            this.deleteAssociatedPartButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(940, 677);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveProductButton
            // 
            this.saveProductButton.Location = new System.Drawing.Point(848, 677);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(75, 23);
            this.saveProductButton.TabIndex = 12;
            this.saveProductButton.Text = "Save";
            this.saveProductButton.UseVisualStyleBackColor = true;
            this.saveProductButton.Click += new System.EventHandler(this.saveProductButton_Click);
            // 
            // priceTextBox
            // 
            this.priceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.priceTextBox.Location = new System.Drawing.Point(176, 315);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(186, 20);
            this.priceTextBox.TabIndex = 30;
            // 
            // inventoryTextBox
            // 
            this.inventoryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.inventoryTextBox.Location = new System.Drawing.Point(176, 279);
            this.inventoryTextBox.Name = "inventoryTextBox";
            this.inventoryTextBox.Size = new System.Drawing.Size(186, 20);
            this.inventoryTextBox.TabIndex = 29;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(176, 212);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(186, 20);
            this.idTextBox.TabIndex = 28;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nameTextBox.Location = new System.Drawing.Point(176, 248);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(186, 20);
            this.nameTextBox.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(39, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Price/Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(39, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Inventory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(39, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(39, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "ID";
            // 
            // maxTextBox
            // 
            this.maxTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.maxTextBox.Location = new System.Drawing.Point(75, 370);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(73, 20);
            this.maxTextBox.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(36, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Max";
            // 
            // minTextBox
            // 
            this.minTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.minTextBox.Location = new System.Drawing.Point(227, 370);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(73, 20);
            this.minTextBox.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(188, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(406, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "All candidate Parts";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(406, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "All Associated with this Product";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 726);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.inventoryTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveProductButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteAssociatedPartButton);
            this.Controls.Add(this.AllAssociatedPartListView);
            this.Controls.Add(this.addPartButton);
            this.Controls.Add(this.AllPartDataGridView);
            this.Controls.Add(this.allPartSearchBox);
            this.Controls.Add(this.AllPartSearchButton);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            ((System.ComponentModel.ISupportInitialize)(this.AllPartDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllAssociatedPartListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox allPartSearchBox;
        private System.Windows.Forms.Button AllPartSearchButton;
        private System.Windows.Forms.DataGridView AllPartDataGridView;
        private System.Windows.Forms.Button addPartButton;
        private System.Windows.Forms.DataGridView AllAssociatedPartListView;
        private System.Windows.Forms.Button deleteAssociatedPartButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox inventoryTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}