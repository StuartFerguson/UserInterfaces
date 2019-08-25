using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Models
{
    using Newtonsoft.Json;

    public class ChartJsPieChartDataDataSet
    {
        public ChartJsPieChartDataDataSet()
        {
            this.BackgroundColor = new List<String>();
            this.Data=new List<Int32>();
            this.HoverBackgroundColor=new List<String>();
        }
        [JsonProperty(PropertyName = "data")]
        public List<Int32> Data { get; set; }
        [JsonProperty(PropertyName = "backgroundColor")]
        public List<String> BackgroundColor { get; set; }
        [JsonProperty(PropertyName = "hoverBackgroundColor")]
        public List<String> HoverBackgroundColor { get; set; }
        [JsonProperty(PropertyName = "hoverBorderColor")]
        public String HoverBorderColor { get; set; }
    }

    public class ChartJsPieChartDataViewModel
    {
        public ChartJsPieChartDataViewModel()
        {
            this.Datasets = new List<ChartJsPieChartDataDataSet>();
            this.Labels=new List<String>();
        }
        [JsonProperty(PropertyName = "labels")]
        public List<String> Labels { get; set; }
        [JsonProperty(PropertyName = "datasets")]
        public List<ChartJsPieChartDataDataSet> Datasets { get; set; }
    }

    public class ChartJsLineChartDataDataSet
    {
        public ChartJsLineChartDataDataSet()
        {
            this.Data = new List<Int32>();

        }
        [JsonProperty(PropertyName = "label")]
        public String Label { get; set; }
        [JsonProperty(PropertyName = "lineTension")]
        public Double LineTension { get; set; }
        [JsonProperty(PropertyName = "backgroundColor")]
        public String BackgroundColor { get; set; }
        [JsonProperty(PropertyName = "borderColor")]
        public String BorderColor { get; set; }
        [JsonProperty(PropertyName = "pointRadius")]
        public Int32 PointRadius { get; set; }
        [JsonProperty(PropertyName = "pointBackgroundColor")]
        public String PointBackgroundColor { get; set; }
        [JsonProperty(PropertyName = "pointBorderColor")]
        public String PointBorderColor { get; set; }
        [JsonProperty(PropertyName = "pointHoverRadius")]
        public Int32 PointHoverRadius { get; set; }
        [JsonProperty(PropertyName = "pointHoverBackgroundColour")]
        public String PointHoverBackgroundColor { get; set; }
        [JsonProperty(PropertyName = "pointHoverBorderColor")]
        public String PointHoverBorderColor { get; set; }
        [JsonProperty(PropertyName = "pointHitRadius")]
        public Int32 PointHitRadius { get; set; }
        [JsonProperty(PropertyName = "pointBorderWidth")]
        public Int32 PointBorderWidth { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<Int32> Data { get; set; }
    }

    public class ChartJsLineChartDataViewModel
    {
        public ChartJsLineChartDataViewModel()
        {
            this.Datasets = new List<ChartJsLineChartDataDataSet>();
            this.Labels = new List<String>();
        }
        [JsonProperty(PropertyName = "labels")]
        public List<String> Labels { get; set; }
        [JsonProperty(PropertyName = "datasets")]
        public List<ChartJsLineChartDataDataSet> Datasets { get; set; }
    }

    public class NumberOfMembersReportViewModel
    {
        public Int32 NumberOfMembers { get; set; }
    }
}
