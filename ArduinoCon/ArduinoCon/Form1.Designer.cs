namespace ArduinoCon
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.TextBox();
            this.right = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lstat = new System.Windows.Forms.Label();
            this.rstat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 18);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(12, 10);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(89, 21);
            this.left.TabIndex = 6;
            this.left.Text = "LEFT";
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(107, 10);
            this.right.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(88, 21);
            this.right.TabIndex = 2;
            this.right.Text = "RIGHT";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(10, 32);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(17, 12);
            this.status.TabIndex = 3;
            this.status.Text = "...";
            // 
            // lstat
            // 
            this.lstat.AutoSize = true;
            this.lstat.Location = new System.Drawing.Point(10, 67);
            this.lstat.Name = "lstat";
            this.lstat.Size = new System.Drawing.Size(29, 12);
            this.lstat.TabIndex = 4;
            this.lstat.Text = "Left:";
            // 
            // rstat
            // 
            this.rstat.AutoSize = true;
            this.rstat.Location = new System.Drawing.Point(10, 81);
            this.rstat.Name = "rstat";
            this.rstat.Size = new System.Drawing.Size(37, 12);
            this.rstat.TabIndex = 5;
            this.rstat.Text = "Right:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 215);
            this.Controls.Add(this.rstat);
            this.Controls.Add(this.lstat);
            this.Controls.Add(this.status);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Arduino";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox left;
        private System.Windows.Forms.TextBox right;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lstat;
        private System.Windows.Forms.Label rstat;
    }
}

