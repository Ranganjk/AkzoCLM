<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="GHLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
    <meta charset="UTF-8">

    <title>CodePen - Log-In</title>
    
    <link href="CSS/LogInStyle.css" rel="stylesheet" type="text/css"  />
</head>
<body>
    <div class="box">
        <div class="content">
            <h1>Log In</h1>
            <input class="field" id="UserID" type="text" name="user" placeholder="User Name"><br>
            <input class="field" id="Password" type="password" name="pass" placeholder="Password"><br>
            <input class="btn" type="submit"   value="Log In" onclick="myFunction()">
            <%--<form runat="server">
                <asp:Button ID="Button1" runat="server" Height="24px" Text="Submit" Width="93px" BackColor="#CC00FF" BorderStyle="Solid" OnClick="DynamicButton_Click" />
            </form>--%>

             <script>
                 function myFunction() {
                     var inputVal1 = document.getElementById("UserID").value;
                     var inputVal2 = document.getElementById("Password").value;
                     if (inputVal1 == 'Admin' && inputVal2 == 'Admin123')
                     { 
                         window.location.href = "Dashboard.aspx";
                     }
                     else
                     {
                         alert("Invalid User Name or Password");
                     }

                 }
             </script>

           <%-- <button type="button" onclick="my_button_click_handler" runat="server">Click this button</button>
            <script>
                function my_button_click_handler() {
                    alert('Button Clcked');
                }
            </script>--%>

            <%--<p id="demo" onclick="myFunction()">Click me to change my text color.</p>

            <script>
                function myFunction() {
                    document.getElementById("demo").style.color = "red";
                }
            </script>--%>
        </div>
    </div>


</body>
</html>
