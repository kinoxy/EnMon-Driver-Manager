using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers.Archiving;
using EnMon_Driver_Manager.Drivers.Mail;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Modbus;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Signals.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class MainForm2 : Form
    {
        private AbstractDBHelper dbHelper;

        #region Private Properties

        private frm_Devices frm_devices;
        private frm_SignalList frm_signallist;
        private frm_Email frm_email;
        private frm_EmailAlarms frm_emailAlarms;
        private ModbusTCP modbusTCP;
        private MailClient mailClient;
        private AbstractArchiving archivist;
        private TreeNode clickedNode;

        #endregion Private Properties

        #region Constructors

        public MainForm2()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Private Methods

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (ProjectTreeView.SelectedNode.Name)
            {
                case "Node_EmailGroups":
                    ShowMailGroups();
                    break;

                default:
                    break;
            }
        }

        private void ShowMailGroups()
        {
            frm_Email frm_email = new frm_Email(dbHelper);
            frm_email.AddToPanel(mainPanel, true);
        }

        private void LoadProjectTreeView()
        {
            LoadStations();
            //LoadMenus();
        }

        private void LoadMenus()
        {
            ProjectTreeView.Nodes[0].Nodes[1].ContextMenuStrip = contextMenuStrip_Stations;
            foreach (TreeNode node in ProjectTreeView.Nodes[0].Nodes[1].Nodes)
            {
                node.ContextMenuStrip = contextMenuStrip_Devices;
                foreach (TreeNode node2 in node.Nodes)
                {
                    foreach (TreeNode node3 in node2.Nodes)
                        node3.ContextMenuStrip = contextMenuStrip_Signals;
                }
            }
        }

        private void LoadStations()
        {
            TemporaryValues.stations = dbHelper.GetAllStationsInfoWithDeviceInfo();
            if (TemporaryValues.stations != null)
            {
                if (TemporaryValues.stations.Count > 0)
                {
                    ProjectTreeView.BeginUpdate();
                    // İlk Node seçilir
                    TreeNode node = ProjectTreeView.Nodes[0];
                    // 2 nolu node'un 'istasyonlar' node u oldugu kabul edilerek devam edilir.
                    if (node.Nodes[1].Nodes != null)
                    {
                        node.Nodes[1].Nodes.Clear();
                        node.Nodes[1].ContextMenuStrip = contextMenuStrip_Stations;
                    }
                    foreach (Station station in TemporaryValues.stations)
                    {
                        TreeNode node_station = new TreeNode(station.Name);
                        node_station.ContextMenuStrip = contextMenuStrip_Devices;
                        ProjectTreeView.Nodes[0].Nodes[1].Nodes.Add(node_station);
                        AddStationDevicesToTreeView(station.Devices, node_station);
                    }
                    ProjectTreeView.EndUpdate();
                }
            }
        }

        private void AddStationDevicesToTreeView(List<Device> devices, TreeNode node_station)
        {
            node_station.Nodes.Clear();
            foreach (var device in devices)
            {
                TreeNode node_device = new TreeNode(device.Name);
                TreeNode node_digitalsignals = new TreeNode("Digital Sinyaller");
                TreeNode node_analogsignals = new TreeNode("Analog Sinyaller");
                node_device.Nodes.Add(node_digitalsignals);
                node_device.Nodes.Add(node_analogsignals);
                foreach (TreeNode node in node_device.Nodes)
                {
                    node.ContextMenuStrip = contextMenuStrip_Signals;
                }
                node_station.Nodes.Add(node_device);
            }
        }

        private void LoadStationDevicesCommunicationStatusForm()
        {
            frm_Devices frm_devices = new frm_Devices();
            frm_devices.AddToPanel(mainPanel, true);
        }

        private void ShowStationDevices(Station station)
        {
            frm_Devices<Device> frm = new frm_Devices<Device>(station.Devices, dbHelper);
            frm.AddToPanel(mainPanel, true);
        }

        private void ShowDigitalSignals(TreeNode node)
        {
            // Node içerisinde yer alan fullpath property'si üzerinden istasyon ve cihaz ismi çekiliyor
            string node_path = node.FullPath;
            string[] path_texts = node_path.Split('\\');
            Station station = TemporaryValues.stations.Find(s => s.Name == path_texts[2]);
            Device device = station.Devices.Find(d => d.Name == path_texts[3]);
            switch (device.Protocol.ID)
            {
                // 1: ModbusTCP,
                case 1:
                    List<ModbusBinarySignal> signals = dbHelper.GetDeviceBinarySignalsInfo<ModbusBinarySignal>(device);
                    if (signals != null)
                    {
                        frm_Signals<ModbusBinarySignal> frm = new frm_Signals<ModbusBinarySignal>(signals, device, dbHelper);
                        frm.AddToPanel(mainPanel, true);
                    }
                    break;
            }
        }

        private void ShowAnalogSignals(TreeNode node)
        {
            // Node içerisinde yer alan fullpath property'si üzerinden istasyon ve cihaz ismi çekiliyor
            string node_path = node.FullPath;
            string[] path_texts = node_path.Split('\\');
            Station station = TemporaryValues.stations.Find(s => s.Name == path_texts[2]);
            Device device = station.Devices.Find(d => d.Name == path_texts[3]);
            switch (device.Protocol.ID)
            {
                // 1: ModbusTCP,
                case 1:
                    List<ModbusAnalogSignal> signals = dbHelper.GetDeviceAnalogSignalsInfo<ModbusAnalogSignal>(device);
                    if (signals != null)
                    {
                        frm_Signals<ModbusAnalogSignal> frm = new frm_Signals<ModbusAnalogSignal>(signals, device, dbHelper);
                        frm.AddToPanel(mainPanel, true);
                    }
                    break;
            }
        }

        private void ShowStations()
        {
            frm_Stations<Station> frm = new frm_Stations<Station>(TemporaryValues.stations, dbHelper);
            frm.AddToPanel(mainPanel, true);
        }

        private void LoadTemporaryValues()
        {
            TemporaryValues.archivePeriods = dbHelper.GetArchivePeriods();
            TemporaryValues.dataTypes = dbHelper.GetAllDataTypes();
            TemporaryValues.statusTexts = dbHelper.GetAllStatusTexts();
            TemporaryValues.protocols = dbHelper.GetAllProtocolsInfo();
            TemporaryValues.deviceTypes = dbHelper.GetAllDeviceTypes();
        }

        private void Load_frm_eMailSettings()
        {
            if (frm_email == null)
            {
                frm_email = new frm_Email();

                frm_email.TopLevel = false;
                frm_email.FormBorderStyle = FormBorderStyle.None;
                frm_email.Dock = DockStyle.Fill;
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(frm_email);
                frm_email.Visible = true;
            }
        }

        #endregion Private Methods

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            dbHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            dbHelper.DatabaseConnected += DatabaseConnected;

            if (dbHelper.IsConnected)
            {
                LoadProjectTreeView();
                LoadTemporaryValues();
            }
            else
            {
                MessageBox.Show("Database bağlantısı kurulamadığı için yazılım kapatılacaktır.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void menu_databaseConnectionSettings_Click(object sender, EventArgs e)
        {
            if (StaticHelper.GetDatabaseConnectionInfoFromUser())
            {
                dbHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
        }

        private void DatabaseConnected(object sender, DatabaseConnectionEventArgs args)
        {
            toolStripStatusLabel1.Text = $"Veritabanına bağlanıldı. Server: {AbstractDBHelper.str_serverAddress}";
        }

        private void ProjectTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void ProjectTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Text == "İstasyonlar")
                {
                    LoadStations();
                }
                if (e.Node.Parent.Text == "İstasyonlar")
                {
                    Station station = TemporaryValues.stations.Find((s) => s.Name == e.Node.Text);
                    if (station != null)
                    {
                        List<Device> devices = dbHelper.GetStationDevicesInfo<Device>(station.Name);
                        e.Node.Nodes.Clear();
                        AddStationDevicesToTreeView(devices, e.Node);
                    }
                }
            }
        }

        private void ProjectTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            string[] nodePath = node.FullPath.Split('\\');
            if (nodePath.Length > 1)
            {
                switch (nodePath[1])
                {
                    case "İstasyonlar":
                        if (nodePath.Length == 2)
                        {
                            //LoadStationDevicesCommunicationStatusForm();
                            ShowStations();
                        }
                        else if (nodePath.Length == 3)
                        {
                            var station = TemporaryValues.stations.Find((s) => s.Name == nodePath[2]);
                            if(station!=null)
                            {
                                ShowStationDevices(station);
                            }
                            
                        }
                        else if (nodePath.Length == 4)
                        {
                            //LoadDeviceSettingsForm(nodePath);
                        }
                        else
                        {
                            if (nodePath.Length > 4)
                            {
                                switch (nodePath[4])
                                {
                                    case "Digital Sinyaller":
                                        ShowDigitalSignals(node);
                                        break;

                                    case "Analog Sinyaller":
                                        ShowAnalogSignals(node);
                                        break;
                                }
                            }
                        }
                        break;

                    case "E-Posta Gönderimi":
                        if (nodePath.Length == 3)
                        {
                            switch (nodePath[2])
                            {
                                case "Grup Ayarları":
                                    ShowMailGroups();
                                    break;

                                case "E-Postalar":
                                    ShowMailAlarms();
                                    break;
                            }
                        }
                        break;

                    case "Sürücüler":
                        if (nodePath.Length == 2)
                        {
                            frm_Drivers frm = new frm_Drivers();
                            frm.AddToPanel(mainPanel, true);
                        }
                        if (nodePath.Length > 2)
                        {
                            switch (nodePath[2])
                            {
                                case "Mail Client":
                                    frm_MailClientSettings frm = new frm_MailClientSettings();
                                    frm.AddToPanel(mainPanel, true);
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void ShowMailAlarms()
        {
            frm_EmailAlarms frm = new frm_EmailAlarms(dbHelper);
            frm.AddToPanel(mainPanel, true);
        }

        private void addNewStation_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TemporaryValues.stations = dbHelper.addNewStation();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void addNewSignal_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            object signal;
            
            var devices = from s in TemporaryValues.stations from d in s.Devices where d.Name == clickedNode.Parent.Text select d;
            if (devices != null)
            {
                Device d; d = devices.ToList()[0];
                switch (clickedNode.Text)
                {
                    case "Digital Sinyaller":
                        signal = CreateBinarySignal(d);
                        if (signal != null)
                        {
                            string a = signal.GetType().ToString();
                            dbHelper.AddBinarySignalToDataBase(signal);
                            ProjectTreeView.SelectedNode = clickedNode;
                            ShowDigitalSignals(clickedNode);
                        }

                        break;
                    case "Analog Sinyaller":
                        signal = CreateAnalogSignal(d);
                        if (signal != null)
                        {
                            dbHelper.AddAnalogSignalToDataBase(signal);
                            ProjectTreeView.SelectedNode = clickedNode;
                            ShowAnalogSignals(clickedNode);
                        }
                        break;
               }
               
                

            }
            
        }

        private void ProjectTreeView_Click(object sender, EventArgs e)
        {
        }



        private object CreateBinarySignal(Device device)
        {
            Signal signal;
            List<Signal> signals;
            List<Signal> signalsContainName_YeniSinyal;

            switch (device.ID)
            {
                case 1: // ModbusTCP
                    signal = new ModbusBinarySignal();
                    break;

                case 2: // SNMP
                    signal = new Signal();
                    break;
                default:
                    signal = new Signal();
                    break;
            }

            signals = dbHelper.GetDeviceBinarySignalsInfo<Signal>(device);

            // Cihaz içerisinde aynı tipteki sinyaller aynı identification'ı alamazlar.
            // 'Yeni Sinyal' isimli başka bir sinyal varsa yeni oluşturulucak sinyalin ismi 'Yeni Sinyalx' olarak değiştiriliyor.
            // x => Sayı
            signalsContainName_YeniSinyal = signals.Where((s) => s.Name.Contains("Yeni Sinyal")).ToList();
            if (signalsContainName_YeniSinyal.Count > 0)
            {
                signal.Name = "Yeni Sinyal" + signalsContainName_YeniSinyal.Count.ToString();
            }

            // Sinyal ID'si oluşturuluyor
            signal.ID = dbHelper.GetNextBinarySignalID();

            // İstasyon ve cihaz bilgileri sinyale atanıyor.
            signal.DeviceName = device.Name;
            signal.deviceID = device.ID;
            signal.StationName = TemporaryValues.stations.Find((s) => s.ID == device.StationID).Name;

            // ID sıfırdan büyük ise başarılı bir şekilde veritabanından yeni ID değeri okunmuştur.
            // ID sıfır ise yeni ID değeri alınamamıştır ve sinyal oluşturulmaz.
            return signal.ID > 0 ? signal : null;
        }

        private object CreateAnalogSignal(Device device)
        {
            Signal signal;
            List<Signal> signals;
            List<Signal> signalsContainName_YeniSinyal;

            switch (device.ID) 
            {
                case 1: // ModbusTCP
                    signal = new ModbusAnalogSignal();
                    break;

                case 2: // SNMP
                    signal = new Signal();
                    break;
                default:
                    signal = new Signal();
                    break;
            }

            signals = dbHelper.GetDeviceAnalogSignalsInfo<Signal>(device);

            // Cihaz içerisinde aynı tipteki sinyaller aynı identification'ı alamazlar.
            // 'Yeni Sinyal' isimli başka bir sinyal varsa yeni oluşturulucak sinyalin ismi 'Yeni Sinyalx' olarak değiştiriliyor.
            // x => Sayı
            signalsContainName_YeniSinyal = signals.Where((s) => s.Name.Contains("Yeni Sinyal")).ToList();
            if (signalsContainName_YeniSinyal.Count > 0)
            {
                signal.Name = "Yeni Sinyal" + signalsContainName_YeniSinyal.Count.ToString();
            }

            // Sinyal ID'si oluşturuluyor
            signal.ID = dbHelper.GetNextAnalogSignalID();

            // İstasyon ve cihaz bilgileri sinyale atanıyor.
            signal.DeviceName = device.Name;
            signal.deviceID = device.ID;
            signal.StationName = TemporaryValues.stations.Find((s) => s.ID == device.StationID).Name;

            // ID sıfırdan büyük ise başarılı bir şekilde veritabanından yeni ID değeri okunmuştur.
            // ID sıfır ise yeni ID değeri alınamamıştır ve sinyal oluşturulmaz.
            return signal.ID > 0 ? signal : null;
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                if (e.Node.Text == "Digital Sinyaller" || e.Node.Text == "Analog Sinyaller")
                {
                    clickedNode = e.Node;
                    
                }
                else if(e.Node.Parent.Text ==  "İstasyonlar")
                {
                    clickedNode = e.Node;
                }
            }
        }

        private void addNewDevice_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void modbusTCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedNode.Parent.Text == ProjectTreeView.Nodes[0].Nodes[1].Text)
            {
                Station station = TemporaryValues.stations.Find((s) => s.Name == clickedNode.Text);
                if(dbHelper.AddNewDeviceToStation(station, 1))
                {
                    TemporaryValues.devices = dbHelper.GetStationDevices<Device>(station);
                    ShowStationDevices(station);
                }

            }
        }
    }

    #endregion Events
}