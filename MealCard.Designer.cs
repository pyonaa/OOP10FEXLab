namespace OOP10FEXLab
{
    partial class MealCard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            innerPanel = new Panel();
            foodPicture = new PictureBox();
            nameLabel = new Label();
            priceLabel = new Label();
            plusLabel = new Label();
            tip = new ToolTip(components);
            innerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)foodPicture).BeginInit();
            SuspendLayout();
            //
            // innerPanel
            //
            innerPanel.BackColor = Color.White;
            innerPanel.Controls.Add(plusLabel);
            innerPanel.Controls.Add(priceLabel);
            innerPanel.Controls.Add(nameLabel);
            innerPanel.Controls.Add(foodPicture);
            innerPanel.Dock = DockStyle.Fill;
            innerPanel.Location = new Point(1, 1);
            innerPanel.Name = "innerPanel";
            innerPanel.Size = new Size(152, 198);
            innerPanel.TabIndex = 0;
            //
            // foodPicture
            //
            foodPicture.BackColor = Color.FromArgb(255, 241, 220);
            foodPicture.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.food_default;
            foodPicture.Location = new Point(7, 7);
            foodPicture.Name = "foodPicture";
            foodPicture.Size = new Size(136, 100);
            foodPicture.SizeMode = PictureBoxSizeMode.Zoom;
            foodPicture.TabIndex = 0;
            foodPicture.TabStop = false;
            //
            // nameLabel
            //
            nameLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            nameLabel.ForeColor = Color.FromArgb(31, 26, 23);
            nameLabel.Location = new Point(9, 115);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(134, 36);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Meal name";
            nameLabel.UseMnemonic = false;
            //
            // priceLabel
            //
            priceLabel.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            priceLabel.ForeColor = Color.FromArgb(228, 0, 43);
            priceLabel.Location = new Point(9, 159);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(100, 30);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "₱ 0.00";
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // plusLabel
            //
            plusLabel.BackColor = Color.FromArgb(255, 184, 28);
            plusLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            plusLabel.ForeColor = Color.FromArgb(31, 26, 23);
            plusLabel.Location = new Point(113, 159);
            plusLabel.Name = "plusLabel";
            plusLabel.Size = new Size(30, 30);
            plusLabel.TabIndex = 3;
            plusLabel.Text = "+";
            plusLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // MealCard
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 228, 212);
            Controls.Add(innerPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(6);
            Name = "MealCard";
            Padding = new Padding(1);
            Size = new Size(154, 200);
            innerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)foodPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel innerPanel;
        private PictureBox foodPicture;
        private Label nameLabel;
        private Label priceLabel;
        private Label plusLabel;
        private ToolTip tip;
    }
}
