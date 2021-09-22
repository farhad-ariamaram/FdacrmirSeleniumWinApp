using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblPackingDetail
    {
        public TblPackingDetail()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public long Id { get; set; }
        public string FldPackingDetails { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
