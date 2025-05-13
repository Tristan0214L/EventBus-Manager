using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour, IRPGListener
{
    [SerializeField]
    Character character;
    //Status effects: 
    //ticking
    //what status effect
    //duration
    //tick rate


    /// <summary>
    /// Effect Type
    /// Duration
    /// Tick Rate
    /// TickRateRemaining
    /// </summary>
    /// 
    [Serializable]
    class StatusEffect
    {
        public RPGStatusEffects type;
        public float duration;
        public float tickRate;
        public float tickRateRemaining;
    }
    [SerializeField] List<StatusEffect> activeStatusEffects = new List<StatusEffect>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddStatusEffect(RPGStatusEffects.POISONED, 10.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //go through each status effect
        //minus the duration
        //check the tick rate
        //check the type 
        //Activate Effect
        //if duration cancel effect

        List<RPGStatusEffects> toBeRemoved = new List<RPGStatusEffects> ();

        foreach (var statusEffect in activeStatusEffects)
        {
            Debug.Log("Hey there is a status running");
            //- duration
            statusEffect.duration -= Time.deltaTime;
            statusEffect.tickRateRemaining -= Time.deltaTime;

            if(statusEffect.tickRateRemaining <= 0)
            {
                //apply status effect
                switch (statusEffect.type)
                {
                    case RPGStatusEffects.BURNING:
                        character.Health -= 5;
                        break;

                    case RPGStatusEffects.STUNNED:
                        Debug.Log("Character is currently stunned");
                        break;

                    case RPGStatusEffects.POISONED:
                        character.Health -= 20;
                        break;

                    default:

                        break;
                }


                //reset timer
                statusEffect.tickRateRemaining = statusEffect.tickRate;
            }

            //check duration
            if(statusEffect.duration <= 0) {
                //cancel effect
                toBeRemoved.Add(statusEffect.type); 
                //RemoveStatusEffect(statusEffect.type);
            }

        }
        foreach(var statusType in toBeRemoved)
        {
            RemoveStatusEffect(statusType);
        }
        toBeRemoved.Clear();


    }

    public void AddStatusEffect(RPGStatusEffects type, float duration, float tickRate)
    {
        StatusEffect newStatusEffect = new StatusEffect();
        newStatusEffect.type = type;
        newStatusEffect.duration = duration;
        newStatusEffect.tickRate = tickRate;
        newStatusEffect.tickRateRemaining = 0;

        activeStatusEffects.Add(newStatusEffect);
    }
    public void RemoveStatusEffect(RPGStatusEffects type)
    {
        StatusEffect toBeRemoved = null;
        foreach(StatusEffect effect in activeStatusEffects)
        {
            if(effect.type == type)
            {
                //temp variable incase this breaks
                toBeRemoved = effect;
               // activeStatusEffects.Remove(effect);
            }
        }
        if (toBeRemoved != null) {
            activeStatusEffects.Remove(toBeRemoved);
        }

    }
    public void OnEvent(RPGEvents eventType, Component sender, object param = null)
    {
        throw new System.NotImplementedException();
    }
}
