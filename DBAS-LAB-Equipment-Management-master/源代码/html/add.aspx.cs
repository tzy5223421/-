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
	/// add ��ժҪ˵����
	/// </summary>
	public class add : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList DropDownList7;
		protected System.Data.SqlClient.SqlDataReader dreader,dreader1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList8;
		protected System.Web.UI.WebControls.DropDownList DropDownList9;
		protected System.Web.UI.WebControls.DropDownList DropDownList10;
		protected System.Web.UI.WebControls.Label Label1;

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
			if(db1.getdata().Tables["admin"].Rows[0]["jibie"].ToString().Trim()=="����")
			{
				this.DropDownList7.Visible=true;
				this.Label1.Visible=false;
			}
			else
			{
				this.Label1.Text=name;
				this.Label1.Visible=true;
				this.DropDownList7.Visible=false;
			}
            if(!Page.IsPostBack)
			{
				//this.Label1.Text=DateTime.Now.ToString("yyyy-MM-dd");
				
				this.Button1.Attributes.Add("onclick","return confirm('ȷ�������')");
				string sql1="select * from labname";
				db1.cleardata();
				db1.ExectueSQL("labname",sql1);

				for(int i=0;i<db1.getdata().Tables["labname"].Rows.Count;i++)
				{
					this.DropDownList10.Items.Add(new ListItem(db1.getdata().Tables["labname"].Rows[i]["ʵ������"].ToString()));
				}
				//this.Label2.Text=this.dataSet11.Tables["labname"].Rows[0]["ʵ������"].ToString();
				sql1="select * from labname where ʵ������='";
				sql1+=this.DropDownList10.SelectedValue;
				sql1+="'";
				db1.cleardata();
				db1.ExectueSQL("labname",sql1);

				string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

				sql1="select distinct �豸����id from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.DropDownList2.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					sql1="select * from sbname where �豸����id="+db1.getdata().Tables["basicinfo"].Rows[i]["�豸����id"].ToString();
					db1.ExectueSQL("sbname",sql1);

					this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString()));
				}

				sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
				db1.cleardata();
				db1.ExectueSQL("sbname",sql1);

				string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

				sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql1);

				this.DropDownList1.Items.Clear();
				//this.DropDownList2.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
					//this.DropDownList2.Items.Add(new ListItem(this.dataSet11.Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}

				sql1="select * from errorinfo";
				db1.cleardata();
				db1.ExectueSQL("errorinfo",sql1);

				for(int i=0;i<db1.getdata().Tables["errorinfo"].Rows.Count;i++)
				{
					this.DropDownList6.Items.Add(new ListItem(db1.getdata().Tables["errorinfo"].Rows[i]["��������"].ToString()));
					//this.DropDownList2.Items.Add(new ListItem(this.dataSet11.Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}
				
				sql1="select * from admin";
				db1.cleardata();
				db1.ExectueSQL("admin",sql1);

				for(int i=0;i<db1.getdata().Tables["admin"].Rows.Count;i++)
				{
					this.DropDownList7.Items.Add(new ListItem(db1.getdata().Tables["admin"].Rows[i]["username"].ToString()));
					//this.DropDownList2.Items.Add(new ListItem(this.dataSet11.Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}

				for(int i=2000;i<=2007;i++)
				{
					this.DropDownList3.Items.Add(new ListItem(i.ToString()));
				}

				for(int i=1;i<=12;i++)
				{
					this.DropDownList8.Items.Add(new ListItem(i.ToString()));
				}
				for(int i=1;i<=31;i++)
				{
					this.DropDownList9.Items.Add(new ListItem(i.ToString()));
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
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.DropDownList10.SelectedIndexChanged += new System.EventHandler(this.DropDownList10_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{

			string sql1="insert into info values('";
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

			if(db1.getdata().Tables["admin"].Rows[0]["jibie"].ToString().Trim()=="����")
			{
				sql1+=this.DropDownList7.SelectedValue;
			}
			else
			{
				sql1+=name;
			}
			//sql1+=this.DropDownList7.SelectedValue;
			sql1+="','";
			sql1+=this.DropDownList3.SelectedValue.ToString();
			sql1+="-"+this.DropDownList8.SelectedValue.ToString()+"-"+this.DropDownList9.SelectedValue.ToString();
            //sql1+=this.Label1.Text;
			sql1+="','";
			sql1+=this.DropDownList4.SelectedValue;
			sql1+="','";
			sql1+=this.DropDownList5.SelectedValue;
			sql1+="',";
			string sql2="select * from errorinfo where ��������='";
			sql2+=this.DropDownList6.SelectedValue.ToString();
			sql2+="'";
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql2);

			sql1+=db1.getdata().Tables["errorinfo"].Rows[0]["�������ͺ�"].ToString();
			
			sql1+=",";

			sql2="select * from basicinfo where �豸���='";
			sql2+=this.DropDownList1.SelectedValue;
			sql2+="' and �豸����id=";
			string sql3="select * from sbname where �豸����='";
			sql3+=this.DropDownList2.SelectedValue;
			sql3+="'";

			db1.cleardata();
			db1.ExectueSQL("sbname",sql3);

			sql2+=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();
			
			sql2+=" and ʵ����id=";

            sql3="select * from labname where ʵ������='";
			sql3+=this.DropDownList10.SelectedValue;
			sql3+="'";

			db1.cleardata();
			db1.ExectueSQL("labname",sql3);

			sql2+=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql2);
			sql1+=db1.getdata().Tables["basicinfo"].Rows[0]["�豸id"].ToString();
			
			sql1+=")";
			db1.cleardata();
			db1.ExectueSQL("",sql1);
			Response.Redirect("sbgl.aspx");

		}



		private void DropDownList10_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from labname where ʵ������='";
			sql1+=this.DropDownList10.SelectedValue;
			sql1+="'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql1);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1="select distinct �豸����id from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList2.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				sql1="select * from sbname where �豸����id="+db1.getdata().Tables["basicinfo"].Rows[i]["�豸����id"].ToString();
				db1.ExectueSQL("sbname",sql1);

				this.DropDownList2.Items.Add(new ListItem(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString()));
			}

			sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList1.Items.Clear();
			//this.DropDownList2.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				//this.DropDownList2.Items.Add(new ListItem(this.dataSet11.Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}

		}

		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql1="select * from labname where ʵ������='";
			sql1+=this.DropDownList10.SelectedValue;
			sql1+="'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql1);

			string lab=db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();

			sql1="select * from sbname where �豸����='"+this.DropDownList2.SelectedValue.ToString()+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			string sb=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();

			sql1="select distinct �豸��� from basicinfo where �豸����id="+sb+" and ʵ����id="+lab;

			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql1);

			this.DropDownList1.Items.Clear();
			//this.DropDownList2.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList1.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				//this.DropDownList2.Items.Add(new ListItem(this.dataSet11.Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}

		}
	}
}
