using Dungeon_Cruler_2._0.DungeonCruler2.DungeonCrulerWorking;

namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public class Dungeon
    {
        public Room[,] Rooms { get; set; }
        public int CurrentRoomX { get; set; }
        public int CurrentRoomY { get; set; }
        public bool[,] VisitedRooms { get; set; }

        public Dungeon()
        {
            CreateRooms();
            CurrentRoomX = 0;
            CurrentRoomY = 0;
            VisitedRooms = new bool[3, 3];
        }

        public void CreateRooms()
        {
            Rooms = new Room[,]
            {
    { new Room(1, "Room 1"), new TreasureRoom(2, "Room 2", 50, 1), new Room(3, "Room 3") },
    { new Room(4, "Room 4"), new TrainingRoom(5, "Room 5", 5), new Room(6, "Room 6") },
    { new Room(7, "Room 7"), new Room(8, "Room 8"), new TreasureRoom(9, "Room 9", 100, 2) }
            };
        }

        public Room GetCurrentRoom()
        {
            return Rooms[CurrentRoomX, CurrentRoomY];
        }

        public bool MoveRight()
        {
            if (CurrentRoomY + 1 < Rooms.GetLength(1))
            {
                CurrentRoomY++;
                return true;
            }
            return false;
        }

        public bool MoveLeft()
        {
            if (CurrentRoomY - 1 >= 0)
            {
                CurrentRoomY--;
                return true;
            }
            return false;
        }

        public bool MoveUp()
        {
            if (CurrentRoomX - 1 >= 0)
            {
                CurrentRoomX--;
                return true;
            }
            return false;
        }

        public bool MoveDown()
        {
            if (CurrentRoomX + 1 < Rooms.GetLength(0))
            {
                CurrentRoomX++;
                return true;
            }
            return false;
        }

        public bool CheckIfGameOver()
        {
            return CurrentRoomX == 2 && CurrentRoomY == 2;
        }

        public bool PlayerVisitedRoom()
        {
            return VisitedRooms[CurrentRoomX, CurrentRoomY];
        }

        public void MarkRoomAsVisited()
        {
            VisitedRooms[CurrentRoomX, CurrentRoomY] = true;
        }

        public void ResetDungeon()
        {
            CurrentRoomX = 0;
            CurrentRoomY = 0;
            ResetVisitedRooms();
        }

        public void ResetVisitedRooms()
        {
            for (int y = 0; y < VisitedRooms.GetLength(0); y++)
            {
                for (int x = 0; x < VisitedRooms.GetLength(1); x++)
                {
                    VisitedRooms[y, x] = false;
                }
            }
        }
    }
}