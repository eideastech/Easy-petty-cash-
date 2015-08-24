<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PettyCashReimbursement.aspx.cs" Inherits="WebApplication1.WebForm3" %>

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

    <script>
        function ConfirmSubmit() {
            Page_ClientValidate();
            if (Page_IsValid) {
                return confirm('Are you sure you want to Submit?');
            }
            return Page_IsValid;
        }

       
        $(document).ready(function () {
            $("#<%= cmdSubmit.ClientID %>").on("click", function () {

                if (parseFloat($('#<%= AmountToBeReimbursed.ClientID %>').val()) < parseFloat($('#<%= reimburseAmount.ClientID %>').val())) {
                    return confirm("Are you sure you want to Reimburse an amount that would result in exceeding the float");
                }

            });
            $(document).on('keyup', '#ContentPlaceHolder1_reimburseAmount', function () {
                $('#<%= bcf.ClientID %>').val(parseFloat($('#<%= PCBAvailableBalance.ClientID %>').val()) + parseFloat($(this).val()));
            });

        });


        
        
        
       
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="wrapper bg-grey-100">
	 <!-- BEGIN PAGE HEADING -->
     <div class="page-head">
				<h1 class="page-title"><small>Petty Cash Reimbursement</small></h1>				
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
                                                    <asp:Label ID="Label4" runat="server" Text="Petty Cash Book Name"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                    <ContentTemplate>                                                                                             
                                                        <asp:DropDownList ID="ddlPCBName" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPCBName_SelectedIndexChanged">                                                                                                                                                                                                                       
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfPCBID" runat="server" />
                                                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlPCBName" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBAvailableBalance" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBMaxAmount" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="AmountToBeReimbursed" EventName="TextChanged"/>
                                                      
                                                    </Triggers>	
                                                </asp:updatepanel>
                                                																					        
                                            </div>
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label5" runat="server" Text="Petty Cash Book Code"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4"> 
                                                 <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                         
                                                            <asp:DropDownList ID="ddlPCBCode" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPCBCode_SelectedIndexChanged">                                                                                                                                              
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="ddlPCBCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>	
                                                       <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBAvailableBalance" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBMaxAmount" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="AmountToBeReimbursed" EventName="TextChanged"/>
                                                           
                                                    </Triggers>	
                                                 </asp:updatepanel>																						        
                                            </div>
										</div>

                                         <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label10" runat="server" Text="Available Balance"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                                                                              																							                                                                                                 
                                                     <asp:TextBox class="form-control" ID="PCBAvailableBalance" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>   
                                                        </ContentTemplate>
                                                    <%--<Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                                </asp:updatepanel>
                                            </div>           
                                             <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label12" runat="server" Text="Float"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                                                                              																							                                                                                                   
                                                     <asp:TextBox class="form-control" ID="PCBMaxAmount" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>   
                                                        </ContentTemplate>
                                                   <%-- <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                                </asp:updatepanel>
                                            </div>                                                                                      
										</div>

										<div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label pull-left">                                                 
                                                    <asp:Label ID="Label1" runat="server" Text="Amount that should be Reimbursed"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                                                                              																							                                                                                                   
                                                            <asp:TextBox class="form-control" ID="AmountToBeReimbursed" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>																							        
                                                        </ContentTemplate>
                                                   <%-- <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                                </asp:updatepanel>                                                                                             
                                            </div>                                                                                        
										</div>
                                                                                                                      
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label6" runat="server" Text="Reimburse Amount"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                  <asp:updatepanel runat="server">
                                                        <ContentTemplate>
                                                                <%--<asp:TextBox class="form-control" ID="reimburseAmount" runat="server" placeholder="Input Reimburse Amount" OnTextChanged="reimburseAmount_TextChanged"></asp:TextBox>--%>                                                                                                                                          																							                                                                                                   
                                                                <asp:TextBox class="form-control" ID="reimburseAmount" runat="server" placeholder="Input Reimburse Amount" ></asp:TextBox>
                                                                <asp:HiddenField ID="hfReimburseAmount" runat="server" />
                                                            	<asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="reimburseAmount" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                            	<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="reimburseAmount" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" ValidationGroup="EventCat"/>																			        
                                                        </ContentTemplate>
                                                   <%-- <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                                </asp:updatepanel>                                                                                           
                                            </div>
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label7" runat="server" Text="Balance Carrying Forward"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                                                                              																							                                                                                                   
                                                                <asp:TextBox class="form-control" ID="bcf" runat="server"></asp:TextBox>
                                                                <asp:HiddenField ID="hfBCF" runat="server" />																				        
                                                        </ContentTemplate>
                                                   <%-- <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                                </asp:updatepanel>                                                                                             
                                            </div>
										</div>
                                        
                                        

                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label8" runat="server" Text="Remark"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-10">
                                                 <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="PCR_Remark" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        																														
									    <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-8">                                                 
											</div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="cmdSubmit" OnClientClick="javascript:return ConfirmSubmit()" runat="server" Text="Reimburse" class="btn btn-success btn-icon-right margin-right-15" style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click" ValidationGroup="EventCat"/>                                                            
                                            </div>
                                            <div class="col-lg-1">                                                 
                                                 <asp:Button ID="cmdClear" runat="server" Text="&nbsp;&nbsp;Clear&nbsp;&nbsp;" class="btn btn-danger btn-icon-right margin-right-5" style="float: right;" CommandName="CLEAR" OnClick="cmdClear_Click"/>
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
                                        

                                            <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Category" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">--%>
                                            <asp:GridView ID="pcrGrid" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Reimbursement" >
                                                <Columns>
                                                    <asp:BoundField DataField="Petty_Cash_Book_Name" HeaderText="Petty Cash Book Name" />
                                                    <asp:BoundField DataField="Petty_Cash_Book_Code" HeaderText="Petty Cash Book Code" />
                                                    <asp:BoundField DataField="Petty_Cash_Book_Max_Amount" HeaderText="Float" />
                                                    <asp:BoundField DataField="Reimbursement_Amount" HeaderText="Reimbursed Amount" />
                                                    <asp:BoundField DataField="Balance_Carried_Forward" HeaderText="Balance Carried Forward" />
                                                    <asp:BoundField DataField="Petty_Cash_Reimbursement_Remark" HeaderText="Remark" />
                                                    <asp:BoundField DataField="Created_Date" HeaderText="Date of Reimbursement" DataFormatString="{0:yyyy-MM-dd}" />
                                                </Columns>
                                            
                                            
                                            </asp:GridView>
												
									</div>
                                </div>
                               </div>
                            </div>
     </div><!-- /. row -->
																						      
    </div><!-- /.container-fluid -->
    
      <!-- BEGIN FOOTER -->
	<footer>
					<div class="pull-left">
						<span class="pull-left margin-right-15">© 2015 EIDEAS TECHNOLOGIES.</span>
						<ul class="list-inline pull-left">
							<li><a href="#">Privacy Policy</a></li>
							<li><a href="#">Terms of Use</a></li>
						</ul>
					</div>
				</footer>
    <!-- END FOOTER -->

  </div><!-- /.wrapper -->


</asp:Content>
