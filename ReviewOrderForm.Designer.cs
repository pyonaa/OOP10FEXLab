namespace OOP10FEXLab
{
    partial class ReviewOrderForm
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
            titleLabel = new Label();
            subtitleLabel = new Label();
            orderList = new ListView();
            qtyColumn = new ColumnHeader();
            itemColumn = new ColumnHeader();
            amountColumn = new ColumnHeader();
            totalPanel = new Panel();
            totalCaptionLabel = new Label();
            totalAmountLabel = new Label();
            diningCaptionLabel = new Label();
            diningPanel = new Panel();
            dineInRadio = new RadioButton();
            takeOutRadio = new RadioButton();
            paymentCaptionLabel = new Label();
            paymentPanel = new Panel();
            cashRadio = new RadioButton();
            cardRadio = new RadioButton();
            eWalletRadio = new RadioButton();
            backButton = new Button();
            confirmButton = new Button();
            totalPanel.SuspendLayout();
            diningPanel.SuspendLayout();
            paymentPanel.SuspendLayout();
            SuspendLayout();
            //
            // titleLabel
            //
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(31, 26, 23);
            titleLabel.Location = new Point(24, 22);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(197, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Review Your Order";
            //
            // subtitleLabel
            //
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 9F);
            subtitleLabel.ForeColor = Color.FromArgb(138, 127, 117);
            subtitleLabel.Location = new Point(24, 54);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(279, 15);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Check your items, then choose how to eat and pay.";
            //
            // orderList
            //
            orderList.BorderStyle = BorderStyle.FixedSingle;
            orderList.Columns.AddRange(new ColumnHeader[] { qtyColumn, itemColumn, amountColumn });
            orderList.FullRowSelect = true;
            orderList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            orderList.Location = new Point(24, 86);
            orderList.Name = "orderList";
            orderList.Size = new Size(412, 134);
            orderList.TabIndex = 2;
            orderList.UseCompatibleStateImageBehavior = false;
            orderList.View = View.Details;
            //
            // qtyColumn
            //
            qtyColumn.Text = "Qty";
            qtyColumn.Width = 46;
            //
            // itemColumn
            //
            itemColumn.Text = "Item";
            itemColumn.Width = 270;
            //
            // amountColumn
            //
            amountColumn.Text = "Amount";
            amountColumn.TextAlign = HorizontalAlignment.Right;
            amountColumn.Width = 96;
            //
            // totalPanel
            //
            totalPanel.BackColor = Color.FromArgb(255, 248, 236);
            totalPanel.Controls.Add(totalAmountLabel);
            totalPanel.Controls.Add(totalCaptionLabel);
            totalPanel.Location = new Point(24, 228);
            totalPanel.Name = "totalPanel";
            totalPanel.Size = new Size(412, 40);
            totalPanel.TabIndex = 3;
            //
            // totalCaptionLabel
            //
            totalCaptionLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            totalCaptionLabel.ForeColor = Color.FromArgb(31, 26, 23);
            totalCaptionLabel.Location = new Point(12, 0);
            totalCaptionLabel.Name = "totalCaptionLabel";
            totalCaptionLabel.Size = new Size(100, 40);
            totalCaptionLabel.TabIndex = 0;
            totalCaptionLabel.Text = "Total";
            totalCaptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // totalAmountLabel
            //
            totalAmountLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            totalAmountLabel.ForeColor = Color.FromArgb(228, 0, 43);
            totalAmountLabel.Location = new Point(200, 0);
            totalAmountLabel.Name = "totalAmountLabel";
            totalAmountLabel.Size = new Size(200, 40);
            totalAmountLabel.TabIndex = 1;
            totalAmountLabel.Text = "₱ 0.00";
            totalAmountLabel.TextAlign = ContentAlignment.MiddleRight;
            //
            // diningCaptionLabel
            //
            diningCaptionLabel.AutoSize = true;
            diningCaptionLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            diningCaptionLabel.ForeColor = Color.FromArgb(138, 127, 117);
            diningCaptionLabel.Location = new Point(24, 284);
            diningCaptionLabel.Name = "diningCaptionLabel";
            diningCaptionLabel.Size = new Size(93, 13);
            diningCaptionLabel.TabIndex = 4;
            diningCaptionLabel.Text = "DINING OPTION";
            //
            // diningPanel
            //
            diningPanel.BackColor = Color.White;
            diningPanel.Controls.Add(takeOutRadio);
            diningPanel.Controls.Add(dineInRadio);
            diningPanel.Location = new Point(24, 306);
            diningPanel.Name = "diningPanel";
            diningPanel.Size = new Size(412, 52);
            diningPanel.TabIndex = 5;
            //
            // dineInRadio
            //
            dineInRadio.Appearance = Appearance.Button;
            dineInRadio.BackColor = Color.White;
            dineInRadio.Checked = true;
            dineInRadio.Cursor = Cursors.Hand;
            dineInRadio.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            dineInRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 244, 241);
            dineInRadio.FlatStyle = FlatStyle.Flat;
            dineInRadio.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dineInRadio.ForeColor = Color.FromArgb(31, 26, 23);
            dineInRadio.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_dine_in;
            dineInRadio.ImageAlign = ContentAlignment.MiddleLeft;
            dineInRadio.Location = new Point(0, 0);
            dineInRadio.Name = "dineInRadio";
            dineInRadio.Padding = new Padding(12, 0, 0, 0);
            dineInRadio.Size = new Size(202, 52);
            dineInRadio.TabIndex = 0;
            dineInRadio.TabStop = true;
            dineInRadio.Text = "Dine In";
            dineInRadio.TextAlign = ContentAlignment.MiddleLeft;
            dineInRadio.TextImageRelation = TextImageRelation.ImageBeforeText;
            dineInRadio.UseVisualStyleBackColor = false;
            //
            // takeOutRadio
            //
            takeOutRadio.Appearance = Appearance.Button;
            takeOutRadio.BackColor = Color.White;
            takeOutRadio.Cursor = Cursors.Hand;
            takeOutRadio.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            takeOutRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 244, 241);
            takeOutRadio.FlatStyle = FlatStyle.Flat;
            takeOutRadio.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            takeOutRadio.ForeColor = Color.FromArgb(31, 26, 23);
            takeOutRadio.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_take_out;
            takeOutRadio.ImageAlign = ContentAlignment.MiddleLeft;
            takeOutRadio.Location = new Point(210, 0);
            takeOutRadio.Name = "takeOutRadio";
            takeOutRadio.Padding = new Padding(12, 0, 0, 0);
            takeOutRadio.Size = new Size(202, 52);
            takeOutRadio.TabIndex = 1;
            takeOutRadio.Text = "Take Out";
            takeOutRadio.TextAlign = ContentAlignment.MiddleLeft;
            takeOutRadio.TextImageRelation = TextImageRelation.ImageBeforeText;
            takeOutRadio.UseVisualStyleBackColor = false;
            //
            // paymentCaptionLabel
            //
            paymentCaptionLabel.AutoSize = true;
            paymentCaptionLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            paymentCaptionLabel.ForeColor = Color.FromArgb(138, 127, 117);
            paymentCaptionLabel.Location = new Point(24, 374);
            paymentCaptionLabel.Name = "paymentCaptionLabel";
            paymentCaptionLabel.Size = new Size(105, 13);
            paymentCaptionLabel.TabIndex = 6;
            paymentCaptionLabel.Text = "PAYMENT METHOD";
            //
            // paymentPanel
            //
            paymentPanel.BackColor = Color.White;
            paymentPanel.Controls.Add(eWalletRadio);
            paymentPanel.Controls.Add(cardRadio);
            paymentPanel.Controls.Add(cashRadio);
            paymentPanel.Location = new Point(24, 396);
            paymentPanel.Name = "paymentPanel";
            paymentPanel.Size = new Size(412, 106);
            paymentPanel.TabIndex = 7;
            //
            // cashRadio
            //
            cashRadio.Appearance = Appearance.Button;
            cashRadio.BackColor = Color.White;
            cashRadio.Checked = true;
            cashRadio.Cursor = Cursors.Hand;
            cashRadio.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            cashRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 244, 241);
            cashRadio.FlatStyle = FlatStyle.Flat;
            cashRadio.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            cashRadio.ForeColor = Color.FromArgb(31, 26, 23);
            cashRadio.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_cash;
            cashRadio.ImageAlign = ContentAlignment.MiddleLeft;
            cashRadio.Location = new Point(0, 0);
            cashRadio.Name = "cashRadio";
            cashRadio.Padding = new Padding(12, 0, 0, 0);
            cashRadio.Size = new Size(412, 50);
            cashRadio.TabIndex = 0;
            cashRadio.TabStop = true;
            cashRadio.Text = "Cash\r\nPay at the counter";
            cashRadio.TextAlign = ContentAlignment.MiddleLeft;
            cashRadio.TextImageRelation = TextImageRelation.ImageBeforeText;
            cashRadio.UseVisualStyleBackColor = false;
            //
            // cardRadio
            //
            cardRadio.Appearance = Appearance.Button;
            cardRadio.BackColor = Color.White;
            cardRadio.Cursor = Cursors.Hand;
            cardRadio.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            cardRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 244, 241);
            cardRadio.FlatStyle = FlatStyle.Flat;
            cardRadio.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            cardRadio.ForeColor = Color.FromArgb(31, 26, 23);
            cardRadio.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_card;
            cardRadio.ImageAlign = ContentAlignment.MiddleLeft;
            cardRadio.Location = new Point(0, 56);
            cardRadio.Name = "cardRadio";
            cardRadio.Padding = new Padding(12, 0, 0, 0);
            cardRadio.Size = new Size(202, 50);
            cardRadio.TabIndex = 1;
            cardRadio.Text = "Card\r\nCredit / Debit";
            cardRadio.TextAlign = ContentAlignment.MiddleLeft;
            cardRadio.TextImageRelation = TextImageRelation.ImageBeforeText;
            cardRadio.UseVisualStyleBackColor = false;
            //
            // eWalletRadio
            //
            eWalletRadio.Appearance = Appearance.Button;
            eWalletRadio.BackColor = Color.White;
            eWalletRadio.Cursor = Cursors.Hand;
            eWalletRadio.FlatAppearance.BorderColor = Color.FromArgb(239, 228, 212);
            eWalletRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 244, 241);
            eWalletRadio.FlatStyle = FlatStyle.Flat;
            eWalletRadio.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            eWalletRadio.ForeColor = Color.FromArgb(31, 26, 23);
            eWalletRadio.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.icon_ewallet;
            eWalletRadio.ImageAlign = ContentAlignment.MiddleLeft;
            eWalletRadio.Location = new Point(210, 56);
            eWalletRadio.Name = "eWalletRadio";
            eWalletRadio.Padding = new Padding(12, 0, 0, 0);
            eWalletRadio.Size = new Size(202, 50);
            eWalletRadio.TabIndex = 2;
            eWalletRadio.Text = "E-wallet\r\nGCash / Maya";
            eWalletRadio.TextAlign = ContentAlignment.MiddleLeft;
            eWalletRadio.TextImageRelation = TextImageRelation.ImageBeforeText;
            eWalletRadio.UseVisualStyleBackColor = false;
            //
            // backButton
            //
            backButton.BackColor = Color.White;
            backButton.Cursor = Cursors.Hand;
            backButton.DialogResult = DialogResult.Cancel;
            backButton.FlatAppearance.BorderColor = Color.FromArgb(227, 216, 202);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.FromArgb(31, 26, 23);
            backButton.Location = new Point(24, 512);
            backButton.Name = "backButton";
            backButton.Size = new Size(150, 50);
            backButton.TabIndex = 8;
            backButton.Text = "Back to Menu";
            backButton.UseVisualStyleBackColor = false;
            //
            // confirmButton
            //
            confirmButton.BackColor = Color.FromArgb(43, 168, 74);
            confirmButton.Cursor = Cursors.Hand;
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            confirmButton.ForeColor = Color.White;
            confirmButton.Location = new Point(184, 512);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(252, 50);
            confirmButton.TabIndex = 9;
            confirmButton.Text = "Confirm Order ✓";
            confirmButton.UseVisualStyleBackColor = false;
            //
            // ReviewOrderForm
            //
            AcceptButton = confirmButton;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = backButton;
            ClientSize = new Size(460, 580);
            Controls.Add(confirmButton);
            Controls.Add(backButton);
            Controls.Add(paymentPanel);
            Controls.Add(paymentCaptionLabel);
            Controls.Add(diningPanel);
            Controls.Add(diningCaptionLabel);
            Controls.Add(totalPanel);
            Controls.Add(orderList);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReviewOrderForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Your Order";
            totalPanel.ResumeLayout(false);
            diningPanel.ResumeLayout(false);
            paymentPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label subtitleLabel;
        private ListView orderList;
        private ColumnHeader qtyColumn;
        private ColumnHeader itemColumn;
        private ColumnHeader amountColumn;
        private Panel totalPanel;
        private Label totalCaptionLabel;
        private Label totalAmountLabel;
        private Label diningCaptionLabel;
        private Panel diningPanel;
        private RadioButton dineInRadio;
        private RadioButton takeOutRadio;
        private Label paymentCaptionLabel;
        private Panel paymentPanel;
        private RadioButton cashRadio;
        private RadioButton cardRadio;
        private RadioButton eWalletRadio;
        private Button backButton;
        private Button confirmButton;
    }
}
