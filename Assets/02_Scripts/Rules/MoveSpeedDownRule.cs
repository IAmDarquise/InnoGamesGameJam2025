using UnityEngine;

[System.Serializable]
public class MoveSpeedDownRule : RuleFunction
{
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        player.moveSpeed *= 0.8f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.movespeed_down, soundPoint.transform.position);
    }

    public override void WeaponActivate(Weapon weapon)
    {
        return;
    }

    public override void Deactivate()
    {
        return;
    }

    public override void PlayerDeactivate(PlayerMovement player)
    {
        player.moveSpeed = 10f;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
