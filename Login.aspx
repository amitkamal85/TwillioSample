<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Twilio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.10.2.min.js"></script>
</head>
    <style type="text/css">
.main_div{
            float:left;
            width:100%;
 }
.table_pass { float:left; width:100%; margin:50px 0; }
.table_pass input[type=password]{
            border:solid 1px #979797;
            padding:10px 2.5%;
            font-size:15px;
            width:95%;
        }
   .table_pass input[type=submit]{
            border:solid 1px #000;
            padding:10px 20px;
            background:#E9E4E8;
            font-size:16px;
            border-radius:5px;
            font-weight:bold;
        }
.table_pass td{
    padding:5px;
}
    </style>

<body>
    <form id="form1" runat="server">
    <div class="main_div">
    
        <table class="table_pass">
          
            <tr>
                
                <td>
                    <asp:TextBox TextMode="Password" ClientIDMode="Static" runat="server" ID="txt_pasword" placeholder="Password"></asp:TextBox>
                    
                     <asp:Label ForeColor="Red" runat="server" ID="lbl_password" ></asp:Label>
                       <asp:RequiredFieldValidator ValidationGroup="A" ID="rfv_password" runat="server" ControlToValidate="txt_pasword" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 
                </td>
            </tr>

            

            <tr>
                <td style="text-align:center;">
                    <asp:Button runat="server" Text="Submit" ID="btn_save" ClientIDMode="Static" OnClick="btn_save_Click" ValidationGroup="A" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
