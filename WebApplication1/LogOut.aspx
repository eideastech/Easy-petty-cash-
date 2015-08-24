<%@ Page Title="" Language="C#" MasterPageFile="~/LogOut.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="WebApplication1.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function alertSweet() {
            swal({ title: 'Invalid User Name or Password!', type: 'error', confirmButtonColor: '#A90404', showConfirmButton: true });
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrapper animated fadeInDown">
		<div class="panel overflow-hidden">
			<div class="bg-blue-grey-500 padding-top-25 no-padding-bottom font-size-20 color-white text-center text-uppercase">
				<i class="ion-unlocked margin-right-5"></i> You have logged Out
			</div>
			
				<div class="alert bg-blue-grey-500 text-center color-white no-radius no-margin padding-top-15 padding-bottom-30 padding-left-20 padding-right-20">enter your username & password to login in again</div>
				<div class="box-body padding-md">
				
					<div class="text-center margin-bottom-20">
						<%--<img src="assets/img/avatar.jpg" class="img-circle avatar" alt="">	
						<div class="display-block font-size-20 color-blue-grey-700">John Doe</div>
					--%></div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_username" runat="server" class="form-control input-lg" placeholder="Username"></asp:TextBox>
					</div>
                     
					<div class="form-group">
						<asp:TextBox ID="tb_password" runat="server" class="form-control input-lg" placeholder="Password"  type="password"></asp:TextBox>
                        <%--<input type="password" name="password" id="password" class="form-control input-lg" placeholder="Password" data-bv-field="password">
					<small data-bv-validator="notEmpty" data-bv-validator-for="password" class="help-block" style="display: none;">The password is required and can't be empty</small>--%>

					</div>  
				
					 <asp:Button ID="submitLogIn" class="btn btn-dark bg-light-green-500 padding-10 btn-block color-white" runat="server" Text="Sign in" OnClick="submitLogIn_Click"/>
                    <asp:Label ID="logerror" runat="server" Text="" style="display:none;background-color: red;color: blue;padding: 5px;border-radius: 5px;position: relative;top: 20px;"></asp:Label>
                    <%--<button type="submit" class="btn btn-dark bg-green-500 padding-10 btn-block color-white"><i class="ion-log-in"></i> Sign in</button>  --%>
				</div>
			
			<div class="panel-footer padding-md no-margin no-border bg-blue-grey-500 text-center color-white">© 2015 EIDEAS TECHNOLOGIES.</div>
		</div>
	</div>
	<!-- END CONTENT -->
</asp:Content>
