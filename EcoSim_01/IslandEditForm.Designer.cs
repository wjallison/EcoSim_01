namespace EcoSim_01
{
    partial class IslandEditForm
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
            this.commodityListBox = new System.Windows.Forms.ListBox();
            this.CommodityPriceListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addNewCommodityBox = new System.Windows.Forms.ComboBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Commodities";
            // 
            // commodityListBox
            // 
            this.commodityListBox.FormattingEnabled = true;
            this.commodityListBox.Location = new System.Drawing.Point(12, 25);
            this.commodityListBox.Name = "commodityListBox";
            this.commodityListBox.Size = new System.Drawing.Size(120, 95);
            this.commodityListBox.TabIndex = 1;
            // 
            // CommodityPriceListBox
            // 
            this.CommodityPriceListBox.FormattingEnabled = true;
            this.CommodityPriceListBox.Location = new System.Drawing.Point(152, 25);
            this.CommodityPriceListBox.Name = "CommodityPriceListBox";
            this.CommodityPriceListBox.Size = new System.Drawing.Size(120, 95);
            this.CommodityPriceListBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // addNewCommodityBox
            // 
            this.addNewCommodityBox.FormattingEnabled = true;
            this.addNewCommodityBox.Location = new System.Drawing.Point(93, 126);
            this.addNewCommodityBox.Name = "addNewCommodityBox";
            this.addNewCommodityBox.Size = new System.Drawing.Size(121, 21);
            this.addNewCommodityBox.TabIndex = 4;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(12, 227);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(100, 23);
            this.saveChangesButton.TabIndex = 5;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            // 
            // IslandEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.addNewCommodityBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CommodityPriceListBox);
            this.Controls.Add(this.commodityListBox);
            this.Controls.Add(this.label1);
            this.Name = "IslandEditForm";
            this.Text = "IslandEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox commodityListBox;
        private System.Windows.Forms.ListBox CommodityPriceListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox addNewCommodityBox;
        private System.Windows.Forms.Button saveChangesButton;
    }
}