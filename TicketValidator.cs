﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketValidator
    {
        private ActiveTickets activeTickets;
        private string message = " ";
        //Constructor
        public TicketValidator(ActiveTickets activeTickets) 
        {            
            this.activeTickets = activeTickets;
        }
        public void AssignCarPark(CarPark carPark)
        {      
             
        }
        public string CarArrived()
        {
            message = "Please pay (cash only).";
            return message;
        }
        public string TicketEntered()
        {
            message = "Thank you, drive safely.";
            return message;
        }

        public string Paid()
        {
            message = "Please insert your ticket.";
            return message;
        }
        public string ClearMessage()
        {
            message = " ";
            return message;    
        }
        public string GetMessage()
        {
            return message;
        }
    }
}
