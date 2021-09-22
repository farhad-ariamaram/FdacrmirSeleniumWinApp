using System;
using System.Collections.Generic;

#nullable disable

namespace FdacrmirSeleniumWinApp.Models
{
    public partial class TblDetail
    {
        public long Id { get; set; }
        public string FldManufacturingLicenseNumber { get; set; }
        public long? FldProductId { get; set; }
        public long? FldBrandId { get; set; }
        public long? FldPackingDetailsId { get; set; }
        public long? FldFactoryNameId { get; set; }
        public long? FldAddressId { get; set; }
        public long? FldTelephoneNumberId { get; set; }
        public string FldIssueDate { get; set; }
        public string FldExpireDate { get; set; }

        public virtual TblAddress FldAddress { get; set; }
        public virtual TblBrand FldBrand { get; set; }
        public virtual TblPackingDetail FldPackingDetails { get; set; }
        public virtual TblProduct FldProduct { get; set; }
        public virtual TblTelephoneNumber FldTelephoneNumber { get; set; }
    }
}
