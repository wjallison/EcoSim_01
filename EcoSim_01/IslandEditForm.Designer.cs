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
            this.CommodityNumberListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addNewCommodityBox = new System.Windows.Forms.ComboBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.CommodityPriceListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Commodities";
            // 
            // commodityListBox
            // 
            this.commodityListBox.FormattingEnabled = true;
            this.commodityListBox.Location = new System.Drawing.Point(12, 53);
            this.commodityListBox.Name = "commodityListBox";
            this.commodityListBox.Size = new System.Drawing.Size(120, 95);
            this.commodityListBox.TabIndex = 1;
            // 
            // CommodityNumberListBox
            // 
            this.CommodityNumberListBox.FormattingEnabled = true;
            this.CommodityNumberListBox.Location = new System.Drawing.Point(138, 53);
            this.CommodityNumberListBox.Name = "CommodityNumberListBox";
            this.CommodityNumberListBox.Size = new System.Drawing.Size(120, 95);
            this.CommodityNumberListBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // addNewCommodityBox
            // 
            this.addNewCommodityBox.FormattingEnabled = true;
            this.addNewCommodityBox.Location = new System.Drawing.Point(93, 154);
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
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(15, 12);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckBox.TabIndex = 6;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // CommodityPriceListBox
            // 
            this.CommodityPriceListBox.FormattingEnabled = true;
            this.CommodityPriceListBox.Location = new System.Drawing.Point(264, 53);
            this.CommodityPriceListBox.Name = "CommodityPriceListBox";
            this.CommodityPriceListBox.Size = new System.Drawing.Size(120, 95);
            this.CommodityPriceListBox.TabIndex = 7;
            // 
            // IslandEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 262);
            this.Controls.Add(this.CommodityPriceListBox);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.addNewCommodityBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CommodityNumberListBox);
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
        private System.Windows.Forms.ListBox CommodityNumberListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox addNewCommodityBox;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.ListBox CommodityPriceListBox;
    }
}