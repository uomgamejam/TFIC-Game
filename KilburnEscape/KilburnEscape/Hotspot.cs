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
		
		public virtual void Action();
	}

	class AreaHotspot : Hotspot
	{
		private Area mDestinationArea;

		public AreaHotspot(Area area, Area destinationArea)
			: base(area)
		{
		}

		public override void Action()
		{
			Area.World.ChangeArea(mDestinationArea);
		}
	}
}
