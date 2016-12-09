using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public partial class frm_SignalList : Form

    {
        #region Private Properties

        private AbstractDBHelper DBHelper_SignalList;

        private string fileName;

        private string[] analogSignalsCSVFileHeaders;

        private string[] binarySignalsCSVFileHeaders;

        private string[] commandSignalsCSVFileHeaders;

        private DataTable dt_CSV;

        private List<Station> stations;

        private string MessageBoxHeader;

        private ImportSettings importSettings;

        private enum ImportSettings
        {
            DoNotDeleteOrOverWriteExistingSignals,
            OverWriteExistingSignals,
            DeleteOldSignals
        }

        private enum CSVFileFormatType
        {
            AnalogSignals,
            Binarysignals
        }

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="frm_SignalList"/> class.
        /// </summary>
        public frm_SignalList()
        {
            InitializeComponent();

            fileName = "";
            stations = new List<Station>();
            analogSignalsCSVFileHeaders = new string[] { "Analog Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Data Type Id", "Unit", "Scale Value", "Max Value", "Min Value", "Max Alarm ID", "Min Alarm ID", "Max Alarm", "Min Alarm", "Archive", "Archive Period ID", "Device Page Shown", "Detail Page Shown" };
            binarySignalsCSVFileHeaders = new string[] { "Binary Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Bit Number", "Value", "Comparison Type", "Status ID", "Alarm", "Event", "Reverse", "Send Mail", "Mail Message"};
            commandSignalsCSVFileHeaders = new string[] { "Command Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Bit Number", "Status ID", "Event", "Command Type" };
            MessageBoxHeader = "EnMon Sürücü Yöneticisi";
            importSettings = ImportSettings.DoNotDeleteOrOverWriteExistingSignals;
        }

        #endregion Constructors

        #region Events

        private void btn_AddDigitalSignal_Click(object sender, EventArgs e)
        {
            Load_frm_AddBinarySignal();
        }

        private void btn_ExportDigitalSignalsAsCSV_Click(object sender, EventArgs e)
        {
            string folderName = GetFolderName();
            if (folderName != null)
            {
                if (ExportDigitalSignalsInfoAsCSVFromDatabase(folderName, "digital_signals"))
                {
                    MessageBox.Show("Digital Sinyaller başarılı bir şekilde dışarı aktarıldı", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digital Sinyaller dışarı aktarılamadı. Ayrıntılı bilgi için log dosyasına bakınız.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ExportAnalogSignalsAsCSV_Click(object sender, EventArgs e)
        {
            string folderName = GetFolderName();
            if (folderName != null)
            {
                if (ExportAnalogSignalsInfoAsCSVFromDatabase(folderName, "analog_signals"))
                {
                    MessageBox.Show("Analog Sinyaller başarılı bir şekilde dışarı aktarıldı", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Analog Sinyaller dışarı aktarılamadı. Ayrıntılı bilgi için log dosyasına bakınız.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ExportCommandSignalsAsCSV_Click(object sender, EventArgs e)
        {
            string folderName = GetFolderName();
            if (folderName != null)
            {
                if (ExportCommandSignalsInfoAsCSVFromDatabase(folderName, "command_signals"))
                {
                    MessageBox.Show("Komut Sinyalleri başarılı bir şekilde dışarı aktarıldı", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Komut Sinyalleri dışarı aktarılamadı. Ayrıntılı bilgi için log dosyasına bakınız.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ImportAnalogSignalsToDataBase_Click(object sender, EventArgs e)
        {
            // Import edilcek dosyayın konumunu kullanıcadan iste
            fileName = GetCSVFileName();

            // Import edilecek dosya seçildiyse
            if (fileName != "")
            {
                // İşlemlere başlamadan once database baglantısını kontrol et
                if (DBHelper_SignalList.CheckDBConnection())
                {
                    // Database baglantısı varsa kullanıcının import secenegine göre işlemlere başla
                    switch (importSettings)
                    {
                        case ImportSettings.DeleteOldSignals:

                            DialogResult result = MessageBox.Show("Devam ederseniz mevcut tüm sinyaller silinip CSV dosyasındaki sinyaller eklenecektir. İşlem geri döndürülemez. Arşivdeki verilere erişirken bazı sorunlar yaşayabilirsiniz. Yedek almadan devam etmeniz tavsiye edilmez. \n Devam etmek istiyor musunuz?", "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                if (DeleteExistingsAndImportAllAnalogSignalsToDataBase(fileName))
                                {
                                    MessageBox.Show("Sinyal dosyasındaki değişiklikler başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                                }
                                else
                                {
                                    DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result_2 == DialogResult.OK)
                                    {
                                        //OpenLogFile();
                                    }
                                }
                            }
                            break;

                        case ImportSettings.DoNotDeleteOrOverWriteExistingSignals:
                            if (ImportOnlyNewAnalogSignals(fileName))
                            {
                                MessageBox.Show("Sinyal dosyasındaki değişiklikler başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        case ImportSettings.OverWriteExistingSignals:
                            if (UpdateExistingAnalogSignalsandImportNewAnalogSignals(fileName))
                            {
                                MessageBox.Show("Sinyal dosyasındaki değişiklikler başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Database baglantısı kurulamadı. Lütfen önce database ile olan bağlantıyı kontrol ediniz");
                }
            }
        }

        private void btn_ImportDigitalSignalsToDatabase_Click(object sender, EventArgs e)
        {
            // Import edilcek dosyayın konumunu kullanıcadan iste
            fileName = GetCSVFileName();

            // Import edilecek dosya seçildiyse
            if (fileName != "")
            {
                // İşlemlere başlamadan once database baglantısını kontrol et
                if (DBHelper_SignalList.CheckDBConnection())
                {
                    // Database baglantısı varsa kullanıcının import secenegine göre işlemlere başla
                    switch (importSettings)
                    {
                        case ImportSettings.DeleteOldSignals:

                            DialogResult result = MessageBox.Show("Devam ederseniz mevcut tüm sinyaller silinip CSV dosyasındaki sinyaller eklenecektir. İşlem geri döndürülemez. Arşivdeki verilere erişirken bazı sorunlar yaşayabilirsiniz. Yedek almadan devam etmeniz tavsiye edilmez. \n Devam etmek istiyor musunuz?", "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                if (DeleteExistingsAndImportAllBinarySignalsToDataBase(fileName))
                                {
                                    MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                                }
                                else
                                {
                                    DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result_2 == DialogResult.OK)
                                    {
                                        //OpenLogFile();
                                    }
                                }
                            }
                            break;

                        case ImportSettings.DoNotDeleteOrOverWriteExistingSignals:
                            if (ImportOnlyNewBinarySignals(fileName))
                            {
                                MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        case ImportSettings.OverWriteExistingSignals:
                            if (UpdateExistingBinarySignalsandImportNewBinarySignals(fileName))
                            {
                                MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Database baglantısı kurulamadı. Lütfen önce database ile olan bağlantıyı kontrol ediniz");
                }
            }
        }

        private void btn_ImportCommandSignalsToDataBase_Click(object sender, EventArgs e)
        {
            // Import edilcek dosyayın konumunu kullanıcadan iste
            fileName = GetCSVFileName();

            // Import edilecek dosya seçildiyse
            if (fileName != "")
            {
                // İşlemlere başlamadan once database baglantısını kontrol et
                if (DBHelper_SignalList.CheckDBConnection())
                {
                    // Database baglantısı varsa kullanıcının import secenegine göre işlemlere başla
                    switch (importSettings)
                    {
                        case ImportSettings.DeleteOldSignals:

                            DialogResult result = MessageBox.Show("Devam ederseniz mevcut tüm komut sinyalleri silinecek ve CSV dosyasındaki komut sinyalleri eklenecektir. İşlem geri döndürülemez. Arşivdeki verilere erişirken bazı sorunlar yaşayabilirsiniz. Yedek almadan devam etmeniz tavsiye edilmez. \n Devam etmek istiyor musunuz?", "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                if (DeleteExistingsAndImportAllCommandSignalsToDataBase(fileName))
                                {
                                    MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                                }
                                else
                                {
                                    DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result_2 == DialogResult.OK)
                                    {
                                        //OpenLogFile();
                                    }
                                }
                            }
                            break;

                        case ImportSettings.DoNotDeleteOrOverWriteExistingSignals:
                            if (ImportOnlyNewCommandSignals(fileName))
                            {
                                MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        case ImportSettings.OverWriteExistingSignals:
                            if (UpdateExistingCommandSignalsandImportNewCommandSignals(fileName))
                            {
                                MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Database baglantısı kurulamadı. Lütfen önce database ile olan bağlantıyı kontrol ediniz");
                }
            }
        }

        private void frm_SignalList_Load(object sender, EventArgs e)
        {
            DBHelper_SignalList = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
        }

        private void frm_addDevice_ClickedAddDeviceButton(object source, AddDeviceEventArgs e)
        {
            switch (e.ProtocolName)
            {
                case "ModbusTCP":
                    if (!(DBHelper_SignalList.AddModbusTCPDeviceToDatabase(e.StationName, e.DeviceName, e.IpAddress, e.SlaveID)))
                    {
                        MessageBox.Show(String.Format("{0} adlı cihaz database'e eklenemedi. CSV dosyasındaki bu cihaza ait sinyaller database'e eklenmeyecek", e.DeviceName), "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dt_CSV = dt_CSV.RemoveRows((from DataRow row in dt_CSV.AsEnumerable() where row["Device Name"].ToString() == e.DeviceName select row).ToArray());
                    }
                    else
                    {
                    }
                    break;

                default:
                    break;
            }
        }

        private bool ExportDigitalSignalsInfoAsCSVFromDatabase(string pathName, string fileName)
        {
            try
            {
                string time = "";
                if (chkBox_AddTimeInformation.Checked)
                {
                    time = DateTime.Now.ToString("yyyyMMdd_hhmmss");
                }
                string query = String.Format("CALL exportAllBinarySignals()");
                DataTable dt = DBHelper_SignalList.ExecuteQuery(query);
                dt.WriteToCSVFile(String.Format("{0}\\{1}_{2}.csv", pathName, fileName, time));
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{1}: Binary sinyaller dışarı aktarılırken sorun oluştu => {0}", ex.Message, this.GetType().Name);
                return false;
            }
        }

        private bool ExportAnalogSignalsInfoAsCSVFromDatabase(string pathName, string fileName)
        {
            try
            {
                string time = "";
                if (chkBox_AddTimeInformation.Checked)
                {
                    time = DateTime.Now.ToString("yyyyMMdd_hhmmss");
                }
                string query = String.Format("CALL exportAllAnalogSignals()");
                DataTable dt = DBHelper_SignalList.ExecuteQuery(query);
                dt.WriteToCSVFile(String.Format("{0}\\{1}_{2}.csv", pathName, fileName, time));
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{1}:Analog sinyaller dışarı aktarılırken sorun oluştu => {0}", ex.Message, this.GetType().Name);
                return false;
            }
        }

        private bool ExportCommandSignalsInfoAsCSVFromDatabase(string pathName, string fileName)
        {
            string time = "";
            if (chkBox_AddTimeInformation.Checked)
            {
                time = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            }

            try
            {
                string query = String.Format("CALL exportAllCommandSignals()");
                DataTable dt = DBHelper_SignalList.ExecuteQuery(query);
                dt.WriteToCSVFile(String.Format("{0}\\{1}_{2}.csv", pathName, fileName, time));
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{1}: Komut sinyalleri dışarı aktarılırken sorun oluştu => {0}", ex.Message, this.GetType().Name);
                return false;
            }
        }

        private void rdButton_DoNotDeleteOrOverWriteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.DoNotDeleteOrOverWriteExistingSignals;
        }

        private void rdButton_OverWriteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.OverWriteExistingSignals;
        }

        private void rdButton_DeleteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.DeleteOldSignals;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void btn_ShowOnlineValues_Click(object sender, EventArgs e)
        {
            frm_OnlineValues frm_onlineValues = new frm_OnlineValues();
            frm_onlineValues.Show();
        }

        #endregion Events

        #region Private Methods

        private bool UpdateExistingAnalogSignalsandImportNewAnalogSignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForAnalogSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    DataTable rowsWillBeUpdated = new DataTable();
                    rowsWillBeUpdated = dt_CSV.Clone();
                    DataTable rowsWillBeImported = new DataTable();
                    rowsWillBeImported = dt_CSV.Clone();

                    // Database'den tüm analog sinyaller okunur
                    string query = String.Format("CALL exportAllAnalogSignals()");
                    DataTable dt_AnalogSignals = DBHelper_SignalList.ExecuteQuery(query);
                    // Database'den analog sinyal donduyse,
                    if (dt_AnalogSignals.Rows.Count > 0)
                    {
                        CheckDataTableForNewAndUpdateSignals(dt_CSV, dt_AnalogSignals, ref rowsWillBeImported, ref rowsWillBeUpdated);
                    }
                    // Database'den analog sinyal donmediyse tüm sinyaller import edilecek demektir.
                    else
                    {
                        rowsWillBeImported = dt_CSV;
                    }

                    bool isImported = true;
                    bool isUpdated = true;

                    isUpdated = UpdateAnalogSignalsAtDataBase(rowsWillBeUpdated);

                    isImported = ImportAnalogSignalsToDataBase(rowsWillBeImported, false);

                    return isImported & isUpdated;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool UpdateExistingBinarySignalsandImportNewBinarySignals(string _fileName)
        {
            try
            {
                using (dt_CSV = ReadCSVFileForBinarySignals(_fileName))
                {
                    // CSV dosyasından satır okunduysa
                    if (dt_CSV.Rows.Count > 0)
                    {
                        DataTable rowsWillBeUpdated = new DataTable();
                        rowsWillBeUpdated = dt_CSV.Clone();
                        DataTable rowsWillBeImported = new DataTable();
                        rowsWillBeImported = dt_CSV.Clone();

                        string query = String.Format("CALL exportAllBinarySignals()");
                        DataTable dt_BinarySignals = DBHelper_SignalList.ExecuteQuery(query);

                        // Database'den ID numarası donduyse,
                        if (dt_BinarySignals.Rows.Count > 0)
                        {
                            CheckDataTableForNewAndUpdateSignals(dt_CSV, dt_BinarySignals, ref rowsWillBeImported, ref rowsWillBeUpdated);
                        }
                        // Database'den binary sinyal donmediyse tüm sinyaller import edilecek demektir.
                        else
                        {
                            rowsWillBeImported = dt_CSV;
                        }

                        bool isImported = true;
                        bool isUpdated = true;

                        isUpdated = UpdateBinarySignalsAtDataBase(rowsWillBeUpdated);

                        isImported = ImportBinarySignalsToDataBase(rowsWillBeImported, false);

                        return isImported & isUpdated;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                // İşlemin durması için exception yakalandı.
                throw;
            }
        }

        private bool UpdateExistingCommandSignalsandImportNewCommandSignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForCommandSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    DataTable rowsWillBeUpdated = new DataTable();
                    rowsWillBeUpdated = dt_CSV.Clone();
                    DataTable rowsWillBeImported = new DataTable();
                    rowsWillBeImported = dt_CSV.Clone();

                    // Database'den tüm komut sinyalleri okunur
                    string query = String.Format("CALL exportAllCommandSignals()");
                    DataTable dt_CommandSignals = DBHelper_SignalList.ExecuteQuery(query);
                    // Database'den komut sinyal donduyse CSV dosyası ile karşılaştırma yapılır. Yeni sinyaller ve güncellenecek sinyaller bulunur.
                    if (dt_CommandSignals.Rows.Count > 0)
                    {
                        CheckDataTableForNewAndUpdateSignals(dt_CSV, dt_CommandSignals, ref rowsWillBeImported, ref rowsWillBeUpdated);
                    }
                    // Database'den command sinyal donmediyse tüm sinyaller yeni sinyal olarak varsayılır ve import edilir.
                    else
                    {
                        rowsWillBeImported = dt_CSV;
                    }

                    bool isImported = true;
                    bool isUpdated = true;

                    isUpdated = UpdateCommandSignalsAtDataBase(rowsWillBeUpdated);

                    isImported = ImportCommandSignalsToDataBase(rowsWillBeImported, false);

                    return isImported & isUpdated;
                }
                else
                {
                    return false;
                }
            }
        }

        private void CheckDataTableForNewAndUpdateSignals(DataTable dt_CSV, DataTable dt_Signals, ref DataTable rowsWillBeImported, ref DataTable rowsWillBeUpdated)
        {
            try
            {
                //  Database'deki tüm analog sinyallerin ID'leri database'den gelen tablodan okunuyor
                List<uint> signalsID = dt_Signals.AsEnumerable().Select((dr) => dr.Field<uint>(0)).ToList();
                // Sadece yeni sinyaller import edilecek ve diğerleri güncelleneceği için her satır tek tek kontrol edilir.
                foreach (DataRow dr in dt_CSV.Rows)
                {
                    uint id;
                    // CSV dosyasında "Signal ID" sutunu bir sayı ise
                    if (uint.TryParse(dr[0].ToString(), out id))
                    {
                        // İlgili satırın ID no'su database'de kayıtlı olup olmadığı kontrol edilir
                        if (signalsID.Exists((s) => s == id))
                        {
                            // ID Database'de kayıtlı ise ilgili row datatable'den çekilir
                            DataRow row2 = dt_Signals.AsEnumerable().Where((row) => row.Field<uint>(0) == id).First();
                            // row2'deki dataların hepsi string olarak kaydedilmediği için tüm datalar string'e çevrilir.
                            var row2_AsString = string.Join(", ", row2.ItemArray);
                            var dr_AsString = string.Join(", ", dr.ItemArray);
                            // Satırlar arasında farklılık varsa satır güncellecekler listesine eklenir
                            if (dr_AsString != row2_AsString)
                            {
                                rowsWillBeUpdated.Rows.Add(dr.ItemArray);
                            }
                        }

                        // Eğer ilgili satırın ID no'su ID database'de kayıtlı değilse
                        else
                        {
                            rowsWillBeImported.Rows.Add(dr.ItemArray);
                        }
                    }
                    // ID no bir sayı değilse database'de de kayıtlı değildir
                    else
                    {
                        dr[0] = signalsID.Max() > dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d[0].ToString(), out id)).Max((d) => uint.Parse(d[0].ToString())) ? signalsID.Max() + 1 : dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d[0].ToString(), out id)).Max((d) => uint.Parse(d[0].ToString())) + 1;
                        rowsWillBeImported.Rows.Add(dr.ItemArray);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: CSV dosyası yeni ve güncellenecek sinyaller için karşılaştırılırken hata oluştu => {1}", this.GetType().Name, ex.Message);
                throw ex;
            }
        }

        private DataTable ReadCSVFileForBinarySignals(string _fileName)
        {
            return ReadCSVFile(_fileName, binarySignalsCSVFileHeaders);
        }

        private DataTable ReadCSVFileForAnalogSignals(string _fileName)
        {
            return ReadCSVFile(_fileName, analogSignalsCSVFileHeaders);
        }

        private DataTable ReadCSVFileForCommandSignals(string _fileName)
        {
            return ReadCSVFile(_fileName, commandSignalsCSVFileHeaders);
        }

        private DataTable ReadCSVFile(string _fileName, string[] _fileHeaders)
        {
            DataTable dt = new DataTable();
            try
            {
                using (CsvReader csv = new CsvReader(new StreamReader(_fileName, System.Text.Encoding.Default), true, ';'))

                {
                    string[] headers = new string[] { };
                    headers = csv.GetFieldHeaders();

                    if (ValidateCSVFileHeaders(headers, _fileHeaders))
                    {
                        dt = dt.addColumn(headers);

                        int fieldCount = csv.FieldCount;
                        string[] row = new string[fieldCount];
                        while (csv.ReadNextRecord())
                        {
                            csv.CopyCurrentRecordTo(row);
                            dt.Rows.Add(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("CSV dosyası okunurken  bir hata ile  karşılaşıldı! Lütfen CSV dosyasını kontrol ediniz.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dt.Clear();
                        return dt;
                    }

                    return dt;
                }
            }
            catch (FileNotFoundException ex)
            {
                Log.Instance.Error("CSV dosyası okurken bir sorunla karşılaşıldı => {0}", ex.Message);
                DialogResult result = MessageBox.Show("CSV dosyası bulunamadı. Lütfen kontrol ediniz... ", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Retry)
                {
                    return ReadCSVFileForAnalogSignals(_fileName);
                }
                else
                {
                    dt.Clear();
                    return dt;
                }
                //MessageBox.Show();
            }
            catch (IOException ex)
            {
                Log.Instance.Warn("CSV dosyası başka bir program tarafından kullanılıyor => {0}", ex.Message);
                DialogResult result = MessageBox.Show("CSV dosyası başka bir program tarafından kullanılıyor.", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Retry)
                {
                    return ReadCSVFileForAnalogSignals(_fileName);
                }
                else
                {
                    dt.Clear();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Warn("CSV dosyası okunurken  bir hata ile  karşılaşıldı! => {0}", ex.Message);
                MessageBox.Show("CSV dosyası okunurken  bir hata ile  karşılaşıldı! Lütfen CSV dosyasını kontrol ediniz.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt.Clear();
                return dt;
            }
        }

        private bool ImportBinarySignalsToDataBase(DataTable _dt, bool _deleteAll)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    // DataTablosundan import edilecek sinyaller alınırken sistemdeki kayıtlı olmayan station ve device'lar
                    //için kullanıcının ne yapmak istediği soruluyor
                    _dt = GetSignalsFromDataTable(_dt);

                    // Database'e kayıt yapmadan önce database'deki tüm sinyaller siliniyor.
                    if (_deleteAll)
                    {
                        DeleteAllBinarySignals();
                    }

                    return DBHelper_SignalList.AddBinarySignalsToDataBase(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında import edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Sinyaller import edilirken beklenmedik hata oluştu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        private bool ImportAnalogSignalsToDataBase(DataTable _dt, bool _deleteAll)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    // DataTablosundan import edilecek sinyaller alınırken sistemdeki kayıtlı olmayan station ve device'lar
                    //için kullanıcının ne yapmak istediği soruluyor
                    _dt = GetSignalsFromDataTable(_dt);

                    // Database'e kayıt yapmadan önce database'deki tüm sinyaller siliniyor.
                    if (_deleteAll)
                    {
                        DeleteAllAnalogSignals();
                    }

                    return DBHelper_SignalList.AddAnalogSignalsToDataBase(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında import edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Sinyaller import edilirken beklenmedik hata oluştu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        private bool ImportCommandSignalsToDataBase(DataTable _dt, bool _deleteAll)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    // DataTablosundan import edilecek sinyaller alınırken sistemdeki kayıtlı olmayan station ve device'lar
                    //için kullanıcının ne yapmak istediği soruluyor
                    _dt = GetSignalsFromDataTable(_dt);

                    // Database'e kayıt yapmadan önce database'deki tüm sinyaller siliniyor.
                    if (_deleteAll)
                    {
                        DeleteAllCommandSignals();
                    }

                    return DBHelper_SignalList.AddCommandSignalsToDataBase(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında update edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Sinyaller import edilirken beklenmedik hata oluştu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        private DataTable GetSignalsFromDataTable(DataTable _dt)
        {
            // Kayıtlı station'lar CSV dosyasındakiler ile karşılaştırılır
            DataTable dt_stationNames = _dt.DefaultView.ToTable(true, "Station Name");
            if (dt_stationNames.Rows.Count > 0)
            {
                // Database'den istasyonlara ait bilgiler çekiliyor.
                stations = DBHelper_SignalList.GetAllStationsInfoWithDeviceInfo();
                
                foreach (DataRow dr in dt_stationNames.Rows)
                {
                    string stationName = dr[0].ToString();
                    // Database'de hiç istasyon kayıtlı değilse
                    if (stations.Count == 0)
                    {
                        AddStationToDataBaseOrRemoveFromCSVTable(stationName);
                    }
                    // Database'de kayıtlı istasyonlar var ama CSV dosyasındaki istasyon ismi database'de kayıtlı değilse;
                    else if (!(stations.Exists((s) => s.Name == stationName)))
                    {
                        AddStationToDataBaseOrRemoveFromCSVTable(stationName);
                    }
                    // İstasyon database'de kayıtlı ise sadece cihazların kayıtlı olup olmadığı kontrol edilir ve sinyaller eklenir
                    else
                    {
                        Station station = stations.Find((s) => s.Name == stationName);

                        // CSV dosyasında istasyona ait cihaz isimlerini al,
                        var deviceNames = (from DataRow row in _dt.AsEnumerable() where stationName == row["Station Name"].ToString() select row["Device Name"].ToString()).Distinct();
                        foreach (string deviceName in deviceNames.ToList())
                        {
                            // Cihaz istasyona kayıtlı değilse sinyalleri eklemeden önce kullanıcıya ne yapmak istedigini sor
                            if (!(station.ModbusTCPDevices.Exists((d) => d.Name == deviceName)))
                            {
                                AddDeviceToDataBaseOrRemoveFromCSVTable(stationName, deviceName);
                            }
                        }
                    }
                }
            }
            else
            {
                return null;
                throw new Exception("CSV dosyasında istasyon ismi bulunamadı");
            }

            // Datatable'ın sutun isimleri ile station name ve device name isimleri id numaları ile değiştiriliyor.
            return PrepareDataTableForDataBase(_dt);
        }

        private string GetFolderName()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Klasör Seçiniz";
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        private bool UpdateAnalogSignalsAtDataBase(DataTable _dt)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    PrepareDataTableForDataBase(_dt);
                    return DBHelper_SignalList.UpdateAnalogSignals(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında update edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Sinyaller güncellenemedi => {0}", ex.Message);
                return false;
            }
        }

        private bool UpdateBinarySignalsAtDataBase(DataTable _dt)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    PrepareDataTableForDataBase(_dt);
                    return DBHelper_SignalList.UpdateBinarySignals(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında update edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Sinyaller güncellenemedi => {0}", ex.Message);
                return false;
            }
        }

        private bool UpdateCommandSignalsAtDataBase(DataTable _dt)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    PrepareDataTableForDataBase(_dt);
                    return DBHelper_SignalList.UpdateCommandSignals(_dt);
                }
                else
                {
                    Log.Instance.Info("{0}: CSV dosyasında update edilecek sinyal bulunamadı. ", this.GetType().Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Sinyaller güncellenemedi => {0}", ex.Message);
                return false;
            }
        }

        private bool ImportOnlyNewAnalogSignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForAnalogSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    // Database'den tüm analog sinyallerin ID leri okunur
                    List<uint> analogSignalsID = DBHelper_SignalList.GetAllAnalogSignalsID();

                    // Database'den ID numarası donduyse,
                    if (analogSignalsID.Count > 0)
                    {
                        dt_CSV = GetNewSignals(dt_CSV, analogSignalsID);
                    }

                    return ImportAnalogSignalsToDataBase(dt_CSV, false);
                }
                // CSV dosyasından deger donmedi.
                else
                {
                    return false;
                }
            }
        }

        private bool ImportOnlyNewBinarySignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForBinarySignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    // Database'den tüm analog sinyallerin ID leri okunur
                    List<uint> binarySignalsID = DBHelper_SignalList.GetAllBinarySignalsID();

                    // Database'den ID numarası donduyse,
                    if (binarySignalsID.Count > 0)
                    {
                        dt_CSV = GetNewSignals(dt_CSV, binarySignalsID);
                    }

                    return ImportBinarySignalsToDataBase(dt_CSV, false);
                }
                // CSV dosyasından deger donmedi.
                else
                {
                    return false;
                }
            }
        }

        private bool ImportOnlyNewCommandSignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForCommandSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    // Database'den tüm analog sinyallerin ID leri okunur
                    List<uint> commandSignalsID = DBHelper_SignalList.GetAllCommandSignalsID();

                    // Database'den ID numarası donduyse,
                    if (commandSignalsID.Count > 0)
                    {
                        dt_CSV = GetNewSignals(dt_CSV, commandSignalsID);
                    }

                    return ImportCommandSignalsToDataBase(dt_CSV, false);
                }
                // CSV dosyasından deger donmedi.
                else
                {
                    return false;
                }
            }
        }

        private DataTable GetNewSignals(DataTable dt_CSV, List<uint> SignalsID)
        {
            List<DataRow> rowsWillBeDeleted = new List<DataRow>();
            // Sadece yen sinyaller import edileceği için her satır tek tek kontrol edilir.
            foreach (DataRow dr in dt_CSV.Rows)
            {
                uint id;

                // ID no bir sayı ise,
                if (uint.TryParse(dr[0].ToString(), out id))
                {
                    // İlgili satırın ID no'su ID database'de kayıtlı olup olmadığına bakılır
                    if (SignalsID.Exists((s) => s == uint.Parse(dr[0].ToString())))
                    {
                        // Sinyal zaten database'de mevcutsa CSV dosyasındaki degerlerin yer aldıgı datatable'dan bu satır silinir
                        rowsWillBeDeleted.Add(dr);
                    }
                }
                // CSV dosyasındaki ID degeri gecerli bir sayı değilse ilgili satırın databasede kayıtlı olmadıgı varsayılır
                // ve satırdaki sinyal bilgileri için yeni bir ID atanır.
                else
                {
                    dr[0] = SignalsID.Max() > dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d[0].ToString(), out id)).Max((d) => uint.Parse(d[0].ToString())) ? SignalsID.Max() + 1 : dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d[0].ToString(), out id)).Max((d) => uint.Parse(d[0].ToString())) + 1;
                }
            }

            // Database'de mevcut sinyaller tekrardan database'e eklenmemesi için datatable'dan silinir
            if (rowsWillBeDeleted.Count > 0)
            {
                dt_CSV.RemoveRows(rowsWillBeDeleted);
            }

            return dt_CSV;
        }

        private bool DeleteExistingsAndImportAllAnalogSignalsToDataBase(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForAnalogSignals(_fileName))
            {
                if (dt_CSV.Rows.Count > 0)
                {
                    return ImportAnalogSignalsToDataBase(dt_CSV, true);
                }
            }

            return false;
        }

        private bool DeleteExistingsAndImportAllBinarySignalsToDataBase(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForBinarySignals(_fileName))
            {
                if (dt_CSV.Rows.Count > 0)
                {
                    return ImportBinarySignalsToDataBase(dt_CSV, true);
                }
            }

            return false;
        }

        private bool DeleteExistingsAndImportAllCommandSignalsToDataBase(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForCommandSignals(_fileName))
            {
                if (dt_CSV.Rows.Count > 0)
                {
                    return ImportCommandSignalsToDataBase(dt_CSV, true);
                }
            }

            return false;
        }

        private void AddStationToDataBaseOrRemoveFromCSVTable(string stationName)
        {
#pragma warning disable CS0168 // The variable '_dt' is declared but never used
            DataTable _dt;
#pragma warning restore CS0168 // The variable '_dt' is declared but never used
            // Kullanıcıya istasyonu database'e ekleyip eklemek istemediği sorulur,
            DialogResult result = MessageBox.Show(String.Format("{0} adlı istasyon database'de bulunamadı. istasyon database'e eklenmezse CSV dosyasında {0} adlı istasyona ait sinyaller de database'e eklenmeyecektir. İstasyonu database'e eklemek ister misiniz?", stationName), "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            // Kullanıcının cevabı "evet" olursa
            if (result == DialogResult.Yes)
            {
                // İstasyon database' eklenir
                if (DBHelper_SignalList.AddStation(stationName))
                {
                    //ushort maxID = stations.Max(s => s.ID);
                    //Station newStation = new Station();
                    //newStation.ID = maxID;
                    //newStation.Name = stationName;
                    //stations.Add(newStation);

                    // İstasyon yeni eklendiği için CSV dosyasında istasyona ait tüm cihazların da database'e eklenmesi gereklidir.
                    var devices = (from DataRow row in dt_CSV.AsEnumerable() where stationName == row["Station Name"].ToString() select row["Device Name"].ToString()).Distinct();

                    if (devices.Count() > 0)
                    {
                        // CSV dosyasında yer alan cihazlar istasyona kayıtlı olmadıgı için kullanıcıya her cihaz için ne yapmak istedigini sor
                        foreach (string deviceName in devices.ToList())
                        {
                            AddDeviceToDataBaseOrRemoveFromCSVTable(stationName, deviceName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("{0} adlı istasyon database'e eklenirken bir hata oluştu. İçeri aktarma işlemine {0} istasyonuna ait sinyaller işlenmeden devam edilecek"), "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Kullanıcının cevabı hayır olursa,
            else
            {
                // CSV dosyasında okunan satırlar arasından bu istasyona ait tüm satırları siler
                string query = String.Format("dt_CSV['Station Name'] like '{0}'", stationName);
                dt_CSV = dt_CSV.RemoveRows((from DataRow row in dt_CSV.AsEnumerable() where row["Station Name"].ToString() == stationName select row).ToArray());
            }
        }

        private DataTable PrepareDataTableForDataBase(DataTable dt_CSV)
        {
            // Datatable'daki her bir device ismi istasyon ismi ile beraber çekiliyor.
            DataTable dt_uniqueRowsByDeviceNameAndStationName = dt_CSV.DefaultView.ToTable(true, "Station Name", "Device Name");
            // Database'deki tüm istasyonlar istasyonda altında kayıtlı deviceların isimleri ile beraber okunuyor
            List<Station> newStationList = DBHelper_SignalList.GetAllStationsInfoWithDeviceInfo();

            // Her satır için Device Name ve Station Name bilgileri, Device ID ve Station ID bilgileri ile değiştiriliyor.
            foreach (DataRow dr in dt_CSV.Rows)
            {

                try
                {
                    if (newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First().ModbusTCPDevices.Where((d) => d.Name == dr["Device Name"].ToString()).First() != null)
                        dr["Device Name"] = newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First().ModbusTCPDevices.Where((d) => d.Name == dr["Device Name"].ToString()).First().ID;
                    if (newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First() != null)
                        dr["Station Name"] = newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First().ID;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            // Name'ler ID ye değiştirirdikten sonra sutun isimleri de güncelleniyor.
            dt_CSV.Columns["Device Name"].ColumnName = "Device ID";
            dt_CSV.Columns["Station Name"].ColumnName = "Sation ID";
            //"Analog Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Data Type Id", "Scale Value", "Max Value", "Min Value", "Max Alarm ID", "Min Alarm ID", "Alarm", "Event", "Archive", "Archive Period ID" };

            return dt_CSV;
        }

        private void AddDeviceToDataBaseOrRemoveFromCSVTable(string stationName, string deviceName)
        {
            DialogResult result_2 = MessageBox.Show(String.Format("{0} adlı cihaz {1} istasyonunda bulunamadı. {0} adlı cihazı {1} istasyonuna eklemek ister misiniz?", deviceName, stationName), "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            // Kullanıcı onay verirse cihazı kullanıcıdan alınan bilgiler ile database'e ekle.
            if (result_2 == DialogResult.Yes)
            {
                List<CommunicationProtocol> _protocols = DBHelper_SignalList.GetAllProtocolsInfo();
                List<int> usedModbusSlaveAddresses = DBHelper_SignalList.GetUsedModbusSlaveAddresses(stationName);
                usedModbusSlaveAddresses.Add(1);
                using (frm_AddDevice frm_addDevice = new frm_AddDevice(stationName, deviceName, _protocols, usedModbusSlaveAddresses))
                {
                    frm_addDevice.ClickedAddDeviceButton += frm_addDevice_ClickedAddDeviceButton;
                    DialogResult result = frm_addDevice.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        dt_CSV.RemoveRows((from DataRow row in dt_CSV.AsEnumerable() where (row["Station Name"].ToString() == stationName & row["Device Name"].ToString() == deviceName) select row).ToArray());
                    }
                }
            }
            // Kullanıcı onay vermezse CSV dosyasında o cihaza ait tüm satırları sil.
            else
            {
                dt_CSV.RemoveRows((from DataRow row in dt_CSV.AsEnumerable() where (row["Station Name"].ToString() == stationName & row["Device Name"].ToString() == deviceName) select row).ToArray());
            }
        }

        private void DeleteAllAnalogSignals()
        {
            DBHelper_SignalList.ResetTable("analog_signals");
        }

        private void DeleteAllBinarySignals()
        {
            DBHelper_SignalList.ResetTable("binary_signals");
        }

        private void DeleteAllCommandSignals()
        {
            DBHelper_SignalList.ResetTable("command_signals");
        }

        private bool ValidateCSVFormat(string fileName, CSVFileFormatType formatType)
        {
            switch (formatType)
            {
                case CSVFileFormatType.Binarysignals:
                    return false;//ValidateCSVFileHeaders(fileName, binarySignalsCSVFileHeaders);
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected

                case CSVFileFormatType.AnalogSignals:
                    return false;//ValidateCSVFileHeaders(fileName, analogSignalsCSVFileHeaders);
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected

                default:
                    return false;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
            }
        }

#pragma warning disable CS1573 // Parameter 'headers' has no matching param tag in the XML comment for 'frm_SignalList.ValidateCSVFileHeaders(string[], string[])' (but other parameters do)

#pragma warning disable CS1572 // XML comment has a param tag for '_fileName', but there is no parameter by that name
        /// <summary>
        /// Validates the CSV file headers.
        /// </summary>
        /// <param name="_fileName">Name of the file.</param>
        /// <param name="_headers">The headers.</param>
        /// <returns></returns>
        private bool ValidateCSVFileHeaders(string[] headers, string[] _headers)
#pragma warning restore CS1572 // XML comment has a param tag for '_fileName', but there is no parameter by that name
#pragma warning restore CS1573 // Parameter 'headers' has no matching param tag in the XML comment for 'frm_SignalList.ValidateCSVFileHeaders(string[], string[])' (but other parameters do)
        {
            if (headers.Length == _headers.Length)
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    if (headers[i] != _headers[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetCSVFileName()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV dosyası | *.csv";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            ofd.RestoreDirectory = true;
            ofd.Title = "Analog sinyaller için CSV dosyasını seçiniz";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return "";
            }
        }

        #endregion Private Methods

        private void Load_frm_AddBinarySignal()
        {
            frm_AddNewOrUpdateBinarySignal frm_addNewBinarySignal = new frm_AddNewOrUpdateBinarySignal();
            frm_addNewBinarySignal.ShowDialog();
        }

        private void Load_frm_AddAnalogSignal()
        {
            frm_AddNewOrUpdateAnalogSignal frm_addNewAnalogSignal = new frm_AddNewOrUpdateAnalogSignal();
            frm_addNewAnalogSignal.ShowDialog();
        }

        private void btn_AddAnalogSignal_Click(object sender, EventArgs e)
        {
            Load_frm_AddAnalogSignal();
        }

        private void btn_AddCommandSignal_Click(object sender, EventArgs e)
        {
            Load_frm_AddCommandSignal();
        }

        private void Load_frm_AddCommandSignal()
        {
            frm_AddNewOrUpdateCommandSignal frm_addNewCommandSignal = new frm_AddNewOrUpdateCommandSignal();
            frm_addNewCommandSignal.ShowDialog();
        }
    }
}