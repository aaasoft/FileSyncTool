using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileSyncTool.MyControls;

namespace FileSyncTool
{
	public class MainForm : MyForm
	{
		private delegate void WhenEndDelegate();

		private delegate void PushResultDelegate(string msg);

		private delegate void PushProgressDelegate(double prc);

		private IContainer components = null;

		private MyStartButton btnStart;

		private MyProgressBar pbTotal;

		private Label lblShow;

		private Label label2;

		private Label label3;

		private TextBox txtComputerFolder;

		private TextBox txtUDiskFolder;

		private MyButton btnChangeComputerFolder;

		private MyButton btnChangeUDiskFolder;

		private TongBuSetting MainFormSetting;

		private ComputerInfo selfPCInfo;

		private DriveInfo UDiskDriveInfo;

		private string ComputerID = SharedFunction.GetHardwareID();

		private string _ComputerFolder;

		private string _UDiskFolder;

		public string ComputerFolder
		{
			get
			{
				return _ComputerFolder;
			}
			set
			{
				if (IsFolderRight(value))
				{
					_ComputerFolder = value;
				}
			}
		}

		public string UDiskFolder
		{
			get
			{
				return _UDiskFolder;
			}
			set
			{
				if (IsFolderRight(value, true))
				{
					_UDiskFolder = value;
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSyncTool.MainForm));
			this.btnStart = new FileSyncTool.MyControls.MyStartButton();
			this.pbTotal = new FileSyncTool.MyControls.MyProgressBar();
			this.lblShow = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtComputerFolder = new System.Windows.Forms.TextBox();
			this.txtUDiskFolder = new System.Windows.Forms.TextBox();
			this.btnChangeComputerFolder = new FileSyncTool.MyControls.MyButton();
			this.btnChangeUDiskFolder = new FileSyncTool.MyControls.MyButton();
			base.SuspendLayout();
			this.btnStart.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnStart.Location = new System.Drawing.Point(172, 132);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(45, 45);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "开始(&S)";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(btnStart_Click);
			this.pbTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pbTotal.BackColor = System.Drawing.Color.White;
			this.pbTotal.Location = new System.Drawing.Point(1, 183);
			this.pbTotal.Maximum = 1000;
			this.pbTotal.Minimum = 0;
			this.pbTotal.Name = "pbTotal";
			this.pbTotal.ProgressColor = System.Drawing.Color.DarkTurquoise;
			this.pbTotal.ProgressImage = null;
			this.pbTotal.ShowLight = true;
			this.pbTotal.ShowProgressImage = false;
			this.pbTotal.ShowProgressText = false;
			this.pbTotal.Size = new System.Drawing.Size(385, 23);
			this.pbTotal.TabIndex = 1;
			this.pbTotal.Value = 0;
			this.lblShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.lblShow.AutoSize = true;
			this.lblShow.Location = new System.Drawing.Point(12, 168);
			this.lblShow.Name = "lblShow";
			this.lblShow.Size = new System.Drawing.Size(53, 12);
			this.lblShow.TabIndex = 2;
			this.lblShow.Text = "准备就绪";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "计算机资料目录";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "U盘资料目录";
			this.txtComputerFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtComputerFolder.Location = new System.Drawing.Point(12, 60);
			this.txtComputerFolder.Name = "txtComputerFolder";
			this.txtComputerFolder.ReadOnly = true;
			this.txtComputerFolder.Size = new System.Drawing.Size(306, 21);
			this.txtComputerFolder.TabIndex = 3;
			this.txtUDiskFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUDiskFolder.Location = new System.Drawing.Point(12, 107);
			this.txtUDiskFolder.Name = "txtUDiskFolder";
			this.txtUDiskFolder.ReadOnly = true;
			this.txtUDiskFolder.Size = new System.Drawing.Size(306, 21);
			this.txtUDiskFolder.TabIndex = 3;
			this.btnChangeComputerFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnChangeComputerFolder.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnChangeComputerFolder.BorderWidth = 1;
			this.btnChangeComputerFolder.ImageLeftPosition = 0.1f;
			this.btnChangeComputerFolder.Location = new System.Drawing.Point(324, 60);
			this.btnChangeComputerFolder.Name = "btnChangeComputerFolder";
			this.btnChangeComputerFolder.RoundRectWidth = 2;
			this.btnChangeComputerFolder.Size = new System.Drawing.Size(51, 21);
			this.btnChangeComputerFolder.TabIndex = 4;
			this.btnChangeComputerFolder.Text = "更改..";
			this.btnChangeComputerFolder.TextAlign = System.Drawing.StringAlignment.Center;
			this.btnChangeComputerFolder.UseVisualStyleBackColor = false;
			this.btnChangeComputerFolder.Click += new System.EventHandler(btnChangeComputerFolder_Click);
			this.btnChangeUDiskFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnChangeUDiskFolder.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnChangeUDiskFolder.BorderWidth = 1;
			this.btnChangeUDiskFolder.ImageLeftPosition = 0.1f;
			this.btnChangeUDiskFolder.Location = new System.Drawing.Point(324, 107);
			this.btnChangeUDiskFolder.Name = "btnChangeUDiskFolder";
			this.btnChangeUDiskFolder.RoundRectWidth = 2;
			this.btnChangeUDiskFolder.Size = new System.Drawing.Size(50, 21);
			this.btnChangeUDiskFolder.TabIndex = 4;
			this.btnChangeUDiskFolder.Text = "更改..";
			this.btnChangeUDiskFolder.TextAlign = System.Drawing.StringAlignment.Center;
			this.btnChangeUDiskFolder.UseVisualStyleBackColor = false;
			this.btnChangeUDiskFolder.Click += new System.EventHandler(btnChangeUDiskFolder_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSkyBlue;
			base.ClientLeft = 13;
			base.ClientSize = new System.Drawing.Size(386, 206);
			base.ClientTop = 169;
			base.Controls.Add(this.btnChangeUDiskFolder);
			base.Controls.Add(this.btnChangeComputerFolder);
			base.Controls.Add(this.txtUDiskFolder);
			base.Controls.Add(this.txtComputerFolder);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblShow);
			base.Controls.Add(this.pbTotal);
			base.Controls.Add(this.btnStart);
			this.DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "MainForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "文件资料同步工具";
			base.TopMost = true;
			base.Load += new System.EventHandler(MainForm_Load);
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainForm_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			InitForm();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			PushResult("保存设置中...");
			MainFormSetting.SaveSetting();
		}

