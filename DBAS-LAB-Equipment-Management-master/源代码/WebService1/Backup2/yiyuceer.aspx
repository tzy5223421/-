<%@ Register TagPrefix="c1webchart" Namespace="C1.Web.C1WebChart" Assembly="C1.Web.C1WebChart" %>
<%@ Page language="c#" Codebehind="yiyuceer.aspx.cs" AutoEventWireup="false" Inherits="WebService1.yiyuceer" %>
<%@ Register TagPrefix="c1webchart" Namespace="C1.Web.C1WebChart" Assembly="C1.Web.C1WebChart" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>yiyuceer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">
@import url( normal.css ); BODY { BACKGROUND-IMAGE: url(img/blank.gif); MARGIN: 0px }
		</style>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table width="850" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td>
					<form id="Form1" method="post" runat="server">
						<table width="850" height="419" border="1" cellpadding="0" cellspacing="0" bordercolor="#ccccff"
							background="img/bgyg1.gif" style="WIDTH: 848px; HEIGHT: 414px">
							<tr>
								<td height="33" colspan="2"><span class="font2">��ѡ�񳧼�����,�豸����,����Ԥ���ѷ������ϵ��豸����������һ�ι��ϵ�ʱ�䣺 </span>
								</td>
							</tr>
							<TR>
								<TD class="font3" align="center" width="227" height="35">
									<P>��Ԥ���豸�ѷ������ϴ���:</P>
								</TD>
								<TD style="HEIGHT: 35px" width="615">
									<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="�����Ǵ���0������" ControlToValidate="TextBox1"
										ValidationExpression="[1-9]|[1-9][0-9]{1,}"></asp:RegularExpressionValidator></TD>
							</TR>
							<tr>
								<td width="227" height="35" align="center" class="font3">�������ƣ�</td>
								<td width="615" style="HEIGHT: 35px"><table width="98%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="340" height="19" style="WIDTH: 340px">&nbsp;
												<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList></td>
											<td width="259">&nbsp;
												<asp:Button id="Button1" runat="server" Text="ȷ��"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="34" align="center"><span class="font3"> �豸���ƣ�</span></td>
								<td>&nbsp;
									<asp:DropDownList id="DropDownList2" runat="server" AutoPostBack="True"></asp:DropDownList></td>
							</tr>
							<tr>
								<td height="315" align="center" class="font3" style="WIDTH: 207px"><p>Ԥ���豸</p>
									<p>��һ�η������ϵ�ʱ��:
									</p>
								</td>
								<td valign="top">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="256" style="HEIGHT: 256px">&nbsp;
												<c1webchart:C1WebChart id="C1WebChart1" runat="server" Width="600px" Height="238px" Visible="False">
													<Serializer Value="&lt;?xml version=&quot;1.0&quot;?&gt;
