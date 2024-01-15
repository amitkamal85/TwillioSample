<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForwardCall.aspx.cs" Inherits="Twilio.ForwardCall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="jquery-1.10.2.min.js"></script>
    <script src="script.js"></script>
    <link href="style.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .main_div {
            float: left;
            width: 100%;
        }
        .auto-style1
        {
            margin-top: 30px;
        }

        .auto-style1 {
            width: 100%;
            float:left;
            margin:10px 0;
        }

h2{ 
    font-size:25px; 
    text-align:center;
    margin:50px 0 10px; 
}
        .start_Call {
            background: #72BB52;
            border: solid 1px #000;
            padding: 15px 35px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 600;
        }

        .end_call {
            background: #FF8983;
            border: solid 1px #000;
            padding: 15px 35px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 600;
        }

          .Add_New {
            background: #66CCFF;
            border: solid 1px #000;
            padding: 8px 8px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 600;
            margin-left:37%;
        }
        .auto-style2{
           text-align:center;
        }
        .row-div{
            float:left;
            width:100%;
            text-align:center;
            margin:25px 0;
        }
        .Right
        {
            float:right;
            margin-right:10px;
        }
    </style>
    <script type="text/ecmascript">
        $(document).ready(function () {
         $('.chktest input').click(function () {
                $(".chktest input").each(function () {
                    $("#chk").attr("checked", false);
              })
               $(this).attr("checked", true);
           })
        })

        //$("#<%=grdListofNumbers.ClientID%> input[type='checkbox']").click(function () {
          //alert('dfdfs');
            //$(".chktest input").each(function () {
            //    $(this).attr("checked", false);
            //})
            //$(this).attr("checked",true);
    

        function GetAllCheckDisable()
        {
          
            if ($("#grdListofNumbers input[id*='chk']:checked").length > 1)
            {
                alert("One or more rows are checked please choose one");
                return false;
            }
            else if($("#grdListofNumbers input[id*='chk']:checked").length < 1)
            {
                alert("Please Check atleast one check box.");
                return false;
            }
            else
            {
                alert('Enable Call Forwarding Is In Process!');
            }
        }

          //  alert($("#grdListofNumbers input[id*='chk']:checked").length);

<%--            if ($("#<%=grdListofNumbers.ClientID%> input[type='checkbox']:checked").length > 0)
            {
                alert("One Or More Rows are Checked Please Choose One");
            }--%>

           // return false;
       

        function toggleSelectionGrid(source) {
            var isChecked = source.checked;
            $("#grdListofNumbers input[id*='chk']").each(function (index) {
                $(this).attr('checked', false);
            });
            source.checked = isChecked;
        }
           
        function AddPage()
        {
            window.location.href = 'AddEditNumbers.aspx';
        }
    

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField  ID="isDone" ClientIDMode="Static" runat="server"  />
        <div class="main_div">
            <h2>Call Forwarding</h2>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">                        
                       <div class="row-div">      
                        <asp:RadioButton ID="rdb_start" Enabled="false"  GroupName="same" runat="server" ClientIDMode="Static" />
                        <asp:Button ID="btnStartCall" runat="server"  Text="ENABLE"  OnClientClick="return GetAllCheckDisable();" OnClick="btnStartCall_Click" CssClass="start_Call" />
                             <asp:RadioButton ID="rdb_end" Enabled="false" GroupName="same" runat="server" ClientIDMode="Static" />
                        <asp:Button ID="btnEndCall" runat="server" CssClass="end_call" Style="margin-left: 0px" Text="DISABLE" OnClick="btnEndCall_Click" />
                            
                      </div>
                       <div class="row-div">
                           
                        <%--   <a href="AddEditNumbers.aspx" class="Add_New">Add New Number</a> --%>
                         
                       </div>
                          <div class="row-div"> 
                         <asp:Button ID="btnAddNumbers" runat="server" Text="Add New Number" OnClick="btnAddNumbers_Click"  CssClass="Add_New"  />
                      
                       <asp:GridView ID="grdListofNumbers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" style="text-align:center;width:500px; margin-left:500px;margin-top:1%" OnRowDataBound="grdListofNumbers_RowDataBound" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        <Columns>
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk"  onclick="toggleSelectionGrid(this);"  runat="server"   />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" >
                                <HeaderTemplate>
                                       <asp:Label ID="lblhText" runat="server" Text='Number' />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server"  Text='<%#Eval("Name") %>' ClientIDMode="Static"/>
                                      <asp:Label ID="lblID" runat="server"  Text='<%#Eval("ID") %>' ClientIDMode="Static" Visible="false"/>

                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField>
                                   <HeaderTemplate>
                                       <asp:Label ID="lblText" runat="server" Text='Number' CssClass="Right" />
                                   </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNumber" runat="server" Text='<%#Eval("Number") %>' CssClass="Right" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                    </td>
                  
                </tr>

                </table>

        </div>
    </form>
</body>
</html>
