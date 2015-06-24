using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreationalPatterns
{
    public class Room : MapSite
    {
        
        private MapSite[] _sides = new MapSite[4];
        private int _roomNumber;

        public int RoomNumber
        {
            get { return _roomNumber; }            
        }



        public Room(int roomNumber)
        {
            _roomNumber = roomNumber;
        }
        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void SetSide(Direction direction, MapSite site)
        {
            throw new System.NotImplementedException();
        }

        public void GetSide(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
