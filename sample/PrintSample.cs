using System;
using Gtk;
using GtkSourceView;
using Gnome;

class PrintSample
{
	SourceView tv;
	SourceBuffer sb;
	Gtk.Window win;
	
	static void Main ()
	{
		new PrintSample ();
	}
	
	PrintSample ()
	{
		Application.Init ();
		win = new Gtk.Window ("Print sample");
		win.SetDefaultSize (400, 300);
		win.WindowPosition = WindowPosition.Center;
		win.DeleteEvent += new DeleteEventHandler (OnWinDelete);
		
		VBox vbox = new VBox (false, 0);
		win.Add (vbox);
		
		tv = new SourceView ();
		SourceLanguagesManager slm = new SourceLanguagesManager ();
		sb = new SourceBuffer (slm.GetLanguageFromMimeType ("text/x-csharp"));
		sb.Highlight = true;
		tv.Buffer = sb;
		tv.Buffer.Text = "using System; //test\n\nnamespace Foo\n{\n}";
		vbox.PackStart (tv, true, true, 0);

		Button print = new Button (Gtk.Stock.Print);
		print.Clicked += new EventHandler (OnPrintClicked);
		vbox.PackStart (print, false, true, 0);	
		
		win.ShowAll ();
		Application.Run ();
	}
	
	void OnPrintClicked (object o, EventArgs args)
	{
		// create the job using default print configuration
		SourcePrintJob spj = new SourcePrintJob (null);

		// quickly setup the buffer, font and wrapping
		// FIXME: should be SetupFromView (view);
		spj.upFromView = tv;

		// print line numbers every 5 lines
		spj.PrintNumbers = 5;

		// print a header with the title centered
		spj.HeaderFooterFont = "Sans Regular 12.0";
		spj.SetHeaderFormat (null, "title", null, true);
		spj.PrintHeader = true;

		// print the page number in the page bottom
		spj.SetFooterFormat (null, null, "Page N of Q", true);
		spj.PrintFooter = true;

		// print the whole buffer and return the result
		Gnome.PrintJob pj = spj.Print ();
		spj.Dispose ();

		PrintDialog dialog = new PrintDialog (pj, "Print Test", 0);
		dialog.TransientFor = win;
		dialog.Modal = true;
		dialog.DestroyWithParent = true;
		int response = dialog.Run ();
		
		if (response == (int) PrintButtons.Cancel) {
			Console.WriteLine ("Canceled");
			dialog.Hide ();
			dialog.Dispose ();
			return;
		}

		switch (response) {
			case (int) PrintButtons.Print: 
				pj.Print (); 
				break;
			case (int) PrintButtons.Preview:
				new PrintJobPreview (pj, "Print Test").Show ();
				break;
			default:
				Console.WriteLine ("unknown reponse {0}", response);
				break;
		}

		dialog.Hide ();
		dialog.Dispose ();
	}
	
	void OnWinDelete (object o, DeleteEventArgs args)
	{
		Application.Quit ();
	}
}
