using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum HealthCanvasType
{
    world, screenSpace
};

public class Health : MonoBehaviour {

    [SerializeField] Image healthBar;
    [SerializeField] string canvasName;
    [SerializeField] private int maxHealth = 30;
    [SerializeField] HealthCanvasType canvasType;
    private int currentHealth = 0;

    public int MaxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value;
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

	// Use this for initialization
	void Start () {

        if (canvasType == HealthCanvasType.world)
            healthBar = transform.Find("HealthCanvas").Find("HealthBG").Find("Health").GetComponent<Image>();
        else
            healthBar = GameObject.FindGameObjectWithTag("HUD").transform.Find("HealthBG").Find("Health").GetComponent<Image>();

        currentHealth = maxHealth;
	}

    private void Update()
    {
         healthBar.fillAmount = (float)currentHealth / maxHealth;
        
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
            return true;

        return false;
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage <= 0? 0 : currentHealth - damage;
    }
}
