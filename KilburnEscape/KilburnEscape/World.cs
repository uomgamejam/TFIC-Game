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
			AreaNESW collab1, collab2, corridor1_1, corridor1_2, corridor2, corridor3, SSO;
			Area gamemenu, help, malloc;
			int hazKeyz = 0;
			bool doorCollab2Unlocked = false;

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

			corridor1_1 = new AreaNESW(this);
			corridor1_1.N.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_n1.jpg");
			corridor1_1.E.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_e1.jpg");
			corridor1_1.S.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_s1.jpg");
			corridor1_1.W.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_w1.jpg");

			corridor1_2 = new AreaNESW(this);
			corridor1_2.N.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_n2.jpg");
			corridor1_2.E.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_e2.jpg");
			corridor1_2.S.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_s2.jpg");
			corridor1_2.W.Image = new Bitmap(@"..\..\..\..\imgs\corridor1_w2.jpg");

			corridor2 = new AreaNESW(this);
			corridor2.E.Image = new Bitmap(@"..\..\..\..\imgs\corridor2_e.jpg");
			corridor2.S.Image = new Bitmap(@"..\..\..\..\imgs\corridor2_s.jpg");
			corridor2.W.Image = new Bitmap(@"..\..\..\..\imgs\corridor2_w.jpg");

			corridor3 = new AreaNESW(this);
			corridor3.E.Image = new Bitmap(@"..\..\..\..\imgs\corridor3_e.jpg");
			corridor3.S.Image = new Bitmap(@"..\..\..\..\imgs\corridor3_s.jpg");
			corridor3.W.Image = new Bitmap(@"..\..\..\..\imgs\corridor3_w.jpg");
			corridor3.N.Image = new Bitmap(@"..\..\..\..\imgs\corridor3_n.jpg");

			SSO = new AreaNESW(this);
			SSO.N.Image = new Bitmap(@"..\..\..\..\imgs\sso_n.jpg");
			SSO.E.Image = new Bitmap(@"..\..\..\..\imgs\sso_e.jpg");
			SSO.S.Image = new Bitmap(@"..\..\..\..\imgs\sso_s.jpg");
			SSO.W.Image = new Bitmap(@"..\..\..\..\imgs\sso_w.jpg");

			collab1.S.Hotspots.Add(new AreaHotspot(collab1.S, collab2.S, RectangleF.FromLTRB(0.4f, 0.4f, 0.5f, 0.7f)));
			collab2.N.Hotspots.Add(new AreaHotspot(collab2.N, collab1.N, RectangleF.FromLTRB(0.5f, 0.3f, 0.6f, 0.9f)));
			collab2.W.Hotspots.Add(new CustomHotspot(collab2.N, new Action(() => {
				if (doorCollab2Unlocked == false) {
					if (hazKeyz == 0) {
						MessageBox.Show("The door is locked!");
					} else {
						doorCollab2Unlocked = true;
						MessageBox.Show("Congratz u unlocked the door!");
					}
				} else {
					ChangeArea(corridor1_1.W);
				}
			}), RectangleF.FromLTRB(0.37f, 0.25f, 0.68f, 0.81f)));

			collab1.N.Hotspots.Add(new AreaHotspot(collab1.N, corridor3.N, RectangleF.FromLTRB(0.75f, 0.43f, 0.81f, 0.64f)));

			//pizza
			corridor3.N.Hotspots.Add(new CustomHotspot(corridor3.N, new Action(() => {
				MessageBox.Show("Pizza! Nom Nom Nom!");
			}), RectangleF.FromLTRB(0.39f, 0.30f, 0.46f, 0.56f)));

			//key
			corridor3.W.Hotspots.Add(new CustomHotspot(corridor3.W, new Action(() => {
				MessageBox.Show("U found the key :P");
				hazKeyz++;
			}), RectangleF.FromLTRB(0.67f, 0.56f, 0.68f, 0.58f)));

			corridor3.S.Hotspots.Add(new AreaHotspot(corridor3.S, collab1.S, RectangleF.FromLTRB(0.10f, 0.28f, 0.20f, 0.67f)));

			gamemenu = new Area(this);
			help = new Area(this);
			malloc = new Area(this);

			gamemenu.Image = new Bitmap(@"..\..\..\..\imgs\menu.jpg");

			// Attempt to escape
			gamemenu.Hotspots.Add(new AreaHotspot(gamemenu, collab1.N, RectangleF.FromLTRB(0.3f, 0.16f, 0.59f, 0.23f)));
			// Help
			gamemenu.Hotspots.Add(new AreaHotspot(gamemenu, help, RectangleF.FromLTRB(0.41f, 0.34f, 0.5f, 0.41f)));
			// Exit
			gamemenu.Hotspots.Add(new CustomHotspot(gamemenu, new Action( () => {
				MessageBox.Show("LOL!");
				Application.Exit();
			}), RectangleF.FromLTRB(0.42f, 0.51f, 0.51f, 0.59f)));
			// Malloc
			gamemenu.Hotspots.Add(new AreaHotspot(gamemenu, malloc, RectangleF.FromLTRB(0.45f, 0.87f, 0.49f, 0.91f)));

			//temp help menu
			
			help.Image = new Bitmap(@"..\..\..\..\imgs\help.jpg");

			// Go back (currently at the new button)
			help.Hotspots.Add(new AreaHotspot(help, gamemenu, RectangleF.FromLTRB(0.44f, 0.90f, 0.52f, 0.96f)));

			//temp malloc menu
			
			malloc.Image = new Bitmap(@"..\..\..\..\imgs\malloc.jpg");

			// Go back (currently at the new button)
			malloc.Hotspots.Add(new AreaHotspot(malloc, gamemenu, RectangleF.FromLTRB(0.44f, 0.90f, 0.52f, 0.96f)));

			mCurrentArea = gamemenu;

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
