using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ComparableCar
{
    class Car : IComparable
    {
        public int CarID { get; set; }

        // Constant for maximum speed.
        public const int MaxSpeed = 100;
        
        // Car properties.
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        
        // Is the car still operational?
        private bool carIsDead;
        
        // A car has-a radio.
        private Radio theMusicBox = new Radio();

        // Property to return the PetNameComparer.
        public static IComparer SortByPetName
        {
            get { return (IComparer)new PetNameComparer(); }
        }
        
        // Constructors.
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }
        
        // Throw an exception if the user speeds up beyond MaxSpeed.
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    
                    // We need to call the HelpLink Property, thus we need
                    // to create a local variable before throwing the Exception object.
                    Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
                    ex.HelpLink = "http://www.CarsRUS.com";

                    // Stuff in custom data regading the error.
                    ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        public int CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
            {
                if (this.CarID > temp.CarID)
                {
                    return 1;
                }
                if (this.CarID < temp.CarID)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new ArgumentException("Parameter is not a Car!");
            }
        }

        public int IntegerCompare(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
                return this.CarID.CompareTo(temp.CarID);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }
    }
}
