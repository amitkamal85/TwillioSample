<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditNumbers.aspx.cs" Inherits="Twilio.AddEditNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
    <script>
        function ConfirmDelete() {
            var x = confirm("Are you sure you want to delete?");
            if (x)
                return true;
            else
                return false;
        }

        function OnClienClick()
        {
            var x = document.getElementById("txtName").value;
            if(x ==  "" || x == null)
            {
                document.getElementById("error1").style.display = "Block";
                return false;
            }
            else
            {
                document.getElementById("error1").style.display = "none";
            }

            var y = document.getElementById("txtNumber").value;
            if (y == "" || y == null)
            {
                document.getElementById("error2").style.display = "Block";
                return false;
            }
            else
            {
                document.getElementById("error2").style.display = "none";
            }

            var NumberLength = document.getElementById("txtNumber").value.length;

          
            if (NumberLength < 10)
            {
                document.getElementById("ErrorLess").style.display = "Block";
                return false;
            }
            else
            {
                document.getElementById("ErrorLess").style.display = "none";
            }

            return true;
        }

    </script>
      <script type="text/javascript">
          var specialKeys = new Array();
          specialKeys.push(8); //Backspace
          function IsNumeric(e) {
              var keyCode = e.which ? e.which : e.keyCode
              var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
              document.getElementById("error").style.display = ret ? "none" : "inline";
              return ret;
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
  
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ForwardCall.aspx">Forward Call</asp:HyperLink></td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><span id="error1" style="color: Red; display: none">Please Enter Name</span></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Number:</td>
                <td><asp:TextBox ID="txtNumber" runat="server"  MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                     <span id="error2" style="color: Red; display: none">Please Enter Number</span> 
                    <span id="error" style="color: Red; display: none">* Input digits (0 - 9)</span>
                      <span id="ErrorLess" style="color: Red; display: none">Please enter minimum 10 digit Number</span>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return OnClienClick();" />
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:HiddenField ID="hdnID" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:GridView ID="grdListofNumbers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" style="text-align:center;width:500px;" OnRowCommand="grdListofNumbers_RowCommand">
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
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server"  Text='<%#Eval("Name") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumber" runat="server"  Text='<%#Eval("Number") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Newedit" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                   <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" CommandName="Newdelete" CommandArgument='<%#Eval("ID") %>'   OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
            </tr>
        </table>
  
    </form>
</body>
</html>
