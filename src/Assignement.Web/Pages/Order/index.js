$(function () {
    var l = abp.localization.getResource("Assignement");
    var orderService = assignement.orders.order;
    //Defining Modals
   
    var editModal = new abp.ModalManager(abp.appPath + 'Order/EditModal');


    var getFilter = function () {
        return {
            filter: $("#FilterText").val()

        };
    };


    //Biding List With Table
    var dataTable = $("#OrdersTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        ordering: false,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(orderService.getList, getFilter),
        columnDefs: [
            { data: "order.number" },
            { data: "order.name" },

            {
                data: "order.date",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, {
                            locale: abp.localization.currentCulture.name
                        }).toLocaleString();
                }
            },
            {
                data: "customer.name",

            },
            {
                data: "order.orderType",
                render: function (data) {
                    return l('Enum:OrderType:' + data);
                }

            },
            {
                data: "order.status",
                render: function (data) {
                   return l('Enum:OrderStatus:' + data);
                 
                     
                }
            },
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Assignement.Orders.Edit'),
                                action: function (data) {

                                    editModal.open({ id: data.record.order.id });
                                }
                            },

                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Assignement.Orders.Delete'),
                                confirmMessage: function () {
                                    return l("OrderDeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    orderService.delete(data.record.order.id)
                                        .then(function () {
                                            abp.notify.info(l("OrderSuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            },
                            {
                                text: l("ConfirmOrder"),
                                visible: abp.auth.isGranted('Assignement.Orders.Update') || function (data) {

                                    return data.order.status==0
                                },
                                confirmMessage: function () {
                                    return l("ConfrimConfirmationMessage");
                                },
                                action: function (data) {
                                    orderService.confirmOrder(data.record.order.id)
                                        .then(function () {
                                            abp.notify.info(l("OrderSuccessfullyConfirm"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            },
                            {
                                text: l("DispatchOrder"),
                                visible: abp.auth.isGranted('Assignement.Orders.Update') || function (data) {

                                    return data.order.status == 1
                                },
                                confirmMessage: function () {
                                    return l("DispatchConfirmationMessage");
                                },
                                action: function (data) {
                                    orderService.dispatchOrder(data.record.order.id)
                                        .then(function () {
                                            abp.notify.info(l("OrderSuccessfullyDispatch"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            },
                            {
                                text: l("ReceiveOrder"),
                                visible: abp.auth.isGranted('Assignement.Orders.Update') || function (data) {

                                    return data.order.status == 3
                                },
                                confirmMessage: function () {
                                    return l("ReceiveConfirmationMessage");
                                },
                                action: function (data) {
                                    orderService.receiveOrder(data.record.order.id)
                                        .then(function () {
                                            abp.notify.info(l("OrderSuccessfullyReceive"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            },
                            {
                                text: l("CancelOrder"),
                                visible: abp.auth.isGranted('Assignement.Orders.Update') || function (data) {

                                    return data.order.status == 0 || data.order.status==1
                                },
                                confirmMessage: function () {
                                    return l("CancelConfirmationMessage");
                                },
                                action: function (data) {
                                    orderService.cancelOrder(data.record.order.id)
                                        .then(function () {
                                            abp.notify.info(l("OrderSuccessfullyCancel"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },

        ]
    }));




  
    //After Updating Customer Reload List
    editModal.onResult(function () {
        abp.notify.info(l("OrderSuccessfullyUpdated"));
        dataTable.ajax.reload();
    });



    $("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });






});
