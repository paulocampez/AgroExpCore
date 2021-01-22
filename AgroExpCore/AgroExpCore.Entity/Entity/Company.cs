using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroExpCore.Entity
{
    public class Company : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string TaxCode { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
