using Dungeon_Cruler_2._0.DungeonCruler2;

public class RageMonster : Monster
{
    private int rageIncrease;

    public RageMonster(int initialRageIncrease)
    {
        rageIncrease = initialRageIncrease;
        Console.WriteLine("A Rage Monster appeared! It becomes stronger with each attack.");
    }

    public override void IncreaseAttackCount() 
    {
        base.IncreaseAttackCount(); 
        IncreasePower(rageIncrease); 
        Console.WriteLine($"{GetMonsterName()} is enraged! Its power increased by {rageIncrease}. Current power: {GetPower()}");
    }

    private void IncreasePower(int amount)
    {
        SetPower(GetPower() + amount);
    }
}