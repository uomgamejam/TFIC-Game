using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KilburnEscape
{
	public partial class MainForm : Form
	{
		private World mWorld = new World();

		public MainForm()
		{
			InitializeComponent();

			mWorld.Update += mWorld_Update;
			mWorld_Update(this, EventArgs.Empty);
		}

		void mWorld_Update(object sender, EventArgs e)
		{
			imgScene.Image = mWorld.CurrentArea.Image;
		}

		private void imgScene_MouseUp(object sender, MouseEventArgs e)
		{
			mWorld.CurrentArea.Click(new PointF(e.X / (float)imgScene.Width, e.Y / (float)imgScene.Height));
		}

		private void imgScene_MouseMove(object sender, MouseEventArgs e)
		{
			this.Text = String.Format("Kilburn Escape - {0:0.00}, {1:0.00}", e.X / (float)imgScene.Width, e.Y / (float)imgScene.Height);

			if (mWorld.CurrentArea.IsHotspot(new PointF(e.X / (float)imgScene.Width, e.Y / (float)imgScene.Height))) {
				imgScene.Cursor = Cursors.Hand;
			} else {
				imgScene.Cursor = Cursors.Default;
			}
		}
	}
}
