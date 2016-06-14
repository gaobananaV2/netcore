using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Customer
    {
        /// <summary>
        /// 修改邮箱地址这样的职责本来就应该放在Customer上
        /// 要创建行为饱满的领域对象并不难，我们需要转变一下思维，将领域对象当做是服务的提供方，
        /// 而不是数据容器，多思考一个领域对象能够提供哪些行为，而不是数据
        /// </summary>
        public void ChangeEmail(string email)
        {
        }



    }
}
