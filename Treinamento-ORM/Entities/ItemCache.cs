using System;

namespace Treinamento_ORM
{
    public class ItemCache<T>
    {
        internal int key;
        internal T value;
        internal DateTime ultimaAtualizacao;
        internal TypeItem type;
        internal ItemCache(int key, T value, TypeItem typeItem = TypeItem.ANY)
        {
            this.key = key;
            this.value = value;
            type = typeItem;
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