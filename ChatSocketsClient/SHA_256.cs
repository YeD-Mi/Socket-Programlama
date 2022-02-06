using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ChatSocketsClient
{
    public class SHA_256
    {
        private string plain_Text;
        #region Constructor
        public SHA_256(string plain_Text)
        {
            this.plain_Text = plain_Text;
        }
        #endregion

        #region Encrypt
        public string encrypt()
        {
            SHA256Managed sha256 = new SHA256Managed();
            Byte[] b_Text = Encoding.ASCII.GetBytes(this.plain_Text);
            b_Text = sha256.ComputeHash(b_Text);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in b_Text)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();

        }
        #endregion


    }
}
