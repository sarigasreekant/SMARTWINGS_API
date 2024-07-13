using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class Customer_mstDataService: ICustomer_mstDataService
    {

        private readonly ISqlDataAccess Db;
        
        public Customer_mstDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
          

        }
        public async Task<IEnumerable<Customer_mst>> GetCustomer()
        {
            
            string sql = @"SELECT *
                              FROM customer_mst where Cust_reg_module='M'";

            DynamicParameters parameter = new DynamicParameters();
            var DataList = await Db.QueryAsync<Customer_mst>(sql, parameter);

            return DataList.ToList();
        }
        public async Task<Customer_mst> GetCustomerByID(string Custcode)
        {
            try
            {
                string sql = @"SELECT Custcode, Custtype,CustomerGroup, Name1, Name2, Name3, Cell1, Cell2, Phone, Gender, Dob, Adrees1, Adrees2, Place, 
                            Street, City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, Activeflg, Userid, 
                            Branchcode, Company, Photo, Amldoc_collected, Risktype, Amltype, Aml_auth, Aml_auth_user, Remarks, Remark2, Regdate,
                            PEP, Allow_Forex, Allow_Remit, Allow_Incoming, Allow_Mobile, Residence, FullName, IdTypeCode, IdType, IdNo, IssueDate, 
                            ExpDate, Issueplace, ImageFront, ImageBack, ID_Activeflg, IssueContcode, ID_Remarks, Idcollected, Name4
                              FROM customer_mst WHERE Custcode= @Custcode ";

                var parameters = new DynamicParameters();
                parameters.Add("@Custcode", Custcode, DbType.String);

                var Data = await Db.QueryFirstOrDefaultAsync<Customer_mst>(sql, parameters);

                return Data;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public async Task<Customer_mst> GetCustomerByuserID(string UserId)
        {
            try
            {
                string sql = @"SELECT Custcode, Custtype,CustomerGroup, Name1, Name2, Name3, Cell1, Cell2, Phone, Gender, Dob, Adrees1, Adrees2, Place, 
                            Street, City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, Activeflg, Userid, 
                            Branchcode, Company, Photo, Amldoc_collected, Risktype, Amltype, Aml_auth, Aml_auth_user, Remarks, Remark2, Regdate,
                            PEP, Allow_Forex, Allow_Remit, Allow_Incoming, Allow_Mobile, Residence, FullName, IdTypeCode, IdType, IdNo, IssueDate, 
                            ExpDate, Issueplace, ImageFront, ImageBack, ID_Activeflg, IssueContcode, ID_Remarks, Idcollected, Name4
                              FROM customer_mst WHERE IdNo= @IdNo and Cust_reg_module='M' ";

                var parameters = new DynamicParameters();
                parameters.Add("@IdNo", UserId, DbType.String);

                var Data = await Db.QueryFirstOrDefaultAsync<Customer_mst>(sql, parameters);

                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Customer_mst>> Customer_mstSearch(string CustCode, string Mobile, string name, string IdNo)
        {
            DynamicParameters parameters = new DynamicParameters();

            string sql = @"SELECT  TOP 20 Custcode, Custtype, Name1,  Name2, Name3 , Cell1, Cell2, Phone, Gender, Dob, Adrees1, 
                          Adrees2, Place, Street, City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, 
                          Branchcode, Company, Photo, Regdate,Residence  ,FullName, IdTypeCode, IdType, IdNo, IssueDate, 
                            ExpDate, Issueplace, ImageFront, ImageBack, ID_Activeflg, IssueContcode, ID_Remarks, Idcollected, Name4, Occupation
                         FROM customer_mst  WHERE Activeflg='Y' ";

            if (CustCode != "")
            {
                sql += $" AND  Custcode =@CustCode";
                parameters.Add("@CustCode", CustCode, DbType.String);
            }
            if (Mobile != "")
            {
                sql += $" AND  Cell1 =@Mobile OR Cell2 =@Mobile ";
                parameters.Add("@Mobile", Mobile, DbType.String);
            }
            if (name != "")
            {
                sql += " AND ( UPPER(Name1) LIKE @Name OR UPPER(Name2) LIKE @Name OR UPPER(Name3) LIKE @Name )";
                parameters.Add("@Name", "%" + name.ToUpper().Trim() + "%", DbType.String);
               
            }
            if (IdNo != "")
            {
                sql += $" AND  Custcode IN (SELECT Top 10 Custcode  FROM CustomerIdDetails WHERE IdNo= @IdNo) ";
                parameters.Add("@IdNo", IdNo, DbType.String);
            }
             
            return  await Db.QueryAsync<Customer_mst>(sql, parameters);

        }
        public async Task<IEnumerable<Customer_mst>> Customer_mstSearchNew(CustomerSearch customerSearch)
        {

            DynamicParameters parameters = new DynamicParameters();
            string sql = @"SELECT  TOP 20 Custcode, Custtype, Name1,  Name2, Name3 , Cell1, Cell2, Phone, Gender, Dob, Adrees1, 
                          Adrees2, Place, Street, City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, 
                          Branchcode, Company, Photo, Regdate  ,Residence, FullName,IdTypeCode, IdType, IdNo, IssueDate, 
                            ExpDate, Issueplace, ImageFront, ImageBack, ID_Activeflg, IssueContcode, ID_Remarks, Idcollected, Name4, Occupation
                         FROM customer_mst  WHERE Activeflg='Y' ";

            if (customerSearch.CustCode != "")
            {
                sql += $" AND  Custcode =@Custcode";
                parameters.Add("@CustCode", customerSearch.CustCode, DbType.String);
            }
            if (customerSearch.Mobile != "")
            {
                sql += $" AND  Cell1 =@Mobile OR Cell2 =@Mobile";
                parameters.Add("@Mobile", customerSearch.Mobile, DbType.String);
            }
            if (customerSearch.name != "")
            {
                sql += " AND (  UPPER(Name1) LIKE @Name OR UPPER(Name2) LIKE @Name OR UPPER(Name3) LIKE @Name )";
                parameters.Add("@Name", "%" + customerSearch.name.ToUpper().Trim() + "%", DbType.String);
            }
            if (customerSearch.IdNo != "")
            {
                sql += $" AND  Custcode IN (SELECT Top 10 Custcode  FROM CustomerIdDetails WHERE IdNo= @IdNo ";
                parameters.Add("@Name", customerSearch.IdNo, DbType.String);
            }
           
            return await Db.QueryAsync<Customer_mst>(sql, parameters);

        }
        public async Task<IEnumerable<Customer_mst>> GetCustomerKYC(string Custcode)
        {
            try
            {
                string sql = @"SELECT Custcode, CASE  WHEN Custtype = 'I' THEN 'Individual' ELSE 'Corporate'
             END AS Custtype,CustomerGroup, Name1, Name2, Name3, Cell1, Cell2, Phone, Gender, Dob, Adrees1, Adrees2, Place, 
            Street, City, State, Concode, Country, Pobox, Nationcode, Nationality, Profession, Mail, Fax, CASE 
             WHEN Activeflg = 'Y' THEN 'Active' ELSE 'Not Active' END AS Activeflg, Userid, 
            Branchcode, Company, Photo, Amldoc_collected, Risktype, Amltype, Aml_auth, Aml_auth_user, Remarks, Remark2, 
            Regdate ,Residence, FullName,IdTypeCode, IdType, IdNo, IssueDate, ExpDate, Issueplace, ImageFront, ImageBack, 
            ID_Activeflg, IssueContcode, ID_Remarks, Idcollected, Name4, Occupation
              FROM customer_mst WHERE Custcode= @Custcode ";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@CustCode", Custcode, DbType.String);
                // var Data = await Db.QueryAsync<Customer_mst>(sql, parameter);
                //  return Data.ToList();
                return await Db.QueryAsync<Customer_mst>(sql, parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> CheckNumberExistOrNot(string param1,string param2)
        {
            try
            {

                string sql = @"USP_VN_GET_CUSTOMER_PHONE_EXISTS";

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Cell1", param1, DbType.String);
                parameter.Add("@Param", param2, DbType.String);
                parameter.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var Data = await Db.ExecuteScalarAsync<string>(sql, parameter);

                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

    }
}
