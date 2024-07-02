using Dapper;
using DataAccess;
using ForexModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;

namespace ForexDataService
{
    public class CustomerIdDetailsDataService: ICustomerIdDetailsDataService
    {
        private readonly ISqlDataAccess Db;
        private readonly IWebHostEnvironment _environment;
        public IConfiguration Configuration { get; }
        public CustomerIdDetailsDataService(ISqlDataAccess _Db, IWebHostEnvironment env, IConfiguration configuration)
        {
            Db = _Db;
            _environment = env;
            Configuration = configuration;
        }
        public async Task<IEnumerable<CustomerIdDetails>> GetCustomerIdDetail(string Custcode)
        {
            string sql = @"SELECT Custcode, IdTypeCode, IdType, IdNo, IssueDate, ExpDate, Issueplace, ImageFront, ImageBack, Activeflg, IssueContcode, Remarks, 
               Idcollected FROM CustomerIdDetails  WHERE Custcode= @Custcode ";


            var parameters = new DynamicParameters();
            parameters.Add("@Custcode", Custcode, DbType.String);

            var DataList = await Db.QueryAsync<CustomerIdDetails>(sql, parameters);
            var IDList = new List<CustomerIdDetails>();
            foreach (var item in DataList)
            {
                IDList.Add(new CustomerIdDetails
                {
                    Custcode = item.Custcode,
                    IdTypeCode = item.IdTypeCode,
                    IdType = item.IdType,
                    IdNo = item.IdNo,
                    IssueDate = item.IssueDate,
                    ExpDate = item.ExpDate,
                    Issueplace = item.Issueplace,
                    ImageFront = item.ImageFront,
                    ImageBack = item.ImageBack,
                    Activeflg = item.Activeflg,
                    IssueContcode=item.IssueContcode,
                    Remarks=item.Remarks,
                    Idcollected=item.Idcollected,
                    ImageFrontUrl = await GetBase64StringFromFile(item.ImageFront),
                    ImageImageBackUrl = await GetBase64StringFromFile(item.ImageBack)
                });  
                
            }



            return IDList.ToList();
        }
        public async Task<CustomerIdDetails> CustomerIdDetailsByID(string Custcode)
        {
            var custidmage = new CustomerIdDetails();
            string sql = @"SELECT Custcode, IdTypeCode, IdType, IdNo, IssueDate, ExpDate, Issueplace, ImageFront, ImageBack, Activeflg, IssueContcode, Remarks, Idcollected FROM CustomerIdDetails WHERE Custcode= @Custcode
                         ";



            var parameters = new DynamicParameters();
            parameters.Add("@Custcode", Custcode, DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<CustomerIdDetails>(sql, parameters);

           
            string CustImageFront = "NoImagepng.png";
            string CustImageBack= "NoImagepng.png";
            if (Data != null)
            {
                if (!string.IsNullOrEmpty(Data.ImageFront))
                {
                    CustImageFront = await GetBase64StringFromFile(Data.ImageFront);
                }
                else
                    CustImageFront = await GetBase64StringFromFile(CustImageFront);

                if (!string.IsNullOrEmpty(Data.ImageBack))
                {
                    CustImageBack = await GetBase64StringFromFile(Data.ImageBack);
                }
                else
                    CustImageBack = await GetBase64StringFromFile(CustImageBack);


                // return Data;
                var IdImage = new CustomerIdDetails
                {
                    ImageFrontUrl = CustImageFront,
                    ImageImageBackUrl = CustImageBack,
                    IdNo = Data.IdNo,
                    IdTypeCode = Data.IdTypeCode,
                    IssueContcode = Data.IssueContcode,
                    IssueDate = Data.IssueDate,
                    Issueplace = Data.Issueplace,
                    ExpDate = Data.ExpDate,
                    Remarks = Data.Remarks,
                    ImageBack = Data.ImageBack,
                    ImageFront = Data.ImageFront
                };
                return IdImage;
            }

            return custidmage;


        }
        public async Task<int> SaveCustomerIdDetails(CustomerIdDetails customeriddetails)
        {
            await this.DeleteCustomerIdDetails(customeriddetails.Custcode, customeriddetails.IdTypeCode);

            string sql = @"USP_VN_MAS_CUSTOMER_ID_DETAILS";
            var parameters = new DynamicParameters();
            parameters.Add("@Custcode", customeriddetails.Custcode, DbType.String);
            parameters.Add("@IdTypeCode", customeriddetails.IdTypeCode, DbType.String);
            parameters.Add("@IdType", customeriddetails.IdType, DbType.String);
            parameters.Add("@IdNo", customeriddetails.IdNo, DbType.String);
            parameters.Add("@IssueDate", customeriddetails.IssueDate, DbType.Date);
            parameters.Add("@ExpDate", customeriddetails.ExpDate, DbType.Date);
            parameters.Add("@Issueplace", customeriddetails.Issueplace, DbType.String);
            parameters.Add("@ImageFront", customeriddetails.ImageFront, DbType.String);
            parameters.Add("@ImageBack", customeriddetails.ImageBack, DbType.String);
            parameters.Add("@Activeflg", customeriddetails.Activeflg, DbType.String);
            parameters.Add("@IssueContcode", customeriddetails.IssueContcode, DbType.String);
            parameters.Add("@Remarks", customeriddetails.Remarks, DbType.String);
            parameters.Add("@Idcollected", customeriddetails.Idcollected, DbType.String);
            parameters.Add("@Primary_Id", customeriddetails.Primary_Id, DbType.String);
            parameters.Add("EditOrInsert", "Insert", DbType.String);

            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> EditCustomerIdDetails(CustomerIdDetails customeriddetails)
        {

            string sql = @"USP_VN_MAS_CUSTOMER_ID_DETAILS";


           
            var parameters = new DynamicParameters();
            parameters.Add("@Custcode", customeriddetails.Custcode, DbType.String);
            parameters.Add("@IdTypeCode", customeriddetails.IdTypeCode, DbType.String);
            parameters.Add("@IdType", customeriddetails.IdType, DbType.String);
            parameters.Add("@IdNo", customeriddetails.IdNo, DbType.String);
            parameters.Add("@IssueDate", customeriddetails.IssueDate, DbType.Date);
            parameters.Add("@ExpDate", customeriddetails.ExpDate, DbType.Date);
            parameters.Add("@Issueplace", customeriddetails.Issueplace, DbType.String);
            parameters.Add("@ImageFront", customeriddetails.ImageFront, DbType.String);
            parameters.Add("@ImageBack", customeriddetails.ImageBack, DbType.String);
            parameters.Add("@Activeflg", customeriddetails.Activeflg, DbType.String);
            parameters.Add("@IssueContcode", customeriddetails.IssueContcode, DbType.String);
            parameters.Add("@Remarks", customeriddetails.Remarks, DbType.String);
            parameters.Add("@Idcollected", customeriddetails.Idcollected, DbType.String);
            parameters.Add("@Primary_Id", customeriddetails.Primary_Id, DbType.String);
            parameters.Add("EditOrInsert", "Edit", DbType.String);


            var rval = await Db.ExecuteAsync<int>(sql, parameters);

            return rval;
        }
        public async Task<int> DeleteCustomerIdDetails(string Cutomercode,string IdTypecode)
        {
            string sql = @"DELETE FROM CustomerIdDetails WHERE Custcode = @Custcode and  IdTypeCode=@IdTypeCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Custcode", Cutomercode, DbType.String);
            parameters.Add("IdTypeCode", IdTypecode, DbType.String);
            var cnt = await Db.ExecuteAsync<int>(sql, parameters);


            return cnt;
        }
       private async Task<string> GetBase64StringFromFile(string fileName)
        {
            var imageFolderPath = "" + Configuration["ImageFolderPath"];
            imageFolderPath = imageFolderPath + "\\" + fileName;
            // var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", fileName);
             var filePath = imageFolderPath;
            bool FiLEexists = File.Exists(filePath);


            if (FiLEexists==false)
            {
                filePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", "NoImagepng.png");
                fileName = "NoImagepng.png";
            }
            var memoryStream = new MemoryStream();
         

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }

            // set the position to return the file from
            memoryStream.Position = 0;

            // Get the MIMEType for the File
            var mimeType = (string file) =>
            {
                var mimeTypes = MimeTypes.GetMimeTypes();
                var extension = Path.GetExtension(file).ToLowerInvariant();
                return mimeTypes[extension];
            };

            // Convert the file to a base64-encoded string
            var base64String = $"data:{mimeType(filePath)};base64,{Convert.ToBase64String(memoryStream.ToArray())}";

            return base64String;
        }

