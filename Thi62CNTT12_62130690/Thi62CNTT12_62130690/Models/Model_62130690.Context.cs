﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thi62CNTT12_62130690.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Thi62CNTT12_62130690Entities : DbContext
    {
        public Thi62CNTT12_62130690Entities()
            : base("name=Thi62CNTT12_62130690Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DoiTuong> DoiTuong { get; set; }
        public virtual DbSet<HocVien> HocVien { get; set; }
    
        public virtual int HocVien_TimKiem(string hoTen, string maDT)
        {
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var maDTParameter = maDT != null ?
                new ObjectParameter("MaDT", maDT) :
                new ObjectParameter("MaDT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HocVien_TimKiem", hoTenParameter, maDTParameter);
        }
    }
}