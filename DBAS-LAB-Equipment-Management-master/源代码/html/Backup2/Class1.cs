using System;

namespace html
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class Class1
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;  //��ʾsql server���ݿ��һ���򿪵�����
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;  //��ʾ�������System.Data.DataSet�͸���SQL Server��һ�����ݿ���������ݿ����ӡ�
		protected System.Data.DataSet dataSet11;  //��ʾ�������ڴ��еĻ��档
		public Class1()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			string sqlconn; 
			sqlconn="server=4CJF-ZUOYE;uid=db1;pwd=123;database=jfgl";
			this.sqlConnection1=new System.Data.SqlClient.SqlConnection(sqlconn);
            this.sqlDataAdapter1=new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1.SelectCommand=new System.Data.SqlClient.SqlCommand();
			this.dataSet11=new System.Data.DataSet();
		}
		public void ExectueSQL(string tb,string sql)   //ִ��SQL���
		{
			this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
			this.sqlDataAdapter1.SelectCommand.CommandText=sql;
			this.sqlConnection1.Open();  //�����ݿ����ӡ�
			this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();  //������ִ��T-SQL��䲢������Ӱ��ĺ�����
			this.sqlConnection1.Close(); //�ر������ݿ�����ӡ�

			if(tb!="")
			this.sqlDataAdapter1.Fill(this.dataSet11,tb);
		}
		public void cleardata()    //�����¼��
		{
			this.dataSet11.Clear();  //ͨ���Ƴ����б��е����������������System.Data.DataSet.
		}
		public System.Data.DataSet getdata()   //��ȡ��¼�����������ȡ������ԱDataSet�����Ա��뽨��һ������Ľ�ڿ���ȡ��
		{
			return this.dataSet11;  
		}
		public System.Data.SqlClient.SqlConnection getsql()
		{
			return this.sqlConnection1;
		}
	}
}
