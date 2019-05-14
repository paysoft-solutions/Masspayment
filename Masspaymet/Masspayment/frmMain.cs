using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;

namespace Masspayment
{
    public partial class frmMain : Form
    {

        #region Variable

        public DRSA drsa = new DRSA();
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        public bool isInitPrivateKey = false;
        public DataTable table = null;
        private IniFile iniFile = new IniFile();
        private bool IsNotErrorInCSV = false;

        #endregion

        public frmMain()
        {
            InitializeComponent();

            buPrev.Visible = false;
            laFinish0.Text = "";
            laFinish1.Text = "";
            buOpenFolder.Visible = false;
            progressBar.Visible = false;
            laWait.Visible = false;
            
            tabPage2.Parent = null;
            tabPage3.Parent = null;

            edContractorPointId.Text = iniFile.Read("ContractorPointId");
            edFileNamePrivatKey.Text = iniFile.Read("FileNamePrivatKey");

            #region FileNamePrivatKey

            if (File.Exists(edFileNamePrivatKey.Text) == true)
            {
                string text = System.IO.File.ReadAllText(edFileNamePrivatKey.Text);

                if (drsa.InitPrivateKey(text) == true)
                {
                    isInitPrivateKey = true;

                    edTextFileNamePrivatKey.Text = text;

                    buNext_Click(buNext, null);
                }
            }

            #endregion

        }

        private void edContractorPointId_TextChanged(object sender, EventArgs e)
        {
            if (edContractorPointId.Text.Length == 0) return;

            string s = edContractorPointId.Text.Trim().Replace(" ", "");

            if (s.Length > 7)
            {
                s = s.Substring(0, 7);
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(s, "[^0-9]"))
            {
                MessageBox.Show("Нужно только цифры. Длина от 1 до 7 цифр.");
                edContractorPointId.Text = "";
            }
        }

