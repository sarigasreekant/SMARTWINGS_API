using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ForexModel
{
    public class OrgnizationBranchSearch
    {
        public string OrgCode { get; set; } = "";
        public string? BranchName { get; set; } = "";

    }
}