using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilburnEscape
{
	class Area
	{
		private World mWorld;
		private Area mLeft;
		private Area mRight;
		private List<Hotspot> mHotspots = new List<Hotspot>();

		private Bitmap mImage;

		public void Click(PointF sense)
		{
			if (sense.X < 0.1f && mLeft != null) {
				mWorld.ChangeArea(mLeft);
				return;
			} else if (sense.X >= 0.9f && mRight != null) {
				mWorld.ChangeArea(mRight);
				return;
			}

			foreach (Hotspot hotspot in mHotspots) {
				if (hotspot.Sensitive.Contains(sense)) {
					hotspot.Action();
					break;
				}
			}
		}

		public World World
		{
			get { return mWorld; }
			set { mWorld = value; }
		}

		public Area Left
		{
			get { return mLeft; }
			set { mLeft = value; }
		}

		public Area Right
		{
			get { return mRight; }
			set { mRight = value; }
		}

		public List<Hotspot> Hotspots
		{
			get { return mHotspots; }
			set { mHotspots = value; }
		}

		public Bitmap Image
		{
			get { return mImage; }
			set { mImage = value; }
		}
	}
}
