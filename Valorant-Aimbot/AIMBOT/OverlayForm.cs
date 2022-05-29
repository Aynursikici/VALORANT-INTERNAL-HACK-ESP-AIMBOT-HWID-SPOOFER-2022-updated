using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Immortal.SDK;
using Immortal.SDK.Extensions;

namespace Immortals
{
	// Token: 0x02000003 RID: 3
	public partial class OverlayForm : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000048AF File Offset: 0x00002AAF
		public OverlayForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000017 RID: 23
		[DllImport("User32.dll")]
		private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x06000018 RID: 24
		[DllImport("User32.dll")]
		private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

		// Token: 0x06000019 RID: 25 RVA: 0x000048C8 File Offset: 0x00002AC8
		private void OverlayForm_Load(object sender, EventArgs e)
		{
			int windowLong = OverlayForm.GetWindowLong(base.Handle, -20);
			OverlayForm.SetWindowLong(base.Handle, -20, windowLong | 524288 | 32);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000048FC File Offset: 0x00002AFC
		private void OverlayForm_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			bool flag = ProcessUtils.getForegroundProcess().ProcessName.Contains("VALORANT");
			if (flag)
			{
				bool drawRadius = OverlayForm.DrawRadius;
				if (drawRadius)
				{
					e.Graphics.DrawEllipse(new Pen(Color.Black, 3f), new Rectangle(Screen.PrimaryScreen.Bounds.Width / 2 - MainThreads.TriggerbotCrossRadius - 1, Screen.PrimaryScreen.Bounds.Height / 2 - MainThreads.TriggerbotCrossRadius - 1, MainThreads.TriggerbotCrossRadius * 2 + 1, MainThreads.TriggerbotCrossRadius * 2 + 1));
					e.Graphics.DrawEllipse(new Pen(Color.Cyan, 1f), new Rectangle(Screen.PrimaryScreen.Bounds.Width / 2 - MainThreads.TriggerbotCrossRadius - 1, Screen.PrimaryScreen.Bounds.Height / 2 - MainThreads.TriggerbotCrossRadius - 1, MainThreads.TriggerbotCrossRadius * 2 + 1, MainThreads.TriggerbotCrossRadius * 2 + 1));
				}
				e.Graphics.DrawString("IMMORTAL", new Font("Segoe UI", 12f), Brushes.Red, 10f, 10f);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004A45 File Offset: 0x00002C45
		private void autoUpdate_Tick(object sender, EventArgs e)
		{
			base.Invalidate();
		}

		// Token: 0x04000027 RID: 39
		public static bool DrawRadius;
	}
}
