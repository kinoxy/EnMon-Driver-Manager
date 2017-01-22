using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Devices;
using System;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class MainForm2 : Form
    {
        private AbstractDBHelper dbHelper;

        public MainForm2()
        {
            InitializeComponent();
        }

        private void txt_ModbusTCPConfigFileLocation_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (ProjectTreeView.SelectedNode.Name)
            {
                case "Node_EmailGroups":
                    Load_frm_MailGroups();
                    break;

                default:
                    break;
            }
        }

        private void Load_frm_MailGroups()
        {
            frm_Email frm_email = new frm_Email();
            frm_email.FormBorderStyle = FormBorderStyle.None;
            frm_email.Dock = DockStyle.Fill;
            frm_email.TopLevel = false;
            frm_email.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            frm_email.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dbHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            if (dbHelper != null)
            {
                LoadProjectTreeView();
            }
            else
            {
                MessageBox.Show("Database bağlantısı kurulamadığı için yazılım kapatılacaktır.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadProjectTreeView()
        {
            LoadStations();
        }

        private void LoadStations()
        {
            TemporaryValues.stations = dbHelper.GetAllStationsInfoWithDeviceInfo();
            if (TemporaryValues.stations != null)
            {
                if (TemporaryValues.stations.Count > 0)
                {
                    ProjectTreeView.BeginUpdate();
                    TreeNode node = ProjectTreeView.Nodes[1];
                    foreach (Station station in TemporaryValues.stations)
                    {
                        TreeNode node_station = new TreeNode(station.Name);
                        foreach (Device device in station.Devices)
                        {
                            TreeNode node_device = new TreeNode(device.Name);
                            TreeNode node_digitalsignals = new TreeNode("Digital Sinyaller");
                            TreeNode node_analogsignals = new TreeNode("Analog Sinyallar");
                            node_device.Nodes.Add(node_digitalsignals);
                            node_device.Nodes.Add(node_analogsignals);
                            node_station.Nodes.Add(node_device);
                        }
                        node.Nodes.Add(node_station);
                    }
                    ProjectTreeView.EndUpdate();
                }
            }
        }

        private void GetTemporaryValues()
        {
            //TemporaryValues.stations = dbHelper.GetAllStationsInfoWithDeviceInfo();
            //TemporaryValues.archivePeriods = dbHelper.GetArchivePeriods();
            //TemporaryValues.dataTypes = dbHelper.GetAllDataTypes();
            //TemporaryValues.statusTexts = dbHelper.GetAllStatusTexts();
        }

        private void ProjectTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void ProjectTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (ProjectTreeView.SelectedNode.Text == "İstasyonlar")
            {
                LoadStations();
            }
        }
    }
}