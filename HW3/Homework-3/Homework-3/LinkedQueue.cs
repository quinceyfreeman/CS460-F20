using System;
namespace Homework_3
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public bool IsEmpty()
        {
            if (front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Peek()
        {
            if (IsEmpty() )
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            else
            {
                return front.data;
            }
        }

        public T Pop()
        {
            T tmp;

            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }

        public T Push(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                front = tmp;
                rear = tmp;
            }

            else
            {
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }
    }
}
