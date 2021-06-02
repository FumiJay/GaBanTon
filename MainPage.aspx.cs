using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using GaBanTon.DB;
using GaBanTon.Models;

namespace GaBanTon
{
    public partial class MainPage : System.Web.UI.Page
    {

        const int _pageSize = 3;
        //自動生頁數MODEL
        internal class PagingLink
        {
            public string Name { get; set; }
            public string Link { get; set; }
            public string Title { get; set; }
            public string Color { get; set; }
        }

        public class PagingHelper
        {
            //實作分頁的函式
            public static int CalculatePages(int totalSize, int pageSize)
            {
                // 頁 = 總比數 / 單頁資料數
                int pages = totalSize / pageSize;
                //如果有餘數就再+一頁
                if (totalSize % pageSize != 0)
                    pages += 1;
                //回傳給頁
                return pages;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadPettyCashView();
                this.SaveKeyword();
            }
        }

        private string GetQueryString(bool includePage, int? pageIndex)
        {
            //----- Get Query string parameters -----
            string page = Request.QueryString["Page"];
            string Status = Request.QueryString["Status"];
            string KeyWord = Request.QueryString["KeyWord"];
            //----- Get Query string parameters -----

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(page) && includePage)
                conditions.Add("Page=" + page);

            if (!string.IsNullOrEmpty(Status))
                conditions.Add("Status=" + Status);

            if (!string.IsNullOrEmpty(KeyWord))
                conditions.Add("KeyWord=" + KeyWord);

            if (pageIndex.HasValue)
                conditions.Add("Page=" + pageIndex.Value);

            string retText =
                (conditions.Count > 0)
                    ? "?" + string.Join("&", conditions)
                    : string.Empty;

            return retText;
        }

        //一般:從DB抓總表資料出來根據PAGE進行分頁     搜尋:抓取Keyword資料，進DB後將篩選的資料依據PAGE進行分頁
        private void LoadPettyCashView()
        {
            //----- Get Query string parameters -----
            string page = Request.QueryString["Page"];
            int pIndex = 0;
            //當頁面不為0時,進入預設第一頁
            if (string.IsNullOrEmpty(page))
                pIndex = 1;
            else
            {
                //將PAGE轉為數字，回傳pIndex
                int.TryParse(page, out pIndex);
                //如果回傳值小於0,強制轉成1
                if (pIndex <= 0)
                    pIndex = 1;
            }
            //----- Get Query string parameters -----
            //設定關鍵搜尋網址
            string Status = Request.QueryString["Status"];
            string KeyWord = Request.QueryString["KeyWord"];
            int totalSize = 0;

            var manager = new MainPageDB();
            var list = manager.ViewGroup(Status, KeyWord, out totalSize, pIndex, _pageSize);
            int pages = PagingHelper.CalculatePages(totalSize, _pageSize);

            List<PagingLink> pagingList = new List<PagingLink>();
            for (var i = 1; i <= pages; i++)
            {
                pagingList.Add(new PagingLink()
                {
                    Link = $"MainPage.aspx{this.GetQueryString(false, i)}",
                    Name = $"{i}",
                    Title = $"前往第 {i} 頁",
                    Color = (i == pIndex) ? "BLACK" : ""
                });
            }

            this.repPaging.DataSource = pagingList;
            this.repPaging.DataBind();

            this.Group.DataSource = list;
            this.Group.DataBind();
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            string Status = this.GroupStaus1.SelectedValue;
            string KeyWord = this.KeyWord.Text;

            string template = "?Page=1";

            if (!string.IsNullOrEmpty(Status))
                template += "&Status=" + Status;

            if (!string.IsNullOrEmpty(KeyWord))
                template += "&KeyWord=" + KeyWord;

            Response.Redirect("MainPage.aspx" + template);
        }

        protected void Detail_Click(object sender, EventArgs e)
        {
            ImageButton imageButton = sender as ImageButton;

            string GroupSid = imageButton.CommandArgument;
            string template = "";

            if (!string.IsNullOrEmpty(GroupSid))
                template += "?GroupSid=" + GroupSid;

            Response.Redirect("GroupDetail.aspx" + template);
        }

        private void SaveKeyword()
        {
            var Statusval = Request.QueryString["Status"];
            var txtval = Request.QueryString["Keyword_txt"];

            if (!string.IsNullOrEmpty(txtval))
            {
                this.GroupStaus1.SelectedValue = Statusval;
                this.KeyWord.Text = txtval;
            }
        }
    }
}