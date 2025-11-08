using System.Threading.Tasks;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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
        canTakeDamage = false;
        IFrames();
        if (currentHP <= 0) 
        {
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
        await Task.Delay(IMs);
        canTakeDamage = true;
    }
}
