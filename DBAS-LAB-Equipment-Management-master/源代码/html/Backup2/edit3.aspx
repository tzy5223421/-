<%@ Page language="c#" Codebehind="edit3.aspx.cs" AutoEventWireup="false" Inherits="html.edit3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>edit3</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	<style type="text/css">
<!--
@import url("css/normal.css");
.STYLE2 {color: #000000; font-weight: normal;}
body {
	background-image: url(img/JDSJ029.jpg);
}
-->
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="700" height="157" border="0" align="center" cellpadding="0" cellspacing="1" bordercolor="#CCCCFF" bgcolor="#ccccff">
				<tr>
					<td height="30" colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">&nbsp;<FONT size="5" face="����" class="font1">�û�������Ϣ�޸�</FONT></td>
				</tr>
				<tr>
				  <td bgcolor="#FFFFFF" style="WIDTH: 106px">&nbsp;&nbsp;<span class="STYLE2"><FONT face="����" size="4">ԭʼ����</FONT></span><span class="fontlishu">��</span></td>
					<td bgcolor="#FFFFFF">&nbsp;
						<asp:TextBox id="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="���벻��Ϊ��"
							Font-Names="����"></asp:RequiredFieldValidator>
				  <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="���������6λ���ϵ�����"
							ValidationExpression="[0-9]{6,}" Font-Names="����"></asp:RegularExpressionValidator></td>
				</tr>
				<tr>
					<td bgcolor="#FFFFFF" style="WIDTH: 106px">&nbsp;<span class="STYLE2"><FONT face="����" size="4"> ������</FONT></span><span class="fontlishu">��</span></td>
					<td bgcolor="#FFFFFF">&nbsp;
						<asp:TextBox id="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="���벻��Ϊ��"
							Font-Names="����"></asp:RequiredFieldValidator>
				  <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="���������6λ���ϵ�����"
							ValidationExpression="[0-9]{6,}" Font-Names="����"></asp:RegularExpressionValidator></td>
				</tr>
				<tr>
					<td bgcolor="#FFFFFF" style="WIDTH: 106px">&nbsp;<span class="STYLE2"><FONT face="����" size="4">ȷ��������</FONT></span><span class="fontlishu">��</span></td>
					<td bgcolor="#FFFFFF">&nbsp;
						<asp:TextBox id="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="���벻��Ϊ��"
							Font-Names="����"></asp:RequiredFieldValidator>
				  <asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="���������һ��"
							ControlToCompare="TextBox2" Font-Names="����"></asp:CompareValidator></td>
				</tr>
				<tr>
					<td height="31" bgcolor="#FFFFFF" style="WIDTH: 106px">&nbsp;</td>
					<td bgcolor="#FFFFFF">&nbsp;
				  <asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></td>
				</tr>
		  </table>
		</form>
</body>
</HTML>
