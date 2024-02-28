---
layout: page
title: Getting Started
---

### Requirements

* Rhino 7 / Grasshopper
* [Anaconda Python](https://www.anaconda.com/distribution/?gclid=CjwKCAjwo9rtBRAdEiwA_WXcFoyH8v3m-gVC55J6YzR0HpgB8R-PwM-FClIIR1bIPYZXsBtbPRfJ8xoC6HsQAvD_BwE)
* [Visual Studio Code](https://code.visualstudio.com/)
* [Github Desktop](https://desktop.github.com/)
* [Docker Community Edition](https://www.docker.com/get-started): Download it for [Windows](https://store.docker.com/editions/community/docker-ce-desktop-windows). Leave "switch Linux containers to Windows containers" disabled.
* [Unity Hub](https://unity.com/download)
* [Unity 2022.3.3f1](https://unity.com/releases/editor/whats-new/2022.3.3)

* ### Dependencies

* [COMPAS](https://compas-dev.github.io/)
* [COMPAS FAB](https://gramaziokohler.github.io/compas_fab/latest/)
* [COMPAS EVE](https://gramaziokohler.github.io/compas_eve/latest/)
* ARCore

### 1. Setting up the Anaconda environment with COMPAS

Execute the commands below in Anaconda Prompt:
	
    (base) conda config --add channels conda-forge

#### Windows
    (base) conda create -n embodied_coputation compas_fab=0.22.0 compas_eve compas --yes
    (base) conda activate embodied_coputation

#### Mac
    (base) conda create -n embodied_coputation compas_fab=0.22.0 compas_eve compas --yes
    (base) conda activate embodied_coputation
    

#### Verify Installation

    (embodied_coputation) pip show compas_fab

    Name: compas-fab
    Version: 0.22.0
    Summary: Robotic fabrication package for the COMPAS Framework
    ...

#### Install on Rhino 7

    (embodied_coputation) python -m compas_rhino.install -v 7.0


### 2. Installation of Dependencies

    (embodied_coputation) conda install git

### 3. Cloning the Course Repository

Create a workspace directory:

    C:\Users\YOUR_USERNAME\workspace\projects

Then open Github Desktop and clone the [Embodied Computation repository](https://github.com/IntuitiveRobotics-Augmented Technologies/ARC596_Embodied-Computation) repository into your projects folder. Then install the repo within your environment (in editable mode):

**Voilà! You can now go to VS Code, Rhino or Grasshopper to run the example files!**
