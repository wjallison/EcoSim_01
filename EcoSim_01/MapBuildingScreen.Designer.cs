﻿namespace EcoSim_01
{
    partial class MapBuildingScreen
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
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.palatteBox = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.finalizeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clearBrushButton = new System.Windows.Forms.Button();
            this.selectedIslandGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.commodityTextBox = new System.Windows.Forms.TextBox();
            this.commodityPriceTextBox = new System.Windows.Forms.TextBox();
            this.addCommodityButton = new System.Windows.Forms.Button();
            this.saveIslandChangesButton = new System.Windows.Forms.Button();
            this.addNewCommodityList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palatteBox)).BeginInit();
            this.selectedIslandGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(27, 21);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(511, 511);
            this.mapBox.TabIndex = 0;
            this.mapBox.TabStop = false;
            this.mapBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseClick);
            // 
            // palatteBox
            // 
            this.palatteBox.Location = new System.Drawing.Point(550, 21);
            this.palatteBox.Name = "palatteBox";
            this.palatteBox.Size = new System.Drawing.Size(102, 510);
            this.palatteBox.TabIndex = 1;
            this.palatteBox.TabStop = false;
            this.palatteBox.Click += new System.EventHandler(this.palatteBox_Click);
            this.palatteBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palatteBox_MouseClick);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(27, 572);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(108, 572);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(27, 538);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(108, 538);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 5;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // finalizeButton
            // 
            this.finalizeButton.Location = new System.Drawing.Point(189, 572);
            this.finalizeButton.Name = "finalizeButton";
            this.finalizeButton.Size = new System.Drawing.Size(75, 23);
            this.finalizeButton.TabIndex = 6;
            this.finalizeButton.Text = "Finalize";
            this.finalizeButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(685, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML files (*.xml)|*xml|All files(*.*)|*.*";
            // 
            // clearBrushButton
            // 
            this.clearBrushButton.Location = new System.Drawing.Point(550, 537);
            this.clearBrushButton.Name = "clearBrushButton";
            this.clearBrushButton.Size = new System.Drawing.Size(102, 23);
            this.clearBrushButton.TabIndex = 8;
            this.clearBrushButton.Text = "Clear Selection";
            this.clearBrushButton.UseVisualStyleBackColor = true;
            this.clearBrushButton.Visible = false;
            this.clearBrushButton.Click += new System.EventHandler(this.clearBrushButton_Click);
            // 
            // selectedIslandGroupBox
            // 
            this.selectedIslandGroupBox.Controls.Add(this.addNewCommodityList);
            this.selectedIslandGroupBox.Controls.Add(this.saveIslandChangesButton);
            this.selectedIslandGroupBox.Controls.Add(this.addCommodityButton);
            this.selectedIslandGroupBox.Controls.Add(this.commodityPriceTextBox);
            this.selectedIslandGroupBox.Controls.Add(this.commodityTextBox);
            this.selectedIslandGroupBox.Controls.Add(this.label2);
            this.selectedIslandGroupBox.Location = new System.Drawing.Point(670, 247);
            this.selectedIslandGroupBox.Name = "selectedIslandGroupBox";
            this.selectedIslandGroupBox.Size = new System.Drawing.Size(217, 259);
            this.selectedIslandGroupBox.TabIndex = 9;
            this.selectedIslandGroupBox.TabStop = false;
            this.selectedIslandGroupBox.Text = "islandName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Commodities:";
            // 
            // commodityTextBox
            // 
            this.commodityTextBox.Location = new System.Drawing.Point(6, 45);
            this.commodityTextBox.Multiline = true;
            this.commodityTextBox.Name = "commodityTextBox";
            this.commodityTextBox.Size = new System.Drawing.Size(100, 118);
            this.commodityTextBox.TabIndex = 2;
            // 
            // commodityPriceTextBox
            // 
            this.commodityPriceTextBox.Location = new System.Drawing.Point(112, 45);
            this.commodityPriceTextBox.Multiline = true;
            this.commodityPriceTextBox.Name = "commodityPriceTextBox";
            this.commodityPriceTextBox.Size = new System.Drawing.Size(100, 118);
            this.commodityPriceTextBox.TabIndex = 3;
            // 
            // addCommodityButton
            // 
            this.addCommodityButton.Location = new System.Drawing.Point(9, 169);
            this.addCommodityButton.Name = "addCommodityButton";
            this.addCommodityButton.Size = new System.Drawing.Size(75, 23);
            this.addCommodityButton.TabIndex = 4;
            this.addCommodityButton.Text = "Add New";
            this.addCommodityButton.UseVisualStyleBackColor = true;
            // 
            // saveIslandChangesButton
            // 
            this.saveIslandChangesButton.Location = new System.Drawing.Point(60, 230);
            this.saveIslandChangesButton.Name = "saveIslandChangesButton";
            this.saveIslandChangesButton.Size = new System.Drawing.Size(89, 23);
            this.saveIslandChangesButton.TabIndex = 5;
            this.saveIslandChangesButton.Text = "Save Changes";
            this.saveIslandChangesButton.UseVisualStyleBackColor = true;
            // 
            // addNewCommodityList
            // 
            this.addNewCommodityList.FormattingEnabled = true;
            this.addNewCommodityList.Location = new System.Drawing.Point(43, 145);
            this.addNewCommodityList.Name = "addNewCommodityList";
            this.addNewCommodityList.Size = new System.Drawing.Size(120, 95);
            this.addNewCommodityList.TabIndex = 10;
            // 
            // MapBuildingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 608);
            this.Controls.Add(this.selectedIslandGroupBox);
            this.Controls.Add(this.clearBrushButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finalizeButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.palatteBox);
            this.Controls.Add(this.mapBox);
            this.Name = "MapBuildingScreen";
            this.Text = "MapBuildingScreen";
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palatteBox)).EndInit();
            this.selectedIslandGroupBox.ResumeLayout(false);
            this.selectedIslandGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.PictureBox palatteBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button finalizeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button clearBrushButton;
        private System.Windows.Forms.GroupBox selectedIslandGroupBox;
        private System.Windows.Forms.Button saveIslandChangesButton;
        private System.Windows.Forms.Button addCommodityButton;
        private System.Windows.Forms.TextBox commodityPriceTextBox;
        private System.Windows.Forms.TextBox commodityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox addNewCommodityList;
    }
}