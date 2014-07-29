using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExample
{
    class Car
    {
        //Constant for macimum speed.
        readonly int MaxSpeed = 100;

        //Car properties
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        //Is the car still operational?
        private bool carIsDead;

        //A car has a rasio.
        private Radio theMusicBox = new Radio();

        //Constructors.
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            //Delegate request to inner radio
            theMusicBox.TurnOn(state);
        }

        public void Accelarate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    
                    // Use the "throw" keyword to raise an exception.
                    throw new Exception(string.Format("{0} has overheated!", PetName));
                }
            else
                Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
