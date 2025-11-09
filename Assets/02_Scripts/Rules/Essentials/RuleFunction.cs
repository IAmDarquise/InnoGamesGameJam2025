using UnityEngine;

[System.Serializable]
public abstract class RuleFunction
{
    // Global
    public abstract void Activate();
    // Player
    public abstract void PlayerActivate(PlayerMovement player);
    // Enemy
    public abstract void EnemyActivate(BaseEnemy enemy);
    // Weapon
    public abstract void WeaponActivate(Weapon weapon);

    // Global
    public abstract void Deactivate();
    // Player
    public abstract void PlayerDeactivate(PlayerMovement player);
    // Enemy
    public abstract void EnemyDeactivate(BaseEnemy enemy);
    // Weapon
    public abstract void WeaponDeactivate(Weapon weapon);
}
