using Domains.Domains.Agreements;
using Util.Data;

namespace Application.Services.Services.Agreements
{
    public interface IAgreementService
    {
       
        IPagedList<Agreement> GetManageList(string category, string title, int pageIndex, int pageSize); 
      
        Agreement Get(int code);

        void Add(Agreement model);

        void Mod(Agreement model);

       
    }
}