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
    
    public partial class don_dat_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public don_dat_hang()
        {
            this.don_hang_chitiet = new HashSet<don_hang_chitiet>();
        }
    
        public int order_id { get; set; }
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_phone { get; set; }
        public Nullable<System.DateTime> date_order { get; set; }
        public decimal total_price { get; set; }
        public Nullable<bool> status { get; set; }
    
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<don_hang_chitiet> don_hang_chitiet { get; set; }
    }
}
