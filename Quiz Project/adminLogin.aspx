<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="Quiz_Project.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
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
    <form id="form1" runat="server">
        <asp:LinkButton class="topLeft btn btn-secondary" ID="LinkButton1" runat="server" PostBackUrl="studentLogin.aspx">Student Login</asp:LinkButton>
        <center>
            <div>
                <asp:Panel ID="loginPanel" runat="server">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" style="text-align: center; vertical-align: top">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Admin Log In "></asp:Label>
                            </td>
                            <td style="text-align: center; vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: center" class="auto-style2">
                                <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="UserId :"></asp:Label>
                            </td>
                            <td style="text-align: center" class="auto-style3">
                                <asp:TextBox ID="TextBox1" runat="server" Font-Size="X-Large" CssClass="offset-sm-0"></asp:TextBox>
                            </td>
                            <td style="text-align: center" class="auto-style2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Password :"></asp:Label>
                            </td>
                            <td style="text-align: center" class="auto-style4">
                                <asp:TextBox ID="TextBox2" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>
                            </td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="auto-style4"></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center" class="auto-style4">
                                <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Button1_Click" Text="Log In" />
                            </td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="auto-style4">
                                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </center>

        <br />
        <center>
            <asp:LinkButton Visible="false" class="positioning btn btn-secondary" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Show Student Score</asp:LinkButton>
            <asp:LinkButton Visible="false" class="positioning btn btn-secondary" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Edit Questions</asp:LinkButton>
            <br />
            <asp:GridView class="positioning middle table table-success table-striped" Visible="false" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId" DataSourceID="datasrc1">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" />
                    <asp:BoundField DataField="score" HeaderText="score" SortExpression="score" />
                </Columns>
            </asp:GridView>

            <asp:Repeater Visible="false" ID="Repeater1" runat="server" OnItemCommand="Repeater_OnItemCommand" OnItemDataBound="Repeater_OnItemDataBound">
                <HeaderTemplate>
                    <table class="positioning middle table table-success table-striped">
                        <tr>
                            <th>Question.</th>
                            <th>op1</th>
                            <th>op2</th>
                            <th>op3</th>
                            <th>op4</th>
                            <th>Answer Op</th>
                            <th colspan="2">Action</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <asp:Label ID="Label5" Visible="false" runat="server" Text='<%#Eval("qid") %>'></asp:Label>
                        <td><%#Eval("qid") %><asp:TextBox ID="TextBoxqs" runat="server" Text='<% #Eval("question") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxop1" runat="server" Text='<%#Eval("op1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxop2" runat="server" Text='<%#Eval("op2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxop3" runat="server" Text='<%#Eval("op3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxop4" runat="server" Text='<%#Eval("op4") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxans" runat="server" Text='<%#Eval("correct") %>' />
                        </td>
                        <td>
                            <asp:LinkButton class="btn btn-primary btn-sm" ID="update" runat="server" CommandName="update">Update</asp:LinkButton>
                            
                        </td>
                        <td>
                            <asp:LinkButton class="btn btn-danger btn-sm" ID="remove" runat="server" CommandName="remove">Delete</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinkButton id="removebutton" visible="false" class="btn btn-primary btn-sm" runat="server" OnClick="insertRow">Insert</asp:LinkButton>
            <asp:SqlDataSource ID="datasrc1" runat="server" ConnectionString="<%$ ConnectionStrings:myconn %>" SelectCommand="SELECT [UserId], [score] FROM [studentLogin] ORDER BY [UserId]"></asp:SqlDataSource>
            <br />
            <br />
        </center>
    </form>
</body>
</html>