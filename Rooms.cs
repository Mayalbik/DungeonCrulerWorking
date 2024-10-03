using System;
namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string Description { get; set; }

        public Room(int roomNumber, string description)
        {
            RoomNumber = roomNumber;
            Description = description;
        }
    }
}