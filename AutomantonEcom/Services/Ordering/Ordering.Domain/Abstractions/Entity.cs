using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T ID { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
        public DateTime LastModifiedDate { get; set; } = default!;
        public string LastModifiedBy { get; set; } = default!;
    }

    //public class Entity<T>
    //{
    //    public T ID { get; set; } = default!;
    //    public DateTime CreatedDate { get; set; } = default!;
    //    public string CreatedBy { get; set; } = default!;
    //    public DateTime LastModifiedDate { get; set; } = default!;
    //    public string LastModifiedBy { get; set; } = default!;
    //}
}
