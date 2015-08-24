<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication1.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        
        function alertSweet() {
            swal({ title: 'Invalid User Name or Password!', type: 'error', confirmButtonColor: '#A90404', showConfirmButton: true });
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- BEGIN CONTENT -->
	<div class="wrapper animated fadeInDown">
		<div class="panel overflow-hidden">
			<div class="bg-light-blue-500 padding-top-25 no-margin-bottom font-size-20 color-white text-center text-uppercase">
				<i class="ion-log-in margin-right-5"></i> Sign In 
			</div>
			<%--<form id="checkform" method="post" action="http://demo.yakuzi.eu/maniac/1.2/index.html" novalidate="novalidate" class="bv-form">--%>
				<div class="alert bg-light-blue-500 text-center color-white no-radius no-margin padding-top-15 padding-bottom-30 padding-left-20 padding-right-20">Please sign in to Petty Cash Management System</div>
				
            <div class="box-body padding-md">
				
					<div class="form-group">
                        <asp:TextBox ID="tb_username" runat="server" class="form-control input-lg" placeholder="Username"></asp:TextBox>
						<%--<input type="text" name="username" class="form-control input-lg" placeholder="Username" data-bv-field="username">
					<small data-bv-validator="notEmpty" data-bv-validator-for="username" class="help-block" style="display: none;">The username is required and can't be empty</small>--%>

					</div>
					
					<div class="form-group">                       
                        <asp:TextBox ID="tb_password" runat="server" class="form-control input-lg" placeholder="Password"  type="password"></asp:TextBox>
						<%--<input type="password" name="password" class="form-control input-lg" placeholder="Password" data-bv-field="password">
					<small data-bv-validator="notEmpty" data-bv-validator-for="password" class="help-block" style="display: none;">The password is required and can't be empty</small>--%>

					</div>        
					
					<div class="form-group margin-top-20">

                        <%--<asp:CheckBox ID="CheckBox1" runat="server" class="js-switch" data-switchery="true" style="display: none;"/>
                        <span class="switchery switchery-default" style="border-color: rgb(100, 189, 99); box-shadow: rgb(100, 189, 99) 0px 0px 0px 16px inset; transition: border 0.4s, box-shadow 0.4s, background-color 1.2s; -webkit-transition: border 0.4s, box-shadow 0.4s, background-color 1.2s; background-color: rgb(100, 189, 99);"></span>--%>
						
                        <input type="checkbox" class="js-switch" id="checkbox" checked="" data-switchery="true" style="display: none;" ><span class="switchery switchery-default" style="border-color: rgb(100, 189, 99); box-shadow: rgb(100, 189, 99) 0px 0px 0px 16px inset; transition: border 0.4s, box-shadow 0.4s, background-color 1.2s; -webkit-transition: border 0.4s, box-shadow 0.4s, background-color 1.2s; background-color: rgb(100, 189, 99);">
                            <small style="left: 20px; transition: left 0.2s; -webkit-transition: left 0.2s; background-color: rgb(255, 255, 255);"></small></span>
                        
                        
                        <asp:Label ID="Label1" runat="server" class="font-size-12 normal margin-left-10" Text="Remember Me"></asp:Label>                        
                        <%--<label for="checkbox" class="font-size-12 normal margin-left-10">Remember Me</label>--%>
					</div>       
                    <asp:Button ID="submitLogIn" class="btn btn-dark bg-light-green-500 padding-10 btn-block color-white" runat="server" Text="Sign in" OnClick="submitLogIn_Click"/>
					<%--<button type="submit" class="btn btn-dark bg-light-green-500 padding-10 btn-block color-white"><i class="ion-log-in"></i> Sign in</button>  --%>
                    <div class="form-group margin-top-20">
                        <asp:Label ID="logerror" runat="server" Text="" style="display:none;background-color: red;color: blue;padding: 5px;border-radius: 5px;position: relative;top: 20px;"></asp:Label>
                    </div>
				</div>
			

			<%--</form>--%>
			<div class="panel-footer padding-md no-margin no-border bg-light-blue-500 text-center color-white">© 2015 EIDEAS TECHNOLOGIES.</div>
		</div>
	</div>
	<!-- END CONTENT -->
</asp:Content>
