public class EventAttacherDetacher
{
    public delegate void EventAttachDetach();

    public void AttachDetach<T>(T obj, EventAttachDetach Event)
    {
        if (obj != null)
        {
            Event();
        }
    }
}