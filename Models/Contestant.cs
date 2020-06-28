//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContestantApplications.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contestant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contestant()
        {
            this.ContestantRatings = new HashSet<ContestantRating>();
        }
    
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string Address { get; set; }
    
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContestantRating> ContestantRatings { get; set; }
        public string FullName { get; internal set; }
    }
}
