using UnityEngine;

[System.Serializable]
public class DamageDownRule : RuleFunction
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
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.damage_down, soundPoint.transform.position);
        weapon.damage *= 0.8f;
    }

    public override void EnemyActivate(BaseEnemy enemy)
    {
        return;
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
        weapon.damage = 4f;
    }

    public override void EnemyDeactivate(BaseEnemy enemy)
    {
        return;
    }
}
