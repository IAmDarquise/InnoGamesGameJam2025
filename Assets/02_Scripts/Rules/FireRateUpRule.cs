using UnityEngine;

[System.Serializable]
public class FireRateUpRule : RuleFunction
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

        weapon.rateOfFirePerSecond *= 1.5f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.firerate_up, soundPoint.transform.position);
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
        weapon.rateOfFirePerSecond = 3f;
    }

    public override void EnemyDeactivate(BaseEnemy enemy)
    {
        return;
    }
}
