using System.Collections.Generic;
using System.Linq;

namespace WebApi.Models
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly List<Widget> widgets = new List<Widget>();

        public WidgetRepository()
        {
            widgets.Add(new Widget
            {
                Id=1,
                Description="Answering Machine",
                InventedYear=1898
            });

            widgets.Add(new Widget
            {
                Id = 2,
                Description = "Laptop Computer",
                InventedYear = 1983
            });

            widgets.Add(new Widget
            {
                Id = 3,
                Description = "Personal Computer",
                InventedYear = 2016,
                IsPramiumSecured=true
            });

            widgets.Add(new Widget
            {
                Id = 4,
                Description = "Microsoft Computer",
                InventedYear = 1986,
                IsMicrosoftSecured = true
            });

            widgets.Add(new Widget
            {
                Id = 5,
                Description = "Internet",
                InventedYear = 1969,
                IsMicrosoftSecured = true,
                IsPramiumSecured = true
            });
        }

        public IQueryable<Widget> Get(bool isPraemium, bool isMicrosoft)
        {
            if (isPraemium && isMicrosoft)
            {
                return widgets.AsQueryable();
            }

            if (isPraemium)
            {
                return widgets.Where(w =>!w.IsSecured|| w.IsPramiumSecured).AsQueryable();
            }

            if (isMicrosoft)
            {
                return widgets.Where(w => !w.IsSecured || w.IsMicrosoftSecured).AsQueryable();
            }

            return widgets.Where(w => !w.IsSecured).AsQueryable();
        }
    }

    internal interface IWidgetRepository
    {
        IQueryable<Widget> Get(bool isPraemium, bool isMicrosoft);
    }
}