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

		public Area(World world)
		{
			mWorld = world;
		}

		public bool IsHotspot(PointF sense)
		{
			if (sense.X < 0.1f && mLeft != null) {
				return true;
			} else if (sense.X >= 0.9f && mRight != null) {
				return true;
			}

			foreach (Hotspot hotspot in mHotspots) {
				if (hotspot.Sensitive.Contains(sense)) {
					return true;
				}
			}

			return false;
		}

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

	class AreaNESW
	{
		public Area N { get; set; }
		public Area E { get; set; }
		public Area S { get; set; }
		public Area W { get; set; }

		public AreaNESW(World world)
		{
			N = new Area(world);
			E = new Area(world);
			S = new Area(world);
			W = new Area(world);

			N.Left = W;
			E.Left = N;
			S.Left = E;
			W.Left = S;
			N.Right = E;
			E.Right = S;
			S.Right = W;
			W.Right = N;
		}
	}
}
