using System;
using Dungeon_Cruler_2._0.DungeonCruler2.DungeonCrulerWorking;

namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    class Program
    {
        static int totalWins = 0;
        static int totalLosses = 0;
        static int restartCount = 0;
        static int maxRestarts = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your character's name:");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);
            Dungeon dungeon = new Dungeon();

            Console.WriteLine($"Welcome, {player.GetPlayerName()}! Ready for battle?");
            StartGame(player, dungeon);
        }

        public static void StartGame(Player player, Dungeon dungeon)
        {
            while (true)
            {
                Console.WriteLine($"You are now in {dungeon.GetCurrentRoom().Description}.");
                Console.WriteLine($"You are level {player.GetLevel()} | {player.GetPower()} power | {player.GetCurrentHP()} HP | {player.GetExperience()} XP | {player.GetShield()} Shield(s)");

                if (dungeon.GetCurrentRoom() is TreasureRoom treasureRoom)
                {
                    treasureRoom.GiveTreasure(player);
                }
                else if (dungeon.GetCurrentRoom() is TrainingRoom trainingRoom)
                {
                    trainingRoom.TrainPlayer(player);
                }
                else if (dungeon.PlayerVisitedRoom())
                {
                    Console.WriteLine("You have already visited this room. No need to fight the monster again.");
                }
                else
                {
                    Random random = new Random();
                    Monster monster;

                    if (random.Next(2) == 0) 
                    {
                        monster = new RageMonster(5);
                        Console.WriteLine("A RageMonster has appeared!");
                    }
                    else
                    {
                        monster = new Monster();
                        Console.WriteLine("A regular Monster has appeared!");
                    }

                    monster.ResetHP();
                    Console.WriteLine($"A wild {monster.GetMonsterName()} appears with {monster.GetPower()} power and {monster.GetCurrentHP()} HP!");
                    Battle(player, dungeon, monster);
                    dungeon.MarkRoomAsVisited();
                }

                if (dungeon.CheckIfGameOver())
                {
                    DisplayFinalOutcome(true);
                    return;
                }

                HandlePlayerMovement(dungeon);
            }
        }

        public static void Battle(Player player, Dungeon dungeon, Monster monster)
        {
            Console.WriteLine("Brave warrior, write 'fight' when you are ready to begin.");
            string userInputFight = Console.ReadLine();

            if (userInputFight.ToLower().Contains("fight"))
            {
                while (player.GetCurrentHP() > 0 || monster.GetCurrentHP() > 0)
                {
                    PlayerAttack(player, monster);

                    if (monster.GetCurrentHP() <= 0)
                    {
                        Console.WriteLine($"The {monster.GetMonsterName()} has been defeated but gets one last attack!");
                        MonsterAttack(player, monster); 
                        player.PlayerDefeatingMonster(100);
                        player.ResetHP();
                        totalWins++;
                        Console.WriteLine($"You gained XP! You are now level {player.GetLevel()} with {player.GetPower()} power and {player.GetCurrentHP()} HP.");
                        return;
                    }

                    if (player.GetCurrentHP() > 0)
                    {
                        MonsterAttack(player, monster);
                    }

                    if (player.GetCurrentHP() <= 0)
                    {
                        player.PlayerLose();
                        monster.ResetHP();
                        restartCount++;
                        totalLosses++;
                        CheckRestartCount(player, dungeon);
                        return;
                    }
                }
            }
        }

        public static void PlayerAttack(Player player, Monster monster)
        {
            Console.WriteLine($"{player.GetPlayerName()} attacks the {monster.GetMonsterName()}!");
            monster.ReceiveDamage(player.GetPower());
            player.PlayerAttack();
            Console.WriteLine($"The {monster.GetMonsterName()} now has {monster.GetCurrentHP()} HP.");
        }

        public static void MonsterAttack(Player player, Monster monster)
        {
            Console.WriteLine($"The {monster.GetMonsterName()} attacks {player.GetPlayerName()}!");
            player.ReceiveDamage(monster.GetPower());
            monster.IncreaseAttackCount();
            Console.WriteLine($"{player.GetPlayerName()} now has {player.GetCurrentHP()} HP.");
        }

        public static void CheckRestartCount(Player player, Dungeon dungeon)
        {
            if (restartCount >= maxRestarts)
            {
                DisplayFinalOutcome(false);
            }
            else
            {
                Console.WriteLine($"{player.GetPlayerName()} is revived and ready to continue.");
                player.ResetHP();
                dungeon.ResetDungeon();
            }
        }

        public static void DisplayFinalOutcome(bool playerWon)
        {
            if (playerWon)
            {
                Console.WriteLine("You won the dungeon!");
                Console.WriteLine($"Final Results: {totalWins} Wins | {totalLosses} Losses");
            }
            else
            {
                Console.WriteLine("You lost the dungeon.");
                Console.WriteLine($"Final Results: {totalWins} Wins | {totalLosses} Losses");
            }
        }

        public static bool HandlePlayerMovement(Dungeon dungeon)
        {
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine("Write a direction to move: 'right', 'left', 'up', or 'down'");
                string direction = Console.ReadLine().ToLower();

                switch (direction)
                {
                    case "right":
                        validMove = dungeon.MoveRight();
                        break;
                    case "left":
                        validMove = dungeon.MoveLeft();
                        break;
                    case "up":
                        validMove = dungeon.MoveUp();
                        break;
                    case "down":
                        validMove = dungeon.MoveDown();
                        break;
                }

                if (!validMove)
                {
                    Console.WriteLine("Out of range! Try again.");
                }
            }

            return validMove;
        }
    }
}