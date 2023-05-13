<h1 align="center">

  Fiesta Heroes
  <br>
  Universal Launcher <img src="https://i.imgur.com/KuPp7CR.png" width = "32" height="32"></a>
  <br>  
  <img src="https://i.imgur.com/0GOTzNm.gif"></a>
  <h5><center>Built with <a href="https://github.com/adamhathcock/sharpcompress">SharpCompress</a> and <a href="https://github.com/MarioZ/MadMilkman.Ini">MadMilkman.Ini</a></center></h5>
</h1>

## Features

*   Works with all of our sets. TW2008, CN2012 and NA2016.
*   Extremely easy to setup without any coding knowledge.
*   Automatically check, download and extract patch archives.
*   Includes both server and client configuration files.
*   Allows modification of application settings through server-side configuration, eliminating the need to distribute a new executable.
*   Features a maintenance mode that can deactivate the start button through the server-side configuration.

## Requirements

To make your patch archives accessible to the public, you'll require a web server of some kind. This may include a VPS, dedicated server, cPanel, web storage, or even an FTP server. The crucial aspect is that you have a publicly accessible server to download your patches from, and that your application can read your server-side configuration file in the .ini format.

When using IIS as your web server, it is necessary to create a **MIME TYPE** entry for both the .INI file and .RAR archive.

```bash
.INI
text/plain

.RAR
application/x-rar-compressed
```


## Setup Information

#### Client Setup:
You will need to place the following files in the root directory of your client.
```bash
FiestaHeroes_UL.exe
MadMilkman.Ini.dll
SharpCompress.dll
```

Afterward, you must also copy this folder into your root directory, ensuring that you maintain the folder structure by copying and pasting the folder.
```bash
reslauncher/launcher.ini
```

We will now proceed to edit your launcher.ini file:
```bash
[Setup]
PatchServerLocation=http://127.0.0.1/
PatchVersion=0
```

Change ```PatchServerLocation=``` to the location where you're hosting your patch files.
For example: 
```bash
PatchServerLocation=http://fiestaheroes.com/
```

#### Server Setup:
Navigate to your wwwroot folder and copy the contents of the folder. Paste the copied files into the root directory of your web server. By default, patch archives are stored in the ```/patches``` directory, although this location can be modified in the server-side configuration file.

Next, open your ```Config.ini``` file. Comments have been made to help explain what each section is for.
```bash
[Application Settings]
Name=FH: Universal Launcher

; Image resolution: 500x95
Banner=https://i.imgur.com/76k1Wav.jpg

[Archive Settings]
; The FileName pertains to the start of the archive name. When creating your patches, append the version number after the FileName. For instance: patch1.rar. 
FileName=patch

; When creating the archive, it is essential to use RAR4 format (This option can be selected in WinRAR during the creation of the archive).
; Technically, you can assign any file extension of your preference, as long as it's still created with the RAR4 format. For instance, you may choose to use ".xkl" as an extension.
Extension=.rar

[Version]
; This pertains to version control for your patch files. For instance, if you have the following patch files: patch1.rar, patch2.rar, and patch3.rar, then your version number would be 3.
; Example: PatchVersion=3
PatchVersion=0

[Game IP]
; This will be the game server IP the Fiesta.bin will start with.
IP=127.0.0.1

[Login Port]
Port=9010

[Executable]
File=Fiesta.bin

[Download Directory]
Location=patches

[Control]
; Modify this setting to deactivate the start button while performing maintenance on your server.
; 1 = Maintenance mode is enabled.
MaintenanceMode=0
```
#### Notes:
Ensure to maintain the identical folder structure as your client when creating your patch archive.
Suppose you intend to patch the ```ItemInfo.shn file```, for instance. In that case, you must ensure that your patch1.rar file appears as follows: ```ressystem/ItemInfo.shn```.

Also, if you don't know how to enable RAR4 compression, here is a quick [tutorial](https://techdows.com/2017/08/winrar-use-rar4-format-default-instead-rar-5-0.html).

<h2 align="center">
  <br>
  <a href="https://fiestaheroes.com/"><img src="https://i.imgur.com/t3PBKnc.png" width="500"></a>
  <br>
  <br>
  Development • Documentation • Preservation
  <br>
</h1>
