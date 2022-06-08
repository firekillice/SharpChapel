using System.ComponentModel.DataAnnotations;

namespace Chapel.Entity
{
    internal class AuthorEntity
    {
        [Key]
        public int Id { get; set; } = 0;

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
