using Ninject;
using Ninject.Modules;

namespace MockAndInject.Ninject
{
    // Look at http://www.ninject.org
    // Have a read at https://codeblogproject.wordpress.com/2016/07/29/setup-ninject-in-120-seconds/
    public static class IocKernel
    {
        private static StandardKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel(modules);
            }
        }

        public static void LoadFromXML(string filePath)
        {
            _kernel.Load(filePath);
        }
    }
}
