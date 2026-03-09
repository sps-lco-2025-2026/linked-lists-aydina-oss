using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    public class IntegerLinkedList
    {
        IntegerNode _head;

        public IntegerLinkedList()
        {
            _head = null;
        }

        public IntegerLinkedList(int v)
        {
            _head = new IntegerNode(v);
        }

        public int Count => _head == null ? 0 : _head.Count;
        public int Sum => _head == null ? 0 : _head.Sum;

        public void Append(int v)
        {
            if (_head == null)
                _head = new IntegerNode(v);
            else
                _head.Append(v);

        }

        public override string ToString()
        {
            return _head == null ? "{}" : $"{{{_head}}}";
        }
    }
    class IntegerNode
    {
        int _value;
        IntegerNode _next;

        internal int Count => _next == null ? 1 : 1 + _next.Count;
            
        internal int Sum => _next == null ? _value : _value + _next.Sum;


        internal IntegerNode(int v)
        {
            _value = v;
            _next = null;
        }

        internal void Append(int v)
        {
            if (_next == null)
                _next = new IntegerNode(v);
            else
                _next.Append(v);
        }

        public override string ToString()
        {
            return _next == null ? _value.ToString() : $"{_value}, {_next}";
        }
    }
}