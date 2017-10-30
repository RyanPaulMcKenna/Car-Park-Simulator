using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class CarPark
    {  
        private const int Maxspaces = 5;
        private int currentSpaces = 5;
        private FullSign fullSign;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private TicketMachine ticketMachine;
        private TicketValidator ticketValidator;       
        //Constructor
        public CarPark(TicketMachine ticketMachine,TicketValidator ticketValidator,FullSign fullSign,Barrier entryBarrier,Barrier exitBarrier)
        {   
            this.fullSign = fullSign;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
        }     
        public string CarArrivedAtEntrance()
        {
           //1st            
            return ticketMachine.CarArrived();
        }
        public string TicketDispensed()
        {
            //2nd
              entryBarrier.Raise();
           return ticketMachine.PrintTicket();
        }
        public int carEnteredCarPark()
        { //3rd
            ticketMachine.ClearMessage();
            entryBarrier.Lower();
            --currentSpaces;
            if (currentSpaces == 0)
            {
                fullSign.lit = true;
            }
            else
            {
                fullSign.lit = false;
            }
            return currentSpaces;
        }
        public string CarArrivedAtExit()
        { //4th
            return ticketValidator.CarArrived();
        }
        public string TicketValidated()
        {
            exitBarrier.Raise();
            return ticketValidator.TicketEntered();
        }
        public int CarExitedCarPark()
        { //6th
            exitBarrier.Lower();
            ticketValidator.ClearMessage();
            ++currentSpaces;
            if (currentSpaces > 0)
            {
                fullSign.lit = false;
            }
            else
            {
                fullSign.lit = true;
            }
            return currentSpaces;
        }
        public bool IsFull()
        {
            if (currentSpaces == 0)
                return true;            
            else
                return false;
        }
        public bool IsEmpty() 
        {
            if (currentSpaces == 5)
                return true;
            else
                return false;
        }
        public bool HasSpace()
        {
            if (currentSpaces > 0 )

                return true;
            else
                return false;
        }
        public int GetCurrentSpaces()
        {
            return currentSpaces;
        }
    }

}
