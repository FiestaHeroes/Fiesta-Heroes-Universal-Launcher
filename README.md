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
*   Server & client configuration files.
*   The ability to change the application settings from the server-side configuration, without having to distribute a new executable.
*   Maintenance mode. You can disable the start button from the server-side configuration.

## Requirements

You will need some type of web server to publicly host your patch archives. This can be a VPS, dedicated, cpanel, web storage or even a FTP server. Just something you can publicly download your patches from, and the application can parse your server-side configuration (.ini) file. 

## Setup Information

#### Client Setup:
The following files will need to be in your root directory of the client.
```bash
FiestaHeroes_UL.exe
MadMilkman.Ini.dll
SharpCompress.dll
```

Next, you will need to copy this folder into your root directory as well. Please keep the folder structure the same, so just copy & paste the folder.
```bash
reslauncher/launcher.ini
```

Now, let's edit your launcher.ini file:
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
Open your wwwroot folder, and copy & paste the contents of the folder into your root directory of the web server.
Patch archives by default go into ```/patches```. This location can be changed in the server-side configuration file.

Next, open your ```Config.ini``` file. Comments have been made to help explain what each section is for.
```bash
[Application Settings]
Name=FH: Universal Launcher
; Image resolution: 500x95
Banner=https://i.imgur.com/76k1Wav.jpg

[Archive Settings]
; FileName is the beginning of the archive. When you create your patches, include the version afterwards. Example: patch1.rar 
FileName=patch
; The archive must be built with RAR4 (The option can be ticked in WinRar when building)
; You can technically make this whatever extension you like, while making sure it's still built with the RAR4 format. So, it can be .xkl for example.
Extension=.rar

[Version]
; Version control for your patch files. So, if you have following: patch1.rar, patch2.rar and patch3.rar your version would be 3.
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
; Change this to disable the start button during your server maintenance.
; 1 = Maintenance mode is enabled.
MaintenanceMode=0
```
> **Notes:**
> When creating your patch archive, please make sure to keep the same folder structure as your client.
> Let's say you're going to patch the ItemInfo.shn file for example. You want your patch1.rar to look like this: ```ressystem/ItemInfo.shn```
>
> Also, if you don't know how to enable RAR4 compression, here is a quick [tutorial](https://techdows.com/2017/08/winrar-use-rar4-format-default-instead-rar-5-0.html).

<h2 align="center">
  <br>
  <a href="https://fiestaheroes.com/"><img src="https://i.imgur.com/t3PBKnc.png" width="500"></a>
  <br>
  <br>
  Development • Documentation • Preservation
  <br>
</h1>
