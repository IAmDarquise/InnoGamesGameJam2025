using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Holds all the Rules in the game, at the start of every Wave the function SelectRule will be called to choose which 
/// rules will be active for that wave, within the functions the RuleMachine will also display the names of the selected 
/// rules.
/// </summary>
public class RuleManager : MonoBehaviour
{
    [SerializeField] private List<Rule> rules = new List<Rule>();
    [SerializeField] private RuleMachine ruleMachine;

    public void SelectRule()
    {
        Rule selectedRule1 = rules[Random.Range(0, rules.Count)];
        Rule selectedRule2 = rules[Random.Range(0, rules.Count)];
        Rule selectedRule3 = rules[Random.Range(0, rules.Count)];
        selectedRule1.Use();
        selectedRule2.Use();
        selectedRule3.Use();
        ruleMachine._allRulez.Clear();
        ruleMachine._allRulez.Add(selectedRule1._ruleInfo);
        ruleMachine._allRulez.Add(selectedRule2._ruleInfo);
        ruleMachine._allRulez.Add(selectedRule3._ruleInfo);
        ruleMachine.SpinTheMachine();
    }
}
