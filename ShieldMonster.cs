using System;
namespace Dungeon_Cruler_2._0.DungeonCruler2.DungeonCrulerWorking
{
    public class ShieldedMonster : Monster, IShielded
    {
        private int shield;

        public ShieldedMonster(int initialShield)
        {
            shield = initialShield;
            Console.WriteLine($"A Shielded Monster appeared with {shield} shields!");
        }

        public int GetShield()
        {
            return shield;
        }

        public void AddShield(int shieldAmount)
        {
            shield += shieldAmount;
            Console.WriteLine($"Shielded Monster gained {shieldAmount} Shield. Total Shields: {shield}");
        }

        public override void ReceiveDamage(int damage)
        {
            if (shield > 0)
            {
                shield--;
                Console.WriteLine($"Shielded Monster absorbed the attack with a shield! Remaining shields: {shield}");
            }
            else
            {
                base.ReceiveDamage(damage); 
            }
        }
    }
}