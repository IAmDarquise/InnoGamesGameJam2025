using UnityEngine;

[System.Serializable]
public class JumpHeightUpRule : RuleFunction
{
    float jumpHeight;
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        jumpHeight = player.jumpForce;
        player.jumpForce *= 1.2f;
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
        player.jumpForce = jumpHeight;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
