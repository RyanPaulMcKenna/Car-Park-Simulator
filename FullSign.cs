using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{       //Entity Class
    class FullSign
    {
        public bool lit = false;    
        //Constructor
        public FullSign() 
        {
            
        }
        public bool IsLit()
        {
            return lit;
        }
        public bool SetLit() {
            lit = true;
            return lit;
        }









    }   

}
