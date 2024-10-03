using System;
namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public class Monster
    {
        private int power;
        private int currentHP;
        private int maxHP;
        private string monsterName;
        private int attackCount;

        public Monster()
        {
            Random rand = new Random();
            monsterName = "Monster";
            power = rand.Next(5, 15);
            maxHP = rand.Next(50, 100);
            currentHP = maxHP;
            attackCount = 0;
        }

        public string GetMonsterName()
        {
            return monsterName;
        }

        public int GetPower()
        {
            return power;
        }

        public int GetCurrentHP()
        {
            return currentHP;
        }

        public int GetAttackCount()
        {
            return attackCount;
        }

        public void IncreaseAttackCount()
        {
            attackCount++;
        }

        public void ResetHP()
        {
            currentHP = maxHP;
            attackCount = 0;
        }

        public void ReceiveDamage(int damage)
        {
            currentHP -= damage;
        }
    }
}