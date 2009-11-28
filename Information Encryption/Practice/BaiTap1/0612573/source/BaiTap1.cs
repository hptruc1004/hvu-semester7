using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Word;


namespace MHTT
{
    public partial class BaiTap1 : Form
    {
        class CComparer : IComparer<KeyValuePair<string, int>>
        {
            #region IComparer<KeyValuePair<string,int>> Members

            public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
            {
                if (x.Value > y.Value)
                    return -1;
                if (x.Value == y.Value)
                    return 0;

                return 1;
            }

            #endregion
        }

        #region --TABLE--
        const int RAWTABLELENGTH = 26;

        const int TABLELENGTH = 33;
        char[] TABLE = new char[TABLELENGTH] {
         'a', 'b', 'c', 'd', 'e',
         'f', 'g', 'h', 'i', 'j',
         'k', 'l', 'm', 'n', 'o',
         'p', 'q', 'r', 's', 't',
         'u', 'v', 'w', 'x', 'y',
         'z', 'ă', 'â', 'đ', 'ê', 
         'ơ', 'ô', 'ư'
        };

        const int FULLTABLELENGTH = 93;
        char[] FULLTABLE = new char[FULLTABLELENGTH] {
            // VOWELs
            'a', 'á', 'à', 'ả', 'ã', 'ạ',
            'ă', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
            'â', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ',
            'e', 'é', 'è', 'ẻ', 'ẽ', 'ẹ',
            'ê', 'ế', 'ề', 'ể', 'ễ', 'ệ',
            'i', 'í', 'ì', 'ỉ', 'ĩ', 'ị',
            'o', 'ó', 'ò', 'ỏ', 'õ', 'ọ',
            'ơ', 'ớ', 'ờ', 'ở', 'ỡ', 'ợ',
            'ô', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ',
            'u', 'ú', 'ù', 'ủ', 'ũ', 'ụ',
            'ư', 'ứ', 'ừ', 'ử', 'ữ', 'ự',
            'y', 'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ',
            // CONSONANTs
            'b', 'c' ,'d', 'f', 'g', 'h',
            'j', 'k', 'l', 'm', 'n', 'p',
            'q', 'r', 's', 't', 'v', 'w', 
            'x', 'z', 'đ'
        };

        int[] MAPTABLE = new int[FULLTABLELENGTH] {
            // VOWELs
             0,  0,  0,  0,  0,  0,     // a
            26, 26, 26, 26, 26, 26,     // aw
            27, 27, 27, 27, 27, 27,     // aa
             4,  4,  4,  4,  4,  4,     // e
            29, 29, 29, 29, 29, 29,     // ee
             8,  8,  8,  8,  8,  8,     // i
            14, 14, 14, 14, 14, 14,     // o
            30, 30, 30, 30, 30, 30,     // ow
            31, 31, 31, 31, 31, 31,     // oo
            20, 20, 20, 20, 20, 20,     // u
            32, 32, 32, 32, 32, 32,     // uw
            24, 24, 24, 24, 24, 24,     // y
            // CONSONANTs
             1,  2,  3,  5,  6,  7,     // 'b', 'c', 'd', 'f', 'g', 'h',
             9, 10, 11, 12, 13, 15,     // 'j', 'k', 'l', 'm', 'n', 'p',
            16, 17, 18, 19, 21, 22,     // 'q', 'r', 's', 't', 'v', 'w', 
            23, 25, 28                  // 'x', 'z', 'đ'
        };
        #endregion

        int rawText;
        int countC;
        string content = string.Empty;


