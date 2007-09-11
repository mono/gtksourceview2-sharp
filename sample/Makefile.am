TEST = SourceViewTest.exe
GSVLIB=gtksourceview2-sharp.dll
GSVLIBPATH=$(top_builddir)/gtksourceview/$(GSVLIB)

all: $(TEST)

$(TEST): $(srcdir)/SourceViewTest.cs $(GSVLIB)
	$(CSC) -debug -out:$@ $(srcdir)/SourceViewTest.cs -r:$(GSVLIB) -pkg:gtk-sharp-2.0

$(GSVLIB): $(GSVLIBPATH)
	cp $(GSVLIBPATH) .
	cp $(GSVLIBPATH).config .

CLEANFILES = $(TEST) $(TEST).mdb $(GSVLIB)*
EXTRA_DIST = SourceViewTest.cs
