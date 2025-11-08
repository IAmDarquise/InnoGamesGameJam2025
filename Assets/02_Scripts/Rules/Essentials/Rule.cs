using System;
using UnityEngine;
[Serializable]
public class Rule
{
    private RuleFunction _ruleFunc;
    public RuleInfo _ruleInfo;
    public Rule(RuleInfo info)
    {
        _ruleInfo = info;
        _ruleFunc = info.function;
    }

    public void Use()
    {
        _ruleFunc.Activate();
    }
}
