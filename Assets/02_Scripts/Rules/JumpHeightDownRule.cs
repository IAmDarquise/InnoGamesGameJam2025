using UnityEngine;

[System.Serializable]
public class JumpHeightDownRule : RuleFunction
{
    float jumpHeight;
    public override void Activate()
    {
        return;
    }

    public override void PlayerActivate(PlayerMovement player)
    {
        jumpHeight = player.jumpForce;
        player.jumpForce *= 0.8f;
        GameObject soundPoint = GameObject.FindGameObjectWithTag("SoundPoint");
        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.jumpheight_down, soundPoint.transform.position);
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
        player.jumpForce = jumpHeight;
    }

    public override void WeaponDeactivate(Weapon weapon)
    {
        return;
    }
}
