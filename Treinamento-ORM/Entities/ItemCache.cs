using System;

namespace Treinamento_ORM
{
    public class ItemCache<T>
    {
        internal int key;
        internal T value;
        internal ItemCache(int key, T value)
        {
            this.key = key;
            this.update(value);
        }
        internal void update(T value)
        {
            this.value = value;
        }
    }
}