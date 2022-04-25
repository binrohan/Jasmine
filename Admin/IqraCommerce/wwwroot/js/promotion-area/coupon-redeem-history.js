import { editBtn } from "../buttons.js";
import { filter, liveRecord, operationType, trashRecord } from '../filters.js';

(function () {
    const controller = 'CouponRedeemHistory';

    $(document).ready(() => {
        $('#add-record').click(add);
    });

    const columns = () => [
        { field: 'Code', title: 'Code', position: 1 },
        { field: 'IsLimited', title: 'Limited', add: false, bound: isLimitedBound},
        { field: 'MinOrderValue', title: 'Min OrderValue', position: 1 },
        { field: 'Count', title: 'Available', position: 1 },
        { field: 'Redeemed', title: 'Used', position: 1 },
        { field: 'Redeemed', title: 'Left', position: 1, bound: leftOverBound },
        { field: 'MaxDiscount', title: 'Max Discount', position: 1 },
        { field: 'MinDiscount', title: 'Min Discount', position: 1 },
        { field: 'StartingAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Starting', position: 5 },
        { field: 'EndingAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Ending', position: 6 },
        { field: 'Remarks', title: 'Remarks', position: 8 },
        { field: 'CreatedBy', title: 'Creator', add: false },
        { field: 'CreatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Creation Date', add: false },
        { field: 'UpdatedBy', title: 'Updator', add: false },
        { field: 'UpdatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Last Updated', add: false },
    ];

    // Add / Edit popup config
    function popup(options) {
        Global.Add({
            name: 'edit-offer-record' + Math.random(),
            model: options.data,
            title: options.title,
            columns: columns(),
            dropdownList: [
                {
                    title: 'Publish',
                    Id: 'IsPublished',
                    dataSource: [
                        { text: 'Yes', value: true },
                        { text: 'No', value: false },
                    ],
                    add: { sibling: 2 },
                    position: 7,
                },
                {
                    title: 'Limited',
                    Id: 'IsLimited',
                    dataSource: [
                        { text: 'Yes', value: true },
                        { text: 'No', value: false },
                    ],
                    add: { sibling: 2 },
                    position: 7,
                },
            ],
            additionalField: [],
            onSubmit: function (formModel, data, model) {
                formModel.Id = model.Id
                formModel.ActivityId = window.ActivityId;
            },
            onSaveSuccess: function () {
                tabs.gridModel?.Reload();
            },
            save: `/${controller}/Create`,
            saveChange: `/${controller}/Edit`,
        });
    };

    function add() {
        popup({ title: 'New Promotion', action: 'add' });
    };

    function edit(model) {
        popup({ data: model, title: 'Edit Promotion', action: 'edit' });
    };

    function isLimitedBound(td) {
        td.html(this.IsLimited ? 'Yes' : 'No');
    }

    function leftOverBound(td){
        td.html(this.Count - this.Redeemed);
    }

    //Tab config
    const tab = (id, title, filters, isDeleted = 0) => {
        return {
            Id: id,
            Name: title.toLowerCase(),
            Title: title,
            filter: filters,
            remove: isDeleted ? false : { save: `/${controller}/Remove` },
            actions: isDeleted ? [] : [
                {
                    click: edit,
                    html: editBtn()
                }],
            onDataBinding: () => { },
            rowBound: () => { },
            columns: columns(),
            Printable: { container: $('void') },
            Url: 'Get',
        }
    }

    const ongoingFilters = [
        liveRecord,
        filter('StartingAt', `'${new Date().format('MM-dd-yyyy')}'`, operationType.lessOrEqual),
        filter('EndingAt', `'${new Date().format('MM-dd-yyyy')}'`, operationType.greaterOrEqual)
    ];

    const upcommingFilters = [
        liveRecord,
        filter('StartingAt', `'${new Date().format('MM-dd-yyyy')}'`, operationType.greaterOrEqual),
    ]

    const pastFilters = [
        liveRecord,
        filter('EndingAt', `'${new Date().format('MM-dd-yyyy')}'`, operationType.lessOrEqual),
    ]

    const deletedFilters = [
        trashRecord
    ]

    //Tabs config
    const tabs = {
        container: $('#page_container'),
        Base: {
            Url: `/${controller}/`,
        },
        items: [
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB79', 'Ongoing', ongoingFilters),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB78', 'Upcomming', upcommingFilters),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB75', 'Past', pastFilters),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB76', 'Deleted', deletedFilters, 1)
        ],
        periodic: {
            container: '.filter_container',
            type: 'ThisMonth',
        }
    };

    //Initialize Tabs
    Global.Tabs(tabs);
    tabs.items[0].set(tabs.items[0]);
})();