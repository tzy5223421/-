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

namespace WebService1
{
	/// <summary>
	/// shouming ��ժҪ˵����
	/// </summary>
	public class shouming : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		Class1 db1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			db1=new Class1();
			if(!Page.IsPostBack)
			{
				string sql1="select * from changjia";
				db1.cleardata();
				db1.ExectueSQL("changjia",sql1);

				for(int i=0;i<db1.getdata().Tables["changjia"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["changjia"].Rows[i]["��������"].ToString()));
				}

				sql1="select * from changjia where ��������='"+this.DropDownList1.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("changjia",sql1);

				string cj=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();

				sql1="select * from sbname";
				db1.cleardata();
				db1.ExectueSQL("sbname",sql1);

				for(int i=0;i<db1.getdata().Tables["sbname"].Rows.Count;i++)
				{
					this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString()));
				}

				sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("sbname",sql1);

				string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

				sql1="select * from basicinfo where not exists (select * from info where basicinfo.�豸id=info.�豸id) and �豸����id="+sb+" and ����id="+cj;
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.DropDownList3.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					this.DropDownList3.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}
			}
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from changjia where ��������='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			string cj=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();

			sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select * from basicinfo where not exists (select * from info where basicinfo.�豸id=info.�豸id) and �豸����id="+sb+" and ����id="+cj;
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList3.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList3.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}
		}

		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from changjia where ��������='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			string cj=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();

			sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select * from basicinfo where not exists (select * from info where basicinfo.�豸id=info.�豸id) and �豸����id="+sb+" and ����id="+cj;
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList3.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList3.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Service1 MyService=new Service1();
			string sb=this.DropDownList2.SelectedValue;
			string cj=this.DropDownList1.SelectedValue;
			string s=MyService.guzhangtime(sb,cj);
			this.Label1.Text=s;
			string sql1="select * from changjia where ��������='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			cj=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();

			sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select * from basicinfo where �豸����id="+sb+" and ����id="+cj+" and �豸���='"+this.DropDownList3.SelectedValue+"'";
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1); 
			
			DateTime t=DateTime.Parse(db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString());
			int i=s.IndexOf("��",0,s.Length);
			int year=Int32.Parse(s.Substring(0,i));
			int j=s.IndexOf("��",i,s.Length-i);
			int month=Int32.Parse(s.Substring(i+1,j-i-1));
			int day=Int32.Parse(s.Substring(j+1,s.Length-j-2));
			int year1=year+t.Year;
			int month1=month+t.Month;
			int day1=day+t.Day;
			if((month1==1||month1==3||month1==5||month1==7||month1==8||month1==10||month1==12)&&day1>31)
			{
				day1=day1-31;
				month1++;
			}
			else if((month1==4||month1==6||month1==9||month1==11)&&day1>30)
			{
				day1=day1-30;
				month1++;
			}
			else if(((year%4==0&&year%100!=0)||(year%400==0))&&month1==2&&day1>29)
			{
				day1=day1-29;
				month1++;
			}
			else if(month1==2&&day1>28)
			{
				day1=day1-28;
				month1++;
			}
			if(month1>12)
			{
				month1=month1-12;
				year1++;
			}
			string s1=year1.ToString()+"-"+month1.ToString()+"-"+day1.ToString();
			this.Label2.Text=s1;
		}
	}
}
