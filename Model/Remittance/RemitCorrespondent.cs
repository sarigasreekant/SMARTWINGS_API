using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ForexModel
{
    public class RemitCorrespondent
    {
        public string SERVORGCODE { get; set; }
        public string CONFIGCODE { get; set; }
        public string OrgName {  get; set; }
        public string SERVCODE {  get; set; }
        public string CodeType {  get; set; }
        public string Street {  get; set; }
        public string Address { get; set; }
        public int OrgTypeId { get; set; }
       
    }
}
