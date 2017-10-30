using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{       //Entity Class
    class Ticket
    {      
        public bool paid = false;       
        //Constructor
        public Ticket()
        {

        }     
        public bool IsPaid()
        {
            paid = false;
            return paid;
        }
        public bool SetPaid()
        {
            paid = true;
            return paid;
        }     
    }
}
