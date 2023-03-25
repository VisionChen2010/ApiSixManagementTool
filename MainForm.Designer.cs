/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2023/2/8
 * Time: 14:50
 * 
 * 
 */
namespace ApiSixManagementTool
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Sunny.UI.UIDataGridView uiDataGridView1;
		private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除路由ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导出路由ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 全部取消ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导入路由ToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBox_servers;
		private System.Windows.Forms.Label label1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
			this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
			this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.全部取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.导出路由ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.导入路由ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除路由ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBox_servers = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
			this.uiContextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// uiDataGridView1
			// 
			this.uiDataGridView1.AllowUserToAddRows = false;
			this.uiDataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
			this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.uiDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uiDataGridView1.ContextMenuStrip = this.uiContextMenuStrip1;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
			this.uiDataGridView1.EnableHeadersVisualStyles = false;
			this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
			this.uiDataGridView1.Location = new System.Drawing.Point(0, 70);
			this.uiDataGridView1.Name = "uiDataGridView1";
			this.uiDataGridView1.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
			this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.uiDataGridView1.RowTemplate.Height = 23;
			this.uiDataGridView1.SelectedIndex = -1;
			this.uiDataGridView1.ShowGridLine = true;
			this.uiDataGridView1.Size = new System.Drawing.Size(1119, 434);
			this.uiDataGridView1.TabIndex = 0;
			this.uiDataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UiDataGridView1CellMouseClick);
			this.uiDataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.UiDataGridView1RowStateChanged);
			// 
			// uiContextMenuStrip1
			// 
			this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.全选ToolStripMenuItem,
			this.全部取消ToolStripMenuItem,
			this.导出路由ToolStripMenuItem,
			this.导入路由ToolStripMenuItem,
			this.删除路由ToolStripMenuItem});
			this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
			this.uiContextMenuStrip1.Size = new System.Drawing.Size(145, 134);
			// 
			// 全选ToolStripMenuItem
			// 
			this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
			this.全选ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.全选ToolStripMenuItem.Text = "全选选择";
			this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItemClick);
			// 
			// 全部取消ToolStripMenuItem
			// 
			this.全部取消ToolStripMenuItem.Name = "全部取消ToolStripMenuItem";
			this.全部取消ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.全部取消ToolStripMenuItem.Text = "全部取消";
			this.全部取消ToolStripMenuItem.Click += new System.EventHandler(this.全部取消ToolStripMenuItemClick);
			// 
			// 导出路由ToolStripMenuItem
			// 
			this.导出路由ToolStripMenuItem.Name = "导出路由ToolStripMenuItem";
			this.导出路由ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.导出路由ToolStripMenuItem.Text = "导出路由";
			this.导出路由ToolStripMenuItem.Click += new System.EventHandler(this.导出路由ToolStripMenuItemClick);
			// 
			// 导入路由ToolStripMenuItem
			// 
			this.导入路由ToolStripMenuItem.Name = "导入路由ToolStripMenuItem";
			this.导入路由ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.导入路由ToolStripMenuItem.Text = "导入路由";
			this.导入路由ToolStripMenuItem.Click += new System.EventHandler(this.导入路由ToolStripMenuItemClick);
			// 
			// 删除路由ToolStripMenuItem
			// 
			this.删除路由ToolStripMenuItem.Name = "删除路由ToolStripMenuItem";
			this.删除路由ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.删除路由ToolStripMenuItem.Text = "删除路由";
			this.删除路由ToolStripMenuItem.Click += new System.EventHandler(this.删除路由ToolStripMenuItemClick);
			// 
			// comboBox_servers
			// 
			this.comboBox_servers.FormattingEnabled = true;
			this.comboBox_servers.Location = new System.Drawing.Point(79, 38);
			this.comboBox_servers.Name = "comboBox_servers";
			this.comboBox_servers.Size = new System.Drawing.Size(184, 29);
			this.comboBox_servers.TabIndex = 1;
			this.comboBox_servers.SelectedIndexChanged += new System.EventHandler(this.ComboBox_serversSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "Server:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1119, 504);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_servers);
			this.Controls.Add(this.uiDataGridView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Apisix  Management Tool";
			this.TextAlignment = System.Drawing.StringAlignment.Center;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
			this.uiContextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
