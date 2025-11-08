using UnityEngine;

[System.Serializable]
public class GravityRule : RuleFunction
{
    public override void Activate()
    {
        Physics.gravity = new Vector3(0, -1.62f, 0);
    }
}
