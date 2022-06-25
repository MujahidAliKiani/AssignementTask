$(function () {
    var l = abp.localization.getResource("Assignement");
    var customerService = assignement.customers.customer;
    //Defining Modals
    var createModal = new abp.ModalManager(abp.appPath + 'Customer/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Customer/EditModal');
    var createOrderModal = new abp.ModalManager(abp.appPath + 'Customer/CreateOrderModal');

    var getFilter = function () {
        return {
            filter: $("#FilterText").val()
           
        };
    };

   
    //Biding List With Table
    var dataTable = $("#CustomersTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        ordering: false,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(customerService.getList, getFilter),
        columnDefs: [
           
            { data: "name" },
           
            {
                data: "location",
               
            },
        
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Assignement.Customers.Edit'),
                                action: function (data) {
                                
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l("AddOrder"),
                                visible: abp.auth.isGranted('Assignement.Orders.Create'),
                                action: function (data) {

                                    createOrderModal.open({ id: data.record.id });
                                }
                            },
                          
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Assignement.Customers.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    customerService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },

        ]
    }));




    //After Creating Customer Reload List
    createModal.onResult(function () {
        abp.notify.info(l("SuccessfullyAdded"));
        dataTable.ajax.reload();
    });
    //After Updating Customer Reload List
    editModal.onResult(function () {
        abp.notify.info(l("SuccessfullyUpdated"));
        dataTable.ajax.reload();
    });
    createOrderModal.onResult(function () {
        abp.notify.info(l("OrderSuccessfullyAdded"));
        dataTable.ajax.reload();
    });
    //Open Customer Create Model
    $('#NewCustomerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

  

 

    
});
