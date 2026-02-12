# 🧪 Rick and Morty – Clip Manager

A **Windows Forms** application designed to organize *Rick and Morty* scenes by:

- Season  
- Episode  
- Characters  
- Duration  
- Title search  

Perfect for creating **edits, theory videos, funny moments compilations and general Rick and Morty content creator** and finding any scene in seconds.

---

## 📸 Screenshots

### Main Window
![Main Window](https://barbosaapi.onrender.com/pictures/clipmanager1)

### Filters Panel (Main Window)
![Filters](https://barbosaapi.onrender.com/pictures/clipmanager2)

### Import Clip Menu
![Import Clip](https://barbosaapi.onrender.com/pictures/clipmanager4)

### Search Result Preview
![Search Result](https://barbosaapi.onrender.com/pictures/clipmanager3)

---

## Main Features

- Instant title search  
- Sorting by season and episode  
- Character system per clip (User managed)
- Video thumbnail preview  
- Duration and file size display  
- Quick open file location  
- Clip importing and deleting
- Dragging and dropping clips
- Automatic deleting non existing videos

---

## Usage

- **Importing a clip**
You can import a clip by either by clicking the import button and selecting a video or by dragging a video file in the import window or the main window, you can get a preview of the clip by pressing the "Preview" button. After selecting the video you will have to fill 4 fields, the clip title, the season, episode and characters, to select the characters, write their names in this format: ```Rick, Morty``` you can select as many characters as you wish, but remember, ```Morty``` ≠ ```morty```, so select them wisely.

- **Filtering clips by character, episode or season**
You can filter the clips by selecting the options in the filter panel in the left side of the window and then pressing the "Filter" button, it will only show the clips with the wanted characters, episode and season. The most likely to use is the character one, remember, you can only select the characters you have registered, for example, if you want to select clips with only summer, you can select "All" in the season and episode tabs (or just leave them null) and press filter to display them.

- **Sorting clips**
Currently, (Version 1.0.0) you can sort clips by: Title (A-Z or Z-A), Episode (latest to oldest or oldest to latest), Characters (A-Z or Z-A) and Video Duration (shortest to longest or longest to shortest). To sort them, you can just press wanted collumns header.

- **Watching, deleting and viewing the clip on the explorer.
You can do all of that by selecting the wanted clips and right clicking them, a menu will pop up with the allowed actions, you can only open and view in folder one at once, but you can delete multiple clips if you want. You can also open a clip by double clicking it.

If you still have any doubts, check this [youtube video](https://youtu.be/QtY-zzVKdMk), it shows how the app should be used.
---

## Technologies

- **C#**
- **.NET / Windows Forms**
- **JSON** for local database  
- **Windows API Code Pack** for video details (duration & thumbnail)  

---

##

Morty would probably approve, Rick would just label the clips in the file explorer.
<small>**Disclaimer:** All the content in the app is localy managed by the user, no clips or full episodes come with the app, you have to upload your own videos and label them by season, episode, characters and title.</small>
