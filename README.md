# GAME3023-F2020-LabCode

Assets licensed under Creative Commons
https://creativecommons.org/licenses/

################ CC BY-ND 4.0 ################
-Pixel Art Overworld, by Edermunizz - https://edermunizz.itch.io/

################ CC BY 3.0 ################
	-16x18-rpg-characters-hair-clothing-pack, by Charles Gabriel - https://opengameart.org/content/16x18-rpg-characters-hair-clothing-pack

################ CC0 ################
Items -	https://opengameart.org/content/496-pixel-art-icons-for-medievalfantasy-rpg
World tile set - https://opengameart.org/content/zelda-like-tilesets-and-sprites

Kenney.nl assets
	https://opengameart.org/content/rpg-pack-base-set
	https://opengameart.org/content/roguelikerpg-pack-1700-tiles
	https://opengameart.org/content/ui-pack-rpg-extension


#########################
#	CRAFTING SYSTEM		#
#########################

With the GridCrafting package folder added you will get access to the crafting system as well as two new scriptable objects. These scriptable objects are the Recipe and Recipe List.

The CraftingManager script contains a reference to a Recipe List and the Recipe List contains an array of Recipes. Once a Recipe List reference is added to the CraftingManager script
you will only need to add new recipes to the Recipe List for the manager to have access to them. For convenience you can keep all Recipes and Recipe Lists in the Recipes Folder.

The crafting takes place in a 3x3 grid. The recipe can be placed in any position on the grid.

#	Recipes		#

HELMET:

METAL	-	METAL	-	METAL
METAL	-	HAT		-	METAL
null	-	null	-	null


MAP:

null	-	INK		-	null
FABRIC	-	FABRIC	-	FABRIC
null	-	HAT		-	null


BLUE POTION:

null	-	null	-	null
SAPPHIRE-	SAPPHIRE-	null
HAT		-	COAL	-	null


RABBIT FOOT:
CARROT	-	null	-	null
HAT		-	null	-	null
null	-	null	-	null

KEY:

CARROT	-	MEDAL	-	null
HAT		-	null	-	null
null	-	null	-	null