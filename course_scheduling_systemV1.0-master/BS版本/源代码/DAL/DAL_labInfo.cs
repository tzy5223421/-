﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_labInfo
    {
        DAL_common c = new DAL_common();
        SqlDB sql = new SqlDB();
        string str = "";
        LabInfo l = new LabInfo();
       /// <summary>
       /// 返回所有数据
       /// </summary>
       /// <returns></returns>
        public DataTable findAll()
        {
            return c.findAll(l);
        }
        /// <summary>
        /// 判断实验室门标是否重复
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool ReLabNo(string no)
        {
            str = "select * from LabInfo where name='"+no+"'";
            if (sql.FillDt(str).Rows.Count > 0)
                return true;
            return false;
        }
        public string findIdByName(string no)
        {
            str = "select * from LabInfo where name='" + no + "'";
            return sql.FillDt(str).Rows[0][0].ToString();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(string id)
        {
            l.id = int.Parse(id);
            return c.delete(l);
        }
        public bool update(LabInfo ll)
        {
            return c.update(ll);
        }
        public bool insert(LabInfo ll)
        {
            return c.insert(ll);
        }
        /// <summary>
        /// 根据id获得一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getOne(string id)
        {
            try
            {
                str = "select * from LabInfo where id=" + id + "";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
       /// <summary>
       /// 设置是否可用
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public bool state(string id)
        {
            try
            {
                str = "select remark1 from LabInfo where id=" + id + "";
                DataTable dt = sql.FillDt(str);
                if (dt.Rows[0][0].ToString() == "1")
                    str = "update LabInfo set remark1='0' where id=" + id + "";
                else
                    str = "update LabInfo set remark1='1' where id=" + id + "";
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
