<h1>ColorAttack Design</h1>
Oleksandr Sikora 4799925

<h2>Introduction</h2>
ColorAttack is a simple side-scroller game. The goal of the game is to stay alive for as long as possible. As time goes on the score increases.<br>
The player is able to move up and down with arrow keys, and to change the color of the background to one of the three available colors with keys 1, 2 and 3. This is shown to the player with 3 respectively-colored circles with numbers behind the ship as a hint.<br>
Towards the player flies a constant stream of obstacles, each one of which are 3 colored blocks that form a row that take up the whole screen in height. The main feature of the game is that the player is able to pass through obstacles that are the same color as the background. So, to get a good score, the player is supposed to be able to quickly react to the coming projectiles, change the color accordingly, and avoid the white obstacles which are impossible to pass through.

<h2>Design and implementation choices</h2>
<h3>Library and framework usage</h3>
Node.js was used for downloading necessary packages that were used for developing the game, i.e. Kaboomjs. Kaboomjs is a JS based game engine focused on quick and simple creation of games that run in your browser. It was used extensively for the development of this game and made the process much easier and more intuitive.

<h3>Game difficulty</h3>
The speed and frequency of the approaching obstacles were adjusted in such a way that the player had to always be attentive to be able to perform well, but it didn't feel unfair when the player failed, and instead was clear that it was a mistake that they made. The speed of the ship moving up and down was made fast enough to be able to avoid any obstacles when the player reacts in a reasonable time-frame. To further support quick-paces gameplay, the player is able to change direction immediately and the color changing is also instantaneous without a cooldown. To avoid a situation where the player decides to only change the colors withouth moving, white blocks were added, which are impossible to pass through. The amount of white blocks is adjusted to make most of both player movement and color-changing feature.

<h3>Design details</h3>
Some design details that aren't essential to gameplay were added, to make the game more appealing overall:
- Changing colors isn't immediate visually, and instead has a short fade-out, making the color change less jarring on the eyes.
- The ship smoothly tilts into the direction that the player is moving.
- The ship has a trail coming out of it's back, which also tilts along with the player.
- Hitting an obstacles triggers a Game Over screen, alongside an animation of the ship exploding and falling down from where they hit a block whilst spinning, alongside screen shake and a darkened background. The player can restart the game by simply pressing "R".
- The obstacles and buttons suggesting controls don't have an outline, so they blend in with the background.
- The ship is white with a dark back and a black outline, so it's visible in any background, even with colorblindness.

<h3>Colors</h3>
The chosen colors are meant to be not bright, slightly towards the pastel side, so the player doesn't feel like their eyes are being cut by the often-flashing bright colors. In addition, colorblindness was kept in mind when deciding on colors as well. Although it still can be difficult to play such a game if you have any kind of colorblindness due to its nature, the colors were adjusted to make it possible regardless. Here is a screenshot from the game, and versions that people with different colorblindness-variants may see.
<h4>Screenshot</h4>
![](img/normal.png)
<h4>Red-blind</h4>
![](img/redblind.png)
<h4>Green-blind</h4>
![](img/greenblind.png)
<h4>Blue-blind</h4>
![](img/blueblind.png)
<h4>Monocrhomacy</h4>
![](img/monochromacy.png)