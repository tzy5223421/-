using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;


namespace WebService1
{
	/// <summary>
	/// Service1 ��ժҪ˵����
	/// </summary>
	
	public class Service1 : System.Web.Services.WebService
	{
		public Service1()
		{
			//CODEGEN: �õ����� ASP.NET Web ����������������
			InitializeComponent();
		}
		//CSNode *p1;
		

		#region �����������ɵĴ���
		
		//Web ����������������
		private IContainer components = null;
				
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB ����ʾ��
		// HelloWorld() ʾ�����񷵻��ַ��� Hello World
		// ��Ҫ���ɣ���ȡ��ע�������У�Ȼ�󱣴沢������Ŀ
		// ��Ҫ���Դ� Web �����밴 F5 ��

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}
		
		
		public CSNode CreateTree()
		{
			//DateTime d1=DateTime.Parse(start);
			//DateTime d2=DateTime.Parse(end);
			CSNode n1=new CSNode();
			CSNode n2=new CSNode();
			
			Class1 db1=new Class1();
			n1=n1.SetData("���");
			CSNode n3=new CSNode();
			/*this.n2=n3.SetData("��ϲ");
			this.n1.AddChild(this.n2);
			n3=new CSNode();
			n3=n3.SetData("�廪ͬ��");
			this.n2=this.n2.AddSibling(n3);

			n3=new CSNode();
			n3=n3.SetData("����");
			this.n2=this.n2.GetSibling();
			this.n2=this.n2.AddSibling(n3);*/
			string sql;
			sql="select * from sbname";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql);

			for(int i=0;i<db1.getdata().Tables["sbname"].Rows.Count;i++)
			{
				n3=new CSNode();
				n3=n3.SetData(db1.getdata().Tables["sbname"].Rows[i]["�豸����"].ToString());
				if(i==0)
				{
					n1.AddChild(n3);
					n2=n1.GetChild();
				}
				else
				{
					n2.AddSibling(n3);
					n2=n2.GetSibling();
				}
			}

			sql="select * from changjia";
			db1.cleardata();
			db1.ExectueSQL("changjia",sql);

			n2=n1.GetChild();
			CSNode n4=new CSNode();
			CSNode n5=new CSNode();
			while(n2!=null)
			{
				for(int i=0;i<db1.getdata().Tables["changjia"].Rows.Count;i++)
				{
					n4=new CSNode();
					n5=new CSNode();
					n5=n5.SetData("0");
					n4=n4.SetData(db1.getdata().Tables["changjia"].Rows[i]["��������"].ToString());
					n4=n4.AddChild(n5);
					if(i==0)
					{
						n2.AddChild(n4);
						n3=n2.GetChild();
					}
					else if(i==1)
						n3.AddSibling(n4);
					else
					{
						n3=n3.GetSibling();
						n3.AddSibling(n4);
					}
				}
				n2=n2.GetSibling();
			}

