using UnityEngine;

[System.Serializable]
public class DamageDownRule : RuleFunction
{
    float damage;
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
        damage = weapon.damage;
        weapon.damage /= 2f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.damage_down, soundPoint.transform.position);
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
        weapon.damage = damage;
    }
}
