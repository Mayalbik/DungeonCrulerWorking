﻿using System;
namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public class Player
    {
        private int level;
        private int power;
        private int currentHP;
        private int maxHP;
        private string playerName;
        private int attackCount;
        private bool PlayerVisit;
        private int experience;
        private int experienceToLevelUp;

        public Player(string playerName)
        {
            this.playerName = playerName;
            level = 1;
            power = 10;
            maxHP = 100;
            currentHP = maxHP;
            attackCount = 0;
            experienceToLevelUp = 100;
            experience = 0;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public int GetLevel()
        {
            return level;
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

        public void PlayerAttack()
        {
            attackCount++; 
        }

        public void setCurrentHP(int hp)
        {
            currentHP = hp;
        }

        public void PlayerLevelUp()
        {
            level++;
            power += 1;
            maxHP += 20;
        }

        public void PlayerDefeatingMonster(int monsterXP)
        {
            experience += monsterXP;

            Console.WriteLine($"{playerName} gained {monsterXP} XP. Total XP is now {experience}.");

            while (experience >= experienceToLevelUp)
            {
                experience -= experienceToLevelUp; 
                PlayerLevelUp(); 
                experienceToLevelUp += 50; 
            }
        }


        public int GetMaxHP()
        {
            return maxHP;
        }

        public void ResetHP()
        {
            currentHP = maxHP;
            attackCount = 0; 
        }

        public void PlayerLose()
        {
            Console.WriteLine($"{playerName} lost the battle!");
        }

        public void PlayerDeath()
        {
            Console.WriteLine($"{playerName} has died after 10 restarts!");
        }
    }
}