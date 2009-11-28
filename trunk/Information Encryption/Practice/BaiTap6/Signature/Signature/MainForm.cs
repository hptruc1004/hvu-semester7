using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Signature
{
    public partial class MainForm : Form
    {
        RSACryptoServiceProvider m_RSAProvider;
        int m_iRSAKeySize = 1024;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            GenerateKeys("sender");
        }

        #region Private Methods
        /// <summary>
        /// Generate RSA key and save to XML file
        /// </summary>
        private void GenerateKeys(string owner)
        {
            m_RSAProvider = new RSACryptoServiceProvider(m_iRSAKeySize);

            StreamWriter publicStream = new StreamWriter("./" + owner + "_publickey.xml");
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

            StreamWriter publicPrivateStream = new StreamWriter("./" + owner + "_publicprivatekey.xml");
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
        }

        /// <summary>
        /// Encrypt data by using RSA
        /// </summary>
        /// <param name="data">Plain data in bytes</param>
        /// <returns>Encrypted data</returns>
        private byte[] EncryptData(byte[] data, string owner)
        {
            StreamReader publicStream = new StreamReader("./" + owner + "_publickey.xml");

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

        /// <summary>
        /// Decrypt data by using RSA
        /// </summary>
        /// <param name="data">Encrypted data in bytes</param>
        /// <returns>Decrypted data</returns>
        private byte[] DecryptData(byte[] data, string owner)
        {
            StreamReader privatePublicStream = new StreamReader("./" + owner + "_publicprivatekey.xml");

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

        /// <summary>
        /// Hash data and sign it
        /// </summary>
        /// <param name="privateKey">Private key of sender</param>
        /// <param name="inputStream">Input stream</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <returns>Signature</returns>
        private byte[] HashAndSign(RSAParameters privateKey, Stream inputStream, HashAlgorithm hashAlgorithm)
        {
            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                // import private key
                m_RSAProvider.ImportParameters(privateKey);
                return m_RSAProvider.SignData(inputStream, hashAlgorithm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verify data in bytes with signature with specific hash algorithm
        /// </summary>
        /// <param name="publicKey">Public key</param>
        /// <param name="buffer">Buffer of data that was signed</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <param name="signature">Signature</param>
        /// <returns>Result of verification</returns>
        private bool VerifyData(RSAParameters publicKey, byte[] buffer, HashAlgorithm hashAlgorithm, byte[] signature)
        {
            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                // import public key
                m_RSAProvider.ImportParameters(publicKey);
                return m_RSAProvider.VerifyData(buffer, hashAlgorithm, signature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hash data and sign it
        /// </summary>
        /// <param name="privateKey">Private key of sender</param>
        /// <param name="inputStream">Input stream</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <returns>Signature</returns>
        private byte[] Sign(RSAParameters privateKey, Stream inputStream, HashAlgorithm hashAlgorithm)
        {
            try
            {
                // hash data
                byte[] hashData = hashAlgorithm.ComputeHash(inputStream);
                m_RSAProvider = new RSACryptoServiceProvider();
                // import private key
                m_RSAProvider.ImportParameters(privateKey);
                return m_RSAProvider.SignHash(hashData, CryptoConfig.MapNameToOID("SHA256"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verify data by hashing and verify with private key
        /// </summary>
        /// <param name="publicKey">Public key</param>
        /// <param name="inputStream">Data stream that is signed</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <param name="signature">Signature</param>
        /// <returns>Result of verification</returns>
        private bool VerifyHash(RSAParameters publicKey, Stream inputStream, HashAlgorithm hashAlgorithm, byte[] signature)
        {
            try
            {
                // hash data
                byte[] hashData = hashAlgorithm.ComputeHash(inputStream);
                m_RSAProvider = new RSACryptoServiceProvider();
                // import public key
                m_RSAProvider.ImportParameters(publicKey);
                return m_RSAProvider.VerifyHash(hashData, CryptoConfig.MapNameToOID("SHA256"), signature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get public parameters for RSA
        /// </summary>
        /// <param name="owner">Owner of the keys</param>
        /// <returns>RSA Parameters</returns>
        private RSAParameters GetPublicParameters(string owner)
        {
            StreamReader publicStream = new StreamReader("./" + owner + "_publickey.xml");

            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                m_RSAProvider.FromXmlString(publicStream.ReadToEnd());

                return m_RSAProvider.ExportParameters(false);
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

        /// <summary>
        /// Get public and private parameters for RSA
        /// </summary>
        /// <param name="owner">Owner of the keys</param>
        /// <returns>RSA parameters</returns>
        private RSAParameters GetPrivateParameters(string owner)
        {
            StreamReader privatePublicStream = new StreamReader("./" + owner + "_publicprivatekey.xml");

            try
            {
                m_RSAProvider = new RSACryptoServiceProvider();
                m_RSAProvider.FromXmlString(privatePublicStream.ReadToEnd());

                return m_RSAProvider.ExportParameters(true);
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
        #endregion

        #region Events
        private void btnBrowseInputFile_Click(object sender, EventArgs e)
        {
            string strAllFileFilter = "All file|*.*";
            openFileDialog.Filter = strAllFileFilter;
            openFileDialog.Title = "Date file... Opening";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbInputFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseSignatureInput_Click(object sender, EventArgs e)
        {
            string strAllFileFilter = "Signature file|*.sig";
            saveFileDialog.Filter = strAllFileFilter;
            saveFileDialog.Title = "Signature file... Saving";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbSignatureInput.Text = saveFileDialog.FileName;
            }
        }

        private void btnBrowseInputFile2_Click(object sender, EventArgs e)
        {
            string strAllFileFilter = "All file|*.*";
            openFileDialog.Filter = strAllFileFilter;
            openFileDialog.Title = "Date file... Opening";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbInputFileName2.Text = openFileDialog.FileName;
            }

        }

        private void btnBrowseSignatureInput2_Click(object sender, EventArgs e)
        {
            string strAllFileFilter = "Signature file|*.sig";
            saveFileDialog.Filter = strAllFileFilter;
            saveFileDialog.Title = "Signature file... Saving";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbSignatureInput2.Text = saveFileDialog.FileName;
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (tbInputFileName.Text.Trim() == string.Empty)
            {
                btnBrowseInputFile_Click(sender, e);
            }
            if (tbSignatureInput.Text.Trim() == string.Empty)
            {
                btnBrowseSignatureInput_Click(sender, e);
            }
            try
            {
                FileStream inputStream = new FileStream(tbInputFileName.Text.Trim(), FileMode.Open, FileAccess.Read);
                FileStream signStream = new FileStream(tbSignatureInput.Text.Trim(), FileMode.Create, FileAccess.Write);

                try
                {
                    // Sign on input stream with private key, and SHA256 hash
                    byte[] signature = Sign(GetPrivateParameters("sender"), inputStream, new SHA256Managed());
                    // write to file
                    signStream.Write(signature, 0, signature.Length);
                    // Inform
                    MessageBox.Show("Sign complete", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
                finally
                {
                    inputStream.Close();
                    signStream.Flush();
                    signStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (tbInputFileName.Text.Trim() == string.Empty)
            {
                btnBrowseInputFile_Click(sender, e);
            }
            if (tbSignatureInput.Text.Trim() == string.Empty)
            {
                string strAllFileFilter = "Signature file|*.sig";
                openFileDialog.Filter = strAllFileFilter;
                openFileDialog.Title = "Signature file... Opening";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbSignatureInput.Text = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            try
            {
                FileStream inputStream = new FileStream(tbInputFileName.Text.Trim(), FileMode.Open, FileAccess.Read);
                FileStream signStream = new FileStream(tbSignatureInput.Text.Trim(), FileMode.Open, FileAccess.Read);

                try
                {
                    // Read signature from file
                    byte[] signature = new byte[signStream.Length];
                    signStream.Read(signature, 0, signature.Length);
                    // Verify
                    if (VerifyHash(GetPublicParameters("sender"), inputStream, new SHA256Managed(), signature))
                    {
                        MessageBox.Show("OK", "Info");
                    }
                    else
                    {
                        MessageBox.Show("Wrong signature", "Info");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
                finally
                {
                    inputStream.Close();
                    signStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void btnSign2_Click(object sender, EventArgs e)
        {
            if (tbInputFileName2.Text.Trim() == string.Empty)
            {
                btnBrowseInputFile2_Click(sender, e);
            }
            if (tbSignatureInput2.Text.Trim() == string.Empty)
            {
                btnBrowseSignatureInput2_Click(sender, e);
            }
            try
            {
                FileStream inputStream = new FileStream(tbInputFileName2.Text.Trim(), FileMode.Open, FileAccess.Read);
                FileStream signStream = new FileStream(tbSignatureInput2.Text.Trim(), FileMode.Create, FileAccess.Write);

                try
                {
                    // hash and sign
                    byte[] signature = HashAndSign(GetPrivateParameters("sender"), inputStream, new SHA256Managed());
                    // write to file
                    signStream.Write(signature, 0, signature.Length);
                    // inform
                    MessageBox.Show("Sign complete", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
                finally
                {
                    inputStream.Close();
                    signStream.Flush();
                    signStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void btnVerify2_Click(object sender, EventArgs e)
        {
            if (tbInputFileName2.Text.Trim() == string.Empty)
            {
                btnBrowseInputFile_Click(sender, e);
            }
            if (tbSignatureInput2.Text.Trim() == string.Empty)
            {
                string strAllFileFilter = "Signature file|*.sig";
                openFileDialog.Filter = strAllFileFilter;
                openFileDialog.Title = "Signature file... Opening";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbSignatureInput2.Text = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            try
            {
                FileStream inputStream = new FileStream(tbInputFileName2.Text.Trim(), FileMode.Open, FileAccess.Read);
                FileStream signStream = new FileStream(tbSignatureInput2.Text.Trim(), FileMode.Open, FileAccess.Read);

                try
                {
                    // read signature
                    byte[] signature = new byte[signStream.Length];
                    signStream.Read(signature, 0, signature.Length);
                    // get the buffer
                    byte[] buffer = new byte[inputStream.Length];
                    inputStream.Read(buffer, 0, buffer.Length);
                    // verify
                    if (VerifyData(GetPublicParameters("sender"), buffer, new SHA256Managed(), signature))
                    {
                        MessageBox.Show("OK", "Info");
                    }
                    else
                    {
                        MessageBox.Show("Wrong signature", "Info");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
                finally
                {
                    inputStream.Close();
                    signStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
        #endregion
    }
}
