using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class BranchModelVew
    {
      
        public string BranchCode { get; set; } = "";

        public string OrgCode { get; set; } = "";
        public string OrgName { get; set; } = "";
        public string BranchName { get; set; } = "";
        public string Address { get; set; } = "";
      
        public string Street { get; set; } = "";
      
        public string City { get; set; } = "";
     
        public string State { get; set; } = "";
    
        public string PoBox { get; set; } = "";
     
        public string Country { get; set; } = "";
     
        public string Phone { get; set; } = "";
      
        public string Mobile { get; set; } = "";
        
        public string Email { get; set; } = "";
       
        public string WindowsFlag { get; set; } = "";


        public string? InterBranchAccno { get; set; } = "";
        public string? IFSC { get; set; } = "";
    }
}
