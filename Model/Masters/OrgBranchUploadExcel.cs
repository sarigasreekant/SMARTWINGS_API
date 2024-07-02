using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ForexModel
{

    public class OrgBranchUploadExcel
    {
        public string BranchName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Mobile { get; set; } = "";

        public string IFSCCODE { get; set; } = "";
        public string OrgCode { get; set; } = "";
        public string BankName { get; set; } = "";
        public string City1 { get; set; } = "";
        public string City2 { get; set; } = "";

        public string Code { get; set; } = "";



    }


}
