using System.Collections.Generic;
using System.Web.Mvc;
using System.Dynamic;

namespace MVCAppEF.Controllers
{
    public class DemosController : Controller
    {
        /// <summary>
        /// 利用动态对象构造客户需要的数据，可能来自多个实体（可以解决非面向Domain的程序，UI 或者客户端要使用的情况，避免定义viewmodel）
        /// 现在动态类型用的最多的地方，估计就是用来对付json了
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDemos()
        {
            List<ExpandoObject> objList = new List<ExpandoObject>();
            //foreach (DeviceCheckInfo info in list)
            //{
            dynamic obj = new ExpandoObject();
            //}
            return Json(objList);
        }
    }
}