using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CreationalPatterns;
using NUnit.Framework;

namespace DesignPatternUnitTests
{
    [TestFixture]
    public class MazeTest
    {
        
        [Test]
        public void DoorTest()
        {
            Room r1 = new Room(1);
            Room r2 = new Room(2);
            Door door = new Door(r1, r2);

            Room result = door.OtherSideFrom(r1);

            Assert.AreSame(result, r2);
        }
    }
}
