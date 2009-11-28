using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace RijndaelCrypto
{
    public partial class MainForm : Form
    {
        RijndaelManaged rijndael;
        int m_iBlockSize = 128;

        public MainForm()
        {
            InitializeComponent();

            cbbBlockSize.SelectedIndex = 0;
        }

        private byte[] CreateKey(string pass)
        {
            byte[] bytes = new byte[m_iBlockSize / 8];
            Encoding.ASCII.GetBytes(pass).CopyTo(bytes, 0);
            return bytes;
        }

        private byte[] CreateIV(string pass)
        {
            byte[] bytes =new byte[m_iBlockSize / 8];
            Encoding.ASCII.GetBytes(pass).CopyTo(bytes, 0);
            return bytes;
        }

        private void EncryptFile(string inFile, string outFile, string pass, int iBlockSize)
        {
            rijndael = new RijndaelManaged();
            rijndael.BlockSize = iBlockSize;
            
            byte[] key = CreateKey(pass);
            byte[] IV = CreateIV(pass);

            rijndael.Key = key;
            rijndael.IV = IV;
            rijndael.Padding = PaddingMode.PKCS7;

            try
            {
                FileStream inFs = new FileStream(inFile, FileMode.Open, FileAccess.Read);
                FileStream outFs = new FileStream(outFile, FileMode.Create, FileAccess.Write);

                ICryptoTransform encrypt = rijndael.CreateEncryptor(key, IV);
                CryptoStream cs = new CryptoStream(outFs, encrypt, CryptoStreamMode.Write);

                int b;
                while ((b = inFs.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)b);
                }

                cs.FlushFinalBlock();
                cs.Close();
                inFs.Close();
                outFs.Close();
            }
            catch { }
        }

        private void DescryptFile(string inFile, string outFile, string pass, int iBlockSize)
        {
            rijndael = new RijndaelManaged();
            rijndael.BlockSize = iBlockSize;
            
            byte[] key = CreateKey(pass);
            byte[] IV = CreateIV(pass);

            rijndael.Key = key;
            rijndael.IV = IV;
            rijndael.Padding = PaddingMode.PKCS7;

            try
            {
                FileStream inFs = new FileStream(inFile, FileMode.Open, FileAccess.Read);
                FileStream outFs = new FileStream(outFile, FileMode.Create, FileAccess.Write);

                ICryptoTransform descrypt = rijndael.CreateDecryptor(key, IV);
                CryptoStream cs = new CryptoStream(outFs, descrypt, CryptoStreamMode.Write);

                int b;
                while ((b = inFs.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)b);
                }

                cs.FlushFinalBlock();
                cs.Close();
                inFs.Close();
                outFs.Close();
            }
            catch { }
        }

        private void btnBrowsePlainFile_Click(object sender, EventArgs e)
        {
            tbPlainFile.Text = "";
            openFileDialog.Filter = "All file|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbPlainFile.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseEncryptedFile_Click(object sender, EventArgs e)
        {
            tbEncryptedFile.Text = "";
            openFileDialog.Filter = "Encrypted file|*.enc";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbEncryptedFile.Text = openFileDialog.FileName;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (tbPlainFile.Text.Trim() != string.Empty)
            {
                if (tbKey.Text.Trim() != string.Empty)
                {
                    try
                    {
                        string key = tbKey.Text.Trim();
                        string inFile = tbPlainFile.Text.Trim();
                        string outFile = tbPlainFile.Text.Trim() + ".enc";
                        int block = int.Parse(cbbBlockSize.Text);

                        EncryptFile(inFile, outFile, key, block);

                        MessageBox.Show("Encrypt complete.", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
                else
                {
                    MessageBox.Show("Please input key.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please input file name.", "Error");
            }
        }

        private void btnDescrypt_Click(object sender, EventArgs e)
        {
            if (tbEncryptedFile.Text.Trim() != string.Empty)
            {
                if (tbKey.Text.Trim() != string.Empty)
                {
                    try
                    {
                        string key = tbKey.Text.Trim();
                        string inFile = tbEncryptedFile.Text.Trim();
                        int lastIndex = inFile.LastIndexOf('.');
                        string outFile = inFile.Substring(0, lastIndex);
                        int block = int.Parse(cbbBlockSize.Text);

                        DescryptFile(inFile, outFile, key, block);

                        MessageBox.Show("Descrypt complete.", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
                else
                {
                    MessageBox.Show("Please input key.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please input file name.", "Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbbBlockSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_iBlockSize = int.Parse(cbbBlockSize.Text);
            tbKey.MaxLength = m_iBlockSize / 8;
            labelKey.Text = "Key (" + tbKey.MaxLength.ToString() + " chars) :";
        }
    }
}
