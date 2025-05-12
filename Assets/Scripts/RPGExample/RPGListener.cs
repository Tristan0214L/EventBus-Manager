using UnityEngine;

public interface IRPGListener
{
    //Function to invoke events,
    //we also pass in an object incase we want any parameters
    void OnEvent(RPGEvents eventType, Component sender, object param = null);
}
