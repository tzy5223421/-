<%@ Page language="c#" Codebehind="add8.aspx.cs" AutoEventWireup="false" Inherits="html.add8" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>add8</title>
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
			<table width="700" height="157" border="0" align="center" cellpadding="0" cellspacing="1"
				bordercolor="#ccccff" bgcolor="#ccccff">
				<tr>
					<td height="30" colspan="2" align="center" bgcolor="#ffffff" class="font1">&nbsp;<FONT face="����" size="5">����Ա���</FONT></td>
				</tr>
				<tr>
					<td bgcolor="#ffffff" style="WIDTH: 153px; HEIGHT: 29px">&nbsp;<FONT size="4" face="����" class="fontlishu">�û�����</FONT></td>
					<td height="29" valign="middle" bgcolor="#ffffff" style="HEIGHT: 29px">&nbsp;
						<asp:TextBox id="TextBox1" runat="server" Font-Names="����"></asp:TextBox><FONT face="����">&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�û�������Ϊ��" ControlToValidate="TextBox1"
								Font-Names="����"></asp:RequiredFieldValidator></FONT></td>
				</tr>
				<tr>
					<td height="25" bgcolor="#ffffff" style="WIDTH: 153px">&nbsp;<FONT size="4" face="����" class="fontlishu">���룺</FONT></td>
					<td height="30" bgcolor="#ffffff">&nbsp;
						<asp:TextBox id="TextBox2" runat="server" TextMode="Password" Font-Names="����"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="���벻��Ϊ��" ControlToValidate="TextBox2"
							Font-Names="����"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="��������Ǵ���6λ������" ControlToValidate="TextBox2"
							ValidationExpression="[0-9]{6,}" Font-Names="����"></asp:RegularExpressionValidator></td>
				</tr>
				<tr>
					<td height="25" bgcolor="#ffffff" style="WIDTH: 153px">&nbsp;<font size="4" face="����">ȷ������:
						</font>
					</td>
					<td height="30" bgcolor="#ffffff">&nbsp;
						<asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Font-Names="����"></asp:TextBox>
						<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="���벻һ��" ControlToValidate="TextBox3"
							ControlToCompare="TextBox2" Display="Dynamic" Type="Integer" Font-Names="����"></asp:CompareValidator><FONT face="����">&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="ȷ�����벻��Ϊ��" ControlToValidate="TextBox3"
								Font-Names="����"></asp:RequiredFieldValidator></FONT></td>
				</tr>
				<TR>
					<TD class="fontlishu" style=" WIDTH: 153px" bgColor="#ffffff" height="25">&nbsp;<FONT face="����" size="4">����</FONT></TD>
					<TD bgColor="#ffffff" height="30">&nbsp;
						<asp:DropDownList id="DropDownList1" runat="server">
							<asp:ListItem Value="����">����</asp:ListItem>
							<asp:ListItem Value="һ��">һ��</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<tr>
					<td height="34" bgcolor="#ffffff" style="WIDTH: 153px">&nbsp;
						<asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></td>
					<td height="30" bgcolor="#ffffff">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
