using System.ComponentModel.DataAnnotations;

namespace Chapel.Entity
{
    class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
