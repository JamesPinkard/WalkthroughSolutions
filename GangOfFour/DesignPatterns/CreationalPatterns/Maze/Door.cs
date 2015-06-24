using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreationalPatterns
{
    public class Door : MapSite
    {
        private int _isOpen;
        private Room _roomA;
        private Room _roomB;

        public Door(Room roomA, Room roomB)
        {
            _roomA = roomA;
            _roomB = roomB;
        }

        public virtual void Enter()
        {
            
        }

        public Room OtherSideFrom(Room room)
        {
            if (!(room == _roomA || room == _roomB))
            {
                throw new System.ArgumentException("Parameter must be connected to door", "room");
            }

            if (room == _roomA)
            {
                return _roomB;
            }
            else
            {
                return _roomA;
            }
        }
    }
}
