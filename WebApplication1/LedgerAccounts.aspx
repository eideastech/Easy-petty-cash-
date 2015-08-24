<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LedgerAccounts.aspx.cs" Inherits="WebApplication1.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
            

        .form-control[readonly]{
            cursor: default;
            background-color: #eee;
            opacity: 1;
        }
            .bs-texteditor{
                height: 60px;
            }
            .display-inline-block {
            display: inline-block !important;
            }
            
        </style>
    <script type="text/javascript">
        function alertSweet() {
            swal({ title: 'No Data Found', type: 'error', confirmButtonColor: '#A90404', showConfirmButton: true });
        }
        
        $(document).ready(function () {

            $("#<%= fromDate.ClientID%>").datepicker({

                format: 'yyyy-mm-dd',
            });
            $("#<%= toDate.ClientID%>").datepicker({

                format: 'yyyy-mm-dd',
            });
            $("#<%= cmdSubmit.ClientID%>").on("click", function () {
                if ($("#<%= fromDate.ClientID%>").val() == "" || $("#<%= toDate.ClientID%>").val() == "") {
                    swal({ title: "The time period is not selected.\nPlease select the time period", type: 'error', confirmButtonColor: '#A90404', showConfirmButton: true });
                    return false;
                }
                
            });
        });
       
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="wrapper bg-grey-100">
	 <!-- BEGIN PAGE HEADING -->
     <div class="page-head">
				<h1 class="page-title"><small>Ledger Account Entries</small></h1>				
	 </div>
	 <!-- END PAGE HEADING -->

    <div class="container-fluid">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>			
	     <div class="row">
				<div class="col-lg-12">
					<div class="panel">
									<div class="panel-title bg-transparent">
										
									</div>
									<div class="panel-body no-padding-left no-padding-right">
									
									<div class="form-horizontal">	
										
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label4" runat="server" Text="Ledger Account Name"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                    <ContentTemplate>                                                                                             
                                                        <asp:DropDownList ID="ddlLAName" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlLAName_SelectedIndexChanged">                                                                                                                                                                                                                       
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfLAID" runat="server" /> 
                                                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" ControlToValidate="ddlLAName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="leGrid" />
                                                    </Triggers>	
                                                </asp:updatepanel>                                               																					        
                                            </div>                                                                                        
										</div>
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label5" runat="server" Text="Report From Date"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                 <div class="input-group datepicker-plugin">
                                                  
                                                            <asp:TextBox class="form-control" ID="fromDate" runat="server" ></asp:TextBox>                                                                                                                                                      
                                                            <%--<asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator> --%>                                                   																																			
                                                        
                                                     <span class="input-group-addon"><i class="ion-calendar"></i></span>	
                                                </div>																					        
                                            </div>


                                              <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label1" runat="server" Text="Report To Date"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                 <div class="input-group datepicker-plugin">
                                                  
                                                            <asp:TextBox class="form-control" ID="toDate" runat="server" ></asp:TextBox>                                                                                                                                                      
                                                            <%--<asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator> --%>                                                   																																			
                                                        
                                                     <span class="input-group-addon"><i class="ion-calendar"></i></span>	
                                                </div>																					        
                                            </div>                                                                                      
										</div>
                                    																														
									    <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-9">                                                 
											</div>
                                            <div class="col-lg-3">                                                                                                                                                                                              
                                                 <asp:Button ID="cmdSubmit" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" class="btn btn-success btn-icon-right margin-right-15" style="float: right;" OnClick="cmdSubmit_Click" ValidationGroup="EventCat"/>
                                            </div>                                           
                                        </div>
                                    </div>
								</div>
							</div>
				</div>
            
		</div>
																						         				
	     <div class="row">
                        <div class="col-lg-12">
							<div class="panel no-border ">                              
                                <div class="panel-body no-padding-top bg-white">
									<h3 class="color-grey-700">Details Grid View</h3>
									<div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">                                        
                                        <asp:updatepanel runat="server">
                                            <ContentTemplate>
                                            <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Category" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">--%>
                                            <asp:GridView ID="leGrid" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Ledger_Entry" >
                                                <Columns>
                                                    <asp:BoundField DataField="Created_Date" HeaderText="Transaction Date" DataFormatString="{0:yyyy-MM-dd}" />
                                                    <asp:BoundField DataField="Post_Payment" HeaderText="Payment Type" />
                                                    <asp:BoundField DataField="Id_Petty_Cash_Voucher" HeaderText="Voucher Id" />
                                                    <asp:BoundField DataField="Petty_Cash_Book_Name" HeaderText="Petty Cash Book Name" />
                                                    <asp:BoundField DataField="Petty_Cash_Book_Code" HeaderText="Petty Cash Book Code" />                                                  
                                                    <asp:BoundField DataField="Petty_Cash_Category_Name" HeaderText="Petty Cash Category Name" />
                                                    <asp:BoundField DataField="Petty_Cash_Category_Code" HeaderText="Petty Cash Category Code" />                                                                                                                                                           
                                                    <asp:BoundField DataField="Debit_Amount" HeaderText="Cash Out Amount" />
                                                    <asp:BoundField DataField="Credit_Amount" HeaderText="Cash In Amount" />
                                                    <%--<asp:BoundField DataField="Balance_Carried_Forward" HeaderText="Balance Carried Forward" /> --%>                                                 
                                                </Columns>                                                                                      
                                            </asp:GridView>
                                            </ContentTemplate>
                                                    <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlLAName" EventName="SelectedIndexChanged" />                                                     
                                                    </Triggers>	
									    </asp:updatepanel>  	
									</div>
                                    <%--<div class="col-xs-6">
                <div class="dataTables_info" id="example2_info"></div>

            </div>--%>
            <%--<div class="col-xs-6">
                <div class="dataTables_paginate paging_bootstrap">
                    <ul class="pagination" style="float: right;">
                        <li class="prev"><a href="#">← Previous</a></li>
                        <li><a href="#">1</a></li>                       
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li><a href="#">Next → </a></li>                        
                    </ul>
                </div>
            </div>--%>
       </div>
      </div>
                           <%-- <div class="row">--%>
            
        <%--</div>--%>
                            </div>
     </div><!-- /. row -->
			
        																			      
    
    </div><!-- /.container-fluid -->
    
      <!-- BEGIN FOOTER -->
	<footer>
					<div class="pull-left">
						<span class="pull-left margin-right-15">© 2015 EIDEAS TECHNOLOGIES.pan>
						<ul class="list-inline pull-left">
							<li><a href="#">Privacy Policy</a></li>
							<li><a href="#">Terms of Use</a></li>
						</ul>
					</div>
				</footer>
    <!-- END FOOTER -->

  </div><!-- /.wrapper -->
</asp:Content>
