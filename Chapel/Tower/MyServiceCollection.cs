﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;

namespace Tower
{
    internal class MyServiceCollection : IServiceCollection
    {
        private List<ServiceDescriptor>? _descriptors;
        public ServiceDescriptor this[int index] { get => _descriptors[index]; set => _descriptors[index] = value; }
        public MyServiceCollection()
        {
            _descriptors = new List<ServiceDescriptor>();
        }

        public int Count => _descriptors.Count;

        public bool IsReadOnly => false;

        public void Add(ServiceDescriptor item)
        {
            _descriptors.Add(item);
        }

        public void Clear()
        {
            _descriptors.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return _descriptors.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            _descriptors.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return _descriptors.IndexOf(item);  
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            _descriptors.Insert(index, item);
        }

        public bool Remove(ServiceDescriptor item)
        {
            return _descriptors.Remove(item);  
        }

        public void RemoveAt(int index)
        {
            _descriptors.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _descriptors.GetEnumerator();
        }
    }
}
