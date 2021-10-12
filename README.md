# swar
Convert SARGAM Notes to English Scales and XPT Pattern Files.

## ReadWriteDirectory
[Configuration File](swar/configs/Configurations.cs) reads a directory to export LMMS .xpt files.

## Sargams: File List
When the application starts, it reads the sargam notations from `sargams.txt` file.
Each line mentions a full path of a sargam note.
A `#` character can be used as a comment, when used in the front of the line.

## To use with LMMS Software
The purpose of this application is to produce LMMS based XML Pattern File named .xpt.
Every sargam file it reads will be converted into lmms.xpt.
For more details on LMMS, [visit here](https://lmms.io/).

For more details on XML Handler, [see here](swar/libraries/XMLHandler.cs).
