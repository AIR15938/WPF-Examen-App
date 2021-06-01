using Prism.Events;

namespace WPF.Event
{
    public class EntitySavedEvent : PubSubEvent<EntitySavedEventArgs>
    {
    }

    public class EntitySavedEventArgs
    { 
        public int Id { get; set; }

        public string DisplayMember { get; set; }
    }
}
