using System;

namespace Dungeon_Cruler_2._0.DungeonCruler2.DungeonCrulerWorking
{
    public class TreasureRoom : Room
    {
        public int XP { get; set; }
        public int Shield { get; set; }

        public TreasureRoom(int roomNumber, string description, int xp, int shield)
            : base(roomNumber, description)
        {
            XP = xp;
            Shield = shield;
        }

        public void GiveTreasure(Player player)
        {
            Random rand = new Random();
            if (rand.Next(2) == 0)
            {
                player.PlayerDefeatingMonster(XP);
                Console.WriteLine($"You found a treasure chest with {XP} XP!");
            }
            else
            {
                player.AddShield(Shield);
                Console.WriteLine($"You found a treasure chest with {Shield} Shield!");
            }
        }
    }
}