        public async Task<CustomerIdDetails> CustomerPrimaryIdDetailsByID(string Custcode)
        {
            var custidmage = new CustomerIdDetails();
            string sql = @"SELECT Custcode, IdTypeCode, IdType, IdNo, IssueDate, ExpDate, Issueplace, ImageFront, ImageBack, Activeflg, IssueContcode, Remarks, Idcollected FROM CustomerIdDetails WHERE Custcode= @Custcode and Primary_Id = 'Y' ";



            var parameters = new DynamicParameters();
            parameters.Add("@Custcode", Custcode, DbType.String);

            var Data = await Db.QueryFirstOrDefaultAsync<CustomerIdDetails>(sql, parameters);


            string CustImageFront = "NoImagepng.png";
            string CustImageBack = "NoImagepng.png";
            if (Data != null)
            {
                if (!string.IsNullOrEmpty(Data.ImageFront))
                {
                    CustImageFront = await GetBase64StringFromFile(Data.ImageFront);
                }
                else
                    CustImageFront = await GetBase64StringFromFile(CustImageFront);

                if (!string.IsNullOrEmpty(Data.ImageBack))
                {
                    CustImageBack = await GetBase64StringFromFile(Data.ImageBack);
                }
                else
                    CustImageBack = await GetBase64StringFromFile(CustImageBack);


                // return Data;
                var IdImage = new CustomerIdDetails
                {
                    ImageFrontUrl = CustImageFront,
                    ImageImageBackUrl = CustImageBack,
                    IdNo = Data.IdNo,
                    IdTypeCode = Data.IdTypeCode,
                    IssueContcode = Data.IssueContcode,
                    IssueDate = Data.IssueDate,
                    Issueplace = Data.Issueplace,
                    ExpDate = Data.ExpDate,
                    Remarks = Data.Remarks,
                    ImageBack = Data.ImageBack,
                    ImageFront = Data.ImageFront
                };
                return IdImage;
            }

            return custidmage;


        }
    }
}
