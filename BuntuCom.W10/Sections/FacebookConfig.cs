


using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Facebook;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using BuntuCom.Config;
using BuntuCom.ViewModels;

namespace BuntuCom.Sections
{
    public class FacebookConfig : SectionConfigBase<FacebookSchema>
    {
		private readonly FacebookDataProvider _dataProvider = new FacebookDataProvider(new FacebookOAuthTokens
        {
			AppId = "1536635209971002",
                    AppSecret = "372f2bce28c6892531ae50e6c07c3295"
        });

		public override Func<Task<IEnumerable<FacebookSchema>>> LoadDataAsyncFunc
        {
            get
            {
                var config = new FacebookDataConfig
                {
                    UserId = "129981420418132"
                };

                return () => _dataProvider.LoadDataAsync(config, MaxRecords);
            }
        }

        public override ListPageConfig<FacebookSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<FacebookSchema>
                {
                    Title = "Facebook",

					PageTitle = "Facebook",

                    ListNavigationInfo = NavigationInfo.FromPage("FacebookListPage"),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Content.ToSafeString();
                        viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.ImageUrl.ToSafeString());
                    },
                    DetailNavigation = (item) =>
                    {
                        return NavigationInfo.FromPage("FacebookDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<FacebookSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, FacebookSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Content.ToSafeString();
                    viewModel.Title = item.Content.ToSafeString();
                    viewModel.Description = item.Author.ToSafeString();
                    viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.ImageUrl.ToSafeString());
                    viewModel.Content = null;
					viewModel.Source = item.FeedUrl;
                });

                var actions = new List<ActionConfig<FacebookSchema>>
                {
                    ActionConfig<FacebookSchema>.Link("Go To Source", (item) => item.FeedUrl.ToSafeString()),
                };

                return new DetailPageConfig<FacebookSchema>
                {
                    Title = "Facebook",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
