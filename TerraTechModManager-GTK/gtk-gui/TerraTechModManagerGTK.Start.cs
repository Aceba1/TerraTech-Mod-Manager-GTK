
// This file has been generated by the GUI designer. Do not modify.
namespace TerraTechModManagerGTK
{
	public partial class Start
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView textviewNotes;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label labelFileSelect;

		private global::Gtk.Entry entryFileSelect;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label labelTip;

		private global::Gtk.Button buttonStart;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TerraTechModManagerGTK.Start
			this.Name = "TerraTechModManagerGTK.Start";
			this.Title = global::Mono.Unix.Catalog.GetString("TerraTech Mod Manager - Start");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("TerraTechModManagerGTK.Big TTMM Logo.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TerraTechModManagerGTK.Start.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.BorderWidth = ((uint)(5));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textviewNotes = new global::Gtk.TextView();
			this.textviewNotes.Buffer.Text = global::Mono.Unix.Catalog.GetString(@"A few things to note:

 - This program connects to Github to aquire mods, the patcher, and updates.
 - If not present when booting, the program will download the patcher from Github.
 - Loading the program will make sure that the modloader (TTQMM) is present in the game.
    - The modloader can be removed from the game from within this program's File menu.

Updating or reinstalling the game will remove the modloader and stop mods from loading.
You can reinstall the patch by loading TTMM again.

If you encounter the Github API throttling error, you can create a token to bypass it here: 
https://github.com/settings/tokens

If you have any problems, please contact the creator on the Github,  TerraTech Forum, or on the official TerraTech Discord (https://discord.gg/TerraTechGame)");
			this.textviewNotes.CanFocus = true;
			this.textviewNotes.Name = "textviewNotes";
			this.textviewNotes.Editable = false;
			this.textviewNotes.WrapMode = ((global::Gtk.WrapMode)(3));
			this.GtkScrolledWindow.Add(this.textviewNotes);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelFileSelect = new global::Gtk.Label();
			this.labelFileSelect.Name = "labelFileSelect";
			this.labelFileSelect.Xalign = 1F;
			this.labelFileSelect.LabelProp = global::Mono.Unix.Catalog.GetString("     Path");
			this.hbox1.Add(this.labelFileSelect);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelFileSelect]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryFileSelect = new global::Gtk.Entry();
			this.entryFileSelect.CanFocus = true;
			this.entryFileSelect.Name = "entryFileSelect";
			this.entryFileSelect.Text = global::Mono.Unix.Catalog.GetString("/TerraTech installation folder/");
			this.entryFileSelect.IsEditable = true;
			this.entryFileSelect.InvisibleChar = '•';
			this.hbox1.Add(this.entryFileSelect);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entryFileSelect]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 1;
			w4.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.labelTip = new global::Gtk.Label();
			this.labelTip.Name = "labelTip";
			this.labelTip.Xalign = 1F;
			this.labelTip.UseMarkup = true;
			this.labelTip.UseUnderline = true;
			this.labelTip.Wrap = true;
			this.labelTip.Justify = ((global::Gtk.Justification)(1));
			this.hbox2.Add(this.labelTip);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.labelTip]));
			w6.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonStart = new global::Gtk.Button();
			this.buttonStart.CanFocus = true;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.UseUnderline = true;
			this.buttonStart.Label = global::Mono.Unix.Catalog.GetString("   Continue   ");
			this.hbox2.Add(this.buttonStart);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonStart]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			w7.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			w8.Padding = ((uint)(5));
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 641;
			this.DefaultHeight = 402;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.DestroyEvent += new global::Gtk.DestroyEventHandler(this.OnDestroyEvent);
			this.buttonStart.Clicked += new global::System.EventHandler(this.OpenMain_Clicked);
		}
	}
}
