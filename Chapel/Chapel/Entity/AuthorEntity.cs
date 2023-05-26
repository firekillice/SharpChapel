using System.ComponentModel.DataAnnotations;

namespace Chapel.Entity
{
    class AuthorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string? AuthorName { get; set; }
    }
}
