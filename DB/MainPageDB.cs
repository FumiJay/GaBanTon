using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GaBanTon.Models;
using GaBanTon.DB;

namespace GaBanTon.DB
{
    public class MainPageDB : DBbase
    {
        public new const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

        public List<MainPageModel> ViewGroup(string Status, string Keyword, out int totalSize, int currentSize = 1, int pageSize = 2)
        {
            //----- Process filter conditions -----
            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(Status) && !string.IsNullOrEmpty(Keyword))
                conditions.Add($" {Status} LIKE '%' + @Keyword + '%'");

            string filterConditions =
                (conditions.Count > 0)
                    ? (" WHERE " + string.Join(" AND ", conditions))
                    : string.Empty;
            //----- Process filter conditions -----

            string Query =
                $@"
                    SELECT TOP {3} * FROM
                    (
                    SELECT *, ROW_NUMBER() OVER(ORDER BY Sid DESC) AS ROWNUM
                    FROM [Group]
                    {filterConditions}) a
                    WHERE ROWNUM > {pageSize * (currentSize - 1)} AND Status = '未結團';";

            string countQuery =
                $@"
                    SELECT 
                        COUNT (Sid)
                    FROM [Group]
                    {filterConditions}
                ";

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(Status))
            {
                dbParameters.Add(new SqlParameter("@Status", Status));
            }

            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                dbParameters.Add(new SqlParameter("@Keyword", Keyword));
            }

            var dt = DBbase.GetDataTable(Query, dbParameters);

            List<MainPageModel> list = new List<MainPageModel>();

            foreach (DataRow dr in dt.Rows)
            {
                MainPageModel model = new MainPageModel();
                model.Sid = (int)dr["Sid"];
                model.GroupImg = (string)dr["GroupImg"];
                model.GroupTital = (string)dr["GroupTital"];
                model.MemberName = (string)dr["MemberName"];
                model.ShopName = (string)dr["ShopName"];
                model.Status = (string)dr["Status"];

                list.Add(model);
            }

            int? totalSize2 = this.GetScale(countQuery, dbParameters) as int?;
            totalSize = (totalSize2.HasValue) ? totalSize2.Value : 0;

            return list;
        }
    }
}