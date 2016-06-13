using System;
using System.Collections.Generic;
using System.Linq;
using Domains.Domains.Agreements;
using Infrastructure.Repositories;
using Util.Data;
using Domains.Domains.Users;

namespace Application.Services.Services.Agreements
{
    public class AgreementSignService : IAgreementSignService
    {
        private readonly IRepository<Agreement> _agreementRepository;
        private readonly IRepository<AgreementSign> _agreementSignRepository;
        ///private readonly IRepository<UserGroup> _userGroupRepository;
        private readonly IRepository<Group> _groupRepository;

        public AgreementSignService()
        {
            _agreementSignRepository = new EfRepository<AgreementSign>();
            _agreementRepository = new EfRepository<Agreement>();
            //_userGroupRepository = new EfRepository<UserGroup>();
            _groupRepository = new EfRepository<Group>();
        }


        //public IList<Agreement> GetNeedToSignAgreement(string stfid)
        //{
        //    var query = (from a in _agreementRepository.Table
        //                  join b in _groupRepository.Table on a.CategoryCode equals b.Code
        //                 where  a.EndDate >= DateTime.Now 
        //                  //&& _userGroupRepository.Table.Any(p => p.GroupCode == a.CategoryCode && p.StfCode == stfid)
        //                  && !_agreementSignRepository.Table.Any(p => p.AgreeMentId == a.Id && p.StfId == stfid)
        //                 select a
        //    );
        //    var content = query.ToList();
        //    return content;
        //}

        public IList<Agreement> GetSignAgreementHistory(string stfid)
        {
            var query = (from a in _agreementRepository.Table
                         join b in _agreementSignRepository.Table on a.Id equals b.AgreeMentId
                         where b.StfId == stfid
                         select a
            );
            var content = query.ToList();
            return content;

            //using (var scope = new System.Transactions.TransactionScope())
            //{ 
            //scope.Complete();
            //}
        }


        public void Sign(AgreementSign model)
        {
            var query = (from a in _agreementSignRepository.Table
                         where a.AgreeMentId == model.AgreeMentId
                          && a.StfId == model.StfId
                         select a
                             );
            if (query.Any())
            {
                //update
                try
                {
                    _agreementSignRepository.Update(model);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message + e.InnerException.Message);
                }
            }
            else
            {
                //insert
                try
                {
                    _agreementSignRepository.Insert(model);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message + e.InnerException.Message);
                }
            }
        }


        public string GetSignStatus(int agreementcode, string stfid)
        {
            var query = (from a in _agreementSignRepository.Table
                         where a.AgreeMentId == agreementcode
                             && a.StfId == stfid
                         select a
                             );
            return query.Any() ? query.FirstOrDefault().AgreeOrNot : string.Empty;
        }

        public IList<Agreement> GetNeedToSignAgreement(string stfid)
        {
            throw new NotImplementedException();
        }
    }
}
