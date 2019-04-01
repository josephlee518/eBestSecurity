namespace WindowsFormsApp1
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accountCnt = new System.Windows.Forms.Label();
            this.chkPaperTrading = new System.Windows.Forms.CheckBox();
            this.stopAutoTrading = new System.Windows.Forms.Button();
            this.startAutoTrding = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchjongMok = new System.Windows.Forms.Button();
            this.jongmokCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stockQty = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockQty)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(70, 20);
            this.txtID.MaxLength = 8;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 21);
            this.txtID.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(236, 20);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // txtPasswordIn
            // 
            this.txtPasswordIn.Location = new System.Drawing.Point(430, 20);
            this.txtPasswordIn.Name = "txtPasswordIn";
            this.txtPasswordIn.PasswordChar = '*';
            this.txtPasswordIn.Size = new System.Drawing.Size(100, 21);
            this.txtPasswordIn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "비밀번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "공인인증 비번";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.accountCnt);
            this.groupBox1.Controls.Add(this.chkPaperTrading);
            this.groupBox1.Controls.Add(this.stopAutoTrading);
            this.groupBox1.Controls.Add(this.startAutoTrding);
            this.groupBox1.Controls.Add(this.Quit);
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtPasswordIn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "증권사 로그인";
            // 
            // accountCnt
            // 
            this.accountCnt.AutoSize = true;
            this.accountCnt.Font = new System.Drawing.Font("굴림", 12F);
            this.accountCnt.Location = new System.Drawing.Point(22, 50);
            this.accountCnt.Name = "accountCnt";
            this.accountCnt.Size = new System.Drawing.Size(0, 16);
            this.accountCnt.TabIndex = 12;
            // 
            // chkPaperTrading
            // 
            this.chkPaperTrading.AutoSize = true;
            this.chkPaperTrading.Location = new System.Drawing.Point(70, 50);
            this.chkPaperTrading.Name = "chkPaperTrading";
            this.chkPaperTrading.Size = new System.Drawing.Size(72, 16);
            this.chkPaperTrading.TabIndex = 10;
            this.chkPaperTrading.Text = "모의투자";
            this.chkPaperTrading.UseVisualStyleBackColor = true;
            this.chkPaperTrading.CheckedChanged += new System.EventHandler(this.chkPaperTrading_CheckedChanged);
            // 
            // stopAutoTrading
            // 
            this.stopAutoTrading.Location = new System.Drawing.Point(345, 46);
            this.stopAutoTrading.Name = "stopAutoTrading";
            this.stopAutoTrading.Size = new System.Drawing.Size(104, 23);
            this.stopAutoTrading.TabIndex = 11;
            this.stopAutoTrading.Text = "자동매매 중지";
            this.stopAutoTrading.UseVisualStyleBackColor = true;
            this.stopAutoTrading.Click += new System.EventHandler(this.stopAutoTrading_Click);
            // 
            // startAutoTrding
            // 
            this.startAutoTrding.Location = new System.Drawing.Point(235, 46);
            this.startAutoTrding.Name = "startAutoTrding";
            this.startAutoTrding.Size = new System.Drawing.Size(104, 23);
            this.startAutoTrding.TabIndex = 10;
            this.startAutoTrding.Text = "자동매매 실행";
            this.startAutoTrding.UseVisualStyleBackColor = true;
            this.startAutoTrding.Click += new System.EventHandler(this.startAutoTrding_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(455, 46);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 7;
            this.Quit.Text = "종료";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(154, 46);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 6;
            this.Connect.Text = "접속";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // LogBox
            // 
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 12;
            this.LogBox.Location = new System.Drawing.Point(6, 45);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(541, 100);
            this.LogBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAccount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LogBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 151);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "로그";
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(85, 20);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(126, 20);
            this.cmbAccount.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "계좌번호";
            // 
            // SearchjongMok
            // 
            this.SearchjongMok.Location = new System.Drawing.Point(388, 18);
            this.SearchjongMok.Name = "SearchjongMok";
            this.SearchjongMok.Size = new System.Drawing.Size(57, 23);
            this.SearchjongMok.TabIndex = 10;
            this.SearchjongMok.Text = "주문";
            this.SearchjongMok.UseVisualStyleBackColor = true;
            this.SearchjongMok.Click += new System.EventHandler(this.SearchjongMok_Click);
            // 
            // jongmokCode
            // 
            this.jongmokCode.Location = new System.Drawing.Point(75, 20);
            this.jongmokCode.Name = "jongmokCode";
            this.jongmokCode.Size = new System.Drawing.Size(100, 21);
            this.jongmokCode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "종목코드";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F);
            this.label6.Location = new System.Drawing.Point(181, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "수량";
            // 
            // stockQty
            // 
            this.stockQty.Location = new System.Drawing.Point(220, 20);
            this.stockQty.Name = "stockQty";
            this.stockQty.Size = new System.Drawing.Size(56, 21);
            this.stockQty.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.stockQty);
            this.groupBox3.Controls.Add(this.SearchjongMok);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.jongmokCode);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 265);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "거래종목 설정";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(541, 212);
            this.dataGridView1.TabIndex = 16;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(282, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "매수";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(335, 23);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "매도";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 530);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "AutoTrader for EBest (TEST Ver.)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockQty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button stopAutoTrading;
        private System.Windows.Forms.Button startAutoTrding;
        private System.Windows.Forms.CheckBox chkPaperTrading;
        private System.Windows.Forms.Label accountCnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button SearchjongMok;
        private System.Windows.Forms.TextBox jongmokCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown stockQty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

