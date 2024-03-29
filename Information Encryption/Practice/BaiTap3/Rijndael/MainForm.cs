﻿using System;
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
            cbbPadding.SelectedIndex = 0;
            cbbMode.SelectedIndex = 0;
        }

        private byte[] CreateKey(string pass)
        {
            byte[] bytes = new byte[m_iBlockSize / 8];
            Encoding.ASCII.GetBytes(pass).CopyTo(bytes, 0); ;
            return bytes;
        }

        private byte[] CreateIV(string pass)
        {
            byte[] bytes = new byte[m_iBlockSize / 8];
            Encoding.ASCII.GetBytes(pass).CopyTo(bytes, 0);
            return bytes;
        }

        private void EncryptFile(string inFile, string outFile, string pass, string sIV, int iBlockSize, CipherMode cm, PaddingMode pm)
        {
            rijndael = new RijndaelManaged();
            rijndael.BlockSize = rijndael.KeySize = iBlockSize;
            
            byte[] key = CreateKey(pass);
            byte[] IV = CreateIV(sIV);

            rijndael.Key = key;
            rijndael.IV = IV;
            rijndael.Mode = cm;
            rijndael.Padding = pm;

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

                inFs.Close();
                outFs.Flush();
                outFs.Close();
                cs.FlushFinalBlock();
                cs.Close();
            }
            catch (Exception ex)
            { }
        }

        private void DescryptFile(string inFile, string outFile, string pass, string sIV, int iBlockSize, CipherMode cm, PaddingMode pm)
        {
            rijndael = new RijndaelManaged();
            rijndael.BlockSize = rijndael.KeySize = iBlockSize;
            
            byte[] key = CreateKey(pass);
            byte[] IV = CreateIV(sIV);

            rijndael.Key = key;
            rijndael.IV = IV;
            rijndael.Mode = cm;
            rijndael.Padding = pm;

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

                inFs.Close();
                outFs.Flush();
                outFs.Close();
                cs.FlushFinalBlock();
                cs.Close();
            }
            catch (Exception ex)
            { }
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
                    string iv = tbKey.Text.Trim();
                    if (tbIV.Text.Trim() != string.Empty)
                    {
                        iv = tbIV.Text.Trim();
                    }
                    try
                    {
                        string key = tbKey.Text.Trim();
                        string inFile = tbPlainFile.Text.Trim();
                        string outFile = tbPlainFile.Text.Trim() + ".enc";
                        int block = int.Parse(cbbBlockSize.Text);

                        CipherMode cm = CipherMode.CBC;
                        PaddingMode pm = PaddingMode.PKCS7;
                        switch (cbbPadding.SelectedIndex)
                        {
                            case 0:
                                pm = PaddingMode.PKCS7;
                                break;
                            case 1:
                                pm = PaddingMode.ANSIX923;
                                break;
                            case 2:
                                pm = PaddingMode.ISO10126;
                                break;
                            case 3:
                                pm = PaddingMode.None;
                                break;
                            default:
                                pm = PaddingMode.PKCS7;
                                break;
                        }
                        switch (cbbMode.SelectedIndex)
                        {
                            case 0:
                                cm = CipherMode.ECB;
                                break;
                            case 1:
                                cm = CipherMode.CBC;
                                break;
                            case 2:
                                cm = CipherMode.OFB;
                                break;
                            case 3:
                                cm = CipherMode.CFB;
                                break;
                            case 4:
                                cm = CipherMode.CTS;
                                break;
                            default:
                                cm = CipherMode.ECB;
                                break;
                        }

                        EncryptFile(inFile, outFile, key, iv, block, cm, pm);

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
                    string iv = tbKey.Text.Trim();
                    if (tbIV.Text.Trim() != string.Empty)
                    {
                        iv = tbIV.Text.Trim();
                    }
                    try
                    {
                        string key = tbKey.Text.Trim();
                        string inFile = tbEncryptedFile.Text.Trim();
                        int lastIndex = inFile.LastIndexOf('.');
                        string outFile = inFile.Substring(0, lastIndex);
                        int block = int.Parse(cbbBlockSize.Text);

                        CipherMode cm = CipherMode.CBC;
                        PaddingMode pm = PaddingMode.PKCS7;
                        switch (cbbPadding.SelectedIndex)
                        {
                            case 0:
                                pm = PaddingMode.PKCS7;
                                break;
                            case 1:
                                pm = PaddingMode.ANSIX923;
                                break;
                            case 2:
                                pm = PaddingMode.ISO10126;
                                break;
                            case 3:
                                pm = PaddingMode.None;
                                break;
                            default:
                                pm = PaddingMode.PKCS7;
                                break;
                        }
                        switch (cbbMode.SelectedIndex)
                        {
                            case 0:
                                cm = CipherMode.ECB;
                                break;
                            case 1:
                                cm = CipherMode.CBC;
                                break;
                            case 2:
                                cm = CipherMode.OFB;
                                break;
                            case 3:
                                cm = CipherMode.CFB;
                                break;
                            case 4:
                                cm = CipherMode.CTS;
                                break;
                            default:
                                cm = CipherMode.ECB;
                                break;
                        }
     
                        DescryptFile(inFile, outFile, key, iv, block, cm, pm);

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
            labelIV.Text = "IV (" + tbKey.MaxLength.ToString() + " chars) - optional:";
        }
    }
}
