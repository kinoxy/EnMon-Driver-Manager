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
        private AbstractDBHelper dbHelper;
        private string fileName;
        private string[] analogSignalsCSVFileHeaders;
        private string[] binarySignalsCSVFileHeaders;
        private DataTable dt_CSV;
        private List<Station> stations;
        private string MessageBoxHeader;

        public AbstractDBHelper DbHelper
        {
            get;
            set;
        }

        private ImportSettings importSettings;

        private enum ImportSettings
        {
            DoNotDeleteOrOverWriteOldSignals,
            OverWriteOldSignals,
            DeleteOldSignals
        }

        private enum CSVFileFormatType
        {
            AnalogSignals,
            Binarysignals
        }

        public frm_SignalList()
        {
            InitializeComponent();

            fileName = "";
            stations = new List<Station>();
            analogSignalsCSVFileHeaders = new string[] { "Analog Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Data Type Id","Unit", "Scale Value", "Max Value", "Min Value", "Max Alarm ID", "Min Alarm ID", "Alarm", "Event", "Archive", "Archive Period ID", "Send Mail", "Mail Message" };
            binarySignalsCSVFileHeaders = new string[] { "Binary Signal ID", "Station Name", "Device Name", "Name", "Identification", "Address", "Function Code", "Word Count", "Bit Number", "Alarm", "Event", "Reverse", "Alarm ID", "Send Mail", "Mail Message" };
            MessageBoxHeader = "EnMOn Sürücü Yöneticisi";
            importSettings = ImportSettings.DoNotDeleteOrOverWriteOldSignals;
        }

        // TODO: Form, mainformdaki databsehelper olusmadan acılınca burası hata veriyor. mainformdaki databasehelper onload ta olusturmaya bak
        private void InitializedbHelper()
        {
            string test = DbHelper.GetType().ToString();
            switch (DbHelper.GetType().ToString())
            {
                case "EnMon_Driver_Manager.DataBase.MySqlDBHelper":
                    dbHelper = new MySqlDBHelper();
                    break;

                default:
                    break;
            }
        }

        private void btn_ExportDigitalSignalsAsCSV_Click(object sender, EventArgs e)
        {
            string folderName = GetFolderName();
            if (folderName != null)
            {
                if(ExportDigitalSignalsInfoAsCSVFromDatabase(folderName, "digital_signals"))
                {
                    MessageBox.Show("Digital Sinyaller başarılı bir şekilde dışarı aktarıldı", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digital Sinyaller dışarı aktarılamadı. Ayrıntılı bilgi için lütfen log dosyasını kontrol ediniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                DataTable dt = dbHelper.ExecuteQuery(query);
                dt.WriteToCSVFile(String.Format("{0}\\{1}_{2}.csv", pathName, fileName, time));
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Binary sinyalleri dışarı aktarırken bir sorun oluştu => {0}", ex.Message);
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
                DataTable dt = dbHelper.ExecuteQuery(query);
                dt.WriteToCSVFile(String.Format("{0}\\{1}_{2}.csv", pathName, fileName, time));
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Analog sinyalleri dışarı aktarırken bir sorun oluştu => {0}", ex.Message);
                return false;
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
                if (dbHelper.CheckDBConnection())
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

                        case ImportSettings.DoNotDeleteOrOverWriteOldSignals:
                            if (ImportOnlyNewSignals(fileName))
                            {
                                MessageBox.Show("Sinyal dosyasındaki değişiklikler başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        case ImportSettings.OverWriteOldSignals:
                            if (UpdateExistingSignalsandImportNewSignals(fileName))
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
                if (dbHelper.CheckDBConnection())
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

                        case ImportSettings.DoNotDeleteOrOverWriteOldSignals:
                            if (ImportOnlyNewSignals(fileName))
                            {
                                MessageBox.Show("Sinyaller başarılı bir şekilde database'e eklendi.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Instance.Info("{0} adlı dosya başarılı bir şekilde içeri aktarıldı", fileName);
                            }
                            else
                            {
                                DialogResult result_2 = MessageBox.Show("İşlem hatalı bir şekilde tamamlandı. Ayrıntılı bilgi için log dosyasını okuyunuz", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            break;

                        case ImportSettings.OverWriteOldSignals:
                            if (UpdateExistingSignalsandImportNewSignals(fileName))
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

        private DataTable ReadCSVFileForBinarySignals(string _fileName)
        {
            DataTable dt = new DataTable();

            try
            {
                using (CsvReader csv = new CsvReader(new StreamReader(_fileName, System.Text.Encoding.Default), true, ';'))

                {
                    string[] headers = new string[] { };
                    headers = csv.GetFieldHeaders();

                    if (ValidateCSVFileHeaders(headers, binarySignalsCSVFileHeaders))
                    {
                        for (int c = 0; c < headers.Length; c++)
                        {
                            dt.Columns.Add(headers[c]);
                        }
                        int fieldCount = csv.FieldCount;
                        string[] columns = new string[fieldCount];
                        while (csv.ReadNextRecord())
                        {
                            csv.CopyCurrentRecordTo(columns);
                            dt.Rows.Add(columns);
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
            if (_dt.Rows.Count > 0)
            {
                // Kayıtlı station'lar CSV dosyasındakiler ile karşılaştırılır
                DataTable dt_stationNames = _dt.DefaultView.ToTable(true, "Station Name");
                if (dt_stationNames.Rows.Count > 0)
                {
                    // Database'den istasyonlara ait bilgiler çekiliyor.
                    stations = dbHelper.GetAllStationsInfoWithDeviceInfo();
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
                                if (!(station.Devices.Exists((d) => d.Name == deviceName)))
                                {
                                    AddDeviceToDataBaseOrRemoveFromCSVTable(stationName, deviceName);
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

                // Datatable'ın sutun isimleri ile station name ve device name isimleri id numaları ile değiştiriliyor.
                PrepareDataTableForDataBase(_dt);

                // Database'e kayıt yapmadan önce database'deki tüm sinyaller siliniyor.
                if (_deleteAll)
                {
                    DeleteAllBinarySignals();
                }

                return dbHelper.AddBinarySignalsToDataBase(_dt);
            }
            return false;
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

        private void frm_SignalList_Load(object sender, EventArgs e)
        {
            InitializedbHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        

        private bool UpdateExistingSignalsandImportNewSignals(string _fileName)
        {

            using (dt_CSV = ReadCSVFileForAnalogSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    DataTable rowsWillBeUpdated = new DataTable();
                    rowsWillBeUpdated = dt_CSV.Clone();
                    DataTable rowsWillBeImported = new DataTable();
                    rowsWillBeUpdated = dt_CSV.Clone();

                    // Database'den tüm analog sinyallerin ID leri okunur
                    List<uint> analogSignalsID = dbHelper.GetAllAnalogSignalsID();
                    string query = String.Format("CALL exportAllAnalogSignals()");
                    DataTable dt_AnalogSignals = dbHelper.ExecuteQuery(query);
                    // Database'den ID numarası donduyse,
                    if (analogSignalsID.Count > 0)
                    {

                        // Sadece yeni sinyaller import edilecekken diğerleri güncelleneceği için her satır tek tek kontrol edilir.
                        foreach (DataRow dr in dt_CSV.Rows)
                        {
                            uint id;
                            // CSV dosyasında "Analog Signal ID" sutunu bir sayı ise
                            if (uint.TryParse(dr["Analog Signal ID"].ToString(), out id))
                            {
                                // İlgili satırın ID no'su database'de kayıtlı olup olmadığı kontrol edilir
                                if (analogSignalsID.Exists((s) => s == id))
                                {
                                    // ID Database'de kayıtlı ise ilgili row datatable'den çekilir
                                    DataRow row2 = dt_AnalogSignals.AsEnumerable().Where((row) => row.Field<uint>("Analog Signal ID") == id).First();
                                    // row2'deki dataların hepsi string olarak kaydedilmediği için tüm datalar string'e çevrilir.
                                    var row2_AsString = string.Join(", ", row2.ItemArray);
                                    var dr_AsString = string.Join(", ",dr.ItemArray);
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
                                dr["Analog Signal ID"] = analogSignalsID.Max() > dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d["Analog Signal ID"].ToString(), out id)).Max((d) => uint.Parse(d["Analog Signal ID"].ToString())) ? analogSignalsID.Max() + 1 : dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d["Analog Signal ID"].ToString(), out id)).Max((d) => uint.Parse(d["Analog Signal ID"].ToString())) + 1;
                                rowsWillBeImported.Rows.Add(dr.ItemArray);
                            }
                        }
                    }
                    else
                    {
                        rowsWillBeImported = dt_CSV;
                    }

                    bool isImported = true;
                    bool isUpdated = true;

                    if (rowsWillBeUpdated.Rows.Count > 0)
                    {
                        isUpdated = UpdateAnalogSignalsToDataBase(rowsWillBeUpdated);
                    }

                    if (rowsWillBeImported.Rows.Count > 0)
                    {
                        isImported = ImportAnalogSignalsToDataBase(rowsWillBeImported, false);
                    }

                    return isImported & isUpdated;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool UpdateAnalogSignalsToDataBase(DataTable _dt)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    PrepareDataTableForDataBase(_dt);
                    return dbHelper.UpdateAnalogSignals(_dt);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Sinyaller güncellenemedi => {0}", ex.Message);
                return false;
            }
        }

        private bool ImportOnlyNewSignals(string _fileName)
        {
            using (dt_CSV = ReadCSVFileForAnalogSignals(_fileName))
            {
                // CSV dosyasından satır okunduysa
                if (dt_CSV.Rows.Count > 0)
                {
                    
                    // Database'den tüm analog sinyallerin ID leri okunur
                    List<uint> analogSignalsID = dbHelper.GetAllAnalogSignalsID();

                    // Database'den ID numarası donduyse,
                    if (analogSignalsID.Count > 0)
                    {
                        List<DataRow> rowsWillBeDeleted = new List<DataRow>();
                        // Sadece yen sinyaller import edileceği için her satır tek tek kontrol edilir.
                        foreach (DataRow dr in dt_CSV.Rows)
                        {
                            uint id;

                            // ID no bir sayı ise,
                            if (uint.TryParse(dr["Analog Signal ID"].ToString(), out id))
                            {
                                // Eğer ilgili satırın ID no'su ID database'de kayıtlıysa
                                if (analogSignalsID.Exists((s) => s == uint.Parse(dr["Analog Signal ID"].ToString())))
                                {
                                    // Sinyal zaten database'de mevcut demektir ve CSV dosyasından elde edilen datatable'dan bu satır silinir
                                    rowsWillBeDeleted.Add(dr);
                                }
                            }
                            // CSV dosyasındaki ID degeri gecerli bir sayı değilse,
                            else
                            {
                                dr["Analog Signal ID"] = analogSignalsID.Max() > dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d["Analog Signal ID"].ToString(), out id)).Max((d) => uint.Parse(d["Analog Signal ID"].ToString())) ? analogSignalsID.Max() + 1 : dt_CSV.AsEnumerable().Where((d) => uint.TryParse(d["Analog Signal ID"].ToString(), out id)).Max((d) => uint.Parse(d["Analog Signal ID"].ToString())) + 1;
                            }
                        }

                        // Database'de mevcut sinyaller datatable'dan silinir
                        if (rowsWillBeDeleted.Count > 0)
                        {
                            dt_CSV.RemoveRows(rowsWillBeDeleted);
                        }
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

        private bool ImportAnalogSignalsToDataBase(DataTable _dt, bool _deleteAll)
        {
            if (_dt.Rows.Count > 0)
            {
                // Kayıtlı station'lar CSV dosyasındakiler ile karşılaştırılır
                DataTable dt_stationNames = _dt.DefaultView.ToTable(true, "Station Name");
                if (dt_stationNames.Rows.Count > 0)
                {
                    // Database'den istasyonlara ait bilgiler çekiliyor.
                    stations = dbHelper.GetAllStationsInfoWithDeviceInfo();
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
                                if (!(station.Devices.Exists((d) => d.Name == deviceName)))
                                {
                                    AddDeviceToDataBaseOrRemoveFromCSVTable(stationName, deviceName);
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

                // Datatable'ın sutun isimleri ile station name ve device name isimleri id numaları ile değiştiriliyor.
                PrepareDataTableForDataBase(_dt);

                // Database'e kayıt yapmadan önce database'deki tüm sinyaller siliniyor.
                if (_deleteAll)
                {
                    DeleteAllAnalogSignals();
                }

                return dbHelper.AddAnalogSignalsToDataBase(_dt);
            }
            return false;
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

        private void AddStationToDataBaseOrRemoveFromCSVTable(string stationName)
        {
            DataTable _dt;
            // Kullanıcıya istasyonu database'e ekleyip eklemek istemediği sorulur,
            DialogResult result = MessageBox.Show(String.Format("{0} adlı istasyon database'de bulunamadı. istasyon database'e eklenmezse CSV dosyasında {0} adlı istasyona ait sinyaller de database'e eklenmeyecektir. İstasyonu database'e eklemek ister misiniz?", stationName), "EnMon Sürücü Yöneticisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            // Kullanıcının cevabı "evet" olursa
            if (result == DialogResult.Yes)
            {
                // İstasyon database' eklenir
                if (dbHelper.AddStation(stationName))
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
            List<Station> newStationList = dbHelper.GetAllStationsInfoWithDeviceInfo();
            
            // Her satır için Device Name ve Station Name bilgileri, Device ID ve Station ID bilgileri ile değiştiriliyor.
            foreach (DataRow dr in dt_CSV.Rows)
            {
                dr["Device Name"] = newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First().Devices.Where((d) => d.Name == dr["Device Name"].ToString()).First().ID;
                
                dr["Station Name"] = newStationList.Where((s) => s.Name == dr["Station Name"].ToString()).First().ID;
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
                List<Protocol> _protocols = dbHelper.GetAllProtocolsInfo();
                List<int> usedModbusSlaveAddresses = dbHelper.GetUsedModbusSlaveAddresses(stationName);
                usedModbusSlaveAddresses.Add(1);
                using (frm_AddDevice frm_addDevice = new frm_AddDevice(stationName, deviceName, _protocols, usedModbusSlaveAddresses))
                {
                    frm_addDevice.ClickedAddDeviceButton += Frm_addDevice_ClickedAddDeviceButton;
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

        private void Frm_addDevice_ClickedAddDeviceButton(object source, AddDeviceEventArgs e)
        {
            switch (e.ProtocolName)
            {
                case "ModbusTCP":
                    if (!(dbHelper.AddModbusTCPDeviceToDatabase(e.StationName, e.DeviceName, e.IpAddress, e.SlaveID)))
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

        private void DeleteAllAnalogSignals()
        {
            dbHelper.ResetTable("analog_signals");
        }

        private void DeleteAllBinarySignals()
        {
            dbHelper.ResetTable("binary_signals");
        }

        private bool ValidateCSVFormat(string fileName, CSVFileFormatType formatType)
        {
            switch (formatType)
            {
                case CSVFileFormatType.Binarysignals:
                    return false;//ValidateCSVFileHeaders(fileName, binarySignalsCSVFileHeaders);
                    break;

                case CSVFileFormatType.AnalogSignals:
                    return false;//ValidateCSVFileHeaders(fileName, analogSignalsCSVFileHeaders);
                    break;

                default:
                    return false;
                    break;
            }
        }

        /// <summary>
        /// Validates the CSV file headers.
        /// </summary>
        /// <param name="_fileName">Name of the file.</param>
        /// <param name="_headers">The headers.</param>
        /// <returns></returns>
        private DataTable ReadCSVFileForAnalogSignals(string _fileName)
        {
            DataTable dt = new DataTable();

            try
            {
                using (CsvReader csv = new CsvReader(new StreamReader(_fileName, System.Text.Encoding.Default), true, ';'))

                {
                    string[] headers = new string[] { };
                    headers = csv.GetFieldHeaders();

                    if (ValidateCSVFileHeaders(headers, analogSignalsCSVFileHeaders))
                    {
                        for (int c = 0; c < headers.Length; c++)
                        {
                            dt.Columns.Add(headers[c]);
                        }
                        int fieldCount = csv.FieldCount;
                        string[] columns = new string[fieldCount];
                        while (csv.ReadNextRecord())
                        {
                            csv.CopyCurrentRecordTo(columns);
                            dt.Rows.Add(columns);
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
            catch(Exception ex)
            {
                Log.Instance.Warn("CSV dosyası okunurken  bir hata ile  karşılaşıldı! => {0}", ex.Message);
                MessageBox.Show("CSV dosyası okunurken  bir hata ile  karşılaşıldı! Lütfen CSV dosyasını kontrol ediniz.", "EnMon Sürücü Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt.Clear();
                return dt;
            }
        }

        private bool ValidateCSVFileHeaders(string[] headers, string[] _headers)
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

        private void rdButton_DoNotDeleteOrOverWriteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.DoNotDeleteOrOverWriteOldSignals;
        }

        private void rdButton_OverWriteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.OverWriteOldSignals;
        }

        private void rdButton_DeleteOldSignals_Click(object sender, EventArgs e)
        {
            importSettings = ImportSettings.DeleteOldSignals;
        }

        private void btn_ExportAnalogSignalsAsCSV_Click(object sender, EventArgs e)
        {
            string folderName = GetFolderName();
            if (folderName != null)
            {
                if(ExportAnalogSignalsInfoAsCSVFromDatabase(folderName, "analog_signals"))
                {
                    MessageBox.Show("Analog Sinyaller başarılı bir şekilde dışarı aktarıldı", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Analog Sinyaller dışarı aktarılamadı. Ayrıntılı bilgi için lütfen log dosyasını kontrol ediniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}