        public BaiTap1()
        {
            InitializeComponent();

            // set default
            rawText = 1;        // Khong xet dau
            countC = 1;         // 1 char
            cbCount.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openDocFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (openDocFileDialog.FileName != string.Empty)
                {
                    rtbContent.Clear();
                    ApplicationClass docClass;
                    Document doc = null;
                    object nullObj = Missing.Value;
                    try
                    {
                        docClass = new ApplicationClass();
                        tbDocFile.Text = openDocFileDialog.FileName;

                        object filePath = openDocFileDialog.FileName;
                        doc = docClass.Documents.Open(ref filePath, ref nullObj, ref nullObj, ref nullObj,
                                                ref nullObj, ref nullObj, ref nullObj, ref nullObj, ref nullObj, ref nullObj,
                                                ref nullObj, ref nullObj, ref nullObj, ref nullObj, ref nullObj, ref nullObj);

                        doc.ActiveWindow.Selection.WholeStory();
                        doc.ActiveWindow.Selection.Copy();

                        IDataObject data = Clipboard.GetDataObject();
                        rtbContent.Text = data.GetData(DataFormats.UnicodeText).ToString();
                        // read data to string variable
                        content = data.GetData(DataFormats.UnicodeText).ToString().ToLower();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        doc.Close(ref nullObj, ref nullObj, ref nullObj);
                    }
                }
            }
        }

        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            switch (countC)
            {
                case 1:
                    OneCharacter();
                    break;
                case 2:
                    TwoCharacter();
                    break;
                case 3:
                    ThreeCharacter();
                    break;
            }

        }

        /// <summary>
        /// Chi xet 3 character
        /// </summary>
        private void ThreeCharacter()
        {
            StreamWriter writer = null;
            Dictionary<string, int> dict = new Dictionary<string, int>();


            try
            {
                writer = new StreamWriter(".\\data.txt", false, Encoding.Unicode);
                int total = 0;

                if (rawText == 1)
                {
                    char c1, c2, c3;
                    StringBuilder tc = new StringBuilder(3);
                    for (int i = 0; i < content.Length - 2; i++)
                    {
                        c1 = content[i];
                        c2 = content[i + 1];
                        c3 = content[i + 2];

                        // check if this is a character and remove dau
                        if (CheckString(ref c1, ref c2, ref c3))
                        {
                            total++;
                            c1 = TABLE[MapRawIndex(GetIndex(c1))];
                            c2 = TABLE[MapRawIndex(GetIndex(c2))];
                            c3 = TABLE[MapRawIndex(GetIndex(c3))];

                            tc.Append(c1);
                            tc.Append(c2);
                            tc.Append(c3);
                            // if exist in dict, increase amount by 1
                            if (dict.ContainsKey(tc.ToString()))
                            {
                                dict[tc.ToString()]++;
                            }
                            else
                            {
                                // if not, add new index
                                dict.Add(tc.ToString(), 1);
                            }
                            tc = new StringBuilder(3);
                        }
                    }
                    List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(dict.Count);
                    sortedList.AddRange(dict);
                    sortedList.Sort(new CComparer());


                    writer.WriteLine(string.Format("Total: {0}", total));

                    int len = (dict.Count > 100) ? 100 : dict.Count;
                    for (int i = 0; i < len; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", sortedList[i].Key, sortedList[i].Value, sortedList[i].Value * 1.0 / total));
                    }
                }
                else if (rawText == 0)
                {
                    char c1, c2, c3;
                    StringBuilder tc = new StringBuilder(3);
                    for (int i = 0; i < content.Length - 2; i++)
                    {
                        c1 = content[i];
                        c2 = content[i + 1];
                        c3 = content[i + 2];

                        // check if this is a character and remove dau
                        if (CheckString(ref c1, ref c2, ref c3))
                        {
                            total++;

                            tc.Append(c1);
                            tc.Append(c2);
                            tc.Append(c3);
                            // if exist in dict, increase amount by 1
                            if (dict.ContainsKey(tc.ToString()))
                            {
                                dict[tc.ToString()]++;
                            }
                            else
                            {
                                // if not, add new index
                                dict.Add(tc.ToString(), 1);
                            }
                            tc = new StringBuilder(3);
                        }
                    }
                    List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(dict.Count);
                    sortedList.AddRange(dict);
                    sortedList.Sort(new CComparer());


                    writer.WriteLine(string.Format("Total: {0}", total));

                    int len = (dict.Count > 100) ? 100 : dict.Count;
                    for (int i = 0; i < len; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", sortedList[i].Key, sortedList[i].Value, sortedList[i].Value * 1.0 / total));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Chi xet 1 character
        /// </summary>
        private void OneCharacter()
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(".\\data.txt", false, Encoding.Unicode);
                int total = 0;
                if (rawText == 1)
                {
                    int[] arr = new int[RAWTABLELENGTH];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = 0;
                    }

                    for (int i = 0; i < content.Length; i++)
                    {
                        int ind;
                        // check if this is a character
                        if ((ind = GetIndex(content[i])) != -1)
                        {
                            arr[MapRawIndex(ind)] += 1;     // exception solved
                            total++;
                        }
                    }

                    writer.WriteLine(string.Format("Total: {0}", total));

                    for (int i = 0; i < RAWTABLELENGTH; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", TABLE[i], arr[i], arr[i] * 1.0 / total));
                    }
                }
                else if (rawText == 0)
                {
                    int[] arr = new int[TABLELENGTH];
                    for (int i = 0; i < TABLELENGTH; i++)
                    {
                        arr[i] = 0;
                    }

                    int ind;
                    for (int i = 0; i < content.Length; i++)
                    {
                        if ((ind = GetIndex(content[i])) != -1)
                        {
                            arr[ind] += 1;  //*** exception index - solved
                            total++;
                        }
                    }

                    writer.WriteLine(string.Format("Total: {0}", total));

                    for (int i = 0; i < TABLELENGTH; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", (char)(TABLE[i]), arr[i], arr[i] * 1.0 / total));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Xet 2 character
        /// </summary>
        private void TwoCharacter()
        {
            StreamWriter writer = null;
            Dictionary<string, int> dict = new Dictionary<string, int>();


            try
            {
                writer = new StreamWriter(".\\data.txt", false, Encoding.Unicode);
                int total = 0;
                
                if (rawText == 1)
                {
                    char c1, c2;
                    StringBuilder tc = new StringBuilder(2);
                    for (int i = 0; i < content.Length - 1; i++)
                    {
                        c1 = content[i];
                        c2 = content[i + 1];

                        // check if this is a character and remove dau
                        if (CheckString(ref c1, ref c2))
                        {
                            total++;
                            c1 = TABLE[MapRawIndex(GetIndex(c1))];
                            c2 = TABLE[MapRawIndex(GetIndex(c2))];

                            tc.Append(c1);
                            tc.Append(c2);
                            // if exist in dict, increase amount by 1
                            if (dict.ContainsKey(tc.ToString()))
                            {
                                dict[tc.ToString()]++;
                            }
                            else
                            {
                                // if not, add new index
                                dict.Add(tc.ToString(), 1);
                            }
                            tc = new StringBuilder(2);
                        }
                    }
                    List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(dict.Count);
                    sortedList.AddRange(dict);
                    sortedList.Sort(new CComparer());


                    writer.WriteLine(string.Format("Total: {0}", total));

                    int len = (dict.Count > 100) ? 100 : dict.Count;
                    for (int i = 0; i < len; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", sortedList[i].Key, sortedList[i].Value, sortedList[i].Value * 1.0 / total));
                    }
                }
                else if (rawText == 0)
                {
                    char c1, c2;
                    StringBuilder tc = new StringBuilder(2);
                    for (int i = 0; i < content.Length - 1; i++)
                    {
                        c1 = content[i];
                        c2 = content[i + 1];

                        // check if this is a character and remove dau
                        if (CheckString(ref c1, ref c2))
                        {
                            total++;

                            tc.Append(c1);
                            tc.Append(c2);
                            // if exist in dict, increase amount by 1
                            if (dict.ContainsKey(tc.ToString()))
                            {
                                dict[tc.ToString()]++;
                            }
                            else
                            {
                                // if not, add new index
                                dict.Add(tc.ToString(), 1);
                            }
                            tc = new StringBuilder(2);
                        }
                    }
                    List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(dict.Count);
                    sortedList.AddRange(dict);
                    sortedList.Sort(new CComparer());


                    writer.WriteLine(string.Format("Total: {0}", total));

                    int len = (dict.Count > 100) ? 100 : dict.Count;
                    for (int i = 0; i < len; i++)
                    {
                        writer.WriteLine(string.Format("{0}: {1} - {2}.", sortedList[i].Key, sortedList[i].Value, sortedList[i].Value * 1.0 / total));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Kiem tra 2 ky tu ke nhau co phai la ky tu thuong khong
        /// </summary>
        /// <param name="c1">Char 1</param>
        /// <param name="c2">Char 2</param>
        /// <returns></returns>
        private bool CheckString(ref char c1, ref char c2)
        {
            int i1, i2;
            if ((i1 = GetIndex(c1)) != -1)
            {
                if ((i2 = GetIndex(c2)) != -1)
                {
                    c1 = TABLE[i1];
                    c2 = TABLE[i2];
                    return true;
                }
            }
            return false;
        }

        private bool CheckString(ref char c1, ref char c2, ref char c3)
        {
            int i1, i2, i3;
            if ((i1 = GetIndex(c1)) != -1)
            {
                if ((i2 = GetIndex(c2)) != -1)
                {
                    if ((i3 = GetIndex(c3)) != -1)
                    {
                        c1 = TABLE[i1];
                        c2 = TABLE[i2];
                        c3 = TABLE[i3];
                        return true;
                    }
                }
            }
            return false;
        }

        private int MapRawIndex(int ind)
        {
            switch (ind)
            {
                case 26:        // 'aw'
                case 27:        // 'aa'
                    return 0;   // 'a'
                case 28:        // 'dd'
                    return 3;   // 'd'
                case 29:        // 'ee'
                    return 4;   // 'e'
                case 30:        // 'ow'
                case 31:        // 'oo'
                    return 14;  // 'o'
                case 32:        // 'uw'
                    return 20;  // 'u'
                default:
                    return ind;
            }
        }

        private int GetIndex(char c)
        {
            for (int i = 0; i < FULLTABLELENGTH; i++)
            {
                if (c == FULLTABLE[i])
                {
                    return MAPTABLE[i];
                }
            }
            return -1;
        }

        private void rbKoCoDau_CheckedChanged(object sender, EventArgs e)
        {
            rawText = 1;
        }

        private void rbCoDau_CheckedChanged(object sender, EventArgs e)
        {
            rawText = 0;
        }

        private void cbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                countC = int.Parse(cbCount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
