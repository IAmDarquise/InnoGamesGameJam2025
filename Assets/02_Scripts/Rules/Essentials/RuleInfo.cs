using UnityEngine;

[CreateAssetMenu(fileName = "RuleInfo", menuName = "Scriptable Objects/RuleInfo")]
public class RuleInfo : ScriptableObject
{
    public string ruleName;
    
    [SerializeReference]
    public RuleFunction function;
}
