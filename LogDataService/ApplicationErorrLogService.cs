using Dapper;
using DataAccess;
using ForexModel;
using System.Data;
namespace ForexDataService
{
    public class ApplicationErorrLogService: IApplicationErorrLogService
    {

        private readonly ISqlDataAccess Db;
        public ApplicationErorrLogService(ISqlDataAccess _Db)
        {
            Db = _Db;
        }
        public async Task<IEnumerable<ApplicationErorrLog>> GetLog()
        {
            string sql = @" SELECT LId, ModuleName, ConttroleName, ActionName, ErrorMesage, EorrDetails, Errordate 
                              FROM ApplicationErorrLog ";


            try
            {
                DynamicParameters parameter = new DynamicParameters();
                var DataList = await Db.QueryAsync<ApplicationErorrLog>(sql, parameter);
                return DataList.ToList();
            }
            catch (Exception)
            {

                throw;
            }






        }
        public async Task<ApplicationErorrLog> LogByID(int LId)
        {
            string sql = @"SELECT LId, ModuleName, ConttroleName, ActionName, ErrorMesage, EorrDetails, Errordate 
                  FROM ApplicationErorrLog WHERE LId= @LId ";



            var parameters = new DynamicParameters();
            parameters.Add("@LId", LId, DbType.Int64);

            var Data = await Db.QueryFirstOrDefaultAsync<ApplicationErorrLog>(sql, parameters);

            return Data;
        }
        public async Task<int> SaveLog(ApplicationErorrLog applicationerorrlog)
        {
            string sql = @"INSERT INTO ApplicationErorrLog(ModuleName, ConttroleName, ActionName, ErrorMesage,
                        EorrDetails, Errordate) VALUES (@ModuleName, @ConttroleName, @ActionName, @ErrorMesage, @EorrDetails, @Errordate)";
            var parameters = new DynamicParameters();
            parameters.Add("ModuleName", applicationerorrlog.ModuleName, DbType.String);
            parameters.Add("ConttroleName", applicationerorrlog.ConttroleName, DbType.String);
            parameters.Add("ActionName", applicationerorrlog.ActionName, DbType.String);
            parameters.Add("ErrorMesage", applicationerorrlog.ErrorMesage, DbType.String);
            parameters.Add("EorrDetails", applicationerorrlog.EorrDetails, DbType.String);
            parameters.Add("Errordate", applicationerorrlog.Errordate, DbType.DateTime);

            try
            {

                var rval = await Db.ExecuteAsync<int>(sql, parameters);

                return rval;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int SaveLogNormal(ApplicationErorrLog applicationerorrlog)
        {
            string sql = @"INSERT INTO ApplicationErorrLog(ModuleName, ConttroleName, ActionName, ErrorMesage,
                        EorrDetails, Errordate) VALUES (@ModuleName, @ConttroleName, @ActionName, @ErrorMesage, @EorrDetails, @Errordate)";
            var parameters = new DynamicParameters();
            parameters.Add("ModuleName", applicationerorrlog.ModuleName, DbType.String);
            parameters.Add("ConttroleName", applicationerorrlog.ConttroleName, DbType.String);
            parameters.Add("ActionName", applicationerorrlog.ActionName, DbType.String);
            parameters.Add("ErrorMesage", applicationerorrlog.ErrorMesage, DbType.String);
            parameters.Add("EorrDetails", applicationerorrlog.EorrDetails, DbType.String);
            parameters.Add("Errordate", applicationerorrlog.Errordate, DbType.DateTime);

            try
            {

                var rval =  Db.Execute<int>(sql, parameters);

                return rval;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public interface IApplicationErorrLogService
    {
        Task<IEnumerable<ApplicationErorrLog>> GetLog();
        Task<ApplicationErorrLog> LogByID(int LId);
        Task<int> SaveLog(ApplicationErorrLog applicationerorrlog);
        int SaveLogNormal(ApplicationErorrLog applicationerorrlog);
    }
}
