using UnityEngine;

[System.Serializable]
public class StrongerEnemyRule : RuleFunction
{
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        return;
    }

    public override void WeaponActivate(Weapon weapon)
    {
        return;
    }

    public override void EnemyActivate(BaseEnemy enemy)
    {
        enemy.damage += 4f;
    }

    public override void Deactivate()
    {
        return;
    }

    public override void PlayerDeactivate(PlayerMovement player)
    {
        return;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
    
    public override void EnemyDeactivate(BaseEnemy enemy)
    {
        enemy.damage -= 4f;
    }
}
