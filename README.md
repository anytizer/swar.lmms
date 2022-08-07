# swar
Convert SARGAM Notes to English Scales __and__ XPT Pattern File for [LMMS](https://lmms.io/).

Originally, this is an temporary/alternative solution for [Custom Piano Labels](https://github.com/LMMS/lmms/issues/6162).
But the binary file can be used as an independent software as well.

This source code is put into public domain.

## Configurations

### Read/Write Directory
[Configuration File](swar/configs/Configurations.cs) reads a directory to export LMMS .xpt files.
Create a Windows directory `d:/projects/lmms.xpt/`.
Your swar executable files can be anywhere.

A `#` character is a comment, when used in the front of the line.
Make sure that the full path is valid, and sargam note exists.
Recommended file name is: `<project>/notations/notations-sargams.txt`.

## Important Files

* XML Handler, [see here](swar/libraries/XMLHandler.cs).
* File Formatter, [see here](swar/libraries/Formatter.cs).
* SARGAMs Replacer, [see here](swar/libraries/Replacer.cs).

# Software Interface
![SWAR Interface](interface.png)

Click on the image for high resolution clarity.

* Left: Sargam Notes (Paste your unformatted sa, re, ga, ma, ... notes)
* Right: English scales will be auto converted and formatted.

It will write `swar-*.xpt` chunk files when the sargam notes change.
You can later import these xpt xml files directly in the pianoroll of LMMS.

This is a work in progress, and any content, documentation, source code, compiled binaries, etc. are subject to change.
