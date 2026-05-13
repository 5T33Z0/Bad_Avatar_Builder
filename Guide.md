# Bad Avatar Builder Instructions

## 1. Requirements

### PC

- x64 compatible PC with Windows 10/11 installed
- File unarchiver like 7zip or WinRAR
- [.NET Runtime 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or newer installed
- USB Flash Drive (will be formatted during the process)

### Xbox 360

- Xbox 360 with Firmware Version 175559 (Chec System Info):![](https://media.itemlevel.net/wp-content/uploads/2026/04/09144517/firefox_5jnZLBJBX5.jpg)
- You can get it here: https://support.xbox.com/en-US/help/xbox-360/console/system-updates-info (check the "How to update section" and select the "Copy to a USB flash drive" option)
- Disable Auto-Sign in (Settings > Profile > Sign-in Preferences)

## 2. Creating the Bad Avatar USD flash drive

1. Download the `Aurora 0.7b.2 - Release Package.rar`  Dashboard from [phoenix.xboxunity.net](https://phoenix.xboxunity.net/#/news) unpack it into its own folder and rename the Folder to "Aurora"
2. Download the Bad_Avatar-Builder_x64.zip from the [Releases](https://github.com/5T33Z0/Bad_Avatar_Builder/releases) section and unzip it
3. Connect the USB flsh drive you want to use to your computer
4. Double-click `Bad_Avatar-Builder.exe` to run it
5. Hit Enter:<br> ![alt text](Screenshots/01.PNG)
6. Select the removable drive: <br> ![alt text](Screenshots/02.PNG) and hit Enter
7. Confirm formattimg of the USB flash drive with `y`: ![alt text](Screenshots/03.PNG)
8. Next, hit Enter: <br>![alt text](Screenshots/04.PNG)
9. This will download all the necessary files: <br>![alt text](Screenshots/05.PNG)
10. Next, select the Exploit (XeUnshackled is recommended) and press Enter:<br> ![alt text](Screenshots/06.PNG)
11. Wait a bit…:<br>![alt text](Screenshots/07.PNG)
12. Once that's done, enter `y` to add Homebrew Programs: <br>![alt text](Screenshots/08.PNG)
13. Open File Explorer, navigate to the `Aurora` folder and copy the file path as shown in this example (double-click the address bar):<br>![alt text](Screenshots/10.PNG)
14. Paste it into the CMD window:<br> ![alt text](Screenshots/11.PNG)
15. Use the arrow down key to navigate to "Finish & Save" and press Enter :<br> ![alt text](Screenshots/13.PNG)
16. Next, the App will be copied over to the USB flash drive and completed:<br> ![alt text](Screenshots/16.PNG)
17. Next, navigate to the root of USB flash drive and open the `launch.ini` file with Notepad or an Editor of your choice:<br> ![alt text](Screenshots/17.PNG)
18. In Line 37, where it says `Default =`, add the path to the Aurora Dashboard:<br>![alt text](Screenshots/18.PNG)
    ```text
    Usb:\Apps\Aurora\Aurora.xex
    ```
19. Done

## 3. Applying the Exploit

- Take the USB flash drive out of your PC
- Put it in one of the USB ports on your Xbox 360
- Turn the console on and wait for the exploit to finish. It can take anything from 10 seconds to a about a minute
- Once the exploit has succeeded, you will see the following animation:<br> ![XeUnshackle_Banner](https://github.com/user-attachments/assets/af37d4ae-4ff6-4175-8f81-47869ff63ed6)
- In the next screen, press the `Back` button on your controller to continue loading to the Aurora Dashboard

## 4. Configuring the Aurora Dashboard

Once your Xbox360 is *unshackled*, you have to configure the Aurora Dashboard so you can add content and have it displayed. To do so, You can follow [this article](https://itemlevel.net/xbox-360-abadavatar-badbuilder-guide-in-2026/#setting-up-your-aurora-dashboard) or check MrMario2011's great YouTube Tutorial: 

[![Watch the video](https://i.ytimg.com/an_webp/S4xyqbkK51w/mqdefault_6s.webp?du=3000&sqp=CJSTk9AG&rs=AOn4CLDZoPPuZ8y62M6p8N0sVa2MHTCBnA)](https://www.youtube.com/watch?v=S4xyqbkK51w&t=2368s)

Enjoy!
