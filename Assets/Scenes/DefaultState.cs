using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : MonoBehaviour
{
    public int level = 1;
    public int requiredExp = 500;
    public int currentExp = 0;

    public int currentHealth = 100;
    public int maxHealth = 100;

    public Sprite fireball;
    public Sprite frostbite;
    public Sprite zephyr;
    public Sprite aquapulse;

    public float expFillAmount = 0f;

    public PlayerSkills playerSkills = new PlayerSkills();
}
