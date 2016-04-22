using System;
using System.Collections.Generic;

namespace DCS.Domain.SharedKernel.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        List<T> GetValues();
    }
}
