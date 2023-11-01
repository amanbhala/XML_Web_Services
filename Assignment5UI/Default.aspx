<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <div>
            <h2>
                <p>
                    <asp:Label Font-Bold="true" ID="Label1" runat="server" Text="XML Validation Service"></asp:Label>
                </p>
            </h2>

            <p> This service takes a URL for an XML document and an XML Schema document and verifies them. It returns error information if there is any or No Errors as response. </p>
            <p>Enter URL for XML document <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox> </p>
            <p>Enter URL for XML schema document <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox> </p>
            <p><asp:Button ID="Output" runat="server" Text="Verification result" OnClick="xmlverification"/></p>
            <p>Output : <asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
            <br />
            <br />
        </div>

        <div>
            <h2>
                <p>
                    <asp:Label Font-Bold="true" ID="Label2" runat="server" Text="XML Search Service"></asp:Label>
                </p>
            </h2>

            <p> This service takes a URL for an XML document and a key as inputs. It returns the node’s content information related to the search key. </p>
            <p>Enter URL for XMl document <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox7_TextChanged"></asp:TextBox> </p>
            <p>Enter search key <asp:TextBox ID="TextBox8" runat="server" OnTextChanged="TextBox8_TextChanged"></asp:TextBox> </p>
            <p><asp:Button ID="Button1" runat="server" Text="Search result" OnClick="xmlsearch"/></p>
            <p>Output : <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
            <br />
            <br />
        </div>

    </main>

</asp:Content>
