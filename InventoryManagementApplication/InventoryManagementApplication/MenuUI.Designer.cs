namespace InventoryManagementApplication
{
    partial class MenuUI
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
            this.AddSuppliarButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddSuppliarButton
            // 
            this.AddSuppliarButton.Location = new System.Drawing.Point(47, 56);
            this.AddSuppliarButton.Name = "AddSuppliarButton";
            this.AddSuppliarButton.Size = new System.Drawing.Size(119, 58);
            this.AddSuppliarButton.TabIndex = 0;
            this.AddSuppliarButton.Text = "Add Suppliar";
            this.AddSuppliarButton.UseVisualStyleBackColor = true;
            this.AddSuppliarButton.Click += new System.EventHandler(this.AddSuppliarButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(262, 56);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(111, 58);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Add Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // MenuUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 230);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.AddSuppliarButton);
            this.Name = "MenuUI";
            this.Text = "MenuUI";
            this.Load += new System.EventHandler(this.MenuUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddSuppliarButton;
        private System.Windows.Forms.Button addProductButton;
    }
}