// TODO: Search Content [X]
// TODO: Dropdown not loading
// TODO: Add textarea for excerpt
// TODO: Category select
// TODO: Remove vat [X]

import { editBtn, imageBtn, menuBtn, plusBtn, starBtn } from "../buttons.js";
import { url } from '../utils.js';

(function () {
    const controller = 'Product';

    $(document).ready(() => {
        $('#add-record').click(add);
    });

    const columns = () => [
        { field: 'ImageURL', title: 'Image', filter: false, add: false, bound: imageBound },
        { field: 'Name', title: 'Name', filter: true, position: 1 },
        { field: 'CurrentPrice', title: 'Current Price', filter: true, position: 3 },
        { field: 'StockUnit', title: 'Stock', filter: true, position: 7 },
        { field: 'PackSize', title: 'Pack Size', filter: true, position: 9 },
        { field: 'UnitName', title: 'Unit', filter: true, add: false },
        { field: 'BrandName', title: 'Brand', filter: true, add: false },
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
                    add: { sibling: 3 },
                    position: 13,
                },
                {
                    title: 'Display on Home Page',
                    Id: 'IsInHomePage',
                    dataSource: [
                        { text: 'Yes', value: true },
                        { text: 'No', value: false },
                    ],
                    add: { sibling: 3 },
                    position: 14
                },
                {
                    title: 'Is upcomming product',
                    Id: 'IsUpComming',
                    dataSource: [
                        { text: 'Yes', value: true },
                        { text: 'No', value: false },
                    ],
                    add: { sibling: 3 },
                    position: 15
                },
                {
                    Id: 'BrandId',
                    url: `/Brand/AutoComplete`,
                    type: 'AutoComplete',
                    title: 'Brand',
                    position: 10,
                    required: false
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
                { field: 'OriginalPrice', title: 'Original Price', position: 3 },
                { field: 'DiscountedPrice', title: 'Dicounted Price', position: 4 },
                { field: 'DiscountedPercentage', title: 'Discounted Percentage', position: 5 },
                { field: 'TradePrice', title: 'Trade Price', position: 6 },
                { field: 'Rank', title: 'Rank', position: 11 },
                { field: 'Excerpt', title: 'Excerpt', Type: 'textarea', position: 12, add: { sibling: 1 } },
                { field: 'SearchQuery', title: 'Search Query', position: 12, add: { sibling: 1 } },

            ],
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
        popup({ title: 'Create New Brand', action: 'add' });
    };

    function edit(model, grid) {
        popup({ data: model, title: 'Edit Brand', action: 'edit' }, grid);
    };

    const addToCategory = (row) => {
        Global.Add({
            productId: row.Id,
            name: 'add-product-to-categories' + row.Id,
            url: '/js/product-area/categories-modal.js',
        });
    }

    const uploadImage = (row) => {
        Global.Add({
            name: 'add-product-image',
            url: '/js/utils/file-uploader.js',
            save: `/${controller}/UploadImage`,
            model: row,
            ItemId: row.Id,
            onAdd: function () {
                tabs.gridModel?.Reload();
            },
            onDelete: function () {

            }
        });
    }

    function imageBound(td) {
        td.html(`<img src="${url(this.ImageURL)}" style="max-height: 80px; max-width: 100%;" />`);
    }

    const markAsHighlighted = (row, grid) => {
       fetch(`/${controller}/MarkAsHighlighted/` + row.Id, {
           method: 'GET',
       }).then(res => res.json())
       .then(data => {
           if(data.IsError)
            throw new Error(data.Msg)

            // Toaster will be perfact here
            grid.Reload();
            alert("Product Marked as highlighted successfully");
       }).catch((err) => {
            alert(err);
       });
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
                    click: uploadImage,
                    html: imageBtn()
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


    // Image Upload
    // $('#file-input').change((e) => {
    //     console.log(e.target.files);
    //     $('#preview').html(`
    //     <div class="preview-box">
    //         <img src="${URL.createObjectURL(e.target.files[0])}" alt="Alternate Text" />
    //     </div>
    //     `)
    // });

    // $('#image-upload').click((e) => {
    //     if($('#file-input')[0].files.length <= 0){
    //         alert("No image found, Please select image");
    //         return;
    //     }

    //     const formData = new FormData();
    //     formData.append('id', selectedRow.Id);
    //     formData.append('activityId', '00000000-0000-0000-0000-000000000000');
    //     formData.append('image', $('#file-input')[0].files[0]);

    //     fetch(`/${controller}/UploadImage`, {
    //         method: "POST",
    //         body: formData,
    //     }).then(res => {
    //         return json(res);
    //     }).then(data => {
    //         console.log(data.msg);
    //     });

    // })

})();