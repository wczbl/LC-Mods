# About this repo
So, you want to add your very own boombox songs but don't want to use other mods to do it? If that's the case, ask and you shall receive. I assume you have watched [this video](https://www.youtube.com/watch?v=4Q7Zp5K2ywI) and have gotten somewhat an understanding of how C# works.

# Requirements
The things you need in order to get started are the following:
<li>IDE: An integrated development enviroment is useful due to the fact that it provides an auto complete, identifies incorrect syntax, and much more. I personally prefer VS2022</li>
<li>Git Bash: This is required to clone <a href="https://github.com/EvaisaDev/LethalCompanyUnityTemplate">Evaisa's repository</a></li>
<li>Lethal Company Unity Template: The steps on how to set this up are on her README page.</li>
<li>Unity Hub: This is required to use Unity 2022.3.9f1.</li>
<li>Unity 2022.3.9f1: The Unity version Zeekerss used to make Lethal Company.</li>

# Setting Up
From this point on, I assume you have Unity installed and that you have the default empty scene open. Create two folders, one called "Editor"(which is where we'll store the code to create the asset bundles), and the other one should be called whatever you prefer, i.e. in my case, I called it "BoomboxSongs". Inside the BoomboxSongs folder is where you store all the albums/songs that you want the boombox to play. In my case, I've specifically chosen the radio soundtrack from Sons of The Forest. Once you've placed all the audio files inside the folder, it's time to make the asset bundle. Either hit CTRL + A or manually select all your songs. At the bottom, there's a text simply titled "Asset Bundle" and next to it is a dropdown bar with the current selection(the first one) being "None". Click on "None -> New..." and then name it whatever you'd like. When you've picked a name you can exit the text field by pressing enter. Next up, create a C# script called CreateAssetBundles and insert the following code:
<p><image src="https://github.com/wczbl/LC-Mods/assets/130032524/b95525b7-b30c-4a0f-83cb-409ec4160659"></image></p>
All it does is that it creates an asset bundle folder(if it doesn't exist) and then it builds the asset bundles once the menu item has been pressed. You can now build assets by going to "Assets -> Build-AssetBundles". Once it has finished building, locate the AssetBundles inside windows file explorer(or whichever file explorer you have - it really depends on what operating system you have. That's pretty much it. Let's go ahead and create a Visual Studio project.

# Getting Started
Here's the project structure that I have. PluginInfo simply holds the guid, name, and version of the plugin.
<p><image src=https://github.com/wczbl/LC-Mods/assets/130032524/48e9729e-438d-4465-a5af-55768812d6e8></image></p>
These are all the DLLs we need to reference.
<p><image src="https://github.com/wczbl/LC-Mods/assets/130032524/2440e460-8af3-4226-9b4d-7181d7697f3f"></image></p>

# Code 
I prefer to have a separate class for the plugin information because it keeps things clean and much more accessible, in my opinion.
![image](https://github.com/wczbl/LC-Mods/assets/130032524/ba793b87-eaa0-48eb-8901-f4e971eba026)
<p>And for our plugin class, this is the code we need:</p>

![image](https://github.com/wczbl/LC-Mods/assets/130032524/dda832e5-4828-440b-b888-c3e7d5168600)
All it does is:
- Creates a log source - even though the Base plugin has a logger, it is crucial to understand that the logger in question is a private field, meaning that, it's not accessible to other classes. Although this one is private, too, you'd normally want the log source to be either `public static` or just `public`. In my case, I was too lazy to change this to public. In fact, the only purpose this logger has is to tell us how many songs the boombox has.
- Tries to find the Asset Bundle that needs to be in the same folder as the DLL. If it doesn't find, it doesn't go through with loading all audio clips.

And this is what the BoomboxItemPatch looks like:
![image](https://github.com/wczbl/LC-Mods/assets/130032524/5931681c-3882-4664-96c8-a41c87c242b8)
All this does is:
- Creates a list with the length of the original music audios array.
- Adds all the boombox songs to the list.
- Updates the music audios array to contain all the boombox songs.

And that's pretty much it. If anything was unclear, please let me know in issues, and I'll help you as fast as I can. I hope this guide wasn't too confusing as it is my first time teaching this stuff.
