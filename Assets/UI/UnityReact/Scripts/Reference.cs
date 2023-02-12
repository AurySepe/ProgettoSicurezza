namespace MetaClass.UI.UnityReact.Scripts
{
    public class Reference<T> 
    {
        public virtual T Value { get; set; }
        

        public Reference(T value)
        {
            Value = value;
        }

        public Reference()
        {
            
        }
        
    }
}