using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ExitSensor : sensor
    {
        private CarPark carPark;
        //Constructor
        public ExitSensor(CarPark carPark) 
        {
            this.carPark = carPark;
        }
        public override bool CarDetected()
        {
            //4th
            carOnSensor = true;
            carPark.CarArrivedAtExit();
            return carOnSensor;
        }    
        public override bool CarLeftSensor()
        {
            //6th
            carPark.CarExitedCarPark();
            carOnSensor = false;
            return carOnSensor;
        }
    }
}
