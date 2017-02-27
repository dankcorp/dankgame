Il faut :
- un objet arme, avec un int Type qui déterminera le type de l'arme (0 pour aucune arme, 1 pour minigun, 2 pour ak47)
- un script pour tirer et faire apparaitre le type de balle correspondant à l'arme (ex petite balle pour un desert Eagle, roquette pour le RPG)

Vous avez :
- un prefab qui contient tous les mesh et les textures
- un animator qui va animer l'arme 

infos :
c'est le prefab qui sera en face du joueur et des ennemis, donc pas besoin de le relier au joueur.
cela implique de faire les scripts de la balle (qui retire de la vie au joueur, ainsi qu'aux ennemis)