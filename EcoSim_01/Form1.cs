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
        private Button pathfindingTestingButton;
        private Button mapBuilderButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mapBuilderButton = new System.Windows.Forms.Button();
            this.pathfindingTestingButton = new System.Windows.Forms.Button();
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
            // pathfindingTestingButton
            // 
            this.pathfindingTestingButton.Location = new System.Drawing.Point(70, 92);
            this.pathfindingTestingButton.Name = "pathfindingTestingButton";
            this.pathfindingTestingButton.Size = new System.Drawing.Size(140, 23);
            this.pathfindingTestingButton.TabIndex = 1;
            this.pathfindingTestingButton.Text = "Pathfinding Testing";
            this.pathfindingTestingButton.UseVisualStyleBackColor = true;
            this.pathfindingTestingButton.Click += new System.EventHandler(this.pathfindingTestingButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pathfindingTestingButton);
            this.Controls.Add(this.mapBuilderButton);
            this.Name = "Form1";
            this.ResumeLayout(false);







            //Initialize list of commodities

            List<Commodity> buildingList = new List<Commodity>();

            buildingList.Add(new Commodity("Grain", 1, 10, 30));
            buildingList.Add(new Commodity("Meat", 1, 20, 50));
            buildingList.Add(new Commodity("Sugar", 1, 50, 100));
            buildingList.Add(new Commodity("Tobacco", 1, 50, 100));
            buildingList.Add(new Commodity("Wood", 5, 20, 60));
            buildingList.Add(new Commodity("Iron", 5, 50, 100));
            buildingList.Add(new Commodity("Gold", 3, 100, 200));
            buildingList.Add(new Commodity("Leather", 2, 30, 60));
            buildingList.Add(new Commodity("Stone", 8, 20, 60));
            buildingList.Add(new Commodity("Cotton", 1, 20, 50));
            buildingList.Add(new Commodity("Tea", 1, 30, 80));
            buildingList.Add(new Commodity("Saltpetre", 3, 30, 70));
            buildingList.Add(new Commodity("Sulfur", 3, 30, 70));
            buildingList.Add(new Commodity("Salt", 1, 10, 80));
            buildingList.Add(new Commodity("Fish", 1, 20, 50));
            buildingList.Add(new Commodity("Fruit", 1, 10, 50));
            buildingList.Add(new Commodity("Coal", 2, 20, 70));
            buildingList.Add(new Commodity("Dye", 1, 60, 120));
            buildingList.Add(new Commodity("Bread", 2, 60, 150));
            buildingList.Add(new Commodity("Grain Alcohol", 2, 80, 200));
            buildingList.Add(new Commodity("Rum", 2, 100, 250));
            buildingList.Add(new Commodity("Weapons", 3, 100, 500));
            buildingList.Add(new Commodity("Tools", 3, 100, 500));
            buildingList.Add(new Commodity("Cloth", 2, 100, 200));
            buildingList.Add(new Commodity("Gunpowder", 1, 100, 250));
            buildingList.Add(new Commodity("Salted Meat", 2, 100, 250));
            buildingList.Add(new Commodity("Dried Fruit", 1, 50, 150));
            buildingList.Add(new Commodity("Rations", 2, 100, 500));
            buildingList.Add(new Commodity("Clothes", 2, 150, 500));

            GlobalClass1.allCommods = buildingList;


        }

        private void MapBuildingButton_Click(object sender, EventArgs e)
        {

        }

        private void mapBuilderButton_Click(object sender, EventArgs e)
        {
            MapBuildingScreen mapScreen = new MapBuildingScreen();
            mapScreen.ShowDialog();
        }

        private void pathfindingTestingButton_Click(object sender, EventArgs e)
        {
            PathfindingTesting pathTest = new PathfindingTesting();
            pathTest.ShowDialog();
        }
    }
}
