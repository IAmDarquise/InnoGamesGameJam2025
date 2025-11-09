using UnityEngine;

[System.Serializable]
public class EnemySpeedUpRule : RuleFunction
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
        enemy.speed += 2f;
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
        enemy.speed -= 2f;
    }
}
