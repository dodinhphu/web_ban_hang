//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhuDD4_MorckProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.carts = new HashSet<cart>();
        }
    
        public int product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<System.DateTime> CREATE_date { get; set; }
        public string product_description { get; set; }
        public string product_short_description { get; set; }
        public string product_img { get; set; }
        public Nullable<decimal> product_price { get; set; }
        public Nullable<int> number { get; set; }
        public string origin { get; set; }
        public string trademark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cart> carts { get; set; }
        public virtual category category { get; set; }
    }
}