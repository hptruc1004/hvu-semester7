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

namespace CryptoExercise
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
            rijndael.Padding = PaddingMode.None;


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

        private void DecryptFile(string inFile, string outFile, string pass, int iBlockSize)
        {
            rijndael = new RijndaelManaged();
            rijndael.BlockSize = iBlockSize;
            
            byte[] key = CreateKey(pass);
            byte[] IV = CreateIV(pass);

            rijndael.Key = key;
            rijndael.IV = IV;
            rijndael.Padding = PaddingMode.None;

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

                        if (cbRSAEnable.Checked)
                        {
                            // encrypt key and write to file
                            StreamWriter keyStream = new StreamWriter("./key", false, Encoding.ASCII);
                            try
                            {
                                ASCIIEncoding encoder = new ASCIIEncoding();
                                byte[] enc = EncryptData(encoder.GetBytes(key));
                                keyStream.Write(Convert.ToBase64String(enc));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Exception");
                            }
                            finally
                            {
                                keyStream.Close();
                            }
                        }

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

        private void btnDecrypt_Click(object sender, EventArgs e)
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

                        if (cbRSAEnable.Checked)
                        {
                            StreamReader keyStream = new StreamReader("./key");
                            try
                            {
                                ASCIIEncoding encoder = new ASCIIEncoding();
                                byte[] enc = Convert.FromBase64String(keyStream.ReadToEnd());
                                byte[] dec = DecryptData(enc);
                                key = encoder.GetString(dec);
                                tbKey.Text = key;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Exception");
                            }
                            finally
                            {
                                keyStream.Close();
                            }
                        }

                        DecryptFile(inFile, outFile, key, block);

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

        int m_iRSAKeySize;
        RSACryptoServiceProvider m_RSAProvider = null;

        private void btnRSAGenerateKey_Click(object sender, EventArgs e)
        {
            if (tbRSAKeySize.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Key size is empty.", " Error");
                return;
            }
            try
            {
                m_iRSAKeySize = int.Parse(tbRSAKeySize.Text.Trim());
                if ((m_iRSAKeySize % 8 != 0) ||
                    (m_iRSAKeySize < 384 || m_iRSAKeySize > 16384))
                {
                    MessageBox.Show("Key size is invalid.", "Error");
                    m_iRSAKeySize = -1;
                    return;
                }
                GenerateKeys();
                MessageBox.Show("RSA key generate complete.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void GenerateKeys()
        {
            m_RSAProvider = new RSACryptoServiceProvider(m_iRSAKeySize);

            StreamWriter publicStream = new StreamWriter("./publickey.xml");
            try
            {
                publicStream.Write(m_RSAProvider.ToXmlString(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                publicStream.Close();
            }

            StreamWriter publicPrivateStream = new StreamWriter("./publicprivatekey.xml");
            try
            {
                publicPrivateStream.Write(m_RSAProvider.ToXmlString(true));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                publicPrivateStream.Close();
            }

            /*
            // test here
            ASCIIEncoding encoder = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Plain text: {0}", tbKey.Text));
            byte[] enc = m_RSAProvider.Encrypt(encoder.GetBytes(tbKey.Text), false);
            sb.AppendLine(string.Format("Encrypted: {0}", Convert.ToBase64String(enc)));
            byte[] dec = m_RSAProvider.Decrypt(enc, false);
            sb.AppendLine(string.Format("Decrypt: {0}", Convert.ToBase64String(dec)));
            sb.AppendLine(string.Format("Text: {0}", encoder.GetString(dec))); 

            MessageBox.Show(sb.ToString());
            */
        }

        private byte[] EncryptData(byte[] data)
        {
            StreamReader publicStream = new StreamReader("./publickey.xml");

            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                m_RSAProvider.FromXmlString(publicStream.ReadToEnd());

                byte[] cipher = m_RSAProvider.Encrypt(data, false);

                return cipher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                publicStream.Close();
            }
        }

        private byte[] DecryptData(byte[] data)
        {
            StreamReader privatePublicStream = new StreamReader("./publicprivatekey.xml");

            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                m_RSAProvider.FromXmlString(privatePublicStream.ReadToEnd());

                byte[] plain = m_RSAProvider.Decrypt(data, false);

                return plain;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                privatePublicStream.Close();
            }
        }
    }
}
