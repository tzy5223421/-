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
	/// piliang ��ժҪ˵����
	/// </summary>
	public class piliang : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Button Button1;
	
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
				this.Button1.Attributes.Add("onclick","return confirm('ȷ�������')");
				string sql1="select * from sbname";
				db1.cleardata();
				db1.ExectueSQL("sbname",sql1);

				this.DropDownList1.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["sbname"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString());
				}

				sql1="select * from labname";
				db1.cleardata();
				db1.ExectueSQL("labname",sql1);

				this.DropDownList2.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["labname"].Rows.Count;i++)
				{
					this.DropDownList2.Items.Add(db1.getdata().Tables["labname"].Rows[i]["ʵ������"].ToString());
				}

				sql1="select * from changjia";
				db1.cleardata();
				db1.ExectueSQL("changjia",sql1);

				this.DropDownList3.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["changjia"].Rows.Count;i++)
				{
					this.DropDownList3.Items.Add(db1.getdata().Tables["changjia"].Rows[i]["��������"].ToString());
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//string sql1="insert into basicinfo values('" + this.TextBox1.Text+"',";
			string sb;
			string lab;
			string cj;
			string sql2="select * from sbname where �豸����='" + this.DropDownList1.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("sbname",sql2);

			sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();
			
			sql2="select * from changjia where ��������='"+this.DropDownList3.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("changjia",sql2);

			cj=db1.getdata().Tables["changjia"].Rows[0]["����id"].ToString();
			
			sql2="select * from labname where ʵ������='" + this.DropDownList2.SelectedValue.ToString()+"'";

			db1.cleardata();
			db1.ExectueSQL("labname",sql2);

			lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			
			int num=Int32.Parse(this.TextBox2.Text.ToString());
			int first=0;
			for(int i=0;i<9;i++)
			{
				if(this.TextBox1.Text.IndexOf(i.ToString(),0,this.TextBox1.Text.Length)!=-1)
				{
					first=i;
					break;
				}
			}
			string firstid=this.TextBox1.Text.Substring(this.TextBox1.Text.Length-2,2);
			string letter=this.TextBox1.Text.Substring(0,this.TextBox1.Text.Length-2);
			for(int i=0;i<num;i++)
			{
				int j=Int32.Parse(firstid)+i;
				string s;
				if(j<10)
					s="0"+j.ToString();
				else
					s=j.ToString();
				string biaohao=letter+s;
				string sql1="insert into basicinfo values('"+biaohao+"',"+sb+","+cj+",'"+this.TextBox3.Text+"',"+lab+")";

				db1.ExectueSQL("",sql1);
			}
			Response.Redirect("Basicinfo.aspx");
		}
	}
}
