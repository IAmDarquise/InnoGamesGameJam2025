using UnityEngine;

[CreateAssetMenu(fileName = "RuleInfo", menuName = "Scriptable Objects/RuleInfo")]
public class RuleInfo : ScriptableObject
{
    public string ruleName;

    public RuleTarget target;

    [SerializeReference]
    public RuleFunction function;

    public enum RuleTarget
    {
        Player,
        Enemy,
        Global,
        Weapon
    }
}
