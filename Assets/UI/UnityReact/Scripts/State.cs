using System;

namespace MetaClass.UI.UnityReact.Scripts
{
    public class State<T> : Reference<T>,IState
    {

        private ComponentUI component;

        private T _value;

        public State(T value, ComponentUI component)
        {
            this.component = component;
            _value = value;
            this.component.AddState(this);
        }

        public override T Value
        {
            get => _value;
            set
            {
                component.StateHasChanged(Id,value);
            }
        }

        public void SetState(object newValue)
        {
            _value = (T)newValue;
        }
        
        public int Id { get; set; }
    }
}