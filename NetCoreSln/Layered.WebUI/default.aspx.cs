using Layered.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Layered.Domains;
using Layered.Services;
using Layered.Infrastructure.Enum;
using Layered.WebUI.IOC;

namespace Layered.WebUI
{
    public partial class _default : System.Web.UI.Page, IProductListView
    {
        public CustomerType CustomerType
        {
            get
            {
                return (CustomerType)Enum.ToObject(typeof(CustomerType), int.Parse(this.ddlCustomerType.SelectedValue));
            }
        }

        public string ErrorMessage
        {
            set
            {
                lblErrorMessage.Text = String.Format("<p><strong>Error</strong><br/>{0}<p/>", value);
            }
        }


        private ProductListPresenter _presenter;
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new ProductListPresenter(this, BootStrapper.Container.GetInstance<ProductService>());
            this.ddlCustomerType.SelectedIndexChanged += delegate { _presenter.Display(); };
        }

        public void Display(IList<ProductViewModel> products)
        {
            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
                _presenter.Display();
        }
    }
}