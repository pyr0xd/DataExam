using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class CustomerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; //HASH!!!!
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public virtual CartEntity? Cart { get; set; }
       
    }
}
