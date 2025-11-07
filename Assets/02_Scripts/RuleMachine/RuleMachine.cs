using System.Threading.Tasks;
using UnityEngine;

public class RuleMachine : MonoBehaviour
{
    [SerializeField] UIController_RuleMachineSlot slot1;
    [SerializeField] UIController_RuleMachineSlot slot2;
    [SerializeField] UIController_RuleMachineSlot slot3;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            SpinTheMachine();
        }
    }


    private async void SpinTheMachine()
    {
        slot1.Spin();
        await Task.Delay(2);

        slot2.Spin();
        await Task.Delay(2);

        slot3.Spin();
        await Task.Delay(2);
    }
}
