//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace banhang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Don_Hangg
    {
        public string MaKH { get; set; }
        public string MaSP { get; set; }
        public string Don_Gia { get; set; }
        public Nullable<System.DateTime> Ngay_Dat { get; set; }
        public Nullable<byte> Trang_Thai { get; set; }
    
        public virtual Danhmuc_SP Danhmuc_SP { get; set; }
        public virtual Khach_Hang Khach_Hang { get; set; }
    }
}
