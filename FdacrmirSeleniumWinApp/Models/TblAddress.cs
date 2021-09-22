using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblAddress
    {
        public TblAddress()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public long Id { get; set; }
        public string FldAddress { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
