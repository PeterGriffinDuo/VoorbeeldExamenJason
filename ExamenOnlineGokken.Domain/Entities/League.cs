using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.Domain.Entities
{
    public class League
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
