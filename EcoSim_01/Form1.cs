using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoSim_01
{
    public partial class Form1 : Form
    {
        private Button mapBuilderButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mapBuilderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapBuilderButton
            // 
            this.mapBuilderButton.Location = new System.Drawing.Point(79, 42);
            this.mapBuilderButton.Name = "mapBuilderButton";
            this.mapBuilderButton.Size = new System.Drawing.Size(75, 23);
            this.mapBuilderButton.TabIndex = 0;
            this.mapBuilderButton.Text = "Map Builder";
            this.mapBuilderButton.UseVisualStyleBackColor = true;
            this.mapBuilderButton.Click += new System.EventHandler(this.mapBuilderButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.mapBuilderButton);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void MapBuildingButton_Click(object sender, EventArgs e)
        {

        }

        private void mapBuilderButton_Click(object sender, EventArgs e)
        {
            MapBuildingScreen mapScreen = new MapBuildingScreen();
            mapScreen.ShowDialog();
        }
    }
}
