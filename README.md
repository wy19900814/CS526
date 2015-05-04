# Audio Speed
Audio Speed is a music game which let players follow the rhythm to avoid obstacles and attempt to achieve as high score as possible until the end of the song.

The character (jet plane) will be on the music track and fly with the rhythm. During the play, players must follow the beat and the rhythm to do specific tasks, such as dodging obstacles, obtaining items to enhance the chance to get more points, etc.

The speed and tempo will attract people who like music and youngsters to not only enjoy the gameplay and music, but also improve their instant reaction skill.

## Poster
![Poster](/Poster.jpg)

## Trailer (Click to Start)
[![Trailer](/Trailer.png)](http://www.youtube.com/watch?v=-VIRrA-0pCg)

## Team Member
| Names         | Role                    |
| ------------- |:---------------------:  |
| Yang	Wang	| Project Manager	  |
| Feng	Wen	| System Architecture	  |
| Yufeng Jiang	| Player Control Designer |
| Xiongfei Gao	| Game Control Designer	  |
| Xinyu Huang	| Art Designing		  |
| Yin	Li	| Music Analyzer	  |
| Zhenzhong Luo	| Partial System Designer |

| Tables        | Are           | Cool  |
| ------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| zebra stripes | are neat      |    $1 |

## 1 Game Idea
This section gives a brief introduction of the game plays. As mentioned before Audio Speed is a combination of Parkour-game (e.g. Temple-run) and Music games (e.g. Taiko no Tatsujin). The jet plane is flying on an finite/infinite track, trying to dodge obstacles while collect target items. The rhythm of the movement corresponds to the back-ground-music. Hence players could have the experience of speeding while interacting with the music. An example of this type of game is Audiosurf. 

### 1.1 basic goals
There are 2 basic goals for this game:
#### 1.1.1 Dodging obstacles
We have 3 or more sub-tracks for our plane to fly. Obstacles are placed to hinder the plane from flying through. Hitting an obstacle might deduct score for a player. Players must control the plane to dodge such obstacles in order to get high scores or survive. 

#### 1.1.2 Hitting targets
Another goal of the antagonist is to hit targets. The targets appear according to the rhythm of the background music. By hitting a target, the player gains some scores. 

Shown below is a screenshot of Audiosuft. The grey blocks are obstacles while the color ones are targets.

### 1.2 Game modes
There are 2 modes for this game:
#### 1.2.1 Scoring mode
In this mode, the goal is to score as many points as possible in one game. There would be a scoring-board in the games to record the highest scores ever occur  in this device. There will be different stages with varied difficulties, player can unlock a harder level only when they reach certain score requirement in easier level. 

If possible, we could add a score rank system so that players could see their rankings and share high scores and long survive time with friends through Facebook.

#### 1.2.2 Survivor mode
In this mode, the time-length of the game varies. The player is giving an initial score at the beginning of the game. As the game proceed, the score keeps dropping at certain rate. Players must hit targets and scores as soon as possible in order to stay in the game. 

### 1.3 Future expansion
#### 1.3.1 Item system
There could be special items as the reward for the player. Example Items are:
Shields -- making the player invincible for a short period.
Auro -- doulbing the score for a short period.
Hearts -- bringing the player back to life in survivor mode.
	
Implementations might vary from above descriptions.

#### 1.3.2 Combo system
If the player has consecutively hit certain targets, the Combo state would be triggered. Under this state, hitting each target gives more score than usual. However, once the player misses one target, the game would switch back to normal state. 

## 2 Game control (How to play)
Our game offers two options for players:
### 2.1 Control through gravity sensor
Player can move the plane one track left by tilting the phone to the left once. Continuously tilting iPhone to the left keeps the plane stay on the most left track. Same rule applies for the right. One Lift of the upper part of iPhone allows the plane to go over obstacle. Sometimes there could be long fracture zone on the tracks, players should rapidly and consecutively swipe the screen to keep the plane flying, otherwise they will fall into the fracture and lose the game.

### 2.2 Control through touch operation
As for touching sensor, we vertically split iPhone screen into two half, one click on the left half will move the plane one track left and same rule applies for the right half.  Tapping both sides simultaneously allows the plane to fly through obstacle.To pass through fracture zones, players should rapidly and repeatedly tapping two halves of the screen.

## 3 Implementation
Unity3D is a powerful game creation system which not only provides developers a variety of tools to meet specific needs but also has ability to target games to abundant platforms including both PC and mobile device. After doing days of research, we decide to utilize Unity3D to implement our first iOS game. We will provide a brief introduction of how we will use Unity3D to build our game as follows:

### 3.1 Building Game Objects
Every object in a game is a Game Object. Each game object contains properties before they can be regarded as a character, an obstacle, an dynamic environment or graphical and physical effects. A game object can be taken as a container which hold different components that make jointly what the object is. In our game, the main objects are moving ground, obstacles, character, routes, environments, etc. In Unity, depending on which object is desired, different combination of components which could also be manipulated using scripts will be added to the object in order to create it. 	

### 3.2 Gameplay
Since we target game to mobile device, we will focus on mobile device input. The input class offers access to touchscreen, accelerometer and geographical/location input. In respond with game control, we will primarily deal with touch and slide. In Unity, each finger is represented by an Input.Touch data structure and has five phases, Began, Moved, Stationary, Ended and Canceled. 	

### 3.3 Scripting
Scripting is no doubt an essential ingredient in all games, by which the game system could respond to input from the input, arrange events that are triggered by some specific motion. Moreover, scripts could create graphical effect and physical control in the game. In our game, script should be used to create moving ground and obstacles with the beats of a song or piece of music, adjust the camera in respond with the position of the character, process music beats and rhythms, etc. Unity natively support three programming languages, C#(like Java or C++), Unity Script(modeled after JavaScript) and Boo(similar syntax as python). Nevertheless, Unity allows users to call custom functions written in C, C++ or Objective-C directly from C# scripts.

### 3.4 Menu
A good menu design allows users to choose whatever setting they feel comfortable with before playing the game, such as game mode and control mode. UI system in Unity makes it possible to create user interface fast and intuitively. We will start with creating a basic canvas in which all UI component will be placed inside. Then the Rect tool and Rect Transform will be used for layout elements. Finally in order to 	improve the aesthetic perception, we will add visual elements and interactive controller. 

### 3.5 Audio
One of the most important features of our game is that game objects in the world are generated by rhythms and beats of one piece of music. Processing music and retrieving related information can easily be done by using Audio tool in Unity, including clips, sources , importing and sound settings. With the help of scripting API in Unity, it will not be difficult to do music processing such as beats detection.

### 3.6 User Data
In terms of data store, SQLite will be our first choice which is a convenient way of implementing a database in Unity. It could be easily set in Javascript and provides SQL commands to access data in local data store.   


## 4 Tools for Music
Virtual DJ (also known as VDJ) is a range of audio/video mixing software developed by Atomix Productions Inc. We use it as music analysis tool and music production tool.

### 4.1 Music analysis
It can analyse a song’s speed, general beat and pitch. Moreover, time point of every bar’s downbeat could be told by Virtual DJ. Therefore, when a song is selected, our game can generate game objects according to its on-beats and speed. 

### 4.2 Music production
In order to satisfy our game’s different levels, it could change a song’s speed in a certain range(+-33%). Also, a song can be reproduced with a certain length and clips based on requirements or mixed with additional tracks.
