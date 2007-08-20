LIBRARY_NAME=	gtksourceview2-sharp
LIBRARY=	$(LIBRARY_NAME).dll
APIS=		gtksourceview-api.xml

ASSEMBLIES=	/pkg:gnome-sharp-2.0

EXTRA_DIST = $(sources) $(customs) Gtk.metadata gtksourceview-api.raw AssemblyInfo.cs.in

DISTCLEANFILES = AssemblyInfo.cs

noinst_DATA = gtksourceview2-sharp.dll

apidir = $(gtksharp_prefix)/share/gapi-2.0
api_DATA = gtksourceview-api.xml

all: $(LIBRARY)

gtksourceview-api.xml:
	cp $(srcdir)/gtksourceview-api.raw gtksourceview-api.xml
	chmod u+w gtksourceview-api.xml
	$(GAPI_FIXUP) --api=gtksourceview-api.xml --metadata=$(srcdir)/Gtk.metadata

generated-stamp: $(APIS) $(customs) $(sources) Gtk.metadata
	$(GAPI_CODEGEN) $(GTK_SHARP_CFLAGS) --generate $(APIS) \
	--outdir=generated --customdir=. --assembly-name=gtksourceview2-sharp && touch generated-stamp

sources = \
GtkSourceView.cs

build_sources = $(addprefix $(srcdir)/, $(sources)) AssemblyInfo.cs

customs = \
Global.custom \
SourceBuffer.custom \
SourceLanguage.custom \
SourceLanguageManager.custom \
SourceStyleScheme.custom \
SourceTagTable.custom

build_customs = $(addprefix $(srcdir)/, $(customs))

gtk-sharp.snk: $(top_srcdir)/gtk-sharp.snk
	cp $(top_srcdir)/gtk-sharp.snk .

$(LIBRARY): generated-stamp $(build_sources) gtk-sharp.snk
	$(CSC) /unsafe /target:library $(ASSEMBLIES) \
	generated/*.cs $(build_sources) -out:$(LIBRARY)

CLEANFILES = $(LIBRARY) generated/*.cs generated-stamp gtksourceview-api.xml gtk-sharp.snk

install-data-local:
	echo "$(GACUTIL) /i $(LIBRARY) /f $(GACUTIL_FLAGS)";  \
	$(GACUTIL) /i $(LIBRARY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(LIBRARY_NAME) $(GACUTIL_FLAGS)"; \
	$(GACUTIL) /u $(LIBRARY_NAME) $(GACUTIL_FLAGS) || exit 1;
