# Space Madness

This is a repository for the Open-source version of the game Space Madness.

![Game](RepositoryFiles/space_madness.gif)

Game page: https://arti32lehtonen.itch.io/space-madness

**Attention!**
This is an obfuscated version of the project.
Some of the original assets have unsuitable licences for open source.
I replaced such assets with the generic analogues.

An example of differences in versions is displayed below:
![Original](RepositoryFiles/original_game.png)
![OpenSource](RepositoryFiles/open-source-version.png)

You can find lists of replaced assets here:
* [Images](https://github.com/arti32lehtonen/space-madness/blob/main/Assets/Images/README.md)
* [Sound Effects](https://github.com/arti32lehtonen/space-madness/blob/main/Assets/Sounds/SoundEffects/README.md)

## Build

To build the project you need to:
1. Clone the repository

   `git clone https://github.com/arti32lehtonen/space-madness.git`
2. Open the project using UnityHub (original Unity version is 2022.2.9)
3. Import TMP Essentials and TMP Examples & Extras packages
4. Build the project

## How to make changes

You can use your assets without changing project structure.
All you need to do is replace the following files using the same names:
* `Assets/Sounds/SoundEffects/*` - edit sound effects
* `Assets/Sounds/Music/*` - edit music themes
* `Assets/Images/*` - edit images
* `Assets/Fonts/*` - edit game fonts

If you want to restore the original build of the game, you have to:
* Download all assets from the replaced assets lists (some of them are paid assets!)
* Replace all replaced assets with the original ones (to make this process simpler, the original names of the files were preserved)