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

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerWeapon = FindObjectOfType<Weapon>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed");
            SelectRule();
        }
    }

    public void SelectRule()
    {
        Rule selectedRule1 = new Rule(rules[Random.Range(0, rules.Count)]);
        Rule selectedRule2 = new Rule(rules[Random.Range(0, rules.Count)]);
        Rule selectedRule3 = new Rule(rules[Random.Range(0, rules.Count)]);
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
}
