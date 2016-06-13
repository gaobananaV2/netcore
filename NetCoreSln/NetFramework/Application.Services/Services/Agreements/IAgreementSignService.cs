using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains.Domains.Agreements;
using Util.Data;

namespace Application.Services.Services.Agreements
{
    public interface IAgreementSignService
    {
        IList<Agreement> GetNeedToSignAgreement(string stfid);

        IList<Agreement> GetSignAgreementHistory(string stfid);

        void Sign(AgreementSign model);

        /// <summary>
        /// 获取签署状态
        /// </summary>
        /// <param name="agreementcode"></param>
        /// <param name="stfid"></param>
        /// <returns></returns>
        string GetSignStatus(int agreementcode, string stfid); 
    }
}
