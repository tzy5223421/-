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
	/// Errorinfo ��ժҪ˵����
	/// </summary>
	public class Errorinfo1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
					
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
			string sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			//this.DataGrid1.VirtualItemCount=5;
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			
			BoundColumn b1=new BoundColumn();
			b1.DataField="�������ͺ�";
			b1.ReadOnly=true;
			b1.HeaderText="�������ͺ�";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="��������";
			b1.HeaderText="��������";
			this.DataGrid1.Columns.Add(b1);
							
			//this.DataGrid1.PageCount=pagecount;
			//this.DataGrid1.Columns[13].HeaderText="1";
			//this.DataGrid1.Columns[13].DataField="�豸���";
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
			
			if(this.DataGrid1.PageCount==1)
				this.Button3.Enabled=false;
			this.Button2.Enabled=false;
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int iPos=e.NewPageIndex;
			string sql1="select * from errorinfo";
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=iPos;
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string name=Session["name"].ToString();
			string id=Session["pwd"].ToString();
			//Response.Write(name+id);
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
					Response.Redirect("cuowu3.htm");
				else
					Response.Redirect("cuowu2.htm");
			}
			this.DataGrid1.EditItemIndex=e.Item.ItemIndex;
			
			string sql1="select * from errorinfo";
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string name=Session["name"].ToString();
			string id=Session["pwd"].ToString();
			//Response.Write(name+id);
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
					Response.Redirect("cuowu3.htm");
				else
					Response.Redirect("cuowu2.htm");
			}
			string sql1="delete from errorinfo where �������ͺ�="+e.Item.Cells[0].Text;
			db1.ExectueSQL("errorinfo",sql1);
			sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sql1="update errorinfo set ��������='"+((TextBox)e.Item.Cells[1].Controls[0]).Text+"'";
			sql1+=" where �������ͺ�="+e.Item.Cells[0].Text;
			
			db1.ExectueSQL("errorinfo",sql1);

			sql1="select * from errorinfo";
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.EditItemIndex=-1;
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
		}


		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=-1;
			
			string sql1="select * from errorinfo";
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.EditItemIndex=-1;
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
		}
		private void Button1_Click(object sender, System.EventArgs e)
		{
			int iPos=0;
			string sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			//Class1 db1=new Class1();
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.CurrentPageIndex=iPos;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button2.Enabled=false;
			else
				this.Button2.Enabled=true;
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			string sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();

			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button2.Enabled=false;
			else
				this.Button2.Enabled=true;
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			string sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex+1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button2.Enabled=false;
			else
				this.Button2.Enabled=true;
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			string sql1="select * from errorinfo";
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			
			db1.cleardata();
			db1.ExectueSQL("errorinfo",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.PageCount-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="errorinfo";
			this.DataGrid1.DataKeyField="�������ͺ�";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button2.Enabled=false;
			else
				this.Button2.Enabled=true;
		}
	}
}
