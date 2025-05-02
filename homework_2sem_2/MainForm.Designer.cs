namespace homework_2sem_2
{
    partial class MainForm
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
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLoad = new Button();
            btnOpenInfo = new Button();
            picture = new PictureBox();
            entitiesTree = new TreeView();
            infoTable = new DataGridView();
            openFiles = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)infoTable).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(picture);
            splitContainer1.Panel1.Controls.Add(entitiesTree);
            splitContainer1.Panel1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splitContainer1.Panel1MinSize = 265;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(infoTable);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnLoad, 0, 0);
            tableLayoutPanel1.Controls.Add(btnOpenInfo, 1, 0);
            tableLayoutPanel1.Location = new Point(8, 406);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(251, 38);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLoad.Location = new Point(3, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(119, 32);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Открыть файл";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnOpenInfo
            // 
            btnOpenInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOpenInfo.Location = new Point(128, 3);
            btnOpenInfo.Name = "btnOpenInfo";
            btnOpenInfo.Size = new Size(120, 32);
            btnOpenInfo.TabIndex = 1;
            btnOpenInfo.Text = "Информация";
            btnOpenInfo.UseVisualStyleBackColor = true;
            // 
            // picture
            // 
            picture.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picture.BackColor = Color.White;
            picture.Image = Properties.Resources.lottery_logo;
            picture.Location = new Point(12, 9);
            picture.Name = "picture";
            picture.Size = new Size(243, 67);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabIndex = 3;
            picture.TabStop = false;
            // 
            // entitiesTree
            // 
            entitiesTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            entitiesTree.Location = new Point(12, 85);
            entitiesTree.Name = "entitiesTree";
            entitiesTree.Size = new Size(243, 315);
            entitiesTree.TabIndex = 2;
            // 
            // infoTable
            // 
            infoTable.AllowUserToAddRows = false;
            infoTable.AllowUserToDeleteRows = false;
            infoTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            infoTable.Dock = DockStyle.Fill;
            infoTable.Location = new Point(0, 0);
            infoTable.Name = "infoTable";
            infoTable.ReadOnly = true;
            infoTable.Size = new Size(530, 450);
            infoTable.TabIndex = 0;
            // 
            // openFiles
            // 
            openFiles.FileName = "dataSet";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(816, 489);
            Name = "MainForm";
            Text = "Лотерея";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)infoTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button2;
        private Button btnLoad;
        private Button btnOpenInfo;
        private TreeView entitiesTree;
        private OpenFileDialog openFiles;
        private PictureBox picture;
        private DataGridView infoTable;
        private TableLayoutPanel tableLayoutPanel1;
    }
}