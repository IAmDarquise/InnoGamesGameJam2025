using UnityEngine;

[System.Serializable]
public class DoubleEnemySpawnsRule : RuleFunction
{
    public override void Activate()
    {
        WaveSystem.Instance.strengthMultiplierPerWave *= 2;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.double_spawn, soundPoint.transform.position);
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        return;
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
        WaveSystem.Instance.strengthMultiplierPerWave = 1f;
    }

    public override void PlayerDeactivate(PlayerMovement player)
    {
        return;
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
