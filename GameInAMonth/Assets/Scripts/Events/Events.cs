using UnityEngine.Events;



public abstract class BaseEvent : UnityEvent {
    public abstract EventType EventType {
        get;
    }
}
public class BlockDestroyedEvent : UnityEvent<BlockController> { }