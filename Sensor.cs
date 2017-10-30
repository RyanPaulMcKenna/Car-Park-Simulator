using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{       // Entity Class
    abstract class sensor
    {
        protected bool carOnSensor;
        //Constructor
        public sensor() 
        {
            
        }
        public abstract bool CarDetected();    
        public abstract bool CarLeftSensor();
        
        public bool IsCarOnSensor() 
        {
            return carOnSensor;
        }
    }
}
