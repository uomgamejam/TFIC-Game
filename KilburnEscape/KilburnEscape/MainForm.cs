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
		}

		void mWorld_Update(object sender, EventArgs e)
		{
			imgScene.Image = mWorld.CurrentArea.Image;
		}

		private void imgScene_MouseUp(object sender, MouseEventArgs e)
		{
			mWorld.CurrentArea.Click(new PointF(e.X, e.Y));
		}
	}
}
