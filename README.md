A Unity Application that helps players and DMs visualize the battlefield. This is intended to be especially useful for remote games. A premium version will eventually be offered, with extra features like VR presence over the "table", Procedural Map / World generation, and other features that require for-pay assets. 

# ROADMAP

- Networking so players can join a game and move their characters
- Map Creation
- Multi-level mapping so DMs can easily navigate between world, continent, region, city, and battle scales
- DM notebook for organizing campaign notes, tying notes to locations.
- DM and Player Roles for Networking, sharing maps from DM to players
- Combat order tracker
- Character Cheat Sheets for DM 
- Enemy trackers for DM
- Transparency, Removal, and Replacement for objects on map
- Possibly make building interiors another scale of mapping
- Music & Ambience manager
- Map Import from programs like PyMapper / Tiled (Stretch: rudimentary 3D extrusion of 2D maps)
- Character Model Imports
- Fog of War
- Larger set of initial characters
- Dice rolling
- Character sheet import from D&D Beyond & others
- System-Agnostic Character Sheet importer / form (definitely community sourcing needed, because I don't know every TTRPG)


# COMPLETED

- DM can move units around the battlefield
- Decent opening set of assets for mapmaking
- Multiple basic maps

# CONTRIBUTING

To contribute, clone the repository and begin a new branch. Make your changes, and submit a pull request. I will review the request within a couple of days and approve it or give feedback. 

# USING THE APPLICATION
At present, using the application requires the Unity Editor, as the executable would just open to whatever scene happened to be first in the build order. Once you have the Editor, you can download the repository and open the folder as a project in Unity. Make a new scene, design your map, drop in your character models (some included already), and start the game by hitting the "Play" button at the top of the screen. You will need to press the "Start Hosting" button that shows up in the game window, and then you will be able to move characters around the map. 

If you import new models, you will need to add the Newtork Identity and Controller components (easiest to copy from an existing prefab), the Unit Script, and tag the GameObject as Selectable before you can move them around in the game.
