# swar.lmms
Convert SARGAM Notes to English Scales __and__ XPT Pattern File for [LMMS](https://lmms.io/).

Originally, this is an alternative solution for [Custom Piano Labels](https://github.com/LMMS/lmms/issues/6162).
But the binary file can be used as an independent software as well. It is NOT affiliated with any vendors.

## Configurations
[Configuration File](swar/configs/Configurations.cs) reads a directory to export LMMS .xpt files.
Create a Windows directory `d:/projects/lmms.xpt/`.
Your swar executable files can be anywhere.

## Important Files

* XML Handler, [see here](swar/libraries/XMLHandler.cs).
* File Formatter, [see here](swar/libraries/Formatter.cs).
* SARGAMs Replacer, [see here](swar/libraries/Replacer.cs).

# Software Interface
![SWAR Interface](interface.png)

Click on the image for high resolution clarity.

* Left: Sargam Notes (Paste your unformatted sa, re, ga, ma, ... notes) eg. [as in here](https://github.com/anytizer/melodies.lmms/blob/main/melodies/%E0%A4%A4%E0%A5%80%E0%A4%9C%20%E0%A4%AD%E0%A4%BE%E0%A4%95%E0%A4%BE%20-%20%E0%A4%AA%E0%A5%81%E0%A4%B0%E0%A4%BE%E0%A4%A8%E0%A5%8B/notations/notations-sargams.txt)
* Right: English scales will be auto converted and formatted.

It will write `swar-*.xpt` chunk files when the sargam notes change.
You can later import these xpt xml files directly in the pianoroll of LMMS.

Lately, ["pattern" has been changed with "midiclip"](https://github.com/LMMS/lmms/issues/5592) in the xml.
So make sure you use a nightly build. eg. [lmms-1.3.0-alpha.1.221+](https://nightly.link/LMMS/lmms/workflows/build/master/mingw64.zip) from its [Nightly Build](https://nightly.link/LMMS/lmms/workflows/build/master).

This is a work in progress, and any content, documentation, source code, compiled binaries, etc. are subject to change.
