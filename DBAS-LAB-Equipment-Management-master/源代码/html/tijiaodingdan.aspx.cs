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
	/// tijiaodingdan ��ժҪ˵����
	/// </summary>
	public class tijiaodingdan : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Table Table4;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Data.DataSet dataSet1;
		protected System.Data.DataSet dataSet2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.DataSet dataSet3;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.DataSet dataSet4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string name=Session["name"].ToString();
			this.Label1.Text=name;

			string sql1="select * from �û� where �û���='";
			sql1+=name;
			
			sql1+="'";
			this.sqlDataAdapter2.SelectCommand.CommandText=sql1;
			this.sqlDataAdapter2.SelectCommand.Connection=this.sqlConnection1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter2.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();

			this.dataSet2.Clear();
			this.sqlDataAdapter2.Fill(this.dataSet2);
			this.Label2.Text=this.dataSet2.Tables["�û�"].Rows[0]["�û�����"].ToString();
			this.Label3.Text=this.dataSet2.Tables["�û�"].Rows[0]["�Ա�"].ToString();
			this.Label4.Text=this.dataSet2.Tables["�û�"].Rows[0]["����"].ToString();
			this.Label5.Text=this.dataSet2.Tables["�û�"].Rows[0]["�ֻ���"].ToString();
			this.Label6.Text=this.dataSet2.Tables["�û�"].Rows[0]["����"].ToString();
			this.Label7.Text=this.dataSet2.Tables["�û�"].Rows[0]["סַ"].ToString();
			
			string sql="select * from ������ϸ where �û�ID=";
			sql+=this.dataSet2.Tables["�û�"].Rows[0]["�û�ID"].ToString();
			sql+=" and ������=27";

			this.sqlDataAdapter1.SelectCommand.CommandText=sql;
			this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();

			this.dataSet1.Clear();
			this.sqlDataAdapter1.Fill(this.dataSet1);
			
			for(int i=0;i<this.dataSet1.Tables["������ϸ"].Rows.Count;i++)
			{
				TableRow row=new TableRow();
				TableCell cell1=new TableCell();
				string sql2="select �������� from ������ where �����="+this.dataSet1.Tables["������ϸ"].Rows[i]["�����"].ToString();
				this.sqlDataAdapter3.SelectCommand.CommandText=sql2;
				this.sqlDataAdapter3.SelectCommand.Connection=this.sqlConnection1;
				this.sqlConnection1.Open();
				this.sqlDataAdapter3.SelectCommand.ExecuteNonQuery();
				this.sqlConnection1.Close();

				this.dataSet3.Clear();
				this.sqlDataAdapter3.Fill(this.dataSet3);
				cell1.Text=this.dataSet3.Tables["������"].Rows[0]["��������"].ToString();
				row.Cells.Add(cell1);

				TableCell cell2=new TableCell();
				cell2.Text=this.dataSet1.Tables["������ϸ"].Rows[i]["����"].ToString();
				row.Cells.Add(cell2);

				TableCell cell3=new TableCell();
				cell3.Text=this.dataSet1.Tables["������ϸ"].Rows[i]["��������"].ToString();
				row.Cells.Add(cell3);

				TableCell cell4=new TableCell();
				cell4.Text=this.dataSet1.Tables["������ϸ"].Rows[i]["���"].ToString();
				row.Cells.Add(cell4);
				this.Table4.Rows.Add(row);

				double num=0;
				for(int j=0;j<this.dataSet1.Tables["������ϸ"].Rows.Count;j++)
				{
					num=num+Convert.ToInt32(this.dataSet1.Tables["������ϸ"].Rows[j]["���"]);
				}
				this.Label10.Text=num.ToString();
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dataSet1 = new System.Data.DataSet();
			this.dataSet2 = new System.Data.DataSet();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.dataSet3 = new System.Data.DataSet();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.dataSet4 = new System.Data.DataSet();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "������ϸ", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("������", "������"),
																																																			  new System.Data.Common.DataColumnMapping("�����", "�����"),
																																																			  new System.Data.Common.DataColumnMapping("����", "����"),
																																																			  new System.Data.Common.DataColumnMapping("��������", "��������"),
																																																			  new System.Data.Common.DataColumnMapping("���", "���"),
																																																			  new System.Data.Common.DataColumnMapping("�û�ID", "�û�ID")})});
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO ������ϸ(������, �����, ����, ��������, ���, �û�ID) VALUES (@������, @�����, @����, @��������, @��" +
				"��, @�û�ID); SELECT ������, �����, ����, ��������, ���, �û�ID FROM ������ϸ";
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.BigInt, 8, "������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.BigInt, 8, "�����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.Int, 4, "����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.DateTime, 8, "��������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@���", System.Data.SqlDbType.Money, 8, "���"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�û�ID", System.Data.SqlDbType.BigInt, 8, "�û�ID"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ������, �����, ����, ��������, ���, �û�ID FROM ������ϸ";
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "�û�", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("�û���", "�û���"),
																																																			new System.Data.Common.DataColumnMapping("�û�����", "�û�����"),
																																																			new System.Data.Common.DataColumnMapping("�Ա�", "�Ա�"),
																																																			new System.Data.Common.DataColumnMapping("��ʵ����", "��ʵ����"),
																																																			new System.Data.Common.DataColumnMapping("����", "����"),
																																																			new System.Data.Common.DataColumnMapping("סַ", "סַ"),
																																																			new System.Data.Common.DataColumnMapping("�ֻ���", "�ֻ���"),
																																																			new System.Data.Common.DataColumnMapping("����", "����")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT �û���, �û�����, �Ա�, ��ʵ����, ����, סַ, �ֻ���, ���� FROM �û�";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// dataSet2
			// 
			this.dataSet2.DataSetName = "NewDataSet";
			this.dataSet2.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT �������ͺ�1, �������ͺ�2, �����, ��������, ����, ����, �����, ���� FROM ������";
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO ������(�������ͺ�1, �������ͺ�2, ��������, ����, ����, �����, ����) VALUES (@�������ͺ�1, @�������ͺ�2," +
				" @��������, @����, @����, @�����, @����); SELECT �������ͺ�1, �������ͺ�2, �����, ��������, ����, ����, �����, ���� " +
				"FROM ������ WHERE (����� = @@IDENTITY)";
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������ͺ�1", System.Data.SqlDbType.BigInt, 8, "�������ͺ�1"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������ͺ�2", System.Data.SqlDbType.BigInt, 8, "�������ͺ�2"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.VarChar, 20, "��������"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.BigInt, 8, "����"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.Money, 8, "����"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.Int, 4, "�����"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.VarChar, 1000, "����"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE ������ SET �������ͺ�1 = @�������ͺ�1, �������ͺ�2 = @�������ͺ�2, �������� = @��������, ���� = @����, ���� = @����, ����� = @�����, ���� = @���� WHERE (����� = @Original_�����) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (����� = @Original_����� OR @Original_����� IS NULL AND ����� IS NULL) AND (�������� = @Original_��������) AND (�������ͺ�1 = @Original_�������ͺ�1) AND (�������ͺ�2 = @Original_�������ͺ�2); SELECT �������ͺ�1, �������ͺ�2, �����, ��������, ����, ����, �����, ���� FROM ������ WHERE (����� = @�����)";
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������ͺ�1", System.Data.SqlDbType.BigInt, 8, "�������ͺ�1"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������ͺ�2", System.Data.SqlDbType.BigInt, 8, "�������ͺ�2"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.VarChar, 20, "��������"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.BigInt, 8, "����"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.Money, 8, "����"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.Int, 4, "�����"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.VarChar, 1000, "����"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�����", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�����", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_��������", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "��������", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�������ͺ�1", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�������ͺ�1", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�������ͺ�2", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�������ͺ�2", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.BigInt, 8, "�����"));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM ������ WHERE (����� = @Original_�����) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (���� = @Original_���� OR @Original_���� IS NULL AND ���� IS NULL) AND (����� = @Original_����� OR @Original_����� IS NULL AND ����� IS NULL) AND (�������� = @Original_��������) AND (�������ͺ�1 = @Original_�������ͺ�1) AND (�������ͺ�2 = @Original_�������ͺ�2)";
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�����", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�����", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_��������", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "��������", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�������ͺ�1", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�������ͺ�1", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�������ͺ�2", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�������ͺ�2", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "������", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("�������ͺ�1", "�������ͺ�1"),
																																																			  new System.Data.Common.DataColumnMapping("�������ͺ�2", "�������ͺ�2"),
																																																			  new System.Data.Common.DataColumnMapping("�����", "�����"),
																																																			  new System.Data.Common.DataColumnMapping("��������", "��������"),
																																																			  new System.Data.Common.DataColumnMapping("����", "����"),
																																																			  new System.Data.Common.DataColumnMapping("����", "����"),
																																																			  new System.Data.Common.DataColumnMapping("�����", "�����"),
																																																			  new System.Data.Common.DataColumnMapping("����", "����")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// dataSet3
			// 
			this.dataSet3.DataSetName = "NewDataSet";
			this.dataSet3.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "INSERT INTO\r\n    ����(\r\n        �û�ID, \r\n        ����, \r\n        ������\r\n    )\r\nVALUES(\r\n" +
				"    , \r\n    \r\n)\r\n";
			// 
			// dataSet4
			// 
			this.dataSet4.DataSetName = "NewDataSet";
			this.dataSet4.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT �û�ID, ����, ������ FROM ����";
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO ����(�û�ID, ����) VALUES (@�û�ID, @����); SELECT �û�ID, ����, ������ FROM ���� WHERE " +
				"(������ = @@IDENTITY)";
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�û�ID", System.Data.SqlDbType.BigInt, 8, "�û�ID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.DateTime, 4, "����"));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE ���� SET �û�ID = @�û�ID, ���� = @���� WHERE (������ = @Original_������) AND (���� = @Origi" +
				"nal_����) AND (�û�ID = @Original_�û�ID); SELECT �û�ID, ����, ������ FROM ���� WHERE (������ = @" +
				"������)";
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�û�ID", System.Data.SqlDbType.BigInt, 8, "�û�ID"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.DateTime, 4, "����"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_������", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "������", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�û�ID", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�û�ID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.BigInt, 8, "������"));
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM ���� WHERE (������ = @Original_������) AND (���� = @Original_����) AND (�û�ID = @O" +
				"riginal_�û�ID)";
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_������", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "������", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_�û�ID", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "�û�ID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter5.InsertCommand = this.sqlInsertCommand3;
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "����", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("�û�ID", "�û�ID"),
																																																			new System.Data.Common.DataColumnMapping("����", "����"),
																																																			new System.Data.Common.DataColumnMapping("������", "������")})});
			this.sqlDataAdapter5.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=BDA852BA3F45426;packet size=4096;integrated security=SSPI;data sou" +
				"rce=BDA852BA3F45426;persist security info=True;initial catalog=gouwu";
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			double num=0;
			for(int i=0;i<this.dataSet1.Tables["������ϸ"].Rows.Count;i++)
			{
				num=num+Convert.ToInt32(this.dataSet1.Tables["������ϸ"].Rows[i]["���"]);
			}

			string time=DateTime.Now.ToString();
			string sql="insert into ����(�û�ID,����,�ܽ��,�Ѹ���) values("+this.dataSet1.Tables["������ϸ"].Rows[0]["�û�ID"].ToString()+",'"+
				time+"',"+num+",'δ����')";
			this.sqlDataAdapter4.SelectCommand.CommandText=sql;
			this.sqlDataAdapter4.SelectCommand.Connection=this.sqlConnection1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter4.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();


			string sql1="select ������ from ���� where ����='"+time+"' and �û�ID="+this.dataSet1.Tables["������ϸ"].Rows[0]["�û�ID"].ToString();
			this.sqlDataAdapter5.SelectCommand.CommandText=sql1;
			this.sqlDataAdapter5.SelectCommand.Connection=this.sqlConnection1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter5.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();

			
			this.sqlDataAdapter5.Fill(this.dataSet4);

			string sql2="update ������ϸ set ������="+this.dataSet4.Tables["����"].Rows[0]["������"].ToString()+" where ������=27";
			this.sqlDataAdapter1.SelectCommand.CommandText=sql2;
			this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();
			Response.Write("<script>alert('���Ѿ������˱��ι���Ķ���');</script>");
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("yonghu.asp?name11="+Request.QueryString["name11"]+"&pwd1="+Request.QueryString["pwd1"]);
		}
	}
}
