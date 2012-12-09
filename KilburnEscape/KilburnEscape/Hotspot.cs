using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilburnEscape
{
	abstract class Hotspot
	{
		public Area Area { get; set; }
		public RectangleF Sensitive { get; set; }

		public Hotspot(Area area)
		{
			Area = area;
		}
		
		public abstract void Action();
	}

	class AreaHotspot : Hotspot
	{
		private Area mDestinationArea;

		public AreaHotspot(Area area, Area destinationArea, RectangleF sense)
			: base(area)
		{
			mDestinationArea = destinationArea;
			Sensitive = sense;
		}

		public override void Action()
		{
			Area.World.ChangeArea(mDestinationArea);
		}
	}

	class CustomHotspot : Hotspot
	{
		Action mCallback;

		public CustomHotspot(Area area, Action callback, RectangleF sense)
			: base(area)
		{
			mCallback = callback;
			Sensitive = sense;
		}

		public override void Action()
		{
			if (mCallback != null)
				mCallback.Invoke();
		}
	}
}
