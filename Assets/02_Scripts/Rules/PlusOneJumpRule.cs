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
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.extra_jump, soundPoint.transform.position);
    }

    public override void WeaponActivate(Weapon weapon)
    {
        return;
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
        player.extraJumps = 1;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }

    public override void EnemyDeactivate(BaseEnemy enemy)
    {
        return;
    }
}
