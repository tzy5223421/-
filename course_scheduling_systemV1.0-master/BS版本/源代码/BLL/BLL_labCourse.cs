﻿using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_labCourse
    {
        DAL_labCourse l = new DAL_labCourse();
        public bool insert(LabCourse ll)
        {
            return l.insert(ll);
        }
        public bool function(Functions f)
        {
            return l.function(f);
        }
        public string num()
        {
            return l.num();
        }
        public bool fresh(string user)
        {
            return l.fresh(user);
        }
        public string insertDetail(CourseDetail cc)
        {
            l.insertDetail(cc);
            return "";
        }
        public string findRecord(string labNo)
        {
            DataTable dt = l.findCourseByLab(labNo);
            DataTable d = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dd = l.findDetailByCno(dt.Rows[i]["id"].ToString());
                for (int j = 0; j < dd.Rows.Count; j++)
                {
                    DataRow r = dt.NewRow();
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        if (dt.Columns[k].ColumnName == "week")
                            r[k] = dd.Rows[j]["week"].ToString();
                        else if (dt.Columns[k].ColumnName == "section")
                        {
                            r[k] = dd.Rows[j]["remark2"].ToString();
                        }
                        else if (dt.Columns[k].ColumnName == "remark2")
                        {
                            r[k] = dd.Rows[j]["remark1"].ToString();
                        }
                        else
                            r[k] = dt.Rows[i][k].ToString();
                    }
                    d.Rows.Add(r.ItemArray);
                }
            }
            DataTable sec = l.findSec("section");
            for (int i = 0; i < sec.Rows.Count; i++)
            {
                int a = int.Parse(sec.Rows[i]["no"].ToString());
                if (a <= 7)
                    sec.Rows[i]["no"] = "1.2";
                else if (a <= 14 && a > 7)
                    sec.Rows[i]["no"] = "3.4";
                else if (a <= 21 && a > 14)
                    sec.Rows[i]["no"] = "5.6";
                else if (a <= 28 && a > 21)
                    sec.Rows[i]["no"] = "7.8";
                else
                    sec.Rows[i]["no"] = "9.10";
                sec.Rows[i]["remark1"] = chinese(a % 7);
            }
            DataTable t = new DataTable();
            t.Columns.Add("week");
            for (int i = 0; i < sec.Rows.Count; i++)
            {
                for (int j = 0; j < d.Rows.Count; j++)
                {
                    if (sec.Rows[i]["no"].ToString().Trim() == d.Rows[j]["section"].ToString().Trim() && sec.Rows[i]["remark1"].ToString().Trim() == d.Rows[j]["remark2"].ToString().Trim())
                    {
                        DataRow r = t.NewRow();
                        r[0] = d.Rows[j]["week"].ToString().Trim();
                        t.Rows.Add(r.ItemArray);
                    }
                }
            }
            //去除datatable重复行
            DataView dv = new DataView(t);
            t = dv.ToTable(true);

            return JsonCast.DataTableToJSON(t, false).ToString();
        }
        public string findSec(string type)
        {
            return JsonCast.DataTableToJSON(l.findSec(type), false).ToString();
        }
        public string chinese(int a)
        {
            switch (a)
            {
                case 1: return "一";
                case 2: return "二";
                case 3: return "三";
                case 4: return "四";
                case 5: return "五";
                case 6: return "六";
                default:
                    return "日";
            }
        }
        public int num(string a)
        {
            switch (a)
            {
                case "一": return 0;
                case "二": return 1;
                case "三": return 2;
                case "四": return 3;
                case "五": return 4;
                case "六": return 5;
                default:
                    return 6;
            }
        }
        /// <summary>
        /// 判断 周次是交叉或者  不交叉  如果交叉则返回true
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool judgeTable(DataTable dt)
        {
            if (dt.Rows.Count > 1)
            {
                if (dt.Rows[0]["remark1"].ToString() == dt.Rows[1]["remark1"].ToString())
                    return false;
            }
            return true;
        }
        public DataTable createCourse(string labNo)
        {
            DataTable co = new DataTable();
            co.Columns.Add("一");
            co.Columns.Add("二");
            co.Columns.Add("三");
            co.Columns.Add("四");
            co.Columns.Add("五");
            co.Columns.Add("六");
            co.Columns.Add("日");
            DataRow r1 = co.NewRow();
            DataRow r2 = co.NewRow();
            DataRow r3 = co.NewRow();
            DataRow r4 = co.NewRow();
            DataRow r5 = co.NewRow();
            DataRow rr1 = co.NewRow();
            DataRow rr2 = co.NewRow();
            DataRow rr3 = co.NewRow();
            DataRow rr4 = co.NewRow();
            DataRow rr5 = co.NewRow();
            string[] arr = new string[5];
            DataTable d1 = l.findCourseByLab(labNo);
            string str = "", ss = "", name = "", week = "", sec = "";
            if (d1.Rows.Count > 0)
            {
                name = d1.Rows[0]["id"].ToString();
                for (int i = 0; i < d1.Rows.Count; i++)
                {
                    str = d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString();
                    ss = d1.Rows[i][1].ToString() + "\r\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\r\n" + d1.Rows[i]["teacher"].ToString();
                    DataTable d2 = l.findDetailByCno(d1.Rows[i][0].ToString());
                    if (d2.Rows.Count > 0)
                    {
                        DataView dd = d2.DefaultView;
                        dd.Sort = "remark1 asc";
                        d2 = dd.ToTable();
                        week = d2.Rows[0]["remark1"].ToString();
                        sec = d2.Rows[0]["remark2"].ToString();
                        int flag = -1;
                        //给每行每列设置标记
                        int[] a = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        int[] b = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        int[] c = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        int[] d = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        int[] e = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        for (int j = 0; j < d2.Rows.Count; j++)
                        {
                            if (d2.Rows[j]["remark2"].ToString()[0].ToString() == "1")
                            {
                                flag = num(d2.Rows[j]["remark1"].ToString());
                                if (a[flag] == 1 && week == d2.Rows[j]["remark1"].ToString())
                                {
                                    r1[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    rr1[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    continue;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(r1[d2.Rows[j]["remark1"].ToString()].ToString()))
                                    {
                                        a[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        r1[d2.Rows[j]["remark1"].ToString()] = str + "<br>(" + d2.Rows[j]["week"].ToString();
                                        rr1[d2.Rows[j]["remark1"].ToString()] = ss + "\n(" + d2.Rows[j]["week"].ToString();
                                        arr[0] = d1.Rows[i]["id"].ToString();
                                    }
                                    else
                                    {
                                        a[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        arr[0] = d1.Rows[i]["id"].ToString();
                                        r1[d2.Rows[j]["remark1"].ToString()] += ") <br>";
                                        r1[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString() + "<br>(";
                                        rr1[d2.Rows[j]["remark1"].ToString()] += ") \n";
                                        rr1[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\n" + d1.Rows[i]["teacher"].ToString() + "\n(";
                                        r1[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                        rr1[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                    }
                                }
                            }
                            else if (d2.Rows[j]["remark2"].ToString()[0].ToString() == "3")
                            {
                                flag = num(d2.Rows[j]["remark1"].ToString());
                                if (b[flag] == 1 && week == d2.Rows[j]["remark1"].ToString())
                                {
                                    r2[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    rr2[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    continue;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(r2[d2.Rows[j]["remark1"].ToString()].ToString()))
                                    {
                                        b[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        r2[d2.Rows[j]["remark1"].ToString()] = str + "<br>(" + d2.Rows[j]["week"].ToString();
                                        rr2[d2.Rows[j]["remark1"].ToString()] = ss + "\n(" + d2.Rows[j]["week"].ToString();
                                        arr[1] = d1.Rows[i]["id"].ToString();
                                    }
                                    else
                                    {
                                        b[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        arr[1] = d1.Rows[i]["id"].ToString();//?
                                        r2[d2.Rows[j]["remark1"].ToString()] += ") <br>";
                                        r2[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString() + "<br>(";
                                        rr2[d2.Rows[j]["remark1"].ToString()] += ") \n";
                                        rr2[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\n" + d1.Rows[i]["teacher"].ToString() + "\n(";
                                        r2[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                        rr2[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                    }
                                }
                            }
                            else if (d2.Rows[j]["remark2"].ToString()[0].ToString() == "5")
                            {
                                flag = num(d2.Rows[j]["remark1"].ToString());
                                if (c[flag] == 1 && week == d2.Rows[j]["remark1"].ToString())
                                {
                                    r3[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    rr3[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    continue;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(r3[d2.Rows[j]["remark1"].ToString()].ToString()))
                                    {
                                        c[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        r3[d2.Rows[j]["remark1"].ToString()] = str + "<br>(" + d2.Rows[j]["week"].ToString();
                                        rr3[d2.Rows[j]["remark1"].ToString()] = ss + "\n(" + d2.Rows[j]["week"].ToString();
                                        arr[2] = d1.Rows[i]["id"].ToString();
                                    }
                                    else
                                    {
                                        c[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        arr[2] = d1.Rows[i]["id"].ToString();
                                        r3[d2.Rows[j]["remark1"].ToString()] += ") <br>";
                                        r3[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString() + "<br>(";
                                        rr3[d2.Rows[j]["remark1"].ToString()] += ") \n";
                                        rr3[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\n" + d1.Rows[i]["teacher"].ToString() + "\n(";
                                        r3[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                        rr3[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                    }
                                }
                            }
                            else if (d2.Rows[j]["remark2"].ToString()[0].ToString() == "7")
                            {
                                flag = num(d2.Rows[j]["remark1"].ToString());
                                if (d[flag] == 1 && week == d2.Rows[j]["remark1"].ToString())
                                {
                                    r4[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    rr4[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(r4[d2.Rows[j]["remark1"].ToString()].ToString()))
                                    {
                                        d[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        r4[d2.Rows[j]["remark1"].ToString()] = str + "<br>(" + d2.Rows[j]["week"].ToString();
                                        rr4[d2.Rows[j]["remark1"].ToString()] = ss + "\n(" + d2.Rows[j]["week"].ToString();
                                        arr[3] = d1.Rows[i]["id"].ToString();
                                    }
                                    else
                                    {
                                        d[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        arr[3] = d1.Rows[i]["id"].ToString();
                                        r4[d2.Rows[j]["remark1"].ToString()] += ") <br>";
                                        r4[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString() + "<br>(";
                                        rr4[d2.Rows[j]["remark1"].ToString()] += ") \n";
                                        rr4[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\n" + d1.Rows[i]["teacher"].ToString() + "\n(";
                                        r4[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                        rr4[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                flag = num(d2.Rows[j]["remark1"].ToString());
                                if (e[flag] == 1 && week == d2.Rows[j]["remark1"].ToString())
                                {
                                    r5[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                    rr5[d2.Rows[j]["remark1"].ToString()] += "." + d2.Rows[j]["week"].ToString();
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(r5[d2.Rows[j]["remark1"].ToString()].ToString()))
                                    {
                                        e[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        r5[d2.Rows[j]["remark1"].ToString()] = str + "<br>(" + d2.Rows[j]["week"].ToString();
                                        rr5[d2.Rows[j]["remark1"].ToString()] = ss + "\n(" + d2.Rows[j]["week"].ToString();
                                        arr[4] = d1.Rows[i]["id"].ToString();
                                    }
                                    else
                                    {
                                        e[flag] = 1;
                                        week = d2.Rows[j]["remark1"].ToString();
                                        sec = d2.Rows[j]["remark2"].ToString();
                                        arr[4] = d1.Rows[i]["id"].ToString();
                                        r5[d2.Rows[j]["remark1"].ToString()] += ") <br>";
                                        r5[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "<br>" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "<br>" + d1.Rows[i]["teacher"].ToString() + "<br>(";
                                        rr5[d2.Rows[j]["remark1"].ToString()] += ") \n";
                                        rr5[d2.Rows[j]["remark1"].ToString()] += d1.Rows[i][1].ToString() + "\n" + d1.Rows[i][2].ToString() + "(" + d1.Rows[i]["count"].ToString() + ")" + "\n" + d1.Rows[i]["teacher"].ToString() + "\n(";
                                        r5[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                        rr5[d2.Rows[j]["remark1"].ToString()] += d2.Rows[j]["week"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            DataTable excelDt = co.Clone();
            co.Rows.Add(r1.ItemArray);
            co.Rows.Add(r2.ItemArray);
            co.Rows.Add(r3.ItemArray);
            co.Rows.Add(r4.ItemArray);
            co.Rows.Add(r5.ItemArray);
            DataRow r6 = co.NewRow();
            int y = int.Parse(DateTime.Now.Year.ToString());
            string title = "", lab = "";
            int m = int.Parse(DateTime.Now.Month.ToString());
            if (d1.Rows.Count > 0)
                lab = d1.Rows[0]["lab"].ToString();
            if (m >= 2 && m <= 8)
                title = y - 1 + "-" + y + "年第2学期" + lab + "实验室课表";
            else
                title = y + "-" + (y + 1) + "年第1学期" + lab + "实验室课表";
            r6[0] = title;
            co.Rows.Add(r6.ItemArray);
            co.Rows.Add(rr1.ItemArray);
            co.Rows.Add(rr2.ItemArray);
            co.Rows.Add(rr3.ItemArray);
            co.Rows.Add(rr4.ItemArray);
            co.Rows.Add(rr5.ItemArray);
            for (int i = 0; i < co.Rows.Count; i++)
            {
                for (int j = 0; j < co.Columns.Count; j++)
                {
                    if (!string.IsNullOrWhiteSpace(co.Rows[i][j].ToString()))
                    {
                        if (i != 5)
                            co.Rows[i][j] = co.Rows[i][j].ToString() + ")";
                    }
                }
            }
            return co;
        }

        private static int k = 0;
        public string findFunction(string num)
        {
            try
            {
                DataTable dd = l.findFunction(num);
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("周次");
                dt.Columns.Add("星期");
                dt.Columns.Add("节次");
                string type = "";
                List<string> week = new List<string>();
                List<string> section = new List<string>();
                type = dd.Rows[0][0].ToString();
                for (int i = 0; i < dd.Rows.Count; i++)
                {
                    if (dd.Rows[i]["type"].ToString() == "section")
                        section.Add(dd.Rows[i]["no"].ToString());
                    else
                        week.Add(dd.Rows[i]["no"].ToString());
                }
                for (int j = 0; j < week.Count; j++)
                {
                    for (int i = 0; i < section.Count; i++)
                    {
                        DataRow r = dt.NewRow();
                        r[0] = k.ToString();
                        r[1] = week[j];
                        int a = int.Parse(section[i]);
                        int b = a % 7;
                        if (b == 0)
                            r[2] = "7";
                        else
                        {
                            r[2] = b.ToString();
                        }
                        if (a <= 7)
                            r[3] = "1.2";
                        else if (a > 7 && a <= 14)
                            r[3] = "3.4";
                        else if (a > 14 && a <= 21)
                            r[3] = "5.6";
                        else if (a > 21 && a <= 28)
                            r[3] = "7.8";
                        else
                            r[3] = "9.10";
                        dt.Rows.Add(r.ItemArray);
                        k++;
                    }

                }
                DataView dataView = dt.DefaultView;
                dataView.Sort = "星期 asc";
                dt = dataView.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][2] = chinese(int.Parse(dt.Rows[i][2].ToString()));
                }
                return JsonCast.DataTableToJSON(dt, false).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

}
