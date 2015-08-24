<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VoucherReport.aspx.cs" Inherits="WebApplication1.VoucherReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
				<h1 class="page-title"><small>Voucher Report</small></h1>				
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
                                                    <asp:Label ID="Label2" runat="server" Text="Petty Cash Book"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">
                                                 <asp:updatepanel runat="server">
                                                    <ContentTemplate>                                                                                             
                                                        <asp:DropDownList ID="ddlPCBName" runat="server" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPCBName_SelectedIndexChanged" >                                                                                                                                                               
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
                                                    <asp:Label ID="Label3" runat="server" Text="Petty Cash Book Code"></asp:Label>
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
									<h3 class="color-grey-700">Petty Cash Voucher Report</h3>
									<div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                      
                                        <div id="reportViewer" runat="server">
                                            <%--<CR:CrystalReportViewer ID="crvLedger" runat="server" AutoDataBind="true"  HasCrystalLogo="False" HasRefreshButton="True" ToolPanelView="None"/>--%>
                                            <CR:CrystalReportViewer ID="crvVoucherReport" runat="server" AutoDataBind="true" ToolPanelView="None" />
                                        </div>
												
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
