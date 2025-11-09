using UnityEngine;

[System.Serializable]
public class DamageUpRule : RuleFunction
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
        weapon.damage *= 2f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.damage_up, soundPoint.transform.position);
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
