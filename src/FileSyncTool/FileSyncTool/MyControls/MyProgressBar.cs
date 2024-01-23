using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace FileSyncTool.MyControls
{
	public class MyProgressBar : Control
	{
		private const int RoundRectWidth = 4;

		private Bitmap _LightImage = new Bitmap(40, 20);

		private int _Maximum = 100;

		private int _Minimum = 0;

		private Color _ProgressColor = Color.DarkTurquoise;

		private Image _ProgressImage;

		private bool _ShowLight = true;

		private bool _ShowProgressImage = false;

		private bool _ShowProgressText = false;

		private int _Value = 0;

		private int pixelPosition;

		private IContainer components = null;

		private int LightWidth => base.Height * 2;

		public int Maximum
		{
			get
			{
				return _Maximum;
			}
			set
			{
				if (value <= Minimum)
				{
					throw new Exception("Maximum的值应大于Minimum.");
				}
				_Maximum = value;
				Invalidate();
			}
		}

		public int Minimum
		{
			get
			{
				return _Minimum;
			}
			set
			{
				if (value >= Maximum)
				{
					throw new Exception("Minimum的值应小于Maximum.");
				}
				_Minimum = value;
				Invalidate();
			}
		}

		public Color ProgressColor
		{
			get
			{
				return _ProgressColor;
			}
			set
			{
				_ProgressColor = value;
				RefrushMyProgressBar();
			}
		}

		public Image ProgressImage
		{
			get
			{
				return _ProgressImage;
			}
			set
			{
				_ProgressImage = value;
				Invalidate();
			}
		}

		public bool ShowLight
		{
			get
			{
				return _ShowLight;
			}
			set
			{
				_ShowLight = value;
				RefrushMyProgressBar();
			}
		}

		public bool ShowProgressImage
		{
			get
			{
				return _ShowProgressImage;
			}
			set
			{
				if (ProgressImage != null)
				{
					_ShowProgressImage = value;
					Invalidate();
				}
			}
		}

		public bool ShowProgressText
		{
			get
			{
				return _ShowProgressText;
			}
			set
			{
				_ShowProgressText = value;
				RefrushMyProgressBar();
			}
		}

		public int Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (!((value >= Minimum) & (value <= Maximum)))
				{
					throw new Exception("Value的值应介于Maximum与Minimum之间.");
				}
				bool flag = _Value == value;
				_Value = value;
				if (!flag)
				{
					RefrushMyProgressBar();
				}
			}
		}

		public MyProgressBar()
		{
			pixelPosition = -LightWidth;
			InitializeComponent();
			Rectangle rect = new Rectangle(0, 0, _LightImage.Width / 2, _LightImage.Height);
			Rectangle rect2 = new Rectangle(_LightImage.Width / 2, 0, _LightImage.Width / 2, _LightImage.Height);
			Graphics graphics = Graphics.FromImage(_LightImage);
			LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(0, 255, 255, 255), Color.FromArgb(150, 255, 255, 255), LinearGradientMode.Horizontal);
			graphics.FillRectangle(brush, rect);
			brush = new LinearGradientBrush(rect2, Color.FromArgb(150, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.Horizontal);
			graphics.FillRectangle(brush, rect2);
			new Thread(newTmr_Tick).Start();
		}

		private void newTmr_Tick()
		{
			while (base.Created)
			{
				RefrushMyProgressBar();
				int num = Convert.ToInt32((double)(Value * (base.Width - 2)) / (double)Maximum);
				pixelPosition += 5;
				if (pixelPosition - LightWidth >= num)
				{
					pixelPosition = -LightWidth;
					RefrushMyProgressBar();
					Thread.Sleep(1000);
				}
				Thread.Sleep(20);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			Region region = SharedFunction.CreateRoundRectRgn(0, 0, base.Width, base.Height, 4, 4);
			base.Region = region;
			RefrushMyProgressBar();
		}

		private void RefrushMyProgressBar()
		{
			Rectangle rc = new Rectangle(base.Width / 2, base.Height / 2, 1, 1);
			Invalidate(rc);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg != 15 || !((base.Width > 3) & (base.Height > 2)))
			{
				return;
			}
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			SolidBrush solidBrush = new SolidBrush(ForeColor);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			Rectangle rectangle = new Rectangle(1, 1, base.Width - 2, base.Height - 2);
			graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
			rectangle.Width = Convert.ToInt32((double)(Value * (base.Width - 2)) / (double)Maximum);
			if (ShowProgressImage)
			{
				graphics.DrawImage(ProgressImage, rectangle);
			}
			else
			{
				Rectangle rect = new Rectangle(1, 1, rectangle.Width, Convert.ToInt32((double)rectangle.Height / 4.0) + 1);
				Rectangle rect2 = new Rectangle(1, Convert.ToInt32((double)rectangle.Height / 4.0), rectangle.Width, Convert.ToInt32((double)(rectangle.Height * 3) / 4.0) + 1);
				if (rect2.Top + rect2.Height != base.Height - 2)
				{
					rect2.Height += base.Height - 1 - rect2.Top - rect2.Height;
				}
				Point point = new Point(rect.Left, rect.Top);
				Point point2 = new Point(rect.Left, rect.Top + rect.Height);
				LinearGradientBrush brush = new LinearGradientBrush(point, point2, SharedFunction.GetDeeperColor(ProgressColor, 2f), SharedFunction.GetDeeperColor(ProgressColor, 0.9f));
				graphics.FillRectangle(brush, rect);
				point2 = new Point(rect2.Left, rect2.Top - 1);
				point = new Point(rect2.Left, rect2.Top + rect2.Height);
				brush = new LinearGradientBrush(point2, point, SharedFunction.GetDeeperColor(ProgressColor, 0.8f), ProgressColor);
				graphics.FillRectangle(brush, rect2);
				rect.X = rect.Width + 1;
				rect.Width = base.Width - 2 - rect.Width;
				rect2.X = rect.X;
				rect2.Width = rect.Width;
				point2 = new Point(rect.Left, rect.Top);
				point = new Point(rect.Left, rect.Top + rect.Height);
				brush = new LinearGradientBrush(point2, point, Color.White, Color.WhiteSmoke);
				graphics.FillRectangle(brush, rect);
				point2 = new Point(rect2.Left, rect2.Top - 1);
				point = new Point(rect2.Left, rect2.Top + rect2.Height);
				brush = new LinearGradientBrush(point2, point, SharedFunction.GetDeeperColor(Color.LightGray, 1f), SharedFunction.GetDeeperColor(Color.LightGray, 1.2f));
				graphics.FillRectangle(brush, rect2);
				brush.Dispose();
			}
			if (ShowLight)
			{
				rectangle.X = pixelPosition - LightWidth;
				if (rectangle.X + LightWidth > rectangle.Width)
				{
					rectangle.Width -= rectangle.X;
				}
				else
				{
					rectangle.Width = LightWidth;
				}
				Bitmap bitmap2 = new Bitmap(_LightImage, LightWidth, rectangle.Height);
				graphics.DrawImage(srcRect: new Rectangle(0, 0, rectangle.Width, rectangle.Height), image: bitmap2, destRect: rectangle, srcUnit: GraphicsUnit.Pixel);
				bitmap2.Dispose();
			}
			if (ShowProgressText)
			{
				double num = (double)(Value * 100) / (double)Maximum;
				graphics.DrawString(layoutRectangle: new Rectangle(0, 0, base.Width, base.Height), s: num.ToString("N0") + "%", font: Font, brush: solidBrush, format: stringFormat);
			}
			graphics.DrawRectangle(rect: new Rectangle(0, 0, base.Width - 2, base.Height - 2), pen: Pens.DarkGray);
			Pen pen = new Pen(Color.DarkGray, 1f);
			graphics.DrawArc(pen, -1, 0, 8, 8, -180, 90);
			graphics.DrawArc(pen, base.Width - 8 - 1, 0, 8, 8, -90, 90);
			graphics.DrawArc(pen, base.Width - 8 - 2, base.Height - 8 - 1, 8, 8, 0, 90);
			graphics.DrawArc(pen, 0, base.Height - 8 - 1, 8, 8, 90, 90);
			CreateGraphics().DrawImage(bitmap, 0, 0);
			bitmap.Dispose();
			solidBrush.Dispose();
			pen.Dispose();
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
			base.SuspendLayout();
			this.BackColor = System.Drawing.Color.White;
			this.DoubleBuffered = true;
			base.Name = "MyProgressBar";
			System.Drawing.Size size = new System.Drawing.Size(136, 30);
			base.Size = size;
			base.ResumeLayout(false);
		}
	}
}
