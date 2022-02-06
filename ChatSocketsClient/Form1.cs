using ChatSocketsServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using static ChatSocketsClient.Properties.Settings;

namespace ChatSocketsClient
{
    public partial class Form1 : Form
    {
        private delegate void UpdateCallBack(string message);
        private delegate void CloseConnectionCallBack(string reason);

        private string UserName;
        private StreamWriter stwSender;
        private StreamReader strReceiver;
        private TcpClient tcpServer;

        private TcpListener listener;
        private Thread thrListener;
        private bool listening;

        private Thread messageThread;
        private IPAddress serverIpAddress;
        private int serverHostPort;
        private bool connected;

        public List<DirectConnection> Connections = new List<DirectConnection>();
        public string encrypted_Text, decrypted_Text;
        public Form1()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SpnKey.Visible = true;
            crypto.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SpnKey.Visible = false;
            crypto.Visible = false;
        }
        public string TRCevir(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }

        private void btn_sifrele_Click(object sender, EventArgs e)
        {
            MesajTxt.Text = TRCevir(MesajTxt.Text);
            if (MesajTxt.Text == "") { MessageBox.Show("Mesaj bos olamaz.", "Hata-1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }   // can't be empty
            else
            {

                if (spn16RB.Checked == true)
                {
                    if (crypto.Text == "") { MessageBox.Show("SPN-Key bos olamaz.", "Hata-2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (crypto.Text.Length != 8)
                    {
                        SifreliTxt.Text = " ";
                      MessageBox.Show("Key 8 karakter olmalidir.", "Hata-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (MesajTxt.Text.Length % 2 == 1) { MesajTxt.Text += " "; }  // uzunluk çift değilse sona boşluk eklenir.
                    else
                    {
                        SPN_16 spn = new SPN_16(MesajTxt.Text, crypto.Text);
                        SifreliTxt.Text = spn.encrypt();
                    }

                }
                else if (sha256RB.Checked == true)
                {
                    SHA_256 sha = new SHA_256(MesajTxt.Text);
                    SifreliTxt.Text = sha.encrypt();
                }
                else if (spn16RB.Checked == false && spn16RB.Checked == false) { MessageBox.Show("Sifreleme Yontemi Secmelisin...", "Hata-4", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }


                encrypted_Text = SifreliTxt.Text;
                MesajTxt.Text = "";
            }
        }

        private void shaRB_CheckedChanged(object sender, EventArgs e)
        {
            shaRB.Checked = false;
        }

        private void BaglanBtn_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                StartConnection();
            }
            else
            {
                CloseConnection("Kullanici baglantisi kesildi.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateVisibility(false);
        }

        private void GonderBtn_Click(object sender, EventArgs e)
        {
            SHA_256 sha = new SHA_256(SmsTxt.Text);
            string gidensha256=sha.encrypt();
            SendToServer(MsgCode.GlobalChat, gidensha256);
            MessageBox.Show("Alici bu mesaji goremez, bilgin olsun...","Bilgilendirme");
            SmsTxt.Text = " ";
        }
        private void SendToServer(MsgCode code, string body)
        {
            var text = MsgEncoding.Encode(code, body);
            stwSender.WriteLine(text);
            stwSender.Flush();
        }
        private void SendToServer(string body)
        {
            var text = MsgEncoding.Encode(MsgCode.Standard, body);
            stwSender.WriteLine(text);
            stwSender.Flush();
        }
        private void StartDirectConnection(string address)
        {
            var parameters = address.Split(":");
            var ipAddress = IPAddress.Parse(parameters[0]);
            var hostPort = int.Parse(parameters[1]);
            var userName = parameters[2];
            var tcpContact = new TcpClient();
            tcpContact.Connect(ipAddress, hostPort);
            var connection = new DirectConnection(tcpContact, userName, this);
            connection.SendToClient(MsgCode.Standard, UserName);
        }
        public void StartListener(string address)
        {
            var parameters = address.Split(":");
            IPAddress ipLocal = IPAddress.Parse(parameters[0]);
            int portLocal = int.Parse(parameters[1]);

            listener = new TcpListener(ipLocal, portLocal);
            listener.Start();
            listening = true;

            thrListener = new Thread(KeepListening);
            thrListener.IsBackground = true;
            thrListener.Start();
        }
        public void KeepListening()
        {
            while (listening)
            {
                var tcpClient = listener.AcceptTcpClient();
                DirectConnection connection = new DirectConnection(tcpClient, this);
            }
        }
        private void UpdateVisibility(bool connected)
        {
            IpTxt.Enabled = !connected;
            PortTxt.Enabled = !connected;
            UserTxt.Enabled = !connected;
            SmsTxt.Enabled = connected;
            GonderBtn.Enabled = connected;
            GonderSPNBtn.Enabled = connected;
            EkleBtn.Enabled = connected;
            Spn16KeyTxt.Enabled = connected;
            BaglanBtn.Text = connected ? "Cikis" : "Baglan";
        }
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (connected)
            {
                connected = false;
                stwSender.Close();
                strReceiver.Close();
                tcpServer.Close();

                lblStatus.Invoke(new Action(() => lblStatus.Text = "Baglanti Kes"));
            }
        }
        private void CloseConnection(string reason)
        {
            UpdateVisibility(false);

            connected = false;
            stwSender.Close();
            strReceiver.Close();
            tcpServer.Close();

            lblStatus.Invoke(new Action(() => lblStatus.Text = "Baglanti Kesildi"));
        }
        private void RequestOnlineList()
        {
            SendToServer(MsgCode.OnlineListRequest, "");
        }
        private void SendMessage(String mesaj)
        {
            if (SmsTxt.Lines.Length != 0)
            {
                SendToServer(MsgCode.GlobalChat, mesaj);
            }
            SmsTxt.Lines = null;
            SmsTxt.Text = "";
        }
        private void UpdateLog(string message)
        {
            ChatTxt.AppendText(message + "\r\n");
        }
        private void ReceiveMessages()
        {
            strReceiver = new StreamReader(tcpServer.GetStream());
            while (connected)
            {
                string answerString = strReceiver.ReadLine();
                var answer = MsgEncoding.Decode(answerString);
                switch (answer.Code)
                {
                    case MsgCode.ConnectionSuccess:
                        Invoke(new UpdateCallBack(UpdateLog), new object[] { "Baglanti Kuruldu!" });
                        StartListener(answer.Body);
                        break;
                    case MsgCode.ConnectionError:
                        string reason = $"Baglanti Hatasi {answer.Body}";
                        Invoke(new UpdateCallBack(CloseConnection), new object[] { reason });
                        break;
                    case MsgCode.GlobalChat:
                        Invoke(new UpdateCallBack(UpdateLog), new object[] { answer.Body });
                        break;
                }
            }
        }
        private void StartConnection()
        {
            try
            {
                serverIpAddress = IPAddress.Parse(IpTxt.Text);
                serverHostPort = Convert.ToInt32(PortTxt.Text);
                tcpServer = new TcpClient();
                tcpServer.Connect(serverIpAddress, serverHostPort);
                connected = true;
                UserName = UserTxt.Text;
                UpdateVisibility(true);

                stwSender = new StreamWriter(tcpServer.GetStream());
                SendToServer(UserTxt.Text);

                messageThread = new Thread(ReceiveMessages);
                messageThread.IsBackground = true;
                messageThread.Start();

                lblStatus.Invoke(new Action(() => lblStatus.Text = "Bagli"));
                RequestOnlineList();
            }
            catch
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = "Baglanti Hatasi"));
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void GonderSPNBtn_Click(object sender, EventArgs e)
        {
            if (Spn16KeyTxt.Text == "") { MessageBox.Show("SPN-Key bos olamaz.", "Hata-2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (Spn16KeyTxt.Text.Length != 8) { MessageBox.Show("Key 8 karakter olmalidir.", "Hata-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            if (SmsTxt.Text.Length % 2 == 1) { SmsTxt.Text += " "; }                                                                              // uzunluk çift değilse sona boşluk eklenir.

            SPN_16 spn = new SPN_16(SmsTxt.Text, Spn16KeyTxt.Text);
            String Spn16 = spn.encrypt();
            SendMessage(Spn16);      
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            string secilenDosya;
            OpenFileDialog OD = new OpenFileDialog();
            if (OD.ShowDialog() == DialogResult.OK)
            {
                secilenDosya = OD.FileName;
                SendMessage(secilenDosya);
            }
        }

        private void SifreCoz_Btn_Click(object sender, EventArgs e)
        {
            if (SifreliMesaj.Text == "") { MessageBox.Show("Sifreli mesaj kutusu bos..", "Hata-6", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (SpnRB.Checked == false) { MessageBox.Show("SPN-16 seciniz. (SHA-256 secilemez!) ", "Hata-7", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (SpnKeyTxt.Text == "") { MessageBox.Show("Spn key bos olamaz..", "Hata-8", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (SpnKeyTxt.Text.Length != 8) { MessageBox.Show("Spn Key 8 karakter olmalidir.", "Hata-9", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (SifreliMesaj.Text.Length % 2 == 1) { MessageBox.Show("Be sure there is only '0'and '1' in descrypted text "); }
            else
            {
                SifreliMesaj.Text.Replace(" ", "");
                SPN_16 spn = new SPN_16(SpnKeyTxt.Text);
                CozulenMesaj.Text = spn.decrypt(SifreliMesaj.Text);
                decrypted_Text = CozulenMesaj.Text;
                SifreliMesaj.Text = "";
            }
        }
    }
}