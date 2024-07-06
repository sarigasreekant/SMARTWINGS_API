using Dapper;
using DataAccess;
using ForexModel;
using System.Data;

namespace ForexDataService
{
    public class ServiceCountriesDataService : IServiceCountriesDataService
    {
        private readonly ISqlDataAccess Db;
        public ServiceCountriesDataService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }

        public async Task<IEnumerable<ServiceCountries>> GetServiceCountries(ServiceCountries serviceCountries)
        {
            //string sql = @" SELECT Corrorgcode, Servcode, Contcode, Curcode, Subcorrorgcode, 
            //                Orgcode
            //                ,(select top 1 Country.CountryName from Country where Country.ConCode=Correspondent_countries.Contcode ) CountryName
            //            FROM Correspondent_countries where  Corrorgcode= @Corrorgcode and Servcode=@Servcode and Curcode=@Curcode ";


            //try
            //{
            //    DynamicParameters parameters = new DynamicParameters();
            //    parameters.Add("@Corrorgcode", serviceCountries.ConfigCode.Trim(), DbType.String);
            //    parameters.Add("@Servcode", serviceCountries.ServCode.Trim(), DbType.String);
            //    parameters.Add("@Curcode", serviceCountries.CurCode.Trim(), DbType.String);
            //    var DataList = await Db.QueryAsync<ServiceCountries>(sql, parameters);
            //    return DataList.ToList();
            //}

             try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@param1", "ForServCountry");
                parameters.Add("@param2", serviceCountries.ConfigCode.Trim());
                var DataList = await Db.QueryAsync<ServiceCountries>("USP_VN_GET_SERVICECONFIG", parameters);

                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<CommanResponse> SaveServiceCountries(ServiceCountries serviceCountries)
        {
            CommanResponse commanResponse = new CommanResponse();
            commanResponse.IsSucess = true;
            commanResponse.StatusMesage = "Data Saved Sucessfully";
            commanResponse.StatusCode = 200;
            string Corrcode = "";
           // await DeleteCorrespondentCountries(serviceCountries);

            //string sql = @" INSERT INTO Correspondent_countries(Corrorgcode,Servcode, Contcode, Curcode, Subcorrorgcode, Orgcode) 
            //                VALUES (@Corrorgcode,@Servcode, @Contcode, @Curcode, @Subcorrorgcode, @Orgcode)";
            string sql = "USP_VN_MAS_SERVICE_COUNTRY";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigCode", serviceCountries.ConfigCode, DbType.String);
            parameters.Add("ServCode", serviceCountries.ServCode, DbType.String);
            parameters.Add("CountryCode", serviceCountries.CountryCode, DbType.String);
            parameters.Add("CurCode", serviceCountries.CurCode, DbType.String);
            parameters.Add("ServOrgCode", serviceCountries.ServOrgCode, DbType.String);
            parameters.Add("OrgCode", serviceCountries.OrgCode, DbType.String);
            parameters.Add("PortalCode", serviceCountries.PortalCode, DbType.String);
            parameters.Add("UserCode", serviceCountries.UserCode, DbType.String);

            try
            {
                //commanResponse.RefNo = ConfigCode;
                //var rval = await Db.ExecuteAsync<int>(sql, parameters);
                //return commanResponse;

                var rval = await Db.QueryFirstOrDefaultAsync<string>(sql, parameters);
                var retData = rval.Split("-", 2);
                commanResponse.StatusMesage = retData[0];
                commanResponse.RefNo = retData[1];
                return commanResponse;

            }
            catch (Exception)
            {
                commanResponse.IsSucess = false;
                commanResponse.StatusMesage = "DataBase Saving Error";
                commanResponse.RefNo = "";
                return commanResponse;
            }
        }
        public async Task<int> DeleteServiceCountries(string code, string configcode)
        {
            string sql = @"DELETE from VN_REF_SERVCOUNTRY where COUNTRYCODE=@code and CONFIGCODE= @configcode ";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);


            parameters.Add("configcode", configcode, DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }

    }
    public interface IServiceCountriesDataService
    {
        Task<IEnumerable<ServiceCountries>> GetServiceCountries(ServiceCountries serviceCountries);
        //Task<ServiceCountries> GetServiceCountriesByID(string Corrorgcode);
        Task<CommanResponse> SaveServiceCountries(ServiceCountries serviceCountries);
        Task<int> DeleteServiceCountries(string code, string configcode);
        //Task<CommanResponse> EditServiceCountries(ServiceCountries serviceCountries);
        //Task<CommanResponse> DeleteServiceCountries(ServiceCountries serviceCountries);
    }
}
