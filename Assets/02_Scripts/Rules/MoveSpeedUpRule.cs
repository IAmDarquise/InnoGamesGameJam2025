using UnityEngine;

[System.Serializable]
public class MoveSpeedUpRule : RuleFunction
{
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        player.moveSpeed *= 1.4f;
    }

    public override void WeaponActivate(Weapon weapon)
    {
        return;
    }

    public override void Deactivate()
    {
        return;
    }

    public override void PlayerDeactivate(PlayerMovement player)
    {
        player.moveSpeed = 10f;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
