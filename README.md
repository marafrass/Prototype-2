# Prototype 2 - Snowdrift

For my second prototype, I wanted to make a more relaxed game than Chocolate Quake - this one's called Snowdrift, and is a very short exploration-based game during winter.



The main question I wanted to ask was the following:

### What are the natural instincts of a player in an isometric perspective? Where are people drawn to, what do they want to explore, and what type of level design can influence those choices?

1. First, I set up an isometric scene of a winter terrain, using proprietary Unity tools.
2. I initially tried out a 2D sprite-based character, but this made it hard to gauge 3D space while exploring, so I opted for a capsule character instead.
3. I found a series of public domain/creative commons assets for trees and rocks, which I started placing around the scene. Additionally, I added the Unity Standard Assets Kit and built a basic house. Everything else was either built in Unity or by using placeholder geometry.
4. I recorded some banjo music over creative commons winter ambience, in order to give the game a sense of space and to immerse the player in the environment a bit more.
5. Using other Unity assets I had, I quickly implemented a dialogue system and a basic inventory system, in order to do let the player do minor tasks - these dialogue trees were conditional and dependent on where the player would be in a particular "questline", i.e. Started, Doing, Finished, etc.
6. I rearranged a lot of the geometry to help guide the player in where there'd be content - that said, I'm hoping to see player instincts during playtests, to see how well this worked and where and to what the player would explore on their own - to some extent, to build a "heat map" of the environment in game.
7. I added flavor NPCs and interactable world objects, to help reward the player for exploring. Hopefully, these stand out more and the player will search them out.



## PLAYTEST QUESTIONS

- Did you feel like you were exploring an actual space/environment?
- Did you want to explore the map and see what you could find?
- Was the dialogue system easy to grasp? How easily understandable was the inventory?
- Did you feel like you were led on a path, or did you feel free to explore whatever?
- Where did you want to go?
- Did the isometric perspective hinder your enjoyment or your ability to explore the game?
- What things drew your attention?

## PLAYTEST UPDATE

Firstly, I was surprised how far the testers had gone exploring in the game! Almost everyone who played the game mentioned wanting to explore more, or that they had explored beyond the designed map areas. Based on the feedback given in the playtests, I think this is a question of sectioning off the map or clearly signaling what is explorable and what isn't - many had tried moving beyond the ice lake, for example, and had thoughts and comments regarding the "tundra", which in reality only was unedited areas of the terrain! For further development, I'd consider either placing the starting area in the middle of the map and working on building and designing interesting areas throughout the map, or fencing off parts with actual fence models or invisible walls, made to look like a treeline.

That said, most testers agreed that the most enjoyable aspects of the prototype was the dialogue and the general ambience of the game, which was great to hear - it solidified my assumption that the most appealing thing about the game, as I hoped to make it, was seeking out interaction and communicating with the game world, or more specifically, the NPCs. The isometric perspective didn't seem to hinder that, but it was rightfully pointed out that since there's no way of seeing a horizon, terrain would need to be navigated by landmarks and characters - the things the testers uniformly considered the best parts of the prototype. For further exploration of the concept, I think the level design will need to be tackled in screens; each "tile" or terrain has to contain at least one recognizable landmark or geometry for the player to never feel lost - as well as giving them something new to discover every step along the way. 

Mechanically, the game seemed to work great - using the dialogue system will need some tweaks and potentially numpad control, but in general the systems functioned well. 

All in all, I'm fairly happy with the feedback - I'm hoping to potentially revisit this prototype and create something more interesting along the way.
