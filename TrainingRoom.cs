using System;
namespace Dungeon_Cruler_2._0.DungeonCruler2.DungeonCrulerWorking
{
    public class TrainingRoom : Room
    {
        private int powerIncrease;

        public TrainingRoom(int roomNumber, string description, int powerIncrease)
            : base(roomNumber, description)
        {
            this.powerIncrease = powerIncrease;
        }

        public void TrainPlayer(Player player)
        {
            player.IncreasePower(powerIncrease);
            Console.WriteLine($"{player.GetPlayerName()} trained in the room and gained {powerIncrease} power! New power: {player.GetPower()}");
        }
    }
}