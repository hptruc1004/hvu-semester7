using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace HashAlgo
{
    public partial class MainForm : Form
    {
        HashAlgorithm m_HashAlgo;
        const string HASH_DATA_FILTER = "sha1|*.sha1|md5|*.md5|sha256|*.sha26|sha384|*.sha384|sha512|*.sha512";
        public MainForm()
        {
            InitializeComponent();

            cbbHashAlgo.SelectedIndex = 0;
        }

        private HashAlgorithm UpdateHashAlgorithm()
        {
            switch (cbbHashAlgo.SelectedIndex)
            {
                case 0:
                    return new SHA1Managed();
                case 1:
                    return new MD5CryptoServiceProvider();
                case 2:
                    return new SHA256Managed();
                case 3:
                    return new SHA384Managed();
                case 4:
                    return new SHA512Managed();
                default:
                    return null;
            }
        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All files|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbInput.Text = openFileDialog.FileName;
            }
        }

        private void btnHashData_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = HASH_DATA_FILTER;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbHash.Text = openFileDialog.FileName;
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Input file is invalid.", "Error");
                return;
            }

            FileStream fs = null;
            StreamWriter output = null;
            try
            {
                m_HashAlgo = UpdateHashAlgorithm();
                fs = new FileStream(tbInput.Text.Trim(), FileMode.Open, FileAccess.Read);

                string ext;

                switch (cbbHashAlgo.SelectedIndex)
                {
                    case 0:
                        ext = "sha1";
                        break;
                    case 1:
                        ext = "md5";
                        break;
                    case 2:
                        ext = "sha256";
                        break;
                    case 3:
                        ext = "sha384";
                        break;
                    case 4:
                        ext = "sha512";
                        break;
                    default:
                        ext = "sha1";
                        break;
                }

                output = new StreamWriter(tbInput.Text.Trim() + "." + ext, false, Encoding.Default);


                byte[] hash;

                //byte[] bytes = new byte[fs.Length];
                //fs.Read(bytes, 0, fs.Length);
                //hash = m_HashAlgo.ComputeHash(bytes, 0, bytes.Length);

                hash = m_HashAlgo.ComputeHash(fs);

                //string hashString = Convert.ToBase64String(hash);
                string hexHashString = ConvertToHex(hash);
                output.Write(hexHashString);
                output.Flush();

                MessageBox.Show("Compute hash complete", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (output != null)
                    output.Close();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Input file is invalid.", "Error");
                return;
            }
            if (tbHash.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hash file is invalid.", "Error");
                return;
            }

            FileStream fs = null;
            StreamReader hashStream = null;
            try
            {
                fs = new FileStream(tbInput.Text.Trim(), FileMode.Open, FileAccess.Read);
                hashStream = new StreamReader(tbHash.Text.Trim(), Encoding.Default);

                string ext = tbHash.Text.Substring(tbHash.Text.LastIndexOf('.') + 1, tbHash.Text.Length - tbHash.Text.LastIndexOf('.') - 1);

                switch (ext)
                {
                    case "sha1":
                        m_HashAlgo = new SHA1Managed();
                        break;
                    case "md5":
                        m_HashAlgo = new MD5CryptoServiceProvider();
                        break;
                    case "sha256":
                        m_HashAlgo = new SHA256Managed();
                        break;
                    case "sha384":
                        m_HashAlgo = new SHA384Managed();
                        break;
                    case "sha512":
                        m_HashAlgo = new SHA512Managed();
                        break;
                    default:
                        throw new Exception("Extension not supported");
                }

                byte[] hash;

                //byte[] bytes = new byte[fs.Length];
                //fs.Read(bytes, 0, fs.Length);
                //hash = m_HashAlgo.ComputeHash(bytes, 0, bytes.Length);

                hash = m_HashAlgo.ComputeHash(fs);

                //string hashString = Convert.ToBase64String(hash);
                string hexHashString = ConvertToHex(hash);
                string hashData = hashStream.ReadToEnd();

                if (hexHashString.Equals(hashData))
                {
                    MessageBox.Show("OK", "Info");
                }
                else
                {
                    MessageBox.Show("Wrong file", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            finally
            {
                if (hashStream != null)
                    hashStream.Close();
            }
        }

        private string ConvertToHex(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(string.Format("{0:x2}", b));
            }
            return sb.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
