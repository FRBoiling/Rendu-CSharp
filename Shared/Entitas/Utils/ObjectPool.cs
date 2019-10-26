using System;
using System.Collections.Generic;

namespace Entitas.Utils
{
    public class ObjectPool<T>
    {
        private readonly Func<T> _factoryMethod;
        private readonly Stack<T> _objectPool;
        private readonly Action<T> _resetMethod;

        public ObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null)
        {
            _factoryMethod = factoryMethod;
            _resetMethod = resetMethod;
            _objectPool = new Stack<T>();
        }

        public T Get()
        {
            if (_objectPool.Count != 0)
                return _objectPool.Pop();
            return _factoryMethod();
        }

        public void Push(T obj)
        {
            if (_resetMethod != null)
                _resetMethod(obj);
            _objectPool.Push(obj);
        }
    }
}