namespace ForexModel
{
    public class AccountsMaster
    {
        public int? ORGCODE { get; set; } = 1;

        public string? ACCCODE { get; set; } 


        public string? DESCRIPTION { get; set; } 


        public string? ACCGRPCODE { get; set; }

        public string? ACCGRPNAME { get; set; } 
        public string TREEPATH { get; set; } = "";
        public string BRANCHFLAG { get; set; } = "N";
        public string ENTRYFLAG { get; set; } = "N";
        public string CURCODE { get; set; } = "N";
        public string REVALFLAG { get; set; } = "N";
        public string LANGCODE { get; set; } = "EN";
        public string USERID { get; set; } = "ADMIN";
        public int ACCLEVEL { get; set; } = 1;
        public string CURTYPECODE { get; set; } = "1";
        public string ISCONTROLACNT { get; set; } = "Y";
        public DateTime CREATEDATE { get; set; } = System.DateTime.Now;
        public string CBGLCODE { get; set; } = "";
        public string CBGLCODESCRIPTION { get; set; } = "";
        public string PAYMENTFLG { get; set; } = "N";
    }
}
