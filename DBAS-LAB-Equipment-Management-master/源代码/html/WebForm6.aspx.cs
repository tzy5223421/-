using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataDynamics.ActiveReports.Export.Xls;

namespace html
{
	/// <summary>
	/// WebForm6 ��ժҪ˵����
	/// </summary>
	public class WebForm6 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected DataDynamics.ActiveReports.Web.WebViewer WebViewer1;
	
		Class1 db1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string name=Session["name"].ToString();
			string id=Session["pwd"].ToString();
			//Response.Write(name+id);
			db1=new Class1();
			string sql="select * from admin where username='";
			sql+=name;
			
			sql+="' and password='";
			sql+=id;
			sql+="'";
			db1.cleardata();
			db1.ExectueSQL("admin",sql);

			if(db1.getdata().Tables["admin"].Rows.Count==0)
			{
				sql="select * from userid where name='"+name+"' and password='"+id+"'";
				db1.cleardata();
				db1.ExectueSQL("userid",sql);
				if(db1.getdata().Tables["userid"].Rows.Count==0)
					Response.Redirect("cuowu1.htm");
			}
			sql="select * from ������Ϣ order by ʵ������,�豸����";
			db1.cleardata();
			db1.ExectueSQL("������Ϣ",sql);

			this.WebViewer1.ClearCachedReport();
			ActiveReport2 rpt=new ActiveReport2();
			rpt.SetDb(db1);
			rpt.DataMember="������Ϣ";
			rpt.Restart();
			this.WebViewer1.Report=rpt;
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			WebViewer1.Report = new html.ActiveReport2();
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			db1=new Class1();
			string sql="select * from ������Ϣ order by ʵ������,�豸����";
			db1.cleardata();
			db1.ExectueSQL("������Ϣ",sql);

			this.WebViewer1.ClearCachedReport();
			ActiveReport2 rpt=new ActiveReport2();
			rpt.SetDb(db1);
			rpt.DataMember="������Ϣ";
			rpt.Run();
			Response.ContentType = "application/x-msexcel";
			Response.AddHeader("content-disposition", "inline; filename=MyXLS.xls");
			XlsExport xls=new XlsExport();
			System.IO.MemoryStream memStream=new System.IO.MemoryStream();
			xls.RemoveVerticalSpace = true;
			xls.Export(rpt.Document, memStream);
			Response.BinaryWrite(memStream.ToArray());
			Response.End();
		}
	}
}
