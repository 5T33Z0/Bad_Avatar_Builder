![](https://github.com/user-attachments/assets/051a2bb2-64ef-4ddb-8417-89f191f85d8e)

# Bad Avatar Builder

## About
**Bad Avatar Builder** is a CLI tool for creating a Bad Avatar USB flash drive for the Xbox 360. It automates the process of formatting the USB drive, downloading required files, extracting them, and allowing the addition of homebrew applications. It's based on Kurniliya's fork of **BadBuilder** by Pdawg-bytes, which uses [**ABadAvatar**](https://github.com/shutterbug2000/ABadAvatar) instead of [BadUpdate](https://github.com/grimdoomer/Xbox360BadUpdate) for exploiting the Xbox 360, which currently is the easiest method for jailbreaking the Xbox 360.

All I did was add a new logo, compile an x64 executable since Kurniliya's  fork doesn't contain one, and wrote a [Setup Guide](BAD_AVATAR_SETUP.md).

## Usage
- Install [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Download Bad Avatar Builder from the [Releases](https://github.com/5T33Z0/Bad_Avatar_Builder/releases) section and unzip
- Run the .exe and follow the on-screen instructions to create the USB flash drive
- For detailed instructions, follow my [Bad Avatar Setup Guide](BAD_AVATAR_SETUP.md)

## Integrating BadUpdate 1.3
Bad Avatar 1.3 is the latest iteration of the Bad Avatar exploit for the Xbox 360. It improves the exploit's success rate to about 97% and speed (a few seconds). NarcejaLmao has managed to incorporate it into the Bad Avatar jailbreak.

To update your existing Bad Avatar USB flash drive to use the latest exploit, do the following:

- Download the latest release of [ANewAvatar](https://github.com/NarcejaLmao/ANewAvatar/releases)
- Extract it
- Replace the corresponding files on your existing Bad Avatar USB flash drive
- Done

> [!NOTE]
>
> I will try to incorporate this into Bad Avatar Builder at some point.

## Credits
- **Grimdoomer:** [BadUpdate](https://github.com/grimdoomer/Xbox360BadUpdate)
- **Pdawg-bytes:** [BadBuilder](https://github.com/Pdawg-bytes/BadBuilder)
- **Kurniliya:** [BadBuilder with A Bad Avatar](https://github.com/kurniliya/BadBuilder)
- **InvoxiPlayGames:** [FreeMyXe](https://github.com/FreeMyXe/FreeMyXe)
- **Byrom90:** [XeUnshackle](https://github.com/Byrom90/XeUnshackle)
- **Swizzy:** [Simple 360 NAND Flasher](https://github.com/Swizzy/XDK_Projects)
- **Team XeDEV:** [XeXMenu](https://www.se7ensins.com/downloads/xex-menu-1-2.22/)
- **Phoenix Team:** [Aurora Dashboard](https://phoenix.xboxunity.net/#/news)

---

<details>
<summary><b>Original BadBuilder README</b> (Click to reveal)</summary><br>

# BadBuilder
BadBuilder is a tool for creating a BadUpdate USB drive for the Xbox 360. It automates the process of formatting the USB drive, downloading required files, extracting them, and allowing the addition of homebrew applications.

## Features
### USB Formatting (Windows Only)
- Uses a custom FAT32 formatter that supports large USB drives (≥32GB).
- Ensures compatibility with the Xbox 360.

> [!NOTE]  
> Currently, the formatting feature is **Windows-only**. If you compile BadBuilder for another OS, it'll prompt you to manually format your target disk.

### Automatic File Downloading
- Detects and downloads the latest required files automatically.
- Recognizes previously downloaded files and reuses them by default.
- Allows specifying custom paths for required files if they are already on your system.
> [!IMPORTANT]  
> BadBuilder does not dynamically locate files inside ZIP archives. If your provided archive has a different folder structure than expected, the process will fail abruptly. Ensure your archive matches the expected format if specifying an existing copy.

### File Extraction & Copying
- Extracts all necessary files automatically.
- Prepares the USB drive for the BadUpdate exploit by copying all required files.

### Homebrew Support
- Allows adding homebrew applications by specifying their root folder.
- Prompts for the path of the entry point if it could not be automatically determined.
- Automatically searches for the entry point (`.xex`) file within the folder.
- If multiple `.xex` files are found, BadBuilder will prompt you to select the correct one.
- Copies all necessary files and patches the entry `.xex` using the downloaded XexTool.

## How to Use
1. **Launch the executable**. It will open inside of a Terminal window.
2. **Formatting (Windows Only):** BadBuilder will format your USB drive as FAT32, even if it’s larger than 32GB.
> [!CAUTION]
> Formatting a disk means that all data will be lost. Make sure you have selected the right drive before confirming the format. I am not responsible for any data loss.
3. **Download Files:** BadBuilder will fetch the required exploit files or let you specify an existing location.
4. **Extract Files:** BadBuilder will automatically extract everything needed.
5. **Select default program**: BadBuilder will prompt you to choose a program that BadUpdate will try and invoke, being either [FreeMyXe](https://github.com/FreeMyXe/FreeMyXe), or [XeUnshackle](https://github.com/Byrom90/XeUnshackle)
6. **Copy Files:** BadBuilder will copy all of the extracted files to the correct locations.
7. **Add Homebrew (Optional):**
    - Specify the root folder of your homebrew application (e.g., `D:\Aurora 0.7b.2 - Release Package`).
    - If no `.xex` files were located in the root folder, BadBuilder will prompt you for the path of the entry point.
    - BadBuilder will locate the `.xex` file inside.
    - If multiple `.xex` files exist, you’ll be prompted to choose the correct entry point.
    - First, all necessary files will be copied, then, the `.xex` file will be patched using **XexTool**.
        - This ensures that the original copy of the homebrew program will **not** be modified, as it is instead done in-place on the USB drive.

## Example Homebrew Folder Structure
If you want to add Aurora, you would select the **root folder**, like:

```
D:\Aurora 0.7b.2 - Release Package
```

Which contains:

```
Aurora 0.7b.2 - Release Package/
├── Data/
├── Media/
├── Plugins/
├── Skins/
├── User/
├── Aurora.xex
├── live.json
├── nxeart
```
BadBuilder will detect `Aurora.xex` as the entry point and patch it accordingly.

> [!IMPORTANT]  
> Homebrew apps which do not contain the entry point in the root folder will require you to manually enter the path of the entry point.

## Reporting Issues
If you encounter any problems, please create a new issue with details about your setup and the problem.

### Credits
- **Grimdoomer:** [BadUpdate](https://github.com/grimdoomer/Xbox360BadUpdate)
- **InvoxiPlayGames:** [FreeMyXe](https://github.com/FreeMyXe/FreeMyXe)
- **Byrom90:** [XeUnshackle](https://github.com/Byrom90/XeUnshackle)
- **Swizzy:** [Simple 360 NAND Flasher](https://github.com/Swizzy/XDK_Projects)
- **Team XeDEV:** XeXMenu

</details>