        private void edContractorPointId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }            
        }

        private void buOpenFileNamePrivatKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файл ключей (*.pem|*.pem|All files (*.*)|*.*";
            openDialog.FilterIndex = 0;
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(openDialog.FileName) == false)
                {
                    MessageBox.Show("Файл не найден.");
                    return;
                }

                drsa = new DRSA();
                isInitPrivateKey = false;

                try
                {
                    string text = System.IO.File.ReadAllText(openDialog.FileName);

                    if (drsa.InitPrivateKey(text) == false)
                    {
                        MessageBox.Show("Ключ в файле не распознан!");
                        return;
                    }

                    isInitPrivateKey = true;

                    edFileNamePrivatKey.Text = openDialog.FileName;

                    edTextFileNamePrivatKey.Text = text;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ключ в файле не распознан! Message = " + exp.Message, "Ошибка ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buNext_Click(object sender, EventArgs e)
        {
            string ActiveTabPageName = tabMain.SelectedTab.Name;

            switch (ActiveTabPageName)
            {
                case "tabPage1" :

                    string s = edContractorPointId.Text.Trim().Replace(" ", "");

                    if (!(s.Length > 0 && s.Length <= 7) && System.Text.RegularExpressions.Regex.IsMatch(s, "[^0-9]") == false)
                    {
                        MessageBox.Show("ContractorPointId Не распознан. Нужно только цифры. Длина от 1 до 7 цифр.");
                        return;                    
                    }

                    if (edFileNamePrivatKey.Text == "" || File.Exists(edFileNamePrivatKey.Text) == false)
                    {
                        MessageBox.Show("Не указан файл с ключом.");
                        return;
                    }

                    if (isInitPrivateKey == false)
                    {
                        MessageBox.Show("Ключ в файле не распознан!");
                        return;
                    }

                    tabPage1.Parent = null;
                    
                    tabPage2.Parent = tabMain;

                    laProgress.Text = "Шаг 2 из 3";

                    if (IsNotErrorInCSV == false)
                    {
                        buNext.Enabled = false;
                    }
                    else
                    {
                        buNext.Enabled = true;
                    }

                    iniFile.Write("ContractorPointId", edContractorPointId.Text);
                    iniFile.Write("FileNamePrivatKey", edFileNamePrivatKey.Text);

                    break;

                case "tabPage2" :

                    tabPage2.Parent = null;

                    tabPage3.Parent = tabMain;

                    laProgress.Text = "Шаг 3 из 3";

                    buNext.Text = "Закрыть";

                    tabMain.Update();
                    tabMain.Refresh();

                    tabPage3.Update();
                    tabPage3.Refresh();

                    laProgress.Update();
                    laProgress.Refresh();

                    buNext.Update();
                    buNext.Refresh();

                    #region Подписание

                    string filename= "";
                    if (SignDataAndSaveToFile(ref filename) == true)
                    {
                        laFinish0.Text = "Сформирован подписанный файл ";
                        laFinish1.Text = "" + filename;
                        buOpenFolder.Visible = true;
                    }
                    else
                    {
                        laFinish0.Text = "";
                        laFinish1.Text = "";
                        buOpenFolder.Visible = false;
                    }

                    #endregion                    

                    break;


                case "tabPage3":

                    if (buNext.Text == "Закрыть")
                        Close();

                    break;
            }
            
            buPrev.Visible = true;

        }

        private void buPrev_Click(object sender, EventArgs e)
        {
            string ActiveTabPageName = tabMain.SelectedTab.Name;

            switch (ActiveTabPageName)
            {
                case "tabPage1":

                    buPrev.Visible = false;

                    laProgress.Text = "Шаг 1 из 3";
                    break;

                case "tabPage2":

                    tabPage2.Parent = null;
                    
                    tabPage1.Parent = tabMain;

                    buPrev.Visible = false;

                    buNext.Enabled = true;

                    laProgress.Text = "Шаг 1 из 3";
                    break;

                case "tabPage3":

                    tabPage3.Parent = null;

                    tabPage2.Parent = tabMain;

                    laProgress.Text = "Шаг 2 из 3";

                    buNext.Text = "Далее";

                    laFinish0.Text = "";
                    laFinish1.Text = "";
                    buOpenFolder.Visible = false;

                    break;
            }

        }

        private bool SignDataAndSaveToFile(ref string fileName)
        {
            bool result = false;

            laWait.Visible = true;
            progressBar.Visible = true;

            laWait.Update();
            laWait.Refresh();

            try
            {
                if (table.Columns.IndexOf("OperationId") == -1)
                {
                    table.Columns.Add("OperationId");
                }

                if (table.Columns.IndexOf("SignBase64") == -1)
                {
                    table.Columns.Add("SignBase64");
                }

                int pos = 1;
                DataRow[] rows = table.Select();
                progressBar.Maximum = rows.Length;
                foreach (var row in rows)
                {
                    row["OperationId"] = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "-" + row["ID услуги"].ToString() + "-" + pos.ToString();

                    row["SignBase64"] = GetSignBase64(row);

                    progressBar.Value = progressBar.Value + 1;

                    Thread.Sleep(3);

                    pos++;
                }

                string text = DataTableToCSV(table, ';');

                fileName = Path.Combine(Path.GetDirectoryName(edFileNameDataCSV.Text), Path.GetFileNameWithoutExtension(edFileNameDataCSV.Text) + "_signed.csv");

                if (File.Exists(fileName))
                {
                    progressBar.Visible = false;
                    laWait.Text = "Ожидание решения ...";
                    if (MessageBox.Show("Файл уже существует! Перезаписать? " + Environment.NewLine + fileName, "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Delete(fileName);
                    }
                    else
                    {
                        return result;
                    }
                }

                System.IO.File.WriteAllText(fileName, text);

                result = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка подписи! Message = " + exp.Message, "Ошибка ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                progressBar.Value = 0;
                laWait.Visible = false;
                laWait.Text = "Ожидайте ...";
            }

            return result;        
        }

        private string GetSignBase64(DataRow row)
        {
            string result = "";
                                                                                                                                                                                                                                                                                                      //ID услуги          OperationId        Сумма к зачислению    Реквизит       
            string res = String.Format("<OperationRequest><Commands><OperationRequestCommand><ServiceId>{0}</ServiceId><OperationId>{1}</OperationId><Volume>{2}</Volume><Params>{3}</Params><ConfirmMode>0</ConfirmMode><Timeout>5</Timeout></OperationRequestCommand></Commands></OperationRequest>", row[0].ToString(), row[4].ToString(), row[2].ToString(),    row[1].ToString());

            byte[] rs = Encoding.GetEncoding("windows-1251").GetBytes(res);

            var sign = drsa.SignData(rs, sha1);
            result = Convert.ToBase64String(sign);

            return result;
        }

        private void buOpenFileNameDataCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файл операций (*.csv|*.csv|All files (*.*)|*.*";
            openDialog.FilterIndex = 0;
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(openDialog.FileName) == false)
                {
                    MessageBox.Show("Файл не найден.");
                    return;
                }

                IsNotErrorInCSV = false;

                try
                {
                    #region Validate file

                    table = readCSV(openDialog.FileName);

                    GC.Collect();

                    if (table.Columns.Count != 4)
                    {
                        //MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание).");
                    }

                    if (table.Columns[0].ColumnName != "ID услуги")
                    {
                        //MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание).");
                    }

                    if (table.Columns[1].ColumnName != "Реквизит")
                    {
                        //MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание).");
                    }

                    if (table.Columns[2].ColumnName != "Сумма к зачислению")
                    {
                       //MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание).");
                    }

                    if (table.Columns[3].ColumnName != "Примечание")
                    {
                        //MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание).");
                    }

                    bool IsErrorInCSV = false;

                    table.Columns.Add("ERRORS");

                    DataRow[] rows = table.Select();
                    int pos = 0;
                    foreach (var row in rows)
                    {
                        #region col 0 'ID услуги'

                        int n0;
                        if (!int.TryParse(row[0].ToString(), out n0))
                        {
                            //MessageBox.Show("Значение не распознано! Колонка 'ID услуги' Строка " + (pos + 1).ToString() + " Значение = '" + row[0].ToString() + "'");

                            AddCommentToErrorColumn("Колонка 'ID услуги' ", row);

                            IsErrorInCSV = true;
                        }

                        #endregion 

                        #region col 1 'Реквизит'

                        string col1 = row[1].ToString();
                        bool isValidCol1 = false;


                        if (col1.Length == 16 && System.Text.RegularExpressions.Regex.IsMatch(col1, "[0-9]"))
                        {
                            if (Luhn(col1) == true)
                            {
                                isValidCol1 = true;
                            }                        
                        }

                        if (col1.Length == 12 && System.Text.RegularExpressions.Regex.IsMatch(col1, "[0-9]") && col1[0].ToString() == "0" && isValidCol1 == false)
                        {
                            isValidCol1 = true;
                        }

                        if (col1.Length == 12 && col1[0].ToString().ToUpper() == "U" && System.Text.RegularExpressions.Regex.IsMatch(col1.Remove(0, 1), "[0-9]") && isValidCol1 == false)
                        {
                            isValidCol1 = true;
                        }


                        if (isValidCol1 == false)
                        {
                            //MessageBox.Show("Значение не распознано! Колонка 'Реквизит' Строка " + (pos + 1).ToString() + " Значение = '" + row[1].ToString() + "'");

                            AddCommentToErrorColumn("Колонка 'Реквизит' ", row);

                            IsErrorInCSV = true;
                        }

                        #endregion

                        #region col 2 'Сумма к зачислению'

                        decimal n2;
                        if (!decimal.TryParse(row[2].ToString(), out n2))
                        {
                            //MessageBox.Show("Значение не распознано! Колонка 'Сумма к зачислению' Строка " + (pos + 1).ToString() + " Значение = '" + row[2].ToString() + "'");

                            AddCommentToErrorColumn("Колонка 'Сумма к зачислению' ", row);

                            IsErrorInCSV = true;
                        }
                        else
                        {
                            decimal sum = decimal.Parse(row[2].ToString());

                            decimal sumNew = Math.Round(sum, 2, MidpointRounding.AwayFromZero);

                            if ( decimal.Compare(sum, sumNew) != 0)
                            {
                                //MessageBox.Show("Значение не распознано! Колонка 'Сумма к зачислению' Строка " + (pos + 1).ToString() + " Значение = '" + row[2].ToString() + "'");

                                AddCommentToErrorColumn("Колонка 'Сумма к зачислению' ", row);

                                IsErrorInCSV = true;
                            }
                            else
                            {
                                row[2] = string.Format("{0:0.00}", sum).Replace(",",".");                            
                            }
                        }

                        #endregion 

                        pos++;
                    }

                    #endregion

                    if (IsErrorInCSV == true)
                        buNext.Enabled = false;
                    else
                    {
                        table.Columns.Remove("ERRORS");
                        buNext.Enabled = true;

                        IsNotErrorInCSV = true;
                    }

                    dgvDataCSV.DataSource = table;

                    if (IsErrorInCSV == true)
                    {
                        dgvDataCSV.Columns["ERRORS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }

                    dgvDataCSV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    edFileNameDataCSV.Text = openDialog.FileName;
                }
                catch (Exception exp)
                {
                    dgvDataCSV.DataSource = null;

                    MessageBox.Show("Файл не распознан! Структура файла (ID услуги;Реквизит;Сумма к зачислению;Примечание)! ====  Ошибка = " + exp.Message, "Ошибка ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AddCommentToErrorColumn(string comment, DataRow row)
        {
            if (row["ERRORS"].ToString() == "")
            {
                row["ERRORS"] = "Значение не распознано! " + comment;
            }
            else
            {
                row["ERRORS"] = row["ERRORS"].ToString() + " | " + comment;
            }        
        }

        public bool Luhn(string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }

        public DataTable readCSV(string filePath, bool HeaderColIsPresent = false)
        {
            var dt = new DataTable();

            if (HeaderColIsPresent == true)
            {
                File.ReadLines(filePath, Encoding.GetEncoding("windows-1251")).Take(1)
                    .SelectMany(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    .ToList()
                    .ForEach(x => dt.Columns.Add(x.Trim()));

                File.ReadLines(filePath, Encoding.GetEncoding("windows-1251")).Skip(1)
                    .Select(x => x.Split(';'))
                    .ToList()
                    .ForEach(line => dt.Rows.Add(line[0], line[1], line[2], line[3]));
            }
            else
            {
                dt.Columns.Add("ID услуги");
                dt.Columns.Add("Реквизит");
                dt.Columns.Add("Сумма к зачислению");
                dt.Columns.Add("Примечание");

                File.ReadLines(filePath, Encoding.GetEncoding("windows-1251"))
                    .Select(x => x.Split(';'))
                    .ToList()
                    .ForEach(line => dt.Rows.Add(line[0], line[1], line[2], line[3]));
            }

            return dt;
        }

        public string DataTableToCSV(DataTable datatable, char seperator, bool HeaderColIsPresent = false)
        {
            StringBuilder sb = new StringBuilder();

            if (HeaderColIsPresent == true)
            {

                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(datatable.Columns[i]);

                    if (i < datatable.Columns.Count - 1)
                    {
                        sb.Append(seperator);
                    }
                }

                sb.AppendLine();
            }

            foreach (DataRow dr in datatable.Rows)
            {
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());

                    if (i < datatable.Columns.Count - 1)
                    {
                        sb.Append(seperator);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void buOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(laFinish1.Text))
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + laFinish1.Text));
                }
            }
            catch
            {}
        }
    }
}
