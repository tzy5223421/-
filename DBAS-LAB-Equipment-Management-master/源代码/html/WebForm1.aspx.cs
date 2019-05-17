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
using C1.Web.C1WebChart;
using C1.Web.C1WebChartBase;
using C1.Win.C1Chart;

namespace html
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button Button1;
		protected html.DataSet1 dataSet11;
		protected C1.Web.C1WebChart.C1WebChart C1WebChart1;
		//protected WebService1.DataSet1 dataSet11;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				string sql="select * from sbname";
				this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
				this.sqlDataAdapter1.SelectCommand.CommandText=sql;
				this.sqlConnection1.Open();
				this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
				this.sqlConnection1.Close();

				this.dataSet11.Clear();
				this.sqlDataAdapter1.Fill(this.dataSet11,"sbname");

				for(int i=0;i<this.dataSet11.Tables["sbname"].Rows.Count;i++)
				{
					this.DropDownList1.Items.Add(new ListItem(this.dataSet11.Tables["sbname"].Rows[i]["�豸����"].ToString()));
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dataSet11 = new html.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ����id, �������� FROM changjia";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"559-BDAE3A45AA0\";packet size=4096;integrated security=SSPI;data s" +
				"ource=\"559-BDAE3A45AA0\";persist security info=False;initial catalog=jfgl";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO changjia(��������) VALUES (@��������); SELECT ����id, �������� FROM changjia WHERE " +
				"(����id = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.VarChar, 10, "��������"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE changjia SET �������� = @�������� WHERE (����id = @Original_����id) AND (�������� = @Origi" +
				"nal_�������� OR @Original_�������� IS NULL AND �������� IS NULL); SELECT ����id, �������� FROM cha" +
				"ngjia WHERE (����id = @����id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.VarChar, 10, "��������"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_��������", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "��������", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����id", System.Data.SqlDbType.Int, 4, "����id"));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM changjia WHERE (����id = @Original_����id) AND (�������� = @Original_�������� OR " +
				"@Original_�������� IS NULL AND �������� IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_����id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "����id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_��������", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "��������", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "changjia", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("����id", "����id"),
																																																				  new System.Data.Common.DataColumnMapping("��������", "��������")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// dataSet11
			// 
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			localhost.LinkList l=new localhost.LinkList();
			localhost.Service1 MyService=new localhost.Service1();
			
			l=MyService.Time(this.DropDownList1.SelectedValue.ToString());
			localhost.LNode n1=new localhost.LNode();
			localhost.LNode n2=new localhost.LNode();
			n2=n1=l.first.next;
			
			string sql="select * from changjia";
			this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
			this.sqlDataAdapter1.SelectCommand.CommandText=sql;
			this.sqlConnection1.Open();
			this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();

			this.dataSet11.Clear();
			this.sqlDataAdapter1.Fill(this.dataSet11,"changjia");
			
			int max=this.dataSet11.Tables["changjia"].Rows.Count;
			PointF [][]data=new PointF[max][];
			for(int i=0;i<max;i++)
				data[i]=new PointF[14];
			for(int i=max-1;i>=0;i--)
			{
				//n1=n2;
				for(int j=13;j>=0;j--)
				{
					data[i][j]=new PointF(j,float.Parse(n1.data));
					n1=n1.next;
				}
			}

			/*string s="";
			for(int i=0;i<max;i++)
				for(int j=0;j<14;j++)
					s+=data[i][j].ToString()+",";
			this.Label1.Text=s;*/

			C1WebChart1.Visible=true;
			//C1WebChart1.Header.Text="Chart ͷ";
			//C1WebChart1.Footer.Text="Chart β";
			//C1WebChart1.BackColor = Color.LightSteelBlue;
			//
			C1WebChart1.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
			C1WebChart1.ImageRenderMethod = ImageRenderMethodEnum.HttpHandler;
			C1WebChart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.XYPlot;
			//C1WebChart1.Header.Visible= true;
			//C1WebChart1.Header.Text = "����ͼ";

			C1WebChart1.Legend.Visible = true;
			this.AddAxisX();  //X��
				
			//for(int i=0; i < 1; i++) //�����˫��,����ʾ
			//{
			//ChartDataSeries series = C1WebChart1.ChartGroups[0].ChartData.SeriesList[0];
			//series.PointData.CopyDataIn(data);// �����data��PointF����
			//series.FitType = C1.Win.C1Chart.FitTypeEnum.Spline;
			//}
			ChartDataSeriesCollection dscoll = C1WebChart1.ChartGroups[0].ChartData.SeriesList;			

			dscoll.Clear();
			for(int i=0; i < max; i++)
			{
				ChartDataSeries series = dscoll.AddNewSeries();
				series.PointData.Length = 10;
				series.PointData.CopyDataIn(data[i]);// �����data��PointF����
				series.LineStyle.Thickness = 1;
				/*ChartDataSeries series1 = dscoll.AddNewSeries();
				series1.PointData.Length = 10;
				series1.PointData.CopyDataIn(data1);// �����data��PointF����
				series1.LineStyle.Thickness = 1;*/
			}
			for(int i=0;i<max;i++)
			{
				C1WebChart1.ChartGroups[0].ChartData.SeriesList[i].Label=this.dataSet11.Tables["changjia"].Rows[i]["��������"].ToString();
			}
			//C1WebChart1.ChartGroups[0].ChartData.SeriesList[1].Label="2����";
			/*C1WebChart1.ChartGroups[0].ChartData.SeriesList[2].Label="3Ч��";
			C1WebChart1.ChartGroups[0].ChartData.SeriesList[3].Label="4Ч��";*/
			
			
			//C1WebChart1.ChartArea.PlotArea.GradientStyle=C1.Win.C1Chart.GradientStyleEnum.VerticalCenter;
			//this.CRM_Operater_xisX();  //X��


			//this.CRM_Operater_xisY();  //Y��
			//this.CRM_Operater_xisX();  //X��
			//CRM_AddY_Value();
			
		}
		public void AddAxisX()
		{
			
			
			// label x axis with product names
			Axis ax = C1WebChart1.ChartArea.AxisX;
			ax.ValueLabels.Clear();
			
			
			ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;
			DateTime dt=DateTime.Now;
			int month1=dt.Month;
			int month=month1;
			for(int i = 0; i < 12; i++)
			{
				//DataRowView drv = dv[i];
				month=month1+i;
				if(month>12)
					month=month-12;
				ax.ValueLabels.Add(i, (month).ToString()+"��");
			}
			ax.ValueLabels.Add(12,"����");
			ax.ValueLabels.Add(13,"����");
			try
			{
				//ax.Max = 10 - .5;
			}
			catch {}
			
		}

	}
}
