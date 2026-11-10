namespace OOP10FEXLab
{
    partial class KioskForm
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            logoPicture = new PictureBox();
            brandFlow = new FlowLayoutPanel();
            kainanLabel = new Label();
            expressLabel = new Label();
            subtitleLabel = new Label();
            sourceLabel = new Label();
            sidebarPanel = new Panel();
            menuLabel = new Label();
            categoryPanel = new FlowLayoutPanel();
            categoryTemplate = new Button();
            selectedCategoryTemplate = new Button();
            centerPanel = new Panel();
            titleFlow = new FlowLayoutPanel();
            categoryTitle = new Label();
            mealCountLabel = new Label();
            noMealsLabel = new Label();
            mealGrid = new FlowLayoutPanel();
            rightPanel = new Panel();
            rightLine = new Panel();
            myOrderLabel = new Label();
            cartList = new ListView();
            qtyColumn = new ColumnHeader();
            itemColumn = new ColumnHeader();
            amountColumn = new ColumnHeader();
            plusButton = new Button();
            minusButton = new Button();
            removeButton = new Button();
            itemCountLabel = new Label();
            totalCaptionLabel = new Label();
            totalLabel = new Label();
            cancelButton = new Button();
            payButton = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
            brandFlow.SuspendLayout();
            sidebarPanel.SuspendLayout();
            categoryPanel.SuspendLayout();
            centerPanel.SuspendLayout();
            titleFlow.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerPanel
            //
            headerPanel.BackColor = Color.FromArgb(228, 0, 43);
            headerPanel.Controls.Add(sourceLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(brandFlow);
            headerPanel.Controls.Add(logoPicture);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1020, 74);
            headerPanel.TabIndex = 0;
            //
            // logoPicture
            //
            logoPicture.BackColor = Color.White;
            logoPicture.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.logo_bowl;
            logoPicture.Location = new Point(16, 14);
            logoPicture.Name = "logoPicture";
            logoPicture.Padding = new Padding(8);
            logoPicture.Size = new Size(46, 46);
            logoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicture.TabIndex = 0;
            logoPicture.TabStop = false;
            //
            // brandFlow
            //
            brandFlow.AutoSize = true;
            brandFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            brandFlow.Controls.Add(kainanLabel);
            brandFlow.Controls.Add(expressLabel);
            brandFlow.Location = new Point(74, 9);
            brandFlow.Margin = new Padding(0);
            brandFlow.Name = "brandFlow";
            brandFlow.Size = new Size(210, 37);
            brandFlow.TabIndex = 1;
            brandFlow.WrapContents = false;
            //
            // kainanLabel
            //
            kainanLabel.AutoSize = true;
            kainanLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            kainanLabel.ForeColor = Color.White;
            kainanLabel.Location = new Point(0, 0);
            kainanLabel.Margin = new Padding(0);
            kainanLabel.Name = "kainanLabel";
            kainanLabel.Size = new Size(98, 37);
            kainanLabel.TabIndex = 0;
            kainanLabel.Text = "Kainan";
            //
            // expressLabel
            //
            expressLabel.AutoSize = true;
            expressLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            expressLabel.ForeColor = Color.FromArgb(255, 184, 28);
            expressLabel.Location = new Point(98, 0);
            expressLabel.Margin = new Padding(0);
            expressLabel.Name = "expressLabel";
            expressLabel.Size = new Size(112, 37);
            expressLabel.TabIndex = 1;
            expressLabel.Text = "Express";
            //
            // subtitleLabel
            //
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI Semibold", 9.5F);
            subtitleLabel.ForeColor = Color.White;
            subtitleLabel.Location = new Point(74, 46);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(350, 17);
            subtitleLabel.TabIndex = 2;
            subtitleLabel.Text = "Order and Pay here  •  Tap a meal to add it to your order";
            //
            // sourceLabel
            //
            sourceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sourceLabel.BackColor = Color.FromArgb(187, 0, 35);
            sourceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            sourceLabel.ForeColor = Color.White;
            sourceLabel.Location = new Point(768, 22);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(236, 30);
            sourceLabel.TabIndex = 3;
            sourceLabel.Text = "● Connected: ...";
            sourceLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // sidebarPanel
            //
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(categoryPanel);
            sidebarPanel.Controls.Add(menuLabel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 74);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(170, 586);
            sidebarPanel.TabIndex = 1;
            //
            // menuLabel
            //
            menuLabel.AutoSize = true;
            menuLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            menuLabel.ForeColor = Color.FromArgb(138, 127, 117);
            menuLabel.Location = new Point(16, 16);
            menuLabel.Name = "menuLabel";
            menuLabel.Size = new Size(40, 15);
            menuLabel.TabIndex = 0;
            menuLabel.Text = "MENU";
            //
            // categoryPanel
            //
            categoryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            categoryPanel.AutoScroll = true;
            categoryPanel.Controls.Add(categoryTemplate);
            categoryPanel.Controls.Add(selectedCategoryTemplate);
            categoryPanel.FlowDirection = FlowDirection.TopDown;
            categoryPanel.Location = new Point(13, 44);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(144, 542);
            categoryPanel.TabIndex = 1;
            categoryPanel.WrapContents = false;
            //
            // categoryTemplate
            //
            categoryTemplate.BackColor = Color.White;
            categoryTemplate.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            categoryTemplate.FlatStyle = FlatStyle.Flat;
            categoryTemplate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            categoryTemplate.ForeColor = Color.FromArgb(31, 26, 23);
            categoryTemplate.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_cat_all_red;
            categoryTemplate.ImageAlign = ContentAlignment.MiddleLeft;
            categoryTemplate.Location = new Point(0, 0);
            categoryTemplate.Margin = new Padding(0, 0, 0, 6);
            categoryTemplate.Name = "categoryTemplate";
            categoryTemplate.Padding = new Padding(8, 0, 0, 0);
            categoryTemplate.Size = new Size(144, 46);
            categoryTemplate.TabIndex = 0;
            categoryTemplate.Text = "Category";
            categoryTemplate.TextAlign = ContentAlignment.MiddleLeft;
            categoryTemplate.TextImageRelation = TextImageRelation.ImageBeforeText;
            categoryTemplate.UseVisualStyleBackColor = false;
            categoryTemplate.Visible = false;
            //
            // selectedCategoryTemplate
            //
            selectedCategoryTemplate.BackColor = Color.FromArgb(228, 0, 43);
            selectedCategoryTemplate.FlatAppearance.BorderSize = 0;
            selectedCategoryTemplate.FlatStyle = FlatStyle.Flat;
            selectedCategoryTemplate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            selectedCategoryTemplate.ForeColor = Color.White;
            selectedCategoryTemplate.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_cat_all_white;
            selectedCategoryTemplate.ImageAlign = ContentAlignment.MiddleLeft;
            selectedCategoryTemplate.Location = new Point(0, 52);
            selectedCategoryTemplate.Margin = new Padding(0, 0, 0, 6);
            selectedCategoryTemplate.Name = "selectedCategoryTemplate";
            selectedCategoryTemplate.Padding = new Padding(8, 0, 0, 0);
            selectedCategoryTemplate.Size = new Size(144, 46);
            selectedCategoryTemplate.TabIndex = 1;
            selectedCategoryTemplate.Text = "Selected";
            selectedCategoryTemplate.TextAlign = ContentAlignment.MiddleLeft;
            selectedCategoryTemplate.TextImageRelation = TextImageRelation.ImageBeforeText;
            selectedCategoryTemplate.UseVisualStyleBackColor = false;
            selectedCategoryTemplate.Visible = false;
            //
            // centerPanel
            //
            centerPanel.BackColor = Color.FromArgb(255, 248, 236);
            centerPanel.Controls.Add(noMealsLabel);
            centerPanel.Controls.Add(mealGrid);
            centerPanel.Controls.Add(titleFlow);
            centerPanel.Dock = DockStyle.Fill;
            centerPanel.Location = new Point(170, 74);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(540, 586);
            centerPanel.TabIndex = 2;
            //
            // titleFlow
            //
            titleFlow.AutoSize = true;
            titleFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            titleFlow.Controls.Add(categoryTitle);
            titleFlow.Controls.Add(mealCountLabel);
            titleFlow.Location = new Point(14, 8);
            titleFlow.Margin = new Padding(0);
            titleFlow.Name = "titleFlow";
            titleFlow.Size = new Size(189, 32);
            titleFlow.TabIndex = 0;
            titleFlow.WrapContents = false;
            //
            // categoryTitle
            //
            categoryTitle.AutoSize = true;
            categoryTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            categoryTitle.ForeColor = Color.FromArgb(31, 26, 23);
            categoryTitle.Location = new Point(0, 0);
            categoryTitle.Margin = new Padding(0);
            categoryTitle.Name = "categoryTitle";
            categoryTitle.Size = new Size(107, 30);
            categoryTitle.TabIndex = 0;
            categoryTitle.Text = "All Meals";
            categoryTitle.UseMnemonic = false;
            //
            // mealCountLabel
            //
            mealCountLabel.BackColor = Color.FromArgb(255, 241, 220);
            mealCountLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            mealCountLabel.ForeColor = Color.FromArgb(154, 100, 0);
            mealCountLabel.Location = new Point(119, 10);
            mealCountLabel.Margin = new Padding(12, 10, 0, 0);
            mealCountLabel.Name = "mealCountLabel";
            mealCountLabel.Size = new Size(70, 22);
            mealCountLabel.TabIndex = 1;
            mealCountLabel.Text = "0 meals";
            mealCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // noMealsLabel
            //
            noMealsLabel.AutoSize = true;
            noMealsLabel.ForeColor = Color.FromArgb(138, 127, 117);
            noMealsLabel.Location = new Point(22, 58);
            noMealsLabel.Name = "noMealsLabel";
            noMealsLabel.Size = new Size(320, 19);
            noMealsLabel.TabIndex = 2;
            noMealsLabel.Text = "No meals to show. Check meals.txt, then press F5.";
            noMealsLabel.Visible = false;
            //
            // mealGrid
            //
            mealGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mealGrid.AutoScroll = true;
            mealGrid.Location = new Point(14, 50);
            mealGrid.Name = "mealGrid";
            mealGrid.Size = new Size(518, 526);
            mealGrid.TabIndex = 1;
            //
            // rightPanel
            //
            rightPanel.BackColor = Color.White;
            rightPanel.Controls.Add(payButton);
            rightPanel.Controls.Add(cancelButton);
            rightPanel.Controls.Add(totalLabel);
            rightPanel.Controls.Add(totalCaptionLabel);
            rightPanel.Controls.Add(itemCountLabel);
            rightPanel.Controls.Add(removeButton);
            rightPanel.Controls.Add(minusButton);
            rightPanel.Controls.Add(plusButton);
            rightPanel.Controls.Add(cartList);
            rightPanel.Controls.Add(myOrderLabel);
            rightPanel.Controls.Add(rightLine);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(710, 74);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(310, 586);
            rightPanel.TabIndex = 3;
            //
            // rightLine
            //
            rightLine.BackColor = Color.FromArgb(239, 228, 212);
            rightLine.Dock = DockStyle.Left;
            rightLine.Location = new Point(0, 0);
            rightLine.Name = "rightLine";
            rightLine.Size = new Size(1, 586);
            rightLine.TabIndex = 0;
            //
            // myOrderLabel
            //
            myOrderLabel.AutoSize = true;
            myOrderLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            myOrderLabel.ForeColor = Color.FromArgb(31, 26, 23);
            myOrderLabel.Location = new Point(12, 8);
            myOrderLabel.Name = "myOrderLabel";
            myOrderLabel.Size = new Size(110, 30);
            myOrderLabel.TabIndex = 1;
            myOrderLabel.Text = "My Order";
            //
            // cartList
            //
            cartList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cartList.BorderStyle = BorderStyle.FixedSingle;
            cartList.Columns.AddRange(new ColumnHeader[] { qtyColumn, itemColumn, amountColumn });
            cartList.FullRowSelect = true;
            cartList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            cartList.HideSelection = false;
            cartList.Location = new Point(12, 52);
            cartList.MultiSelect = false;
            cartList.Name = "cartList";
            cartList.Size = new Size(286, 342);
            cartList.TabIndex = 2;
            cartList.UseCompatibleStateImageBehavior = false;
            cartList.View = View.Details;
            //
            // qtyColumn
            //
            qtyColumn.Text = "Qty";
            qtyColumn.Width = 46;
            //
            // itemColumn
            //
            itemColumn.Text = "Item";
            itemColumn.Width = 156;
            //
            // amountColumn
            //
            amountColumn.Text = "Amount";
            amountColumn.TextAlign = HorizontalAlignment.Right;
            amountColumn.Width = 84;
            //
            // plusButton
            //
            plusButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            plusButton.BackColor = Color.FromArgb(43, 168, 74);
            plusButton.Cursor = Cursors.Hand;
            plusButton.FlatAppearance.BorderSize = 0;
            plusButton.FlatStyle = FlatStyle.Flat;
            plusButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            plusButton.ForeColor = Color.White;
            plusButton.Location = new Point(12, 402);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(91, 38);
            plusButton.TabIndex = 3;
            plusButton.Text = "+ Add";
            plusButton.UseVisualStyleBackColor = false;
            //
            // minusButton
            //
            minusButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            minusButton.BackColor = Color.FromArgb(255, 184, 28);
            minusButton.Cursor = Cursors.Hand;
            minusButton.FlatAppearance.BorderSize = 0;
            minusButton.FlatStyle = FlatStyle.Flat;
            minusButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            minusButton.ForeColor = Color.FromArgb(31, 26, 23);
            minusButton.Location = new Point(109, 402);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(91, 38);
            minusButton.TabIndex = 4;
            minusButton.Text = "− Less";
            minusButton.UseVisualStyleBackColor = false;
            //
            // removeButton
            //
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeButton.BackColor = Color.FromArgb(244, 238, 231);
            removeButton.Cursor = Cursors.Hand;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            removeButton.ForeColor = Color.FromArgb(31, 26, 23);
            removeButton.Location = new Point(206, 402);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(91, 38);
            removeButton.TabIndex = 5;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = false;
            //
            // itemCountLabel
            //
            itemCountLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            itemCountLabel.AutoSize = true;
            itemCountLabel.Font = new Font("Segoe UI", 9F);
            itemCountLabel.ForeColor = Color.FromArgb(138, 127, 117);
            itemCountLabel.Location = new Point(12, 448);
            itemCountLabel.Name = "itemCountLabel";
            itemCountLabel.Size = new Size(46, 15);
            itemCountLabel.TabIndex = 6;
            itemCountLabel.Text = "0 items";
            //
            // totalCaptionLabel
            //
            totalCaptionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            totalCaptionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalCaptionLabel.ForeColor = Color.FromArgb(31, 26, 23);
            totalCaptionLabel.Location = new Point(12, 466);
            totalCaptionLabel.Name = "totalCaptionLabel";
            totalCaptionLabel.Size = new Size(120, 44);
            totalCaptionLabel.TabIndex = 7;
            totalCaptionLabel.Text = "Order Total";
            totalCaptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // totalLabel
            //
            totalLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            totalLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            totalLabel.ForeColor = Color.FromArgb(228, 0, 43);
            totalLabel.Location = new Point(132, 466);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(166, 44);
            totalLabel.TabIndex = 8;
            totalLabel.Text = "₱ 0.00";
            totalLabel.TextAlign = ContentAlignment.MiddleRight;
            //
            // cancelButton
            //
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.BackColor = Color.White;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(227, 216, 202);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            cancelButton.ForeColor = Color.FromArgb(31, 26, 23);
            cancelButton.Location = new Point(12, 520);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(139, 54);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Cancel Order";
            cancelButton.UseVisualStyleBackColor = false;
            //
            // payButton
            //
            payButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            payButton.BackColor = Color.FromArgb(228, 0, 43);
            payButton.Cursor = Cursors.Hand;
            payButton.FlatAppearance.BorderSize = 0;
            payButton.FlatStyle = FlatStyle.Flat;
            payButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            payButton.ForeColor = Color.White;
            payButton.Location = new Point(159, 520);
            payButton.Name = "payButton";
            payButton.Size = new Size(139, 54);
            payButton.TabIndex = 10;
            payButton.Text = "Review && Pay →";
            payButton.UseVisualStyleBackColor = false;
            //
            // KioskForm
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 248, 236);
            ClientSize = new Size(1020, 660);
            Controls.Add(centerPanel);
            Controls.Add(rightPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(880, 600);
            Name = "KioskForm";
            Text = "Kainan Express - Self-Order Kiosk";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).EndInit();
            brandFlow.ResumeLayout(false);
            brandFlow.PerformLayout();
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            categoryPanel.ResumeLayout(false);
            centerPanel.ResumeLayout(false);
            centerPanel.PerformLayout();
            titleFlow.ResumeLayout(false);
            titleFlow.PerformLayout();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private PictureBox logoPicture;
        private FlowLayoutPanel brandFlow;
        private Label kainanLabel;
        private Label expressLabel;
        private Label subtitleLabel;
        private Label sourceLabel;
        private Panel sidebarPanel;
        private Label menuLabel;
        private FlowLayoutPanel categoryPanel;
        private Button categoryTemplate;
        private Button selectedCategoryTemplate;
        private Panel centerPanel;
        private FlowLayoutPanel titleFlow;
        private Label categoryTitle;
        private Label mealCountLabel;
        private Label noMealsLabel;
        private FlowLayoutPanel mealGrid;
        private Panel rightPanel;
        private Panel rightLine;
        private Label myOrderLabel;
        private ListView cartList;
        private ColumnHeader qtyColumn;
        private ColumnHeader itemColumn;
        private ColumnHeader amountColumn;
        private Button plusButton;
        private Button minusButton;
        private Button removeButton;
        private Label itemCountLabel;
        private Label totalCaptionLabel;
        private Label totalLabel;
        private Button cancelButton;
        private Button payButton;
    }
}
