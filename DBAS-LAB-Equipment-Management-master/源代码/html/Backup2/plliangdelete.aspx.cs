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

namespace html
{
	/// <summary>
	/// plliangdelete ��ժҪ˵����
	/// </summary>
	public class plliangdelete : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
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
			if(!Page.IsPostBack)
			{
				this.Button1.Attributes.Add("onclick","return confirm('ȷ��ɾ����')");
				string sql1="select * from labname";
				db1.cleardata();
				db1.ExectueSQL("labname",sql1);

				for(int i=0;i<db1.getdata().Tables["labname"].Rows.Count;i++)
				{
					this.DropDownList3.Items.Add(new ListItem(db1.getdata().Tables["labname"].Rows[i]["ʵ������"].ToString()));
				}

				sql1="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("labname",sql1);

				string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

				sql1="select distinct �豸����id from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.DropDownList4.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					sql1="select * from sbname where �豸����id="+db1.getdata().Tables["basicinfo"].Rows[i]["�豸����id"].ToString();
					db1.ExectueSQL("sbname",sql1);

					this.DropDownList4.Items.Add(new ListItem(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString()));
				}

				sql1="select * from sbname where �豸����='"+this.DropDownList4.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("sbname",sql1);

				string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

				sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.DropDownList1.Items.Clear();
				this.DropDownList2.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
					this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}

				sql1="select * from basicinfo where �豸����id="+sb+" and ʵ����id="+lab+" and �豸���='"+this.DropDownList1.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString();

                string changjia=db1.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				sql1="select * from changjia where ����id="+changjia;
				db1.cleardata();
				db1.ExectueSQL("changjia",sql1);

				this.Label1.Text=db1.getdata().Tables["changjia"].Rows[0]["��������"].ToString();
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
			this.DropDownList3.SelectedIndexChanged += new System.EventHandler(this.DropDownList3_SelectedIndexChanged);
			this.DropDownList4.SelectedIndexChanged += new System.EventHandler(this.DropDownList4_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DropDownList3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql1);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1="select distinct �豸����id from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList4.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				sql1="select * from sbname where �豸����id="+db1.getdata().Tables["basicinfo"].Rows[i]["�豸����id"].ToString();
				db1.ExectueSQL("sbname",sql1);

				this.DropDownList4.Items.Add(new ListItem(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString()));
			}

			sql1="select * from sbname where �豸����='"+this.DropDownList4.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList1.Items.Clear();
			this.DropDownList2.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}

			sql1="select * from basicinfo where �豸����id="+sb+" and ʵ����id="+lab+" and �豸���='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString();
			string changjia=db1.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
			sql1="select * from changjia where ����id="+changjia;
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			this.Label1.Text=db1.getdata().Tables["changjia"].Rows[0]["��������"].ToString();
		}

		private void DropDownList4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from sbname where �豸����='"+this.DropDownList4.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql1);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList1.Items.Clear();
			this.DropDownList2.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}

			sql1="select * from basicinfo where �豸����id="+sb+" and ʵ����id="+lab+" and �豸���='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString();
			string changjia=db1.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
			sql1="select * from changjia where ����id="+changjia;
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			this.Label1.Text=db1.getdata().Tables["changjia"].Rows[0]["��������"].ToString();
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from sbname where �豸����='"+this.DropDownList4.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql1);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1="select * from basicinfo where �豸����id="+sb+" and ʵ����id="+lab+" and �豸���='"+this.DropDownList1.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString();
			string changjia=db1.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
			sql1="select * from changjia where ����id="+changjia;
			db1.cleardata();
			db1.ExectueSQL("changjia",sql1);

			this.Label1.Text=db1.getdata().Tables["changjia"].Rows[0]["��������"].ToString();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string sql1="delete from basicinfo where �豸����id=";

			string sql2="select * from sbname where �豸����='"+this.DropDownList4.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql2);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql2="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql2);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1+=sb+" and ʵ����id="+lab+" and �豸��� between '"+this.DropDownList1.SelectedValue.ToString()+"' and '"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			Response.Redirect("Basicinfo.aspx");
		}
	}
}
