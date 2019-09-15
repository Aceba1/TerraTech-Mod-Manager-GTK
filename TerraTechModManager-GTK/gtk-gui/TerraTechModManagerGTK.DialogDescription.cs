
// This file has been generated by the GUI designer. Do not modify.
namespace TerraTechModManagerGTK
{
	public partial class DialogDescription
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Label labelTitle;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.Label labelTextView;

		private global::Gtk.Entry entry3;

		private global::Gtk.HButtonBox UpdateInfoArea;

		private global::Gtk.Button buttonUpdateTTMM;

		private global::Gtk.Button buttonOpenSite2;

		private global::Gtk.Button buttonOk2;

		private global::Gtk.HButtonBox ServerModInfoArea;

		private global::Gtk.Button buttonInstallMod;

		private global::Gtk.Button buttonOpenSite1;

		private global::Gtk.Button buttonOk1;

		private global::Gtk.HButtonBox LocalModInfoArea;

		private global::Gtk.Button buttonOpenFolder;

		private global::Gtk.Button buttonOpenSite;

		private global::Gtk.Button buttonOk;

		private global::Gtk.Button button178;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TerraTechModManagerGTK.DialogDescription
			this.Name = "TerraTechModManagerGTK.DialogDescription";
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("TerraTechModManagerGTK.Big TTMM Logo.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child TerraTechModManagerGTK.DialogDescription.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.labelTitle = new global::Gtk.Label();
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Title");
			this.labelTitle.UseMarkup = true;
			this.vbox2.Add(this.labelTitle);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.labelTitle]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w3 = new global::Gtk.Viewport();
			w3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.labelTextView = new global::Gtk.Label();
			this.labelTextView.Name = "labelTextView";
			this.labelTextView.Xalign = 0F;
			this.labelTextView.Yalign = 0F;
			this.labelTextView.LabelProp = global::Mono.Unix.Catalog.GetString("No message provided!");
			this.labelTextView.UseMarkup = true;
			this.labelTextView.Wrap = true;
			this.labelTextView.Selectable = true;
			w3.Add(this.labelTextView);
			this.scrolledwindow1.Add(w3);
			this.vbox2.Add(this.scrolledwindow1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.scrolledwindow1]));
			w6.Position = 1;
			// Container child vbox2.Gtk.Box+BoxChild
			this.entry3 = new global::Gtk.Entry();
			this.entry3.CanFocus = true;
			this.entry3.Name = "entry3";
			this.entry3.IsEditable = true;
			this.entry3.InvisibleChar = '•';
			this.vbox2.Add(this.entry3);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.entry3]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			w1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w8.Position = 0;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.UpdateInfoArea = new global::Gtk.HButtonBox();
			this.UpdateInfoArea.Name = "UpdateInfoArea";
			this.UpdateInfoArea.Spacing = 10;
			this.UpdateInfoArea.BorderWidth = ((uint)(5));
			this.UpdateInfoArea.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child UpdateInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonUpdateTTMM = new global::Gtk.Button();
			this.buttonUpdateTTMM.CanDefault = true;
			this.buttonUpdateTTMM.CanFocus = true;
			this.buttonUpdateTTMM.Name = "buttonUpdateTTMM";
			this.buttonUpdateTTMM.UseUnderline = true;
			this.buttonUpdateTTMM.Label = global::Mono.Unix.Catalog.GetString("Install update");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonUpdateTTMM.Image = w9;
			this.UpdateInfoArea.Add(this.buttonUpdateTTMM);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.UpdateInfoArea[this.buttonUpdateTTMM]));
			w10.Expand = false;
			w10.Fill = false;
			// Container child UpdateInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOpenSite2 = new global::Gtk.Button();
			this.buttonOpenSite2.CanFocus = true;
			this.buttonOpenSite2.Name = "buttonOpenSite2";
			this.buttonOpenSite2.UseUnderline = true;
			this.buttonOpenSite2.Label = global::Mono.Unix.Catalog.GetString("Go to site");
			global::Gtk.Image w11 = new global::Gtk.Image();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-about", global::Gtk.IconSize.Menu);
			this.buttonOpenSite2.Image = w11;
			this.UpdateInfoArea.Add(this.buttonOpenSite2);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.UpdateInfoArea[this.buttonOpenSite2]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child UpdateInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk2 = new global::Gtk.Button();
			this.buttonOk2.CanDefault = true;
			this.buttonOk2.CanFocus = true;
			this.buttonOk2.Name = "buttonOk2";
			this.buttonOk2.UseUnderline = true;
			this.buttonOk2.Label = global::Mono.Unix.Catalog.GetString("Close");
			global::Gtk.Image w13 = new global::Gtk.Image();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonOk2.Image = w13;
			this.UpdateInfoArea.Add(this.buttonOk2);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.UpdateInfoArea[this.buttonOk2]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			w1.Add(this.UpdateInfoArea);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(w1[this.UpdateInfoArea]));
			w15.PackType = ((global::Gtk.PackType)(1));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.ServerModInfoArea = new global::Gtk.HButtonBox();
			this.ServerModInfoArea.Name = "ServerModInfoArea";
			this.ServerModInfoArea.Spacing = 10;
			this.ServerModInfoArea.BorderWidth = ((uint)(5));
			this.ServerModInfoArea.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child ServerModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonInstallMod = new global::Gtk.Button();
			this.buttonInstallMod.CanFocus = true;
			this.buttonInstallMod.Name = "buttonInstallMod";
			this.buttonInstallMod.UseUnderline = true;
			this.buttonInstallMod.Label = global::Mono.Unix.Catalog.GetString("Install mod");
			global::Gtk.Image w16 = new global::Gtk.Image();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonInstallMod.Image = w16;
			this.ServerModInfoArea.Add(this.buttonInstallMod);
			global::Gtk.ButtonBox.ButtonBoxChild w17 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.ServerModInfoArea[this.buttonInstallMod]));
			w17.Expand = false;
			w17.Fill = false;
			// Container child ServerModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOpenSite1 = new global::Gtk.Button();
			this.buttonOpenSite1.CanDefault = true;
			this.buttonOpenSite1.CanFocus = true;
			this.buttonOpenSite1.Name = "buttonOpenSite1";
			this.buttonOpenSite1.UseUnderline = true;
			this.buttonOpenSite1.Label = global::Mono.Unix.Catalog.GetString("Go to site");
			global::Gtk.Image w18 = new global::Gtk.Image();
			w18.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-about", global::Gtk.IconSize.Menu);
			this.buttonOpenSite1.Image = w18;
			this.ServerModInfoArea.Add(this.buttonOpenSite1);
			global::Gtk.ButtonBox.ButtonBoxChild w19 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.ServerModInfoArea[this.buttonOpenSite1]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			// Container child ServerModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk1 = new global::Gtk.Button();
			this.buttonOk1.CanDefault = true;
			this.buttonOk1.CanFocus = true;
			this.buttonOk1.Name = "buttonOk1";
			this.buttonOk1.UseUnderline = true;
			this.buttonOk1.Label = global::Mono.Unix.Catalog.GetString("Close");
			global::Gtk.Image w20 = new global::Gtk.Image();
			w20.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonOk1.Image = w20;
			this.ServerModInfoArea.Add(this.buttonOk1);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.ServerModInfoArea[this.buttonOk1]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			w1.Add(this.ServerModInfoArea);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(w1[this.ServerModInfoArea]));
			w22.PackType = ((global::Gtk.PackType)(1));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.LocalModInfoArea = new global::Gtk.HButtonBox();
			this.LocalModInfoArea.Name = "LocalModInfoArea";
			this.LocalModInfoArea.Spacing = 10;
			this.LocalModInfoArea.BorderWidth = ((uint)(5));
			this.LocalModInfoArea.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child LocalModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOpenFolder = new global::Gtk.Button();
			this.buttonOpenFolder.CanDefault = true;
			this.buttonOpenFolder.CanFocus = true;
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.UseUnderline = true;
			this.buttonOpenFolder.Label = global::Mono.Unix.Catalog.GetString("Open folder");
			global::Gtk.Image w23 = new global::Gtk.Image();
			w23.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-open", global::Gtk.IconSize.Menu);
			this.buttonOpenFolder.Image = w23;
			this.LocalModInfoArea.Add(this.buttonOpenFolder);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.LocalModInfoArea[this.buttonOpenFolder]));
			w24.Expand = false;
			w24.Fill = false;
			// Container child LocalModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOpenSite = new global::Gtk.Button();
			this.buttonOpenSite.CanFocus = true;
			this.buttonOpenSite.Name = "buttonOpenSite";
			this.buttonOpenSite.UseUnderline = true;
			this.buttonOpenSite.Label = global::Mono.Unix.Catalog.GetString("Go to site");
			global::Gtk.Image w25 = new global::Gtk.Image();
			w25.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-about", global::Gtk.IconSize.Menu);
			this.buttonOpenSite.Image = w25;
			this.LocalModInfoArea.Add(this.buttonOpenSite);
			global::Gtk.ButtonBox.ButtonBoxChild w26 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.LocalModInfoArea[this.buttonOpenSite]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			// Container child LocalModInfoArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = global::Mono.Unix.Catalog.GetString("Close");
			global::Gtk.Image w27 = new global::Gtk.Image();
			w27.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonOk.Image = w27;
			this.LocalModInfoArea.Add(this.buttonOk);
			global::Gtk.ButtonBox.ButtonBoxChild w28 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.LocalModInfoArea[this.buttonOk]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			w1.Add(this.LocalModInfoArea);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(w1[this.LocalModInfoArea]));
			w29.PackType = ((global::Gtk.PackType)(1));
			w29.Position = 3;
			w29.Expand = false;
			w29.Fill = false;
			// Internal child TerraTechModManagerGTK.DialogDescription.ActionArea
			global::Gtk.HButtonBox w30 = this.ActionArea;
			w30.Name = "__gtksharp_92_Stetic_TopLevelDialog_ActionArea";
			// Container child __gtksharp_92_Stetic_TopLevelDialog_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.button178 = new global::Gtk.Button();
			this.button178.CanFocus = true;
			this.button178.Name = "button178";
			this.button178.UseUnderline = true;
			this.button178.Label = global::Mono.Unix.Catalog.GetString("IDE-Generated button that will not go away, do not anger");
			this.AddActionWidget(this.button178, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w31 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w30[this.button178]));
			w31.Expand = false;
			w31.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 463;
			this.DefaultHeight = 300;
			this.UpdateInfoArea.Hide();
			this.ServerModInfoArea.Hide();
			this.LocalModInfoArea.Hide();
			this.button178.Hide();
			w30.Hide();
			this.Show();
			this.entry3.Changed += new global::System.EventHandler(this.OnChanged);
			this.buttonOpenFolder.Clicked += new global::System.EventHandler(this.OpenFolderEvent);
			this.buttonOpenSite.Clicked += new global::System.EventHandler(this.OpenSiteEvent);
			this.buttonOk.Clicked += new global::System.EventHandler(this.OnCloseEvent);
			this.buttonInstallMod.Clicked += new global::System.EventHandler(this.InstallModEvent);
			this.buttonOpenSite1.Clicked += new global::System.EventHandler(this.OpenSiteEvent);
			this.buttonOk1.Clicked += new global::System.EventHandler(this.OnCloseEvent);
			this.buttonUpdateTTMM.Clicked += new global::System.EventHandler(this.InstallUpdateEvent);
			this.buttonOpenSite2.Clicked += new global::System.EventHandler(this.OpenSiteEvent);
			this.buttonOk2.Clicked += new global::System.EventHandler(this.OnCloseEvent);
		}
	}
}
