using System;
using System.Collections.Generic;
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
