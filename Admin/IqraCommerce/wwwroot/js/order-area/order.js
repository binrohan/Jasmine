// TODO: Search Content [X]
// TODO: Dropdown not loading
// TODO: Add textarea for excerpt
// TODO: Category select
// TODO: Remove vat [X]

import { editBtn, imageBtn, menuBtn, fileBtn, eyeBtn, flashBtn } from "../buttons.js";
import { orderStatus } from "../dictionaries.js";
import { filter, liveRecord, trashRecord } from "../filters.js";
import { url } from '../utils.js';

(function () {
    const controller = 'Order';

    $(document).ready(() => {
        $('#add-record').click(add);
    });

    const columns = () => [
        { field: 'OrderNumber', filter: true, add: false },
        { field: 'OrderStatus', filter: true, add: false, bound: orderStatusBound },
        { field: 'CustomerPhone', filter: true, add: false },
        { field: 'PayableAmount', filter: true, add: false },
        { field: 'PaidAmount', filter: true, add: false },
        { field: 'PaymentLeft', filter: true, add: false },
        { field: 'TotalProducts', filter: true, add: false },
        { field: 'TotalQuantity', filter: true, add: false },
        { field: 'Address', filter: true, add: false },
        { field: 'Remarks', title: 'Remarks', Width: '255px', add: false },
        { field: 'CreatedBy', title: 'Creator', add: false },
        { field: 'CreatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Creation Date', add: false },
        { field: 'UpdatedBy', title: 'Updator', add: false },
        { field: 'UpdatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Last Updated', add: false },
    ];

    // Add / Edit popup config
    function popup(options) {
        
    };

    function add() {
        popup({ title: 'Create New Brand', action: 'add' });
    };

    function changeStatus(row) {
        row.Remarks = '';
        Global.Add({
            name: 'change-order-status',
            title: 'Order Status',
            model: row,
            columns: [],
            dropdownList: [
                {
                    title: 'Change Status',
                    Id: 'IsVisible',
                    dataSource: [
                        { text: 'Pending', value: 0 },
                        { text: 'Confirmed', value: 1 },
                        { text: 'Processing', value: 2 },
                        { text: 'Delivering', value: 3 },
                        { text: 'Delived', value: 4 },
                        { text: 'Cancel', value: 5 }
                    ],
                    position: 1
                }
            ],
            additionalField: [
                { field: 'Remarks', title: 'Remarks', position: 2 }
            ],
            onSubmit: function (formModel, data, model) {
                formModel.Id = model.Id
                formModel.ActivityId = window.ActivityId;
            },
            onSaveSuccess: function () {
                tabs.gridModel?.Reload();
            },
            saveChange: `/${controller}/ChangeStatus`,
        });
    };

    const orderDetails = (row) => {
        Global.Add({
            orderId: row.Id,
            customerId: row.CustomerId,
            name: 'order-details' + row.Id,
            url: '/js/order-area/order-details-modal.js',
        });
    }

    function orderStatusBound(td) {
        switch (this.OrderStatus) {
            case orderStatus.pending:
                td.html('Pending');
                break;

            case orderStatus.processing:
                td.html('Processing');
                break;

            case orderStatus.delivering:
                td.html('Delivering');
                break;

            case orderStatus.delivered:
                td.html('Delivered');
                break;

            case orderStatus.cancelledByCustomer:
                td.html('Cancelled By Customer');
                break;

            case orderStatus.cancelledByCustomer:
                td.html('Cancelled By Admin');
                break;

            default:
                td.html('Unknown');
                break;
        }
    }

    //Tab config
    const tab = (id, title, actions = [], status) => {
        return {
            Id: id,
            Name: title.toLowerCase(),
            Title: title,
            filter: [filter('OrderStatus', status)],
            remove: false,
            actions: actions,
            onDataBinding: () => { },
            rowBound: () => { },
            columns: columns(),
            Printable: { container: $('void') },
            Url: 'Get',
        }
    }

    const detailsAction = {
        click: orderDetails,
        html: eyeBtn()
    }

    const changeStatusAction = {
        click: changeStatus,
        html: flashBtn()
    }

    //Tabs config
    const tabs = {
        container: $('#page_container'),
        Base: {
            Url: `/${controller}/`,
        },
        items: [
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB75', 'Pending', [detailsAction, changeStatusAction], orderStatus.pending),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB76', 'Confirmed', [detailsAction, changeStatusAction], orderStatus.confirmed),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB77', 'Processing', [detailsAction, changeStatusAction], orderStatus.processing),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB78', 'Delivering', [detailsAction, changeStatusAction], orderStatus.delivering),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB79', 'Delivered', [detailsAction, changeStatusAction], orderStatus.delivered),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB70', 'Cancelled-Customer', [detailsAction], orderStatus.cancelledByCustomer),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB71', 'Cancelled-Admin', [detailsAction], orderStatus.cancelledByCustomer),
        ],
        periodic: {
            container: '.filter_container',
            type: 'Today',
        }
    };

    //Initialize Tabs
    Global.Tabs(tabs);
    tabs.items[0].set(tabs.items[0]);
})();