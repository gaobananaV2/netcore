using Domains.Domains.Agreements;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Data;
using System.Linq;
using Util.Common;
using Util.Data;

namespace Application.Services.Services.Agreements
{
    public class AgreementService : IAgreementService
    {
        private readonly IRepository<Agreement> _agreementRepository;

        public AgreementService()
        { 
            _agreementRepository = new EfRepository<Agreement>();
        }

      
        public IPagedList<Agreement> GetManageList(string category, string title, int pageIndex, int pageSize)
        {
            var query = _agreementRepository.Table;
            try
            {
 
                //if (!category.IsNullOrEmpty())
                //    query = query.Where(b => b.CategoryCode == category);
                if (!title.IsNullOrEmpty())
                    query = query.Where(b => b.Title.Contains(title));
                query = query.OrderBy(a => a.Id);
                var lst = new PagedList<Agreement>(query.IncludeProperties(p => p.Category), pageIndex, pageSize);
                return lst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException.Message);
            }

        }


        public Agreement Get(int code)
        {
            try
            {
                return _agreementRepository.GetById(code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException.Message);
            }
        }
         

        public void Add(Agreement model)
        {
            try
            {  
                _agreementRepository.Insert(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException.Message);
            }
        }

        public void Mod(Agreement model)
        {
            try
            {
                _agreementRepository.Update(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException.Message);
            }
        }


        
       
    }
}
