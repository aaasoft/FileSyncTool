#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileSyncTool
{
	[Serializable]
	public class TongBuSetting
	{
		private static string SettingFileName = Path.Combine(Application.StartupPath, "文件同步配置.ini");

		public List<ComputerInfo> PcInfos = new List<ComputerInfo>();

		public DateTime LastTongBuTime;

		public string RelativelyUDiskFolder;

		public static TongBuSetting ReadSetting()
		{
			TongBuSetting tongBuSetting = null;
			if (File.Exists(SettingFileName))
			{
				FileStream stream = new FileStream(SettingFileName, FileMode.Open);
				StreamReader streamReader = new StreamReader(stream, Encoding.Default);
				string str = streamReader.ReadToEnd();
				streamReader.Close();
				object rtnObj;
				if (SharedFunction.XmlTryParse(str, typeof(TongBuSetting), true, out rtnObj))
				{
					TongBuSetting tongBuSetting2 = (TongBuSetting)rtnObj;
					tongBuSetting = tongBuSetting2;
				}
			}
			if (tongBuSetting == null)
			{
				tongBuSetting = new TongBuSetting();
			}
			return tongBuSetting;
		}

		public bool SaveSetting()
		{
			try
			{
				SharedFunction.SaveToXmlfile(this, SettingFileName);
				return true;
			}
			catch (Exception ex)
			{
				Debug.Print("保存配置文件失败。原因：" + ex.Message);
				return false;
			}
		}
	}
}
