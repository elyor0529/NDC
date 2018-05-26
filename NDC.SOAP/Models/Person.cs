using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NDC.Common.Enums;

namespace NDC.SOAP.Models
{
    /// <summary>
    /// Person table
    /// </summary>
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(50, 250)]
        public int Height { get; set; }

        [Required]
        [Range(50, 150)]
        public double Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}