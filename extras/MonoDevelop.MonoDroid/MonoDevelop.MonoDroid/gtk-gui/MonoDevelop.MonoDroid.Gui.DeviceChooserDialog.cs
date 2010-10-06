
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.MonoDroid.Gui {
    public partial class DeviceChooserDialog {
        private global::Gtk.VBox vbox2;
        
        private global::Gtk.Alignment bannerPlaceholder;
        
        private global::Gtk.ScrolledWindow GtkScrolledWindow;
        
        private global::Gtk.TreeView deviceListTreeView;
        
        private global::Gtk.HBox hbox1;
        
        private global::Gtk.Button refreshButton;
        
        private global::Gtk.Button startEmulatorButton;
        
        private global::Gtk.Button createEmulatorButton;
        
        private global::Gtk.Button buttonCancel;
        
        private global::Gtk.Button buttonOk;
        
        protected virtual void Build() {
            global::Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.MonoDroid.Gui.DeviceChooserDialog
            this.Name = "MonoDevelop.MonoDroid.Gui.DeviceChooserDialog";
            this.Title = global::Mono.Unix.Catalog.GetString("Select Device");
            this.WindowPosition = ((global::Gtk.WindowPosition)(4));
            this.Modal = true;
            // Internal child MonoDevelop.MonoDroid.Gui.DeviceChooserDialog.VBox
            global::Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new global::Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(6));
            // Container child vbox2.Gtk.Box+BoxChild
            this.bannerPlaceholder = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.bannerPlaceholder.Name = "bannerPlaceholder";
            this.vbox2.Add(this.bannerPlaceholder);
            global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.bannerPlaceholder]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.deviceListTreeView = new global::Gtk.TreeView();
            this.deviceListTreeView.CanFocus = true;
            this.deviceListTreeView.Name = "deviceListTreeView";
            this.GtkScrolledWindow.Add(this.deviceListTreeView);
            this.vbox2.Add(this.GtkScrolledWindow);
            global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
            w4.Position = 1;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox1 = new global::Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.refreshButton = new global::Gtk.Button();
            this.refreshButton.CanFocus = true;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseUnderline = true;
            this.refreshButton.Relief = ((global::Gtk.ReliefStyle)(2));
            // Container child refreshButton.Gtk.Container+ContainerChild
            global::Gtk.Alignment w5 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            global::Gtk.HBox w6 = new global::Gtk.HBox();
            w6.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Image w7 = new global::Gtk.Image();
            w7.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
            w6.Add(w7);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Label w9 = new global::Gtk.Label();
            w9.LabelProp = global::Mono.Unix.Catalog.GetString("_Refresh List");
            w9.UseUnderline = true;
            w6.Add(w9);
            w5.Add(w6);
            this.refreshButton.Add(w5);
            this.hbox1.Add(this.refreshButton);
            global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.refreshButton]));
            w13.Position = 0;
            w13.Expand = false;
            w13.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.startEmulatorButton = new global::Gtk.Button();
            this.startEmulatorButton.CanFocus = true;
            this.startEmulatorButton.Name = "startEmulatorButton";
            this.startEmulatorButton.UseUnderline = true;
            this.startEmulatorButton.Relief = ((global::Gtk.ReliefStyle)(2));
            // Container child startEmulatorButton.Gtk.Container+ContainerChild
            global::Gtk.Alignment w14 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            global::Gtk.HBox w15 = new global::Gtk.HBox();
            w15.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Image w16 = new global::Gtk.Image();
            w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-media-play", global::Gtk.IconSize.Menu);
            w15.Add(w16);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Label w18 = new global::Gtk.Label();
            w18.LabelProp = global::Mono.Unix.Catalog.GetString("Start Emulator");
            w18.UseUnderline = true;
            w15.Add(w18);
            w14.Add(w15);
            this.startEmulatorButton.Add(w14);
            this.hbox1.Add(this.startEmulatorButton);
            global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.startEmulatorButton]));
            w22.Position = 1;
            w22.Expand = false;
            w22.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.createEmulatorButton = new global::Gtk.Button();
            this.createEmulatorButton.CanFocus = true;
            this.createEmulatorButton.Name = "createEmulatorButton";
            this.createEmulatorButton.UseUnderline = true;
            this.createEmulatorButton.Relief = ((global::Gtk.ReliefStyle)(2));
            // Container child createEmulatorButton.Gtk.Container+ContainerChild
            global::Gtk.Alignment w23 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            global::Gtk.HBox w24 = new global::Gtk.HBox();
            w24.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Image w25 = new global::Gtk.Image();
            w25.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
            w24.Add(w25);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            global::Gtk.Label w27 = new global::Gtk.Label();
            w27.LabelProp = global::Mono.Unix.Catalog.GetString("Create Emulator");
            w27.UseUnderline = true;
            w24.Add(w27);
            w23.Add(w24);
            this.createEmulatorButton.Add(w23);
            this.hbox1.Add(this.createEmulatorButton);
            global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.createEmulatorButton]));
            w31.Position = 2;
            w31.Expand = false;
            w31.Fill = false;
            this.vbox2.Add(this.hbox1);
            global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
            w32.Position = 2;
            w32.Expand = false;
            w32.Fill = false;
            w1.Add(this.vbox2);
            global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
            w33.Position = 0;
            // Internal child MonoDevelop.MonoDroid.Gui.DeviceChooserDialog.ActionArea
            global::Gtk.HButtonBox w34 = this.ActionArea;
            w34.Name = "dialog1_ActionArea";
            w34.Spacing = 10;
            w34.BorderWidth = ((uint)(5));
            w34.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new global::Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            global::Gtk.ButtonBox.ButtonBoxChild w35 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w34[this.buttonCancel]));
            w35.Expand = false;
            w35.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new global::Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            global::Gtk.ButtonBox.ButtonBoxChild w36 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w34[this.buttonOk]));
            w36.Position = 1;
            w36.Expand = false;
            w36.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 407;
            this.DefaultHeight = 300;
            this.Show();
        }
    }
}