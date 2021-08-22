using System;

namespace Treinamento_ORM
{
    public class ItemCache<T>
    {
        internal int key;
        internal T value;
        internal DateTime ultimaAtualizacao;
        internal ItemCache(int key, T value)
        {
            this.key = key;
            this.update(value);
        }
        internal void update(T value)
        {
            this.value = value;
        }
        internal bool IsValid(int validadeSegundos)
        {
            return ultimaAtualizacao.AddSeconds(validadeSegundos) <= DateTime.Now;
        }
    }

    public enum TypeItem
    {
        NEW_OBJECT = 1,
        DELETE = 2,
        UPDATE = 3,
        ANY = 4
    }
}