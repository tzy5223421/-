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
	/// Weihu ��ժҪ˵����
	/// </summary>
	public class Weihu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
	
		Class1 db1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			
			db1=new Class1();
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
			}
			string id1=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id1;
			Session["id"]=id1;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			
			BoundColumn b1=new BoundColumn();
			b1.DataField="ά�޹���";
			b1.HeaderText="ά�޹���";
			this.DataGrid1.Columns.Add(b1);

			b1=new BoundColumn();
			b1.DataField="������";
			b1.HeaderText="������";
			this.DataGrid1.Columns.Add(b1);

			b1=new BoundColumn();
			b1.DataField="����id";
			b1.ReadOnly=true;
			b1.HeaderText="����id";
			this.DataGrid1.Columns.Add(b1);

			b1=new BoundColumn();
			b1.DataField="�Ǽ�����";
			b1.HeaderText="�Ǽ�����";
			this.DataGrid1.Columns.Add(b1);

			b1=new BoundColumn();
			b1.DataField="���";
			b1.SortExpression="���";
			b1.ReadOnly=true;
			b1.HeaderText="���";
			this.DataGrid1.Columns.Add(b1);
			
			EditCommandColumn e1=new EditCommandColumn();
			e1.ButtonType=ButtonColumnType.LinkButton;
			e1.UpdateText="����";
			e1.CancelText="ȡ��";
			e1.EditText="�༭";

			this.DataGrid1.Columns.Add(e1);

			ButtonColumn bc1=new ButtonColumn();
			bc1.CommandName="Delete";
			bc1.Text="ɾ��";
			this.DataGrid1.Columns.Add(bc1);
				
			//this.DataGrid1.PageCount=pagecount;
			//this.DataGrid1.Columns[13].HeaderText="1";
			//this.DataGrid1.Columns[13].DataField="�豸���";
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			
			if(this.DataGrid1.PageCount==1)
				this.Button4.Enabled=false;
			this.Button3.Enabled=false;

			sql1="select * from info where ����id=" + id1;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
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
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("add2.aspx");
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
			string id1=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id1;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string guocheng=((TextBox)e.Item.Cells[0].Controls[0]).Text;
			string person=((TextBox)e.Item.Cells[1].Controls[0]).Text;
			string sql1="update weihu set ά�޹���='"+guocheng+"',������='"+person;
			sql1+="' where ���="+e.Item.Cells[4].Text;

			db1.ExectueSQL("weihu",sql1);

			string id1=Request.QueryString["id"];
			sql1="select * from weihu where ����id=" + id1;
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.EditItemIndex=-1;
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=-1;
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.EditItemIndex=-1;
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
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
			string sql1="delete from weihu where ���="+e.Item.Cells[4].Text;
			db1.ExectueSQL("weihu",sql1);

			string id1=Request.QueryString["id"];
			sql1="select * from weihu where ����id=" + id1;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int iPos=e.NewPageIndex;
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			this.DataGrid1.CurrentPageIndex=iPos;
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();

			sql1="select * from info where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
			Session["id"]=id;
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			int iPos=0;
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.CurrentPageIndex=iPos;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			sql1="select * from info where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
			Session["id"]=id;
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			sql1="select * from info where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
			Session["id"]=id;
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex+1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			sql1="select * from info where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
			Session["id"]=id;
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			
			string id=Request.QueryString["id"];
			string sql1="select * from weihu where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("weihu",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.PageCount-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="weihu";
			this.DataGrid1.DataKeyField="���";
			this.DataGrid1.DataBind();
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			sql1="select * from info where ����id=" + id;
			db1.cleardata();
			db1.ExectueSQL("info",sql1);
				
			string id2=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			sql1="select * from basicinfo where �豸id=" + id2;
			db1.ExectueSQL("basicinfo",sql1);

			this.Label2.Text=db1.getdata().Tables["basicinfo"].Rows[0]["�豸���"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
			sql1="select * from sbname where �豸����id=" + id2;
			db1.ExectueSQL("sbname",sql1);

			this.Label4.Text=db1.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString();

			id2=db1.getdata().Tables["basicinfo"].Rows[0]["ʵ����id"].ToString();
			sql1="select * from labname where ʵ����id=" + id2;
			db1.ExectueSQL("labname",sql1);

			this.Label6.Text=db1.getdata().Tables["labname"].Rows[0]["ʵ������"].ToString();

			id2=db1.getdata().Tables["info"].Rows[0]["�������ͺ�"].ToString();
			sql1="select * from errorinfo where �������ͺ�=" + id2;
			db1.ExectueSQL("errorinfo",sql1);

			this.Label8.Text=db1.getdata().Tables["errorinfo"].Rows[0]["��������"].ToString();
			Session["id"]=id;
		}

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem||e.Item.ItemType==ListItemType.EditItem)
				((LinkButton)e.Item.Cells[e.Item.Cells.Count-1].Controls[0]).Attributes.Add("onclick","return confirm('ȷ��ɾ����');");

		}
	}
}
