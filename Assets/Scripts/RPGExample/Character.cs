using UnityEngine;

public class Character : MonoBehaviour, IRPGListener
{
    private int health;
    private int mana;

    public int Health
    {
        get { return health; }
        set { 

            var newHealth = Mathf.Clamp(value, 0, 100);
            if(health != newHealth)
            {
                health = newHealth;
                RPGEventManager.Instance.PostNotification(RPGEvents.HEALTH_CHANGED, this, health);
            }

        }
    }
    public int Mana
    {
        get { return mana; }
        set
        {

            var newMana = Mathf.Clamp(value, 0, 100);
            if (mana != newMana)
            {
                mana = newMana;
                RPGEventManager.Instance.PostNotification(RPGEvents.MANA_CHANGED, this, mana);
            }

        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RPGEventManager.Instance.AddListener(RPGEvents.HEALTH_CHANGED, this);
        RPGEventManager.Instance.AddListener(RPGEvents.MANA_CHANGED, this);
        
    }
    private void OnDestroy()
    {
        RPGEventManager.Instance.RemoveListener(RPGEvents.HEALTH_CHANGED, this);
        RPGEventManager.Instance.RemoveListener(RPGEvents.MANA_CHANGED, this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEvent(RPGEvents eventType, Component sender, object param = null)
    {
        switch (eventType)
        {
            case RPGEvents.HEALTH_CHANGED:
                Debug.Log($"Hello health changed {param}");
                break;

            case RPGEvents.MANA_CHANGED:
                Debug.Log($"Hello mana changed {param}");

                break;
        }
    }
}
