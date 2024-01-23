using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FileSyncTool.MyControls
{
	public class MyButton : Button
	{
		private float _ImageLeftPosition = 0.1f;

		private Bitmap _LightImage = new Bitmap(40, 20);

		private int _RoundRectWidth = 2;

		private StringAlignment _TextAlign = StringAlignment.Center;

		private int _BorderWidth = 1;

		private bool IsMouseDown = false;

		private bool IsMouseOn = false;

		private IContainer components = null;

		public float ImageLeftPosition
		{
			get
			{
				return _ImageLeftPosition;
			}
			set
			{
				if (value > 0f)
				{
					_ImageLeftPosition = value;
					RefrushMyButton();
				}
			}
		}

		private Rectangle ImageRectangle
		{
			get
			{
				int num = ((!(ImageLeftPosition < 1f)) ? Convert.ToInt32(ImageLeftPosition) : Convert.ToInt32((float)base.Width * ImageLeftPosition));
				return new Rectangle(num, (base.Height - base.Image.Height) / 2, base.Image.Width, base.Image.Height);
			}
		}

		private int LightWidth => Convert.ToInt32((double)(base.Width * 3) / 4.0);

		public int RoundRectWidth
		{
			get
			{
				return _RoundRectWidth;
			}
			set
			{
				if (value > 0)
				{
					_RoundRectWidth = value;
					SetNewRegion();
					RefrushMyButton();
				}
			}
		}

		public new StringAlignment TextAlign
		{
			get
			{
				return _TextAlign;
			}
			set
			{
				_TextAlign = value;
				RefrushMyButton();
			}
		}

		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				if (value > 0)
				{
					_BorderWidth = value;
					RefrushMyButton();
				}
			}
		}

		private void SetNewRegion()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			Region region = SharedFunction.CreateRoundRectRgn(0, 0, base.Width, base.Height, RoundRectWidth, RoundRectWidth);
			base.Region = region;
			RefrushMyButton();
		}

		private void RefrushMyButton()
		{
			Rectangle rc = new Rectangle(0, 0, base.Width, base.Height);
			Invalidate(rc);
		}

		public MyButton()
		{
			InitializeComponent();
			Rectangle rect = new Rectangle(0, 0, _LightImage.Width / 2, _LightImage.Height);
			Rectangle rect2 = new Rectangle(_LightImage.Width / 2, 0, _LightImage.Width / 2, _LightImage.Height);
			Graphics graphics = Graphics.FromImage(_LightImage);
			LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(0, 255, 255, 255), Color.FromArgb(150, 255, 255, 255), LinearGradientMode.Horizontal);
			graphics.FillRectangle(brush, rect);
			brush = new LinearGradientBrush(rect2, Color.FromArgb(150, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.Horizontal);
			graphics.FillRectangle(brush, rect2);
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			base.BackColor = base.Parent.BackColor;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (mevent.Button == MouseButtons.Left)
			{
				IsMouseDown = true;
				RefrushMyButton();
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			IsMouseDown = false;
			RefrushMyButton();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			IsMouseOn = true;
			RefrushMyButton();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			IsMouseOn = false;
			RefrushMyButton();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics graphics = pe.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillRectangle(Brushes.Green, new Rectangle(0, 0, base.Width, base.Height));
			DrawRectButton(graphics);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = TextAlign;
			stringFormat.LineAlignment = StringAlignment.Center;
			Rectangle clientRectangle = base.ClientRectangle;
			if (base.Image != null)
			{
				clientRectangle.X += ImageRectangle.Right;
				clientRectangle.Width -= ImageRectangle.Right;
			}
			SolidBrush solidBrush = new SolidBrush(base.ForeColor);
			if (!base.Enabled)
			{
				solidBrush.Color = Color.LightGray;
			}
			graphics.DrawString(Text.Replace("&", ""), Font, solidBrush, clientRectangle, stringFormat);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			SetNewRegion();
		}

		private void DrawRectButton(Graphics graphics)
		{
			float deep = 2f;
			float deep2 = 0.9f;
			float deep3 = 0.8f;
			float deep4 = 1f;
			if (IsMouseOn)
			{
				deep2 = 0.8f;
				deep3 = 0.7f;
				deep4 = 0.9f;
			}
			if (IsMouseDown)
			{
				deep2 = 0.7f;
				deep3 = 0.6f;
				deep4 = 0.8f;
			}
			Rectangle rect = new Rectangle(0, 0, base.Width, Convert.ToInt32((double)base.Height / 3.0) + 1);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, SharedFunction.GetDeeperColor(BackColor, deep), SharedFunction.GetDeeperColor(BackColor, deep2), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			rect = new Rectangle(0, Convert.ToInt32((double)base.Height / 3.0), base.Width, base.Height - Convert.ToInt32((double)base.Height / 3.0));
			linearGradientBrush = new LinearGradientBrush(rect, SharedFunction.GetDeeperColor(BackColor, deep3), SharedFunction.GetDeeperColor(BackColor, deep4), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			linearGradientBrush.Dispose();
			if (base.Image != null)
			{
				graphics.DrawImage(base.Image, ImageRectangle);
			}
			if (IsMouseOn | IsMouseDown)
			{
				Bitmap bitmap = new Bitmap(_LightImage, LightWidth, base.Height);
				graphics.DrawImage(bitmap, (base.Width - LightWidth) / 2, 0);
				bitmap.Dispose();
			}
			Pen pen = new Pen(SharedFunction.GetDeeperColor(BackColor, 0.9f), BorderWidth);
			rect = new Rectangle(0, 0, base.Width - 2, base.Height - 2);
			graphics.DrawRectangle(pen, rect);
			graphics.DrawArc(pen, 0, 0, RoundRectWidth, RoundRectWidth, -180, 90);
			graphics.DrawArc(pen, base.Width - RoundRectWidth - 2, 0, RoundRectWidth, RoundRectWidth, -90, 90);
			graphics.DrawArc(pen, base.Width - RoundRectWidth - 2, base.Height - RoundRectWidth - 2, RoundRectWidth, RoundRectWidth, 0, 90);
			graphics.DrawArc(pen, 0, base.Height - RoundRectWidth - 2, RoundRectWidth, RoundRectWidth, 90, 90);
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
			base.ResumeLayout(false);
		}
	}
}
