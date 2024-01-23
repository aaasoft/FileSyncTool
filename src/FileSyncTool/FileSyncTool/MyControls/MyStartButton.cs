#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace FileSyncTool.MyControls
{
	public class MyStartButton : Button
	{
		private delegate void DrawBackGroundDelegate(PaintEventArgs pe);

		private IContainer components = null;

		private bool IsMouseOn = false;

		private bool IsMouseOning = false;

		private Image _BackLogoImage;

		private Image BackLogoImage
		{
			get
			{
				return _BackLogoImage;
			}
			set
			{
				_BackLogoImage = value;
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
		}

		public MyStartButton()
		{
			InitializeComponent();
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			RebuildBackLogo();
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			RebuildBackLogo();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			try
			{
				base.OnPaint(pe);
				pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				DrawRoundButton(pe.Graphics);
				DrawBackGround(pe);
				if (IsMouseOn && !IsMouseOning)
				{
					pe.Graphics.ResetClip();
					pe.Graphics.ResetTransform();
					DrawLogo(pe.Graphics, 0);
				}
			}
			catch (Exception ex)
			{
				Debug.Print("Error From MyStartButton.OnPaint.原因:" + ex.Message);
			}
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			base.BackColor = base.Parent.BackColor;
		}

		private void RebuildBackLogo()
		{
			if (BackgroundImage != null)
			{
				BackLogoImage = SharedFunction.ChangeImageToColorImage((Bitmap)base.BackgroundImage, base.BackColor, 65);
			}
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			base.BackColor = base.Parent.BackColor;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			base.Height = base.Width;
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			DrawLogo(CreateGraphics(), 0);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			IsMouseOn = true;
			IsMouseOning = true;
			Thread thread = new Thread(WhenMouseOnThread);
			thread.IsBackground = true;
			thread.Name = "StartButton.WhenMouseOnThread";
			thread.Start();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			IsMouseOn = false;
			Thread thread = new Thread(WhenMouseLeaveThread);
			thread.IsBackground = true;
			thread.Name = "StartButton.WhenMouseLeaveThread";
			thread.Start();
		}

		private void WhenMouseOnThread()
		{
			IsMouseOning = true;
			DrawLogo(CreateGraphics(), 5);
			IsMouseOning = false;
		}

		private void WhenMouseLeaveThread()
		{
			UnDrawLogo(CreateGraphics(), 5);
		}

		private void DrawLogo(Graphics g, int drawSetp)
		{
			try
			{
				Image image = null;
				if (base.Image != null)
				{
					image = ((drawSetp != 0) ? SharedFunction.GetAlphaImage(base.Image, 255 / (drawSetp - 1)) : new Bitmap(base.Image));
				}
				g.SmoothingMode = SmoothingMode.AntiAlias;
				Pen pen = new Pen(Color.White, 1.6f);
				for (int i = 0; i <= drawSetp; i++)
				{
					if (!IsMouseOn)
					{
						break;
					}
					for (int j = 0; j <= 2; j++)
					{
						pen.Color = Color.FromArgb(255 / (drawSetp + 1), SharedFunction.GetDeeperColor(base.BackColor, 1.7f - 0.3f * (float)j));
						g.DrawEllipse(pen, new Rectangle(1 - j, 1 - j, base.Width - 7 + 2 * j, base.Height - 7 + 2 * j));
					}
					if (image != null)
					{
						try
						{
							if (i == drawSetp)
							{
								image = new Bitmap(base.Image);
							}
							g.DrawImage(image, (base.Width - base.Image.Width - 4) / 2, (base.Height - base.Image.Height - 2) / 2);
						}
						catch
						{
						}
					}
					Thread.Sleep(50);
				}
				image.Dispose();
			}
			catch (Exception ex)
			{
				Debug.Print("Error From MyStartButton.DrawLogo.原因:" + ex.Message);
			}
		}

		private void DrawBackGround(PaintEventArgs pe)
		{
			Invoke(new DrawBackGroundDelegate(_DrawBackGround), pe);
		}

		private void _DrawBackGround(PaintEventArgs pe)
		{
			Graphics graphics = pe.Graphics;
			DrawRoundButton(graphics);
			int num = 2;
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Region region = new Region(rect);
			region.Exclude(SharedFunction.CreateRoundRectRgn(num, num, base.Width - 2 * num, base.Height - 2 * num, base.Width - 2 * num, base.Height - 2 * num));
			graphics.SetClip(region, CombineMode.Replace);
			graphics.TranslateTransform(-base.Left, -base.Top);
			InvokePaintBackground(base.Parent, pe);
			InvokePaint(base.Parent, pe);
			graphics.ResetClip();
			graphics.ResetTransform();
		}

		private void UnDrawLogo(Graphics g, int drawSetp)
		{
			try
			{
				Image image = null;
				if (base.Image != null)
				{
					image = ((drawSetp != 0) ? SharedFunction.GetAlphaImage(base.Image, 255 / (drawSetp - 1)) : new Bitmap(base.Image));
				}
				g.SmoothingMode = SmoothingMode.AntiAlias;
				Pen pen = new Pen(Color.White, 1.6f);
				for (int i = 0; i <= drawSetp; i++)
				{
					if (IsMouseOn)
					{
						break;
					}
					Bitmap bitmap = new Bitmap(base.Width, base.Height);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					PaintEventArgs pe = new PaintEventArgs(graphics, new Rectangle(0, 0, base.Width, base.Height));
					DrawBackGround(pe);
					if (i == drawSetp)
					{
						g.DrawImage(bitmap, 0, 0);
						bitmap.Dispose();
						break;
					}
					for (int j = 0; j <= drawSetp - i - 1; j++)
					{
						for (int k = 0; k <= 2; k++)
						{
							pen.Color = Color.FromArgb(255 / (drawSetp + 1), SharedFunction.GetDeeperColor(base.BackColor, 1.7f - 0.3f * (float)k));
							graphics.DrawEllipse(pen, new Rectangle(1 - k, 1 - k, base.Width - 7 + 2 * k, base.Height - 7 + 2 * k));
						}
						if (image != null)
						{
							try
							{
								graphics.DrawImage(image, (base.Width - base.Image.Width - 4) / 2, (base.Height - base.Image.Height - 2) / 2);
							}
							catch
							{
							}
						}
					}
					g.DrawImage(bitmap, 0, 0);
					bitmap.Dispose();
					Thread.Sleep(50);
				}
			}
			catch (Exception ex)
			{
				Debug.Print("Error From MyStartButton.UnDrawLogo.原因:" + ex.Message);
			}
		}

		private void RefrushMyButton()
		{
			Rectangle rc = new Rectangle(0, 0, base.Width, base.Height);
			Invalidate(rc);
		}

		private void DrawRoundButton(Graphics graphics)
		{
			float deep = 2f;
			float deep2 = 0.9f;
			float deep3 = 0.8f;
			float deep4 = 1f;
			float num = 2.5f;
			Rectangle rect = new Rectangle(0, 0, base.Width, Convert.ToInt32((double)base.Height / (double)num) + 1);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, SharedFunction.GetDeeperColor(BackColor, deep), SharedFunction.GetDeeperColor(BackColor, deep2), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			rect = new Rectangle(0, Convert.ToInt32((double)base.Height / (double)num), base.Width, base.Height - Convert.ToInt32((double)base.Height / (double)num));
			linearGradientBrush = new LinearGradientBrush(rect, SharedFunction.GetDeeperColor(BackColor, deep3), SharedFunction.GetDeeperColor(BackColor, deep4), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			linearGradientBrush.Dispose();
			Pen pen = new Pen(SharedFunction.GetDeeperColor(BackColor, 0.9f), 1.5f);
			rect = new Rectangle(2, 2, base.Width - 8, base.Height - 6);
			if (BackLogoImage != null)
			{
				graphics.DrawImage(BackLogoImage, (base.Width - BackLogoImage.Width - 4) / 2, (base.Height - BackLogoImage.Height - 2) / 2, 24, 24);
			}
			graphics.DrawEllipse(pen, rect);
			pen.Dispose();
		}
	}
}
