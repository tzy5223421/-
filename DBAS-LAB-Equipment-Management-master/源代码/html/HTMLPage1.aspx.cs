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
	/// HTMLPage1 ��ժҪ˵����
	/// </summary>
	public class HTMLPage1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView2;
	
		Class1 db1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Session["name"]=Session["name"];
			Session["pwd"]=Session["pwd"];
			
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
			this.Unload += new System.EventHandler(this.HTMLPage1_Unload);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void HTMLPage1_Unload(object sender, System.EventArgs e)
		{
			//Session["name"]="";
			//Session["pwd"]="";
		}
	}
}
