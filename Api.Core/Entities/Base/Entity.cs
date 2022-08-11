using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Entities.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime CreatedDate { get; set; }
        //DateTime? UpdatedDate { get; set; }
        //int? UpdatedBy { get; set; }
        bool Deleted { get; set; }
        //Guid Guid { get; set; }
    }

    public abstract class BaseEntity
    { }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        /// <summary>
        /// Identity number for the entity
        /// </summary>
        public virtual T Id { get; set; }
        public virtual bool Deleted { get; set; } = false;
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
