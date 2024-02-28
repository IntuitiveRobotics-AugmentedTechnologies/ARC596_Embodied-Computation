# ARC596 - Tutorial 1 - Installation Guide

- ARC596: Embodied Computation
- Professor: Daniela Mitterberger - mitterberger@princeton.edu
- Assistant Instructor: Kirill Volchinskiy - kvolchinskiy@princeton.edu

### Requirements

1. [Rhinoceros 7](https://www.rhino3d.com/en/7/)
2. [Github Desktop](https://desktop.github.com/) 
3. [Anaconda](https://www.anaconda.com/)
4. [Unity 2022.3.3f1](https://unity.com/) 
>	Note: When developing for Android, the Android SDK and Java JDK have to be ticked in the installation modules when installing Unity.

### Dependencies

1. [COMPAS](https://compas.dev)
2. [COMPAS Fab - Fabrication Library for Robots](https://gramaziokohler.github.io/compas_fab/latest/)
3. [COMPAS Eve - Communication](https://compas.dev/compas_eve/latest/index.html)
4. [Vuforia](https://developer.vuforia.com/downloads/sdk)
5. [ROS#](https://www.ros.org/)

## Getting Started with This Project

### Installing Basic Requirements 

1. Install Rhino 7 (Grasshopper is installed as part of Rhino)

2. Make a Github Account 

	- Create an account using https://github.com/signup
	
	- Email your username to Daniela (mitterberger@princeton.edu) and Kirill (kvolchinskiy@princeton.edu) once you are done 

3. Install Github Desktop https://desktop.github.com/

	  - Install Git for windows: https://gitforwindows.org/

      - Note: Git is a package manager, and it allows you to publish code onto the cloud or public web. It also tracks your changes. Github is a web-based repository to use Git to post/host your files

4. Install Git LFS https://git-lfs.com/ using the Window Command Prompt (or Anaconda Prompt). Be sure to activate the ARC596 environment. 

	- Open the Windows Command Prompt. Search CMD in the start menu. 
	
		<img width="650" alt="" src="https://i.imgur.com/6O0JqTz.jpg">
	
	- Run ```git lfs install```

      - *Note: This is a Git extension to allow you to post larger files to the cloud folder called a repository*

5. Install Anaconda https://www.anaconda.com/download

      - *Note: Anaconda is a package management system for Python; it manages python and related packages on your computer.*


6. Install compas, compas_fab, and compas_eve

      - *Note: Compas is an open-source library for digital fabrication and computation within architecture, engineering, and construction*
	  
	- Run Anaconda Prompt. Go to start menu and search ```anaconda prompt```
	
		<img width="650" alt="" src="https://i.imgur.com/4OSBP7y.jpg">
		
		- *Note: This is the Anaconda-flavored Python terminal. It is different from the Windows Command Prompt in that it runs python code and commands, not windows commands*
	
	- Type the following commands into the terminal, this creates a new development environment. We reccomend you to name it ARC596, and the commands subsequently install compas, compas_fab, compas_eve, and link these libraries into Rhino 7:

	```
	conda create -n <environment name>
	conda activate <environment name>
	conda install -c conda-forge compas
	conda update compas
	conda install conda-forge::compas_fab
	conda install conda-forge::compas_eve
	python -m compas_rhino.install -v 7.0
	```

      - *Note: For documentation or help, please see: https://compas.dev/compas/latest/userguide/installation.html*
	  
>	Note: if the rhino install fails, you d not have the right folders. Need to make the scripts folder. Open explorer, put ``` \%appdata%\McNeel\Rhinoceros\7.0\ ``` in the search bar. Create a "scripts" folder. Run the command again. 
	  

	<img width="650" alt="" src="https://i.imgur.com/Qs8CP1P.jpg">

7. Install Visual Studio Code (VSCode) https://code.visualstudio.com/

      - *Note: Visual Studio Code is a simplified IDE (Integrated Development Environment), which allows you to write and run code within the same application for convenience.*
	
      - Install the python extension in VSCode. The Python extension to provide features like linting, debugging, code navigation, and more. To install it, open VSCode, go to the Extensions view by clicking on the Extensions icon in the Activity Bar on the side of the window, and search for Python. Click Install to add it.


        <img width="650" alt="" src="https://i.imgur.com/DaCjVLp.png">


      - We will need to switch the terminal to the anaconda prompt and the correct python environment that you just set up where you installed all of the compas dependencies. 

      - First, open the Command Palette (Ctrl+Shift+P) or click on the top of the screen 
      - Type ```>Terminal: Select Default Profile``` and select the standard Command Prompt System32/cmd.exe)

		<img width="650" alt="" src="https://i.imgur.com/k69forF.jpeg">
		<img width="650" alt="" src="https://i.imgur.com/IABwVuO.jpeg">

      - Now we can select the Anaconda Environment as your python interpreter. Open the Command Palette (Ctrl+Shift+P), type ```Python: Select Interpreter```, and hit enter. A list of available interpreters will appear. Select the one that corresponds to your ARC596 Anaconda environment.

		<img width="650" alt="" src="https://i.imgur.com/ts8WtPz.jpeg">    
		<img width="650" alt="" src="https://i.imgur.com/CkSIH9J.jpg">   

8. Allow the recently installed programs to access the network using the firewall
		
	- When Windows asks whether to allow network access for Python, be sure to allow for both private and public networks. 

		<img width="400" alt="" src="https://i.imgur.com/2lRvYge.jpg">
			
		- *Note: If your host (broker/server) for messages is not localhost. DISABLE your Firewall or ensure that the required ports for MQTT (typically 1883 or 8883 for secure connections) are open and accessible. Please note that this does open your computer to possible attacks at these ports, especially since you are running custom code that may not be secure.*
		
    - To open the ports for MQTT, which is a communication protocol we will be using to pass data to and from the robots, please open the Windows Firewall. Start Menu > Search ```Firewall```

    - Add a rule, make sure that it is a port-based type. MQTT runs on TCP, and for the specific ports put ```1883, 8883``` You can name it ```MQTT Allow```, for instance. Save the rule. 

		<img width="650" alt="" src="https://i.imgur.com/vDoGpn4.jpeg">
		
		<img width="650" alt="" src="https://i.imgur.com/4uhkREQ.jpeg">


	
### Installing Unity

1. Install Unity https://unity.com/download 

      - *Note: We will use Unity 3D to develop the Android – based augmented reality apps.*
	
2. License Unity & Create Unity ID

	- Create your Unity ID: https://id.unity.com/en/conversations/b1516ea8-e6f1-4061-96b5-a060365abe06019f
	
		<img width="600" alt="" src="https://i.imgur.com/HUdlboa.jpg">
		
	- License unity as personal non-commercial license. Open Unity Hub>Account>Preferences>Licenses
	
		<img width="400" alt="" src="https://i.imgur.com/RDnocQQ.jpeg">
	
		<img width="400" alt="" src="https://i.imgur.com/GChEZvL.jpg">
	
	
	
<!--- Download the project from Github
*** Open Unity Hub. In Projects, click on Open(MacOS) or ADD(Windows). Locate the folder you downloaded from GitHub `name of project here` on the drive and add it.
-->

3. Install the correct Unity Version using Unity Hub ```2022.3.3f1``` https://unity.com/releases/editor/whats-new/2022.3.3
      - *Note: Do not click the blue download link. If you download directly from this website it is cubersome to install the dependencies. Unity is version-sensitive, and it needs to be exactly this version*
	  <img width="400" alt="" src=" https://i.imgur.com/cqnSaTm.jpg">
	 
	- Be sure to select the appropriate dependencies below.
      - *Note: this installs roughly 20gb of data, make sure you have enough free space on your computer.*
		<img width="600" alt="" src="https://i.imgur.com/D9o3zho.jpg">
		
		- Microsoft Visual Studio 
		- Android Build Support (Both Android SDK and OpenJDK)
		- iOS Build Support
		- Universal Windows Platform Build Support
		- Windows Build Support (IL2CPP)
		- Documentation
	

### Android

1. Enable Developer Mode on your Android phone

	- Go to the settings on your phone. Settings > About Phone > Build Number (or similar)
	
	- To enable developer options, tap the Build Number option 7 times 
	
	- Enable USB debugging
	
	- Use a USBC Data cable to connect to your computer, as opposed to a power cable. 


### Test Your Setup

1. Download the code 

	- Open Github Desktop, sign into your Github account 
	
      - *Note: Instructor/AI will need to give you access to the private repository. Be sure to email them*
      - *Note: This downloads the files hosted on github to your computer.*
	  
	- Clone the repository. Go to File > Clone Repository
	  
	- Use the following url, and make a note of where it saves the files ```https://github.com/IntuitiveRobotics-AugmentedTechnologies/ARC596_Embodied-Computation.git```
      
	  - *Note: Do not use a Dropbox or Google Drive directory, as the file locking will make working more difficult*
	
	  	<img width="400" alt="" src="https://i.imgur.com/pbxRg8X.jpg">
		
2. Open the test files

	- Open Unity Hub. Go to Start menu and search ```unity hub```
	
	- Add the test file from ```ARC596_Embodied-Computation\src\arc596_unity``` to Unity 
	  	
		<img width="600" alt="" src="https://i.imgur.com/TpqB3gn.jpeg">
	
		- Be sure that it is using the right unity version ```2022.3.3f1```
	
		<img width="600" alt="" src="https://i.imgur.com/mKvVORT.jpeg">
		
	- See if you can build and run the file on your phone. Open the Unity console. Go to File > Build and Run
	
		<img width="600" alt="" src="https://i.imgur.com/z1ek1M8.jpg">
		
		- *Note: You should see no red errors. Yellow warnings in the screenshot are OK. If you see red errors, dependencies are not installed correctly.*
	
	- Open Rhino
	
	- Go to the ```ARC596_Embodied-Computation\docs\T2 folder```, and see if you can run the grasshopper script without any errors. 