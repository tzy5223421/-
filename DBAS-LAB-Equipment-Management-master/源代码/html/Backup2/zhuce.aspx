<%@ Page language="c#" Codebehind="zhuce.aspx.cs" AutoEventWireup="false" Inherits="html.zhuce" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���û�ע��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="css/normal.css" rel="stylesheet" type="text/css">
		<style type="text/css">
BODY { MARGIN: 0px }
.STYLE2 { COLOR: #000000 }
		</style>
	</HEAD>
	<body background="img/blank.gif" MS_POSITIONING="GridLayout">
		<table width="778" height="499" border="0" cellpadding="0" cellspacing="0" align="center">
			<tr>
				<td height="100"><img src="file:///C:\Inetpub\wwwroot\data\html\img\top.gif" width="778" height="100"></td>
			</tr>
			<tr>
				<td height="307" align="center" valign="middle" background="img/bgyg1.gif">
					<form id="Form1" method="post" runat="server">
						<table width="568" height="156" border="0" cellpadding="0" cellspacing="1" bordercolor="#ccccff"
							bgcolor="#ccccff">
							<tr>
								<td colspan="2" align="center" background="img/dl_bg.gif">&nbsp;<FONT size="5" face="����" class="font1">���û�ע��</FONT></td>
							</tr>
							<tr>
								<td width="111" height="30" valign="middle" bgcolor="#ffffff">&nbsp;<span class="lishu"><font size="4" face="����">�û���:</font></span><font size="4" face="����">
									</font>
								</td>
								<td width="451" valign="middle" bgcolor="#ffffff">&nbsp;
									<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�û�������Ϊ��" ControlToValidate="TextBox1"
										Font-Names="����"></asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td height="30" bgcolor="#ffffff">&nbsp;<span class="lishu"><font size="4" face="����">����</font>��</span></td>
								<td bgcolor="#ffffff">&nbsp;
									<asp:TextBox id="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="���벻��Ϊ��" ControlToValidate="TextBox2"
										Font-Names="����"></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="��������Ǵ���6λ������" ControlToValidate="TextBox2"
										ValidationExpression="[0-9]{6,}" Font-Names="����"></asp:RegularExpressionValidator></td>
							</tr>
							<tr>
								<td height="30" bgcolor="#ffffff">&nbsp;<span class="lishu"><font size="4" face="����">ȷ������</font>��</span></td>
								<td bgcolor="#ffffff">&nbsp;
									<asp:TextBox id="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="���벻һ��" ControlToValidate="TextBox3"
										ControlToCompare="TextBox2" Display="Dynamic" Type="Integer" Font-Names="����"></asp:CompareValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="ȷ�����벻��Ϊ��" ControlToValidate="TextBox3"
										Font-Names="����"></asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td bgcolor="#ffffff">&nbsp;
									<asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></td>
								<td bgcolor="#ffffff">&nbsp;</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr>
				<td height="92" align="center" valign="middle" background="img/bg-d.jpg"><table width="500" height="67" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td align="center" valign="middle" class="font"></td>
						</tr>
						<tr>
							<td align="center" valign="middle"><FONT color="#000033"></FONT>
							</td>
						</tr>
						<tr>
							<td align="center" valign="middle" class="font"></td>
						</tr>
						<tr>
							<td align="center" valign="middle" class="font"></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
