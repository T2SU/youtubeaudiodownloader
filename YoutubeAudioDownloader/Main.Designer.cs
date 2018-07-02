namespace YoutubeAudioDownloader
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.textSaveDir = new System.Windows.Forms.TextBox();
            this.buttonBrowseSaveDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textDownloadURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.listDownloads = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.labelCurrentDownload = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "저장 폴더";
            // 
            // textSaveDir
            // 
            this.textSaveDir.Location = new System.Drawing.Point(75, 6);
            this.textSaveDir.Name = "textSaveDir";
            this.textSaveDir.Size = new System.Drawing.Size(634, 21);
            this.textSaveDir.TabIndex = 1;
            // 
            // buttonBrowseSaveDir
            // 
            this.buttonBrowseSaveDir.Location = new System.Drawing.Point(715, 6);
            this.buttonBrowseSaveDir.Name = "buttonBrowseSaveDir";
            this.buttonBrowseSaveDir.Size = new System.Drawing.Size(87, 21);
            this.buttonBrowseSaveDir.TabIndex = 2;
            this.buttonBrowseSaveDir.Text = "...";
            this.buttonBrowseSaveDir.UseVisualStyleBackColor = true;
            this.buttonBrowseSaveDir.Click += new System.EventHandler(this.buttonBrowseSaveDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "다운로드 주소";
            // 
            // textDownloadURL
            // 
            this.textDownloadURL.Location = new System.Drawing.Point(103, 59);
            this.textDownloadURL.Name = "textDownloadURL";
            this.textDownloadURL.Size = new System.Drawing.Size(605, 21);
            this.textDownloadURL.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(111, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "https://www.youtube.com/watch?v=LVO_Nykd8Vk";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(715, 60);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(87, 38);
            this.buttonDownload.TabIndex = 6;
            this.buttonDownload.Text = "다운로드";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // listDownloads
            // 
            this.listDownloads.FormattingEnabled = true;
            this.listDownloads.ItemHeight = 12;
            this.listDownloads.Location = new System.Drawing.Point(15, 128);
            this.listDownloads.Name = "listDownloads";
            this.listDownloads.Size = new System.Drawing.Size(784, 244);
            this.listDownloads.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "다운로드 대기 목록";
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(15, 380);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(786, 24);
            this.progressDownload.TabIndex = 9;
            // 
            // labelCurrentDownload
            // 
            this.labelCurrentDownload.Location = new System.Drawing.Point(14, 411);
            this.labelCurrentDownload.Name = "labelCurrentDownload";
            this.labelCurrentDownload.Size = new System.Drawing.Size(788, 11);
            this.labelCurrentDownload.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(629, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "텐시야 (Tensiya) [2018.07.03]";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 431);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelCurrentDownload);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listDownloads);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDownloadURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowseSaveDir);
            this.Controls.Add(this.textSaveDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Youtube Audio Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSaveDir;
        private System.Windows.Forms.Button buttonBrowseSaveDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDownloadURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListBox listDownloads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.Windows.Forms.Label labelCurrentDownload;
        private System.Windows.Forms.Label label5;
    }
}

