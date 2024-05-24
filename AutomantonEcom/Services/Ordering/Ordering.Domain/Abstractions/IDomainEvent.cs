﻿using MediatR;


namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        public Guid Id => Guid.NewGuid();
        public DateTime OccuredOn => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName!;
    }
}
