


using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Uwp.Navigation;
using AppStudio.Uwp;
using System.Linq;
using BuntuCom.Config;
using BuntuCom.ViewModels;

namespace BuntuCom.Sections
{
    public class AboutUsConfig : SectionConfigBase<HtmlSchema>
    {
		public override Func<Task<IEnumerable<HtmlSchema>>> LoadDataAsyncFunc
        {
            get
            {
                var config = new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/AboutUs.htm"
                };

                return () => Singleton<HtmlDataProvider>.Instance.LoadDataAsync(config, MaxRecords);
            }
        }

        public override bool NeedsNetwork
        {
            get
            {
                return false;
            }
        }

        public override ListPageConfig<HtmlSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<HtmlSchema>
                {
                    Title = "About Us",

					PageTitle = "About Us",

                    ListNavigationInfo = NavigationInfo.FromPage("AboutUsListPage"),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Content = item.Content;
                    },
                    DetailNavigation = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public override DetailPageConfig<HtmlSchema> DetailPage
        {
            get { return null; }
        }
    }
}
