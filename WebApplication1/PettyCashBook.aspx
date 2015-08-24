<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PettyCashBook.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bs-texteditor {
            height: 60px;
        }

        .form-control[readonly] {
            cursor: default;
            background-color: #eee;
            opacity: 1;
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
                $('#<%= hfAvailableBalance.ClientID %>').val(parseFloat($('#<%= PCB_Available_Balance_Amount.ClientID %>').val()));

                if ($('#ContentPlaceHolder1_cmdSubmit').val() == 'Update') {

                    if (parseFloat($('#<%= PCB_Max_Amount.ClientID %>').val()) < parseFloat($('#<%= PCB_Available_Balance_Amount.ClientID %>').val())) {
                        alert("Can not edit the float that will result in being lower than the available balance.\nPlease create a new petty cash book");
                        return false;
                    }
                }
            });
            //$(document).on('keyup', '#ContentPlaceHolder1_PCB_Max_Amount', function () {

                //if ($('#ContentPlaceHolder1_cmdSubmit').val() != 'Update') {
                   // $('#<%= PCB_Available_Balance_Amount.ClientID %>').val(parseFloat($(this).val()));
               // }

            // });
            
        });



    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper bg-grey-100">
        <!-- BEGIN PAGE HEADING -->
        <div class="page-head">
            <h1 class="page-title"><small>Petty Cash Book</small></h1>
        </div>
        <!-- END PAGE HEADING -->

        <div class="container-fluid">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        <div class="panel-title bg-transparent">
                            <%--<div class="panel-head">Inputs</div>
										<div class="panel-tools">
											<a href="#" data-toggle="dropdown"><i class="ion-gear-a"></i></a>  
											<ul class="dropdown-menu pull-right margin-right-10">
												<li>
													<a href="#"><i class="ion-gear-a"></i> Settings </a>
												</li>
												<li>
													<a href="#"><i class="ion-ios-printer"></i> Print </a>
												</li>
												<li>
													<a href="#"><i class="ion-refresh"></i> Refresh </a>
												</li>
											</ul>
											<a href="#" class="panel-refresh"><i class="ion-refresh"></i></a>
											<a href="#" class="panel-close"><i class="ion-close"></i></a>
										</div>--%>
                        </div>
                        <div class="panel-body no-padding-left no-padding-right">
                            <%--<div class="padding-left-40">
										<h3 class="color-grey-700 margin-top-10">Basic Inputs</h3>
										<p class="text-light margin-bottom-40">Individual form controls automatically receive some global styling. All textual <code>input</code>, <code>textarea</code>, and <code>select</code> elements with .form-control are set to width: 100%; by default. Wrap labels and controls in .form-group for optimum spacing.</p>
									</div>
                            --%>
                            <div class="form-horizontal">

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label1" runat="server" Text="Petty Cash Book Name"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox class="form-control" ID="PCB_Name" runat="server" placeholder="Input Petty Cash Book Name" ValidationGroup="EventCat"></asp:TextBox>
                                        <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="PCB_Name" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvPCB_Name" runat="server" Display="Dynamic" ErrorMessage="The name already exists" ControlToValidate="PCB_Name" OnServerValidate="cvPCB_Name_ServerValidate" ForeColor="Red" Font-Names="verdana" Font-Size="8pt" ValidationGroup="EventCat"></asp:CustomValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label2" runat="server" Text="Petty Cash Book Code"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox class="form-control" ID="PCB_Code" runat="server" placeholder="Input Petty Cash Book Code" ValidationGroup="EventCat"></asp:TextBox>
                                        <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="PCB_Code" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvPCB_Code" runat="server" Display="Dynamic" ErrorMessage="The code already exists" ControlToValidate="PCB_Code" OnServerValidate="cvPCB_Code_ServerValidate" ForeColor="Red" Font-Names="verdana" Font-Size="8pt" ValidationGroup="EventCat"></asp:CustomValidator>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label3" runat="server" Text="Float"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox class="form-control" ID="PCB_Max_Amount" runat="server" placeholder="Input the Maximum Amount" ValidationGroup="EventCat"></asp:TextBox>

                                        <asp:RequiredFieldValidator InitialValue="" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="PCB_Max_Amount" ErrorMessage="Input field can not be empty" ForeColor="Red" ValidationGroup="EventCat"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="PCB_Max_Amount" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" ValidationGroup="EventCat" />
                                       
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label4" runat="server" Text="Available Balance"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox class="form-control" ID="PCB_Available_Balance_Amount" runat="server" AutoPostBack="true" ViewStateMode="Enabled"></asp:TextBox>
                                                <asp:HiddenField ID="hfAvailableBalance" runat="server" />
                                            </ContentTemplate>
                                            <%--<Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPCBCode" EventName="SelectedIndexChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBAvailableBalance" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="PCBMaxAmount" EventName="TextChanged"/>
                                                            <asp:AsyncPostBackTrigger ControlID="AmountToBeReimbursed" EventName="TextChanged"/>
                                                      
                                                    </Triggers>	--%>
                                        </asp:UpdatePanel>



                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-2">
                                        <div class="control-label">
                                            <asp:Label ID="Label5" runat="server" Text="Remark"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:TextBox class="form-control bs-texteditor wysihtml5-editor" ID="PCB_Remark" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group no-margin-left no-margin-right margin-bottom-20 border-bottom-1 padding-bottom-20 border-grey-100">
                                    <div class="col-lg-8">
                                    </div>
                                    <div class="col-lg-3">

                                        <%--<span onclick="return confirm('Are you sure you want to Submit?')">--%>
                                            <asp:Button ID="cmdSubmit" runat="server" OnClientClick="javascript:return ConfirmSubmit()" Text="&nbsp;&nbsp;Save&nbsp;&nbsp;" class="btn btn-success btn-icon-right margin-right-5" Style="float: right;" CommandName="SAVE" OnClick="cmdSubmit_Click" ValidationGroup="EventCat" />
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
                        <%--<div class="panel-title bg-white no-border">
									<div class="panel-head">Data Table</div>
									<div class="panel-tools">
									<a href="#" data-toggle="dropdown"><i class="ion-gear-a"></i></a>  
									<ul class="dropdown-menu pull-right margin-right-10">
										<li>
											<a href="#"><i class="ion-gear-a"></i> Settings </a>
										</li>
										<li>
											<a href="#"><i class="ion-ios-printer"></i> Print </a>
										</li>
										<li>
											<a href="#"><i class="ion-refresh"></i> Refresh </a>
										</li>
                                    </ul>
									<a href="#" class="panel-refresh"><i class="ion-refresh"></i></a>
									<a href="#" class="panel-close" data-effect="fadeOutUp"><i class="ion-close"></i></a>
								</div>
								</div>--%>
                        <div class="panel-body no-padding-top bg-white">
                            <h3 class="color-grey-700">Details Grid View</h3>
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <%--<div class="row">
                                            <div class="col-xs-6">
                                                <div id="example1_length" class="dataTables_length">
                                                <label>
                                                    <select size="1" name="example1_length" aria-controls="example1">
                                                        <option value="10" selected="selected">10</option>
                                                        <option value="25">25</option>
                                                        <option value="50">50</option>
                                                        <option value="100">100</option>
                                                    </select> records per page
                                                </label>
                                                </div>
                                            </div>
                                            <div class="col-xs-6">
                                                <div class="dataTables_filter" id="example1_filter">
                                                    <label>Search: <input type="text" aria-controls="example1"></label>
                                                </div>
                                            </div>
                                        </div>--%>

                                <%--<table id="example1" class="table table-bordered table-striped dataTable" aria-describedby="example1_info">
													<thead>
														<tr role="row">
                                                            <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" style="width: 186px;" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Rendering engine</th>
                                                            <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" style="width: 216px;" aria-label="Browser: activate to sort column ascending">Browser</th>
                                                            <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" style="width: 197px;" aria-label="Platform(s): activate to sort column ascending">Platform(s)</th>
                                                            <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" style="width: 160px;" aria-label="Engine version: activate to sort column ascending">Engine version</th>
                                                            <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" style="width: 119px;" aria-label="CSS grade: activate to sort column ascending">CSS grade</th>
														</tr>
													</thead>
													
													<%--<tfoot>
														<tr><th rowspan="1" colspan="1">Rendering engine</th><th rowspan="1" colspan="1">Browser</th><th rowspan="1" colspan="1">Platform(s)</th><th rowspan="1" colspan="1">Engine version</th><th rowspan="1" colspan="1">CSS grade</th></tr>
													</tfoot>--%>
                                
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="55px" Width="949px" class="table table-bordered table-striped dataTable" DataKeyNames="Id_Petty_Cash_Book" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                    <Columns>
                                        <asp:BoundField DataField="Petty_Cash_Book_Name" HeaderText="Petty Cash Book Name" />
                                        <asp:BoundField DataField="Petty_Cash_Book_Code" HeaderText="Petty Cash Book Code" />
                                        <asp:BoundField DataField="Petty_Cash_Book_Max_Amount" HeaderText="Float" />
                                        <asp:BoundField DataField="Available_Balance_Amount" HeaderText="Available Balance" />
                                        <asp:BoundField DataField="Petty_Cash_Book_Remark" HeaderText="Remark" />
                                        <asp:BoundField DataField="Created_Date" HeaderText="Created Date" DataFormatString="{0:yyyy-MM-dd}" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <span onclick="return confirm('Are you sure you want to Delete?')">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return Confirm(this);" CausesValidation="false" CommandName="Delete" class="btn btn-danger">Delete</asp:LinkButton>
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                                            <ControlStyle CssClass="btn btn-primary" />
                                        </asp:CommandField>
                                    </Columns>


                                </asp:GridView>

                                <%-- <div class="row">
                                            <div class="col-xs-6">
                                                <div class="dataTables_info" id="example1_info">Showing 1 to 10 of 57 entries</div></div>
                                            <div class="col-xs-6">
                                                <div class="dataTables_paginate paging_bootstrap">
                                                    <ul class="pagination">
                                                        <li class="prev disabled"><a href="#">← Previous</a></li>
                                                        <li class="active"><a href="#">1</a></li>
                                                        <li><a href="#">2</a></li>
                                                        <li><a href="#">3</a></li>
                                                        <li><a href="#">4</a></li>
                                                        <li><a href="#">5</a></li>
                                                        <li class="next"><a href="#">Next → </a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>--%>
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
