using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilburnEscape
{
	class World
	{
		private List<Area> mAreas = new List<Area>();
		private Area mCurrentArea;

		public event EventHandler Update;

		public World()
		{
			Area collabA = new Area(this);
			collabA.Image = new Bitmap(@"..\..\..\..\imgs\DSC_0414.JPG");

			Area collabB = new Area(this);
			collabB.Image = new Bitmap(@"..\..\..\..\imgs\DSC_0415.JPG");




			collabA.Right = collabB;
			collabB.Left = collabA;

			mCurrentArea = collabA;
		}

		public void ChangeArea(Area area)
		{
			mCurrentArea = area;
			if (Update != null)
				Update.Invoke(this, EventArgs.Empty);
		}

		public Area CurrentArea
		{
			get { return mCurrentArea; }
			set { mCurrentArea = value; }
		}
	}
}
