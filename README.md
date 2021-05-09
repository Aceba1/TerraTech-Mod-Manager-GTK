# [TerraTech Mod Manager](https://forum.terratechgame.com/index.php?threads/terratech-mod-manager.17208/)
Recreation of my mod manager for [TerraTech](https://terratechgame.com)

## Installing
[Most-recent release](https://github.com/Aceba1/TerraTech-Mod-Manager-GTK/releases/latest)

### For Windows users:
* Download & unzip `TTMM.zip`
* Make sure to install [Mono 32-bit](https://download.mono-project.com/archive/6.8.0/windows-installer/mono-6.8.0.123-gtksharp-2.12.45-win32-0.msi) and [GTK# for .NET](https://xamarin.azureedge.net/GTKforWindows/Windows/gtk-sharp-2.12.45.msi) (both found [here](https://www.mono-project.com/download/stable/#download-win))
* Double-click `TerraTechModManager-GTK.exe`. Be aware that Windows SmartScreen may interfere, either mark this executable as trusted ~~or disable SmartScreen~~

### For Mac OS users:
* Download & unzip `TTMM.zip`
* Ensure [Mono](https://www.mono-project.com/download/stable/#download-mac) is installed
* *Control-click* the `Execute.command` file to run it the first time, otherwise Finder will prohibit it


### For Linux users:
* Download & unzip `TTMM.zip`
* Ensure the `mono-complete` package is installed (instructions [here](https://www.mono-project.com/download/stable/#download-lin))
* Mark `Execute.sh` as an executable, with `chmod +x Execute.sh`, or with user interface if applicable
* Run with `./Execute.sh`, or with interface
  * It is possible to alternatively use `mono TerraTechModManager-GTK.exe`
  * You can create a desktop entry to also run this, for example, with [Alacarte](https://www.lifewire.com/ubuntu-alacarte-menu-editor-2205584)
## Note
- Mac support has been added! (ver. [0.3.0](https://github.com/Aceba1/TerraTech-Mod-Manager-GTK/releases/tag/0.3.0))
- Compiling through Monodevelop might produce an executable that does not function on Windows. Visual Studio Community is still necessary.

- The developers are working towards official mod support, meaning TTMM may be left behind or integrated.
