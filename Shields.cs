namespace Dungeon_Cruler_2._0.DungeonCruler2
{
    public interface IShielded
    {
        int GetShield();
        void AddShield(int shieldAmount);
        void ReceiveDamage(int damage);
    }
}