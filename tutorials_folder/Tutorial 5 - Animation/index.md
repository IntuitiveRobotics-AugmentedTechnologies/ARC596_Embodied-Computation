# ARC596 - Tutorial 5 - Animation

- ARC596: Embodied Computation
- Professor: Daniela Mitterberger - mitterberger@princeton.edu
- Assistant Instructor: Kirill Volchinskiy - kvolchinskiy@princeton.edu

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

# Create the Multiple Houses App

### Useful Links 

→ [Unity Manual](https://docs.unity3d.com/Manual/index.html)

→ [More Information on execution order of events in unity](https://docs.unity3d.com/Manual/ExecutionOrder.html)

→ [More information about AR Foundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.2/manual/index.html)

→ [Unity Scripting API](https://docs.unity3d.com/ScriptReference/)

Scenes: [_https://docs.unity3d.com/Manual/CreatingScenes.html_](https://docs.unity3d.com/Manual/CreatingScenes.html)

Game Objects: [_https://docs.unity3d.com/ScriptReference/GameObject.html_](https://docs.unity3d.com/ScriptReference/GameObject.html)

Prefabs: [_https://docs.unity3d.com/Manual/Prefabs.html_](https://docs.unity3d.com/Manual/Prefabs.html)

Packages: [_https://docs.unity3d.com/Manual/PackagesList.html_](https://docs.unity3d.com/Manual/PackagesList.html)

### Unity Interface Recap


**Button**
<img src="https://i.imgur.com/Gr2MC7R.png" alt="" width="200">
A Button has an OnClick UnityEvent to define what it will do when clicked.

**Slider**
<img src="https://i.imgur.com/6EEBh7v.png" alt="" width="200">
A Slider has a decimal number Value that the user can drag between a minimum and maximum value. It can be either horizontal or vertical. It also has a OnValueChanged UnityEvent to define what it will do when the value is changed.

**Raycasters**
Raycasters are used for figuring out what the pointer is over

**AR Raycast Manager** 
Also known as hit testing, ray casting allows you to determine where a ray (defined by an origin and direction) intersects with a trackable. A "trackable" is a feature in the physical environment that can be detected and tracked by an XR device.


```
[SerializeField]
ARRaycastManager m_RaycastManager;

List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

void Update()
{
    if (Input.touchCount == 0)
        return;

    if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
    {
        // Only returns true if there is at least one hit
    }
}
```

**Physics Raycaster**

Used for 3D physics elements. Casts a ray against all colliders in the Scene and returns detailed information on what was hit. This example reports the distance between the current object and the reported Collider:


```
public class RaycastExample : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit hit;

       if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            print("Found an object - distance: " + hit.distance);
    }
}
```

### Functions Review

**Variables** hold values and references to objects. Variables start with a lowercase letter. When Unity compiles the script, it makes public variables visible in the editor.

**Functions** are collections of code that compare and manipulate these variables. Functions start with an uppercase letter. 

**Start Function** Start will be called if a GameObject is active, but only if the component is enabled.

**Update Function**  is called once per frame. This is where you put code to define the logic that runs continuously, like animations, AI, and other parts of the game that have to be constantly updated.


### New Features

<img src="https://i.imgur.com/ML5tTnS.png" alt="" width="25">
**Edit Mode**
-	Tap once on the object to select it ( you will see a white bounding box appear ). 
-	Tap and hold for 1 second. The bounding box will become yellow. Without lifting your finger, try to move the object around.

<img src="https://i.imgur.com/ok8CfEa.png" alt="" width="25">
**Delete Mode**
Tap once on an object to delete it immediately

<img src="https://i.imgur.com/UDXp4ze.png" alt="" width="25">
**Menu**
When pressed, new buttons pop up. 

<img src="https://i.imgur.com/DyxKT2v.png" alt="" width="25">
**Visibility Button** Turns on and off the visibility of the 3D printed object

<img src="https://i.imgur.com/ZUDFlUr.png" alt="" width="25">
**Reset Button** Resets all scanned planes and deletes all objects in Scene.

<img src="https://i.imgur.com/FEVArZ6.png" alt="" width="25">
**Play Button** Starts animating the characters.

<img src="https://i.imgur.com/zT6IZNS.png" alt="" width="200">
**Interactive Sunlight**
<img src="https://i.imgur.com/mRD1yhu.png" alt="" width="300">

 
 
In short, we will import 2 interactive sliders to manipulate the Sunlight, by changing the Altitude and the Azimuth. By changing these values, we are in fact iterating through seasons and hours of the day. 

-	Import UnityPackage

	-	Go to Assets>Import Package>Custom Package
	-	<img src="https://i.imgur.com/CXzGzF2.png" alt="" width="500">
	-	Select the .unitypackage file you downloaded
	-	<img src="https://i.imgur.com/ovdq7Mn.png" alt="" width="500">
	-	Select all Assets and click Import
	-	<img src="https://i.imgur.com/PYc6EHq.png" alt="" width="350"> <img src="https://i.imgur.com/EmNWRhA.png" alt="" width="500"> 
	-	You should be able to see a new folder in your Assets.

### Configure new GameObjects 

Since we imported new Prefabs and we want to incorporate them in our scene, we have to do some necessary steps to Relink some dependencies for Scripts and Buttons. 

-	Instantiator
	-	Since we have a new Instantiator, we will delete the previous Instantiator GameObject.
	-	<img src="https://i.imgur.com/JyRat0B.png" alt="" width="300">
	
-	Import as GameObject
	-	Drag and Drop the Instantiator Prefab from the Materials to the Hierarchy. 
	-	Unpack GameObject
	-	Respectively, we will Unpack the Prefab Completely
	-	<img src="https://i.imgur.com/Lpm9wSQ.png" alt="" width="450">
	-	Relink GameObject

-	Since we imported Instantiator again, we have to re-link the previous GameObject, where needed.

	-	<img src="https://i.imgur.com/ng2CyiS.png" alt="" width="400"> <img src="https://i.imgur.com/XPfdmeT.png" alt="" width="400">



-	AR Canvas - New Buttons

	-	Import as GameObject
	-	Drag and drop the AR Canvas Prefab of the previous tutorial to the Hierarchy 
	-	<img src="https://i.imgur.com/KlcPiX5.png" alt="" width="300"> <img src="https://i.imgur.com/edSP9oV.png" alt="" width="200"> 
 	-	<img src="https://i.imgur.com/R7IaVti.png" alt="" width="500"> 
 

>     Note: Notice that it is renamed to  AR_Canvas(1). This happens because the Prefab has the same name as the Menu. We will take the Children we need and import them in our existing AR_Canvas. 

-	Unpack Prefab
-	Respectively, unpack completely the AR_Canvas(1). 


-	Format  AR Canvas
	-	These are the 4 buttons we will import in our existing AR_Canvas.[1] Drag them into the existing AR_Canvas, as children.  The structure should look like this
	-	Delete the existing Reset button (there is already one included in the new Menu).
		<img src="https://i.imgur.com/PM9OaEU.png" alt="" width="300"> <img src="https://i.imgur.com/HDrakrn.png" alt="" width="300">

	-	Delete the AR_Canvas(1)  (Should be now an empty GameObject).
		<img src="https://i.imgur.com/i3E85pX.png" alt="" width="300">



-	Relink Menu Buttons
-	We will relink the buttons on their OnClick Modes.
	-	Go to your Menu Buttons from the previous tutorial, go to the Inspector, and Drag & Drop the Instantiator on the On Click () component on the Inspector. 
	-	Re-configure the Function for the button you need (Mode A = Instantiate one (for the 3d object) , Mode B = Instantiate multiple).
	-	<img src="https://i.imgur.com/hyxq4I6.jpeg" alt="" width="300">


	-	<img src="https://i.imgur.com/3iXWdLO.png" alt="" width="300">

	-	<img src="https://i.imgur.com/USmojW9.png" alt="" width="300"> <img src="https://i.imgur.com/DJqsh48.png" alt="" width="300">




 

-	Link new modes to the new Instantiator Script
	-	Link Edit Button (mode==2) 
	-	In this new mode, we will be able to select existing objects we created, scale, rotate and move them. ( AR Canvas > Edit_Button)
	-	Drag and drop the Instantiator GameObject and choose:  Instantiator> Instantiator.SetMode_C()
 
-	Link Delete Button (mode ==3) 
	-	In this mode, we will be able to delete existing objects by tapping on them.
	-	Drag and drop the Instantiator GameObject and choose:  Instantiator> Instantiator.SetMode_D()
	-	( AR Canvas >Delete_Button)

 
-	Link Visibility Button
	-	( AR Canvas >Menu> Shadow_Button) /// Directional_Light >  Sun.VisibilityToggle()


  
-	Link Reset Button
	-	( AR Canvas >Menu> Reset_Button) /// Instantiator > Instatiator.ResetApp()



  

-	Light

	Delete Previous Light

	We will import a new Light in the Scene, so let’s delete the existing Directional Light in the Hierarchy.

	<img src="https://i.imgur.com/PbIQpfc.png" alt="" width="400"> 


-	Import as GameObject

-	We will now drag and drop the Directional Light Prefab from the Asset Folder to the Hierarchy.
  
	<img src="https://i.imgur.com/PEbOUDB.png" alt="" width="250"><img src="https://i.imgur.com/Ijl1H0b.png" alt="" width="250"> 


-	Unpack Prefab Completely

-	Right Click on the Directional Light > Prefab> Unpack Completely. This will “detach” the link between the GameObject and the Prefab.
	
	<img src="https://i.imgur.com/VSDn4PR.png" alt="" width="500">


-	Sun Sliders

**Link Sliders to the Script**
-	Click on the Directional Light we imported, go to the Inspector on the Sun Script and drag and drop the 2 sliders we imported from the Assets package. 
	<img src="https://i.imgur.com/JOotBn3.png" alt="" width="300">
	<img src="https://i.imgur.com/PbG2iBA.png" alt="" width="300">
	<img src="https://i.imgur.com/yYt7KXq.png" alt="" width="300">


  
Drag and drop the Azimuth and Altitude slider (children in AR Canvas) to the Sun Script in the Inspector. Drag and drop the parent of the 3d object (houseParent).
	<img src="https://i.imgur.com/WizNIFS.png" alt="" width="500">



You should be able to see the newly added UI Menu on the Right.

### Build the App! 

### Menu Script 


Go to the new Menu GameObject that was imported. On the Inspector, find the MenuScript (C# Script component), double click and open the code. 

<img src="https://i.imgur.com/NX98hg5.png" alt="" width="300">
<img src="https://i.imgur.com/JULboVj.png" alt="" width="300">


Script Overview

```
public class Menuscript : MonoBehaviour
{
    //variables
    public GameObject Shadow_Button;
    public GameObject Reset_Button;
    public GameObject Animation_Button;

    // Start is called before the first frame update
    void Start()
    {
        //For each button, define OnClick Action and prefab
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Menu_Toggle);

    }

     //Toggle ON and OFF the dropdown submenu options
    private void Menu_Toggle()
    {
        //deactivate the buttons if they are on
        if (Shadow_Button.activeSelf == true)
        {
            Shadow_Button.SetActive(false);
            Reset_Button.SetActive(false);
            Animation_Button.SetActive(false);
        }
        else 
        {
            Shadow_Button.SetActive(true);
            Reset_Button.SetActive(true);
            Animation_Button.SetActive(true);
        }
    }
}
```

→ Here the “AddListener” redirects to the Menu_Toggle() function. This is a computationally efficient way of checking if a button is clicked to execute a function. 
→ This Menu Script turns on and off different buttons. This allows us to create a “pop up” Menu that includes multiple buttons, and make the UI Experience more compact. 


### New Instantiator Script - Overview 

Go to the Instantiator C# Script. 

How we set a mode
```
    public void SetMode_A()
    {
        mode = 0; // for single placement of objects, like the 3D printed house hologram
    }
    public void SetMode_B()
    {
        mode = 1; // for multiple placement of objects, like multiple trees or characters
    }
    public void SetMode_C()
    {
        mode = 2; // for editing existing objects
    }
    public void SetMode_D()
    {
        mode = 3; // for deleting objects
    }
```

How these modes are used
```
   private void _InstantiateOnTouch()
    {
        if (Input.touchCount > 0) //if there is an input..           
        {
            if (PhysicRayCastBlockedByUi(Input.GetTouch(0).position))
            {
                if (mode == 0) // ADD ONE : destroy previous object with every tap
                {
                    Debug.Log("***MODE 0***");
                    Touch touch = Input.GetTouch(0);

                    // Handle finger movements based on TouchPhase
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            if (Input.touchCount == 1)
                            { 
                                _PlaceInstant(houseParent);
                            }
                            break; //break: If this case is true, it will not check the other ones. More computational efficiency, 

                        case TouchPhase.Moved:
                        // Record initial touch position.
                            if (Input.touchCount == 1)
                                {
                                _Rotate(ARObject_new);
                                }
                            
                            if (Input.touchCount == 2)
                            {
                                _PinchtoZoom(ARObject_new);
                            }
                            break;

                        case TouchPhase.Ended:
                            Debug.Log("Touch Phase Ended.");
                            break;
                    }
                }
                else if (mode == 1) //ADD MULTIPLE : create multiple instances of object
                {

                    Debug.Log("***MODE 1***");
                    Touch touch = Input.GetTouch(0);

                    // Handle finger movements based on TouchPhase
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            if (Input.touchCount == 1)
                            {
                                _PlaceInstant(objectParent);
                            }                          
                            break;

                        case TouchPhase.Moved:
                        // Record initial touch position.
                            if (Input.touchCount == 1)
                                {
                                _Rotate(ARObject_new);
                                }
                            
                            if (Input.touchCount == 2)
                            {
                                _PinchtoZoom(ARObject_new);
                            }
                            break;

                        case TouchPhase.Ended:
                            Debug.Log("Touch Phase Ended.");
                            break;
                    }
                }

                else if (mode == 2) //EDIT MODE
                {
                    Debug.Log("***MODE 2***");
                    _EditMode();                                    
                }

                else if (mode == 3) //DELETE MODE
                {
                    Debug.Log("***MODE 3***");
                    activeGameObject = SelectedObject();
                    _DestroySelected(activeGameObject);
                }
                else
                {
                    Debug.Log("Press a button to initialize a mode");
                }
            }
        }
    }
```

EditMode() Function
```
mode==2
    private void _EditMode()
    {
        if (Input.touchCount == 1) //try and locate the selected object only when we click, not on update
        {
            activeGameObject = SelectedObject();
        }
        if (activeGameObject != null) //change the pinch and zoom place holder only when we locate a new object
        {           
            temporaryObject = activeGameObject;
            _addBoundingBox(temporaryObject); //add bounding box around selected game object
        }

        _Move(temporaryObject);
        _PinchtoZoom(temporaryObject);
        
    }
```

Find Selected Object by RayCasting
>     Note: This This function Returns an object (the activeGameObject), when the Raycast hits the Physics collider of that object. 

```
private GameObject SelectedObject(GameObject activeGameObject = null)
    {
        Touch touch;
        touch = Input.GetTouch(0);

        //delete the previous selection boundary, will be replaced with a new one

        if (Input.touchCount == 1 && touch.phase == TouchPhase.Ended)
        {
            Debug.Log("Single Touch");
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            rayManager.Raycast(touch.position, hits);

            if (hits.Count > 0)
            {

                Debug.Log("Ray shooting from camera");
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;              

                //if our touch hits an existing object, we find that object
                if (Physics.Raycast(ray, out hitObject))  
                {
                    //we make sure we didn't tap a plane
                    if (hitObject.collider.tag != "plane")
                    {
                        //setting the variable
                        Debug.Log("Selected object located");
                        activeGameObject = hitObject.collider.gameObject; //assign GameObject as the active
                        Debug.Log(activeGameObject);

                    }
                }
            }
        }
```

-	Delete mode

```mode==3```

In delete mode, we use the same script to locate the Raycast hit Object, and then instead of Moving, Rotating or Scaling, we just use the /Destroy()/  function.

``` 
                else if (mode == 3) //DELETE MODE
                {
                    Debug.Log("***MODE 3***");
                    activeGameObject = SelectedObject();
                    _DestroySelected(activeGameObject);
                }
   ------------------------------------------------------------------------
```

```
   private void _DestroySelected(GameObject gameObjectToDestroy)
    {
        Destroy(gameObjectToDestroy);
    }
```
→ Pro Tip: If you want to go directly to a function  you see in the code, you can CTRL+ click on the name. (e.g. here we would CTRL+click on the _DestroySelected(activeGameObject))

### Interactive Sunlight

In the new Directional Light we imported, there is a custom C# script attached named “Sun”.

<img src="https://i.imgur.com/EqfbJJc.png" alt="" width="400">

Here, we link the position and rotation of our Sunlight according to the slider values we have on our UI Canvas, which we manipulate on the fly. 

Also, we use this script to turn ON/OFF the visibility of our 3D printed object (that’s why we use the House Parent GameObject).
Let’s take a look at the scripts.


Azimuth - Altitude

-	AddListener

On line 40, we add listeners for everytime we change the slider for each parameter. 

```
     azimuth_slider.onValueChanged.AddListener(AdjustLatitude);
      altitude_slider.onValueChanged.AddListener(AdjustLongitude);
```

-	Adjust Values

On line 45, we assign these new values in the AdjustTime() function.

```
   public void AdjustAzimuth(float value)
     {
         New_Azimuth = value;
         AdjustTime(New_Azimuth, New_Altitude);
     }

     public void AdjustAltitude(float value)
     {
         New_Altitude = value;
         AdjustTime(New_Azimuth, New_Altitude);
     }  
```

-	Adjust Sun transform

On line 69,  we adjust the position of our 3D Sphere object, according to the Azimuth and Altitude values. 

The centerpoint of this sphere, is the House (the 3D printed object)

```
        if (house!=null)
        {
            coordPosition.x = radius*Mathf.Cos(New_Azimuth*Mathf.Deg2Rad)*Mathf.Cos(New_Altitude*Mathf.Deg2Rad);
            coordPosition.z = radius*Mathf.Cos(New_Azimuth*Mathf.Deg2Rad)*Mathf.Sin(New_Altitude*Mathf.Deg2Rad);
            coordPosition.y = radius*Mathf.Sin(New_Azimuth*Mathf.Deg2Rad);
     
            coordPosition += centerpoint;
            sun.transform.position = new Vector3(coordPosition.x, coordPosition.y, coordPosition.z);
            sun.transform.LookAt(house.transform);      
        }
```

Note: We use the LookAt command, to rotate the sunlight, by making it “look” at our object each time it is moving. 

-	Visibility Toggle

In the same C# Script (Sun), we use the function VisibilityToggle() to be able to turn ON/OFF the visibility of the 3d model, while still keeping the shadows of it. 

```
    public void VisibilityToggle()
    {
        //**Preview ON/Off the house 3dmodel**

        //Check if the house is instantiated
        if (houseParent.transform.childCount != 0)
            house = houseParent.transform.GetChild(0).gameObject;

        if(house != null)
        {
            //Get access to the model obj and adjust the MeshRenderer parameters
            GameObject obj = house.transform.GetChild(0).gameObject;
            Debug.Log(obj);

            if (shadowMode == 0)
            {
                obj.GetComponent<MeshRenderer>().shadowCastingMode =         UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                shadowMode = 1;
            }
            else
            {
                obj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                shadowMode = 0;
            }
        }
```



### Animation

“Animanimals” Script

Go to the Prefabs, click on the Animated Characters

<img src="https://i.imgur.com/czYah3w.png" alt="" width="400">


These downloaded Assets come with different Animations embedded in the prefab. This means that by assigning different functions, they can “switch” their animation to the desired preset. 
Our goal is to activate the “Walk” animation, so that our characters can walk around in the Augmented Reality environment. 


-	Add Animanimals Script
	-	Select the animated character Prefab.
	-	<img src="https://i.imgur.com/WstHcRL.png" alt="" width="100">
	-	Go to the Inspector, click on “Add Component”, type in “ Animanimals ” and import the Script. 

<img src="https://i.imgur.com/4qplW38.png" alt="" width="500">


Overview of Animanimals Script

Open the code by double clicking on the Animanimals Script.
First, we locate the Button we need (Which is named “Animation_Button, in our AR Canvas)
And then Add a Listener to it. When it is clicked, the ControllPLayer() void is called. This sets a value of either 1 or 0 (1 is for moving = “Walk”).
When the “Animation_Button”  button is clicked, the animation “Walk” is activated, and our characters start to move. 

<img src="https://i.imgur.com/AS8BEnN.png" alt="" width="250">




```
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //Button btn = Anim_Button.GetComponent<Button>();
        btn = GameObject.Find("/AR_Canvas/Menu/Animation_Button").GetComponent<Button>(); //.GetComponent<Button>();
        btn.onClick.AddListener(ControllPlayer);        
    }


    void Update()
    {
        Debug.Log(move);
        if (move)
        {
            Vector3 movement = transform.forward;
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    public void ControllPlayer()
    {
        Debug.Log("walk");
        anim.SetInteger("Walk", 1);
        if (move)
        {
            move = false;
        }
        else{
        move = true;
        }
        Debug.Log("move");        
     }
```


Colliders

<img src="https://i.imgur.com/FdYKKKj.png" alt="" width="500">


In order for our animations and placement of the objects to work, we have to make sure our imported Prefabs have Colliders and are Rigid Bodies.

Collider components define the shape of a GameObject for the purposes of physical collisions. A collider, which is invisible, does not need to be the exact same shape as the GameObject’s mesh. 

<img src="https://i.imgur.com/ckpU03e.png" alt="" width="100">

→ Our cat has a Box Collider attached to it.

A rough approximation of the mesh is often more efficient and indistinguishable in gameplay.The simplest (and least processor-intensive) colliders are primitive collider types. In 3D, these are the Box Collider, Sphere Collider and Capsule Collider.


-	Mesh Collider (Component)

	-	Documentation [Here](https://docs.unity3d.com/560/Documentation/Manual/class-MeshCollider.html#:~:text=The%20Mesh%20Collider%20takes%20a,collide%20with%20other%20Mesh%20Colliders)

	-	The Mesh Collider builds its collision representation from the Mesh attached to the GameObject, and reads the properties of the attached Transform to set its position and scale correctly. The benefit of this is that you can make the shape of the Collider exactly the same as the shape of the visible Mesh for the GameObject, resulting in more precise and authentic collisions. However, this precision comes with a higher processing overhead than collisions involving primitive colliders (such as Sphere, Box, and Capsule) and so it is best to use Mesh Colliders sparingly.

	-	Check if all of your prefabs have some sort of Collider.

-	Rigid Body (Component)

	-	Rigidbodies enable your GameObjects to act under the control of physics. The Rigidbody can receive forces to make your objects move in a realistic way. Any GameObject must contain a Rigidbody to be influenced by gravity, act under added forces via scripting, or interact with other objects.

<img src="https://i.imgur.com/OdNHEGI.png" alt="" width="400">

Rigid Body Properties

**Mass** The mass of the object (in kilograms by default).
**Drag** How much air resistance affects the object when moving from forces. 0 means no air resistance, and infinity makes the object stop moving immediately.
**Angular Drag** How much air resistance affects the object when rotating from torque. 0 means no air resistance. Note that you cannot make the object stop rotating just by setting its Angular Drag to infinity.
**Use Gravity** If enabled, the object is affected by gravity.
**Is Kinematic** If enabled, the object will not be driven by the physics engine, and can only be manipulated by its Transform. This is useful for moving platforms or if you want to animate a Rigidbody that has a HingeJoint attached.

→ The Rigidbody component is what makes our animals “fall”, or “move around”.

### Develop your app further

Now, it is time to continue developing your Augmented Reality environment setup!
Good luck!
