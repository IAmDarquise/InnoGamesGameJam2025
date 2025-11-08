using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Holds all the Rules in the game, at the start of every Wave the function SelectRule will be called to choose which 
/// rules will be active for that wave, within the functions the RuleMachine will also display the names of the selected 
/// rules.
/// </summary>
public class RuleManager : MonoBehaviour
{
    [SerializeField] private List<RuleInfo> rules = new List<RuleInfo>();
    [SerializeField] private RuleMachine ruleMachine1;
    [SerializeField] private RuleMachine ruleMachine2;
    private PlayerMovement playerMovement;
    private Weapon playerWeapon;

    private Rule selectedRule1;
    private Rule selectedRule2;
    private Rule selectedRule3;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerWeapon = FindObjectOfType<Weapon>();
        WaveSystem.Instance.onWaveComplete += SelectRule;
    }

    public void SelectRule(int wavesCompleted)
    {
        ResetRules();
        selectedRule1 = new Rule(rules[Random.Range(0, rules.Count)]);
        selectedRule2 = new Rule(rules[Random.Range(0, rules.Count)]);
        selectedRule3 = new Rule(rules[Random.Range(0, rules.Count)]);
        UseRules(selectedRule1);
        UseRules(selectedRule2);
        UseRules(selectedRule3);
        ruleMachine1._allRulez.Clear();
        ruleMachine2._allRulez.Clear();
        ruleMachine1._allRulez.Add(selectedRule1._ruleInfo);
        ruleMachine1._allRulez.Add(selectedRule2._ruleInfo);
        ruleMachine1._allRulez.Add(selectedRule3._ruleInfo);
        ruleMachine2._allRulez.Add(selectedRule1._ruleInfo);
        ruleMachine2._allRulez.Add(selectedRule2._ruleInfo);
        ruleMachine2._allRulez.Add(selectedRule3._ruleInfo);
        ruleMachine1.SpinTheMachine();
        ruleMachine2.SpinTheMachine();
    }

    public void UseRules(Rule rule)
    {
        if (rule._ruleInfo.target == RuleInfo.RuleTarget.Global)
        {
            rule.Use();
        }
        else if (rule._ruleInfo.target == RuleInfo.RuleTarget.Player)
        {
            rule.UsePlayer(playerMovement);
        }
        else if (rule._ruleInfo.target == RuleInfo.RuleTarget.Weapon)
        {
            rule.UseWeapon(playerWeapon);
        }
    }

    private void ResetRules()
    {
        if (selectedRule1 != null)
        {
            if (selectedRule1._ruleInfo.target == RuleInfo.RuleTarget.Global)
            {
                selectedRule1.Deactivate();
                selectedRule1 = null;
            }
            else if (selectedRule1._ruleInfo.target == RuleInfo.RuleTarget.Player)
            {
                selectedRule1.DeactivatePlayer(playerMovement);
                selectedRule1 = null;
            }
            else if (selectedRule1._ruleInfo.target == RuleInfo.RuleTarget.Weapon)
            {
                selectedRule1.DeactivateWeapon(playerWeapon);
                selectedRule1 = null;
            }
        }

        if (selectedRule2 != null)
        {
            if (selectedRule2._ruleInfo.target == RuleInfo.RuleTarget.Global)
            {
                selectedRule2.Deactivate();
                selectedRule2 = null;
            }
            else if (selectedRule2._ruleInfo.target == RuleInfo.RuleTarget.Player)
            {
                selectedRule2.DeactivatePlayer(playerMovement);
                selectedRule2 = null;
            }
            else if (selectedRule2._ruleInfo.target == RuleInfo.RuleTarget.Weapon)
            {
                selectedRule2.DeactivateWeapon(playerWeapon);
                selectedRule2 = null;
            }
        }
        if (selectedRule3 != null)
        {
            if (selectedRule3._ruleInfo.target == RuleInfo.RuleTarget.Global)
            {
                selectedRule3.Deactivate();
                selectedRule3 = null;
            }
            else if (selectedRule3._ruleInfo.target == RuleInfo.RuleTarget.Player)
            {
                selectedRule3.DeactivatePlayer(playerMovement);
                selectedRule3 = null;
            }
            else if (selectedRule3._ruleInfo.target == RuleInfo.RuleTarget.Weapon)
            {
                selectedRule3.DeactivateWeapon(playerWeapon);
                selectedRule3 = null;
            }
        }
    }
}
