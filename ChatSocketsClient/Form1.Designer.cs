
namespace ChatSocketsClient
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_sifrele = new System.Windows.Forms.Button();
            this.crypto = new System.Windows.Forms.TextBox();
            this.SpnKey = new System.Windows.Forms.Label();
            this.sha256RB = new System.Windows.Forms.RadioButton();
            this.spn16RB = new System.Windows.Forms.RadioButton();
            this.SifreliTxt = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MesajTxt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SifreCoz_Btn = new System.Windows.Forms.Button();
            this.KeySpn = new System.Windows.Forms.Label();
            this.SpnKeyTxt = new System.Windows.Forms.TextBox();
            this.SpnRB = new System.Windows.Forms.RadioButton();
            this.shaRB = new System.Windows.Forms.RadioButton();
            this.CozulenMesaj = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SifreliMesaj = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Spn16Key = new System.Windows.Forms.Label();
            this.Spn16KeyTxt = new System.Windows.Forms.TextBox();
            this.GonderSPNBtn = new System.Windows.Forms.Button();
            this.SmsTxt = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.ChatTxt = new System.Windows.Forms.RichTextBox();
            this.EkleBtn = new System.Windows.Forms.Button();
            this.GonderBtn = new System.Windows.Forms.Button();
            this.BaglanBtn = new System.Windows.Forms.Button();
            this.UserTxt = new System.Windows.Forms.TextBox();
            this.UserLbl = new System.Windows.Forms.Label();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.PortLbl = new System.Windows.Forms.Label();
            this.IpLbl = new System.Windows.Forms.Label();
            this.IpTxt = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 531);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_sifrele);
            this.tabPage1.Controls.Add(this.crypto);
            this.tabPage1.Controls.Add(this.SpnKey);
            this.tabPage1.Controls.Add(this.sha256RB);
            this.tabPage1.Controls.Add(this.spn16RB);
            this.tabPage1.Controls.Add(this.SifreliTxt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.MesajTxt);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(506, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sifrele";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btn_sifrele
            // 
            this.btn_sifrele.Location = new System.Drawing.Point(372, 398);
            this.btn_sifrele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_sifrele.Name = "btn_sifrele";
            this.btn_sifrele.Size = new System.Drawing.Size(126, 45);
            this.btn_sifrele.TabIndex = 8;
            this.btn_sifrele.Text = "Sifrele";
            this.btn_sifrele.UseVisualStyleBackColor = true;
            this.btn_sifrele.Click += new System.EventHandler(this.btn_sifrele_Click);
            // 
            // crypto
            // 
            this.crypto.Location = new System.Drawing.Point(372, 188);
            this.crypto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.crypto.Name = "crypto";
            this.crypto.Size = new System.Drawing.Size(103, 28);
            this.crypto.TabIndex = 7;
            this.crypto.Text = "crypto12";
            this.crypto.Visible = false;
            // 
            // SpnKey
            // 
            this.SpnKey.AutoSize = true;
            this.SpnKey.Location = new System.Drawing.Point(368, 148);
            this.SpnKey.Name = "SpnKey";
            this.SpnKey.Size = new System.Drawing.Size(84, 20);
            this.SpnKey.TabIndex = 6;
            this.SpnKey.Text = "SPN-Key;";
            this.SpnKey.Visible = false;
            // 
            // sha256RB
            // 
            this.sha256RB.AutoSize = true;
            this.sha256RB.Location = new System.Drawing.Point(372, 56);
            this.sha256RB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sha256RB.Name = "sha256RB";
            this.sha256RB.Size = new System.Drawing.Size(98, 24);
            this.sha256RB.TabIndex = 5;
            this.sha256RB.TabStop = true;
            this.sha256RB.Text = "SHA-256";
            this.sha256RB.UseVisualStyleBackColor = true;
            this.sha256RB.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // spn16RB
            // 
            this.spn16RB.AutoSize = true;
            this.spn16RB.Location = new System.Drawing.Point(372, 98);
            this.spn16RB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spn16RB.Name = "spn16RB";
            this.spn16RB.Size = new System.Drawing.Size(88, 24);
            this.spn16RB.TabIndex = 4;
            this.spn16RB.TabStop = true;
            this.spn16RB.Text = "SPN-16";
            this.spn16RB.UseVisualStyleBackColor = true;
            this.spn16RB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // SifreliTxt
            // 
            this.SifreliTxt.Location = new System.Drawing.Point(12, 274);
            this.SifreliTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SifreliTxt.Name = "SifreliTxt";
            this.SifreliTxt.Size = new System.Drawing.Size(337, 168);
            this.SifreliTxt.TabIndex = 3;
            this.SifreliTxt.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifreli;";
            // 
            // MesajTxt
            // 
            this.MesajTxt.Location = new System.Drawing.Point(10, 55);
            this.MesajTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MesajTxt.Name = "MesajTxt";
            this.MesajTxt.Size = new System.Drawing.Size(337, 168);
            this.MesajTxt.TabIndex = 1;
            this.MesajTxt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mesaj;";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SifreCoz_Btn);
            this.tabPage2.Controls.Add(this.KeySpn);
            this.tabPage2.Controls.Add(this.SpnKeyTxt);
            this.tabPage2.Controls.Add(this.SpnRB);
            this.tabPage2.Controls.Add(this.shaRB);
            this.tabPage2.Controls.Add(this.CozulenMesaj);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.SifreliMesaj);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(506, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SifreCoz_Btn
            // 
            this.SifreCoz_Btn.Location = new System.Drawing.Point(362, 411);
            this.SifreCoz_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SifreCoz_Btn.Name = "SifreCoz_Btn";
            this.SifreCoz_Btn.Size = new System.Drawing.Size(126, 45);
            this.SifreCoz_Btn.TabIndex = 16;
            this.SifreCoz_Btn.Text = "Sifre Coz";
            this.SifreCoz_Btn.UseVisualStyleBackColor = true;
            this.SifreCoz_Btn.Click += new System.EventHandler(this.SifreCoz_Btn_Click);
            // 
            // KeySpn
            // 
            this.KeySpn.AutoSize = true;
            this.KeySpn.Location = new System.Drawing.Point(360, 165);
            this.KeySpn.Name = "KeySpn";
            this.KeySpn.Size = new System.Drawing.Size(84, 20);
            this.KeySpn.TabIndex = 15;
            this.KeySpn.Text = "SPN-Key;";
            // 
            // SpnKeyTxt
            // 
            this.SpnKeyTxt.Location = new System.Drawing.Point(362, 206);
            this.SpnKeyTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpnKeyTxt.Name = "SpnKeyTxt";
            this.SpnKeyTxt.Size = new System.Drawing.Size(103, 28);
            this.SpnKeyTxt.TabIndex = 13;
            this.SpnKeyTxt.Text = "crypto12";
            // 
            // SpnRB
            // 
            this.SpnRB.AutoSize = true;
            this.SpnRB.Location = new System.Drawing.Point(364, 111);
            this.SpnRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpnRB.Name = "SpnRB";
            this.SpnRB.Size = new System.Drawing.Size(88, 24);
            this.SpnRB.TabIndex = 11;
            this.SpnRB.TabStop = true;
            this.SpnRB.Text = "SPN-16";
            this.SpnRB.UseVisualStyleBackColor = true;
            // 
            // shaRB
            // 
            this.shaRB.AutoSize = true;
            this.shaRB.Location = new System.Drawing.Point(364, 72);
            this.shaRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shaRB.Name = "shaRB";
            this.shaRB.Size = new System.Drawing.Size(98, 24);
            this.shaRB.TabIndex = 10;
            this.shaRB.TabStop = true;
            this.shaRB.Text = "SHA-256";
            this.shaRB.UseVisualStyleBackColor = true;
            this.shaRB.CheckedChanged += new System.EventHandler(this.shaRB_CheckedChanged);
            // 
            // CozulenMesaj
            // 
            this.CozulenMesaj.Location = new System.Drawing.Point(10, 288);
            this.CozulenMesaj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CozulenMesaj.Name = "CozulenMesaj";
            this.CozulenMesaj.Size = new System.Drawing.Size(337, 168);
            this.CozulenMesaj.TabIndex = 6;
            this.CozulenMesaj.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mesaj;";
            // 
            // SifreliMesaj
            // 
            this.SifreliMesaj.Location = new System.Drawing.Point(10, 72);
            this.SifreliMesaj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SifreliMesaj.Name = "SifreliMesaj";
            this.SifreliMesaj.Size = new System.Drawing.Size(337, 168);
            this.SifreliMesaj.TabIndex = 4;
            this.SifreliMesaj.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifreli Mesaj;";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Spn16Key);
            this.tabPage3.Controls.Add(this.Spn16KeyTxt);
            this.tabPage3.Controls.Add(this.GonderSPNBtn);
            this.tabPage3.Controls.Add(this.SmsTxt);
            this.tabPage3.Controls.Add(this.lblStatus);
            this.tabPage3.Controls.Add(this.tabControl);
            this.tabPage3.Controls.Add(this.EkleBtn);
            this.tabPage3.Controls.Add(this.GonderBtn);
            this.tabPage3.Controls.Add(this.BaglanBtn);
            this.tabPage3.Controls.Add(this.UserTxt);
            this.tabPage3.Controls.Add(this.UserLbl);
            this.tabPage3.Controls.Add(this.PortTxt);
            this.tabPage3.Controls.Add(this.PortLbl);
            this.tabPage3.Controls.Add(this.IpLbl);
            this.tabPage3.Controls.Add(this.IpTxt);
            this.tabPage3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(506, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sohbet";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Spn16Key
            // 
            this.Spn16Key.AutoSize = true;
            this.Spn16Key.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Spn16Key.Location = new System.Drawing.Point(6, 454);
            this.Spn16Key.Name = "Spn16Key";
            this.Spn16Key.Size = new System.Drawing.Size(67, 19);
            this.Spn16Key.TabIndex = 17;
            this.Spn16Key.Text = "SpnKey:";
            // 
            // Spn16KeyTxt
            // 
            this.Spn16KeyTxt.Location = new System.Drawing.Point(79, 450);
            this.Spn16KeyTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Spn16KeyTxt.Name = "Spn16KeyTxt";
            this.Spn16KeyTxt.Size = new System.Drawing.Size(144, 28);
            this.Spn16KeyTxt.TabIndex = 16;
            this.Spn16KeyTxt.Text = "crypto12";
            // 
            // GonderSPNBtn
            // 
            this.GonderSPNBtn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GonderSPNBtn.Location = new System.Drawing.Point(118, 411);
            this.GonderSPNBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GonderSPNBtn.Name = "GonderSPNBtn";
            this.GonderSPNBtn.Size = new System.Drawing.Size(133, 31);
            this.GonderSPNBtn.TabIndex = 15;
            this.GonderSPNBtn.Text = "Gonder (SPN16)";
            this.GonderSPNBtn.UseVisualStyleBackColor = true;
            this.GonderSPNBtn.Click += new System.EventHandler(this.GonderSPNBtn_Click);
            // 
            // SmsTxt
            // 
            this.SmsTxt.Location = new System.Drawing.Point(106, 376);
            this.SmsTxt.Name = "SmsTxt";
            this.SmsTxt.Size = new System.Drawing.Size(308, 28);
            this.SmsTxt.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(309, 453);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 20);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Durum:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGlobal);
            this.tabControl.Location = new System.Drawing.Point(10, 112);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(477, 257);
            this.tabControl.TabIndex = 11;
            // 
            // tabGlobal
            // 
            this.tabGlobal.Controls.Add(this.ChatTxt);
            this.tabGlobal.Location = new System.Drawing.Point(4, 29);
            this.tabGlobal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGlobal.Size = new System.Drawing.Size(469, 224);
            this.tabGlobal.TabIndex = 1;
            this.tabGlobal.Text = "Global";
            this.tabGlobal.UseVisualStyleBackColor = true;
            // 
            // ChatTxt
            // 
            this.ChatTxt.Location = new System.Drawing.Point(12, 20);
            this.ChatTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChatTxt.Name = "ChatTxt";
            this.ChatTxt.Size = new System.Drawing.Size(430, 196);
            this.ChatTxt.TabIndex = 7;
            this.ChatTxt.Text = "";
            // 
            // EkleBtn
            // 
            this.EkleBtn.Location = new System.Drawing.Point(420, 377);
            this.EkleBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EkleBtn.Name = "EkleBtn";
            this.EkleBtn.Size = new System.Drawing.Size(52, 30);
            this.EkleBtn.TabIndex = 10;
            this.EkleBtn.Text = "Ekle";
            this.EkleBtn.UseVisualStyleBackColor = true;
            this.EkleBtn.Click += new System.EventHandler(this.EkleBtn_Click);
            // 
            // GonderBtn
            // 
            this.GonderBtn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GonderBtn.Location = new System.Drawing.Point(254, 411);
            this.GonderBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GonderBtn.Name = "GonderBtn";
            this.GonderBtn.Size = new System.Drawing.Size(133, 31);
            this.GonderBtn.TabIndex = 9;
            this.GonderBtn.Text = "Gonder (SHA256)";
            this.GonderBtn.UseVisualStyleBackColor = true;
            this.GonderBtn.Click += new System.EventHandler(this.GonderBtn_Click);
            // 
            // BaglanBtn
            // 
            this.BaglanBtn.Location = new System.Drawing.Point(356, 66);
            this.BaglanBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BaglanBtn.Name = "BaglanBtn";
            this.BaglanBtn.Size = new System.Drawing.Size(131, 39);
            this.BaglanBtn.TabIndex = 6;
            this.BaglanBtn.Text = "Baglan";
            this.BaglanBtn.UseVisualStyleBackColor = true;
            this.BaglanBtn.Click += new System.EventHandler(this.BaglanBtn_Click);
            // 
            // UserTxt
            // 
            this.UserTxt.Location = new System.Drawing.Point(350, 22);
            this.UserTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserTxt.Name = "UserTxt";
            this.UserTxt.Size = new System.Drawing.Size(144, 28);
            this.UserTxt.TabIndex = 5;
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserLbl.Location = new System.Drawing.Point(254, 25);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(90, 22);
            this.UserLbl.TabIndex = 4;
            this.UserLbl.Text = "Kullanıcı:";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(94, 69);
            this.PortTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(144, 28);
            this.PortTxt.TabIndex = 3;
            this.PortTxt.Text = "1024";
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortLbl.Location = new System.Drawing.Point(6, 71);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(80, 22);
            this.PortLbl.TabIndex = 2;
            this.PortLbl.Text = "Port-No:";
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IpLbl.Location = new System.Drawing.Point(6, 25);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(64, 22);
            this.IpLbl.TabIndex = 1;
            this.IpLbl.Text = "IP-No:";
            // 
            // IpTxt
            // 
            this.IpTxt.Location = new System.Drawing.Point(94, 18);
            this.IpTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IpTxt.Name = "IpTxt";
            this.IpTxt.Size = new System.Drawing.Size(144, 28);
            this.IpTxt.TabIndex = 0;
            this.IpTxt.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 562);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "WHATSAPP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox crypto;
        private System.Windows.Forms.Label SpnKey;
        private System.Windows.Forms.RadioButton sha256RB;
        private System.Windows.Forms.RadioButton spn16RB;
        private System.Windows.Forms.RichTextBox SifreliTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox MesajTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_sifrele;
        private System.Windows.Forms.TextBox SpnKeyTxt;
        private System.Windows.Forms.RadioButton SpnRB;
        private System.Windows.Forms.RadioButton shaRB;
        private System.Windows.Forms.RichTextBox CozulenMesaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox SifreliMesaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label KeySpn;
        private System.Windows.Forms.Button SifreCoz_Btn;
        private System.Windows.Forms.Button EkleBtn;
        private System.Windows.Forms.Button GonderBtn;
        private System.Windows.Forms.RichTextBox ChatTxt;
        private System.Windows.Forms.Button BaglanBtn;
        private System.Windows.Forms.TextBox UserTxt;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.Label IpLbl;
        private System.Windows.Forms.TextBox IpTxt;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox SmsTxt;
        private System.Windows.Forms.Button GonderSPNBtn;
        private System.Windows.Forms.Label Spn16Key;
        private System.Windows.Forms.TextBox Spn16KeyTxt;
    }
}

