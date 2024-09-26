using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{

    private Image healthBarImage;

    void Start()
    {
        healthBarImage = GetComponent<Image>();
    }



    public void SetHealth(float currentHealth, float maxHealth)
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

}
