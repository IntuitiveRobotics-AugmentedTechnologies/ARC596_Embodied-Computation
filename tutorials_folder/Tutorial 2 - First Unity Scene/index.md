# ARC596 - Tutorial 2 - Basic Unity AR App

- ARC596: Embodied Computation
- Professor: Daniela Mitterberger - mitterberger@princeton.edu
- Assistant Instructor: Kirill Volchinskiy - kvolchinskiy@princeton.edu
- Tutorial 2 - Basic Unity AR App

### Requirements

1. [Rhinoceros 7](https://www.rhino3d.com/en/7/)
2. [Github Desktop](https://desktop.github.com/) 
3. [Anaconda](https://www.anaconda.com/)
4. [Unity 2022.3.3f1](https://unity.com/) 
>	*Note: Android SDK and Java JDK (when developing for Android) - have to be ticked in the installation modules when installing Unity.*

### Dependencies

1. [COMPAS](https://compas.dev)
2. [COMPAS Fab - Fabrication Library for Robots](https://gramaziokohler.github.io/compas_fab/latest/)
3. [COMPAS Eve - Communication](https://compas.dev/compas_eve/latest/index.html)
4. [Vuforia](https://developer.vuforia.com/downloads/sdk)
5. [ROS#](https://www.ros.org/)

## Installing the Dependencies

1. Install the correct Unity Version using Unity Hub ```2022.3.3f1``` https://unity.com/releases/editor/whats-new/2022.3.3
      - *Note: Do not click the blue download link. If you download directly from this website it is cubersome to install the dependencies. Unity is version-sensitive, and it needs to be exactly this version*
	  <img width="400" alt="" src=" https://i.imgur.com/cqnSaTm.jpg">
	 
	- Be sure to select the appropriate dependencies below.
      - *Note: this installs roughly 20gb of data, make sure you have enough free space on your computer.*
		<img width="650" alt="" src="https://i.imgur.com/D9o3zho.jpg">
		
		- Microsoft Visual Studio 
		- Android Build Support (Both Android SDK and OpenJDK)
		- iOS Build Support
		- Universal Windows Platform Build Support
		- Windows Build Support (IL2CPP)
		- Documentation
	
2. Run Unity Hub. Create a new Unity Project. Be sure to select the correct Unity Version as basis for the project ```2022.3.3f1```

	<img width="650" alt="" src="https://i.imgur.com/I77ndmz.jpg">
	
	
3. Install Unity Packages for XR (Mixed Reality)

	- Access the Package Manager
	
		<img width="650" alt="" src="https://i.imgur.com/iQD4avo.png">
	
	- Switch to the Unity Registry 		
		
		<img width="400" alt="" src="https://i.imgur.com/73kTqaN.png">
	
	- Search & Install ```AR Foundation```, repeat for ```ARCore XR plugin```
		
		<img width="650" alt="" src="https://i.imgur.com/x0k6B1T.png">

    - Select ```No``` on whether to use the new input system package.
        
        <img width="400" alt="" src="https://i.imgur.com/RaFmyjP.jpg">
	
	- Add ARCore Unity Extensions. Select ```Add package from git URL```, https://github.com/google-ar/arcore-unity-extensions.git
		
		<img width="400" alt="" src="https://i.imgur.com/JDOpw0S.png">

	- Verify ```AR Foundation```, ```ARCore XR plugin```, ```ARCore Extensions``` are installed
		
		<img width="650" alt="" src="https://i.imgur.com/4LUeQrF.png">
	


















## Unity Overview 

<img width="650" alt="" src="https://i.imgur.com/fctlEa8.png">

### The Scene View 

A Scene contains the environments and menus of your game. Think of each unique Scene file as a unique level. In each Scene, you place your environments, obstacles, and decorations, essentially designing and building your game in pieces. Scene view is your interactive view into the world you are creating. You can use the Scene view to select and position scenery, characters, Cameras , lights, and all other types of Objects. Selecting, manipulating, and modifying GameObjects in the Scene view are some of the first skills you must learn to begin working in Unity.

→ [More info](https://docs.unity3d.com/Manual/CreatingScenes.html)

### Scene View Navigation 

<img alt="" src="https://i.imgur.com/RaSGErB.png">

The Gizmo allows you to quickly modify the viewing angle and the projection mode.

#### Arrow movement

You can use the **Arrow Keys** to move around the Scene as though walking through it. The up and down arrows move the _Camera_ forward and backward in the direction it is facing. The **left** and **right** arrows pan the view **sideways**.

#### Basic Tools

You can use the following Buttons to select, move, rotate, scale. This toolbar is located on the top left corner.

<img width="300" alt="" src="https://i.imgur.com/TYhoU7d.png">

1. **Hand** Tool (Keyboard Shortcut: **Q**)
2. **Move** Tool (Keyboard Shortcut: **W**)
3. **Rotate** Tool (Keyboard Shortcut: **E**)
4. **Scale** tool (Keyboard Shortcut: **R**)

### The Game View 

The Game view is rendered from the Camera(s) in your application. It represents your final, published application. You need to use one or more Cameras to control what the player sees when they are using your application. In AR, we will see a mixed environment between real and digital objects, as the camera orientation is constantly changing by our movement in space.

**Play mode**

<img width="100" alt="" src="https://i.imgur.com/Np9EDMS.png">

Use the buttons in the _Toolbar_ to control the Editor Play mode and see how your published application plays. An important fact is that, in **Play mode**, any changes you make are **temporary,** and are **reset** when you exit Play mode.

[→ More info](https://docs.unity3d.com/Manual/GameView.html)

### The Hierarchy Window

The Hierarchy window displays every [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) in a Scene, such as models, Cameras, or [Prefabs](https://docs.unity3d.com/Manual/Prefabs.html). You can use the Hierarchy window to sort and group the GameObjects you use in a Scene.

<img alt="" src="https://i.imgur.com/0Xs2azM.png">

The default Hierarchy window view when you open a new Unity project

### The Inspector Window 

The **Inspector Window** is being used to [view and edit **properties**](https://docs.unity3d.com/Manual/EditingValueProperties.html) and **settings** for almost everything in the _Unity Editor_. In the _Inspector Window_, one can add or remove _Components_ , which enable different features.. We will see what these are soon. [→ More Info](https://docs.unity3d.com/Manual/UsingTheInspector.html) 

### The Project Window 

<img width="650" alt="" src="https://i.imgur.com/YtMU8b9.png">

The _Project window_ displays all of the **files** related to your _Project_ and is the main way you can navigate and find _Assets_ and other _Project files_ in your application. When you start a new _Project_ by default this window is open. However, if you cannot find it, or it is closed, you can open it via **Window > General > Project** or use the keyboard command **Ctrl + 9** (Command + 9 on macOS).





















### GameObjects, Components, Prefabs 


<img width="650" alt="" src="https://i.imgur.com/yjd1wvG.png">

**GameObjects** are the fundamental objects in _Unity_ that represent _3d objects, props and scenery_. They do not accomplish much in themselves but they act as containers for **Components**, which implement the real **functionality**.

A _GameObject_ always has a [Transform](https://docs.unity3d.com/Manual/class-Transform.html) component attached (to represent position and orientation) and it is not possible to remove this. The other _components_ that give the object its functionality can be added from the editor’s Component menu or from a script. There are also many useful pre-constructed objects (_primitive shapes, Cameras,_ etc) available on the **GameObject > 3D Object menu** (more info: [Primitive Objects](https://docs.unity3d.com/Manual/PrimitiveObjects.html) )

### Components 

**Components** implement  **functionalities** on the _GameObjects_. For example, a _light object_ is created by attaching a _light component_ to a _GameObject_. **Components** are contained by GameObjects. _Unity_ has many built-in components, and you can create your own by writing scripts that inherit from the _MonoBehaviour_ class. C# is the programming language which we use to write code. 

[→ More Info about Scripting in Unity](https://docs.unity3d.com/Manual/CreatingComponents.html)

<img width="650" alt="" src="https://i.imgur.com/cqqIjt9.png">

A simple Cube GameObject with several Components

### Prefabs 

**Prefabs** allow you to create, configure, and store a _GameObject_ complete with all its _components, property values, and child GameObjects_ .The **Prefab Asset** acts as a **template** from which you can create new prefab instances in the scene.

[→ More Info](https://docs.unity3d.com/Manual/Prefabs.html)

### Parenting

Unity uses the concept of parent-child hierarchies, or parenting, to group GameObjects. An object can contain other GameObjects that inherit its properties. You can link GameObjects together to help move, scale, or transform a collection of GameObjects. When you move the top-level object, or parent GameObject, you also move all child GameObjects. You can also create nested parent-child GameObjects. All nested objects are still descendants of the original parent GameObject, or root GameObject.Child GameObjects inherit the movement and rotation of the parent GameObject. To learn more about this, see documentation on the [Transform component](https://docs.unity3d.com/Manual/class-Transform.html)!


<img alt="" src="https://i.imgur.com/9xteFSv.png">


_**Child 1** and **Child 2** are the child GameObjects of **Parent**. **Child 3** is a child GameObject of **Child 2**, and a descendant GameObject of **Parent**._




# Create the Animation Test App

## Creating new GameObjects 

To create a new GameObject in the Hierarchy window:

-   Right-click on empty space in the selected Scene.
-   Select the GameObject you want to create. Let’s make a **cube** _GameObject_ by selecting **3D Object > Cube.**
-   Now let’s make another _**empty** GameObject_.

→ You can also press **Ctrl+Shift+N** (Windows) or **Command+Shift+N** (macOS) to create a new empty GameObject.

<img height="400" alt="" src="https://i.imgur.com/zsk1bg1.png"> <img height="400" alt="" src="https://i.imgur.com/pKyxJiL.png">
 

### Creating child GameObjects 


To create a child GameObject:

-   Drag the GameObject onto the parent GameObject in the Hierarchy.
-   Drag _Object 4_ (selected) onto the parent _GameObject_, _Object 1_(highlighted in a blue) to create a child GameObject.

    <img width="250" alt="" src="https://i.imgur.com/JXuUcVX.png">

### Creating parent GameObjects 

You can add a new GameObject into the Hierarchy view as the parent of existing GameObjects.

To create a parent GameObject:

-   Right-click a _GameObject,_ or select multiple _GameObjects_ on the same level and right-click.
-   Select **Create Empty Parent.**

You can also press **Ctrl+Shift+G** (Windows) or **Command+Shift+G** (macOS) to create a parent GameObject.

→ You can also **click and drag** GameObjects inside, or outside parent GameObjects.

<img width="250" alt="" src="https://i.imgur.com/jFu65Qu.png">


### Duplicating GameObjects 

To duplicate _GameObjects,_ right-click the target GameObject and select **Duplicate.**

→ You can also press **Ctrl+D** (Windows) or **Command+D** (macOS) to duplicate the selected GameObject.

### Task: 

Try inserting multiple _GameObjects_ like _cubes_, _spheres_ and _Planes_ in the Scene. Use the basic tools to **Move, Rotate and Scale** the Objects and go to the **Inspector Window**. Try to transform them Manually by Inserting Values on **Position, Rotation and Scale.**

<img width="250" alt="" src="https://i.imgur.com/cSj8KHj.png">


>   Note: **To quickly** reset all the transform values, you can right click on the transform title, and click **Reset**


<img width="750" alt="" src="https://i.imgur.com/gI5AMaQ.png">

### Make a new Material 

-   In the **Project Window**, go to **Assets**, right click on the empty space and make a new folder by going to **Create> Folder.** Name it _Materials_.

-   Double click on the folder, right click on the empty space and make a new material by going to **Create>Material.** A new Material is created.

-   Click on the color palette on the _Inspector_ and select a color of your choice.

-   Drag and drop the material from **the Assets Folder** on the desired objects

>   Note: You can explore different Material Properties, such as **Transparency (in Rendering Mode)**, **Emission** (“glowy” effect, especially when combined with Bloom Rendering effects in Gaming), or add a **Texture** as a Map, similarly to other softwares.

<img width="750" alt="" src="https://i.imgur.com/TAxdfT0.png">

-   Move the **camera** to look at the cube.

-   You see a _small icon_ appearing at the bottom, showing how _the Game Mode_ will look like through this _camera._

>   **Tip**: If you don’t see the camera and light icons, try to click on the **Gizmos button** on top.











## Events in Unity 

<img width="400" alt="" src="https://i.imgur.com/Xwy5mgu.jpg">

An **event is a message** sent to an object to signal that an event happened such as the pressing of a button has occurred. An event sender pushes notifications that an event happened and a receiver receives that notification and defines to respond to it. The object that raises the event is called the **event sender**. The event sender doesn’t know which object will receive the events it raises.

### Event Functions 

A script in Unity is not like the traditional idea of a program where the code runs continuously in a loop until it completes its task. Instead, Unity passes control to a script intermittently by calling certain functions that are declared within it. Once a function has finished executing, control is passed back to Unity. These functions are known as event functions since they are activated by Unity in response to events that occur during gameplay. Unity uses a naming scheme to identify which function to call for a particular event. For example, you will already have seen the **Update** function (called before a frame update occurs) and the **Start** function (called just before the object’s first frame update).

>   Note: Many more event functions are available in Unity; the full list can be found in the script reference page for the [_MonoBehaviour_](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) class along with details of their usage. The following are some of the most common and important events.

### Create a C# script for keyboard interaction 

Let’s create our first C# script to interact with the Cube we made previously.

-   Click on the cube GameObject you created, go to the Inspector and click **Add Component**. Go to **New Script** , name it **Zoom** and click on **Create and Add**.

    <img width="450" alt="" src="https://i.imgur.com/nTbL4Pj.png">

-   Set Visual Studio Code to the default interface in Unity settings. Go to _File>Preferences>External Tools>External Script Editor_ and select **Visual Studio Code**

    <img width="650" alt="" src="https://i.imgur.com/pjdnwxW.jpg">

-   Double click on the **Script name**, or **right click>Edit Script**

-   Open the file with **Visual Studio Code**. Login with _your Microsoft account_, or create a new one.


```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

### MonoBehaviour: 

Unity’s base class that all scripts should derive from if they are used as components.

MonoBehaviour is a part of the **UnityEngine** namespace and implements a big list of event functions.

### Start and Update 

Unity adds the Start and Update methods by default to all new scripts.

**Start:** Runs once, at the first time the component is initialized.

**Update:** Runs on every frame (e.g. if it is 60fps, it runs 60 times per second!)

_→ We will write a script in **Update**, but will create an Event that triggers the command only when we press a button_.

### Declare a variable 

-   Insert the **cube GameObject** variable as a public gameObject (public = we can access it outside of the script and change it).

> Note: Remember to always put a semicolon (;) at the end of every line_

<img width="700" alt="" src="https://i.imgur.com/h08eean.png">

```
public class Zoom: MonoBehaviour {
  
  public GameObject cube;
  
  // Start is called before the first frame update
  void Start() {
      
  }
  
  // Update is called once per frame
  void Update() {
      
  }
}
```

### Add an event in an “if” statement 


-   We put the statement in the update, so that the script is checking constantly for our input.

    <img width="700" alt="" src="https://i.imgur.com/VrdMBJv.png">


```
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //do something here
        }
 }
```

### Add an action 

```
     void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            cube.transform.localScale += (Vector3.one*1.00001f)/100;
        }
    }
```

>   Note: We used a small value, since it will move fast.

-   Link the ```Public GameObject cube;``` variable that you just created in code to the actual cube instance in Unity. Click the buttom under Zoom, and select the cube. 

    <img width="700" alt="" src="https://i.imgur.com/LPyVGEE.jpg">


-   **Save** the script, go back to _Unity_ and **Play** the Scene.

-   Long Press the **SpaceBar** of your keyboard and watch the cube zoom exponentially.

    <img width="700" alt="" src="https://i.imgur.com/S7In6Q9.png">

>   Note: Any changes to code or scene must be made after **Existing Play  Mode** or they will be temporary. 

-   Change the code to ```transform.localScale += (Vector3.one*1.00001f)/100;``` Save it and run the code again. It still works because the script is self-referencing the object that the component is added to.

### Download animated characters 

-   Go to the Unity Asset Store:

[https://assetstore.unity.com/](https://assetstore.unity.com)

> Note: The **Unity Asset Store** is home to a growing library of **free and commercial assets** created both by _Unity Technologies_ and also members of the community. A wide variety of assets are available, covering everything from _textures, models and animations_, _to whole project examples, tutorials and Extension Assets_.

Find and download the free asset _5 animated Voxel animals_.

[https://assetstore.unity.com/packages/3d/characters/animals/5-animated-voxel-animals-145754](https://assetstore.unity.com/packages/3d/characters/animals/5-animated-voxel-animals-145754)

-   Click _Add to My Assets_
-   Click _Open in Unity_

### Import Package in your Unity File 

-   After clicking the **Open in Unity** button, you will be redirected to the Unity software, on the package manager. Make sure you are in **Packages: My Assets**. Click **Import**

    <img width="700" alt="" src="https://i.imgur.com/iflzJnm.jpg">


-   A window pops up. When importing a package, you can select the parts you want to import. For now, we will import everything. Click **Import**.

### Make a Plane 

-   In the **Hierarchy**, right click and go to **3D Object> Plane.**

→ _Make sure the Transform position values are set to **0,0,0**_

### Import a character 

-   Go to **Assets>VoxelAnimals>Assets>Prefabs** and drag and drop a character on the Scene or the Hierarchy. Make sure it is correctly placed on the plane.

    <img width="400" alt="" src="https://i.imgur.com/jTt2v4u.png">

>   Tip: To zoom in on an object fast, you can first select it from the Hierarchy or the scene and then click on the “F” button on your keyboard.

You can move the camera to a position where you see everything nicely.

### Click on Play! 

By clicking on the Keyboard arrows your character will move, by clicking on the Space Button the character will jump! If the cube gets bigger, the dog collides with it and might fall. The character is a **Rigid Body** with **Collision** properties.

### Regular Update Events 

A game is rather like an animation where the animation frames are generated on the fly. A key concept in games programming is that of making changes to **position, state and behavior** of objects in the game just before each frame is rendered. The [**Update**](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html) function is the main place for this kind of code in Unity. _Update_ is called **before the frame is rendered** and also **before animations are calculated**.

Below is an example of the code that would make the animated figure move:

```
void Update() 
{
    float distance = speed * Time.deltaTime * Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * distance);
}
```

[→ More Information on execution order of events in unity](https://docs.unity3d.com/Manual/ExecutionOrder.html)


## ARCore 

_ARCore_ is _Google’s_ platform for building augmented reality experiences. Using different APIs. ARCore enables your phone to sense its environment, understand the world and interact with information. Some of the APIs are available across _Android_ and _iOS_ to enable shared AR experiences.

ARCore uses _three key capabilities_ to integrate virtual content with the real world as seen through your phone's camera:

-   [**Motion tracking**](https://developers.google.com/ar/discover/concepts#motion\_tracking) allows the phone to understand and track its position relative to the world.
-   [**Environmental understanding**](https://developers.google.com/ar/discover/concepts#environmental\_understanding) allows the phone to detect the size and location of all types of surfaces: horizontal, vertical and angled surfaces like the ground, a coffee table or walls.
-   [**Light estimation**](https://developers.google.com/ar/discover/concepts#light\_estimation) allows the phone to estimate the environment's current lighting conditions.

### Supported devices

_ARCore_ is designed to work on a wide variety of qualified Android phones running _Android 7.0 (Nougat)_ and later. A full list of all supported devices [is available here](https://developers.google.com/ar/discover/supported-devices).

### How does ARCore work? 

-   Fundamentally, ARCore is doing two things:

    -   tracking the **position** of the mobile device as it moves
    -   building its own understanding of the real world

-   ARCore's motion tracking technology uses the **phone's camera** to identify interesting **points,** called features, and **tracks** how those points move over time. With a combination of the movement of these points and readings from the phone's inertial sensors, _ARCore_ determines both the position and orientation of the phone as it moves through space.

-   In addition to identifying key points, ARCore can detect **flat surfaces**, like a table or the floor, and can also estimate the **average lighting** in the area around it.

_→ For a more detailed breakdown of how ARCore works, check out _[_fundamental concepts_](https://developers.google.com/ar/discover/concepts)_._

-   _ARCore_ provides **SDKs**, or software development kits, for many of the most popular development environments. These SDKs provide native APIs for all of the essential AR features like motion tracking, environmental understanding, and light estimation. With these capabilities you can build entirely new AR experiences or enhance existing apps with AR features.

[Android](https://developers.google.com/ar/develop/java/quickstart) // [Android NDK](https://developers.google.com/ar/develop/c/quickstart) // [Unity (AR Foundation)](https://developers.google.com/ar/develop/unity-arf) // [iOS](https://developers.google.com/ar/develop/ios/overview) // [Unreal](https://developers.google.com/ar/develop/unreal/quickstart)

> Note: In our class/tutorial, we will focus on Unity’s AR Foundation Framework, and build the application for Android devices.

### AR Foundation 

[AR Foundation](https://unity.com/unity/features/arfoundation) is a **cross-platform framework** that allows you to build augmented reality experiences once, then build for either Android or iOS devices. **ARCore Extensions** for AR

-   AR Foundation allows you to work with augmented reality platforms in a multi-platform way within Unity. This package presents an interface for Unity developers to use, but doesn't implement any AR features itself. To use AR Foundation on a target device, you also need separate packages for the target platforms officially supported by Unity:

* [ARCore XR Plug-in](https://docs.unity3d.com/Packages/com.unity.xr.arcore@4.2/manual/index.html) on Android
* [ARKit XR Plug-in](https://docs.unity3d.com/Packages/com.unity.xr.arkit@4.2/manual/index.html) on iOS
* [Magic Leap XR Plug-in](https://docs.unity3d.com/Packages/com.unity.xr.magicleap@6.0/manual/index.html) on Magic Leap
* [Windows XR Plug-in](https://docs.unity3d.com/Packages/com.unity.xr.windowsmr@4.0/manual/index.html) on HoloLens

-   AR Foundation is a set of _MonoBehaviours_ and APIs for dealing with devices that support the following concepts. A few of them are:

    -   **Device tracking**: track the device's position and orientation in physical space.
    -   **Plane detection**: detect horizontal and vertical surfaces.
    -   **Anchor**: an arbitrary position and orientation that the device tracks.
    -   **Light estimation**: estimates for average color temperature and brightness in physical space.
    -   **Face tracking**: detect and track human faces.
    -   **2D image tracking**: detect and track 2D images.
    -   **Meshing**: generate triangle meshes that correspond to the physical space.
    -   **Collaborative participants**: track the position and orientation of other devices in a shared AR experience.
    -   **Raycast**: queries physical surroundings for detected planes and feature points.

[→ More information about AR Foundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.2/manual/index.html)




