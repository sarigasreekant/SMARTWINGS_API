using ForexModel;

namespace Helper
{
    public  class AppSession
    {
        public  string LocalCurcode { get; set; } = SD.LocalCurCode;
        public  string Orgcode { get; set; } = SD.OrgCode;
        public  string BranchCode { get; set; } = SD.HeadOfficeBranchCode;
        public  string UserGroup { get; set; } = SDUserGroup.AdminUserGroup;

        public static string ServerDateTime { get; set; } = SD.serverTimeDDMMYYYY();
        
    }
}
