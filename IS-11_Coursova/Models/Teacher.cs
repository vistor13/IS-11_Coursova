//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IS_11_Coursova.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.Load = new HashSet<Load>();
        }
    
        public int TeacherID { get; set; }
        public string Full_Name { get; set; }
        public int TeacherRankID { get; set; }
        public int Work_hours { get; set; }
        public bool Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Load> Load { get; set; }
        public virtual TeacherRank TeacherRank { get; set; }
    }
}