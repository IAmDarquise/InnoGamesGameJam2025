using UnityEngine;

[System.Serializable]
public class MoveSpeedDownRule : RuleFunction
{
    float speed;
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        speed = player.moveSpeed;
        player.moveSpeed *= 0.8f;
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
        player.moveSpeed = speed;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
