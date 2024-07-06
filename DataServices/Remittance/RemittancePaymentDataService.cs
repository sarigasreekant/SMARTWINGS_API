using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class RemittancePaymentDataService
    {
        private readonly ISqlDataAccess Db;
        public RemittancePaymentDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<int> SaveremittancePayment(RemittancePayment remittancePayment)
        {
            string sql = @"exec USP_VN_TRN_Insert_PAYMODE  @PortalCode, @OrgCode, @MenuCode, @RefNo, @PayRefNo, @TranDate, @UserCode, @PayCode, @AccountCode, @PayCurCode, @PayAmount, @Rate, @CLCYAmount, @Discount, @LCYAmount";
            var parameters = new DynamicParameters();
            parameters.Add("RefNo", remittancePayment.RefNo.ToUpper(), DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
    }
}
