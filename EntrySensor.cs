using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class EntrySensor : sensor
    {
        private CarPark carPark;
        //Constructor
        public EntrySensor(CarPark carPark) 
        {
            this.carPark = carPark;
        }     
        public override bool CarDetected()
        {
            //1st
            carOnSensor = true;
            carPark.CarArrivedAtEntrance();           
            return carOnSensor;
        }    
        public override bool CarLeftSensor()
        {
            //3rd
            carPark.carEnteredCarPark();
            carOnSensor = false;
            return carOnSensor;
        }

    }
}