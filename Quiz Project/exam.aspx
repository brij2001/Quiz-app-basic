<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exam.aspx.cs" Inherits="Quiz_Project.exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Quiz Web Application</h1>
                <h2>AWP Project</h2>
                <hr />
                </center>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table class="positioning" ><div class="main-box">
                            <tr>
                                <td>QNo. <%#Eval("qid") %>:<%#Eval("question") %></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text='<%#Eval("op1") %>' GroupName="radioexam" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" Text='<%#Eval("op2") %>' GroupName="radioexam" />
                                    <asp:RadioButton ID="RadioButton3" runat="server" Text='<%#Eval("op3") %>' GroupName="radioexam" />
                                    <asp:RadioButton ID="RadioButton4" runat="server" Text='<%#Eval("op4") %>' GroupName="radioexam" />
                                    <br />
                                   <!-- <asp:Label ID="CorrectAns" runat="server" Text='<%#Eval("correct") %>' Visible="false"></asp:Label>-->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="UserAns" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                       </div> </table>
                    </ItemTemplate>
                </asp:Repeater>
                <br /><br /><asp:Button class="positioning btn btn-successs" ID="submit_btn" runat="server" Text="Submit" OnClick="submit_btn_Click" BackColor="#009900" />

                <br /><p class="fw-normal">
                <asp:Label class="positioning" ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>   </p>
            <asp:LinkButton  class="positioning btn btn-secondary" ID="LinkButton1" runat="server" PostBackUrl="studentLogin.aspx">New Test</asp:LinkButton>
        </div>
    </form>
</body>
</html>
