# Unity-PostPIE-SunShafts
Description:
------------ 


* Unity - "PostPIE" -> "Post Processing Image Effects" - Sun Shafts

This is simply the old "Sun Shafts Image Effects" from Unity "Standard Assets" simply edited to use with "Post Processing V2".



Dependencies:
-------------


* Dependency: Post Processing V2


Note: You must install the "Post Processing V2" package from the "Unity Registry"!



Basic "Getting Started" Notes:
------------------------------


First and foremost you must install the "Post Processing V2" package from the "Unity Registry".



Next, create a new "Layer" called: "Post Process"...

...as that will be used later in your "Post-process Layer"



Next you must note that:


Your scene needs a "Camera"

Your scene needs a: "Directional Light"



Barebones needed: On "Camera":


You need a: "Post-process Layer"

Example:

Trigger: "Main Camera (Transform)"

Layer: "Post Process"



You need a: "Post-process Volume"

Example:

Profile: "Main Camera Profile"



You need: "Sun Shafts"

Example:

Shafts Caster: "Directional Light"



On Adding "Sun Shafts" Note:


There is a Menu Item: (can be used if you "select" a camera to add the sunshafts to)

Component -> Image Effects -> Rendering -> Sun Shafts


Or you can just add the Sun Shafts to the camera normally in the ditor sidebar...



Now, for the "Directional Light" & "Camera", positions and other related settings can be setup and tweaked to your desire, needs and likings...

Now, also as far as the "Post-process Layer", "Post-process Volume" and "Sun Shafts", note that the majority of other settings can be setup and tweaked to your desire, needs and likings...



Project Creation Reason Note: 
-----------------------------


The reason for this project was very simple, I found recently that an asset I had purchased awhile back and liked and had planned to use in a project was since then removed from the asset store due to depreciation and upon looking at the asset package I noticed the reason was most likely that the dependency on the old standard assets package as the asset was using sun shafts and as such since standard assets package was long gone and prior to that also the image effects was also removed from  the long gone standard assets and also that long ago post processing became post-processing v2, I contacted the particular asset author of the depreciated asset using such and mentioned this upon noticing the asset was removed from the asset store due to depreciation of the aforementioned and hoped the author would fix those issues so that the asset would be available again, alas several months went by and this task was not done as far as I could see and rather than bugging the asset author I decided that the only option now was to do some minor edits to included sun shafts related files to get the depreciated asset I was desiring to use back on track, and that is the reason for this project. Simple enough right?! Anyhoo, hopefully that all makes sense.

