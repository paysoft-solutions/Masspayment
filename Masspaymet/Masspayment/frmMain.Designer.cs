namespace Masspayment
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.paBottom = new System.Windows.Forms.Panel();
            this.laProgress = new System.Windows.Forms.Label();
            this.buPrev = new System.Windows.Forms.Button();
            this.buNext = new System.Windows.Forms.Button();
            this.paTop = new System.Windows.Forms.Panel();
            this.laTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.laTextFileNamePrivatKey = new System.Windows.Forms.Label();
            this.edTextFileNamePrivatKey = new System.Windows.Forms.TextBox();
            this.buOpenFileNamePrivatKey = new System.Windows.Forms.Button();
            this.laFileNamePrivatKey = new System.Windows.Forms.Label();
            this.edFileNamePrivatKey = new System.Windows.Forms.TextBox();
            this.laContractorPointId = new System.Windows.Forms.Label();
            this.edContractorPointId = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.laDataCSV = new System.Windows.Forms.Label();
            this.dgvDataCSV = new System.Windows.Forms.DataGridView();
            this.buOpenFileNameDataCSV = new System.Windows.Forms.Button();
            this.laFileNameDataCSV = new System.Windows.Forms.Label();
            this.edFileNameDataCSV = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.laWait = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.laFinish1 = new System.Windows.Forms.Label();
            this.buOpenFolder = new System.Windows.Forms.Button();
            this.laFinish0 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.paBottom.SuspendLayout();
            this.paTop.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCSV)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // paBottom
            // 
            this.paBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paBottom.Controls.Add(this.laProgress);
            this.paBottom.Controls.Add(this.buPrev);
            this.paBottom.Controls.Add(this.buNext);
            this.paBottom.Location = new System.Drawing.Point(12, 474);
            this.paBottom.Name = "paBottom";
            this.paBottom.Size = new System.Drawing.Size(850, 29);
            this.paBottom.TabIndex = 0;
            // 
            // laProgress
            // 
            this.laProgress.AutoSize = true;
            this.laProgress.Location = new System.Drawing.Point(4, 8);
            this.laProgress.Name = "laProgress";
            this.laProgress.Size = new System.Drawing.Size(60, 13);
            this.laProgress.TabIndex = 2;
            this.laProgress.Text = "Шаг 1 из 3";
            // 
            // buPrev
            // 
            this.buPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buPrev.Location = new System.Drawing.Point(678, 3);
            this.buPrev.Name = "buPrev";
            this.buPrev.Size = new System.Drawing.Size(75, 23);
            this.buPrev.TabIndex = 1;
            this.buPrev.Text = "Назад";
            this.buPrev.UseVisualStyleBackColor = true;
            this.buPrev.Click += new System.EventHandler(this.buPrev_Click);
            // 
            // buNext
            // 
            this.buNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buNext.Location = new System.Drawing.Point(772, 3);
            this.buNext.Name = "buNext";
            this.buNext.Size = new System.Drawing.Size(75, 23);
            this.buNext.TabIndex = 0;
            this.buNext.Text = "Далее";
            this.buNext.UseVisualStyleBackColor = true;
            this.buNext.Click += new System.EventHandler(this.buNext_Click);
            // 
            // paTop
            // 
            this.paTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paTop.Controls.Add(this.laTitle);
            this.paTop.Location = new System.Drawing.Point(12, 12);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(847, 39);
            this.paTop.TabIndex = 1;
            // 
            // laTitle
            // 
            this.laTitle.AutoSize = true;
            this.laTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laTitle.Location = new System.Drawing.Point(3, 3);
            this.laTitle.Name = "laTitle";
            this.laTitle.Size = new System.Drawing.Size(354, 20);
            this.laTitle.TabIndex = 0;
            this.laTitle.Text = "Массовые платежи: подпись реестра выплат";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.ItemSize = new System.Drawing.Size(42, 18);
            this.tabMain.Location = new System.Drawing.Point(12, 57);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(850, 411);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.laTextFileNamePrivatKey);
            this.tabPage1.Controls.Add(this.edTextFileNamePrivatKey);
            this.tabPage1.Controls.Add(this.buOpenFileNamePrivatKey);
            this.tabPage1.Controls.Add(this.laFileNamePrivatKey);
            this.tabPage1.Controls.Add(this.edFileNamePrivatKey);
            this.tabPage1.Controls.Add(this.laContractorPointId);
            this.tabPage1.Controls.Add(this.edContractorPointId);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(842, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "          Шаг 1          ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // laTextFileNamePrivatKey
            // 
            this.laTextFileNamePrivatKey.AutoSize = true;
            this.laTextFileNamePrivatKey.Location = new System.Drawing.Point(13, 171);
            this.laTextFileNamePrivatKey.Name = "laTextFileNamePrivatKey";
            this.laTextFileNamePrivatKey.Size = new System.Drawing.Size(107, 13);
            this.laTextFileNamePrivatKey.TabIndex = 6;
            this.laTextFileNamePrivatKey.Text = "Содержимое файла";
            // 
            // edTextFileNamePrivatKey
            // 
            this.edTextFileNamePrivatKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edTextFileNamePrivatKey.Location = new System.Drawing.Point(16, 187);
            this.edTextFileNamePrivatKey.Multiline = true;
            this.edTextFileNamePrivatKey.Name = "edTextFileNamePrivatKey";
            this.edTextFileNamePrivatKey.ReadOnly = true;
            this.edTextFileNamePrivatKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edTextFileNamePrivatKey.Size = new System.Drawing.Size(811, 192);
            this.edTextFileNamePrivatKey.TabIndex = 5;
            this.edTextFileNamePrivatKey.TabStop = false;
            // 
            // buOpenFileNamePrivatKey
            // 
            this.buOpenFileNamePrivatKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buOpenFileNamePrivatKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buOpenFileNamePrivatKey.Location = new System.Drawing.Point(791, 111);
            this.buOpenFileNamePrivatKey.Margin = new System.Windows.Forms.Padding(0);
            this.buOpenFileNamePrivatKey.Name = "buOpenFileNamePrivatKey";
            this.buOpenFileNamePrivatKey.Size = new System.Drawing.Size(36, 30);
            this.buOpenFileNamePrivatKey.TabIndex = 4;
            this.buOpenFileNamePrivatKey.Text = "...";
            this.buOpenFileNamePrivatKey.UseVisualStyleBackColor = true;
            this.buOpenFileNamePrivatKey.Click += new System.EventHandler(this.buOpenFileNamePrivatKey_Click);
            // 
            // laFileNamePrivatKey
            // 
            this.laFileNamePrivatKey.AutoSize = true;
            this.laFileNamePrivatKey.Location = new System.Drawing.Point(13, 97);
            this.laFileNamePrivatKey.Name = "laFileNamePrivatKey";
            this.laFileNamePrivatKey.Size = new System.Drawing.Size(221, 13);
            this.laFileNamePrivatKey.TabIndex = 3;
            this.laFileNamePrivatKey.Text = "Путь к файлу с приватным ключём (*.pem)";
            // 
            // edFileNamePrivatKey
            // 
            this.edFileNamePrivatKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFileNamePrivatKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFileNamePrivatKey.Location = new System.Drawing.Point(16, 113);
            this.edFileNamePrivatKey.MaxLength = 255;
            this.edFileNamePrivatKey.Name = "edFileNamePrivatKey";
            this.edFileNamePrivatKey.ReadOnly = true;
            this.edFileNamePrivatKey.Size = new System.Drawing.Size(759, 22);
            this.edFileNamePrivatKey.TabIndex = 2;
            this.edFileNamePrivatKey.TabStop = false;
            this.edFileNamePrivatKey.WordWrap = false;
            // 
            // laContractorPointId
            // 
            this.laContractorPointId.AutoSize = true;
            this.laContractorPointId.Location = new System.Drawing.Point(13, 28);
            this.laContractorPointId.Name = "laContractorPointId";
            this.laContractorPointId.Size = new System.Drawing.Size(290, 13);
            this.laContractorPointId.TabIndex = 1;
            this.laContractorPointId.Text = "ContractorPointId (Только цифры. Длина от 1 до 7 цифр.)";
            // 
            // edContractorPointId
            // 
            this.edContractorPointId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edContractorPointId.Location = new System.Drawing.Point(16, 44);
            this.edContractorPointId.MaxLength = 7;
            this.edContractorPointId.Name = "edContractorPointId";
            this.edContractorPointId.Size = new System.Drawing.Size(287, 22);
            this.edContractorPointId.TabIndex = 0;
            this.edContractorPointId.WordWrap = false;
            this.edContractorPointId.TextChanged += new System.EventHandler(this.edContractorPointId_TextChanged);
            this.edContractorPointId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edContractorPointId_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.laDataCSV);
            this.tabPage2.Controls.Add(this.dgvDataCSV);
            this.tabPage2.Controls.Add(this.buOpenFileNameDataCSV);
            this.tabPage2.Controls.Add(this.laFileNameDataCSV);
            this.tabPage2.Controls.Add(this.edFileNameDataCSV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "          Шаг 2          ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // laDataCSV
            // 
            this.laDataCSV.AutoSize = true;
            this.laDataCSV.Location = new System.Drawing.Point(12, 81);
            this.laDataCSV.Name = "laDataCSV";
            this.laDataCSV.Size = new System.Drawing.Size(107, 13);
            this.laDataCSV.TabIndex = 9;
            this.laDataCSV.Text = "Содержимое файла";
            // 
            // dgvDataCSV
            // 
            this.dgvDataCSV.AllowUserToAddRows = false;
            this.dgvDataCSV.AllowUserToDeleteRows = false;
            this.dgvDataCSV.AllowUserToOrderColumns = true;
            this.dgvDataCSV.AllowUserToResizeRows = false;
            this.dgvDataCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataCSV.Location = new System.Drawing.Point(15, 97);
            this.dgvDataCSV.Name = "dgvDataCSV";
            this.dgvDataCSV.ReadOnly = true;
            this.dgvDataCSV.Size = new System.Drawing.Size(811, 282);
            this.dgvDataCSV.TabIndex = 8;
            // 
            // buOpenFileNameDataCSV
            // 
            this.buOpenFileNameDataCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buOpenFileNameDataCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buOpenFileNameDataCSV.Location = new System.Drawing.Point(790, 42);
            this.buOpenFileNameDataCSV.Margin = new System.Windows.Forms.Padding(0);
            this.buOpenFileNameDataCSV.Name = "buOpenFileNameDataCSV";
            this.buOpenFileNameDataCSV.Size = new System.Drawing.Size(36, 30);
            this.buOpenFileNameDataCSV.TabIndex = 7;
            this.buOpenFileNameDataCSV.Text = "...";
            this.buOpenFileNameDataCSV.UseVisualStyleBackColor = true;
            this.buOpenFileNameDataCSV.Click += new System.EventHandler(this.buOpenFileNameDataCSV_Click);
            // 
            // laFileNameDataCSV
            // 
            this.laFileNameDataCSV.AutoSize = true;
            this.laFileNameDataCSV.Location = new System.Drawing.Point(12, 28);
            this.laFileNameDataCSV.Name = "laFileNameDataCSV";
            this.laFileNameDataCSV.Size = new System.Drawing.Size(184, 13);
            this.laFileNameDataCSV.TabIndex = 6;
            this.laFileNameDataCSV.Text = "Путь к файлу  с операциями (*.csv)";
            // 
            // edFileNameDataCSV
            // 
            this.edFileNameDataCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFileNameDataCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFileNameDataCSV.Location = new System.Drawing.Point(15, 44);
            this.edFileNameDataCSV.MaxLength = 255;
            this.edFileNameDataCSV.Name = "edFileNameDataCSV";
            this.edFileNameDataCSV.ReadOnly = true;
            this.edFileNameDataCSV.Size = new System.Drawing.Size(759, 22);
            this.edFileNameDataCSV.TabIndex = 5;
            this.edFileNameDataCSV.TabStop = false;
            this.edFileNameDataCSV.WordWrap = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.laWait);
            this.tabPage3.Controls.Add(this.progressBar);
            this.tabPage3.Controls.Add(this.laFinish1);
            this.tabPage3.Controls.Add(this.buOpenFolder);
            this.tabPage3.Controls.Add(this.laFinish0);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(842, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "          Шаг 3          ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // laWait
            // 
            this.laWait.AutoSize = true;
            this.laWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laWait.Location = new System.Drawing.Point(41, 147);
            this.laWait.Name = "laWait";
            this.laWait.Size = new System.Drawing.Size(104, 20);
            this.laWait.TabIndex = 5;
            this.laWait.Text = "Ожидайте ...";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(45, 170);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(739, 23);
            this.progressBar.TabIndex = 4;
            // 
            // laFinish1
            // 
            this.laFinish1.AutoSize = true;
            this.laFinish1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laFinish1.Location = new System.Drawing.Point(47, 115);
            this.laFinish1.Name = "laFinish1";
            this.laFinish1.Size = new System.Drawing.Size(484, 20);
            this.laFinish1.TabIndex = 3;
            this.laFinish1.Text = "---------------------------------------------------------------------------------" +
    "--------------";
            // 
            // buOpenFolder
            // 
            this.buOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buOpenFolder.BackgroundImage = global::Masspayment.Properties.Resources.folder;
            this.buOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buOpenFolder.Location = new System.Drawing.Point(568, 83);
            this.buOpenFolder.Name = "buOpenFolder";
            this.buOpenFolder.Size = new System.Drawing.Size(55, 55);
            this.buOpenFolder.TabIndex = 2;
            this.buOpenFolder.TabStop = false;
            this.toolTip1.SetToolTip(this.buOpenFolder, "Открыть папку с файлом...");
            this.buOpenFolder.UseVisualStyleBackColor = true;
            this.buOpenFolder.Click += new System.EventHandler(this.buOpenFolder_Click);
            // 
            // laFinish0
            // 
            this.laFinish0.AutoSize = true;
            this.laFinish0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laFinish0.Location = new System.Drawing.Point(47, 82);
            this.laFinish0.Name = "laFinish0";
            this.laFinish0.Size = new System.Drawing.Size(484, 20);
            this.laFinish0.TabIndex = 1;
            this.laFinish0.Text = "---------------------------------------------------------------------------------" +
    "--------------";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 515);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.paTop);
            this.Controls.Add(this.paBottom);
            this.MinimumSize = new System.Drawing.Size(370, 500);
            this.Name = "frmMain";
            this.Text = "Masspayment";
            this.paBottom.ResumeLayout(false);
            this.paBottom.PerformLayout();
            this.paTop.ResumeLayout(false);
            this.paTop.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCSV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paBottom;
        private System.Windows.Forms.Button buPrev;
        private System.Windows.Forms.Button buNext;
        private System.Windows.Forms.Panel paTop;
        private System.Windows.Forms.Label laTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox edContractorPointId;
        private System.Windows.Forms.Label laContractorPointId;
        private System.Windows.Forms.Label laFileNamePrivatKey;
        private System.Windows.Forms.TextBox edFileNamePrivatKey;
        private System.Windows.Forms.Button buOpenFileNamePrivatKey;
        private System.Windows.Forms.TextBox edTextFileNamePrivatKey;
        private System.Windows.Forms.Label laTextFileNamePrivatKey;
        private System.Windows.Forms.Button buOpenFileNameDataCSV;
        private System.Windows.Forms.Label laFileNameDataCSV;
        private System.Windows.Forms.TextBox edFileNameDataCSV;
        private System.Windows.Forms.DataGridView dgvDataCSV;
        private System.Windows.Forms.Label laProgress;
        private System.Windows.Forms.Label laDataCSV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label laFinish0;
        private System.Windows.Forms.Label laFinish1;
        private System.Windows.Forms.Button buOpenFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label laWait;
    }
}

