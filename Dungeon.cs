namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public class Dungeon
    {
        public string[,] Rooms { get; set; }
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
            Rooms = new string[,]{
                { "Room 1", "Room 2", "Room 3" },
                { "Room 4", "Room 5", "Room 6" },
                { "Room 7", "Room 8", "Room 9" }
            };
        }

        public string GetCurrentRoom()
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
            Console.WriteLine("Sorry, this room is out of range. Please try again.");
            return false;
        }

        public bool MoveLeft()
        {
            if (CurrentRoomY - 1 >= 0)
            {
                CurrentRoomY--;
                return true;
            }
            Console.WriteLine("Sorry, this room is out of range. Please try again.");
            return false;
        }

        public bool MoveUp()
        {
            if (CurrentRoomX - 1 >= 0)
            {
                CurrentRoomX--;
                return true;
            }
            Console.WriteLine("Sorry, this room is out of range. Please try again.");
            return false;
        }

        public bool MoveDown()
        {
            if (CurrentRoomX + 1 < Rooms.GetLength(0))
            {
                CurrentRoomX++;
                return true;
            }
            Console.WriteLine("Sorry, this room is out of range. Please try again.");
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