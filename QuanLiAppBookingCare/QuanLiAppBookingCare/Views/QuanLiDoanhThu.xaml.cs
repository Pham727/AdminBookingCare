using Microcharts;
using Newtonsoft.Json;
using QuanLiAppBookingCare.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuanLiAppBookingCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuanLiDoanhThu : ContentPage
    {
        public QuanLiDoanhThu()
        {
            InitializeComponent();
        }
        private async void cmdReport_Clicked(object sender, EventArgs e)
        {

            result.IsVisible = true;
            var random = new Random();
            var entries = new List<ChartEntry>();
            var entries1 = new List<ChartEntry>();
            var entries3 = new List<ChartEntry>();
            var entries2 = new List<ChartEntry>();
            HttpClient httpClient = new HttpClient();
            var kq1 = await httpClient.GetStringAsync(App.url + "api/DataController/GetDoanhThu?ngaybatdau=" + prkStart.Date.ToString("dd/MM/yyyy") + "&ngayketthuc=" + prkEnd.Date.ToString("dd/MM/yyyy"));
            var doanhthu1 = JsonConvert.DeserializeObject<List<DoanhThu>>(kq1);
            var kq2 = await httpClient.GetStringAsync(App.url + "api/DataController/GetDoanhThu1?ngaybatdau=" + prkStart.Date.ToString("dd/MM/yyyy") + "&ngayketthuc=" + prkEnd.Date.ToString("dd/MM/yyyy"));
            var doanhthu2 = JsonConvert.DeserializeObject<List<DoanhThu1>>(kq2);
            if (doanhthu1.Count == 0)
            {
                await DisplayAlert("Thông báo", "Không có doanh thu trong thời gian trên. Vui lòng chọn mốc thời gian khác.", "Ok");
            }
            else
            {
                foreach (DoanhThu doanhThu in doanhthu1)
                {
                    var color = String.Format("#{0:X6}", random.Next(0x1000000));
                    entries.Add(new ChartEntry((float)doanhThu.doanh_thu)
                    {
                        Label = doanhThu.chuyen_khoa,
                        Color = SKColor.Parse(color),
                        ValueLabel = doanhThu.doanh_thu.ToString(),
                    });
                    entries1.Add(new ChartEntry((float)doanhThu.so_luong)
                    {
                        Label = doanhThu.chuyen_khoa,
                        Color = SKColor.Parse(color),
                        ValueLabel = doanhThu.so_luong.ToString(),
                    });
                }
                chartViewBar.Chart = new BarChart { Entries = entries, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 40, LabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#000000")};
                chartViewBar1.Chart = new BarChart { Entries = entries1, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 40, LabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#000000") };
                foreach (DoanhThu1 doanhThu in doanhthu2)
                {
                    var color = String.Format("#{0:X6}", random.Next(0x1000000));
                    entries2.Add(new ChartEntry((float)doanhThu.doanh_thu)
                    {
                        Label = doanhThu.loai_hinh,
                        Color = SKColor.Parse(color),
                        ValueLabel = doanhThu.doanh_thu.ToString(),
                    });
                    entries3.Add(new ChartEntry((float)doanhThu.so_luong)
                    {
                        Label = doanhThu.loai_hinh,
                        Color = SKColor.Parse(color),
                        ValueLabel = doanhThu.so_luong.ToString(),
                    });
                }
                chartViewPie.Chart = new PieChart { Entries = entries3, HoleRadius = 0.3f ,LabelTextSize=40, LabelColor = SKColor.Parse("#000000") };
                chartViewBar2.Chart = new BarChart { Entries = entries2, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 40, LabelOrientation = Orientation.Horizontal , LabelColor = SKColor.Parse("#000000") };
            }
        }
        
    }
}