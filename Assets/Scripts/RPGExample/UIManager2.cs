using UnityEngine;
using UnityEngine.UI;

public class UIManager2  : MonoBehaviour, IRPGListener
{
    public int variable1;

    public GameObject icon;

    public GameObject panelParent;

    [SerializeField]
    public Slider healthBar;
    [SerializeField]
    public Slider manaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("UIManager");
        RPGEventManager.Instance.AddListener(RPGEvents.HEALTH_CHANGED, this);
        RPGEventManager.Instance.AddListener(RPGEvents.MANA_CHANGED, this);
        RPGEventManager.Instance.AddListener(RPGEvents.STATUS_ADDED, this);
        RPGEventManager.Instance.AddListener(RPGEvents.STATUS_REMOVED, this);

    }
    private void OnDestroy()
    {
        RPGEventManager.Instance.RemoveListener(RPGEvents.HEALTH_CHANGED, this);
        RPGEventManager.Instance.RemoveListener(RPGEvents.MANA_CHANGED, this);
        RPGEventManager.Instance.RemoveListener(RPGEvents.STATUS_ADDED, this);
        RPGEventManager.Instance.RemoveListener(RPGEvents.STATUS_REMOVED, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEvent(RPGEvents eventType, Component sender, object param = null)
    {
        Debug.Log("SHould call");
        switch (eventType) {
            case RPGEvents.HEALTH_CHANGED:
                Debug.Log("Health called");
                healthBar.value = (int)param / 100.0f;
                break;

            case RPGEvents.MANA_CHANGED:
                manaBar.value = (int)param / 100.0f;
                break;

            case RPGEvents.STATUS_ADDED:
                Debug.Log("UI MANAGERS ACCEPTS THIS");
                var go = Instantiate(icon, panelParent.transform, false);
                break;

            case RPGEvents.STATUS_REMOVED:
                break;
        }

    }
}
