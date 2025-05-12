using System.Diagnostics.Tracing;
using UnityEngine;

public class SimpleListener : MonoBehaviour, ISimpleListener
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //add on start
        SimpleEventBus.Instance.AddListener(SIMPLE_EVENT_TYPE.EVENT_ONE, this);
    }
    private void OnDestroy()
    {
        //remove when destroyed, so errors don't occur
        SimpleEventBus.Instance.RemoveListener(SIMPLE_EVENT_TYPE.EVENT_ONE, this);
     
    }



    void Update()
    {
        // we can call this from any class but I am doing it here
        //Invoke specific event
        //SimpleEventBus.Instance.PostNotification(SIMPLE_EVENT_TYPE.EVENT_ONE, this, "Hello World");
    }
    //what to do when events are called
    public void OnEvent(SIMPLE_EVENT_TYPE eventType, Component sender, object param = null)
    {
        if (eventType == SIMPLE_EVENT_TYPE.EVENT_ONE)
        {
            Debug.Log($"Hey, event was triggered!! parameters are {param} from {sender.name}");
        }
    }
}
