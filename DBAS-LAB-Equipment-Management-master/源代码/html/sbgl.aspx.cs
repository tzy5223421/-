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
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		
		Class1 db1;
		//protected html.DataSet1 dataSet12;
	
		string jb;
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
			jb=db1.getdata().Tables["admin"].Rows[0]["jibie"].ToString();
			string sql1;
			if(!Page.IsPostBack)
			{
				
				sql="select * from labname";
				db1.cleardata();
				db1.ExectueSQL("labname",sql);
				this.DropDownList3.Items.Clear();

				for(int i=0;i<db1.getdata().Tables["labname"].Rows.Count;i++)
				{
					this.DropDownList3.Items.Add(new ListItem(db1.getdata().Tables["labname"].Rows[i]["ʵ������"].ToString()));
				}
				
				sql="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
				db1.cleardata();
				db1.ExectueSQL("labname",sql);

				sql="select distinct �豸��� from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
				db1.cleardata();
				db1.ExectueSQL("basicinfo",sql);

				this.DropDownList4.Items.Clear();
				for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
				{
					this.DropDownList4.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
				}
				this.Hidden1.Value="0";
			}
			
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			//this.DataGrid1.VirtualItemCount=5;
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			
			BoundColumn b1=new BoundColumn();
			b1.DataField="�豸���";
			b1.ReadOnly=true;
			b1.HeaderText="�豸���";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="��������";
			b1.ReadOnly=true;
			b1.HeaderText="��������";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="��������";
			b1.ReadOnly=true;
			b1.HeaderText="��������";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="������";
			b1.ReadOnly=true;
			b1.HeaderText="������";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="�Ǽ�����";
			b1.ReadOnly=true;
			b1.HeaderText="�Ǽ�����";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="����ʱ��";
			b1.ReadOnly=true;
			b1.HeaderText="����ʱ��";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="���ϲ���";
			b1.ReadOnly=true;
			b1.HeaderText="���ϲ���";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="��������";
			b1.ReadOnly=true;
			b1.HeaderText="��������";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="�豸����";
			b1.ReadOnly=true;
			b1.HeaderText="�豸����";
			this.DataGrid1.Columns.Add(b1);
			b1=new BoundColumn();
			b1.DataField="ʵ������";
			b1.ReadOnly=true;
			b1.HeaderText="ʵ������";
			this.DataGrid1.Columns.Add(b1);

			HyperLinkColumn h1=new HyperLinkColumn();
			h1.DataNavigateUrlField="����id";
			h1.DataNavigateUrlFormatString="weihu.aspx?id={0}";
			h1.DataTextField="����id";
			h1.HeaderText="����id";
			this.DataGrid1.Columns.Add(h1);

			h1=new HyperLinkColumn();
			h1.DataNavigateUrlField="����id";
			h1.DataNavigateUrlFormatString="edit.aspx?id={0}";
			h1.Text="�޸�";
			this.DataGrid1.Columns.Add(h1);

			ButtonColumn bc1=new ButtonColumn();
			bc1.Text="ɾ��";
			bc1.CommandName="Delete";
			this.DataGrid1.Columns.Add(bc1);
				
			//this.DataGrid1.PageCount=pagecount;
			//this.DataGrid1.Columns[13].HeaderText="1";
			//this.DataGrid1.Columns[13].DataField="�豸���";
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
			this.DataGrid1.DataBind();
			
			if(this.DataGrid1.PageCount==1)
				this.Button4.Enabled=false;
			this.Button3.Enabled=false;
			//if(Request.QueryString["pwd1"]!=this.dataSet2.Tables["�û�"].Rows[0]["����"].ToString())
			//{
			//	Response.Redirect("denglu1.asp");
			//}
			//this.Label1.Text="��ӭ��:"+this.dataSet2.Tables["�û�"].Rows[0]["�û���"].ToString();
			
			//if(this.DataGrid1.PageCount==1)
			//	this.ImageButton1.Enabled=false;
			//this.Imagebutton2.Enabled=false;
			Session["name"]=name;
			Session["pwd"]=id;
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
			this.DropDownList3.SelectedIndexChanged += new System.EventHandler(this.DropDownList3_SelectedIndexChanged);
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
//			this.Hidden1.ServerChange += new System.EventHandler(this.Hidden1_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("add.aspx");
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
			jb=db1.getdata().Tables["admin"].Rows[0]["jibie"].ToString();
			sql="select * from info where ����id="+((HyperLink)e.Item.Cells[10].Controls[0]).Text;
			db1.cleardata();
			db1.ExectueSQL("info",sql);

			if(jb.Trim()!="����"&&name!=db1.getdata().Tables["info"].Rows[0]["������"].ToString())
				Response.Redirect("cuowu2.htm");
			string sql1="delete from info where ����id="+((HyperLink)e.Item.Cells[10].Controls[0]).Text;
			db1.cleardata();
			db1.ExectueSQL("",sql1);
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			
			//sql1+=Request.QueryString["name11"];
			//sql1+="'";
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			this.DataGrid1.CurrentPageIndex=0;
			
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
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
			string sql1;
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";		
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			this.DataGrid1.CurrentPageIndex=iPos;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
			this.DataGrid1.DataBind();
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			int iPos=0;
			string sql1;
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			this.DataGrid1.CurrentPageIndex=iPos;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
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

		private void Button3_Click(object sender, System.EventArgs e)
		{
			//int iPos=;
			string sql1;
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
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

		private void Button4_Click(object sender, System.EventArgs e)
		{
			//int iPos=e.NewPageIndex;
			string sql1;
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.CurrentPageIndex+1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
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

		private void Button5_Click(object sender, System.EventArgs e)
		{
			//int iPos=e.NewPageIndex;
			string sql1;
			if(this.Hidden1.Value.Trim()=="0")
			{
				sql1="select * from ά��";
			}
			else if(this.Hidden1.Value.Trim()=="1")
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			}
			else
			{
				sql1="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
				sql1+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			}
			
			db1.cleardata();
			db1.ExectueSQL("ά��",sql1);
			
			this.DataGrid1.CurrentPageIndex=this.DataGrid1.PageCount-1;
			
			//this.DataGrid1.Load;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
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

		private void DropDownList3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sql="select * from labname where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			db1.cleardata();
			db1.ExectueSQL("labname",sql);

			sql="select distinct �豸��� from basicinfo where ʵ����id="+db1.getdata().Tables["labname"].Rows[0]["ʵ����id"].ToString();
			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql);

			this.DropDownList4.Items.Clear();
			for(int i=0;i<db1.getdata().Tables["basicinfo"].Rows.Count;i++)
			{
				this.DropDownList4.Items.Add(new ListItem(db1.getdata().Tables["basicinfo"].Rows[i]["�豸���"].ToString()));
			}
			sql="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			db1.cleardata();
			db1.ExectueSQL("ά��",sql);
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
			this.DataGrid1.DataBind();
			
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			this.Hidden1.Value="1";
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string sql="select * from ά�� where ʵ������='"+this.DropDownList3.SelectedValue.Trim()+"'";
			
			sql+=" and �豸���='"+this.DropDownList4.SelectedValue.Trim()+"'";
			db1.cleardata();
			db1.ExectueSQL("ά��",sql);
			this.DataGrid1.CurrentPageIndex=0;
			this.DataGrid1.DataSource=db1.getdata();
			this.DataGrid1.DataMember="ά��";
			this.DataGrid1.DataKeyField="����id";
			this.DataGrid1.DataBind();
			
			if(this.DataGrid1.CurrentPageIndex==this.DataGrid1.PageCount-1)
				this.Button4.Enabled=false;
			else
				this.Button4.Enabled=true;
			if(this.DataGrid1.CurrentPageIndex==0)
				this.Button3.Enabled=false;
			else
				this.Button3.Enabled=true;
			this.Hidden1.Value="2";
		}

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem||e.Item.ItemType==ListItemType.EditItem)
			{
				((LinkButton)e.Item.Cells[e.Item.Cells.Count-1].Controls[0]).Attributes.Add("onclick","return confirm('ȷ��ɾ����');");
			}

		}
	}
}
