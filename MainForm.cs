/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2023/2/8
 * Time: 14:50
 * 用于管理Apisix，比页面多了一个批量删除路由的功能，页面只能一条条的删除。当需要重新全量配置apisix路由的时候可以使用
 * 支持多台服务器的管理
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ApiSixUtify;
using System.ComponentModel;
using System.Data;
using System.Xml;



namespace ApiSixManagementTool
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Sunny.UI.UIForm
	{
		ApiSixClient apisixClient;
		
		List<ServerInfo> _ServerList=new List<ServerInfo>();
		
		string _initTitle="";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void MainFormLoad(object sender, EventArgs e)
		{

		}
				
		void MainFormShown(object sender, EventArgs e)
		{
			_initTitle=this.Text;
			
			XmlNodeList _Servers=XMLConfigMgr.GetConfig("Config.xml");
			foreach(XmlNode Server in _Servers)
			{
				string _IPPort=Server.Attributes["IPPort"].Value;
				string _User=Server.Attributes["User"].Value;
				string _Password=Server.Attributes["Password"].Value;
				_ServerList.Add(new ServerInfo{IPPort=_IPPort,User=_User,Password=_Password});
				
				comboBox_servers.Items.Add(_IPPort.Split(':')[0]);
			}
			
			comboBox_servers.SelectedIndexChanged-=ComboBox_serversSelectedIndexChanged;   //先去掉combobox的选择事件
			comboBox_servers.SelectedIndex=0;


			
		
			apisixClient=new ApiSixClient{IPPort=_ServerList[0].IPPort,User=_ServerList[0].User,Password=_ServerList[0].Password};
			
			this.Text=_initTitle+" [ "+apisixClient.IPPort.Split(':')[0]+" ]";
			
			
			
			uiDataGridView1.RowHeadersVisible=true;
			uiDataGridView1.RowHeadersWidth=80;

			//datagridview自动列宽
			uiDataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
			uiDataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;

			
			try
			{

				ShowRoute();
			}
			catch
			{
			
			}
			
			
			
			//为dgv增加复选框列
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            //列显示名称
            checkbox.HeaderText = "Select";
            checkbox.Name = "IsChecked";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.DataPropertyName = "IsChecked";
            //列宽
            checkbox.Width = 50;
            //列大小不改变
            checkbox.Resizable = DataGridViewTriState.False;
            //添加的checkbox在dgv第一列
            this.uiDataGridView1.Columns.Insert(0, checkbox);		
			
			
			comboBox_servers.SelectedIndexChanged+=ComboBox_serversSelectedIndexChanged;   //恢复combobox的选择事件

			
			
		}
		
		//显示路由
		void ShowRoute()
		{
		
			//加载路由
			
			apisixClient.Login();
			List<RouteInfo> Routes=apisixClient.GetRoute();
			
			DataTable dt=new DataTable();
			dt.Columns.Add("Path");
			dt.Columns.Add("Name");
			dt.Columns.Add("ID");
			
			foreach(RouteInfo route in Routes)
			{
				dt.Rows.Add(route.Path,route.Name,route.ID);
			
			}
			
			
			uiDataGridView1.DataSource=dt;
			if(dt.Rows.Count >0)
			{
				uiDataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
			}
				

	
		
		}
		
		
		void UiDataGridView1RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			 e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
		}
		void MainFormSizeChanged(object sender, EventArgs e)
		{	
			if(this.WindowState==System.Windows.Forms.FormWindowState.Maximized)
			{
				
				//datagridview自动列宽
				uiDataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
				uiDataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
				uiDataGridView1.Columns[0].Width=80;
			}
			else
			{
			
				//datagridview自动列宽
				uiDataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
				uiDataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
			}
	
		}
		void UiDataGridView1CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//增加单机选中复选框
			
			//不是序号列和标题列时才执行
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                //checkbox 勾上
                if ((bool)uiDataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    //选中改为不选中
                    this.uiDataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    //不选中改为选中
                    this.uiDataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }

		}
		void 全选ToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(DataGridViewRow dgr in uiDataGridView1.Rows)
			{
				dgr.Cells[0].Value=true;
			}
		}
		void 全部取消ToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(DataGridViewRow dgr in uiDataGridView1.Rows)
			{
				dgr.Cells[0].Value=false;
			}
		}
		void 删除路由ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除勾选的路由
			foreach(DataGridViewRow dgr in uiDataGridView1.Rows)
			{
				if((bool)dgr.Cells[0].EditedFormattedValue)
				{
					string ID=dgr.Cells["ID"].Value.ToString();
					apisixClient.DeleteRoute(ID);
				}
			}
			
			ShowRoute();
		}
		void 导出路由ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除勾选的路由
			List<string> RouteIDS=new List<string>();
			foreach(DataGridViewRow dgr in uiDataGridView1.Rows)
			{
				
				if((bool)dgr.Cells[0].EditedFormattedValue)
				{
					string ID=dgr.Cells["ID"].Value.ToString();
					RouteIDS.Add(ID);
				}
			}
			apisixClient.ExportRoute(RouteIDS);
			
			
		}
		void 导入路由ToolStripMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				apisixClient.ImportRoute(BrowseLocalFile());
				ShowRoute();
			}
			catch
			{
			
			}
			
		}
		
		
		
		        //选择本地文件
        string BrowseLocalFile()
        {
        
            //选择文件
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            //fdlg.Filter = "cui files（*.cui）|*.cui|xml files(*.xml)|*.xml";
            /*
             * FilterIndex 属性用于选择了何种文件类型,缺省设置为0,系统取Filter属性设置第一项
             * ,相当于FilterIndex 属性设置为1.如果你编了3个文件类型，当FilterIndex ＝2时是指第2个.
             */
            fdlg.FilterIndex = 0;
            /*
             *如果值为false，那么下一次选择文件的初始目录是上一次你选择的那个目录，
             *不固定；如果值为true，每次打开这个对话框初始目录不随你的选择而改变，是固定的  
             */
            fdlg.RestoreDirectory = true;
            if(fdlg.ShowDialog() == DialogResult.OK)
            {
               return fdlg.FileName;
            }
            else
            {
                return "";
            }
        }


		void ComboBox_serversSelectedIndexChanged(object sender, EventArgs e)
		{
			ServerInfo server=_ServerList[comboBox_servers.SelectedIndex];
			apisixClient.IPPort=server.IPPort;
			apisixClient.User=server.User;
			apisixClient.Password=server.Password;
			
			this.Text=_initTitle+" [ "+apisixClient.IPPort.Split(':')[0]+" ]";
			
			
			ShowRoute();
			
			try
			{

				
			}
			catch
			{
			
			}
	
		}

	}
	
	struct ServerInfo
	{
		public string  IPPort;
		public string  User;
		public string  Password;
	
	
	}
}
