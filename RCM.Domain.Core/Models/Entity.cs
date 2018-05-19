using MediatR;
using RCM.Domain.Core.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RCM.Domain.Core.Models
{
    public abstract class Entity<T>
    {
        public Guid Id { get; protected set; }

        private List<INotification> _events;
        private List<DomainError> _errors;

        [NotMapped]
        public IReadOnlyList<INotification> Events
        {
            get
            {
                return _events;
            }
        }

        [NotMapped]
        public IReadOnlyList<DomainError> Errors
        {
            get
            {
                return _errors;
            }
        }


        public Entity()
        {
            Id = Guid.NewGuid();

            _events = new List<INotification>();
            _errors = new List<DomainError>();
        }

        public void AddDomainEvent(INotification notification)
        {
            _events.Add(notification);
        }

        public bool ContainsErrors()
        {
            return _errors.Any();
        }

        public void AddDomainError(string description, string code = null)
        {
            _errors.Add(new DomainError(description, code));
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;
            if (other.GetType() != GetType() || other == null) return false;

            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (397 * Id.GetHashCode());
        }
    }
}
