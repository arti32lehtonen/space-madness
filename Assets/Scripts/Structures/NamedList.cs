using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceMadness.Structures
{
    /// <summary>
    /// NamedList is a collection for a sequence of elements.
    /// Its defined by a collection of elements of type TValue and
    /// by a Enum which defines the set of possible labels and the length.
    /// You can access ith element as usual using [i].
    /// You also can access element by enum label using GetByLabel and SetByLabel.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TEnum"></typeparam>
    [Serializable]
    public class NamedList<TValue, TEnum> : IEnumerable<TValue> where TEnum : Enum
    {
        [SerializeField] private List<TValue> _values;
        // we need this for the Unity Property Drawer
        [SerializeField] private TEnum _enumContainer;
        private static Dictionary<TEnum, int> _fieldToIndex;
        
        public TValue this[int i]
        {
            get => _values[i];
            set => _values[i] = value;
        }
        
        public int Length => _values.Count;
        
        public NamedList()
        {
            var fields = Enum.GetValues(typeof(TEnum));
            _fieldToIndex = new Dictionary<TEnum, int>();
            int lastIndex = 0;
            
            foreach (TEnum field in fields)
            {
                var index = Array.IndexOf(fields, field);
                _fieldToIndex[field] = index;
                lastIndex++;
            }
            
            _values = new List<TValue>(new TValue[lastIndex]);
        }

        public TValue GetByField(TEnum field)
        {
            return this[_fieldToIndex[field]];
        }

        public void SetByField(TEnum field, TValue value)
        {
            this[_fieldToIndex[field]] = value;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<TEnum> GetFields()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }

        public IEnumerable<KeyValuePair<TEnum, TValue>> IterateThroughPairs()
        {
            foreach (TEnum field in Enum.GetValues(typeof(TEnum)))
            {
                var content = GetByField(field);
                yield return new KeyValuePair<TEnum, TValue>(field, content);
            }
        }
    }
}