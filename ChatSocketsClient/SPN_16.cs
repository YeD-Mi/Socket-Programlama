using System;
using System.Collections.Generic;
using System.Text;

namespace ChatSocketsClient
{
    public class SPN_16
    {
        private string plainText, bin_plainText, key, bin_Key, s_Boxes = "", cipherText;


        #region Constructors
        public SPN_16(string key)
        {
            this.key = key;
            this.bin_Key = this.stringToBinary(this.key);
        }
        public SPN_16(string plain_Text, string key)
        {
            this.key = key;
            this.bin_Key = this.stringToBinary(this.key);
            this.plainText = plain_Text;
            this.bin_plainText = this.stringToBinary(this.plainText);
        }
        #endregion

        #region Convert to Binary/ to String
        //Convert string to binary
        private string stringToBinary(string data)
        {
            string binary = "";
            for (int i = 0; i < data.Length; i++)
            {
                binary += Convert.ToString(data[i], 2).PadLeft(8, '0');
            }

            return binary;
        }

        // Convert binary to string
        public string binaryToString(string enctxt)
        {
            // use your encoding here
            Encoding enc = System.Text.Encoding.ASCII;

            string binaryString = enctxt.Replace(" ", "");

            var bytes = new byte[binaryString.Length / 8];

            var ilen = (int)(binaryString.Length / 8);

            for (var i = 0; i < ilen; i++)
            {
                bytes[i] = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);
            }

            string str = enc.GetString(bytes);

            return str;

        }

        #endregion

        #region XOR
        private string xor(string text, string key)
        {
            string bin_xor = "";
            int xor = 0;
            for (int i = 0; i < 16; i++)// Do xor for every character
            {
                xor = Convert.ToInt32(text[i]) ^ Convert.ToInt32(key[i]);
                bin_xor += xor.ToString();
            }
            return bin_xor;
        }
        #endregion

        #region Substitution
        private string substitution(string data)
        {
            string p_Data = "";
            p_Data += data[2]; p_Data += data[8]; p_Data += data[12]; p_Data += data[5];
            p_Data += data[9]; p_Data += data[0]; p_Data += data[14]; p_Data += data[4];
            p_Data += data[11]; p_Data += data[1]; p_Data += data[15]; p_Data += data[6];
            p_Data += data[3]; p_Data += data[10]; p_Data += data[7]; p_Data += data[13];


            return p_Data;
        }

        private string r_Substitution(string data)
        {
            string rp_Data = "";
            rp_Data += data[5]; rp_Data += data[9]; rp_Data += data[0]; rp_Data += data[12];
            rp_Data += data[7]; rp_Data += data[3]; rp_Data += data[11]; rp_Data += data[14];
            rp_Data += data[1]; rp_Data += data[4]; rp_Data += data[13]; rp_Data += data[8];
            rp_Data += data[2]; rp_Data += data[15]; rp_Data += data[6]; rp_Data += data[10];




            return rp_Data;

        }
        #endregion

        #region encrypt-decrypt
        public string encrypt()
        {

            string xor = "";
            string data = this.bin_plainText;

            for (int i = 0; i < this.bin_plainText.Length; i += 16)
            {
                data = this.bin_plainText.Substring(i, 16);// Take 2 character of text (binary version)

                for (int j = 0; j < 64; j += 16) // Take 2 character of key  (binary version)
                {
                    xor = this.xor(data, this.bin_Key.Substring(j, 16));

                    if (j < 32)// Don't use substitution if key is k2 and  k3
                    {
                        s_Boxes = this.substitution(xor);
                    }
                    else
                    {
                        s_Boxes = xor;
                    }

                    data = s_Boxes;

                }
                this.cipherText += data;
            }

            return this.cipherText;
        }

        public string decrypt(string data)
        {

            string xor = "";
            string plain_Text = "";
            string cipher_Text = data;

            for (int i = 0; i < cipher_Text.Length; i += 16)
            {
                data = cipher_Text.Substring(i, 16); // Take 2 character of crypted text  (binary version)

                for (int j = 48; j >= 0; j -= 16) // Take 2 character of key  (binary version)
                {
                    xor = this.xor(data, this.bin_Key.Substring(j, 16));

                    if (j == 48 || j == 0)// Don't use reverse substitution if key is k0 or  k3
                    {
                        s_Boxes = xor;
                    }
                    else
                    {
                        s_Boxes = this.r_Substitution(xor);
                    }

                    data = s_Boxes;

                }

                plain_Text += data;
            }

            return this.binaryToString(plain_Text); // plain_Text is binary string so we have to convert it to  string
        }

        #endregion
    }
}