			return n1;
		}
		[WebMethod]
		public string guzhangtime(string sb,string cj)
		{
			string s;
			CSNode n1=new CSNode();
			CSNode n2=new CSNode();
			CSNode n3=new CSNode();
			CSNode n4=new CSNode();
			Class1 db1=new Class1();
			Class1 db2=new Class1();
			n1=CreateTree();
			n2=n1.GetChild();
			string sql="select * from info where �豸id is not null order by �豸id,�Ǽ�����";
			db1.cleardata();
			db1.ExectueSQL("info",sql);

			int num1=0;
			string sbid="";
			sbid=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			for(int i=0;i<db1.getdata().Tables["info"].Rows.Count;i++)
			{
				string sbid1=db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				if(i!=0&&sbid1==sbid)
					continue;
				sql="select * from basicinfo where �豸id="+db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				db2.cleardata();
				db2.ExectueSQL("basicinfo",sql);

				sql="select * from changjia where ����id="+db2.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				db2.ExectueSQL("changjia",sql);

				sql="select * from sbname where �豸����id="+db2.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
				db2.ExectueSQL("sbname",sql);

				n4=Traverse1(n2,db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim());
				n4=n4.GetChild();
				n3=Traverse1(n4,db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim());
				n3=n3.GetChild();
				/*DateTime dt1=DateTime.Parse(db1.getdata().Tables["info"].Rows[i]["�Ǽ�����"].ToString());
				DateTime dt2=DateTime.Parse(db2.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString());
				int year=dt1.Year-dt2.Year;
				int month=dt1.Month-dt2.Month;
				int day=dt1.Day-dt2.Day;*/
				
				int num=Int32.Parse(n3.GetData().ToString());
				TimeSpan t=DateTime.Parse(db1.getdata().Tables["info"].Rows[i]["�Ǽ�����"].ToString())-DateTime.Parse(db2.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString());

				num=num+Int32.Parse(t.TotalDays.ToString());

				n3=n3.SetData(num.ToString());
				if(db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim()==sb.Trim()&&db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim()==cj.Trim())
					num1++;
				sbid=db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
			}
			//s=Traverse1(this.n2,"��ϲ");
			
			n2=this.Traverse1(n2,sb);
			n2=n2.GetChild();

			n2=Traverse1(n2,cj);
			if(num1!=0)
			{
				int pass=Int32.Parse(n2.GetChild().GetData())/num1;
				int year=pass/365;
				int month=(pass%365)/31;
				int day=pass-year*365-month*31;
				s=year.ToString()+"��"+month.ToString()+"��"+day.ToString()+"��";
			}
			else
				s="";
			//s=bit.ToString();
			return s;

		}
		[WebMethod]
		public string gzttwo(string sb,string cj,string cishu)
		{
			string s;
			CSNode n1=new CSNode();
			CSNode n2=new CSNode();
			CSNode n3=new CSNode();
			CSNode n4=new CSNode();
			Class1 db1=new Class1();
			Class1 db2=new Class1();
			n1=CreateTree();
			n2=n1.GetChild();
			string sql="select * from info where �豸id in (select �豸id from info group by �豸id having count(*)>"+cishu+") order by �豸id,�Ǽ�����";

			db1.cleardata();
			db1.ExectueSQL("info",sql);

			int num1=0;
			int num2=0;
			DateTime t2=new DateTime(1900,1,1);
			string sbid="";
			string sbid1="";
			sbid=db1.getdata().Tables["info"].Rows[0]["�豸id"].ToString();
			for(int i=0;i<db1.getdata().Tables["info"].Rows.Count;i++)
			{
				sbid1=db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				if(sbid!=sbid1)
				{
					num2=0;
					sbid=db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				}
				num2++;
				
				if(num2==Int32.Parse(cishu))
					t2=DateTime.Parse(db1.getdata().Tables["info"].Rows[i]["�Ǽ�����"].ToString());
				if(num2!=Int32.Parse(cishu)+1)
					continue;
				sql="select * from basicinfo where �豸id="+db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				db2.cleardata();
				db2.ExectueSQL("basicinfo",sql);

				sql="select * from changjia where ����id="+db2.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				db2.ExectueSQL("changjia",sql);

				sql="select * from sbname where �豸����id="+db2.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
				db2.ExectueSQL("sbname",sql);

				n4=Traverse1(n2,db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim());
				n4=n4.GetChild();
				n3=Traverse1(n4,db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim());
				n3=n3.GetChild();
				/*DateTime dt1=DateTime.Parse(db1.getdata().Tables["info"].Rows[i]["�Ǽ�����"].ToString());
				DateTime dt2=DateTime.Parse(db2.getdata().Tables["basicinfo"].Rows[0]["��������"].ToString());
				int year=dt1.Year-dt2.Year;
				int month=dt1.Month-dt2.Month;
				int day=dt1.Day-dt2.Day;*/
				
				int num=Int32.Parse(n3.GetData().ToString());
				TimeSpan t=DateTime.Parse(db1.getdata().Tables["info"].Rows[i]["�Ǽ�����"].ToString())-t2;

				num=num+Int32.Parse(t.TotalDays.ToString());

				n3=n3.SetData(num.ToString());
				if(db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim()==sb.Trim()&&db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim()==cj.Trim())
					num1++;
			}
			//s=Traverse1(this.n2,"��ϲ");
			
			n2=this.Traverse1(n2,sb);
			n2=n2.GetChild();

			n2=Traverse1(n2,cj);
			if(num1!=0)
			{
				int pass=Int32.Parse(n2.GetChild().GetData())/num1;
				int year=pass/365;
				int month=(pass%365)/31;
				int day=pass-year*365-month*31;
				s=year.ToString()+"��"+month.ToString()+"��"+day.ToString()+"��";
			}
			else
				s="";
			//s=bit.ToString();
			return s;

		}
		[WebMethod]
		public string guzhanglv(string sb,string start,string end)
		{
			string s;
			CSNode n1=new CSNode();
			CSNode n2=new CSNode();
			CSNode n3=new CSNode();
			CSNode n4=new CSNode();
			Class1 db1=new Class1();
			Class1 db2=new Class1();
			n1=CreateTree();
			n2=n1.GetChild();
			string sql="select �豸id from info where �Ǽ����� between '"+start+"' and '"+end+"' and �豸id is not null";
			db1.cleardata();
			db1.ExectueSQL("info",sql);

			int num1=0;
			for(int i=0;i<db1.getdata().Tables["info"].Rows.Count;i++)
			{
				sql="select * from basicinfo where �豸id="+db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				db2.cleardata();
				db2.ExectueSQL("basicinfo",sql);

				sql="select * from changjia where ����id="+db2.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				db2.ExectueSQL("changjia",sql);

				sql="select * from sbname where �豸����id="+db2.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
				db2.ExectueSQL("sbname",sql);

				if(db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim()==sb)
					num1++;
				n4=Traverse1(n2,db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim());
				n4=n4.GetChild();
				n3=Traverse1(n4,db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim());
				n3=n3.GetChild();
				int num=Int32.Parse(n3.GetData().ToString());
				num++;
				n3=n3.SetData(num.ToString());
			}
			//s=Traverse1(this.n2,"��ϲ");
			
			n2=this.Traverse1(n2,sb);
			n2=n2.GetChild();
			//this.n2=this.Traverse1(this.n2,cj);
			//this.n2=this.n2.GetChild();

			/*sql="select * from basicinfo where �豸����id=";
			string sql1="select * from sbname where �豸����='"+sb+"'";
			db1.cleardata();
			db1.ExectueSQL("sbname",sql1);

			sql+=db1.getdata().Tables["sbname"].Rows[0]["�豸����id"].ToString();
			//sql+=" and ����id=";
					
			/*sql1="select * from changjia where ��������='"+cj+"'";
			this.sqlDataAdapter1.SelectCommand.Connection=this.sqlConnection1;
			this.sqlDataAdapter1.SelectCommand.CommandText=sql1;
			this.sqlConnection1.Open();
			this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
			this.sqlConnection1.Close();

			this.dataSet11.Clear();
			this.sqlDataAdapter1.Fill(this.dataSet11,"changjia");

			sql+=this.dataSet11.Tables["changjia"].Rows[0]["����id"].ToString();

			db1.cleardata();
			db1.ExectueSQL("basicinfo",sql);*/

			double bit=0.0;
			s="";
			if(num1!=0)
			{
				while(n2!=null)
				{
					s+=n2.GetData()+":";
					bit=Double.Parse(n2.GetChild().GetData().ToString())/num1*100.0;
					s+=string.Format("{0:F2}",bit)+"%\n";
					n2=n2.GetSibling();
				}
			}
			else
				bit=0.0;
			//s=bit.ToString();
			return s;
		}
		[WebMethod]
		public string bilv(string sb,string start,string end)
		{
			string s;
			CSNode n1=new CSNode();
			CSNode n2=new CSNode();
			CSNode n3=new CSNode();
			CSNode n4=new CSNode();
			Class1 db1=new Class1();
			Class1 db2=new Class1();
			n1=CreateTree();
			n2=n1.GetChild();
			string sql="select distinct �豸id from info where �Ǽ����� between '"+start+"' and '"+end+"' and �豸id is not null";
			db1.cleardata();
			db1.ExectueSQL("info",sql);

			int num1=0;
			for(int i=0;i<db1.getdata().Tables["info"].Rows.Count;i++)
			{
				sql="select * from basicinfo where �豸id="+db1.getdata().Tables["info"].Rows[i]["�豸id"].ToString();
				db2.cleardata();
				db2.ExectueSQL("basicinfo",sql);

				sql="select * from changjia where ����id="+db2.getdata().Tables["basicinfo"].Rows[0]["����id"].ToString();
				db2.ExectueSQL("changjia",sql);

				sql="select * from sbname where �豸����id="+db2.getdata().Tables["basicinfo"].Rows[0]["�豸����id"].ToString();
				db2.ExectueSQL("sbname",sql);

				if(db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim()==sb)
					num1++;
				n4=Traverse1(n2,db2.getdata().Tables["sbname"].Rows[0]["�豸����"].ToString().Trim());
				n4=n4.GetChild();
				n3=Traverse1(n4,db2.getdata().Tables["changjia"].Rows[0]["��������"].ToString().Trim());
				n3=n3.GetChild();
				int num=Int32.Parse(n3.GetData().ToString());
				num++;
				n3=n3.SetData(num.ToString());
			}
			//s=Traverse1(this.n2,"��ϲ");
			
			n2=this.Traverse1(n2,sb);
			n2=n2.GetChild();

			double bit=0.0;
			s="";

			while(n2!=null)
			{
				sql="select * from ������Ϣ where ��������='"+n2.GetData()+"'";
				sql+=" and �豸����='"+sb+"'";
				db1.cleardata();
				db1.ExectueSQL("changjia",sql);

				s+=n2.GetData()+":";
				num1=db1.getdata().Tables["changjia"].Rows.Count;
				if(num1!=0)
                    bit=float.Parse(n2.GetChild().GetData().ToString())/num1*100.0;
				else
					bit=0.0;
				
				s+=String.Format("{0:F2}",bit)+"%\n";
				n2=n2.GetSibling();
			}
			//s=bit.ToString();
			return s;
		}
		//[WebMethod]
		public CSNode Traverse1(CSNode n1,String e)
		{
			if(n1!=null)
			{
				while(n1.GetData().Trim()!=e.Trim()&&n1.GetSibling()!=null)
				{
					//this.label1.Text=this.n1.GetData().ToString();
					n1=n1.GetSibling();
				}
			}
			if(n1.GetData().Trim()==e.Trim())
			return n1;
			else
				return null;
		}
		[WebMethod]
		public LinkList Time(string sb)
		{
			Class1 db1=new Class1();
			LinkList l=new LinkList();
			DateTime dt=DateTime.Now;
			int year=Int32.Parse(dt.Year.ToString())-1;
			int month=Int32.Parse(dt.Month.ToString());
			int num=0;
			string sql="select * from changjia";
			db1.cleardata();
			db1.ExectueSQL("changjia",sql);

			int max=db1.getdata().Tables["changjia"].Rows.Count;
			string []cjname=new string[max];
            
			for(int i=0;i<max;i++)
			{
				cjname[i]=db1.getdata().Tables["changjia"].Rows[i]["��������"].ToString();
			}
			
			int month1=month;
			int year1=year;
			bool ifadd=false;
			int num1=0;
			int first=0;

			for(int i=0;i<max;i++)
			{
				year=year1;
				ifadd=false;
				num1=0;
				for(int j=0;j<12;j++)
				{
					num=0;
					
					month=month1+j;
					if(month>12)
					{
						month=month-12;
						if(!ifadd)
						{
							year=year+1;
							ifadd=true;
						}
					}
					string date1;
					string date=year.ToString()+"-"+month.ToString()+"-1";
					if(month==1||month==3||month==5||month==7||month==8||month==10||month==12)
						date1=year.ToString()+"-"+month.ToString()+"-31";
					else if(month==4||month==6||month==9||month==11)
						date1=year.ToString()+"-"+month.ToString()+"-30";
					else if((year%4==0&&year%100!=0)||(year%400==0))
						date1=year.ToString()+"-"+month.ToString()+"-29";
					else
						date1=year.ToString()+"-"+month.ToString()+"-28";
					sql="select * from ά�� where �Ǽ����� between '"+date+"' and '"+date1+"' and �豸����='"+sb+"' and ��������='"+cjname[i].Trim()+"'";
					db1.cleardata();
					db1.ExectueSQL("ά��",sql);

					if(db1.getdata().Tables["ά��"].Rows.Count!=0)
						num=db1.getdata().Tables["ά��"].Rows.Count;
					if(j==6)
						first=num;
					if(j>=6)
					num1+=num;
					LNode p=new LNode();
					p.SetData(num.ToString());
					l=l.Add(p);
				}
				LNode p1=new LNode();
				p1.SetData((num1/6).ToString());
				l=l.Add(p1);
				p1=new LNode();
				p1.SetData(((num1-first+num1/6)/6).ToString());
				l=l.Add(p1);
			}
			return l;
		}

		
		
	}
	public class CSNode
	{
		String data;
		CSNode firstchild;
		CSNode nextsibling;

		public CSNode()
		{
			firstchild=null;
			nextsibling=null;
		}
		public CSNode AddChild(CSNode n2)
		{
			firstchild=n2;
			return this;
		}
		public CSNode AddSibling(CSNode n2)
		{
			nextsibling=n2;
			return this;
		}
		public CSNode SetData(String e)
		{
			data=e;
			return this;
		}
		public String GetData()
		{
			return this.data;
		}
		public CSNode GetChild()
		{
			return this.firstchild;
		}
		public CSNode GetSibling()
		{
			return this.nextsibling;
		}
	}
	public class LNode
	{
		public string data;
		public LNode next;
		public LNode()
		{}
		public LNode SetData(string e)
		{
			data=e;
			return this;
		}
		public string GetData()
		{
			return this.data;
		}
		public LNode GetNext()
		{
			return this.next;
		}
	}
	public class LinkList
	{
		public LNode first;
		public LinkList()
		{
			first=new LNode();
			first.data="";
			first.next=null;
		}
		public LinkList Add(LNode p)
		{
			p.next=first.next;
			first.next=p;
			return this;
		}
	}
}
