using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KilburnEscape
{
	class World
	{
		private List<Area> mAreas = new List<Area>();
		private Area mCurrentArea;

		public event EventHandler Update;

		public World()
		{
			AreaNESW collab1, collab2;

			collab2 = new AreaNESW(this);
			collab2.N.Image = new Bitmap(@"..\..\..\..\imgs\collab2_n.jpg");
			collab2.E.Image = new Bitmap(@"..\..\..\..\imgs\collab2_e.jpg");
			collab2.S.Image = new Bitmap(@"..\..\..\..\imgs\collab2_s.jpg");
			collab2.W.Image = new Bitmap(@"..\..\..\..\imgs\collab2_w.jpg");

			collab1 = new AreaNESW(this);
			collab1.N.Image = new Bitmap(@"..\..\..\..\imgs\collab1_n.jpg");
			collab1.E.Image = new Bitmap(@"..\..\..\..\imgs\collab1_e.jpg");
			collab1.S.Image = new Bitmap(@"..\..\..\..\imgs\collab1_s.jpg");
			collab1.W.Image = new Bitmap(@"..\..\..\..\imgs\collab1_w.jpg");

			collab1.S.Hotspots.Add(new AreaHotspot(collab1.S, collab2.S, RectangleF.FromLTRB(0.4f, 0.4f, 0.5f, 0.7f)));
			collab2.N.Hotspots.Add(new AreaHotspot(collab2.N, collab1.N, RectangleF.FromLTRB(0.5f, 0.3f, 0.6f, 0.9f)));
			collab2.W.Hotspots.Add(new CustomHotspot(collab2.N, new Action( () => {
				MessageBox.Show("The door is locked!");
			}), RectangleF.FromLTRB(0.37f, 0.25f, 0.68f, 0.81f)));

			mCurrentArea = collab2.N;
		}

		public void ChangeArea(Area area)
		{
			mCurrentArea = area;
			if (Update != null)
				Update.Invoke(this, EventArgs.Empty);

			Console.Beep(500, 150);
		}

		public Area CurrentArea
		{
			get { return mCurrentArea; }
			set { mCurrentArea = value; }
		}
	}
}
