<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="AbstractFactory.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <span >Enter the Employee's Name</span><asp:TextBox ID="txtName" runat ="server" ></asp:TextBox><br /><br />
            <span >Enter the Employee's Title</span><asp:TextBox ID="txtTitle" runat ="server" ></asp:TextBox><br /><br />
            <span >Enter the Employee's salary</span><asp:TextBox ID="txtSalary" runat ="server" ></asp:TextBox><br /><br />
            <span >Enter Your Age:</span><asp:TextBox ID="txtAge" runat ="server" ></asp:TextBox><br /><br />

           <br /><br />
            <asp:Button ID="GetFlatRate" runat="server" Text="Get Flat Rate" />
       
         <br /><br />
            <span >Enter Your multiple:</span><asp:TextBox ID="txtMultiple" runat ="server" ></asp:TextBox><br />
            
            <asp:Button ID="GetMultiple" runat="server" Text="Get Flat Rate" />
           
            <br /><br />
            <span id="DisplayFlatRate" runat="server"></span>
        </div>
    </form>
</body>
</html>
