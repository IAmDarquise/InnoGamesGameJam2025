using UnityEngine;

[System.Serializable]
public class GravityRule : RuleFunction
{
    public override void Activate()
    {
        Physics.gravity += new Vector3(0, 3f, 0);
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        return;
    }

    public override void WeaponActivate(Weapon weapon)
    {
        return;
    }

    public override void Deactivate()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    public override void PlayerDeactivate(PlayerMovement player)
    {
        return;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
