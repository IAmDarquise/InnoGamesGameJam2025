using UnityEngine;

[System.Serializable]
public class PlusOneJumpRule : RuleFunction
{
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        player.extraJumps++;
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
        player.extraJumps = 1;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
