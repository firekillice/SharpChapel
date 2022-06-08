using System.ComponentModel.DataAnnotations;

namespace Chapel.Entity
{
    internal class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
