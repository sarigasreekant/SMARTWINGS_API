using ForexModel;

namespace ForexDataService
{
    public interface IDropDwnListDataService
    {
        Task<IEnumerable<ForexModel.DropDwnList>> GetDropDwnList(string dropType, int Id = 0, string Parameter = "");
        Task<IEnumerable<ForexModel.DropDwnListIdText>> GetDropDwnListIdText(string dropType, string Id = "", string Parameter = "");
        Task<ForexModel.DropDwnListIdText> GetDropDwnText(string dropType, string Id = "");
        Task<IEnumerable<ForexModel.DropDwnListIdText>> GetDropDwnListText(string dropType, string Id = "", string Parameter1 = "", string Parameter2 = "", string Parameter3 = "");
       }
}
