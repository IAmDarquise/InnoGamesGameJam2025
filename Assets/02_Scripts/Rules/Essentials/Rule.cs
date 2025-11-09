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

    public void UsePlayer(PlayerMovement player)
    {
        _ruleFunc.PlayerActivate(player);
    }

    public void UseWeapon(Weapon weapon)
    {
        _ruleFunc.WeaponActivate(weapon);
    }

    public void UseEnemy(BaseEnemy enemy)
    {
        _ruleFunc.EnemyActivate(enemy);
    }

    public void Deactivate()
    {
        _ruleFunc.Deactivate();
    }

    public void DeactivatePlayer(PlayerMovement player)
    {
        _ruleFunc.PlayerDeactivate(player);
    }

    public void DeactivateWeapon(Weapon weapon)
    {
        _ruleFunc.WeaponDeactivate(weapon);
    }

    public void DeactivateEnemy(BaseEnemy enemy)
    {
        _ruleFunc.EnemyDeactivate(enemy);
    }
}
