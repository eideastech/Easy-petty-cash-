<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PettyCashCategory.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
            
    </style>
    <script>
        function ConfirmSubmit() {
            Page_ClientValidate();
            if (Page_IsValid) {
                return confirm('Are you sure you want to Submit?');
            }
            return Page_IsValid;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper bg-grey-100">
        <!-- BEGIN PAGE HEADING -->
        <div class="page-head">
            <h1 class="page-title"><small>Petty Cash Category</small></h1>
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
                                            <asp:Label ID="Label1" runat="server" Text="Petty Cash Category Name"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox class="form-control" ID="PCC_Name" runat="server" placeholder="Input Petty Cash Category Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator InitialValue="" ID="rfv1" Display="Dynamic" runat="server" ControlToValidate="PCC_Name" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCatt"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="PCCName" runat="server" Display="Dynamic" ErrorMessage="The name already exists" ControlToValidate="PCC_Name" OnServerValidate="PCCName_ServerValidate1" ForeColor="Red" Font-Names="verdana" Font-Size="8pt" ValidationGroup="EventCatt"></asp:CustomValidator>

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label2" runat="server" Text="Petty Cash Category Code"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox class="form-control" ID="PCC_Code" runat="server" placeholder="Input Petty Cash Category Code"></asp:TextBox>
                                        <asp:RequiredFieldValidator InitialValue="" ID="rfv2" Display="Dynamic" runat="server" ControlToValidate="PCC_Code" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCatt"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvPCC_Code" runat="server" Display="Dynamic" ErrorMessage="The code already exists" ControlToValidate="PCC_Code" OnServerValidate="cvPCC_Code_ServerValidate" ForeColor="Red" Font-Names="verdana" Font-Size="8pt" ValidationGroup="EventCatt"></asp:CustomValidator>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label3" runat="server" Text="Ledger Account Type"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="ddlLedgerAccountType" runat="server" OnSelectedIndexChanged="ddlLedgerAccountType_SelectedIndexChanged" class="form-control input-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="0" ID="rfv3" Display="Dynamic" runat="server" ControlToValidate="ddlLedgerAccountType" ErrorMessage="*" ForeColor="Red" ValidationGroup="EventCatt"></asp:RequiredFieldValidator>
                                    </div>



                                    <%-- <div class="col-lg-2"> 
                                                <div class="control-label">                                                 
                                                    <asp:Label ID="Label4" runat="server" Text="Available Balance"></asp:Label>
                                                </div>
											</div>
                                            <div class="col-lg-4">                                                                                             
                                                <asp:TextBox class="form-control" ID="PCB_Available_Balance_Amount" runat="server"></asp:TextBox>																							        
                                            </div>--%>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-8">
                                    </div>
                                    <div class="col-lg-3">
                                        <%--<span onclick="return confirm('Are you sure you want to Submit?')">--%>
                                            <asp:Button ID="cmdSubmit" runat="server" OnClientClick="javascript:return ConfirmSubmit()" Text="&nbsp;&nbsp;Save&nbsp;&nbsp;" class="btn btn-success btn-icon-right margin-right-5" Style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click" ValidationGroup="EventCatt" />
                                        <%--</span>--%>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Button ID="cmdClear" runat="server" Text="&nbsp;&nbsp;Clear&nbsp;&nbsp;" class="btn btn-danger btn-icon-right margin-right-5" Style="float: right;" OnClick="cmdClear_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.col -->
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel no-border ">

                        <div class="panel-body no-padding-top bg-white">
                            <h3 class="color-grey-700">Details Grid View</h3>
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">



                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Category,Id_Ledger_Account" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Petty_Cash_Category_Name" HeaderText="Petty Cash Category Name" />
                                        <asp:BoundField DataField="Petty_Cash_Category_Code" HeaderText="Petty Cash Category Code" />
                                        <asp:BoundField DataField="Ledger_Account_Name" HeaderText="Ledger Account Type" />
                                        <asp:BoundField DataField="Id_Ledger_Account" HeaderText="Ledger Account Id" Visible="False" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <span onclick="return confirm('Are you sure want to Delete?')">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return Confirm(this);" CausesValidation="false" CommandName="Delete" class="btn btn-danger">Delete</asp:LinkButton>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                                            <ControlStyle CssClass="btn btn-primary" />
                                        </asp:CommandField>
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
