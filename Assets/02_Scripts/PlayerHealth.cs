using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UIController_HUD _hud;

    public float maxHP;
    public float currentHP;
    private int IMs = 500;
    private bool canTakeDamage = true;
    public void TakeDamage(float damage) 
    {
        if (!canTakeDamage) 
        { 
            return; 
        }
        currentHP -= damage;
        _hud.DisplayPlayerHeath(currentHP);
        canTakeDamage = false;
        IFrames();
        if (currentHP <= 0) 
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //DEAD
        }
    }

    public void Heal(float amount) 
    {
        currentHP += amount;
        if (currentHP > maxHP) 
        {
            currentHP = maxHP;

        }
    }

    public void HealFull()
    {
        currentHP = maxHP;
    }


    private async void IFrames() 
    {
        if(this == null) 
        {
            return ;
        }
        await Task.Delay(IMs);
        canTakeDamage = true;
    }
}
