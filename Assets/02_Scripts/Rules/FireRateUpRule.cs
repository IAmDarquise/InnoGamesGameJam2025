using UnityEngine;

[System.Serializable]
public class FireRateUpRule : RuleFunction
{
    float fireRate;
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
        fireRate = weapon.rateOfFirePerSecond;
        weapon.rateOfFirePerSecond *= 1.5f;
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
        weapon.rateOfFirePerSecond = fireRate;
    }
}
