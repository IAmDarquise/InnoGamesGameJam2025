using UnityEngine;

[System.Serializable]
public class FireRateDownRule : RuleFunction
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
        weapon.rateOfFirePerSecond *= 0.7f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.firerate_down, soundPoint.transform.position);
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
