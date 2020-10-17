using System;
namespace Homework_3
{
    public interface IQueueInterface
    {
        T Push<T>(T element);

        T Pop<T>();

        T Peek<T>();

        bool IsEmpty();
    }
}