&lt;Chart2DPropBag Version=&quot;&quot;&gt;
  &lt;StyleCollection&gt;
    &lt;NamedStyle Name=&quot;PlotArea&quot; ParentName=&quot;Area&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Legend&quot; ParentName=&quot;Legend.default&quot;&gt;
      &lt;StyleData /&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Footer&quot; ParentName=&quot;Control&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;AxisY2&quot; ParentName=&quot;Area&quot;&gt;
      &lt;StyleData&gt;Rotation=Rotate90;Border=None,Transparent,1;AlignHorz=Far;BackColor=Transparent;AlignVert=Center;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Area&quot; ParentName=&quot;Area.default&quot;&gt;
      &lt;StyleData /&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Control&quot; ParentName=&quot;Control.default&quot;&gt;
      &lt;StyleData /&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;AxisX&quot; ParentName=&quot;Area&quot;&gt;
      &lt;StyleData&gt;Rotation=Rotate0;Border=None,Transparent,1;AlignHorz=Center;BackColor=Transparent;Opaque=False;AlignVert=Bottom;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;AxisY&quot; ParentName=&quot;Area&quot;&gt;
      &lt;StyleData&gt;Rotation=Rotate270;Border=None,Transparent,1;AlignHorz=Near;BackColor=Transparent;Opaque=False;AlignVert=Center;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;LabelStyleDefault&quot; ParentName=&quot;LabelStyleDefault.default&quot;&gt;
      &lt;StyleData /&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Legend.default&quot; ParentName=&quot;Control&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;Wrap=False;AlignVert=Top;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;LabelStyleDefault.default&quot; ParentName=&quot;Control&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;BackColor=Transparent;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Header&quot; ParentName=&quot;Control&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Control.default&quot; ParentName=&quot;&quot;&gt;
      &lt;StyleData&gt;ForeColor=ControlText;Border=None,Black,1;BackColor=Control;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
    &lt;NamedStyle Name=&quot;Area.default&quot; ParentName=&quot;Control&quot;&gt;
      &lt;StyleData&gt;Border=None,Black,1;AlignVert=Top;&lt;/StyleData&gt;
    &lt;/NamedStyle&gt;
  &lt;/StyleCollection&gt;
  &lt;ChartGroupsCollection&gt;
    &lt;ChartGroup&gt;
      &lt;DataSerializer Hole=&quot;3.4028234663852886E+38&quot; DefaultSet=&quot;True&quot;&gt;
        &lt;DataSeriesCollection&gt;
          &lt;DataSeriesSerializer&gt;
            &lt;LineStyle Color=&quot;DarkGoldenrod&quot; /&gt;
            &lt;SymbolStyle Color=&quot;Coral&quot; Shape=&quot;Box&quot; /&gt;
            &lt;SeriesLabel&gt;series 0&lt;/SeriesLabel&gt;
            &lt;X&gt;1;2;3;4;5&lt;/X&gt;
            &lt;Y&gt;20;22;19;24;25&lt;/Y&gt;
            &lt;Y1 /&gt;
            &lt;Y2 /&gt;
            &lt;Y3 /&gt;
            &lt;DataTypes&gt;Single;Single;Double;Double;Double&lt;/DataTypes&gt;
            &lt;DataFields&gt;;;;;&lt;/DataFields&gt;
            &lt;Tag /&gt;
          &lt;/DataSeriesSerializer&gt;
          &lt;DataSeriesSerializer&gt;
            &lt;LineStyle Color=&quot;DarkGray&quot; /&gt;
            &lt;SymbolStyle Color=&quot;CornflowerBlue&quot; Shape=&quot;Dot&quot; /&gt;
            &lt;SeriesLabel&gt;series 1&lt;/SeriesLabel&gt;
            &lt;X&gt;1;2;3;4;5&lt;/X&gt;
            &lt;Y&gt;8;12;10;12;15&lt;/Y&gt;
            &lt;Y1 /&gt;
            &lt;Y2 /&gt;
            &lt;Y3 /&gt;
            &lt;DataTypes&gt;Single;Single;Double;Double;Double&lt;/DataTypes&gt;
            &lt;DataFields&gt;;;;;&lt;/DataFields&gt;
            &lt;Tag /&gt;
          &lt;/DataSeriesSerializer&gt;
          &lt;DataSeriesSerializer&gt;
            &lt;LineStyle Color=&quot;DarkGreen&quot; /&gt;
            &lt;SymbolStyle Color=&quot;Cornsilk&quot; Shape=&quot;Tri&quot; /&gt;
            &lt;SeriesLabel&gt;series 2&lt;/SeriesLabel&gt;
            &lt;X&gt;1;2;3;4;5&lt;/X&gt;
            &lt;Y&gt;10;16;17;15;23&lt;/Y&gt;
            &lt;Y1 /&gt;
            &lt;Y2 /&gt;
            &lt;Y3 /&gt;
            &lt;DataTypes&gt;Single;Single;Double;Double;Double&lt;/DataTypes&gt;
            &lt;DataFields&gt;;;;;&lt;/DataFields&gt;
            &lt;Tag /&gt;
          &lt;/DataSeriesSerializer&gt;
          &lt;DataSeriesSerializer&gt;
            &lt;LineStyle Color=&quot;DarkKhaki&quot; /&gt;
            &lt;SymbolStyle Color=&quot;Crimson&quot; Shape=&quot;Diamond&quot; /&gt;
            &lt;SeriesLabel&gt;series 3&lt;/SeriesLabel&gt;
            &lt;X&gt;1;2;3;4;5&lt;/X&gt;
            &lt;Y&gt;16;19;15;22;18&lt;/Y&gt;
            &lt;Y1 /&gt;
            &lt;Y2 /&gt;
            &lt;Y3 /&gt;
            &lt;DataTypes&gt;Single;Single;Double;Double;Double&lt;/DataTypes&gt;
            &lt;DataFields&gt;;;;;&lt;/DataFields&gt;
            &lt;Tag /&gt;
          &lt;/DataSeriesSerializer&gt;
        &lt;/DataSeriesCollection&gt;
      &lt;/DataSerializer&gt;
      &lt;Name&gt;Group1&lt;/Name&gt;
      &lt;Stacked&gt;False&lt;/Stacked&gt;
      &lt;ChartType&gt;XYPlot&lt;/ChartType&gt;
      &lt;Pie&gt;OtherOffset=0,Start=0&lt;/Pie&gt;
      &lt;Bar&gt;ClusterOverlap=0,ClusterWidth=50&lt;/Bar&gt;
      &lt;HiLoData&gt;FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True,ShowOpen=True&lt;/HiLoData&gt;
      &lt;Bubble&gt;EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5&lt;/Bubble&gt;
      &lt;Polar&gt;Degrees=True,PiRatioAnnotations=True,Start=0&lt;/Polar&gt;
      &lt;Radar&gt;Degrees=True,Filled=False,Start=0&lt;/Radar&gt;
      &lt;Visible&gt;True&lt;/Visible&gt;
      &lt;ShowOutline&gt;True&lt;/ShowOutline&gt;
    &lt;/ChartGroup&gt;
    &lt;ChartGroup&gt;
      &lt;DataSerializer Hole=&quot;3.4028234663852886E+38&quot; /&gt;
      &lt;Name&gt;Group2&lt;/Name&gt;
      &lt;Stacked&gt;False&lt;/Stacked&gt;
      &lt;ChartType&gt;XYPlot&lt;/ChartType&gt;
      &lt;Pie&gt;OtherOffset=0,Start=0&lt;/Pie&gt;
      &lt;Bar&gt;ClusterOverlap=0,ClusterWidth=50&lt;/Bar&gt;
      &lt;HiLoData&gt;FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True,ShowOpen=True&lt;/HiLoData&gt;
      &lt;Bubble&gt;EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5&lt;/Bubble&gt;
      &lt;Polar&gt;Degrees=True,PiRatioAnnotations=True,Start=0&lt;/Polar&gt;
      &lt;Radar&gt;Degrees=True,Filled=False,Start=0&lt;/Radar&gt;
      &lt;Visible&gt;True&lt;/Visible&gt;
      &lt;ShowOutline&gt;True&lt;/ShowOutline&gt;
    &lt;/ChartGroup&gt;
  &lt;/ChartGroupsCollection&gt;
  &lt;Header Compass=&quot;North&quot;&gt;
    &lt;Text /&gt;
  &lt;/Header&gt;
  &lt;Footer Compass=&quot;South&quot;&gt;
    &lt;Text /&gt;
  &lt;/Footer&gt;
  &lt;Legend Compass=&quot;East&quot; Visible=&quot;False&quot;&gt;
    &lt;Text /&gt;
  &lt;/Legend&gt;
  &lt;ChartArea /&gt;
  &lt;Axes&gt;
    &lt;Axis Max=&quot;5&quot; Min=&quot;1&quot; UnitMajor=&quot;1&quot; UnitMinor=&quot;0.5&quot; AutoMajor=&quot;True&quot; AutoMinor=&quot;True&quot; AutoMax=&quot;True&quot; AutoMin=&quot;True&quot; _onTop=&quot;0&quot; Compass=&quot;South&quot;&gt;
      &lt;Text /&gt;
      &lt;GridMajor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
      &lt;GridMinor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
    &lt;/Axis&gt;
    &lt;Axis Max=&quot;26&quot; Min=&quot;8&quot; UnitMajor=&quot;2&quot; UnitMinor=&quot;1&quot; AutoMajor=&quot;True&quot; AutoMinor=&quot;True&quot; AutoMax=&quot;True&quot; AutoMin=&quot;True&quot; _onTop=&quot;0&quot; Compass=&quot;West&quot;&gt;
      &lt;Text /&gt;
      &lt;GridMajor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
      &lt;GridMinor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
    &lt;/Axis&gt;
    &lt;Axis Max=&quot;0&quot; Min=&quot;0&quot; UnitMajor=&quot;0&quot; UnitMinor=&quot;0&quot; AutoMajor=&quot;True&quot; AutoMinor=&quot;True&quot; AutoMax=&quot;True&quot; AutoMin=&quot;True&quot; _onTop=&quot;0&quot; Compass=&quot;East&quot;&gt;
      &lt;Text /&gt;
      &lt;GridMajor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
      &lt;GridMinor AutoSpace=&quot;True&quot; Color=&quot;LightGray&quot; Pattern=&quot;Dash&quot; /&gt;
    &lt;/Axis&gt;
  &lt;/Axes&gt;
&lt;/Chart2DPropBag&gt;"></Serializer>
												</c1webchart:C1WebChart></td>
										</tr>
										<tr>
											<td height="37" align="right">&nbsp;
												<asp:Button id="Button2" runat="server" Text="��һҳ"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<INPUT id="Hidden1" style="Z-INDEX: 101; LEFT: 368px; POSITION: absolute; TOP: 472px" type="hidden"
			name="Hidden1" runat="server">
	</body>
</HTML>