		private void btnChangeComputerFolder_Click(object sender, EventArgs e)
		{
			ChangeComputerFolder();
		}

		private void btnChangeUDiskFolder_Click(object sender, EventArgs e)
		{
			ChangeUDiskFolder();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			btnChangeComputerFolder.Enabled = false;
			btnChangeUDiskFolder.Enabled = false;
			btnStart.Enabled = false;
			Thread thread = new Thread(TongBuThread);
			thread.IsBackground = true;
			thread.Start();
		}

		private void TongBuThread()
		{
			PushResult("初始化中...");
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			PushResult("扫描计算机文件资料目录中...");
			ScanFolder(ComputerFolder, list, list2);
			PushResult("扫描U盘文件资料目录中...");
			ScanFolder(UDiskFolder, list3, list4);
			PushResult("检查U盘文件资料目录中...");
			CheckFolder(ComputerFolder, UDiskFolder, list, list3);
			PushResult("检查计算机文件资料目录中...");
			CheckFolder(UDiskFolder, ComputerFolder, list3, list);
			PushResult("同步计算机内文件中...");
			CheckFile(ComputerFolder, UDiskFolder, list2, list4);
			PushResult("同步U盘内文件中...");
			CheckFile(UDiskFolder, ComputerFolder, list4, list2);
			MainFormSetting.LastTongBuTime = DateTime.Now;
			PushResult("准备就绪 | 最后一次同步时间:" + MainFormSetting.LastTongBuTime.ToLocalTime());
			WhenEnd();
		}

