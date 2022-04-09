# AirLockControl for Space Engineers

This program is a *work-in-progress* **air lock control unit** for **Space Engineers**.


---


## Concept

The program takes care of the initialization of the in-game blocks.

The different button methods provide: 
- checks for pressurization status of the air lock
- checks for status of each door (open/closed)


## HOW-TO-USE

- build **three button panels** (one on pressurized side; one on vacuum side; one inside air lock)
- build **four programming blocks** and **one timer block**
- enter the *relevant block names* (doors; air vent; timer block) for each constant in the program
- choose the corresponding method for each button and enter the code to the linked programming block


---


### Ressources

- [Space Engineers](https://www.spaceengineersgame.com)
- [Space Engineers Documentation](https://www.spaceengineerswiki.com/Programming_Guide)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)


### TO-DO

- *status reading functions* might be obsolete and need to be replaced with updated functions (see documentation)
- *countdown loop* needs more testing
- *deactivation of doors* while methods run to prevent players from interupting the air lock control