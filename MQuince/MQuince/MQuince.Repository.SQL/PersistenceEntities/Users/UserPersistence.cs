using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities
{

    //Anotacija ispod [Table("User")] u EntityFrameworku pomocu koje se zadaje naziv tabele, ova klasa se pravi da se u Entitetima ne bi mesale anotacije, 
    //jer se tad krsi singular responsibility princip
    [Table("User")]
    public class UserPersistence
    {
        [Key] 
        public Guid Id { get; set; }
        public Usertype UserType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
