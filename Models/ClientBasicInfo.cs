using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankQ1Investment.Models
{
    public class ClientBasicInfo                 //This will be the initial table for the initial migration:
    {
        [Key]           //Because this is the PK
        public int Customer_Id { get; set; }
        [Required(ErrorMessage = "Please Insert a Name")]
        [Display(Name = "Customer Name:")]
       // [RegularExpression(@"\s{1,20}",ErrorMessage ="Please insert a Name.")] //We can use Regular Expressions but, we will keep it simple for now!
        [MaxLength(20)]
        public string Customer_Name { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2)]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Currency)] //This will display the Investment in dollars $$$$
        [Range(0,10000000)]
        public int Current_Investment { get; set; }  
    }
}
