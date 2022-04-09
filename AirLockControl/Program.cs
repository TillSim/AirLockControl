using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Ingame;
using Sandbox.Game.EntityComponents;
using VRage.Game.Components;
using VRage.Collections;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;

namespace SpaceEngineers{
    
    class Program : MyGridProgram
    {

        //  block names:
        private const string doorNameIN = "doorIN";
        private const string doorNameOUT = "doorOUT";
        private const string airVentName = "airVent";
        private const string timerBlockName = "timerBlock";

        private IMyDoor doorIN, doorOUT;
        private IMyAirVent airVent;
        private IMyTimerBlock timer;
        

                        
        public Program()
        {

        }

        
        public void Save()
        {

        }

        
        public void Main(string argument, UpdateType updateType)
        {
            
            initBlocks();



            //control methods for access buttons (choose one for each button):
             
                        
            //toggleAirLockFromInside();

            //toggleAirLockFromOutside();

            //toogleAirLockFromAirLockIN();

            //toogleAirLockFromAirLockOUT();
            
        }


        
        private void initBlocks()
        {

            doorIN = GridTerminalSystem.GetBlockWithName(doorNameIN) as IMyDoor;
            doorOUT = GridTerminalSystem.GetBlockWithName(doorNameOUT) as IMyDoor;
            airVent = GridTerminalSystem.GetBlockWithName(airVentName) as IMyAirVent;
            timer = GridTerminalSystem.GetBlockWithName(timerBlockName) as IMyTimerBlock;

            if(doorIN == null)
            {
                Echo(doorNameIN + " not found!");
            }

            if(doorOUT == null)
            {
                Echo(doorNameOUT + " not found!");
            }

            if(airVent == null)
            {
                Echo(airVentName + " not found!");
            }

            if(timer == null)
            {
                Echo(timerBlockName + " not found!");
            }

        }


        private void toggleAirLockFromOutside()
        {

            if (doorOUT.Open)
            {
                doorOUT.CloseDoor();
                timer.StartCountdown();
                while (timer.IsCountingDown){}

                airVent.ApplyAction("Depressurize");
                while (airVent.IsDepressurizing) { }

                doorIN.OpenDoor();
            }
            else
            {
                doorIN.CloseDoor();
                timer.StartCountdown();
                while (timer.IsCountingDown) { }

                airVent.ApplyAction("Depressurize");                
                while (airVent.IsDepressurizing) { }

                doorOUT.OpenDoor();
            }

        }


        private void toggleAirLockFromInside()
        {

            if (doorIN.Open)
            {
                doorIN.CloseDoor();
                timer.StartCountdown();
                while (timer.IsCountingDown) { }

                airVent.ApplyAction("Depressurize");
                while (airVent.IsDepressurizing) { }

                doorOUT.OpenDoor();
            }
            else
            {
                doorOUT.CloseDoor();
                timer.StartCountdown();
                while (timer.IsCountingDown) { }

                airVent.ApplyAction("Depressurize");
                while (airVent.IsDepressurizing) { }

                doorIN.OpenDoor();
            }

        }


        private void toogleAirLockFromAirLockIN()
        {

            if (airVent.Depressurize)
            {
                airVent.ApplyAction("Depressurize");
                while (airVent.IsDepressurizing) { }
                
                doorIN.OpenDoor();
            }
            else
            {
                doorIN.OpenDoor();
            }

        }


        private void toogleAirLockFromAirLockOUT()
        {

            if (airVent.Depressurize)
            {
                doorOUT.OpenDoor();
            }
            else
            {
                airVent.ApplyAction("Depressurize");
                while (airVent.IsDepressurizing) { }
                doorOUT.OpenDoor();
            }

        }


    }
}
