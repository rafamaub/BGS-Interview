using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

[System.Serializable]
public class EmptyEvent : UnityEvent
{

}
[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> 
{ 
}


public class MainEventListener : MonoBehaviour
{
    public MainEvent gEvent;
    //public UnityEvent response;
    public IntEvent response = new IntEvent();

    private void OnEnable()
    {
        gEvent.Register(this);
    }

    private void OnDisable()
    {
        gEvent.Unregister(this);
    }

    public void OnEventOccurs(int amount)
    {
        response.Invoke(amount);
    }
}
