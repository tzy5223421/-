<%@ Page language="c#" Codebehind="sbgl.aspx.cs" AutoEventWireup="false" Inherits="html.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="css/normal.css" rel="stylesheet" type="text/css">
		<style type="text/css">
BODY { BACKGROUND-IMAGE: url(img/JDSJ029.jpg); MARGIN: 0px }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="851" height="390" border="0" cellPadding="0" cellSpacing="0">
				<tr>
					<td width="829" height="26" align="center" vAlign="middle" background="img/dl_bg.gif">&nbsp;<FONT face="����" size="5">�����豸�����</FONT></td>
				</tr>
				<tr>
					<td height="72" align="center" valign="top"><table width="91%" height="72" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td height="24" colspan="6" align="left" class="font"><img src="img/dian.jpg" width="18" height="18">���ѯĳ����������豸���������ѯ����&nbsp;��&nbsp;</td>
							</tr>
							<tr>
								<td width="136" height="25" align="center" class="font">&nbsp;</td>
								<td width="103" class="font2" style="WIDTH: 103px"><span class="font2" style="WIDTH: 103px"><span class="font2" style="WIDTH: 103px">ʵ�������ƣ�</span></span></td>
								<td width="171" style="WIDTH: 171px">&nbsp;
									<asp:DropDownList id="DropDownList3" runat="server" AutoPostBack="True"></asp:DropDownList></td>
								<td width="83" class="font2" style="WIDTH: 83px"><span class="font2" style="WIDTH: 83px"><span class="font2" style="WIDTH: 83px">�豸���:</span></span></td>
								<td width="120">&nbsp;
									<asp:DropDownList id="DropDownList4" runat="server"></asp:DropDownList></td>
								<td width="162">
									<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/search_m.gif"></asp:ImageButton></td>
							</tr>
							<tr>
								<td height="11" colspan="6" align="center" class="font">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="139" align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td align="center"><asp:DataGrid ID="DataGrid1" runat="server" PageSize="5" Width="817px" AllowPaging="True" BorderColor="#CCCCFF"
										BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" Height="248px" AutoGenerateColumns="False"
										Font-Size="Smaller" Font-Names="����">
										<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="#000066" BackColor="#88A2FF"></HeaderStyle>
										<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
										<PagerStyle Visible="False" NextPageText="��һҳ" PrevPageText="��һҳ" HorizontalAlign="Right" ForeColor="#4A3C8C"
											BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></td>
							</tr>
							<tr>
								<td><table width="100%" height="28" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td style="WIDTH: 617px">&nbsp;&nbsp;
												<asp:Button ID="Button1" runat="server" Height="20px" Text="����µĹ����豸"></asp:Button></td>
											<td>&nbsp;
												<asp:Button id="Button2" runat="server" Height="20px" Text="��ҳ" ForeColor="Black"></asp:Button>
												<asp:Button id="Button3" runat="server" Height="20px" Text="��һҳ"></asp:Button>
												<asp:Button id="Button4" runat="server" Height="20px" Text="��һҳ"></asp:Button>
												<asp:Button id="Button5" runat="server" Height="20px" Text="ĩҳ"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td class="font2">ע������豸id�ſ��Բ鿴ÿ�������豸��ά����������ҿ������ά�޹��̡�</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="Hidden1" style="Z-INDEX: 101; LEFT: 328px; POSITION: absolute; TOP: 464px" type="hidden"
				name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
