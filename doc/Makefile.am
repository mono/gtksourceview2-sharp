if ENABLE_MONODOC
TARGETS = gtksourceview-sharp-docs.zip gtksourceview-sharp-docs.tree gtksourceview-sharp-docs.source
docsdir = `$(PKG_CONFIG) --variable sourcesdir monodoc`
docs_DATA = $(TARGETS)
else
TARGETS = 
docsdir = $(datadir)
docs_DATA =
endif

gtksourceview-sharp-docs.zip gtksourceview-sharp-docs.tree: $(srcdir)/en/*/*.xml $(srcdir)/en/*.xml
	$(MDASSEMBLER) --ecma $(srcdir)/en -o gtksourceview-sharp-docs

update:
	rm -Rf ./en/GtkSourceView/* ./en/GtkSharp.GtksourceviewSharp/*
	$(MONODOCER) -updateto:./en -path:. -assembly:../gtksourceview/gtksourceview-sharp.dll

CLEANFILES = gtksourceview-sharp-docs.zip gtksourceview-sharp-docs.tree

EXTRA_DIST = $(TARGETS)

dist-hook:
	mkdir -p $(distdir)/en
	cp $(srcdir)/en/*.xml $(distdir)/en/
	mkdir -p $(distdir)/en/GtkSourceView
	cp $(srcdir)/en/GtkSourceView/*.xml $(distdir)/en/GtkSourceView/


push:
	scp gtksourceview-sharp-docs.* root@www.go-mono.com:/usr/lib/monodoc/sources/
