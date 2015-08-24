<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PettyCashVoucher.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
                if (parseFloat($('#<%= PCBAvailableBalance.ClientID %>').val()) < parseFloat($('#<%= cashOutAmount.ClientID %>').val())) {
                    alert("Can not cash out an amount that is more than the available balance.\n Please select another Petty Cash Book");
                    return false;
                }
                <%--if (!$('#<%= RadioButtonList1.ClientID %>').is(':checked')) {
                    alert("Payment Type is not selected");
                    return false;
                }--%>


            });
        });


        //$('#element').click(function () {
        //    if ($('#radio_button').is(':checked'))
        //    {
        //        alert("it's not checked");
        //        return false;
        //    }
        //});

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="wrapper bg-grey-100">
	 <!-- BEGIN PAGE HEADING -->
     <div class="page-head">
				<h1 class="page-title"><small>Petty Cash Voucher</small></h1>				
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
                                                        <asp:RequiredFieldValidator InitialValue="0" ID="rfv1" Display="Dynamic" runat="server" ControlToValidate="ddlPCBName" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>					
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged" />
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
                                                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlPCBCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>	
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged" />
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
                                                <%--<asp:TextBox class="form-control" ID="PCBAvailableBalance" runat="server" disabled="" AutoPostBack="true" ></asp:TextBox>--%>	
                                                     <asp:TextBox class="form-control" ID="PCBAvailableBalance" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>   
                                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>
                                                </asp:updatepanel>
                                            </div>                                                                                        
										</div>

										<div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label1" runat="server" Text="Petty Cash Category Name"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                                                                             
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                         
                                                            <asp:DropDownList ID="ddlPCCName" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPCCName_SelectedIndexChanged">                                                        
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hfIDLedgerAccount" runat="server" />
                                                            <asp:HiddenField ID="hfIDLedgerAccountBCF" runat="server" />
                                                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="ddlPCCName" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>	
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCCCode" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccount" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccountBCF" />
                                                        </Triggers>
                                                 </asp:updatepanel>		
                                                																						        
                                            </div>
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label2" runat="server" Text="Petty Cash Category Code"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                                                                             
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                         
                                                            <asp:DropDownList ID="ddlPCCCode" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPCCCode_SelectedIndexChanged">                                                        
                                                            </asp:DropDownList>	
                                                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="ddlPCCCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>	
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCCName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccount" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccountBCF" />                                                       
                                                        </Triggers>
                                                 </asp:updatepanel>	
                                                																							        
                                            </div>
										</div>
                                        
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label3" runat="server" Text="Petty Cash Voucher Id"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4"> 
                                                <asp:updatepanel runat="server">
                                                        <ContentTemplate>                                                                                         
                                                            <asp:TextBox class="form-control" ID="PCV_Id" runat="server"  AutoPostBack="true" ReadOnly="true"></asp:TextBox>	                                                            	
                                                        </ContentTemplate>	
                                                        <%--<Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCCName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccount" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccountBCF" EventName="SelectedIndexChanged" />                                                       
                                                        </Triggers>--%>
                                                 </asp:updatepanel>	
                                               	
                                            </div> 
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label11" runat="server" Text="Payment Type"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                               
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                    <asp:ListItem ID="selectedPost" runat="server" Text="Post-Payment" class="radio radio-theme display-inline-block"></asp:ListItem>
                                                    <asp:ListItem ID="selectedPre" runat="server" Text="Pre-Payment" class="radio radio-theme display-inline-block"></asp:ListItem>
                                                </asp:RadioButtonList> 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>                                                                                                                                         																							                                                                                                
                                            </div> 
                                                                                                                                        
										</div>
                                       
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
											<div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label6" runat="server" Text="Cash Out Amount"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                                                                             
                                                <asp:TextBox class="form-control" ID="cashOutAmount" runat="server" placeholder="Input Cash Amount"></asp:TextBox>
                                                <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="cashOutAmount" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cashOutAmount" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" ValidationGroup="EventCat"/>																							        
                                            </div>
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label7" runat="server" Text="Received By"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                                                                             
                                                <asp:TextBox class="form-control" ID="receivedBy" runat="server" placeholder="Input Person Receievd By"></asp:TextBox>
                                                <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ControlToValidate="receivedBy" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>																							        
                                            </div>
										</div>
                                        
                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label9" runat="server" Text="Business Purpose"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-10">
                                                 <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="businessPurpose" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ControlToValidate="businessPurpose" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                            
                                            </div>
                                        </div>

                                        <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label8" runat="server" Text="Remark"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-10">
                                                 <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="PCV_Remark" runat="server"></asp:TextBox>
                                            </div>
                                        </div>																														
									    <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                            <div class="col-lg-8">                                                 
											</div>
                                            <div class="col-lg-3">
                                                <%--<span onclick="return confirm('Are you sure you want to Submit?')">--%>
                                                    <asp:Button ID="cmdSubmit" runat="server" OnClientClick="javascript:return ConfirmSubmit()" Text="Submit Voucher" class="btn btn-success btn-icon-right margin-right-15" style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click" ValidationGroup="EventCat"/>
                                                <%--</span>--%>                                                                                                                                                                                                                                               
                                            </div>
                                            <div class="col-lg-1">                                                 
                                                 <asp:Button ID="cmdClear" runat="server" Text="&nbsp;&nbsp;Clear&nbsp;&nbsp;" class="btn btn-danger btn-icon-right margin-right-5" style="float: right;" OnClick="cmdClear_Click" />
                                            </div>
                                        </div>
                                    </div>
								</div>
							</div>
				</div><!-- /.col -->
            <asp:HiddenField ID="HiddenField1" runat="server" />
		</div>
																						         				
	     <div class="row">
                        <div class="col-lg-12">
							<div class="panel no-border ">
                              
                                <div class="panel-body no-padding-top bg-white">
									<h3 class="color-grey-700">Details Grid View</h3>
									<div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                        
                                        <div id="reportViewer" runat="server">
                                            <%--<CR:CrystalReportViewer ID="crvLedger" runat="server" AutoDataBind="true"  HasCrystalLogo="False" HasRefreshButton="True" ToolPanelView="None"/>--%>
                                            <%--<CR:CrystalReportViewer ID="crvVoucherReport" runat="server" AutoDataBind="true" ToolPanelView="None" />--%>
                                            <CR:CrystalReportViewer ID="crvPettyCashVoucherReport" runat="server" AutoDataBind="true" ToolPanelView="None" />
                                        </div>
                                            
                                            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Voucher" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                                <Columns>
                                                    <asp:BoundField DataField="Id_Petty_Cash_Voucher" HeaderText="Voucher Id" />
                                                    <asp:BoundField DataField="Payment_Type" HeaderText="Payment Type" />
                                                    <asp:BoundField DataField="Petty_Cash_Book_Name" HeaderText="Petty Cash Book Name" />
                                                    
                                                    <asp:BoundField DataField="Petty_Cash_Category_Name" HeaderText="Category Name" />
                                                                                                                                                           
                                                    <asp:BoundField DataField="Cash_Out_Amount" HeaderText="Cash Out Amount" />
                                                    <asp:BoundField DataField="Business_Purpose" HeaderText="Business Purpose" />
                                                    <asp:BoundField DataField="Received_By" HeaderText="Received By" />
                                                    <asp:BoundField DataField="Petty_Cash_Voucher_Remark" HeaderText="Remark" />
                                                    <asp:BoundField DataField="Created_Date" HeaderText="Cash Out Date" DataFormatString="{0:yyyy-MM-dd}" />
                                                    <asp:BoundField DataField="Edited_Date" HeaderText="Edited Date" DataFormatString="{0:yyyy-MM-dd}" />
                                                    
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <span onclick="return confirm('Are you sure want to Delete?')">
                                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return Confirm(this);" CausesValidation="false" CommandName="Delete" class="btn btn-danger">Delete</asp:LinkButton>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    
                                                </Columns>
                                            
                                            
                                            </asp:GridView>--%>
												
									</div>
                                </div>
                               </div><!-- /.x-->
                            </div><!-- /.col -->
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
