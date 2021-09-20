using System;

namespace Assets.Client.Scripts.Helpers
{
    public class ReactiveProperty<T>
    {
        private T value;
        public T Value
        {
            get => value;
            set
            {
                if (this.value.Equals(value))
                    return;

                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }

        public event Action<T> OnValueChanged;
    }
}