namespace OOP10FEXLab
{
    partial class QueueMonitorForm
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
            storeNameLabel = new Label();
            titleLabel = new Label();
            timeLabel = new Label();
            dateLabel = new Label();
            boardTable = new TableLayoutPanel();
            preparingColumn = new Panel();
            preparingCountLabel = new Label();
            preparingPanel = new FlowLayoutPanel();
            preparingHeader = new Label();
            servingColumn = new Panel();
            servingCountLabel = new Label();
            servingPanel = new FlowLayoutPanel();
            servingHeader = new Label();
            hintLabel = new Label();
            preparingTileTemplate = new Label();
            servingTileTemplate = new Panel();
            servingTileLabelTemplate = new Label();
            blinkingTileTemplate = new Label();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
            boardTable.SuspendLayout();
            preparingColumn.SuspendLayout();
            servingColumn.SuspendLayout();
            servingTileTemplate.SuspendLayout();
            SuspendLayout();
            //
            // headerPanel
            //
            headerPanel.BackColor = Color.FromArgb(228, 0, 43);
            headerPanel.Controls.Add(dateLabel);
            headerPanel.Controls.Add(timeLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(storeNameLabel);
            headerPanel.Controls.Add(logoPicture);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(560, 64);
            headerPanel.TabIndex = 0;
            //
            // logoPicture
            //
            logoPicture.BackColor = Color.White;
            logoPicture.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.logo_bowl;
            logoPicture.Location = new Point(16, 12);
            logoPicture.Name = "logoPicture";
            logoPicture.Padding = new Padding(6);
            logoPicture.Size = new Size(40, 40);
            logoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicture.TabIndex = 0;
            logoPicture.TabStop = false;
            //
            // storeNameLabel
            //
            storeNameLabel.AutoSize = true;
            storeNameLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            storeNameLabel.ForeColor = Color.FromArgb(255, 184, 28);
            storeNameLabel.Location = new Point(66, 11);
            storeNameLabel.Name = "storeNameLabel";
            storeNameLabel.Size = new Size(93, 15);
            storeNameLabel.TabIndex = 1;
            storeNameLabel.Text = "Kainan Express";
            //
            // titleLabel
            //
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(66, 26);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(173, 30);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "CLAIM MONITOR";
            //
            // timeLabel
            //
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new Point(404, 12);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(140, 25);
            timeLabel.TabIndex = 3;
            timeLabel.Text = "12:00:00 PM";
            timeLabel.TextAlign = ContentAlignment.MiddleRight;
            //
            // dateLabel
            //
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLabel.Font = new Font("Segoe UI", 8.5F);
            dateLabel.ForeColor = Color.White;
            dateLabel.Location = new Point(404, 36);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(140, 18);
            dateLabel.TabIndex = 4;
            dateLabel.Text = "Mon, Jan 1";
            dateLabel.TextAlign = ContentAlignment.MiddleRight;
            //
            // boardTable
            //
            boardTable.ColumnCount = 2;
            boardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            boardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            boardTable.Controls.Add(preparingColumn, 0, 0);
            boardTable.Controls.Add(servingColumn, 1, 0);
            boardTable.Dock = DockStyle.Fill;
            boardTable.Location = new Point(0, 64);
            boardTable.Name = "boardTable";
            boardTable.Padding = new Padding(12);
            boardTable.RowCount = 1;
            boardTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            boardTable.Size = new Size(560, 554);
            boardTable.TabIndex = 1;
            //
            // preparingColumn
            //
            preparingColumn.Controls.Add(preparingCountLabel);
            preparingColumn.Controls.Add(preparingPanel);
            preparingColumn.Controls.Add(preparingHeader);
            preparingColumn.Dock = DockStyle.Fill;
            preparingColumn.Location = new Point(12, 12);
            preparingColumn.Margin = new Padding(0, 0, 4, 0);
            preparingColumn.Name = "preparingColumn";
            preparingColumn.Size = new Size(291, 530);
            preparingColumn.TabIndex = 0;
            //
            // preparingCountLabel
            //
            preparingCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            preparingCountLabel.BackColor = Color.FromArgb(209, 151, 23);
            preparingCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            preparingCountLabel.ForeColor = Color.FromArgb(31, 26, 23);
            preparingCountLabel.Location = new Point(249, 12);
            preparingCountLabel.Name = "preparingCountLabel";
            preparingCountLabel.Size = new Size(30, 22);
            preparingCountLabel.TabIndex = 2;
            preparingCountLabel.Text = "0";
            preparingCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // preparingPanel
            //
            preparingPanel.AutoScroll = true;
            preparingPanel.BackColor = Color.FromArgb(42, 36, 32);
            preparingPanel.Dock = DockStyle.Fill;
            preparingPanel.Location = new Point(0, 46);
            preparingPanel.Name = "preparingPanel";
            preparingPanel.Padding = new Padding(33, 16, 0, 0);
            preparingPanel.Size = new Size(291, 484);
            preparingPanel.TabIndex = 1;
            //
            // preparingHeader
            //
            preparingHeader.BackColor = Color.FromArgb(255, 184, 28);
            preparingHeader.Dock = DockStyle.Top;
            preparingHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            preparingHeader.ForeColor = Color.FromArgb(31, 26, 23);
            preparingHeader.Location = new Point(0, 0);
            preparingHeader.Name = "preparingHeader";
            preparingHeader.Size = new Size(291, 46);
            preparingHeader.TabIndex = 0;
            preparingHeader.Text = "PREPARING";
            preparingHeader.TextAlign = ContentAlignment.MiddleCenter;
            //
            // servingColumn
            //
            servingColumn.Controls.Add(servingCountLabel);
            servingColumn.Controls.Add(servingPanel);
            servingColumn.Controls.Add(servingHeader);
            servingColumn.Dock = DockStyle.Fill;
            servingColumn.Location = new Point(311, 12);
            servingColumn.Margin = new Padding(4, 0, 0, 0);
            servingColumn.Name = "servingColumn";
            servingColumn.Size = new Size(237, 530);
            servingColumn.TabIndex = 1;
            //
            // servingCountLabel
            //
            servingCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            servingCountLabel.BackColor = Color.FromArgb(35, 138, 61);
            servingCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            servingCountLabel.ForeColor = Color.White;
            servingCountLabel.Location = new Point(195, 12);
            servingCountLabel.Name = "servingCountLabel";
            servingCountLabel.Size = new Size(30, 22);
            servingCountLabel.TabIndex = 2;
            servingCountLabel.Text = "0";
            servingCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // servingPanel
            //
            servingPanel.AutoScroll = true;
            servingPanel.BackColor = Color.FromArgb(42, 36, 32);
            servingPanel.Dock = DockStyle.Fill;
            servingPanel.Location = new Point(0, 46);
            servingPanel.Name = "servingPanel";
            servingPanel.Padding = new Padding(41, 16, 0, 0);
            servingPanel.Size = new Size(237, 484);
            servingPanel.TabIndex = 1;
            //
            // servingHeader
            //
            servingHeader.BackColor = Color.FromArgb(43, 168, 74);
            servingHeader.Dock = DockStyle.Top;
            servingHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            servingHeader.ForeColor = Color.White;
            servingHeader.Location = new Point(0, 0);
            servingHeader.Name = "servingHeader";
            servingHeader.Size = new Size(237, 46);
            servingHeader.TabIndex = 0;
            servingHeader.Text = "NOW SERVING";
            servingHeader.TextAlign = ContentAlignment.MiddleCenter;
            //
            // hintLabel
            //
            hintLabel.Dock = DockStyle.Bottom;
            hintLabel.Font = new Font("Segoe UI", 8.5F);
            hintLabel.ForeColor = Color.FromArgb(185, 174, 162);
            hintLabel.Location = new Point(0, 618);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(560, 42);
            hintLabel.TabIndex = 2;
            hintLabel.Text = "Staff: click a PREPARING number when the meal is ready.\nClick a NOW SERVING number once it has been claimed.";
            hintLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // preparingTileTemplate
            //
            preparingTileTemplate.BackColor = Color.FromArgb(58, 49, 43);
            preparingTileTemplate.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            preparingTileTemplate.ForeColor = Color.FromArgb(255, 243, 224);
            preparingTileTemplate.Location = new Point(45, 138);
            preparingTileTemplate.Margin = new Padding(0, 0, 16, 12);
            preparingTileTemplate.Name = "preparingTileTemplate";
            preparingTileTemplate.Size = new Size(104, 46);
            preparingTileTemplate.TabIndex = 3;
            preparingTileTemplate.Text = "1000";
            preparingTileTemplate.TextAlign = ContentAlignment.MiddleCenter;
            preparingTileTemplate.Visible = false;
            //
            // servingTileTemplate
            //
            servingTileTemplate.BackColor = Color.FromArgb(43, 168, 74);
            servingTileTemplate.Controls.Add(servingTileLabelTemplate);
            servingTileTemplate.Location = new Point(352, 138);
            servingTileTemplate.Margin = new Padding(0, 0, 0, 12);
            servingTileTemplate.Name = "servingTileTemplate";
            servingTileTemplate.Size = new Size(154, 68);
            servingTileTemplate.TabIndex = 4;
            servingTileTemplate.Visible = false;
            //
            // servingTileLabelTemplate
            //
            servingTileLabelTemplate.BackColor = Color.FromArgb(30, 43, 32);
            servingTileLabelTemplate.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            servingTileLabelTemplate.ForeColor = Color.FromArgb(91, 227, 125);
            servingTileLabelTemplate.Location = new Point(2, 2);
            servingTileLabelTemplate.Name = "servingTileLabelTemplate";
            servingTileLabelTemplate.Size = new Size(150, 64);
            servingTileLabelTemplate.TabIndex = 0;
            servingTileLabelTemplate.Text = "1000";
            servingTileLabelTemplate.TextAlign = ContentAlignment.MiddleCenter;
            //
            // blinkingTileTemplate
            //
            blinkingTileTemplate.BackColor = Color.FromArgb(255, 184, 28);
            blinkingTileTemplate.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            blinkingTileTemplate.ForeColor = Color.FromArgb(31, 26, 23);
            blinkingTileTemplate.Location = new Point(354, 220);
            blinkingTileTemplate.Name = "blinkingTileTemplate";
            blinkingTileTemplate.Size = new Size(150, 64);
            blinkingTileTemplate.TabIndex = 5;
            blinkingTileTemplate.Text = "1000";
            blinkingTileTemplate.TextAlign = ContentAlignment.MiddleCenter;
            blinkingTileTemplate.Visible = false;
            //
            // QueueMonitorForm
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 26, 23);
            ClientSize = new Size(560, 660);
            Controls.Add(blinkingTileTemplate);
            Controls.Add(servingTileTemplate);
            Controls.Add(preparingTileTemplate);
            Controls.Add(boardTable);
            Controls.Add(hintLabel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(380, 420);
            Name = "QueueMonitorForm";
            Text = "Claim Monitor";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).EndInit();
            boardTable.ResumeLayout(false);
            preparingColumn.ResumeLayout(false);
            servingColumn.ResumeLayout(false);
            servingTileTemplate.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private PictureBox logoPicture;
        private Label storeNameLabel;
        private Label titleLabel;
        private Label timeLabel;
        private Label dateLabel;
        private TableLayoutPanel boardTable;
        private Panel preparingColumn;
        private Label preparingCountLabel;
        private FlowLayoutPanel preparingPanel;
        private Label preparingHeader;
        private Panel servingColumn;
        private Label servingCountLabel;
        private FlowLayoutPanel servingPanel;
        private Label servingHeader;
        private Label hintLabel;
        private Label preparingTileTemplate;
        private Panel servingTileTemplate;
        private Label servingTileLabelTemplate;
        private Label blinkingTileTemplate;
    }
}
