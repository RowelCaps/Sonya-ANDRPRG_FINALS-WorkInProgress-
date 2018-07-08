using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    private int strength, vitality, luck;
    private int level = 1, maxLvl = 30;

	public int Strength
    {
        get { return strength; }
    }

    public int Endurance
    {
        get { return vitality; }
    }

    public int Luck
    {
        get { return luck; }
    }

    public int Level
    {
        get { return level; }
    }

    public int MaxLevel
    {
        get { return maxLvl; }
    }

    void Start () {

        strength = Random.Range(1, 10);
        vitality = Random.Range(1, 10);
        luck = Random.Range(1, 10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp()
    {
        if (level + 1 > 30)
            return;

        level++;

        strength += Random.Range(1, level);
        vitality += Random.Range(1, level);
        luck += Random.Range(1, level);
    }

    private void addBonusMaxHealth()
    {
        Health health = GetComponent<Health>();

        if (health == null)
            return;

        health.MaxHealth += (2 * strength) * level;
    }
}
