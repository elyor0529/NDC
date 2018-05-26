using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Foolproof;
using NDC.Common.Enums;

namespace NDC.Common.ViewModels
{
    /// <summary>
    ///     Use a data contract as illustrated in the sample below to add composite types to service operations.
    /// </summary>
    [DataContract]
    public class SearchModel
    { 

        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Names { get; set; }

        [DataMember]
        [Required]
        [Range(5, 100)]
        [Display(Name = "Min age")]
        [LessThanOrEqualTo("MaxAge")]
        public int? MinAge { get; set; }

        [DataMember]
        [Required]
        [Range(5, 100)]
        [Display(Name = "Max age")]
        [GreaterThanOrEqualTo("MinAge")]
        public int? MaxAge { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [DataMember]
        [Range(50, 250)]
        [Display(Name = "Min heigth")]
        [LessThanOrEqualTo("MaxHeigth")]
        public int? MinHeigth { get; set; }

        [DataMember]
        [Range(50, 250)]
        [Display(Name = "Max heigth")]
        [GreaterThanOrEqualTo("MinHeigth")]
        public int? MaxHeigth { get; set; }

        [DataMember]
        [Range(50, 150)]
        [Display(Name = "Min weight")]
        [LessThanOrEqualTo("MaxWeight")]
        public double? MinWeight { get; set; }

        [DataMember]
        [Range(50, 150)]
        [Display(Name = "Max weight")]
        [GreaterThanOrEqualTo("MinWeight")]
        public double? MaxWeight { get; set; }

        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

    }
}