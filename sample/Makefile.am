TEST=$(builddir)/SourceViewTest.exe

GSVLIB=$(builddir)/gtksourceview2-sharp.dll
GSVLIBBUILT=$(top_builddir)/gtksourceview/gtksourceview2-sharp.dll

all: $(TEST)

$(TEST): $(srcdir)/SourceViewTest.cs $(GSVLIB)
	$(CSC) -debug -out:$@ $(srcdir)/SourceViewTest.cs -r:$(GSVLIB) -pkg:gtk-sharp-2.0

$(GSVLIB): $(GSVLIBBUILT)
	cp $(GSVLIBBUILT) $(builddir)
	cp $(GSVLIBBUILT).config $(builddir)

CLEANFILES = $(TEST) $(TEST).mdb $(GSVLIB)*
EXTRA_DIST = SourceViewTest.cs
