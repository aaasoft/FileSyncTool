#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileSyncTool.MyControls
{
	public class MyForm : Form
	{
		public enum DX
		{
			East = 61442,
			North = 61443,
			NorthEast = 61445,
			NorthWest = 61444,
			South = 61446,
			SouthEast = 61448,
			SouthWest = 61447,
			West = 61441
		}

		public delegate void MouseNcEnterEventHandler(object sender, EventArgs e);

		public delegate void MouseNcLeaveEventHandler(object sender, EventArgs e);

		[Serializable]
		public class SkinDataClass
		{
			public string AuthorName = Application.CompanyName;

			public Bitmap btnCloseClickImage = MyForm.btnCloseClickImage;

			public Bitmap btnCloseHoverImage = MyForm.btnCloseHoverImage;

			public Bitmap btnCloseImage = MyForm.btnCloseImage;

			public Bitmap btnMaxClickImage = MyForm.btnMaxClickImage;

			public Bitmap btnMaxHoverImage = MyForm.btnMaxHoverImage;

			public Bitmap btnMaxImage = MyForm.btnMaxImage;

			public Bitmap btnMinClickImage = MyForm.btnMinClickImage;

			public Bitmap btnMinHoverImage = MyForm.btnMinHoverImage;

			public Bitmap btnMinImage = MyForm.btnMinImage;

			public Bitmap btnRestoreClickImage = MyForm.btnRestoreClickImage;

			public Bitmap btnRestoreHoverImage = MyForm.btnRestoreHoverImage;

			public Bitmap btnRestoreImage = MyForm.btnRestoreImage;

			public int btnSpeatorWidth = MyForm.btnSpeatorWidth;

			public Color leftSideColor = MyForm.leftSideColor;

			public Rectangle m_rtIcon = MyForm.m_rtIcon;

			public int rightOffset = MyForm.rightOffset;

			public Color rightSideColor = MyForm.rightSideColor;

			public int RoundHeight = MyForm.RoundHeight;

			public int RoundWidth = MyForm.RoundWidth;

			public float SideBorderTimes = MyForm.SideBorderTimes;

			public float SideLineTimes = MyForm.SideLineTimes;

			public int sysBtnHeight = MyForm.sysBtnHeight;

			public int sysBtnWidth = MyForm.sysBtnWidth;

			public int topicHeight = MyForm.topicHeight;

			public Bitmap topicImage = MyForm.topicImage;

			public Color TopicTextColor = MyForm.TopicTextColor;

			public Font TopicTextFont = MyForm.TopicTextFont;

			public int TopicTextFormat = (int)MyForm.TopicTextFormat.Alignment;

			public int topOffset = MyForm.topOffset;

			public static SkinDataClass FromSkinFile(string iniFileName)
			{
				try
				{
					SkinDataClass skinDataClass = new SkinDataClass();
					string tempFileName = Path.GetTempFileName();
					DecompressFile(iniFileName, tempFileName);
					SkinDataClass skinDataClass2 = skinDataClass;
					string[] strLines = File.ReadAllLines(tempFileName, Encoding.Default);
					File.Delete(tempFileName);
					skinDataClass2.AuthorName = Convert.ToString(ToObject(Convert.FromBase64String(ReadAssf(strLines, "AuthorName"))));
					skinDataClass2.topicImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "topicImage")));
					skinDataClass2.topicHeight = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "topicHeight"))));
					skinDataClass2.TopicTextFont = (Font)ToObject(Convert.FromBase64String(ReadAssf(strLines, "TopicTextFont")));
					skinDataClass2.TopicTextFormat = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "TopicTextFormat"))));
					skinDataClass2.TopicTextColor = (Color)ToObject(Convert.FromBase64String(ReadAssf(strLines, "TopicTextColor")));
					skinDataClass2.m_rtIcon = (Rectangle)ToObject(Convert.FromBase64String(ReadAssf(strLines, "m_rtIcon")));
					skinDataClass2.sysBtnWidth = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "sysBtnWidth"))));
					skinDataClass2.sysBtnHeight = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "sysBtnHeight"))));
					skinDataClass2.btnSpeatorWidth = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnSpeatorWidth"))));
					skinDataClass2.rightOffset = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "rightOffset"))));
					skinDataClass2.topOffset = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "topOffset"))));
					try
					{
						skinDataClass2.RoundWidth = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "RoundWidth"))));
						skinDataClass2.RoundHeight = Convert.ToInt32(ToObject(Convert.FromBase64String(ReadAssf(strLines, "RoundHeight"))));
						skinDataClass2.SideBorderTimes = Convert.ToSingle(ToObject(Convert.FromBase64String(ReadAssf(strLines, "SideBorderTimes"))));
						skinDataClass2.SideLineTimes = Convert.ToSingle(ToObject(Convert.FromBase64String(ReadAssf(strLines, "SideLineTimes"))));
					}
					catch
					{
					}
					skinDataClass2.btnMinImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMinImage")));
					skinDataClass2.btnMinHoverImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMinHoverImage")));
					skinDataClass2.btnMinClickImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMinClickImage")));
					skinDataClass2.btnMaxImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMaxImage")));
					skinDataClass2.btnMaxHoverImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMaxHoverImage")));
					skinDataClass2.btnMaxClickImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnMaxClickImage")));
					skinDataClass2.btnRestoreImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnRestoreImage")));
					skinDataClass2.btnRestoreHoverImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnRestoreHoverImage")));
					skinDataClass2.btnRestoreClickImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnRestoreClickImage")));
					skinDataClass2.btnCloseImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnCloseImage")));
					skinDataClass2.btnCloseHoverImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnCloseHoverImage")));
					skinDataClass2.btnCloseClickImage = (Bitmap)ToObject(Convert.FromBase64String(ReadAssf(strLines, "btnCloseClickImage")));
					skinDataClass2.leftSideColor = (Color)ToObject(Convert.FromBase64String(ReadAssf(strLines, "leftSideColor")));
					skinDataClass2.rightSideColor = (Color)ToObject(Convert.FromBase64String(ReadAssf(strLines, "rightSideColor")));
					skinDataClass2 = null;
					return skinDataClass;
				}
				catch
				{
					return null;
				}
			}
		}

		private class FloatOutClass
		{
			public enum FloatOutStyle
			{
				水平方向,
				垂直方向
			}

			private delegate void SetPositionDelegate(int pos);

			private MyForm frmObject;

			private int beginPos;

			private int endPos;

			private FloatOutStyle style;

			private int FloatStep = 10;

			public FloatOutClass(MyForm frmObject, int beginPos, int endPos, FloatOutStyle style)
			{
				this.frmObject = frmObject;
				this.beginPos = beginPos;
				this.endPos = endPos;
				this.style = style;
			}

			public void FloatShow()
			{
				frmObject.IsFloating = true;
				Thread thread = new Thread(FloatShowThread);
				thread.Name = "拉边隐藏线程";
				thread.IsBackground = true;
				thread.Start();
			}

			public void FloatShow(int FloatStep)
			{
				this.FloatStep = FloatStep;
				FloatShow();
			}

			public void SetLeft(int pos)
			{
				try
				{
					frmObject.Invoke(new SetPositionDelegate(_SetLeft), pos);
				}
				catch
				{
				}
			}

			private void _SetLeft(int pos)
			{
				frmObject.Left = pos;
			}

			public void SetTop(int pos)
			{
				try
				{
					frmObject.Invoke(new SetPositionDelegate(_SetTop), pos);
				}
				catch
				{
				}
			}

			private void _SetTop(int pos)
			{
				frmObject.Top = pos;
			}

			private void FloatShowThread()
			{
				int millisecondsTimeout = 10;
				int num = Math.Abs(Convert.ToInt32((double)(beginPos - endPos) / (double)FloatStep));
				if (beginPos > endPos)
				{
					num = -num;
				}
				if (num == 0)
				{
					num = -1;
				}
				for (int i = 1; i <= FloatStep; i++)
				{
					switch (style)
					{
					case FloatOutStyle.水平方向:
						SetLeft(beginPos + i * num);
						break;
					case FloatOutStyle.垂直方向:
						SetTop(beginPos + i * num);
						break;
					}
					Thread.Sleep(millisecondsTimeout);
				}
				switch (style)
				{
				case FloatOutStyle.水平方向:
					SetLeft(endPos);
					break;
				case FloatOutStyle.垂直方向:
					SetTop(endPos);
					break;
				}
				frmObject.IsFloating = false;
			}
		}

		private bool _ShowWindowsBorder = false;

		private int beforeSideHeight;

		private int beforeSideWidth;

		internal static Bitmap btnCloseClickImage;

		internal static Bitmap btnCloseHoverImage;

		internal static Bitmap btnCloseImage;

		internal static Bitmap btnMaxClickImage;

		internal static Bitmap btnMaxHoverImage;

		internal static Bitmap btnMaxImage;

		internal static Bitmap btnMinClickImage;

		internal static Bitmap btnMinHoverImage;

		internal static Bitmap btnMinImage;

		internal static Bitmap btnRestoreClickImage;

		internal static Bitmap btnRestoreHoverImage;

		internal static Bitmap btnRestoreImage;

		internal static int btnSpeatorWidth;

		private bool IsMaxBefore;

		private Point LastMouesDownPostion;

		private DateTime LastMouseDownTime;

		private Size LastSize;

		internal static Color leftSideColor;

		internal static Rectangle m_rtIcon;

		private int MaxmizeLeftArg = 0;

		internal static int rightOffset;

		internal static Color rightSideColor;

		internal static int RoundHeight = 2;

		internal static int RoundWidth = 2;

		internal static float SideBorderTimes;

		internal static float SideLineTimes;

		internal static int sysBtnHeight;

		internal static int sysBtnWidth;

		internal static int topicHeight;

		internal static Bitmap topicImage;

		internal static Color TopicTextColor;

		internal static Font TopicTextFont = new Font("Arial", 9f, FontStyle.Bold);

		internal static StringFormat TopicTextFormat = new StringFormat();

		internal static int topOffset;

		private static Color _AllBackColor = Color.LightSkyBlue;

		private static string _BackLogo = "君子青竹";

		private static Bitmap BlackBackLogoImage = SharedFunction.GetBitmapResource(BackLogo);

		private static Bitmap BackLogoImage;

		private bool IsMouseDown = false;

		private Point lastMousePosition;

		private bool _IsShowBackLogo = true;

		private bool _IsShowTopic = true;

		private static Bitmap BlackbtnMinImage = SharedFunction.GetBitmapResource("btnMin");

		private static Bitmap BlackbtnMinHoverImage = SharedFunction.GetBitmapResource("btnMinHover");

		private static Bitmap BlackbtnMinClickImage = SharedFunction.GetBitmapResource("btnMinClick");

		private static Bitmap BlackbtnMaxImage = SharedFunction.GetBitmapResource("btnMax");

		private static Bitmap BlackbtnMaxHoverImage = SharedFunction.GetBitmapResource("btnMaxHover");

		private static Bitmap BlackbtnMaxClickImage = SharedFunction.GetBitmapResource("btnMaxClick");

		private static Bitmap BlackbtnRestoreImage = SharedFunction.GetBitmapResource("btnRestore");

		private static Bitmap BlackbtnRestoreHoverImage = SharedFunction.GetBitmapResource("btnRestoreHover");

		private static Bitmap BlackbtnRestoreClickImage = SharedFunction.GetBitmapResource("btnRestoreClick");

		private static Bitmap BlackbtnCloseImage = SharedFunction.GetBitmapResource("btnClose");

		private static Bitmap BlackbtnCloseHoverImage = SharedFunction.GetBitmapResource("btnCloseHover");

		private static Bitmap BlackbtnCloseClickImage = SharedFunction.GetBitmapResource("btnCloseClick");

		private bool _IsShowCationText = true;

		private bool _IsCanHiden = false;

		public bool IsFloating = false;

		public bool IsOut = true;

		private int LeftHidenTime = 0;

		private IContainer components = null;

		private System.Windows.Forms.Timer tmrHiden;

		public static Color AllBackColor
		{
			get
			{
				return _AllBackColor;
			}
			set
			{
				_AllBackColor = value;
				ReBuildSystemButton();
				RebuildBackLogo();
				RefrushAllForms();
			}
		}

		public static string BackLogo
		{
			get
			{
				return _BackLogo;
			}
			set
			{
				_BackLogo = value;
				BlackBackLogoImage = SharedFunction.GetBitmapResource(BackLogo);
				RebuildBackLogo();
				RefrushAllForms();
			}
		}

		public bool IsShowBackLogo
		{
			get
			{
				return _IsShowBackLogo;
			}
			set
			{
				_IsShowBackLogo = value;
				Invalidate();
			}
		}

		public bool IsShowTopic
		{
			get
			{
				return _IsShowTopic;
			}
			set
			{
				_IsShowTopic = value;
				Invalidate();
			}
		}

		public int ClientBottom => base.Bottom - sideHeight;

		public int ClientLeft
		{
			get
			{
				return base.Left + sideWidth;
			}
			set
			{
				base.Left = value - sideWidth;
			}
		}

		public Point ClientLocation => new Point(ClientLeft, ClientTop);

		public int ClientRight => base.Right - sideWidth;

		public int ClientTop
		{
			get
			{
				return base.Top + formTopOffset;
			}
			set
			{
				base.Top = value - sideHeight;
			}
		}

		internal Rectangle FootRectangle => new Rectangle(2, base.ClientSize.Height - 3, base.ClientSize.Width - 6 + 1, 3);

		internal int formTopOffset => base.Height - base.ClientSize.Height - sideHeight;

		internal Color leftSideBorderColor => SharedFunction.GetDeeperColor(leftSideColor, SideBorderTimes);

		internal Color leftSideLineColor => SharedFunction.GetDeeperColor(leftSideColor, SideLineTimes);

		private Rectangle m_rtBtnExit => new Rectangle(base.ClientSize.Width - (sysBtnWidth + btnSpeatorWidth) - rightOffset, topOffset + 1, sysBtnWidth, sysBtnHeight);

		private Rectangle m_rtBtnMax => new Rectangle(base.ClientSize.Width - (sysBtnWidth + btnSpeatorWidth) * 2 - rightOffset, topOffset + 1, sysBtnWidth, sysBtnHeight);

		internal Rectangle m_rtBtnMin
		{
			get
			{
				if (!base.MaximizeBox)
				{
					return m_rtBtnMax;
				}
				return new Rectangle(base.ClientSize.Width - (sysBtnWidth + btnSpeatorWidth) * 3 - rightOffset, topOffset + 1, sysBtnWidth, sysBtnHeight);
			}
		}

		internal Color rightSideBorderColor => SharedFunction.GetDeeperColor(rightSideColor, SideBorderTimes);

		internal Color rightSideLineColor => SharedFunction.GetDeeperColor(rightSideColor, SideLineTimes);

		public bool ShowWindowsBorder
		{
			get
			{
				return _ShowWindowsBorder;
			}
			set
			{
				_ShowWindowsBorder = value;
				if (_ShowWindowsBorder)
				{
					base.Region = null;
				}
				else
				{
					SetRoundRectWnd();
				}
			}
		}

		public bool IsShowCationText
		{
			get
			{
				return _IsShowCationText;
			}
			set
			{
				_IsShowCationText = value;
				Invalidate();
			}
		}

		internal int sideHeight => sideWidth;

		internal int sideWidth => (base.Width - base.ClientSize.Width) / 2;

		private Rectangle TopicCaptionRectangle
		{
			get
			{
				Rectangle result = ((!base.ShowIcon) ? new Rectangle(m_rtIcon.Left + 3, 0, TopicRectangle.Width - (m_rtIcon.Left + sideWidth + 5) - (TopicRectangle.Right - m_rtBtnMin.Left), TopicRectangle.Height) : new Rectangle(m_rtIcon.Right + 5, 0, TopicRectangle.Width - (m_rtIcon.Right + sideWidth + 5) - (TopicRectangle.Right - m_rtBtnMin.Left), TopicRectangle.Height));
				return result;
			}
		}

		internal Rectangle TopicRectangle => new Rectangle(1, 0, base.Width - 2 * sideWidth - 3 + 1, topicHeight);

		public bool IsCanHiden
		{
			get
			{
				return _IsCanHiden;
			}
			set
			{
				_IsCanHiden = value;
			}
		}

		public MyForm()
		{
			LastSize = base.Size;
			IsMaxBefore = false;
			LastMouseDownTime = DateTime.Now;
			beforeSideWidth = sideWidth;
			beforeSideHeight = sideHeight;
			LoadDefaultSkin();
			InitializeComponent();
		}

		private static void RebuildBackLogo()
		{
			Debug.Print("RebuildBackLogo()");
			if (BlackBackLogoImage != null)
			{
				BackLogoImage = SharedFunction.ChangeImageToColorImage(BlackBackLogoImage, AllBackColor);
			}
		}

		private static int ChangeColorIntDeep(int srcInt, int desInt)
		{
			srcInt = Convert.ToInt32((double)(desInt * (srcInt + 100)) / 255.0);
			if (srcInt > 255)
			{
				srcInt = 255;
			}
			return srcInt;
		}

		private static Bitmap ChangeImageColor(Bitmap srcImage, Color desColor)
		{
			return SharedFunction.ChangeImageToColorImage(srcImage, desColor);
		}

		private static bool CompressFile(string srcFileName, string desFileName)
		{
			bool result = false;
			FileStream fileStream = new FileStream(srcFileName, FileMode.Open);
			FileStream fileStream2 = new FileStream(desFileName, FileMode.OpenOrCreate, FileAccess.Write);
			fileStream2.SetLength(0L);
			GZipStream gZipStream = new GZipStream(fileStream2, CompressionMode.Compress, false);
			byte[] array = new byte[1000];
			int num = 0;
			do
			{
				num = fileStream.Read(array, 0, array.Length);
				gZipStream.Write(array, 0, num);
			}
			while (num == array.Length);
			fileStream.Close();
			gZipStream.Flush();
			gZipStream.Close();
			return result;
		}

		private static bool DecompressFile(string srcFileName, string desFileName)
		{
			bool result = false;
			FileStream fileStream = new FileStream(srcFileName, FileMode.Open);
			FileStream fileStream2 = new FileStream(desFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			fileStream2.SetLength(0L);
			GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress, false);
			byte[] array = new byte[1000];
			int num = 0;
			do
			{
				num = gZipStream.Read(array, 0, array.Length);
				fileStream2.Write(array, 0, num);
			}
			while (num == array.Length);
			fileStream.Close();
			fileStream2.Close();
			gZipStream.Close();
			return result;
		}

		public void DrawSkin(Graphics fg)
		{
			Bitmap image = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(image);
			Rectangle topicRectangle = TopicRectangle;
			Rectangle rect;
			if (topicImage == null)
			{
				rect = new Rectangle(topicRectangle.Left, topicRectangle.Top, topicRectangle.Width, topicRectangle.Height * 3 / 8 + 2);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.White, SharedFunction.GetDeeperColor(AllBackColor, 0.9f), LinearGradientMode.Vertical);
				graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
				rect = new Rectangle(topicRectangle.Left, topicRectangle.Top + topicRectangle.Height * 3 / 8 - 2, topicRectangle.Width, topicRectangle.Height * 5 / 8 + 3);
				linearGradientBrush = new LinearGradientBrush(rect, SharedFunction.GetDeeperColor(AllBackColor, 0.9f), SharedFunction.GetDeeperColor(AllBackColor, 1f), LinearGradientMode.Vertical);
				graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			}
			else
			{
				graphics.DrawImage(topicImage, topicRectangle);
			}
			rect = new Rectangle(0, topicHeight, base.ClientSize.Width / 3, 1);
			LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect, Color.FromArgb(0, Color.White), Color.FromArgb(100, Color.White), LinearGradientMode.Horizontal);
			graphics.FillRectangle(linearGradientBrush2, linearGradientBrush2.Rectangle);
			rect = new Rectangle(base.ClientSize.Width / 3, topicHeight, base.ClientSize.Width * 2 / 3, 1);
			linearGradientBrush2 = new LinearGradientBrush(rect, Color.FromArgb(100, Color.White), Color.FromArgb(0, Color.White), LinearGradientMode.Horizontal);
			graphics.FillRectangle(linearGradientBrush2, linearGradientBrush2.Rectangle);
			if (base.ShowIcon)
			{
				Rectangle rtIcon = m_rtIcon;
				graphics.DrawImage(base.Icon.ToBitmap(), rtIcon);
			}
			if (IsShowCationText)
			{
				SolidBrush brush = new SolidBrush(TopicTextColor);
				graphics.DrawString(Text, TopicTextFont, brush, TopicCaptionRectangle, TopicTextFormat);
			}
			if (topicImage == null)
			{
				Pen pen = new Pen(SharedFunction.GetDeeperColor(base.BackColor, 0.5f));
				graphics.DrawLine(pen, 0, 0, 0, base.ClientSize.Height - 1);
				graphics.DrawLine(pen, base.ClientSize.Width - 1, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);
				graphics.DrawLine(pen, 0, 0, base.ClientSize.Width - 1, 0);
				graphics.DrawLine(pen, 1, base.ClientSize.Height - 1, base.ClientSize.Width - 2, base.ClientSize.Height - 1);
				if (base.WindowState == FormWindowState.Normal)
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					pen.Width = 1.6f;
					rect = new Rectangle(0, 0, RoundWidth, RoundHeight);
					graphics.DrawArc(pen, rect, -180f, 90f);
					rect = new Rectangle(base.ClientSize.Width - RoundWidth - 1, 0, RoundWidth, RoundHeight);
					graphics.DrawArc(pen, rect, -90f, 90f);
					rect = new Rectangle(base.ClientSize.Width - RoundWidth - 1, base.ClientSize.Height - RoundHeight - 1, RoundWidth, RoundHeight);
					graphics.DrawArc(pen, rect, 0f, 90f);
					rect = new Rectangle(0, base.ClientSize.Height - RoundHeight - 1, RoundWidth, RoundHeight);
					graphics.DrawArc(pen, rect, 90f, 90f);
				}
			}
			else
			{
				Pen pen2 = new Pen(leftSideBorderColor);
				pen2.Color = leftSideBorderColor;
				graphics.DrawLine(pen2, 0, 0, 0, base.ClientSize.Height - 1);
				pen2.Color = leftSideLineColor;
				graphics.DrawLine(pen2, 1, topicHeight, 1, base.ClientSize.Height - 3);
				pen2.Color = leftSideColor;
				int num = 2;
				do
				{
					graphics.DrawLine(pen2, num, topicHeight, num, base.ClientSize.Height - 2);
					num++;
				}
				while (num <= 2);
				pen2.Color = rightSideBorderColor;
				graphics.DrawLine(pen2, base.ClientSize.Width - 1, 0, base.ClientSize.Width - 1, base.ClientSize.Height);
				pen2.Color = rightSideLineColor;
				graphics.DrawLine(pen2, base.ClientSize.Width - 2, topicHeight, base.ClientSize.Width - 2, base.ClientSize.Height - 3);
				pen2.Color = rightSideColor;
				int num2 = 2;
				do
				{
					graphics.DrawLine(pen2, base.ClientSize.Width - num2 - 1, topicHeight, base.ClientSize.Width - num2 - 1, base.ClientSize.Height - 3);
					num2++;
				}
				while (num2 <= 2);
				LinearGradientBrush brush2 = new LinearGradientBrush(FootRectangle, leftSideColor, rightSideColor, LinearGradientMode.Horizontal);
				graphics.FillRectangle(brush2, FootRectangle);
				Rectangle rect2 = new Rectangle(1, base.ClientSize.Height - 2, base.ClientSize.Width - 2, 1);
				brush2 = new LinearGradientBrush(rect2, leftSideLineColor, rightSideLineColor, LinearGradientMode.Horizontal);
				graphics.FillRectangle(brush2, rect2);
				rect2 = new Rectangle(1, base.ClientSize.Height - 1, base.ClientSize.Width - 2, 1);
				brush2 = new LinearGradientBrush(rect2, leftSideBorderColor, rightSideBorderColor, LinearGradientMode.Horizontal);
				graphics.FillRectangle(brush2, rect2);
				rect = new Rectangle(0, 0, base.ClientSize.Width, 1);
				graphics.FillRectangle(brush2, rect);
				if (base.WindowState == FormWindowState.Normal)
				{
					pen2.Color = leftSideBorderColor;
					pen2.Width = 1.6f;
					rect = new Rectangle(0, 0, RoundWidth, RoundHeight);
					graphics.DrawArc(pen2, rect, -180f, 90f);
					pen2.Color = rightSideBorderColor;
					pen2.Width = 1.6f;
					rect = new Rectangle(base.ClientSize.Width - RoundWidth - 1, 0, RoundWidth, RoundHeight);
					graphics.DrawArc(pen2, rect, -90f, 90f);
				}
			}
			if (base.Region != null)
			{
				if (base.MinimizeBox)
				{
					graphics.DrawImage(btnMinImage, m_rtBtnMin);
				}
				if (base.MaximizeBox)
				{
					if (base.WindowState == FormWindowState.Normal)
					{
						graphics.DrawImage(btnMaxImage, m_rtBtnMax);
					}
					else
					{
						graphics.DrawImage(btnRestoreImage, m_rtBtnMax);
					}
				}
				graphics.DrawImage(btnCloseImage, m_rtBtnExit);
			}
			if ((base.FormBorderStyle == FormBorderStyle.Sizable) | (base.FormBorderStyle == FormBorderStyle.SizableToolWindow))
			{
				int num3 = 12;
				int num4 = 3;
				Rectangle rectangle = new Rectangle(base.ClientSize.Width - 3 - num3, base.ClientSize.Height - 3 - num3, num3 - num4, num3 - num4);
				Pen pen3 = new Pen(SharedFunction.GetDeeperColor(base.BackColor, 0.5f), 1.5f);
				graphics.DrawLine(pen3, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Top);
				graphics.DrawLine(pen3, rectangle.Left + rectangle.Width / 3, rectangle.Bottom, rectangle.Right, rectangle.Top + rectangle.Height / 3);
				graphics.DrawLine(pen3, rectangle.Left + 2 * rectangle.Width / 3, rectangle.Bottom, rectangle.Right, rectangle.Top + 2 * rectangle.Height / 3);
			}
			fg.DrawImage(image, 0, 0);
		}

		private void InitMyForm()
		{
			if (base.StartPosition == FormStartPosition.CenterScreen)
			{
				base.Left = (Screen.PrimaryScreen.WorkingArea.Width - base.Width) / 2;
				base.Top = (Screen.PrimaryScreen.WorkingArea.Height - base.Height) / 2;
			}
		}

		public static void LoadDefaultSkin()
		{
			TopicTextFormat.LineAlignment = StringAlignment.Center;
			TopicTextFormat.Alignment = StringAlignment.Near;
			TopicTextFormat.FormatFlags = StringFormatFlags.NoWrap;
			topicImage = null;
			topicHeight = 30;
			TopicTextFont = new Font("Arial", 9f, FontStyle.Bold);
			TopicTextColor = Color.White;
			m_rtIcon = new Rectangle(5, 5, 20, 20);
			sysBtnWidth = 27;
			sysBtnHeight = 17;
			btnSpeatorWidth = 0;
			rightOffset = 7;
			topOffset = 0;
			RoundWidth = 16;
			RoundHeight = 16;
			btnMinImage = SharedFunction.GetBitmapResource("btnMin");
			btnMinHoverImage = SharedFunction.GetBitmapResource("btnMinHover");
			btnMinClickImage = SharedFunction.GetBitmapResource("btnMinClick");
			btnMaxImage = SharedFunction.GetBitmapResource("btnMax");
			btnMaxHoverImage = SharedFunction.GetBitmapResource("btnMaxHover");
			btnMaxClickImage = SharedFunction.GetBitmapResource("btnMaxClick");
			btnRestoreImage = SharedFunction.GetBitmapResource("btnRestore");
			btnRestoreHoverImage = SharedFunction.GetBitmapResource("btnRestoreHover");
			btnRestoreClickImage = SharedFunction.GetBitmapResource("btnRestoreClick");
			btnCloseImage = SharedFunction.GetBitmapResource("btnClose");
			btnCloseHoverImage = SharedFunction.GetBitmapResource("btnCloseHover");
			btnCloseClickImage = SharedFunction.GetBitmapResource("btnCloseClick");
			leftSideColor = Color.FromArgb(62, 142, 153);
			rightSideColor = Color.FromArgb(62, 142, 153);
			SideLineTimes = 1.3f;
			SideBorderTimes = 0.9f;
			ReBuildSystemButton();
		}

		public static void LoadSkin(SkinDataClass skin)
		{
			topicImage = skin.topicImage;
			topicHeight = skin.topicHeight;
			TopicTextFont = skin.TopicTextFont;
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			switch (skin.TopicTextFormat)
			{
			case 0:
				stringFormat.Alignment = StringAlignment.Near;
				break;
			case 1:
				stringFormat.Alignment = StringAlignment.Center;
				break;
			case 2:
				stringFormat.Alignment = StringAlignment.Far;
				break;
			}
			TopicTextFormat = stringFormat;
			TopicTextColor = skin.TopicTextColor;
			m_rtIcon = skin.m_rtIcon;
			sysBtnWidth = skin.sysBtnWidth;
			sysBtnHeight = skin.sysBtnHeight;
			btnSpeatorWidth = skin.btnSpeatorWidth;
			rightOffset = skin.rightOffset;
			topOffset = skin.topOffset;
			RoundWidth = skin.RoundWidth;
			RoundHeight = skin.RoundHeight;
			btnMinImage = skin.btnMinImage;
			btnMinHoverImage = skin.btnMinHoverImage;
			btnMinClickImage = skin.btnMinClickImage;
			btnMaxImage = skin.btnMaxImage;
			btnMaxHoverImage = skin.btnMaxHoverImage;
			btnMaxClickImage = skin.btnMaxClickImage;
			btnRestoreImage = skin.btnRestoreImage;
			btnRestoreHoverImage = skin.btnRestoreHoverImage;
			btnRestoreClickImage = skin.btnRestoreClickImage;
			btnCloseImage = skin.btnCloseImage;
			btnCloseHoverImage = skin.btnCloseHoverImage;
			btnCloseClickImage = skin.btnCloseClickImage;
			leftSideColor = skin.leftSideColor;
			rightSideColor = skin.rightSideColor;
			SideLineTimes = skin.SideLineTimes;
			SideBorderTimes = skin.SideBorderTimes;
		}

		public static bool LoadSkinFromFile(string fileName)
		{
			try
			{
				SkinDataClass skinDataClass = SkinDataClass.FromSkinFile(fileName);
				if (skinDataClass == null)
				{
					throw new NullReferenceException("皮肤文件非法.");
				}
				LoadSkin(skinDataClass);
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			InitMyForm();
			base.OnLoad(e);
			base.DoubleBuffered = true;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			IsMouseDown = false;
			base.Cursor = Cursors.Default;
			Invalidate(m_rtBtnMin);
			Invalidate(m_rtBtnMax);
			Invalidate(m_rtBtnExit);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (BackLogoImage != null && IsShowBackLogo)
			{
				graphics.DrawImage(BackLogoImage, base.ClientSize.Width - BackLogoImage.Width, topicHeight);
				graphics.DrawImage(BackLogoImage, base.ClientSize.Width - BackLogoImage.Width * 3 / 4, base.ClientSize.Height - BackLogoImage.Height);
			}
			if (IsShowTopic)
			{
				DrawSkin(graphics);
			}
			base.OnPaint(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (base.WindowState == FormWindowState.Normal && base.ClientSize.Height < topicHeight)
			{
				base.ClientSize = new Size(base.ClientSize.Width, topicHeight);
				return;
			}
			if (base.WindowState == FormWindowState.Maximized)
			{
				IsMaxBefore = true;
				int value = UnsafeNativeMethods.GetWindowLong(base.Handle, -16) & -12582913;
				UnsafeNativeMethods.SetWindowLong(nNewLong: new IntPtr(value), hWnd: base.Handle, nIndex: -16);
			}
			else if (IsMaxBefore)
			{
				IsMaxBefore = false;
				base.ControlBox = true;
				base.Width -= 2;
				base.Height -= formTopOffset - sideHeight + 2;
			}
			if (base.MaximizedBounds != Screen.PrimaryScreen.WorkingArea)
			{
				base.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
			}
			if ((base.WindowState == FormWindowState.Maximized) | (base.WindowState == FormWindowState.Minimized))
			{
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				base.Region = new Region(rect);
				MaxmizeLeftArg = 1;
			}
			else
			{
				if (MaxmizeLeftArg == 0)
				{
					LastSize = base.Size;
				}
				if (!ShowWindowsBorder)
				{
					SetRoundRectWnd();
				}
			}
			Invalidate();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Invalidate(TopicCaptionRectangle);
		}

		private bool PointInRect(Point pt, Rectangle rect)
		{
			return (pt.X >= rect.Left) & (pt.X < rect.Right) & (pt.Y >= rect.Top) & (pt.Y < rect.Bottom);
		}

		private void PopupSysMenu(Point pt)
		{
			UnsafeNativeMethods.ReleaseCapture();
			IntPtr systemMenu = UnsafeNativeMethods.GetSystemMenu(base.Handle, false);
			UnsafeNativeMethods.EnableMenuItem(systemMenu, 1, 1025);
			UnsafeNativeMethods.EnableMenuItem(systemMenu, 2, 1025);
			UnsafeNativeMethods.TrackPopupMenu(systemMenu, 2u, pt.X, pt.Y, 0, base.Handle, IntPtr.Zero);
		}

		internal static string ReadAssf(string[] strLines, string strKeyName)
		{
			string empty = string.Empty;
			int num = strLines.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = strLines[i].Trim();
				if (text.StartsWith(strKeyName + "="))
				{
					return text.Substring(strKeyName.Length + 1);
				}
			}
			return empty;
		}

		public static void ReBuildSystemButton()
		{
			Debug.Print("RebuildSystemButton()");
			if (topicImage == null)
			{
				Color allBackColor = AllBackColor;
				btnMinImage = ChangeImageColor(BlackbtnMinImage, allBackColor);
				btnMinHoverImage = ChangeImageColor(BlackbtnMinHoverImage, allBackColor);
				btnMinClickImage = ChangeImageColor(BlackbtnMinClickImage, allBackColor);
				btnMaxImage = ChangeImageColor(BlackbtnMaxImage, allBackColor);
				btnMaxHoverImage = ChangeImageColor(BlackbtnMaxHoverImage, allBackColor);
				btnMaxClickImage = ChangeImageColor(BlackbtnMaxClickImage, allBackColor);
				btnRestoreImage = ChangeImageColor(BlackbtnRestoreImage, allBackColor);
				btnRestoreHoverImage = ChangeImageColor(BlackbtnRestoreHoverImage, allBackColor);
				btnRestoreClickImage = ChangeImageColor(BlackbtnRestoreClickImage, allBackColor);
				btnCloseImage = ChangeImageColor(BlackbtnCloseImage, allBackColor);
				btnCloseHoverImage = ChangeImageColor(BlackbtnCloseHoverImage, Color.Red);
				btnCloseClickImage = ChangeImageColor(BlackbtnCloseClickImage, Color.Red);
			}
		}

		public static void RefrushAllForms()
		{
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is MyForm)
				{
					if (openForm.BackColor != AllBackColor)
					{
						openForm.BackColor = AllBackColor;
					}
					openForm.Invalidate();
				}
			}
		}

		private void SetRoundRectWnd()
		{
			Region roundRectWnd = GetRoundRectWnd();
			Point location = base.Location;
			base.Region = roundRectWnd;
			if (base.Location != location)
			{
				base.Location = location;
			}
		}

		internal Region GetRoundRectWnd()
		{
			return SharedFunction.CreateRoundRectRgn(sideWidth, formTopOffset, base.ClientSize.Width + sideWidth + 1, base.Height - sideWidth + 1, RoundWidth, RoundHeight);
		}

		public static byte[] ToBytes(object infoObj)
		{
			return ToStream(RuntimeHelpers.GetObjectValue(infoObj)).GetBuffer();
		}

		public static object ToObject(Stream @out)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			object objectValue;
			try
			{
				@out.Position = 0L;
				objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(@out));
			}
			catch
			{
				return null;
			}
			return objectValue;
		}

		public static object ToObject(byte[] newBytes)
		{
			if (newBytes.Length == 0)
			{
				throw new FormatException();
			}
			MemoryStream @out = new MemoryStream(newBytes);
			return ToObject(@out);
		}

		public static MemoryStream ToStream(object infoObj)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			try
			{
				binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(infoObj));
				memoryStream.Position = 0L;
			}
			catch
			{
				return null;
			}
			return memoryStream;
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 273 && m.LParam == IntPtr.Zero)
			{
				int num = m.WParam.ToInt32();
				switch (num)
				{
				case 61536:
					Close();
					break;
				case 61488:
					base.WindowState = FormWindowState.Maximized;
					break;
				case 61472:
					base.WindowState = FormWindowState.Minimized;
					break;
				}
				if (num == 61728)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			base.WndProc(ref m);
		}

		private void MyForm_MouseEnter(object sender, EventArgs e)
		{
			WhenMouseEnter();
		}

		private void MyForm_MouseLeave(object sender, EventArgs e)
		{
			WhenMouseLevae(10);
		}

		public void WhenMouseEnter()
		{
			tmrHiden.Enabled = false;
			if (!IsFloating)
			{
				FloatOutClass floatOutClass = null;
				if (base.Left < -sideWidth)
				{
					floatOutClass = new FloatOutClass(this, base.Left, -sideWidth, FloatOutClass.FloatOutStyle.水平方向);
				}
				else if (base.Left > Screen.PrimaryScreen.Bounds.Width - (base.Width - sideWidth))
				{
					floatOutClass = new FloatOutClass(this, base.Left, Screen.PrimaryScreen.Bounds.Width - (base.Width - sideWidth), FloatOutClass.FloatOutStyle.水平方向);
				}
				else if (base.Top < -topicHeight)
				{
					floatOutClass = new FloatOutClass(this, base.Top, -topicHeight, FloatOutClass.FloatOutStyle.垂直方向);
				}
				if (floatOutClass != null)
				{
					floatOutClass.FloatShow();
					IsOut = true;
					base.TopMost = false;
				}
			}
		}

		private void WhenMouseLevae(int hidenTime)
		{
			if (IsCanHiden)
			{
				LeftHidenTime = hidenTime;
				tmrHiden.Enabled = true;
			}
		}

		private void tmrHiden_Tick(object sender, EventArgs e)
		{
			if (LeftHidenTime <= 0)
			{
				if (IsOut & !IsFloating)
				{
					FloatOutClass floatOutClass = null;
					if (base.Left == -sideWidth)
					{
						floatOutClass = new FloatOutClass(this, base.Left, 3 - (base.Width - sideWidth), FloatOutClass.FloatOutStyle.水平方向);
					}
					else if (base.Left == Screen.PrimaryScreen.Bounds.Width - (base.Width - sideWidth))
					{
						floatOutClass = new FloatOutClass(this, base.Left, Screen.PrimaryScreen.Bounds.Width - 3 - sideWidth, FloatOutClass.FloatOutStyle.水平方向);
					}
					else if (base.Top == -topicHeight)
					{
						floatOutClass = new FloatOutClass(this, base.Top, 3 - (base.Height - sideHeight), FloatOutClass.FloatOutStyle.垂直方向);
					}
					if (floatOutClass != null)
					{
						floatOutClass.FloatShow();
						IsOut = false;
						base.TopMost = true;
					}
				}
				tmrHiden.Enabled = false;
			}
			else
			{
				LeftHidenTime--;
			}
		}

		private void MyForm_Load(object sender, EventArgs e)
		{
			if (IsCanHiden)
			{
				AddControlsHideEvent(this);
			}
			AddControlsMoveEvent(this);
		}

		private void AddControlsHideEvent(Control crl)
		{
			crl.MouseEnter += MyForm_MouseEnter;
			crl.MouseLeave += MyForm_MouseLeave;
			foreach (Control control in crl.Controls)
			{
				AddControlsHideEvent(control);
			}
		}

		private void AddControlsMoveEvent(Control crl)
		{
			foreach (Control control in crl.Controls)
			{
				if (control is Label)
				{
					control.MouseDown += MyForm_MouseDown;
					control.MouseMove += MyForm_MouseMove;
					control.MouseUp += MyForm_MouseUp;
				}
				AddControlsMoveEvent(control);
			}
		}

		private void MyForm_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				IsMouseDown = true;
				Point pt = PointToClient(Control.MousePosition);
				if ((base.Region != null) & (base.WindowState == FormWindowState.Normal) & ((base.FormBorderStyle == FormBorderStyle.Sizable) | (base.FormBorderStyle == FormBorderStyle.SizableToolWindow)))
				{
					bool flag = true;
					IsMouseDown = false;
					Rectangle rect = new Rectangle(3, 0, base.Width - 2 * (sideWidth + 1) - 3 - 1, 1);
					if (PointInRect(pt, rect))
					{
						UnsafeNativeMethods.ReleaseCapture();
						UnsafeNativeMethods.SendMessage(base.Handle, 274, 61443L, 0L);
					}
					else
					{
						rect = new Rectangle(0, 1, 3, base.Height - formTopOffset - sideHeight - 3 - 1);
						if (PointInRect(pt, rect))
						{
							UnsafeNativeMethods.ReleaseCapture();
							UnsafeNativeMethods.SendMessage(base.Handle, 274, 61441L, 0L);
						}
						else
						{
							rect = new Rectangle(base.ClientSize.Width - 3, 1, 3, base.Height - formTopOffset - sideHeight - 3 - 1);
							if (PointInRect(pt, rect))
							{
								UnsafeNativeMethods.ReleaseCapture();
								UnsafeNativeMethods.SendMessage(base.Handle, 274, 61442L, 0L);
							}
							else
							{
								rect = new Rectangle(3, base.ClientSize.Height - 3, base.Width - 2 * (sideWidth + 1) - 3 - 1, 3);
								if (PointInRect(pt, rect))
								{
									UnsafeNativeMethods.ReleaseCapture();
									UnsafeNativeMethods.SendMessage(base.Handle, 274, 61446L, 0L);
								}
								else
								{
									rect = new Rectangle(0, 0, 3, 1);
									if (PointInRect(pt, rect))
									{
										UnsafeNativeMethods.ReleaseCapture();
										UnsafeNativeMethods.SendMessage(base.Handle, 274, 61444L, 0L);
									}
									else
									{
										rect = new Rectangle(base.ClientSize.Width - 3, 0, 3, 1);
										if (PointInRect(pt, rect))
										{
											UnsafeNativeMethods.ReleaseCapture();
											UnsafeNativeMethods.SendMessage(base.Handle, 274, 61445L, 0L);
										}
										else
										{
											rect = new Rectangle(0, base.ClientSize.Height - 3, 3, 3);
											if (PointInRect(pt, rect))
											{
												UnsafeNativeMethods.ReleaseCapture();
												UnsafeNativeMethods.SendMessage(base.Handle, 274, 61447L, 0L);
											}
											else
											{
												rect = new Rectangle(base.ClientSize.Width - 3, base.ClientSize.Height - 3, 3, 3);
												if (PointInRect(pt, rect))
												{
													UnsafeNativeMethods.ReleaseCapture();
													UnsafeNativeMethods.SendMessage(base.Handle, 274, 61448L, 0L);
												}
												else
												{
													rect = new Rectangle(base.ClientSize.Width - 3 - 12, base.ClientSize.Height - 3 - 12, 12, 12);
													if (((base.FormBorderStyle == FormBorderStyle.Sizable) | (base.FormBorderStyle == FormBorderStyle.SizableToolWindow)) & PointInRect(pt, rect))
													{
														UnsafeNativeMethods.ReleaseCapture();
														UnsafeNativeMethods.SendMessage(base.Handle, 274, 61448L, 0L);
													}
													else
													{
														base.Cursor = Cursors.Default;
														flag = false;
														IsMouseDown = true;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (flag)
					{
						return;
					}
				}
				else
				{
					base.Cursor = Cursors.Default;
				}
				switch (e.Button)
				{
				case MouseButtons.Left:
				{
					TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 500);
					if ((DateTime.Now - LastMouseDownTime <= timeSpan) & (e.Location == LastMouesDownPostion) & (base.FormBorderStyle == FormBorderStyle.Sizable))
					{
						if (base.MaximizeBox)
						{
							if (base.WindowState == FormWindowState.Normal)
							{
								base.WindowState = FormWindowState.Maximized;
							}
							else
							{
								base.WindowState = FormWindowState.Normal;
							}
						}
					}
					else
					{
						if ((base.WindowState == FormWindowState.Normal) & !PointInRect(pt, m_rtBtnMin) & !PointInRect(pt, m_rtBtnMax) & !PointInRect(pt, m_rtBtnExit))
						{
						}
						LastMouseDownTime = DateTime.Now;
						LastMouesDownPostion = e.Location;
					}
					break;
				}
				case MouseButtons.Right:
					if (PointInRect(pt, TopicRectangle) & !PointInRect(pt, m_rtBtnMin) & !PointInRect(pt, m_rtBtnMax) & !PointInRect(pt, m_rtBtnExit))
					{
						PopupSysMenu(PointToScreen(e.Location));
					}
					break;
				}
				if ((base.Region != null) & (e.Button == MouseButtons.Left))
				{
					pt = PointToClient(Control.MousePosition);
					Graphics graphics = CreateGraphics();
					if (base.MinimizeBox)
					{
						if (PointInRect(pt, m_rtBtnMin))
						{
							graphics.DrawImage(btnMinClickImage, m_rtBtnMin);
						}
						else
						{
							graphics.DrawImage(btnMinImage, m_rtBtnMin);
						}
					}
					if (base.MaximizeBox)
					{
						if (PointInRect(pt, m_rtBtnMax))
						{
							if (base.WindowState == FormWindowState.Normal)
							{
								graphics.DrawImage(btnMaxClickImage, m_rtBtnMax);
							}
							else
							{
								graphics.DrawImage(btnRestoreClickImage, m_rtBtnMax);
							}
						}
						else if (base.WindowState == FormWindowState.Normal)
						{
							graphics.DrawImage(btnMaxImage, m_rtBtnMax);
						}
						else
						{
							graphics.DrawImage(btnRestoreImage, m_rtBtnMax);
						}
					}
					if (PointInRect(pt, m_rtBtnExit))
					{
						graphics.DrawImage(btnCloseClickImage, m_rtBtnExit);
					}
					else
					{
						graphics.DrawImage(btnCloseImage, m_rtBtnExit);
					}
					if (PointInRect(pt, m_rtIcon))
					{
						Point p = new Point(TopicRectangle.Left, topicHeight);
						PopupSysMenu(PointToScreen(p));
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print("Error From MyFrom.OnMouseDown.原因:" + ex.Message);
			}
			lastMousePosition = e.Location;
		}

		private void MyForm_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			if (!IsShowTopic)
			{
				return;
			}
			if (IsMouseDown)
			{
				Point pt = lastMousePosition;
				if (!PointInRect(location, m_rtBtnMin) && !PointInRect(location, m_rtBtnMax) && !PointInRect(location, m_rtBtnExit) && !PointInRect(pt, m_rtBtnMin) && !PointInRect(pt, m_rtBtnMax) && !PointInRect(pt, m_rtBtnExit))
				{
					Point location2 = default(Point);
					location2.X = base.Left + e.X - lastMousePosition.X;
					location2.Y = base.Top + e.Y - lastMousePosition.Y;
					base.Location = location2;
				}
			}
			if (base.Region != null)
			{
				Graphics graphics = CreateGraphics();
				if (base.MinimizeBox)
				{
					if (PointInRect(location, m_rtBtnMin))
					{
						graphics.DrawImage(btnMinHoverImage, m_rtBtnMin);
					}
					else
					{
						graphics.DrawImage(btnMinImage, m_rtBtnMin);
					}
				}
				if (base.MaximizeBox)
				{
					if (PointInRect(location, m_rtBtnMax))
					{
						if (base.WindowState == FormWindowState.Normal)
						{
							graphics.DrawImage(btnMaxHoverImage, m_rtBtnMax);
						}
						else
						{
							graphics.DrawImage(btnRestoreHoverImage, m_rtBtnMax);
						}
					}
					else if (base.WindowState == FormWindowState.Normal)
					{
						graphics.DrawImage(btnMaxImage, m_rtBtnMax);
					}
					else
					{
						graphics.DrawImage(btnRestoreImage, m_rtBtnMax);
					}
				}
				if (PointInRect(location, m_rtBtnExit))
				{
					graphics.DrawImage(btnCloseHoverImage, m_rtBtnExit);
				}
				else
				{
					graphics.DrawImage(btnCloseImage, m_rtBtnExit);
				}
				if (!((base.WindowState == FormWindowState.Normal) & ((base.FormBorderStyle == FormBorderStyle.Sizable) | (base.FormBorderStyle == FormBorderStyle.SizableToolWindow))))
				{
					return;
				}
				Rectangle rect = new Rectangle(3, 0, base.Width - 2 * (sideWidth + 1) - 3 - 1, 1);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNS;
					return;
				}
				rect = new Rectangle(0, 1, 3, base.Height - formTopOffset - sideHeight - 3 - 1);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeWE;
					return;
				}
				rect = new Rectangle(base.ClientSize.Width - 3, 1, 3, base.Height - formTopOffset - sideHeight - 3 - 1);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeWE;
					return;
				}
				rect = new Rectangle(3, base.ClientSize.Height - 3, base.Width - 2 * (sideWidth + 1) - 3 - 1, 3);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNS;
					return;
				}
				rect = new Rectangle(0, 0, 3, 1);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNWSE;
					return;
				}
				rect = new Rectangle(base.ClientSize.Width - 3, 0, 3, 1);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNESW;
					return;
				}
				rect = new Rectangle(0, base.ClientSize.Height - 3, 3, 3);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNESW;
					return;
				}
				rect = new Rectangle(base.ClientSize.Width - 3, base.ClientSize.Height - 3, 3, 3);
				if (PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNWSE;
					return;
				}
				rect = new Rectangle(base.ClientSize.Width - 3 - 12, base.ClientSize.Height - 3 - 12, 12, 12);
				if (((base.FormBorderStyle == FormBorderStyle.Sizable) | (base.FormBorderStyle == FormBorderStyle.SizableToolWindow)) & PointInRect(location, rect))
				{
					base.Cursor = Cursors.SizeNWSE;
				}
				else
				{
					base.Cursor = Cursors.Default;
				}
			}
			else
			{
				base.Cursor = Cursors.Default;
			}
		}

		private void MyForm_MouseUp(object sender, MouseEventArgs e)
		{
			IsMouseDown = false;
			if ((base.Region != null) & (e.Button == MouseButtons.Left))
			{
				Point pt = PointToClient(Control.MousePosition);
				if (base.MinimizeBox && PointInRect(pt, m_rtBtnMin))
				{
					base.WindowState = FormWindowState.Minimized;
				}
				else if (base.MaximizeBox && PointInRect(pt, m_rtBtnMax))
				{
					if (base.WindowState == FormWindowState.Normal)
					{
						base.WindowState = FormWindowState.Maximized;
					}
					else
					{
						base.WindowState = FormWindowState.Normal;
					}
				}
				else if (PointInRect(pt, m_rtBtnExit))
				{
					Close();
				}
			}
			if (IsCanHiden)
			{
				WhenMouseEnter();
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
			this.components = new System.ComponentModel.Container();
			this.tmrHiden = new System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.tmrHiden.Interval = 10;
			this.tmrHiden.Tick += new System.EventHandler(tmrHiden_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(290, 264);
			base.Name = "MyForm";
			base.Load += new System.EventHandler(MyForm_Load);
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(MyForm_MouseUp);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(MyForm_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(MyForm_MouseMove);
			base.ResumeLayout(false);
		}
	}
}
