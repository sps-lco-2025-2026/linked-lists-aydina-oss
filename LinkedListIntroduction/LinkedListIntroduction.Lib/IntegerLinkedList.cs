using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    public class IntegerLinkedList
    {
        internal IntegerNode _head;

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

        public virtual void Append(int v)
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

        public void Prepend(int v)
        {
            var newNode = new IntegerNode(v);
            newNode._next = _head;
            _head = newNode;
        }

        public bool Delete(int v)
        {
            if (_head == null) return false;

            if (_head._value == v)
            {
                _head = _head._next;
                return true;
            }

            var current = _head;
            while (current._next != null)
            {
                if (current._next._value == v)
                {
                    current._next = current._next._next;
                    return true;
                }
                current = current._next;
            }
            return false;
        }

        public void Insert(int v, int index)
        {
            if (index == 0)
            {
                Prepend(v);
                return;
            }

            var current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
                current = current._next;
            }

            var newNode = new IntegerNode(v);
            newNode._next = current._next;
            current._next = newNode;
        }

        public void Join(IntegerLinkedList otherList)
        {
            if (otherList._head == null) return;
            if (_head == null)
            {
                _head = otherList._head;
                return;
            }

            var current = _head;
            while (current._next != null)
            {
                current = current._next;
            }
            current._next = otherList._head;
        }

        public bool Contains(int v)
        {
            var current = _head;
            while (current != null)
            {
                if (current._value == v) return true;
                current = current._next;
            }
            return false;
        }

        public void RemoveDuplicates()
        {
            if (_head == null) return;

            var current = _head;
            while (current != null)
            {
                var runner = current;
                while (runner._next != null)
                {
                    if (runner._next._value == current._value)
                    {
                        runner._next = runner._next._next;
                    }
                    else
                    {
                        runner = runner._next;
                    }
                }
                current = current._next;
            }
        }

        public void Merge(IntegerLinkedList otherList)
        {
            var current1 = _head;
            var current2 = otherList._head;

            while (current1 != null && current2 != null)
            {
                var next1 = current1._next;
                var next2 = current2._next;

                current1._next = current2;
                if (next1 == null) break;
                current2._next = next1;

                current1 = next1;
                current2 = next2;
            }
        }

        public IntegerLinkedList Reverse()
        {
            var newList = new IntegerLinkedList();
            var current = _head;
            while (current != null)
            {
                newList.Prepend(current._value);
                current = current._next;
            }
            return newList;
        }
    }

    class IntegerNode
    {
        internal int _value;
        internal IntegerNode _next;

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

    public class SortedIntegerLinkedList : IntegerLinkedList
    {
        public SortedIntegerLinkedList() : base() { }
        public SortedIntegerLinkedList(int v) : base(v) { }

        public override void Append(int v)
        {
            var newNode = new IntegerNode(v);

            if (_head == null || _head._value >= v)
            {
                newNode._next = _head;
                _head = newNode;
                return;
            }

            var current = _head;
            while (current._next != null && current._next._value < v)
            {
                current = current._next;
            }

            newNode._next = current._next;
            current._next = newNode;
        }
    }
}