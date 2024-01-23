using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FileSyncTool
{
	public static class SharedFunction
	{
		public const int bufferSize = 1000;

		private static XmlDocument xd = new XmlDocument();

		public static Color GetDeeperColor(Color srcColor, float deep)
		{
			int hue;
			int sat;
			int bri;
			RGB2HSB(srcColor, out hue, out sat, out bri);
			return HSB2RGBColor(hue, sat, (int)((float)bri * deep));
		}

		public static Color HSB2RGBColor(int hue, int sat, int bri)
		{
			if (hue > 239)
			{
				hue = 239;
			}
			else if (hue < 0)
			{
				hue = 0;
			}
			if (sat > 240)
			{
				sat = 240;
			}
			else if (sat < 0)
			{
				sat = 0;
			}
			if (bri > 240)
			{
				bri = 240;
			}
			else if (bri < 0)
			{
				bri = 0;
			}
			float num = (float)hue / 239f;
			float num2 = (float)sat / 240f;
			float num3 = (float)bri / 240f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			if (num3 == 0f)
			{
				num4 = (num5 = (num6 = 0f));
			}
			else if (num2 == 0f)
			{
				num4 = (num5 = (num6 = num3));
			}
			else
			{
				float num7 = ((num3 <= 0.5f) ? (num3 * (1f + num2)) : (num3 + num2 - num3 * num2));
				float num8 = 2f * num3 - num7;
				float[] array = new float[3]
				{
					num + 1f / 3f,
					num,
					num - 1f / 3f
				};
				float[] array2 = new float[3];
				float[] array3 = array2;
				for (int i = 0; i < 3; i++)
				{
					if (array[i] < 0f)
					{
						array[i] += 1f;
					}
					if (array[i] > 1f)
					{
						array[i] -= 1f;
					}
					if (6f * array[i] < 1f)
					{
						array3[i] = num8 + (num7 - num8) * array[i] * 6f;
					}
					else if (2f * array[i] < 1f)
					{
						array3[i] = num7;
					}
					else if (3f * array[i] < 2f)
					{
						array3[i] = num8 + (num7 - num8) * (2f / 3f - array[i]) * 6f;
					}
					else
					{
						array3[i] = num8;
					}
				}
				num4 = array3[0];
				num5 = array3[1];
				num6 = array3[2];
			}
			num4 = 255f * num4;
			num5 = 255f * num5;
			num6 = 255f * num6;
			if (num4 < 1f)
			{
				num4 = 0f;
			}
			else if (num4 > 255f)
			{
				num4 = 255f;
			}
			if (num5 < 1f)
			{
				num5 = 0f;
			}
			else if (num5 > 255f)
			{
				num5 = 255f;
			}
			if (num6 < 1f)
			{
				num6 = 0f;
			}
			else if (num6 > 255f)
			{
				num6 = 255f;
			}
			int red = (int)((double)num4 + 0.5);
			int green = (int)((double)num5 + 0.5);
			int blue = (int)((double)num6 + 0.5);
			return Color.FromArgb(red, green, blue);
		}

		public static void RGB2HSB(Color cor, out int hue, out int sat, out int bri)
		{
			RGB2HSB((int)cor.R, (int)cor.G, (int)cor.B, out hue, out sat, out bri);
		}

		public static void RGB2HSB(int r, int g, int b, out float hue, out float sat, out float bri)
		{
			int num = Math.Min(r, Math.Min(g, b));
			int num2 = Math.Max(r, Math.Max(g, b));
			bri = (float)(num2 + num) / 510f;
			if (num2 == num)
			{
				sat = 0f;
			}
			else
			{
				int num3 = num2 + num;
				if (num3 > 255)
				{
					num3 = 510 - num3;
				}
				sat = (float)(num2 - num) / (float)num3;
			}
			if (num2 == num)
			{
				hue = 0f;
				return;
			}
			float num4 = num2 - num;
			float num5 = (float)(num2 - r) / num4;
			float num6 = (float)(num2 - g) / num4;
			float num7 = (float)(num2 - b) / num4;
			hue = 0f;
			if (r == num2)
			{
				hue = 60f * (6f + num7 - num6);
			}
			if (g == num2)
			{
				hue = 60f * (2f + num5 - num7);
			}
			if (b == num2)
			{
				hue = 60f * (4f + num6 - num5);
			}
			if (hue > 360f)
			{
				hue -= 360f;
			}
		}

		public static void RGB2HSB(int r, int g, int b, out int hue, out int sat, out int bri)
		{
			float hue2;
			float sat2;
			float bri2;
			RGB2HSB(r, g, b, out hue2, out sat2, out bri2);
			hue = (int)((double)(hue2 / 360f * 240f) + 0.5);
			sat = (int)((double)(sat2 * 241f) + 0.5);
			bri = (int)((double)(bri2 * 241f) + 0.5);
			if (hue > 239)
			{
				hue = 239;
			}
			if (sat > 240)
			{
				sat = 240;
			}
			if (bri > 240)
			{
				bri = 240;
			}
		}

		public static Bitmap GetAlphaImage(Image srcImage, int Alpha)
		{
			try
			{
				Bitmap bitmap = (Bitmap)srcImage;
				Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
				for (int i = 0; i <= bitmap.Width - 1; i++)
				{
					for (int j = 0; j <= bitmap.Height - 1; j++)
					{
						Color pixel = bitmap.GetPixel(i, j);
						pixel = Color.FromArgb(Alpha * pixel.A / 255, pixel);
						bitmap2.SetPixel(i, j, pixel);
					}
				}
				return bitmap2;
			}
			catch
			{
				return null;
			}
		}

		public static Image GetBlackImage(Image srcImage)
		{
			try
			{
				Bitmap bitmap = (Bitmap)srcImage;
				Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
				for (int i = 0; i <= bitmap.Width - 1; i++)
				{
					for (int j = 0; j <= bitmap.Height - 1; j++)
					{
						Color pixel = bitmap.GetPixel(i, j);
						int r = pixel.R;
						int g = pixel.G;
						int b = pixel.B;
						int a = pixel.A;
						r = (r + g + b) / 3;
						pixel = Color.FromArgb(a, r, r, r);
						bitmap2.SetPixel(i, j, pixel);
					}
				}
				return bitmap2;
			}
			catch
			{
				return null;
			}
		}

		public static Bitmap GetBitmapResource(string bmpName)
		{
			try
			{
				Bitmap bitmap = GetObjectResource(bmpName) as Bitmap;
				if (bitmap == null)
					return null;
				return new Bitmap(bitmap, bitmap.Size);
			}
			catch
			{
				return null;
			}
		}

		public static object GetObjectResource(string objName)
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			ResourceManager resourceManager = new ResourceManager("FileSyncTool.Properties.Resources", callingAssembly);
			return RuntimeHelpers.GetObjectValue(resourceManager.GetObject(objName));
		}

		public static bool IsFormExist(Form frm)
		{
			if (frm == null || frm.IsDisposed)
			{
				return false;
			}
			return true;
		}

		public static Region CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(new Rectangle(nLeftRect, nTopRect, nWidthEllipse, nHeightEllipse), 180f, 90f);
			graphicsPath.AddArc(new Rectangle(nRightRect - nWidthEllipse - 1, nTopRect, nWidthEllipse, nHeightEllipse), -90f, 90f);
			graphicsPath.AddArc(new Rectangle(nRightRect - nWidthEllipse - 1, nBottomRect - nHeightEllipse - 1, nWidthEllipse, nHeightEllipse), 0f, 90f);
			graphicsPath.AddArc(new Rectangle(nLeftRect, nBottomRect - nHeightEllipse - 1, nWidthEllipse, nHeightEllipse), 90f, 90f);
			graphicsPath.CloseAllFigures();
			return new Region(graphicsPath);
		}

		public static Bitmap ChangeImageToColorImage(Bitmap srcBmp, Color desColor)
		{
			return ChangeImageToColorImage(srcBmp, desColor, 50);
		}

		public static Bitmap ChangeImageToColorImage(Bitmap srcBmp, Color desColor, int addLight)
		{
			if (srcBmp == null)
				return null;
			Bitmap bitmap = new Bitmap(srcBmp);
			for (int i = 0; i <= bitmap.Height - 1; i++)
			{
				for (int j = 0; j <= bitmap.Width - 1; j++)
				{
					Color pixel = bitmap.GetPixel(j, i);
					int num = Convert.ToInt32(desColor.R) * Convert.ToInt32(pixel.B) / (128 + addLight);
					int num2 = Convert.ToInt32(desColor.G) * Convert.ToInt32(pixel.B) / (128 + addLight);
					int num3 = Convert.ToInt32(desColor.B) * Convert.ToInt32(pixel.B) / (128 + addLight);
					if (num > 255)
					{
						num = 255;
					}
					if (num2 > 255)
					{
						num2 = 255;
					}
					if (num3 > 255)
					{
						num3 = 255;
					}
					pixel = Color.FromArgb(pixel.A, num, num2, num3);
					bitmap.SetPixel(j, i, pixel);
				}
			}
			return bitmap;
		}

		public static void DrawRectButton(Graphics graphics, Rectangle ButtonRect, Color BackColor, float deep)
		{
			float deep2 = 2f * deep;
			float deep3 = 1f * deep;
			float deep4 = 0.9f * deep;
			float deep5 = 1.2f * deep;
			int num = 1;
			int num2 = 4;
			Rectangle rect = new Rectangle(0, 0, ButtonRect.Width, Convert.ToInt32((double)ButtonRect.Height / 2.0) + 1);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, GetDeeperColor(BackColor, deep2), GetDeeperColor(BackColor, deep3), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			rect = new Rectangle(0, Convert.ToInt32((double)ButtonRect.Height / 2.0), ButtonRect.Width, ButtonRect.Height - Convert.ToInt32((double)ButtonRect.Height / 2.0));
			linearGradientBrush = new LinearGradientBrush(rect, GetDeeperColor(BackColor, deep4), GetDeeperColor(BackColor, deep5), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			linearGradientBrush.Dispose();
			Pen pen = new Pen(GetDeeperColor(BackColor, 0.9f), num);
			rect = new Rectangle(0, 0, ButtonRect.Width - 2, ButtonRect.Height - 2);
			graphics.DrawRectangle(pen, rect);
			graphics.DrawArc(pen, 0, 0, num2, num2, -180, 90);
			graphics.DrawArc(pen, ButtonRect.Width - num2 - 2, 0, num2, num2, -90, 90);
			graphics.DrawArc(pen, ButtonRect.Width - num2 - 2, ButtonRect.Height - num2 - 2, num2, num2, 0, 90);
			graphics.DrawArc(pen, 0, ButtonRect.Height - num2 - 2, num2, num2, 90, 90);
			pen.Dispose();
		}

		public static void SetLayout(Form frm)
		{
			SetLayout(frm, 0, 0);
		}

		public static void SetLayout(Form frm, int xoffset, int yoffset)
		{
			if (frm.Left < -xoffset)
			{
				frm.Width = frm.MinimumSize.Width;
				frm.Left = -xoffset;
			}
			if (frm.Left > Screen.PrimaryScreen.WorkingArea.Width - (frm.Width - xoffset))
			{
				frm.Width = frm.MinimumSize.Width;
				frm.Left = Screen.PrimaryScreen.WorkingArea.Width - (frm.Width - xoffset);
			}
			if (frm.Top < -yoffset)
			{
				frm.Height = frm.MinimumSize.Height;
				frm.Top = -yoffset;
			}
			if (frm.Top > Screen.PrimaryScreen.WorkingArea.Height - (frm.Height - yoffset))
			{
				frm.Height = frm.MinimumSize.Height;
				frm.Top = Screen.PrimaryScreen.WorkingArea.Height - (frm.Height - yoffset);
			}
		}

		public static void CompressFile(string srcFileName, string desFileName)
		{
			FileStream srcStream = new FileStream(srcFileName, FileMode.Open);
			FileStream desStream = new FileStream(desFileName, FileMode.OpenOrCreate, FileAccess.Write);
			CompressFile(srcStream, desStream);
		}

		public static void CompressFile(Stream srcStream, Stream desStream)
		{
			desStream.SetLength(0L);
			GZipStream gZipStream = new GZipStream(desStream, CompressionMode.Compress, false);
			byte[] array = new byte[1000];
			int num = 0;
			do
			{
				num = srcStream.Read(array, 0, array.Length);
				gZipStream.Write(array, 0, num);
			}
			while (num == array.Length);
			srcStream.Close();
			gZipStream.Flush();
			gZipStream.Close();
		}

		public static void DecompressFile(string srcFileName, string desFileName)
		{
			FileStream srcStream = new FileStream(srcFileName, FileMode.Open);
			FileStream desStream = new FileStream(desFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			DecompressFile(srcStream, desStream);
		}

		public static void DecompressFile(Stream srcStream, Stream desStream)
		{
			Exception ex = null;
			try
			{
				desStream.SetLength(0L);
				GZipStream gZipStream = new GZipStream(srcStream, CompressionMode.Decompress, false);
				byte[] array = new byte[1000];
				int num = 0;
				do
				{
					num = gZipStream.Read(array, 0, array.Length);
					desStream.Write(array, 0, num);
				}
				while (num == array.Length);
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			finally
			{
				srcStream.Close();
				desStream.Close();
			}
			if (ex != null)
			{
				throw ex;
			}
		}

		public static void ReleaseResourceFile(string resourceName, string fileName)
		{
			FileStream desStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			byte[] buffer = (byte[])GetObjectResource(resourceName);
			MemoryStream srcStream = new MemoryStream(buffer);
			DecompressFile(srcStream, desStream);
		}

		public static Process RunApp(string fileName, string args)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.FileName = fileName;
				processStartInfo.Arguments = args;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				return process;
			}
			catch
			{
				return null;
			}
		}

		public static string GetHardwareID()
		{
			try
			{
				string macAddresses = GetMacAddresses();
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(macAddresses)), 0, 8).Replace("-", "");
			}
			catch
			{
				return Dns.GetHostAddresses("")[0].ToString();
			}
		}

		public static string GetMacAddresses()
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("WIN32_NetworkAdapterConfiguration");
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementObject item in instances)
			{
				if ((bool)item["IPEnabled"])
				{
					text += item["MacAddress"].ToString().Replace(":", "").ToString();
				}
			}
			return text;
		}

		public static bool XmlTryParse(string str, Type objType, bool IsCheckTypeName, out object rtnObj)
		{
			return XmlTryParse(Encoding.Default.GetBytes(str), objType, IsCheckTypeName, out rtnObj);
		}

		public static bool XmlTryParse(byte[] bytes, Type objType, bool IsCheckTypeName, out object rtnObj)
		{
			try
			{
				if (bytes[0] != 60 || bytes[1] != 63 || bytes[2] != 120 || bytes[3] != 109 || bytes[4] != 108)
				{
					rtnObj = null;
					return false;
				}
				lock (xd)
				{
					string @string = Encoding.Default.GetString(bytes);
					xd.LoadXml(@string);
					if (IsCheckTypeName && objType.Name.ToString().ToUpper() != xd.DocumentElement.Name.ToUpper())
					{
						rtnObj = null;
						return false;
					}
					XmlSerializer xmlSerializer = new XmlSerializer(objType);
					MemoryStream stream = new MemoryStream(bytes);
					object obj = xmlSerializer.Deserialize(stream);
					rtnObj = obj;
				}
				if (rtnObj == null)
				{
					return false;
				}
				return true;
			}
			catch
			{
				rtnObj = null;
				return false;
			}
		}

		public static void SaveToXmlfile(object obj, string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			fileStream.SetLength(0L);
			TextWriter textWriter = new StreamWriter(fileStream, Encoding.Default);
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			xmlSerializer.Serialize(textWriter, obj);
			textWriter.Close();
		}

		public static bool CreateMultiFolder(string folderName)
		{
			try
			{
				if (Directory.Exists(folderName))
				{
					return true;
				}
				string directoryName = Path.GetDirectoryName(folderName);
				if (!Directory.Exists(directoryName) && !CreateMultiFolder(directoryName))
				{
					return false;
				}
				Directory.CreateDirectory(folderName);
				return true;
			}
			catch
			{
				throw;
			}
		}
	}
}
