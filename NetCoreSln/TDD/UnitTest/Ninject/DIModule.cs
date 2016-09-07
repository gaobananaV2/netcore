using MockAndInject.Mock;
using MockAndInject.ViewModel;
using Ninject.Modules;

namespace MockAndInject.Ninject
{
    public class DIModule : NinjectModule
    {
        // Look at http://www.ninject.org
        // Have a read at https://codeblogproject.wordpress.com/2016/07/29/setup-ninject-in-120-seconds/
        public override void Load()
        {
            Bind<IService>().To<ServiceMock>();
            //Bind<IService>().To<Service>();
        }
    }
}