		public void ScanFolder(string folderName, List<string> FolderList, List<string> FileList)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories("*", SearchOption.AllDirectories);
				if (directories.Length > 0)
				{
					for (int i = 0; i <= directories.Length - 1; i++)
					{
						DirectoryInfo directoryInfo2 = directories[i];
						FolderList.Add(directoryInfo2.FullName);
						PushProgress(((float)i + 1f) / (float)directories.Length);
					}
				}
				FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
				if (files.Length > 0)
				{
					for (int i = 0; i <= files.Length - 1; i++)
					{
						FileInfo fileInfo = files[i];
						FileList.Add(fileInfo.FullName);
						PushProgress(((float)i + 1f) / (float)files.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("扫描目录时出错，程序将退出，原因：" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Environment.Exit(0);
			}
		}

		public void CheckFolder(string srcFolder, string desFolder, List<string> srcFolderList, List<string> desFolderList)
		{
			int length = srcFolder.Length;
			for (int i = 0; i <= srcFolderList.Count - 1; i++)
			{
				string text = srcFolderList[i];
				string text2 = desFolder + text.Substring(length);
				if (!Directory.Exists(text2))
				{
					SharedFunction.CreateMultiFolder(text2);
					DirectoryInfo directoryInfo = new DirectoryInfo(text);
					DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
					directoryInfo2.LastAccessTime = directoryInfo.LastAccessTime;
					directoryInfo2.LastWriteTime = directoryInfo.LastWriteTime;
					directoryInfo2.CreationTime = directoryInfo.CreationTime;
				}
				PushProgress(((float)i + 1f) / (float)srcFolderList.Count);
			}
		}

		public void CheckFile(string srcFolder, string desFolder, List<string> srcFileList, List<string> desFileList)
		{
			int length = srcFolder.Length;
			for (int i = 0; i <= srcFileList.Count - 1; i++)
			{
				string text = srcFileList[i];
				string text2 = desFolder + text.Substring(length);
				if (File.Exists(text2))
				{
					FileInfo fileInfo = new FileInfo(text);
					FileInfo fileInfo2 = new FileInfo(text2);
					long ticks = (fileInfo.LastWriteTime - fileInfo2.LastWriteTime).Ticks;
					if (ticks > 0)
					{
						File.Copy(text, text2, true);
					}
					else if (ticks < 0)
					{
						File.Copy(text2, text, true);
					}
				}
				else
				{
					File.Copy(text, text2);
				}
				PushProgress(((float)i + 1f) / (float)srcFileList.Count);
			}
		}

		public void WhenEnd()
		{
			Invoke(new WhenEndDelegate(_WhenEnd));
		}

		private void _WhenEnd()
		{
			btnChangeComputerFolder.Enabled = true;
			btnChangeUDiskFolder.Enabled = true;
			btnStart.Enabled = true;
		}

		private void InitForm()
		{
			MainFormSetting = TongBuSetting.ReadSetting();
			if (MainFormSetting.PcInfos.Count > 0)
			{
				foreach (ComputerInfo pcInfo in MainFormSetting.PcInfos)
				{
					if (pcInfo.ID == ComputerID)
					{
						selfPCInfo = pcInfo;
						ComputerFolder = selfPCInfo.ComputerFolder;
						txtComputerFolder.Text = ComputerFolder;
						break;
					}
				}
				UDiskFolder = Application.StartupPath.Substring(0, 2) + MainFormSetting.RelativelyUDiskFolder;
				txtUDiskFolder.Text = UDiskFolder;
			}
			if (selfPCInfo == null)
			{
				MessageBox.Show("发现新的计算机，按[确定]按钮后设置本计算机上的文件资料目录。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			UDiskDriveInfo = new DriveInfo(Application.StartupPath.Substring(0, 1));
			if (UDiskDriveInfo.DriveType != DriveType.Removable)
			{
				MessageBox.Show("请从U盘中启动本程序！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Environment.Exit(0);
			}
			if (string.IsNullOrEmpty(ComputerFolder))
			{
				if (selfPCInfo == null)
				{
					selfPCInfo = new ComputerInfo();
					MainFormSetting.PcInfos.Add(selfPCInfo);
				}
				selfPCInfo.ID = ComputerID;
				if (!ChangeComputerFolder())
				{
					Environment.Exit(0);
				}
			}
			if (string.IsNullOrEmpty(UDiskFolder) && !ChangeUDiskFolder())
			{
				Environment.Exit(0);
			}
		}

		private bool ChangeComputerFolder()
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.Description = "请选择计算机上文件资料目录";
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				{
					return false;
				}
				if (!IsFolderRight(folderBrowserDialog.SelectedPath))
				{
					return ChangeComputerFolder();
				}
				txtComputerFolder.Text = folderBrowserDialog.SelectedPath;
				ComputerFolder = folderBrowserDialog.SelectedPath;
				selfPCInfo.ComputerFolder = ComputerFolder;
				return true;
			}
			catch
			{
				MessageBox.Show("选择目录出错，请重新选择！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private bool ChangeUDiskFolder()
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.Description = $"请选择U盘上文件资料目录(仅限驱动器[{Application.StartupPath.Substring(0, 3)}])";
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				folderBrowserDialog.SelectedPath = Application.StartupPath.Substring(0, 3);
				if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				{
					return false;
				}
				DriveInfo driveInfo = new DriveInfo(folderBrowserDialog.SelectedPath.Substring(0, 1));
				if (!IsFolderRight(folderBrowserDialog.SelectedPath, true))
				{
					return ChangeUDiskFolder();
				}
				txtUDiskFolder.Text = folderBrowserDialog.SelectedPath;
				UDiskFolder = folderBrowserDialog.SelectedPath;
				MainFormSetting.RelativelyUDiskFolder = UDiskFolder.Substring(2);
				return true;
			}
			catch
			{
				MessageBox.Show("选择目录出错，请重新选择！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		public bool IsFolderRight(string folderName)
		{
			return IsFolderRight(folderName, false);
		}

		public bool IsFolderRight(string folderName, bool IsCheckRemovable)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
			DriveInfo driveInfo = new DriveInfo(directoryInfo.FullName.Substring(0, 1));
			if (IsCheckRemovable)
			{
				if (driveInfo.DriveType != DriveType.Removable)
				{
					MessageBox.Show($"驱动器[{driveInfo.Name}]不是可移动设备！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
				if (driveInfo.Name.Substring(0, 1).ToUpper() != Application.StartupPath.Substring(0, 1).ToUpper())
				{
					MessageBox.Show($"您只可以选择驱动器[{Application.StartupPath.Substring(0, 3)}]下的目录！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}
			else if (driveInfo.DriveType != DriveType.Fixed)
			{
				MessageBox.Show($"驱动器[{driveInfo.Name}]不是固定磁盘！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (!driveInfo.IsReady)
			{
				MessageBox.Show($"驱动器[{driveInfo.Name}]未准备好！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (!directoryInfo.Exists)
			{
				MessageBox.Show($"目录[{directoryInfo.FullName}]不存在！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		public void PushResult(string msg)
		{
			Invoke(new PushResultDelegate(_PushResult), msg);
		}

		private void _PushResult(string msg)
		{
			lblShow.Text = msg;
		}

		public void PushProgress(double prc)
		{
			Invoke(new PushProgressDelegate(_PushProgress), prc);
		}

		private void _PushProgress(double prc)
		{
			if (prc >= 0.0 && prc <= 1.0)
			{
				pbTotal.Value = Convert.ToInt32(prc * 1000.0);
			}
		}
	}
}
