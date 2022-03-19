// TODO: clicked on brand name show all coresponding product list
// TODO: CreatedBy name and Updated by name

import { editBtn } from "../buttons.js";

(function () {

    const controller = 'Brand';

    $(document).ready(() => {
        $('#add-record').click(add);
    });

    const columns = () => [
        { field: 'Name', title: 'Name', filter: true, add: { sibling: 2 } },
        { field: 'Description', title: 'Description', Width: '550px', add: { sibling: 2 } },
        { field: 'Number of Products', title: 'ProductCount', add: false },
        { field: 'Remarks', title: 'Remarks', Width: '255px', add: { sibling: 2 } },
        { field: 'CreatedBy', title: 'Creator', add: false },
        { field: 'CreatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Creation Date',  add: false },
        { field: 'UpdatedBy', title: 'Updator',  add: false },
        { field: 'UpdatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Last Updated',  add: false },
    ];

    // Add / Edit popup config
    function AddBase(options, grid) {
        Global.Add({
            name: 'edit-brand-record',
            model: options.data,
            title: options.title,
            columns: columns(),
            dropdownList: [
                {
                    title: 'Show in client',
                    Id: 'IsVisible',
                    dataSource: [
                        { text: 'Yes', value: true },
                        { text: 'No', value: false },
                    ],
                    add: { sibling: 2 }
                }
            ],
            additionalField: [],
            /*
            * Before submiting the form onSubmit callback is invoked
            * By passing following argument
            * 1 first: form submit dto
            * 2 second: unknown
            * 3 editing row data 
            */
            onSubmit: function (formModel, data, model) {
                formModel.Id = model.Id
                formModel.ActivityId = window.ActivityId;
            },
            // following callback function invoked after http request is successed
            onSaveSuccess: function () {
                tabs.gridModel && tabs.gridModel.Reload();
            },
            save: `/${controller}/Create`,
            saveChange: `/${controller}/Edit`,
        });
    };

    function add() {
        AddBase({ title: 'Create New Brand', action: 'add' });
    };

    function edit(model, grid) {
        AddBase({ data: model, title: 'Edit Brand', action: 'edit' }, grid);
    };


    //Tab config
    const tab = (id, title, status, isDeleted = 0) => {
        return {
            Id: id,
            Name: title.toLowerCase(),
            Title: title,
            filter: isDeleted ?
                [{ "field": "IsDeleted", "value": isDeleted, Operation: 0 }]
                :
                [{ "field": "IsVisible", "value": status, Operation: 0 },
                { "field": "IsDeleted", "value": isDeleted, Operation: 0 }],
            remove: isDeleted ? false : { save: `/${controller}/Remove` },
            actions: isDeleted ? [] : [{
                click: edit,
                html: editBtn
            }],
            onDataBinding: () => { },
            rowBound: () => { },
            columns: columns(),
            Url: 'Get',
        }
    }

    //Tabs config
    const tabs = {
        container: $('#page_container'),
        Base: {
            Url: `/${controller}/`,
        },
        items: [
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB79', 'Visibile', true),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB78', 'Invisibile', false),
            tab('014D50FD-18CA-4CE8-951B-35ECAB91CB76', 'Deleted', '', 1)
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