<%@ Page language="c#" Codebehind="add.aspx.cs" AutoEventWireup="false" Inherits="html.add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>add</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<style type="text/css">
@import url( css/normal.css ); BODY { BACKGROUND-IMAGE: url(img/JDSJ029.jpg) }
		</style>
	</HEAD>
	<body leftmargin="0" topmargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td valign="top"><table width="826" height="206" border="0" align="center" cellpadding="0" cellspacing="1"
							bgcolor="#ccccff" style="WIDTH: 826px; HEIGHT: 206px">
							<tr>
								<td height="36" colspan="4" align="center" valign="middle" bgcolor="#ffffff">&nbsp;<FONT size="5" face="����" class="font1">�����豸���</FONT></td>
							</tr>
							<tr>
								<td width="125" bgcolor="#ffffff" class="lishu" style="HEIGHT: 36px">&nbsp;&nbsp;&nbsp;<FONT face="����" size="4">�豸���</FONT>��</td>
								<td width="226" bgcolor="#ffffff" style="HEIGHT: 36px">&nbsp;
									<asp:DropDownList ID="DropDownList1" runat="server" Font-Names="����"></asp:DropDownList></td>
								<td width="135" bgcolor="#ffffff" class="lishu" style="HEIGHT: 36px">&nbsp;&nbsp;&nbsp;<FONT face="����" size="4">���ϲ���</FONT>��</td>
								<td width="335" bgcolor="#ffffff" style="HEIGHT: 36px">&nbsp;
									<asp:DropDownList id="DropDownList5" runat="server" Font-Names="����">
										<asp:ListItem Value="Ӳ��">Ӳ��</asp:ListItem>
										<asp:ListItem Value="���">���</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td height="31" bgcolor="#ffffff" class="lishu" style="HEIGHT: 31px">&nbsp;&nbsp;&nbsp;<FONT face="����" size="4">�豸����</FONT>��</td>
								<td bgcolor="#ffffff" style="HEIGHT: 31px">&nbsp;
									<asp:DropDownList id="DropDownList2" runat="server" Font-Names="����" AutoPostBack="True"></asp:DropDownList></td>
								<td bgcolor="#ffffff" style="HEIGHT: 31px">&nbsp; <span class="lishu"><FONT face="����" size="4">
											��������</FONT>��</span></td>
								<td bgcolor="#ffffff" style="HEIGHT: 31px">&nbsp;
									<asp:DropDownList id="DropDownList6" runat="server" Font-Names="����"></asp:DropDownList></td>
							</tr>
							<tr>
								<td height="35" bgcolor="#ffffff">&nbsp;<span class="lishu"><FONT face="����" size="4">&nbsp;ʵ��������</FONT>��</span></td>
								<td bgcolor="#ffffff">&nbsp;
									<asp:DropDownList id="DropDownList10" runat="server" Font-Names="����" AutoPostBack="True"></asp:DropDownList></td>
								<td bgcolor="#ffffff">&nbsp; <span class="lishu"><FONT face="����" size="4">�Ǽ�����</FONT>��</span></td>
								<td bgcolor="#ffffff"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td><font face="����" size="2">
													<asp:DropDownList id="DropDownList3" runat="server" Font-Names="����"></asp:DropDownList>
													��</font></td>
											<td><font face="����" size="2">
													<asp:DropDownList id="DropDownList8" runat="server" Font-Names="����"></asp:DropDownList>��</font></td>
											<td><font face="����" size="2">
													<asp:DropDownList id="DropDownList9" runat="server" Font-Names="����"></asp:DropDownList>��</font></td>
											<td><asp:DropDownList ID="DropDownList4" runat="server" Font-Names="����">
													<asp:ListItem Value="����">����</asp:ListItem>
													<asp:ListItem Value="����">����</asp:ListItem>
													<asp:ListItem Value="����">����</asp:ListItem>
												</asp:DropDownList></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="39" bgcolor="#ffffff">&nbsp;<span class="lishu"><FONT face="����" size="4">&nbsp;������</FONT>��</span></td>
								<td bgcolor="#ffffff">&nbsp;
									<asp:DropDownList id="DropDownList7" runat="server" Font-Names="����" Visible="False"></asp:DropDownList>
									<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label></td>
								<td colspan="2" bgcolor="#ffffff">&nbsp;
									<asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
