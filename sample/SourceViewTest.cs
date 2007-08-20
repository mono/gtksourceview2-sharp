using System;
using System.IO;
using Gtk;
using GtkSourceView;

class SourceViewTest
{
	static string filename;

	static void Main (string[] args)
	{
		if (args.Length != 1 || !File.Exists (args[0]))
			PrintUsage ();
		filename = args[0];

		Application.Init ();
		new SourceViewTest ();
		Application.Run ();
	}

	static void PrintUsage ()
	{
		Console.WriteLine ("usage: SourceViewTest.exe <csfile>");
		Environment.Exit (0);
	}

	SourceViewTest ()
	{
		Window win = new Window ("SourceView test");
		win.SetDefaultSize (600, 400);
		win.WindowPosition = WindowPosition.Center;
		win.DeleteEvent += new DeleteEventHandler (OnWinDelete);
		win.Add (CreateView ());
		win.ShowAll ();
	}

	ScrolledWindow CreateView ()
	{
		ScrolledWindow sw = new ScrolledWindow ();
		SourceView view = new SourceView (CreateBuffer ());
		sw.Add (view);
		return sw;
	}

	SourceBuffer CreateBuffer ()
	{
		SourceLanguagesManager manager = new SourceLanguagesManager ();
		SourceLanguage lang = manager.GetLanguageFromMimeType ("text/x-csharp");

		SourceBuffer buffer = new SourceBuffer (lang);
		buffer.Highlight = true;
		StreamReader sr = File.OpenText (filename);
		buffer.Text = sr.ReadToEnd ();
		sr.Close ();
		return buffer;
	}

	void OnWinDelete (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

