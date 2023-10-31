using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int block;
    public Dictionary<Effect, int> effects;

    public void TakeDamage(int damage, bool ignoreBlock = false)
    {
        if (effects.ContainsKey(Effect.Vulnerable))
            damage = (int)(damage * 1.5f);

        if (!ignoreBlock)
        {
            if (damage <= block)
            {
                block -= damage;
                damage = 0;
            }
            else
            {
                damage -= block;
                block = 0;
            }
        }

        health -= damage;

        if (health < 0) health = 0;
    }

    public void StartTurn()
    {
        if (effects.ContainsKey(Effect.Metallicize))
        {
            block += effects[Effect.Metallicize];
        }

        if (effects.ContainsKey(Effect.Poison))
        {
            TakeDamage(effects[Effect.Poison], true);
        }
    }

    public void EndTurn()
    {
        if (effects.ContainsKey(Effect.Vulnerable))
        {
            effects[Effect.Vulnerable]--;
            if (effects[Effect.Vulnerable] <= 0)
                effects.Remove(Effect.Vulnerable);
        }

        if (effects.ContainsKey(Effect.Weak))
        {
            effects[Effect.Weak]--;
            if (effects[Effect.Weak] <= 0)
                effects.Remove(Effect.Weak);
        }

        if (effects.ContainsKey(Effect.Frail))
        {
            effects[Effect.Frail]--;
            if (effects[Effect.Frail] <= 0)
                effects.Remove(Effect.Frail);
        }

        if (effects.ContainsKey(Effect.Poison))
        {
            effects[Effect.Poison]--;
            if (effects[Effect.Poison] <= 0)
                effects.Remove(Effect.Poison);
        }

        if (effects.ContainsKey(Effect.StrengthDown))
        {
            if (effects.ContainsKey(Effect.Strength))
                effects[Effect.Strength] -= effects[Effect.StrengthDown];
            else
                effects[Effect.Strength] = -effects[Effect.StrengthDown];

            effects.Remove(Effect.StrengthDown);
        }

        if (effects.ContainsKey(Effect.DexterityDown))
        {
            if (effects.ContainsKey(Effect.Dexterity))
                effects[Effect.Dexterity] -= effects[Effect.DexterityDown];
            else
                effects[Effect.Dexterity] = -effects[Effect.DexterityDown];

            effects.Remove(Effect.DexterityDown);
        }

        // Block removal
        if (effects.ContainsKey(Effect.Blur))
        {
            effects[Effect.Blur]--;
            if (effects[Effect.Blur] <= 0)
                effects.Remove(Effect.Blur);
        }
        else block = 0;

        // Remove unnecessary effects
        foreach (KeyValuePair<Effect, int> k in effects)
            if (k.Value == 0) effects.Remove(k.Key);
    }
}

public enum Effect
{
    None,
    Vulnerable,
    Weak,
    Frail,
    Strength,
    Dexterity,
    Metallicize,
    Thorns,
    Poison,
    StrengthDown,
    DexterityDown,
    Blur,
    Etos,
    Patos,
    Logos,
    Kairos
}