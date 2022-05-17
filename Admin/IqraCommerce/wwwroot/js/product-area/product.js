import { editBtn, imageBtn, menuBtn, fileBtn } from "../buttons.js";
import { url } from '../utils.js';

(function () {
    const controller = 'Product';

    $(document).ready(() => {
        $('#add-record').click(add);
    });

    const columns = () => [
        { field: 'ImageURL', title: 'Image', filter: false, add: false, bound: imageBound },
        { field: 'Name', title: 'Name', filter: true, position: 1 },
        { field: 'CurrentPrice', title: 'Current Price(Tk)', filter: true, position: 3,add:{datatype:'float'} },
        { field: 'StockUnit', title: 'Stock', filter: true, position: 7 },
        { field: 'PackSize', title: 'Pack Size', filter: true, position: 9 },
        { field: 'UnitName', title: 'Unit', filter: true, add: false },
        { field: 'Remarks', title: 'Remarks', Width: '255px', add: { sibling: 1 }, position: 16, },
        { field: 'CreatedBy', title: 'Creator', add: false },
        { field: 'CreatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Creation Date', add: false },
        { field: 'UpdatedBy', title: 'Updator', add: false },
        { field: 'UpdatedAt', dateFormat: 'dd/MM/yyyy hh:mm', title: 'Last Updated', add: false },
    ];

    // Add / Edit popup config
    function popup(options) {
        Global.Add({
            name: 'edit-product-record',
            title: 'Add Product',
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
                    add: { sibling: 2 },
                    position: 12,
                },
                {
                    Id: 'UnitId',
                    url: `/Unit/AutoComplete`,
                    type: 'AutoComplete',
                    title: 'Sales Unit',
                    position: 8,
                    required: false
                }
            ],
            additionalField: [
                { field: 'DisplayName', title: 'Display Name', position: 2 },
                { field: 'OriginalPrice', title: 'Original Price(Tk)', position: 3 },
                { field: 'DiscountedPrice', title: 'Dicounted Price(Tk)', position: 4 },
                { field: 'DiscountedPercentage', title: 'Discounted Percentage(%)', position: 5 },
                { field: 'TradePrice', title: 'Trade Price', position: 6 },
                { field: 'Rank', title: 'Rank', position: 11 },
                { field: 'Excerpt', title: 'Excerpt', Type: 'textarea', position: 13, add: { sibling: 1 } },
                { field: 'SearchQuery', title: 'Search Query', position: 14, add: { sibling: 1 } },

            ],
            onviewcreated:(windowModel, formInputs, dropDownList, IsNew, formModel)=>{
                formInputs['CurrentPrice'].addEventListener('input', currentPriceInputHandler.bind(null, formModel));
                formInputs['OriginalPrice'].addEventListener('input', originalPriceInputHandler.bind(null, formModel));
                formInputs['DiscountedPrice'].addEventListener('input', discountedPriceInputHandler.bind(null, formModel));
                formInputs['DiscountedPercentage'].addEventListener('input', discountedPercentageInputHandler.bind(null, formModel));
            },
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
        popup({ title: 'Create New Product', action: 'add' });
    };

    function edit(model, grid) {
        popup({ data: model, title: 'Edit Product', action: 'edit' }, grid);
    };

    const addToCategory = (row) => {
        Global.Add({
            productId: row.Id,
            name: 'add-product-to-categories' + row.Id,
            url: '/js/product-area/categories-modal.js',
        });
    }

    const gotoImages = (row) => {
        window.open(`/Product/Images?id=${row.Id}`, "_blank");
    }

    function imageBound(td) {
        td.html(`<img src="${url(this.ImageURL)}" style="max-height: 80px; max-width: 100%;" />`);
    }

    const gotoProductEditor = (row) => {
        window.open(`/Product/Description?id=${row.Id}`, "_blank");
    }

    const currentPriceInputHandler = (values) => {
        values.DiscountedPrice = values.OriginalPrice - values.CurrentPrice;
        values.DiscountedPercentage = ((1 - values.CurrentPrice/values.OriginalPrice)*100).toFixed(4);
    }

    const originalPriceInputHandler = (values) => {
        values.DiscountedPrice = values.OriginalPrice - values.CurrentPrice;
        values.DiscountedPercentage = ((1 - values.CurrentPrice/values.OriginalPrice)*100).toFixed(4);
    }
    
    const discountedPriceInputHandler = (values) => {
        values.CurrentPrice = values.OriginalPrice - values.DiscountedPrice;
        values.DiscountedPercentage = ((1 - values.CurrentPrice/values.OriginalPrice)*100).toFixed(4);
    }

    const discountedPercentageInputHandler = (values) => {
        values.DiscountedPrice = (values.OriginalPrice * values.DiscountedPercentage/100).toFixed(4);
        values.CurrentPrice = values.OriginalPrice - values.DiscountedPrice;
    }


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
            actions: isDeleted ? [] : [
                {
                    click: addToCategory,
                    html: menuBtn()
                }, {
                    click: edit,
                    html: editBtn()
                }, {
                    click: gotoImages,
                    html: imageBtn()
                }, {
                    click: gotoProductEditor,
                    html: fileBtn("Edit Product Description")
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