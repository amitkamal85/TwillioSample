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
        .auto-style2{
           text-align:center;
        }
        .row-div{
            float:left;
            width:100%;
            text-align:center;
            margin:25px 0;
        }
    </style>
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
                        <asp:Button ID="btnStartCall" runat="server"  Text="Start Call" OnClick="btnStartCall_Click" CssClass="start_Call" />
                      </div>
                        <div class="row-div">
                        <asp:RadioButton ID="rdb_end" Enabled="false" GroupName="same" runat="server" ClientIDMode="Static" />
                        <asp:Button ID="btnEndCall" runat="server" CssClass="end_call" Style="margin-left: 0px" Text="End Call" OnClick="btnEndCall_Click" />
                            </div>
                    </td>
                  
                </tr>
               
            </table>

        </div>
    </form>
</body>
</html>
