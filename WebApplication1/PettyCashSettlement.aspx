<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PettyCashSettlement.aspx.cs" Inherits="WebApplication1.WebForm7" %>
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

          function alertSweet() {
              alert("Petty Cash Id is not valid");
              return false;
          }

          function ConfirmSubmit() {
              Page_ClientValidate();
              if (Page_IsValid) {
                  return confirm('Are you sure you want to Submit?');
              }
              return Page_IsValid;
          }

          $(document).ready(function () {

              $(document).on('keyup', '#<%= idPrePV.ClientID %>', function () {
                  $('#<%= hfVoucherID.ClientID %>').val(parseInt($('#<%= idPrePV.ClientID %>').val()));
              });

              $("#<%= cmdSubmit.ClientID %>").on("click", function () {
                  $('#<%= hfnetcashOutAmount.ClientID %>').val(parseFloat($('#<%= netcashOutAmount.ClientID %>').val()));
                  if (parseFloat($('#<%= cashOutAmount.ClientID %>').val()) < parseFloat($('#<%= cashInAmount.ClientID %>').val())) {
                      alert("Cash in amount can not exceed the cash out amount");
                      return false;
                  }
              });

              $(document).on('keyup', '#ContentPlaceHolder1_cashInAmount', function () {
                  $('#<%= netcashOutAmount.ClientID %>').val(parseFloat($('#<%= cashOutAmount.ClientID %>').val()) - parseFloat($('#<%= cashInAmount.ClientID %>').val()));
              });

          });
  
      </script> 

     
    idPrePV

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper bg-grey-100">
        <!-- BEGIN PAGE HEADING -->
        <div class="page-head">
            <h1 class="page-title"><small>Petty Cash Voucher Settlement</small></h1>
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

                                <div class="form-group btn-inline no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label12" runat="server" Text="Petty Cash Voucher Id"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-lg-4">
                                        <div class="input-group">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox class="form-control" ID="idPrePV" runat="server" AutoPostBack="false" placeholder="Input Voucher Id (Pre-Payment)"></asp:TextBox>

                                                    <asp:HiddenField ID="hfVoucherID" runat="server" />
                                                    <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator1" Display="None" runat="server" ControlToValidate="idPrePV" ErrorMessage="You have not entered the Voucher ID" ForeColor="Red" ValidationGroup="EventSearch"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="idPrePV" Type="Integer" Operator="DataTypeCheck" Display="None" ErrorMessage="Voucher ID must be an integer!" ValidationGroup="EventSearch"></asp:CompareValidator>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="EventSearch"/>
                                                    <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator2" Display="None" runat="server" ControlToValidate="idPrePV" ErrorMessage="You have not entered the Voucher ID" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="idPrePV" Type="Integer" Operator="DataTypeCheck" Display="None" ErrorMessage="Voucher ID must be an integer!" ValidationGroup="EventCat"></asp:CompareValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="PCBAvailableBalance" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPCCName" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPCCCode" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="cashOutAmount" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="receivedBy" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="businessPurpose" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="PCV_Remark" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="idPrePV" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccount" />
                                                    <asp:AsyncPostBackTrigger ControlID="hfIDLedgerAccountBCF" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="input-group-btn">
														<asp:Button ID="searchID" runat="server" class="btn btn-primary" Text="Search" OnClick="searchID_Click" ValidationGroup="EventSearch"></asp:Button>
													</span>
                                            <%--<button class="btn btn-primary" type="button"><i class="ion-search"></i></button>--%>
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
                                            <asp:HiddenField ID="hfSearchID" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label4" runat="server" Text="Petty Cash Book Name"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="ddlPCBName" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                                <asp:HiddenField ID="hfPCBID" runat="server" />
                                            </ContentTemplate>
                                            <%--<Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged" />
                                                    </Triggers>--%>
                                        </asp:UpdatePanel>

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label5" runat="server" Text="Petty Cash Book Code"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="ddlPCBCode" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                            </ContentTemplate>
                                            <%--<Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged" />
                                                        </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label10" runat="server" Text="Available Balance"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="PCBAvailableBalance" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>

                                            </ContentTemplate>
                                            <%--<Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                    </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label1" runat="server" Text="Petty Cash Category Name"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="ddlPCCName" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                                <asp:HiddenField ID="hfPCCID" runat="server" />
                                                <asp:HiddenField ID="hfIDLedgerAccount" runat="server" />
                                                <asp:HiddenField ID="hfIDLedgerAccountBCF" runat="server" />
                                            </ContentTemplate>
                                            <%--<Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCCCode" EventName="SelectedIndexChanged" />
                                                        </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label2" runat="server" Text="Petty Cash Category Code"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="ddlPCCCode" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                            </ContentTemplate>
                                            <%--<Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCCName" EventName="SelectedIndexChanged" />
                                                        </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label6" runat="server" Text="Cash Out Amount"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="cashOutAmount" runat="server" ReadOnly="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label7" runat="server" Text="Received By"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="receivedBy" runat="server" ReadOnly="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label3" runat="server" Text="Cash In Amount"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>                                               
                                                <asp:TextBox class="form-control" ID="cashInAmount" runat="server" AutoPostBack="false" OnTextChanged="cashInAmount_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator5" Display="None" runat="server" ControlToValidate="cashInAmount" ErrorMessage="Cash In Amount is not entered" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cashInAmount" Display="None" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Cash In Amount must be an integer!" ValidationGroup="EventCat" />                                              																						       
                                                <asp:HiddenField ID="hfUpdatedAV" runat="server" />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="EventCat"/>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="netcashOutAmount" EventName="TextChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="hfUpdatedAV" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label11" runat="server" Text="Net Cash out Amount"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="netcashOutAmount" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hfnetcashOutAmount" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label9" runat="server" Text="Business Purpose"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="businessPurpose" runat="server"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label8" runat="server" Text="Remark"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="PCV_Remark" runat="server"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-8">
                                    </div>
                                    <div class="col-lg-3">
                                        <%--<asp:Button ID="Button1" runat="server" Text="Submit Voucher" class="btn btn-success btn-icon-right margin-right-15" style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click"/> --%>
                                        <asp:Button ID="cmdSubmit" runat="server" OnClientClick="javascript:return ConfirmSubmit()" Text="Settle Voucher" class="btn btn-success btn-icon-right margin-right-15" Style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click" ValidationGroup="EventCat" />
                                    </div>
                                    <div class="col-lg-1">
                                        <%--<asp:Button ID="Button1" runat="server" Text="&nbsp;&nbsp;Clear&nbsp;&nbsp;" class="btn btn-danger btn-icon-right margin-right-5" style="float: right;" OnClick="cmdClear_Click" />--%>
                                        <asp:Button ID="cmdClear" runat="server" Text="&nbsp;&nbsp;Clear&nbsp;&nbsp;" class="btn btn-danger btn-icon-right margin-right-5" Style="float: right;" OnClick="cmdClear_Click" />
                                    </div>
                                </div>



                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.col -->

            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel no-border ">

                        <div class="panel-body no-padding-top bg-white">
                            <h3 class="color-grey-700">Details Grid View</h3>
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">



                                <asp:GridView ID="pcvsGrid" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Settlement,Id_Petty_Cash_Voucher,Id_Petty_Cash_Book,Id_Petty_Cash_Category" OnRowCommand="pcvsGrid_RowCommand" OnRowDeleting="pcvsGrid_RowDeleting" OnSelectedIndexChanged="pcvsGrid_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Id_Petty_Cash_Voucher" HeaderText="Voucher Id" />
                                        <asp:BoundField DataField="Petty_Cash_Book_Name" HeaderText="Petty Cash Book Name" />
                                        <%-- <asp:BoundField DataField="Petty_Cash_Book_Code" HeaderText="Petty Cash Book Code" />--%>
                                        <asp:BoundField DataField="Petty_Cash_Category_Name" HeaderText="Petty Cash Category Name" />
                                        <%--<asp:BoundField DataField="Petty_Cash_Category_Code" HeaderText="Petty Cash Category Code" />--%>
                                        <asp:BoundField DataField="Cash_Out_Amount" HeaderText="Cash Out Amount" />
                                        <asp:BoundField DataField="Cash_In_Amount" HeaderText="Cash In Amount" />
                                        <asp:BoundField DataField="Net_Cash_Out_Amount" HeaderText="Net Cash Out Amount" />
                                        <asp:BoundField DataField="Petty_Cash_Voucher_Remark" HeaderText="Remark" />
                                        <asp:BoundField DataField="Created_Date" HeaderText="Voucher Settled Date" DataFormatString="{0:yyyy-MM-dd}" />

                                    </Columns>


                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                    <!-- /.x-->
                </div>
                <!-- /.col -->
            </div>
            <!-- /. row -->

        </div>
        <!-- /.container-fluid -->

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

    </div>
    <!-- /.wrapper -->




</asp:Content>
