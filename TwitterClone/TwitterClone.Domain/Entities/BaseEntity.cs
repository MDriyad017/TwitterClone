using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid? ModifiedBy { get; private set; }

        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        public virtual string DescribeRecord()
        {
            return $"BaseEntity: Id: {Id}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt}, CreatedBy: {CreatedBy}, ModifiedBy: {ModifiedBy}";
        }
    }
}
