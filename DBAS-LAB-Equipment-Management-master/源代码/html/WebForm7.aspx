<%@ Page language="c#" Codebehind="WebForm7.aspx.cs" AutoEventWireup="false" Inherits="html.WebForm7" %>
<%@ Register TagPrefix="activereportsweb" Namespace="DataDynamics.ActiveReports.Web" Assembly="ActiveReports.Web, Version=3.0.0.1893, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm7</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">@import url( normal.css ); BODY { BACKGROUND-IMAGE: url(img/JDSJ029.jpg); MARGIN: 0px }
		</style>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE width="849" height="250" border="0" cellPadding="0" cellSpacing="0">
				<TR>
					<TD vAlign="middle" align="center" background="img/dl_bg.gif" height="30"><FONT size="5" face="����">ά����Ϣ����</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 177px" vAlign="top" height="177" align="left" class="lishu"><table width="88%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td align="center">
									<TABLE id="Table1" style="WIDTH: 704px; HEIGHT: 127px" cellSpacing="1" cellPadding="1"
										width="704" border="0">
										<TR>
											<TD style="WIDTH: 640px; HEIGHT: 35px" colSpan="4"><IMG height="18" src="img/dian.jpg" width="18"><SPAN class="font">��ʾѡ��ʵ����������ֹʱ�䣬��ʾ��ʵ���������ʱ��������ϵ��豸��Ϣ���������ΪExcel�ļ���</SPAN>
												</SPAN></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 55px; HEIGHT: 25px"></TD>
											<TD style="WIDTH: 80px; HEIGHT: 25px"><Font face="����">ʵ������</Font></TD>
											<TD style="HEIGHT: 25px">
												<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList></TD>
											<TD style="HEIGHT: 25px"><FONT face="����"></FONT></TD>
											<TD style="HEIGHT: 25px"><FONT face="����"></FONT></TD>
										</TR>
										<TR>
											<TD class="lishu" style="WIDTH: 55px"></TD>
											<TD class="lishu" style="WIDTH: 80px"><Font face="����"> ��ʼʱ��</Font></TD>
											<TD><FONT face="����">
													<asp:DropDownList id="DropDownList2" runat="server"></asp:DropDownList>��
													<asp:DropDownList id="DropDownList3" runat="server"></asp:DropDownList>��
													<asp:DropDownList id="DropDownList4" runat="server"></asp:DropDownList>��</FONT></TD>
											<TD><FONT face="����">
													<asp:Button id="Button2" runat="server" Text="������Ϣ"></asp:Button></FONT></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="lishu" style="WIDTH: 55px"></TD>
											<TD class="lishu" style="WIDTH: 80px"><Font face="����"> ��ֹʱ��</Font></TD>
											<TD><Font face="����">
													<asp:DropDownList id="DropDownList5" runat="server"></asp:DropDownList>��
													<asp:DropDownList id="DropDownList6" runat="server"></asp:DropDownList>��
													<asp:DropDownList id="DropDownList7" runat="server"></asp:DropDownList>��</Font></TD>
											<TD>
												<asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></TD>
											<TD>
												<asp:LinkButton id="LinkButton1" runat="server" Font-Names="����">���Ϊ</asp:LinkButton></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center"><table width="550" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="297" style="WIDTH: 253px">
												<ActiveReportsWeb:WebViewer id="WebViewer1" runat="server" BorderColor="LightGray" width="683px" height="990px"
													BackColor="Transparent" BorderStyle="Solid" ForeColor="Black"></ActiveReportsWeb:WebViewer></td>
											<td width="253" style="WIDTH: 227px">
											</td>
										</tr>
									</table>
									<INPUT id="Hidden1" type="hidden" name="Hidden1" runat="server">
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
