using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RuleMachine : MonoBehaviour
{
    [SerializeField] UIController_RuleMachineSlot slot1;
    [SerializeField] UIController_RuleMachineSlot slot2;
    [SerializeField] UIController_RuleMachineSlot slot3;

    [SerializeField] public List<RuleInfo> _allRulez = new List<RuleInfo>();






    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed");
            SpinTheMachine();
        }


        
    }


    public async void SpinTheMachine()
    {


        slot1.Spin(_allRulez[0]);
        await Task.Delay(2);

        slot2.Spin(_allRulez[1]);
        await Task.Delay(2);

        slot3.Spin(_allRulez[2]);
        await Task.Delay(2);



    }


   
}
