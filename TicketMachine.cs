using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace CarParkSimulator
{
    class TicketMachine
    {
        private ActiveTickets activeTickets;
        private string message = " ";
        //Constructor
        public TicketMachine(ActiveTickets activeTickets)
        {      
            this.activeTickets = activeTickets;        
        }     
        public void AssignCarPark(CarPark carPark)
        {
            
        }
        public string CarArrived()
        {
            message = "Please press to get a ticket.";
            return message;
        }
        public string PrintTicket()
        {
            message = "Thank you, enjoy your stay.";          
            return message;
        }
        public string ClearMessage()
        {
            message = "";
            return message;   
        }
        public string GetMessage()
        {
            return message;
        }     
    }
}
