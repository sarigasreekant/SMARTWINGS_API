using Dapper;
using DataAccess;
using ForexModel;
//using Org.BouncyCastle.Tls;
using System.Data;
using System.Data.SqlTypes;

namespace ForexDataService
{
    public class CustomerTransactionDataService
    {
        IUnitOfWork unitOfWork = null;
        public CustomerTransactionDataService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public async Task<CustomerResponse> SaveCustomer(CustomerDTO customer_mst)
        {
            var customerResponse = new CustomerResponse();
            string Custcode = ""; 


            try
            {
                string sql = @"USP_VN_MAS_CUSTOMER";




                Custcode = await GenerateCustCode(customer_mst.Custtype.ToUpper());
                if(await IscustomerExist(Custcode) ==true)
                {
                    Custcode = await GenerateCustCode(customer_mst.Custtype.ToUpper());
                }
                //string servertime = ServerDateTime().ToString();
                var servertime = ServerDateTime();

                var parameters = new DynamicParameters();
                parameters.Add("@Custcode", Custcode.Trim(), DbType.String);
                parameters.Add("@Custtype", customer_mst.Custtype.ToUpper(), DbType.String);
                parameters.Add("@CustomerGroup", customer_mst.CustomerGroup.ToUpper(), DbType.String);
                parameters.Add("@Name1", customer_mst.Name1.ToUpper(), DbType.String);
                parameters.Add("@Name2", customer_mst.Name2.ToUpper(), DbType.String);
                parameters.Add("@Name3", customer_mst.Name3.ToUpper(), DbType.String);
                parameters.Add("@Name4", customer_mst.Name4.ToUpper(), DbType.String);
                parameters.Add("@Cell1", customer_mst.Cell1, DbType.String);
                parameters.Add("@Cell2", customer_mst.Cell2, DbType.String);
                parameters.Add("@Phone", customer_mst.Phone, DbType.String);
                parameters.Add("@Gender", customer_mst.Gender, DbType.String);
                parameters.Add("@Dob", customer_mst.Dob, DbType.DateTime);
                parameters.Add("@Adrees1", customer_mst.Adrees1.ToUpper(), DbType.String);
                parameters.Add("@Adrees2", customer_mst.Adrees2.ToUpper(), DbType.String);
                parameters.Add("@Place", customer_mst.Place.ToUpper(), DbType.String);
                parameters.Add("@Street", customer_mst.Street.ToUpper(), DbType.String);
                parameters.Add("@City", customer_mst.City.ToUpper(), DbType.String);
                parameters.Add("@State", customer_mst.State.ToUpper(), DbType.String);
                parameters.Add("@Concode", customer_mst.Concode, DbType.String);
                parameters.Add("@Country", customer_mst.Country.ToUpper(), DbType.String);
                parameters.Add("@Pobox", customer_mst.Pobox.ToUpper(), DbType.String);
                parameters.Add("@Nationcode", customer_mst.Nationcode, DbType.String);
                parameters.Add("@Nationality", customer_mst.Nationality, DbType.String);
                parameters.Add("@Profession", customer_mst.Profession, DbType.String);
                parameters.Add("@Mail", customer_mst.Mail, DbType.String);
                parameters.Add("@Fax", customer_mst.Fax, DbType.String);
                parameters.Add("@Activeflg", customer_mst.Activeflg.ToUpper(), DbType.String);
                parameters.Add("@Userid", customer_mst.Userid.ToUpper(), DbType.String);
                parameters.Add("@Branchcode", customer_mst.Branchcode.ToUpper(), DbType.String);
                parameters.Add("@Company", customer_mst.Company.ToUpper(), DbType.String);
                parameters.Add("@Photo", customer_mst.Photo, DbType.String);
                parameters.Add("@Amldoc_collected", customer_mst.Amldoc_collected, DbType.String);
                parameters.Add("@Risktype", customer_mst.Risktype, DbType.String);
                parameters.Add("@Amltype", customer_mst.Amltype, DbType.String);
                parameters.Add("@Aml_auth", customer_mst.Aml_auth, DbType.String);
                parameters.Add("@Aml_auth_user", customer_mst.Aml_auth_user, DbType.String);
                parameters.Add("@Remarks", customer_mst.Remarks.ToUpper(), DbType.String);
                parameters.Add("@Remark2", customer_mst.Remark2.ToUpper(), DbType.String);                
                parameters.Add("@Regdate", servertime, DbType.DateTime);
               
                parameters.Add("@PEP", customer_mst.PEP.ToUpper(), DbType.String);
                parameters.Add("@Allow_Forex", customer_mst.Allow_Forex, DbType.Boolean);
                parameters.Add("@Allow_Remit", customer_mst.Allow_Remit, DbType.Boolean);
                parameters.Add("@Allow_Incoming", customer_mst.Allow_Incoming, DbType.Boolean);
                parameters.Add("@Allow_Mobile", customer_mst.Allow_Mobile, DbType.Boolean);
                parameters.Add("@Residence", customer_mst.Residence, DbType.String);

                parameters.Add("@Cust_reg_module", customer_mst.Cust_reg_module, DbType.String);
                parameters.Add("@Cust_reg_UserId", customer_mst.Cust_reg_UserId, DbType.String);
                parameters.Add("Cust_reg_date", servertime, DbType.DateTime);
                parameters.Add("@Cust_reg_branch", customer_mst.Cust_reg_branch, DbType.String);
                parameters.Add("@Last_updated_by", customer_mst.Last_updated_by, DbType.String);
                parameters.Add("@Last_updated_date", servertime, DbType.DateTime);
                parameters.Add("@aml_score", customer_mst.aml_score, DbType.String);                
                parameters.Add("@IdTypeCode", customer_mst.IdTypeCode, DbType.String);
                parameters.Add("@IdType", customer_mst.IdType, DbType.String);
                parameters.Add("@IdNo", customer_mst.IdNo, DbType.String);
                parameters.Add("@IssueDate", customer_mst.IssueDate, DbType.Date);
                parameters.Add("@ExpDate", customer_mst.ExpDate, DbType.Date);
                parameters.Add("@Issueplace", customer_mst.Issueplace, DbType.String);
                parameters.Add("@ImageFront", customer_mst.ImageFront, DbType.String);
                parameters.Add("@ImageBack", customer_mst.ImageBack, DbType.String);
                parameters.Add("@ID_Activeflg", "Y", DbType.String);
                parameters.Add("@IssueContcode", customer_mst.IssueContcode, DbType.String);
                parameters.Add("@IdRemarks", customer_mst.IdRemarks, DbType.String);
                parameters.Add("@Idcollected", "Y", DbType.String);
                parameters.Add("@Primary_Id", customer_mst.Primary_Id, DbType.String);
                parameters.Add("@Occupation", customer_mst.Occupation, DbType.String);
                parameters.Add("EditOrInsert", "Insert", DbType.String);
                parameters.Add("@SuccessMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                var rval = await this.unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
                string SuccessMsg = parameters.Get<string>("SuccessMsg");
                customerResponse.CustomerCode = Custcode;
                customerResponse.StatusMesage = SuccessMsg;
                if (SuccessMsg == "SUCCESS") { 
                
                customerResponse.StatusCode = 200;
                customerResponse.IsSucess = true;
                }
                else
                {
                    customerResponse.StatusCode = 400;
                    customerResponse.IsSucess = false;
                }
                return customerResponse;

            }
            catch (Exception ex)
            {
                Custcode = "";

                customerResponse.CustomerCode = Custcode;
                customerResponse.StatusMesage = "Error" + ex.Message;
                customerResponse.StatusCode = 400;
                customerResponse.IsSucess = false;
                return customerResponse;
            }

           

        }
        public async Task<CustomerResponse> EditCustomer(CustomerDTO customer_mst)
        {
            var customerResponse = new CustomerResponse();
            // string servertime = ServerDateTime().ToString();
            var servertime = ServerDateTime();
            string sql = @"USP_VN_MAS_CUSTOMER";
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Custcode", customer_mst.Custcode, DbType.String);
                parameters.Add("@Custtype", customer_mst.Custtype, DbType.String);
                parameters.Add("@CustomerGroup", customer_mst.CustomerGroup, DbType.String);
                parameters.Add("@Name1", customer_mst.Name1, DbType.String);
                parameters.Add("@Name2", customer_mst.Name2, DbType.String);
                parameters.Add("@Name3", customer_mst.Name3, DbType.String);
                parameters.Add("@Name4", customer_mst.Name4, DbType.String);

                parameters.Add("@Cell1", customer_mst.Cell1, DbType.String);
                parameters.Add("@Cell2", customer_mst.Cell2, DbType.String);
                parameters.Add("@Phone", customer_mst.Phone, DbType.String);
                parameters.Add("@Gender", customer_mst.Gender, DbType.String);
                parameters.Add("@Dob", customer_mst.Dob, DbType.DateTime);
                parameters.Add("@Adrees1", customer_mst.Adrees1, DbType.String);
                parameters.Add("@Adrees2", customer_mst.Adrees2, DbType.String);
                parameters.Add("@Place", customer_mst.Place, DbType.String);
                parameters.Add("@Street", customer_mst.Street, DbType.String);
                parameters.Add("@City", customer_mst.City, DbType.String);
                parameters.Add("@State", customer_mst.State, DbType.String);
                parameters.Add("@Concode", customer_mst.Concode, DbType.String);
                parameters.Add("@Country", customer_mst.Country, DbType.String);
                parameters.Add("@Pobox", customer_mst.Pobox, DbType.String);
                parameters.Add("@Nationcode", customer_mst.Nationcode, DbType.String);
                parameters.Add("@Nationality", customer_mst.Nationality, DbType.String);
                parameters.Add("@Profession", customer_mst.Profession, DbType.String);
                parameters.Add("@Mail", customer_mst.Mail, DbType.String);
                parameters.Add("@Fax", customer_mst.Fax, DbType.String);
                parameters.Add("@Company", customer_mst.Company, DbType.String);
                parameters.Add("@Remarks", customer_mst.Remarks, DbType.String);
                parameters.Add("@Remark2", customer_mst.Remark2, DbType.String);
                parameters.Add("@Risktype", customer_mst.Risktype, DbType.String);
                parameters.Add("@Amltype", customer_mst.Amltype, DbType.String);
                parameters.Add("@Activeflg", customer_mst.Activeflg.ToUpper(), DbType.String);
                parameters.Add("@Userid", customer_mst.Userid.ToUpper(), DbType.String);
                parameters.Add("@Branchcode", customer_mst.Branchcode.ToUpper(), DbType.String);
                parameters.Add("@Photo", customer_mst.Photo, DbType.String);
                parameters.Add("@Amldoc_collected", customer_mst.Amldoc_collected, DbType.String);
                parameters.Add("@Aml_auth", customer_mst.Aml_auth, DbType.String);
                parameters.Add("@Aml_auth_user", customer_mst.Aml_auth_user, DbType.String);
                parameters.Add("@Regdate", servertime, DbType.Date);
                
                parameters.Add("@PEP", customer_mst.PEP.ToUpper(), DbType.String);
                parameters.Add("@Allow_Forex", customer_mst.Allow_Forex, DbType.Boolean);
                parameters.Add("@Allow_Remit", customer_mst.Allow_Remit, DbType.Boolean);
                parameters.Add("@Allow_Incoming", customer_mst.Allow_Incoming, DbType.Boolean);
                parameters.Add("@Allow_Mobile", customer_mst.Allow_Mobile, DbType.Boolean);
                parameters.Add("@Residence", customer_mst.Residence, DbType.String);

                parameters.Add("@Cust_reg_module", customer_mst.Cust_reg_module, DbType.String);
                parameters.Add("@Cust_reg_UserId", customer_mst.Cust_reg_UserId, DbType.String);
                parameters.Add("Cust_reg_date", servertime, DbType.DateTime);
                parameters.Add("@Cust_reg_branch", customer_mst.Cust_reg_branch, DbType.String);
                parameters.Add("@Last_updated_by", customer_mst.Last_updated_by, DbType.String);
                parameters.Add("@Last_updated_date", servertime, DbType.DateTime);
                parameters.Add("@aml_score", customer_mst.aml_score, DbType.String);
                parameters.Add("@IdTypeCode", customer_mst.IdTypeCode, DbType.String);
                parameters.Add("@IdNo", customer_mst.IdNo, DbType.String);
                parameters.Add("@IdType", customer_mst.IdType, DbType.String);
                parameters.Add("@IssueDate", customer_mst.IssueDate, DbType.Date);
                parameters.Add("@ExpDate", customer_mst.ExpDate, DbType.Date);
                parameters.Add("@Issueplace", customer_mst.Issueplace, DbType.String);
                parameters.Add("@ImageFront", customer_mst.ImageFront, DbType.String);
                parameters.Add("@ImageBack", customer_mst.ImageBack, DbType.String);
                parameters.Add("@ID_Activeflg", "Y", DbType.String);
                parameters.Add("@IssueContcode", customer_mst.IssueContcode, DbType.String);
                parameters.Add("@IdRemarks", customer_mst.IdRemarks, DbType.String);
                parameters.Add("@Idcollected", "Y", DbType.String);
                parameters.Add("@Primary_Id", customer_mst.Primary_Id, DbType.String);
                parameters.Add("@Occupation", customer_mst.Occupation, DbType.String);
                parameters.Add("@EditOrInsert", "Edit", DbType.String);
                parameters.Add("@SuccessMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                var rval = await this.unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, 180);
                string SuccessMsg = parameters.Get<string>("SuccessMsg");

                customerResponse.CustomerCode = customer_mst.Custcode;
                customerResponse.StatusMesage = SuccessMsg;
                if (SuccessMsg == "SUCCESS")
                {

                    customerResponse.StatusCode = 200;
                    customerResponse.IsSucess = true;
                }
                else
                {
                    customerResponse.StatusCode = 400;
                    customerResponse.IsSucess = false;
                }
                return customerResponse;
            }

            catch (Exception ex)
            {


                customerResponse.CustomerCode = customer_mst.Custcode;
                customerResponse.StatusMesage = "Error" + ex.Message;
                customerResponse.StatusCode = 400;
                customerResponse.IsSucess = false;
                return customerResponse;
            }


        }
        public static DateTime ServerDateTime()
        {
            string ServerTimeZone = "04:00";
            string LoginContTimeZone = "04:00";
            DateTime time = DateTime.Now.ToLocalTime();
            string _serverTimeZone = ServerTimeZone;
            double dMin = Convert.ToDouble("." + _serverTimeZone.Substring(_serverTimeZone.IndexOf(':') + 1)) * 100 / 60;
            double dHr = Convert.ToDouble(_serverTimeZone.Substring(0, _serverTimeZone.IndexOf(':')));
            double dST = 0;
            if (dHr > 0)
                dST = dMin + dHr;
            else
                dST = dHr - dMin;
            time = time.AddHours(-1 * dST);
            time = time.AddHours(Convert.ToDouble(LoginContTimeZone.Replace(":", ".")));
            return time;
        }
        private async Task<string> GenerateCustCode(string CustType)
        {
            string sqlID = @" SELECT [CUSTID] ,[COCUSTID] FROM [dbo].[IDGEN_CUST] ";
            string Custcode = "";
            var parameters1 = new DynamicParameters();

            IDGEN_CUST? custIdRecord = await this.unitOfWork.Connection.QueryFirstOrDefaultAsync<IDGEN_CUST>(sqlID, parameters1, unitOfWork.Transaction, 180);

            string servertime = ServerDateTime().ToString();
            if (CustType == "I")
            {
                string SId = "" + custIdRecord.CUSTID.ToString();
                Custcode = Custcode + SId.PadLeft(10, '0').Trim();

                sqlID = "";
                sqlID = @" UPDATE [dbo].[IDGEN_CUST] set  CUSTID =CUSTID+1";


                await this.unitOfWork.Connection.ExecuteAsync(sqlID, parameters1, unitOfWork.Transaction, 180);
            }
            else
            {
                string SId = "" + custIdRecord.COCUSTID.ToString();

                Custcode = Custcode + SId.PadLeft(10, '0').Trim();
                sqlID = @" UPDATE [dbo].[IDGEN_CUST] set COCUSTID =COCUSTID+1";


                await this.unitOfWork.Connection.ExecuteAsync(sqlID, parameters1, unitOfWork.Transaction, 180);
            }
            return SD.Concode + CustType.ToUpper()+ Custcode;
        }
        private async Task<bool> IscustomerExist(string customercode)
        {
            string sql = $" SELECT Custcode FROM customer_mst where Custcode='{customercode}'";
           
            var parameters1 = new DynamicParameters();
           var record= await this.unitOfWork.Connection.ExecuteScalarAsync<int>(sql, parameters1, unitOfWork.Transaction, 180);
           return record>0 ? true :false;
        }
    }
    public interface ICustomerTransactionDataService
    {
        Task<CustomerResponse> SaveCustomer(Customer_mst customer_mst);
        Task<CustomerResponse> EditCustomer(Customer_mst customer_mst);

    }
}
