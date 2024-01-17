using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_final.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
