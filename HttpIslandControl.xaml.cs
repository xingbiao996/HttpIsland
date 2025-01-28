using System.Net.Http;
using System.Threading.Tasks;
using ClassIsland.Core.Controls;
using System.Windows;
using ClassIsland.Core.Abstractions.Controls;
using ClassIsland.Core.Attributes;
using MaterialDesignThemes.Wpf;

namespace HttpIsland
{
    [ComponentInfo(
            "CC72B633-1B5C-4233-A410-C90C57DE3710",
            "HttpIsland 互联网",
            PackIconKind.CalendarOutline,
            "ClassIsland の 插件。可以联结你 & 互联网"
        )]
    public partial class HttpIslandControl : ComponentBase
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public HttpIslandControl()
        {
            InitializeComponent();
            LoadHttpIslandAsync();
        }

        private async void LoadHttpIslandAsync()
        {
            try
            {
                var result = await _httpClient.GetStringAsync("https://v1.HttpIsland.cn/?encode=text");
                Dispatcher.Invoke(() => HttpIslandText.Text = result);
            }
            catch (HttpRequestException)
            {
                Dispatcher.Invoke(() => HttpIslandText.Text = "加载失败");
            }
        }
    }
}