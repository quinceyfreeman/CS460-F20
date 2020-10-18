using System;
namespace Homework_3
{
    public class QueueUnderflowException : Exception
    {
        public QueueUnderflowException()
            : base()
        {

        }
        public QueueUnderflowException(string message)
            : base(message)
        {

        }
    }
}
