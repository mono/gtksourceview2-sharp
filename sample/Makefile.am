TEST = SourceViewTest.exe
PRINT = PrintSample.exe

EXTRA_DIST = SourceViewTest.cs PrintSample.cs
CLEANFILES = $(TEST) $(TEST).mdb $(PRINT) $(PRINT).mdb

all: $(TEST) $(PRINT)

$(TEST): $(srcdir)/SourceViewTest.cs
	$(CSC) -out:$@ $(srcdir)/SourceViewTest.cs -r:../gtksourceview/gtksourceview-sharp.dll -pkg:gtk-sharp-2.0

$(PRINT): $(srcdir)/PrintSample.cs
	$(CSC) -out:$@ $(srcdir)/PrintSample.cs -r:../gtksourceview/gtksourceview-sharp.dll -pkg:gtk-sharp-2.0 -pkg:gnome-sharp-2.0

