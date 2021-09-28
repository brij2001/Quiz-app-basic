<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentLogin.aspx.cs" Inherits="Quiz_Project.studentLogin" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous"/>
    <style type="text/css">
        .auto-style1 {
            height: 34px;
            width: 488px;
        }
        .auto-style2 {
            height: 35px;
        }
        .auto-style3 {
            height: 35px;
            width: 12px;
        }
        .auto-style4 {
            width: 12px;
        }
    </style>
</head>
<body>  
    <form id="form1" runat="server">  <center>
    <div>  
      
        <table class="auto-style1">  
            <tr>  
                <td colspan="2" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Student Log In "></asp:Label>  
                </td>  
                
            </tr>  
            <tr>  
                <td style="text-align: center" class="auto-style2">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="UserId :"></asp:Label>  
                </td>  
                <td style="text-align: center" class="auto-style3">  
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="X-Large" CssClass="offset-sm-0"></asp:TextBox>  
                </td>  
                
            </tr>  
            <tr>  
                <td style="text-align: center">  
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Password :"></asp:Label>  
                </td>  
                <td style="text-align: center" class="auto-style4">  
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
                  
            </tr>  
            <tr>  
                <td> </td>  
                
            </tr>  
            <tr>  
                <td><asp:LinkButton  class="positioning btn btn-secondary" ID="LinkButton1" runat="server" PostBackUrl="adminLogin.aspx">Admin Login</asp:LinkButton></td>  
                <td style="text-align: center" class="auto-style4">  
                    <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Button1_Click" Text="Log In" />  
                </td>  
                 
            </tr>  
            <tr>  
                <td> </td>  
                <td class="auto-style4">  
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>  
                 
            </tr>  
        </table>  
      
    </div> </center> 
    </form>  
</body>  
</html>
