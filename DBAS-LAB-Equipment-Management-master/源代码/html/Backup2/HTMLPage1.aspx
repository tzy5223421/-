<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Page language="c#" Codebehind="HTMLPage1.aspx.cs" AutoEventWireup="false" Inherits="html.HTMLPage1" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HTMLPage1</title>
		<SCRIPT language="javascript">
	<!-- 
		var lastSelectedIndex = -1;
		function switchstatus(itemName){
			var item = document.getElementById('Item' + itemName);
			//alert('Item' + itemName);
			
			if (item.style.display=='none'){
				item.style.display = '';
			}else{
				item.style.display = 'none';
			}
			if (lastSelectedIndex != -1) 
			{
				var lastSelectedItem = document.getElementById('Item' + lastSelectedIndex);
				if (itemName != lastSelectedIndex) lastSelectedItem.style.display = 'none';
			}
			lastSelectedIndex = itemName;
		}
	-->
		</SCRIPT>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="css/normal.css" rel="stylesheet" type="text/css">
		<style type="text/css"> 
		.STYLE1 { FONT-FAMILY: "����" } 
		BODY { BACKGROUND-IMAGE: url(img/blank.gif); MARGIN: 0px } 
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT>
			<table width="152" height="562" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="152" valign="top" background="img/01.jpg"><table width="151" height="337" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="178" height="14" class="font2">
									<iewc:TreeView id="TreeView2" runat="server" Height="600px" BackColor="#F1F1F1" ShowLines="False"
										SelectExpands="True" ShowPlus="False" BorderStyle="Groove" BorderWidth="2px" CssClass="font2"
										Indent="13" Width="184px">
										<iewc:TreeNode Text="����Ա���" DefaultStyle="font-family:&quot;����&quot;;font-size:16px;color:#000066;font-weight:bold;"></iewc:TreeNode>
										<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="�����豸����" DefaultStyle="font-weight:bold;">
											<iewc:TreeNode NavigateUrl="Basicinfo.aspx" ImageUrl="img/dian_1.gif" Text="�����豸" Target="main">
												<iewc:TreeNode NavigateUrl="add3.aspx" ImageUrl="img/dian_11.gif" Text="�����豸��� " Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="piliang.aspx" ImageUrl="img/dian_11.gif" Text="�����豸���" Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="piliangxiugai.aspx" ImageUrl="img/dian_11.gif" Text="�����豸�޸�" Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="plliangdelete.aspx" ImageUrl="img/dian_11.gif" Text="�����豸ɾ��" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="changjia.aspx" ImageUrl="img/dian_1.gif" Text="��������" Target="main">
												<iewc:TreeNode NavigateUrl="add4.aspx" ImageUrl="img/dian_11.gif" Text="�����������" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Labname.aspx" ImageUrl="img/dian_1.gif" Text="ʵ��������" Target="main">
												<iewc:TreeNode NavigateUrl="add6.aspx" ImageUrl="img/dian_11.gif" Text="ʵ�����������" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="sbname.aspx" ImageUrl="img/dian_1.gif" Text="�豸����" Target="main">
												<iewc:TreeNode NavigateUrl="add7.aspx" ImageUrl="img/dian_11.gif" Text="�豸�������" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
										</iewc:TreeNode>
										<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="�����豸����" DefaultStyle="font-weight:bold;">
											<iewc:TreeNode NavigateUrl="sbgl.aspx" ImageUrl="img/dian_1.gif" Text="�����豸����" Target="main">
												<iewc:TreeNode NavigateUrl="add.aspx" ImageUrl="img/dian_11.gif" Text="�����豸���" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Errorinfo.aspx" ImageUrl="img/dian_1.gif" Text="��������" Target="main">
												<iewc:TreeNode NavigateUrl="add5.aspx" ImageUrl="img/dian_11.gif" Text="�����������" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
										</iewc:TreeNode>
										<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="�����ھ�" DefaultStyle="font-weight:bold;">
											<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="�������㷨">
												<iewc:TreeNode NavigateUrl="../WebService1/jueceshijian.aspx" ImageUrl="img/dian_11.gif" Text="�豸������Ԥ��"
													Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="../WebService1/shouming.aspx" ImageUrl="img/dian_11.gif" Text="����δ�����豸ά��"
													Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="../WebService1/piliangguzhang.aspx" ImageUrl="img/dian_11.gif" Text="����δ�����豸ά��"
													Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="../WebService1/yiyuceer.aspx" ImageUrl="img/dian_11.gif" Text="���޸��豸ά��Ԥ��"
													Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="../WebService1/shijianxulie.aspx" ImageUrl="img/dian_11.gif" Text="ʱ�������㷨"
												Target="main"></iewc:TreeNode>
										</iewc:TreeNode>
										<iewc:TreeNode NavigateUrl="Admin.aspx" ImageUrl="img/dian_1.gif" Text="����Ա��Ϣ" DefaultStyle="font-weight:bold;"
											Target="main">
											<iewc:TreeNode NavigateUrl="add8.aspx" ImageUrl="img/dian_11.gif" Text="��ӹ���Ա" Target="main"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Userid.aspx" ImageUrl="img/dian_11.gif" Text="����û���Ϣ" Target="main"></iewc:TreeNode>
										</iewc:TreeNode>
										<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="��ӡ����" DefaultStyle="font-weight:bold;">
											<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="��ӡ������Ϣ��">
												<iewc:TreeNode NavigateUrl="WebForm4.aspx" ImageUrl="img/dian_11.gif" Text="��ϸ������Ϣ����" Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="WebForm6.aspx" ImageUrl="img/dian_11.gif" Text="���ܻ�����Ϣ����" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
											<iewc:TreeNode ImageUrl="img/dian_1.gif" Text="��ӡά����">
												<iewc:TreeNode NavigateUrl="WebForm7.aspx" ImageUrl="img/dian_11.gif" Text="��ϸά����Ϣ����" Target="main"></iewc:TreeNode>
												<iewc:TreeNode NavigateUrl="WebForm5.aspx" ImageUrl="img/dian_11.gif" Text="����ά����Ϣ����" Target="main"></iewc:TreeNode>
											</iewc:TreeNode>
										</iewc:TreeNode>
										<iewc:TreeNode NavigateUrl="denglu.aspx" ImageUrl="img/dian_1.gif" Text="ע��" DefaultStyle="font-weight:bold;"
											Target="_parent"></iewc:TreeNode>
									</iewc:TreeView></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!-- <DIV style="Z-INDEX: 101; LEFT: 25px; POSITION: absolute; TOP: 31px; width: 100px;" ms_positioning="text2D">-->
			<p><A href="sbgl.aspx" target="main"></A><BR>
				<A href="Basicinfo.aspx" target="main"></A><font face="����">
					<BR>
					<A href="Admin.aspx" target="main"></A></font>
				<BR>
				<A href="Changjia.aspx" target="main"></A>
				<BR>
				<A href="Errorinfo.aspx" target="main"></A>
				<BR>
				<A href="Labname.aspx" target="main"></A><font face="����"><A href="Admin.aspx" target="main">
					</A></font>
				<BR>
				<A href="Sbname.aspx" target="main"></A>
				<BR>
				<A href="edit3.aspx" target="main"></A>
				<BR>
				<A href="denglu.aspx" target="_parent"></A>
			</p>
			<p><a href="add.aspx" target="main"></a></p>
			<!-- </DIV>-->
		</form>
	</body>
</HTML>
