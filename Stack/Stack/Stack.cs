using System.Collections;

namespace Stack.Stack
{
    sealed class CustomStack<T> : IEnumerable<T>
    {
        Node<T> peek;
        Node<T> start;
        public int count { get; private set; } = 0;

        public Node<T> FindElementInStack(T findItem)
        {
            var duplePick = peek;
            while(duplePick.Next is not null)
            {
                if (duplePick.Next.Data.Equals(findItem))
                    return duplePick;
                duplePick = duplePick.Next;
            }
            return null;
        }

        public void Push(T element)
        {
            var elementToAdd = new Node<T>(element);
            if (peek is null)
            {
                peek = elementToAdd;
                start = peek;
            }
            else
            {
                elementToAdd.Next = peek;
                peek = elementToAdd;
            }
            count++;
        }
        public bool Pop(T item)
        {
            var popElement = FindElementInStack(item);
            if (popElement != null)
            {
                popElement.Next = popElement.Next.Next;
                return true;
            }
            else if (popElement == null && count != 0)
                peek = peek.Next;
            return false;
        }
        public T Peek()
        {
            if (peek is null)
                return default;

            return peek.Data;
        }

        public bool IsEmpty()
        {
            if (peek is null)
                return true;
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var duplePick = peek;
            while(duplePick is not null)
            {
                yield return duplePick.Data;
                duplePick = duplePick.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
