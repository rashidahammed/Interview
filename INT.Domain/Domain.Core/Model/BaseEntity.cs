using System.ComponentModel.DataAnnotations;

namespace INT.Domain.Domain.Core.Model
{
    public class BaseEntity<IdType>
    {
        [Key]
        public IdType Id { get; set; }
    }
}
