//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class registration
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string Last_Name { get; set; }
        [Display(Name = "Identity Card Number")]
        [Required(ErrorMessage = "This field is required")]
        public string CNIC { get; set; }
        [Display(Name = "Course ID")]
        public Nullable<int> Course_ID { get; set; }
        [Display(Name = "Student ID")]
        public Nullable<int> Student_ID { get; set; }
        [Display(Name = "Assessment ID")]
        public Nullable<int> Assessment_Id { get; set; }
        [Display(Name ="Phone")]
        public Nullable<int> telNo { get; set; }
    
        public virtual Assessment Assessment { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
