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
	/// edit2 ��ժҪ˵����
	/// </summary>
	public class edit2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
	
		Class1 db1;
		Class1 db2;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string name=Session["name"].ToString();
			string id=Session["pwd"].ToString();
			//Response.Write(name+id);
			db1=new Class1();
			db2=new Class1();
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
				this.Button1.Attributes.Add("onclick","return confirm('ȷ���޸���')");
				string sql3="select * from basicinfo where �豸id=" + Request.QueryString["id"];
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql3);

				this.TextBox1.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

				string sql1="select * from sbname";
				db1.ExectueSQL("sbname",sql1);

				this.DropDownList1.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["sbname"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString());
				}

				sql1="select * from sbname where �豸����id="+db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
				db2.ExectueSQL("sbname",sql1);

				this.DropDownList1.SelectedValue=db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

				sql1="select * from labname";
				db1.ExectueSQL("labname",sql1);

				this.DropDownList2.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["labname"].Rows.Count;i++)
				{
					this.DropDownList2.Items.Add(db1.getdata().Tables["labname"].Rows[i]["ʵ������"].ToString());
				}

				sql1="select * from labname where ʵ����id="+db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
				db2.ExectueSQL("labname",sql1);
				this.DropDownList2.SelectedValue=db2.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

				sql1="select * from changjia";
				db1.ExectueSQL("changjia",sql1);

				this.DropDownList3.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["changjia"].Rows.Count;i++)
				{
					this.DropDownList3.Items.Add(db1.getdata().Tables["changjia"].Rows[i]["��������"].ToString());
				}

				sql1="select * from changjia where ����id="+db1.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				db2.ExectueSQL("changjia",sql1);
				this.DropDownList3.SelectedValue=db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString();

				this.TextBox2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string sql1="update basicinfo set �豸���='" + this.TextBox1.Text+"',�豸����id=";
			string sql2="select * from sbname where �豸����='" + this.DropDownList1.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("sbname",sql2);

			sql1+=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();
			sql1+=",����id=";

			sql2="select * from changjia where ��������='"+this.DropDownList3.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("changjia",sql2);

			sql1+=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();
			sql1+=",��������='" + this.TextBox2.Text +"',ʵ����id=";

			sql2="select * from labname where ʵ������='" + this.DropDownList2.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("labname",sql2);

			sql1+=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			sql1+=" where �豸id="+Request.QueryString["id"];

			db1.ExectueSQL("",sql1);
			Response.Redirect("Basicinfo.aspx");
		}
	}
}
