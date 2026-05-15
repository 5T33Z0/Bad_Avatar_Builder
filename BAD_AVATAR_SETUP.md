# Bad Avatar Builder – Xbox 360 Setup Guide

> [!WARNING]
> 
> **Back up your NAND before proceeding.** This process modifies your Xbox 360's software environment. A NAND backup lets you restore your console to its original state if anything goes wrong. Without one, a failed or botched exploit may leave your console unrecoverable. Search for NAND backup tutorials specific to your Xbox 360 model before continuing.

## 1. Requirements

### PC
- 64-bit Windows 10 or 11
- File archiver: [7-Zip](https://www.7-zip.org) or WinRAR
- [.NET Runtime 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or newer
- USB flash drive *(will be formatted — back up any data on it first)*

### Xbox 360
- Firmware version **2.0.17559.0** — check via **Settings > System Info**
  - If needed, update via USB: [Xbox 360 System Updates](https://support.xbox.com/en-US/help/xbox-360/console/system-updates-info) → *How to update* → *Copy to a USB flash drive*
- **Auto sign-in disabled**: Settings → Profile → Sign-in Preferences

## 2. Creating the Bad Avatar USB Flash Drive

### Preparation

1. Download `Aurora 0.7b.2 - Release Package.rar` from [phoenix.xboxunity.net](https://phoenix.xboxunity.net/#/news), extract it, and rename the folder to **`Aurora`**.
2. Download `Bad_Avatar-Builder_x64.zip` from the [GitHub Releases page](https://github.com/5T33Z0/Bad_Avatar_Builder/releases) and extract it.
3. Plug in your USB flash drive.

### Running the Builder

4. Double-click `Bad_Avatar-Builder.exe`.
5. Press **Enter** at the welcome screen:<br><img width="711" height="373" alt="01" src="https://github.com/user-attachments/assets/ca83170b-b8e8-469e-807f-a3144a9c4924" />
6. Select your USB flash drive from the list and press **Enter**:<br><img width="720" height="397" alt="02" src="https://github.com/user-attachments/assets/4ccefb2b-da21-46ea-a7fd-f6a966b9fe28" />
7. Type `y` and press **Enter** to confirm formatting:<br> <img width="831" height="386" alt="03" src="https://github.com/user-attachments/assets/98524016-9757-404e-ab3d-8b97f6598a15" />
8. Press **Enter** to begin downloading required files:<br> <img width="710" height="512" alt="04" src="https://github.com/user-attachments/assets/52328633-6c36-4c8f-a23e-8158b5455486" />
9. Wait for all necessary files to download:<br><img width="721" height="512" alt="05" src="https://github.com/user-attachments/assets/0fe3f4f4-9644-46bc-baee-3e346217d34b" />
10. Select your exploit — **XeUnshackled** is recommended — and press **Enter**:<br> <img width="709" height="431" alt="06" src="https://github.com/user-attachments/assets/49bd6331-2065-41d2-a0ae-0e6daa374bba" />
11. Wait for the process to complete:<br> <img width="709" height="376" alt="07" src="https://github.com/user-attachments/assets/511b2c56-ffe4-4190-8805-2932086df70e" />
12. Type `y` and press **Enter** to add Homebrew programs:<br> <img width="702" height="375" alt="08" src="https://github.com/user-attachments/assets/e13836ed-2d6b-4f24-8d01-8fc609a576a3" />
13. Open File Explorer, navigate to your **`Aurora`** folder, and copy the full path from the address bar (double-click the address bar):<br> <img width="661" height="312" alt="10" src="https://github.com/user-attachments/assets/a5ea56e5-077c-4b86-a2cd-9b69ad6f2f38" />
14. Paste the path into the Command Prompt window and press **Enter**:<br> <img width="724" height="413" alt="11" src="https://github.com/user-attachments/assets/85c1d08d-6198-47b0-838b-aefe9decbc6d" />
15. Use the **↓ arrow key** to highlight **Finish & Save** and press **Enter**:<br> <img width="714" height="447" alt="13" src="https://github.com/user-attachments/assets/ea461f3a-9b02-42df-b0d2-35a6a62dacb5" />
16. Wait for the files to be copied to the USB flash drive:<br> <img width="712" height="512" alt="16" src="https://github.com/user-attachments/assets/d06e4848-5a77-4f60-aef1-6a5cddebe237" />

### Configuring `launch.ini`

17. Open the root of the USB flash drive in File Explorer and open **`launch.ini`** in Notepad or any text editor:<br><img width="789" height="318" alt="17" src="https://github.com/user-attachments/assets/cf50c5ad-38b5-4186-9490-359378a43280" />
18. On **line 37**, find the `Default =` entry and set it to:
    ```
    Usb:\Apps\Aurora\Aurora.xex
    ```
    **Screenshot**: <br> <img width="1200" height="800" alt="18" src="https://github.com/user-attachments/assets/59f3b683-1ae5-49d4-8b90-236fc7299f82" />
19. Save the file. The USB drive is ready.

## 3. Applying the Exploit

1. Safely eject the USB flash drive from your PC.
2. Insert it into a USB port on your Xbox 360.
3. Power on the console and wait — the exploit typically takes 10 seconds to about a minute.
4. A success animation will appear on screen when the exploit completes:<br>![XeUnshackle Banner](https://github.com/user-attachments/assets/af37d4ae-4ff6-4175-8f81-47869ff63ed6)
5. Press the **Back** button on your controller to continue loading into the Aurora Dashboard.

## 4. Configuring the Aurora Dashboard

With your Xbox 360 now unshackled, set up Aurora to browse and launch content. Two resources:

- **Written guide**: [Xbox 360 Bad Avatar / Bad Builder Guide (2026)](https://itemlevel.net/xbox-360-abadavatar-badbuilder-guide-in-2026/#setting-up-your-aurora-dashboard)
- **Video tutorial**: [MrMario2011 on YouTube](https://www.youtube.com/watch?v=S4xyqbkK51w&t=2368s)
