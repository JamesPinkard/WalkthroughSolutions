using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreationalPatterns
{
    public class Maze
    {
        private readonly Dictionary<int, Room> _rooms = new Dictionary<int, Room>();        

        public void AddRoom(Room room)
        {
            _rooms[room.RoomNumber] = room;
        }

        public Room RoomNumber(int roomNumber)
        {
            return _rooms[roomNumber];
        }
    }
}
