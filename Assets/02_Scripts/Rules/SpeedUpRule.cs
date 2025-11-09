using UnityEngine;

[System.Serializable]
public class SpeedUpRule : RuleFunction
{
    public override void Activate()
    {
        Time.timeScale *= 1.3f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.everything_faster, soundPoint.transform.position);
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
        Time.timeScale = 1f;
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
